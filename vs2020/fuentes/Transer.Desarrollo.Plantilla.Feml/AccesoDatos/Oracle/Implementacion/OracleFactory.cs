using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace AccesoDatos.Oracle
{
    public partial class OracleFactory
    {
        private DataTable GetTable(string[] nParametros, object[] vParametros, string bloque, string instruccion)
        {
            DataTable dataTable = new DataTable();
            Stopwatch timeMeasure = new Stopwatch();
            using (OracleConnection conn = GetOracleConnection())
            {
                OracleCommand cmd = new OracleCommand(_select.Select(bloque, instruccion), conn);

                switch (bloque)
                {
                    case "StoreProcedura":
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

                cmd.Parameters.Add(GetRefcursor());

                for (int i = 0; i < _nParametros.Length; i++)
                {
                    cmd.Parameters.Add(parametroInt(_nParametros[i], _vParametros[i]));
                }

                OracleDataAdapter dataAdapter = new OracleDataAdapter(cmd);

                try
                {
                    timeMeasure.Start();
                    dataAdapter.Fill(dataTable);
                    timeMeasure.Stop();
                    _eP._timeSpan = timeMeasure.Elapsed;
                    _eP._Continua = true;
                    _eP._Fecha = DateTime.UtcNow;
                    _eP.Registro(MensajeGetTable(nParametros, vParametros, bloque, instruccion, dataTable.Rows.Count));
                }
                catch (OracleException ex)
                {
                    timeMeasure.Stop();
                    _eP._timeSpan = timeMeasure.Elapsed;
                    _eP._Mensaje = ex.Message;
                    _eP._Continua = false;
                    _eP._Excepcion = ex.Message;
                    _eP._Fecha = DateTime.UtcNow;
                    _eP.Registro(MensajeGetTableError(nParametros, vParametros, bloque, instruccion, ex.Message));
                }
                catch (Exception ex)
                {
                    timeMeasure.Stop();
                    _eP._timeSpan = timeMeasure.Elapsed;
                    _eP._Mensaje = ex.Message;
                    _eP._Continua = false;
                    _eP._Excepcion = ex.Message;
                    _eP._Fecha = DateTime.UtcNow;
                    _eP.Registro(MensajeGetTableError(nParametros, vParametros, bloque, instruccion, ex.Message));
                }

            }
            return dataTable;
        }

        private string MensajeGetTableError(string[] nParametros, object[] vParametros, string bloque, string instruccion, string mensajeError)
        {
            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.AppendLine("Error al momento de ejecutar requerimiento");
            sbMensaje.AppendLine("# # # # # # # # # # # # # # # # # # # # #" );
            sbMensaje.AppendLine(" ");
            sbMensaje.AppendLine("Detalles de la instruccion:");
            sbMensaje.AppendLine("Tiempo de ejecucion : " + _timeSpan);
            sbMensaje.AppendLine("Detalle del error : " + mensajeError);
            sbMensaje.AppendLine("Bloque : " + bloque);
            sbMensaje.AppendLine("Instruccion : " + instruccion);
            sbMensaje.AppendLine(" ");
            sbMensaje.AppendLine("Detalle de los Parametros : ");
            sbMensaje.AppendLine(" ");
            for (int i = 0; i < _nParametros.Length; i++)
            {
                sbMensaje.AppendLine("* Parametro : " + _nParametros[i] + " Valor : " + _vParametros[i]);
            }
            sbMensaje.AppendLine(" ");
            return sbMensaje.ToString();
        }

        private string MensajeGetTable(string[] nParametros, object[] vParametros, string bloque, string instruccion, int rows)
        {
            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.AppendLine("Ejecucion Exitosa del metodo GetTable");
            sbMensaje.AppendLine("# # # # # # # # # # # # # # # # # # #");
            sbMensaje.AppendLine(" ");
            sbMensaje.AppendLine("Detalles de la instruccion:");
            sbMensaje.AppendLine("Tiempo de ejecucion : " + _timeSpan);
            sbMensaje.AppendLine("Filas Devueltas : " + rows);
            sbMensaje.AppendLine("Bloque : " + bloque);
            sbMensaje.AppendLine("Instruccion : " + instruccion);
            sbMensaje.AppendLine(" ");
            sbMensaje.AppendLine("Detalle de los Parametros : ");
            sbMensaje.AppendLine(" ");
            for (int i = 0; i < _nParametros.Length; i++)
            {
                sbMensaje.AppendLine("* Parametro : " + _nParametros[i] + " Valor : " + _vParametros[i]);
            }
            sbMensaje.AppendLine(" ");
            return sbMensaje.ToString();
        }

        private OracleConnection GetOracleConnection()
        {
            OracleConnection conn = new OracleConnection();
            try
            {
                conn = new OracleConnection(GetConnectionString())
                {
                    //ActionName = "ManagedDataAccess_FEML",
                    //ClientId = "Francisco Montoya",
                    //ClientInfo = "Acceso Autorizado Automatico"
                };
            }
            catch (OracleException ex)
            {
                _eP._Mensaje = ex.Message;
                _eP._Continua = false;
                _eP._Excepcion = ex.Message;
                _eP._Fecha = DateTime.UtcNow;
            }
            catch (Exception ex)
            {
                _eP._Mensaje = ex.Message;
                _eP._Continua = false;
                _eP._Excepcion = ex.Message;
                _eP._Fecha = DateTime.UtcNow;
            }

            return conn;
        }

        private string GetConnectionString()
        {
            string cadena = string.Empty;
            try
            {
                cadena = _credentials.cadena;
            }
            catch (OracleException ex)
            {
                _eP._Mensaje = ex.Message;
                _eP._Continua = false;
                _eP._Excepcion = ex.Message;
                _eP._Fecha = DateTime.UtcNow;
            }
            catch (Exception ex)
            {
                _eP._Mensaje = ex.Message;
                _eP._Continua = false;
                _eP._Excepcion = ex.Message;
                _eP._Fecha = DateTime.UtcNow;
            }
            return cadena;
        }

        private OracleParameter GetRefcursor()
        {
            OracleParameter p_refcursor = new OracleParameter();
            p_refcursor.OracleDbType = OracleDbType.RefCursor;
            p_refcursor.Direction = ParameterDirection.ReturnValue;
            return p_refcursor;
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

    }
}
