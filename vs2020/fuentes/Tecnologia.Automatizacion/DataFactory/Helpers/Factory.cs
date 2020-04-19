using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace DataFactory
{
    public partial class Factory : IDisposable
    {
        private DataTable getTableRader(string library, string select, string[] nParametros, object[] vParametros)
        {
            Successfulexecution = false;
            int recordProcessed = int.MinValue;
            DataTable dtTmp = new DataTable();
            using (OracleConnection conn = new OracleConnection(security.GetCadena()))
            {
                OracleCommand cmd = GetOracleCommand(library, select, nParametros, vParametros, conn);
                cmd.CommandType = GetCommandType(cmd, select);

                OracleParameter p_refcursor = AddOracleParameter();

                cmd.Parameters.Add(p_refcursor);

                for (int i = 0; i < nParametros.Length; i++)
                {
                    cmd.Parameters.Add(parametroInt(nParametros[i], vParametros[i]));
                }

                try
                {
                    timeMeasure.Restart();
                    timeMeasure.Start();
                    recordProcessed = (int)cmd.ExecuteNonQuery();//El método executeNonQuery ejecuta el stored procedure y éste nos devolverá el cursor ya abierto el cual tiene identificado el conjunto de filas a recuperar.
                    Successfulexecution = true;
                    SendRecordtoMail("Program Execution Error", SuccessfulExecution(timeMeasure, security.GetCadena(), cmd, recordProcessed));
                    OracleRefCursor cursor = (OracleRefCursor)p_refcursor.Value;

                    OracleDataReader dr = cursor.GetDataReader();//Se crea el objeto DataReader mediante el valor obtenido por el cursor (OracleParameter) para recorrer la información y cargarla a nuestro arreglo.


                    /*  En muchas situaciones es recomendable aumentar el tamaño en ventaja de recoger la información más rápido siendo más eficientes. Esto se realiza con la siguiente línea de código:
                        dr.FetchSize = cmd.RowSize * 100;
                        En este caso esperamos recibir la información en bloques de 100 filas, por lo cual si una tabla tiene 1000 filas se harán 10 viajes de la capa de base de datos a la capa cliente para obtener la información completa de la tabla.
                        La vista V$SQL tiene los campos: executions, fetches y rows_processed los cuales nos pueden ayudar a definir la cantidad de filas hacer retornadas en un fetch de manera eficiente. 
                        Por ejemplo: Si obtenemos el ratio de rows_processed/executions nos daría la cantidad de filas promedio obtenidas en una ejecución del query. 
                        El ratio de fetches/executions nos entrega la cantidad de fetchs en cada ejecución. 
                        Obteniendo ambos ratios tenemos la cantidad de filas y fetchs de cada ejecución del query los cuales podrían ser reducidos ampliando la cantidad de filas a traer en cada operación de fetch.
                     */

                    FieldInfo fi = dr.GetType().GetField("m_rowSize", BindingFlags.Instance | BindingFlags.NonPublic);
                    fi = dr.GetType().GetField("m_rowSize", BindingFlags.Instance);

                    //Existe un bug con el atributo RowSize del objeto Command ya que devuelve siempre el valor de 0. Para evitar el bug y conseguir el tamaño en bytes de una fila se ha implementado las siguientes líneas de código.
                    int rowsize = 0;
                    try
                    {
                        //int rowsize = Convert.ToInt32(fi.GetValue(dr));
                        rowsize = dr.FieldCount * 100;
                    }
                    catch (Exception ex)
                    {
                        string whats = ex.Message;
                        rowsize = 1515;
                    }

                    //Un fetch es un conjunto de filas que recoge la capa de aplicación de la base de datos mientras recorre un cursor. Por default este valor es 64 KB, es decir en bloques de 64 KB se va obteniendo todas las filas de un cursor.
                    dr.FetchSize = rowsize * 100;
                    while (dr.Read())
                    {
                        /*EConsulta objConsulta = new EConsulta();
                        objConsulta.ORCA_NUMERO_NB = double.Parse(dr["ORCA_NUMERO_NB"].ToString());*/
                    }
                    p_refcursor.Dispose();
                    cmd.Dispose();

                }
                catch (OracleException ex)
                {
                    timeMeasure.Stop();
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    PrcsOracleException(buildSelect.GetCommand(library, select, nParametros, vParametros), ex, nParametros, vParametros);
                }
                catch (Exception ex)
                {
                    timeMeasure.Stop();
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    PrcsException(library, buildSelect.GetCommand(library, select, nParametros, vParametros), ex, nParametros, vParametros);
                }
                finally
                {
                    timeMeasure.Stop();
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            return dtTmp;
        }

        private DataTable getTable(string library, string select, string[] nParametros, object[] vParametros)
        {
            Successfulexecution = false;
            DataTable dtTmp = new DataTable();
            using (OracleConnection conn = new OracleConnection(security.GetCadena()))
            {
                OracleCommand cmd = GetOracleCommand(library, select, nParametros, vParametros, conn);
                cmd.CommandType = GetCommandType(cmd, select);
                cmd.Parameters.Add(AddOracleParameter());
                for (int i = 0; i < nParametros.Length; i++)
                {
                    cmd.Parameters.Add(parametroInt(nParametros[i], vParametros[i]));
                }
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                try
                {
                    timeMeasure.Restart();
                    timeMeasure.Start();
                    adapter.Fill(dtTmp);
                    Successfulexecution = true;
                    SendRecordtoMail("Program Execution Error", SuccessfulExecution(timeMeasure, security.GetCadena(), cmd, dtTmp.Rows.Count));
                }
                catch (OracleException ex)
                {
                    timeMeasure.Stop();
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    PrcsOracleException(buildSelect.GetCommand(library, select, nParametros, vParametros), ex, nParametros, vParametros);
                }
                catch (Exception ex)
                {
                    timeMeasure.Stop();
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    PrcsException(library, buildSelect.GetCommand(library, select, nParametros, vParametros), ex, nParametros, vParametros);
                }
                finally
                {
                    timeMeasure.Stop();
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            return dtTmp;
        }


        private int executeCommand(string library, string select, string[] nParametros, object[] vParametros)
        {
            Successfulexecution = false;
            int recordProcessed = int.MinValue;
            using (OracleConnection conn = new OracleConnection(security.GetCadena()))
            {
                OracleCommand cmd = GetOracleCommand(library, select, nParametros, vParametros, conn);
                cmd.CommandType = GetCommandType(cmd, select);
                for (int i = 0; i < nParametros.Length; i++)
                {
                    cmd.Parameters.Add(parametroInt(nParametros[i], vParametros[i]));
                }
                try
                {
                    conn.Open();
                    timeMeasure.Restart();
                    timeMeasure.Start();
                    recordProcessed = (int)cmd.ExecuteNonQuery();
                    Successfulexecution = true;
                    SendRecordtoMail("Program Execution Error", SuccessfulExecution(timeMeasure, security.GetCadena(), cmd, recordProcessed));
                }
                catch (OracleException ex)
                {
                    timeMeasure.Stop();
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    PrcsOracleException(buildSelect.GetCommand(library, select, nParametros, vParametros), ex, nParametros, vParametros);
                }
                catch (Exception ex)
                {
                    timeMeasure.Stop();
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    PrcsException(library, buildSelect.GetCommand(library, select, nParametros, vParametros), ex, nParametros, vParametros);
                }
                finally
                {
                    timeMeasure.Stop();
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            return recordProcessed;
        }
        private CommandType GetCommandType(OracleCommand cmd, string select)
        {
            switch (select)
            {
                case "FDB_LEER_ANEXOS_DIAN":
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        break;
                    }
                default:
                    {
                        cmd.CommandType = CommandType.Text;
                        break;
                    }
            }
            return cmd.CommandType;
        }
        private OracleParameter AddOracleParameter()
        {
            OracleParameter p_refcursor = new OracleParameter();
            p_refcursor.OracleDbType = OracleDbType.RefCursor;
            p_refcursor.Direction = ParameterDirection.ReturnValue;
            return p_refcursor;
        }
        private OracleCommand GetOracleCommand(string library, string select, string[] nParametros, object[] vParametros, OracleConnection conn)
        {
            ComandoConsulta = buildSelect.GetCommand(library, select, nParametros, vParametros);
            OracleCommand cmd = new OracleCommand(buildSelect.GetCommand(library, select, nParametros, vParametros), conn);
            return cmd;
        }
        private OracleParameter parametroInt(string pnombre, object valor)
        {

            bool continua = true;
            OracleParameter op = new OracleParameter();
            op.ParameterName = pnombre;
            op.Direction = ParameterDirection.Input;
            while (continua)
            {
                if (valor.GetType() == Type.GetType("System.String"))
                {
                    switch (pnombre)
                    {
                        case ":soaprespuesta":
                            {

                                //OracleParameter psoapEnviado = new OracleParameter(":soapEnviado", OracleDbType.Blob);
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    writer.Write(valor);
                                    writer.Flush();
                                    stream.Position = 0;
                                    byte[] bfiledata = new byte[stream.Length];
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        case ":xmlfactura":
                            {

                                //OracleParameter psoapEnviado = new OracleParameter(":soapEnviado", OracleDbType.Blob);
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    writer.Write(valor);
                                    writer.Flush();
                                    stream.Position = 0;
                                    byte[] bfiledata = new byte[stream.Length];
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        case ":filedata":
                            {

                                //OracleParameter psoapEnviado = new OracleParameter(":soapEnviado", OracleDbType.Blob);
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    writer.Write(valor);
                                    writer.Flush();
                                    stream.Position = 0;
                                    byte[] bfiledata = new byte[stream.Length];
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        case ":soapenviado":
                            {

                                //OracleParameter psoapEnviado = new OracleParameter(":soapEnviado", OracleDbType.Blob);
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    writer.Write(valor);
                                    writer.Flush();
                                    stream.Position = 0;
                                    byte[] bfiledata = new byte[stream.Length];
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        case ":soapEnviado":
                            {

                                //OracleParameter psoapEnviado = new OracleParameter(":soapEnviado", OracleDbType.Blob);
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    writer.Write(valor);
                                    writer.Flush();
                                    stream.Position = 0;
                                    byte[] bfiledata = new byte[stream.Length];
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        case ":soapRecibido":
                            {
                                //OracleParameter psoapEnviado = new OracleParameter(":soapEnviado", OracleDbType.Blob);
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    writer.Write(valor);
                                    writer.Flush();
                                    stream.Position = 0;
                                    byte[] bfiledata = new byte[stream.Length];
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        case ":indi_xmllegal":
                            {
                                //OracleParameter psoapEnviado = new OracleParameter(":soapEnviado", OracleDbType.Blob);
                                string perro = (string)valor;
                                op.OracleDbType = OracleDbType.Clob;
                                op.Direction = ParameterDirection.Input;
                                op.Value = perro;
                                continua = false;
                                break;
                            }
                        case ":indi_xmlrec":
                            {
                                //OracleParameter psoapEnviado = new OracleParameter(":soapEnviado", OracleDbType.Blob);
                                string svalor = (string)valor;
                                byte[] bfiledata = Encoding.ASCII.GetBytes(svalor);
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        default:
                            {
                                op.Value = (string)valor;
                                op.OracleDbType = OracleDbType.Varchar2;
                                continua = false;
                                break;
                            }
                    }
                    break;
                }
                if (valor.GetType() == Type.GetType("System.Int32"))
                {
                    op.Value = (int)valor;
                    op.OracleDbType = OracleDbType.Int32;
                    continua = false;
                    break;
                }
                if (valor.GetType() == Type.GetType("System.Double"))
                {
                    op.Value = (Double)valor;
                    op.OracleDbType = OracleDbType.Int32;
                    continua = false;
                    break;
                }
                if (valor.GetType() == Type.GetType("System.Int64"))
                {
                    op.Value = (long)valor;
                    op.OracleDbType = OracleDbType.Int32;
                    continua = false;
                    break;
                }
                if (valor.GetType() == Type.GetType("System.DateTime"))
                {
                    DateTime fecha = (DateTime)valor;
                    op.Value = fecha;
                    op.OracleDbType = OracleDbType.Date;
                    continua = false;
                    break;
                }
                if (valor.GetType() == Type.GetType("System.Byte[]"))
                {
                    switch (pnombre)
                    {
                        case ":indi_repgrafica":
                            {
                                byte[] bfiledata = (byte[])valor;
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        case ":indi_xmlrec":
                            {
                                byte[] bfiledata = (byte[])valor;
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        default:
                            {
                                byte[] myBytes = (byte[])valor;
                                op.Value = myBytes;
                                op.OracleDbType = OracleDbType.Clob;
                                continua = false;
                                break;
                            }
                    }
                    break;
                }
                if (valor.GetType() == Type.GetType("System.Byte"))
                {
                    byte[] myBytes = (byte[])valor;
                    op.Value = myBytes;
                    op.OracleDbType = OracleDbType.Clob;
                    continua = false;
                    break;
                }
                if (valor.GetType() == Type.GetType("System.Sbyte"))
                {
                    byte[] myBytes = (byte[])valor;
                    op.Value = myBytes;
                    op.OracleDbType = OracleDbType.Clob;
                    continua = false;
                    break;
                }
                if (continua)
                {
                    continua = false;
                    break;
                }
            }
            return op;
        }
        private void log(string texto)
        {
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine(texto);
            }
        }
        private void PrcsException(string library, string select, Exception ex, string[] nParametros, object[] vParametros)
        {
            DetalleExcepcion.Rows.Add(ex.Message, ex.StackTrace, ex.Source, select);
            logException(buildSelect.GetCommand(library, select, nParametros, vParametros), DetalleExcepcion);
        }
        private void PrcsOracleException(string select, OracleException ex, string[] nParametros, object[] vParametros)
        {
            DetalleExcepcionOracle.Rows.Add(ex.Number, ex.Procedure, ex.DataSource, ex.Source, ex.ErrorCode, ex.Message.ToString(), select);
            logOracleException(select, DetalleExcepcionOracle);
        }
        private void logException(string texto, DataTable dtMensaje)
        {
            string mensaje = string.Empty;
            if (dtMensaje.Rows.Count > 0)
            {
                mensaje = GetMensajeException(texto, dtMensaje);
                BurnRecordtoDisk(mensaje);
                SendRecordtoMail("Program Execution Error", mensaje);
            }
        }
        private void logOracleException(string texto, DataTable dtMensaje)
        {
            string mensaje = string.Empty;
            if (dtMensaje.Rows.Count > 0)
            {
                mensaje = GetMensajeOracleException(texto, dtMensaje);
                BurnRecordtoDisk(mensaje);
                SendRecordtoMail("Program Execution Error", mensaje);
            }
        }

        private void SendRecordtoMail(string asunto, string mensaje)
        {
            correo.CorreoDesarrollador(asunto, mensaje);
        }

        private void BurnRecordtoDisk(string mensaje)
        {
            using (StreamWriter writer = new StreamWriter("ProgramExecutionError.txt", true))
            {
                writer.WriteLine(mensaje);
            }
        }

        private string GetMensajeException(string texto, DataTable dtMensaje)
        {
            string HostName = Dns.GetHostName();
            IPAddress[] ipaddress = Dns.GetHostAddresses(HostName);
            //foreach (IPAddress ip in ipaddress)
            //{
            //    Console.WriteLine(ip.ToString());
            //}
            string mensaje = string.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dtMensaje.Rows)
            {
                sb.AppendLine();
                sb.AppendLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                sb.AppendLine("Se Produjo un error al ejecutar el comando de tipo OracleException:");
                sb.AppendLine(texto);
                sb.AppendLine(" ");
                sb.AppendLine(" # # # #  # # # #  # # # #  # # # #  # # # # ");
                sb.AppendLine("Informacion Asociada al Error... ");
                sb.AppendLine("Message : " + dr["Message"].ToString());
                sb.AppendLine("StackTrace : " + dr["StackTrace"].ToString());
                sb.AppendLine("Source : " + dr["Source"].ToString());
                sb.AppendLine("select : " + dr["select"].ToString());

                if (_vParametros.Length > 0)
                {
                    sb.AppendLine(" ");
                    sb.AppendLine(" # # # #  # # # #  # # # #  # # # #  # # # # ");
                    sb.AppendLine(" Informacion de los parametros");
                    for (int i = 0; i < _vParametros.Length; i++)
                    {
                        sb.AppendLine("Nombre del Parametro : " + _nParametros[i].ToString());
                        sb.AppendLine("Valor del Parametro : " + _vParametros[i].ToString());
                    }
                }
                sb.AppendLine(" ");
                sb.AppendLine(" # # # #  # # # #  # # # #  # # # #  # # # # ");
                sb.AppendLine(" Informacion del Equipo ");
                sb.AppendLine(" Nombre del Equipo : " + HostName);
                sb.AppendLine(" Detalle de la tarjeta de Red ");
                foreach (IPAddress ip4 in ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
                {
                    sb.AppendLine("IPv4 of Machine is ");
                    sb.AppendLine(ip4.ToString());
                }
                foreach (IPAddress ip6 in ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6))
                {
                    sb.AppendLine("IPv6 of Machine is ");
                    sb.AppendLine(ip6.ToString());
                }
                sb.AppendLine(" * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine(" ");
                mensaje = sb.ToString();
            }
            return mensaje;
        }
        private string GetMensajeOracleException(string texto, DataTable dtMensaje)
        {
            string HostName = Dns.GetHostName();
            IPAddress[] ipaddress = Dns.GetHostAddresses(HostName);
            //foreach (IPAddress ip in ipaddress)
            //{
            //    Console.WriteLine(ip.ToString());
            //}
            string mensaje = string.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dtMensaje.Rows)
            {
                sb.AppendLine();
                sb.AppendLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                sb.AppendLine("Se Produjo un error al ejecutar el comando de tipo OracleException:");
                sb.AppendLine(texto);
                sb.AppendLine(" ");
                sb.AppendLine(" # # # #  # # # #  # # # #  # # # #  # # # # ");
                sb.AppendLine("Informacion Asociada al Error... ");
                sb.AppendLine("Number : " + dr["Number"].ToString());
                sb.AppendLine("Procedure : " + dr["Procedure"].ToString());
                sb.AppendLine("DataSource : " + dr["DataSource"].ToString());
                sb.AppendLine("Source : " + dr["Source"].ToString());
                sb.AppendLine("ErrorCode : " + dr["ErrorCode"].ToString());
                sb.AppendLine("Mensaje : " + dr["Mensaje"].ToString());
                if (_vParametros.Length > 0)
                {
                    sb.AppendLine(" ");
                    sb.AppendLine(" # # # #  # # # #  # # # #  # # # #  # # # # ");
                    sb.AppendLine(" Informacion de los parametros");
                    for (int i = 0; i < _vParametros.Length; i++)
                    {
                        sb.AppendLine("Nombre del Parametro : " + _nParametros[i].ToString());
                        sb.AppendLine("Valor del Parametro : " + _vParametros[i].ToString());
                    }
                }
                sb.AppendLine(" ");
                sb.AppendLine(" # # # #  # # # #  # # # #  # # # #  # # # # ");
                sb.AppendLine(" Informacion del Equipo ");
                sb.AppendLine(" Nombre del Equipo : " + HostName);
                sb.AppendLine(" Detalle de la tarjeta de Red ");
                foreach (IPAddress ip4 in ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
                {
                    sb.AppendLine("IPv4 of Machine is ");
                    sb.AppendLine(ip4.ToString());
                }
                foreach (IPAddress ip6 in ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6))
                {
                    sb.AppendLine("IPv6 of Machine is ");
                    sb.AppendLine(ip6.ToString());
                }
                sb.AppendLine(" * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine(" ");
                mensaje = sb.ToString();
            }
            return mensaje;
        }

        private string SuccessfulExecution(Stopwatch timeMeasure, string Cadena, OracleCommand cmd, int RowsReturn)
        {
            string mensaje = string.Empty;
            string HostName = Dns.GetHostName();
            IPAddress[] ipaddress = Dns.GetHostAddresses(HostName);
            //foreach (IPAddress ip in ipaddress)
            //{
            //    Console.WriteLine(ip.ToString());
            //}
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
            sb.AppendLine("Ejecucion Exitosa....");
            sb.AppendLine(" ");
            sb.AppendLine(" &       &       &       &       &       &       &");
            sb.AppendLine("Informacion Asociada a la Ejecucion del comando");
            sb.AppendLine("Regisros Obtenidos : " + RowsReturn);
            sb.AppendLine("Comando : " + cmd.CommandText);
            sb.AppendLine("Cadena de Conexion  : " + Cadena);
            sb.AppendLine("Tiempo de Ejecucion Milesegundos  : " + timeMeasure.ElapsedMilliseconds);
            if (_vParametros.Length > 0)
            {
                sb.AppendLine(" ");
                sb.AppendLine(" # # # #  # # # #  # # # #  # # # #  # # # # ");
                sb.AppendLine(" Informacion de los parametros");
                for (int i = 0; i < _vParametros.Length; i++)
                {
                    sb.AppendLine("Nombre del Parametro : " + _nParametros[i].ToString());
                    sb.AppendLine("Valor del Parametro : " + _vParametros[i].ToString());
                }
            }
            sb.AppendLine(" ");
            sb.AppendLine(" # # # #  # # # #  # # # #  # # # #  # # # # ");
            sb.AppendLine(" Informacion del Equipo ");
            sb.AppendLine(" Nombre del Equipo : " + HostName);
            sb.AppendLine(" Detalle de la tarjeta de Red ");
            foreach (IPAddress ip4 in ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
            {
                sb.AppendLine("IPv4 of Machine is ");
                sb.AppendLine(ip4.ToString());
            }
            foreach (IPAddress ip6 in ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6))
            {
                sb.AppendLine("IPv6 of Machine is ");
                sb.AppendLine(ip6.ToString());
            }
            sb.AppendLine(" * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            sb.AppendLine(" ");
            mensaje = sb.ToString();
            return mensaje;
        }

    }
}
