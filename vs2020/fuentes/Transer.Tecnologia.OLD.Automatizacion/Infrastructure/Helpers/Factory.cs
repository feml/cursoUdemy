using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public partial class Factory : IDisposable
    {
        public Factory()
        {
        }
        public Factory(string Nombreprograma)
        {
        }
        private DataTable GetTableReader(string library, string select, string[] _nParametros, object[] _vParametros)
        {
            Info.avance(select);
            DataTable dtTmp = new DataTable();
            using (OracleConnection conn = new OracleConnection(_Security.cadena))
            {
                Info.avance(SelectCommand.GetCommand(library, select, _nParametros, _vParametros));
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                OracleCommand cmd = new OracleCommand(SelectCommand.GetCommand(library, select, _nParametros, _vParametros), conn);
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
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

                //Debido a que el stored procedure recibe un parámetro de salida creamos un objeto de tipo OracleParameter y lo definimos que será de salida y de tipo RefCursor.

                Info.avance("OracleParameter p_refcursor = new OracleParameter()");
                OracleParameter p_refcursor = new OracleParameter();
                p_refcursor.OracleDbType = OracleDbType.RefCursor;
                p_refcursor.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(p_refcursor);


                for (int i = 0; i < _nParametros.Length; i++)
                {
                    Info.avance("cmd.Parameters.Add(parametroInt(_nParametros[i], _vParametros[i]))");
                    cmd.Parameters.Add(parametroInt(_nParametros[i], _vParametros[i]));
                }

                try
                {
                    Info.avance("cmd.ExecuteNonQuery()");
                    cmd.ExecuteNonQuery();//El método executeNonQuery ejecuta el stored procedure y éste nos devolverá el cursor ya abierto el cual tiene identificado el conjunto de filas a recuperar.

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
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    PrcsOracleException(SelectCommand.GetCommand(library, select, _nParametros, _vParametros), ex);
                }
                catch (Exception ex)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    PrcsException(library, SelectCommand.GetCommand(library, select, _nParametros, _vParametros), ex, _nParametros, _vParametros);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            return dtTmp;
        }

        private DataTable GetTable(string library, string select, string[] _nParametros, object[] _vParametros)
        {
            Info.avance(select);

            DataTable dtTmp = new DataTable();
            using (OracleConnection conn = new OracleConnection(_Security.cadena))
            {
                Info.avance(SelectCommand.GetCommand(library, select, _nParametros, _vParametros));
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                OracleCommand cmd = new OracleCommand(SelectCommand.GetCommand(library, select, _nParametros, _vParametros), conn);
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
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
                Info.avance("OracleParameter p_refcursor = new OracleParameter()");
                OracleParameter p_refcursor = new OracleParameter();
                p_refcursor.OracleDbType = OracleDbType.RefCursor;
                p_refcursor.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(p_refcursor);


                for (int i = 0; i < _nParametros.Length; i++)
                {
                    Info.avance("cmd.Parameters.Add(parametroInt(_nParametros[i], _vParametros[i]))");
                    cmd.Parameters.Add(parametroInt(_nParametros[i], _vParametros[i]));
                }

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                try
                {
                    Info.avance("adapter.Fill(dtTmp)");
                    adapter.Fill(dtTmp);
                }
                catch (OracleException ex)
                {
                    Info.avance(ex.Message);
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    PrcsOracleException(SelectCommand.GetCommand(library, select, _nParametros, _vParametros), ex);
                }
                catch (Exception ex)
                {
                    Info.avance(ex.Message);
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    PrcsException(library, SelectCommand.GetCommand(library, select, _nParametros, _vParametros), ex, _nParametros, _vParametros);
                }
                finally
                {
                    Info.avance("finally");
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            return dtTmp;
        }
        private int ExecuteCommand(string library, string select, string[] _nParametros, object[] _vParametros)
        {
            int recordProcessed = int.MinValue;
            using (OracleConnection conn = new OracleConnection(_Security.cadena))
            {
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                OracleCommand cmd = new OracleCommand(SelectCommand.GetCommand(library, select, _nParametros, _vParametros), conn)
                {
                    CommandType = CommandType.Text
                };
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                for (int i = 0; i < _nParametros.Length; i++)
                {
                    cmd.Parameters.Add(parametroInt(_nParametros[i], _vParametros[i]));
                }
                try
                {
                    conn.Open();
                    recordProcessed = (int)cmd.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    PrcsOracleException(SelectCommand.GetCommand(library, select, _nParametros, _vParametros), ex);
                }
                catch (Exception ex)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    PrcsException(library, SelectCommand.GetCommand(library, select, _nParametros, _vParametros), ex, _nParametros, _vParametros);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            return recordProcessed;
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

        private void PrcsException(string library, string select, Exception ex, string[] _nParametros, object[] _vParametros)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Columns.Add("Error", typeof(string));
            dtTmp.Rows.Add(ex.Message);
            logException(SelectCommand.GetCommand(library, select, _nParametros, _vParametros), dtTmp);
        }
        private void PrcsOracleException(string select, OracleException ex)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Columns.Add("Number", typeof(int));
            dtTmp.Columns.Add("Procedure", typeof(string));
            dtTmp.Columns.Add("DataSource", typeof(string));
            dtTmp.Columns.Add("Source", typeof(string));
            dtTmp.Columns.Add("ErrorCode", typeof(int));
            dtTmp.Columns.Add("Mensaje", typeof(string));
            dtTmp.Rows.Add(ex.Number, ex.Procedure, ex.DataSource, ex.Source, ex.ErrorCode, ex.Message.ToString());
            /*dtTmp.Rows.Add(ex.Procedure);
            dtTmp.Rows.Add(ex.DataSource);
            dtTmp.Rows.Add(ex.Source);
            dtTmp.Rows.Add(ex.ErrorCode);
            dtTmp.Rows.Add(ex.Message);*/
            logOracleException(select, dtTmp);
        }
        private void logException(string texto, DataTable dtMensaje)
        {
            if (dtMensaje.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMensaje.Rows)
                {
                    using (StreamWriter writer = new StreamWriter("log.txt", true))
                    {
                        writer.WriteLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                        writer.WriteLine("Se Produjo un error al ejecutar el comando de tipo Exception:");
                        writer.WriteLine(texto);
                        writer.WriteLine(" ");
                        writer.WriteLine("Informacion Asociada al Error... ");
                        writer.WriteLine("Error : " + dr["Error"].ToString());
                        writer.WriteLine(" * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                        writer.WriteLine(" ");
                    }
                }
            }
        }
        private void logOracleException(string texto, DataTable dtMensaje)
        {
            if (dtMensaje.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMensaje.Rows)
                {
                    using (StreamWriter writer = new StreamWriter("log.txt", true))
                    {
                        writer.WriteLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                        writer.WriteLine("Se Produjo un error al ejecutar el comando de tipo OracleException:");
                        writer.WriteLine(texto);
                        writer.WriteLine(" ");
                        writer.WriteLine("Informacion Asociada al Error... ");
                        writer.WriteLine("Number : " + dr["Number"].ToString());
                        writer.WriteLine("Procedure : " + dr["Procedure"].ToString());
                        writer.WriteLine("DataSource : " + dr["DataSource"].ToString());
                        writer.WriteLine("Source : " + dr["Source"].ToString());
                        writer.WriteLine("ErrorCode : " + dr["ErrorCode"].ToString());
                        writer.WriteLine("Mensaje : " + dr["Mensaje"].ToString());
                        writer.WriteLine(" * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                        writer.WriteLine(" ");
                    }
                }
            }
        }
    }
}
