using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Transer.Desarrollo.Facturacion.Correo;
using Transer.Desarrollo.Facturacion.Registro;
using Transer.Desarrollo.Facturacion.VariablesGlobalesProyecto;

namespace Transer.Desarrollo.Facturacion.OracleManagedData
{
    public class OracleData
    {
        private Stopwatch _cronometro { get; set; }
        private Correo.Correo _correo { get; set; }
        private Registro.Registro _log { get; set; }
        private Vgp _vgp { get; set; }
        private int _intento { get; set; }
        public OracleData(Vgp Vgp)
        {
            _cronometro = new Stopwatch();
            _vgp = Vgp;
            _log = new Registro.Registro();
            _correo = new Correo.Correo(_vgp);
        }
        public DataTable daDataTable(string select, string[] _nParametros, object[] _vParametros, Vgp vgl)
        {
            _intento = 0;
            DataTable dt = new DataTable();
            try
            {
                using (OracleConnection con = new OracleConnection(vgl._Cadena))
                {
                    OracleCommand cmd = new OracleCommand(select, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("refcur1", OracleDbType.RefCursor, ParameterDirection.Output);
                    for (int i = 0; i < _nParametros.Length; i++)
                    {
                        cmd.Parameters.Add(parametroInt(_nParametros[i], _vParametros[i]));
                    }
                    _cronometro.Start();


                    while (true)
                    {
                        _intento++;
                        try
                        {
                            con.Open();
                            con.ClientId = vgl._ClienteID;
                            //con.Failover += new OracleFailoverEventHandler(OnFailover);
                            OracleDataAdapter da = new OracleDataAdapter(cmd);
                            da.Fill(dt);
                            con.Close();
                            OracleConnection.ClearAllPools();
                            _cronometro.Stop();
                            string _mensajeExitoso = "Ejecucion Exitosa.  \r\n Comando : " + select + "\r\n Tiempo de proceso : " + _cronometro.Elapsed;
                            _log.wr(_vgp._Directorio, "Oraclesuccessful.txt", _mensajeExitoso);
                            break;
                        }
                        catch (OracleException ex)
                        {
                            _cronometro.Stop();
                            string _mensajeError = @"Cadena Conexion : " + vgl._Cadena + "\n Error Number: " + ex.Number + "\nSource: " +
                                        ex.Source + "\nData source: " + ex.DataSource + "\nProcedure: " +
                                            ex.Procedure + "\nMessage: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                           "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                            _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                            Console.WriteLine(_mensajeError);
                            _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                            if (_intento > 100)
                            {
                                break;
                            }
                            else
                            {
                                _intento++;
                                Thread.Sleep(10000);
                            }
                        }
                        catch (InvalidOperationException ex)
                        {
                            _cronometro.Stop();
                            string _mensajeError = @"InvalidOperationException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                                    "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed;
                            _log.wr(_vgp._Directorio, "InvalidOperationException.txt", _mensajeError);
                            Console.WriteLine(_mensajeError);
                            _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, vgl);
                        }
                        catch (Exception ex)
                        {
                            _cronometro.Stop();
                            string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                                  "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed;
                            _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                            Console.WriteLine(_mensajeError);
                            _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, vgl);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                _cronometro.Stop();
                string _mensajeError = @"Cadena Conexion : " + vgl._Cadena + "\n Error Number: " + ex.Number + "\nSource: " +
                            ex.Source + "\nData source: " + ex.DataSource + "\nProcedure: " +
                                ex.Procedure + "\nMessage: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                           "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                Console.WriteLine(_mensajeError);
                _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
            }
            catch (InvalidOperationException ex)
            {
                _cronometro.Stop();
                string _mensajeError = @"InvalidOperationException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                Console.WriteLine(_mensajeError);
                _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
            }
            catch (Exception ex)
            {
                _cronometro.Stop();
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                Console.WriteLine(_mensajeError);
                _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
            }
            return dt;
        }
        public DataTable daDataTable(string select, Vgp vgl)
        {
            DataTable dt = new DataTable();
            try
            {
                using (OracleConnection con = new OracleConnection(vgl._Cadena))
                {
                    OracleCommand cmd = new OracleCommand(select, con);
                    cmd.CommandType = CommandType.Text;
                    _cronometro.Start();
                    _intento = 0;
                    while (true)
                    {
                        _intento++;
                        try
                        {
                            con.Open();
                            con.ClientId = vgl._ClienteID;
                            //con.Failover += new OracleFailoverEventHandler(OnFailover);
                            OracleDataAdapter da = new OracleDataAdapter(cmd);
                            da.Fill(dt);
                            con.Close();
                            OracleConnection.ClearAllPools();
                            _cronometro.Stop();
                            string _mensajeExitoso = "Ejecucion Exitosa.  \r\n Comando : " + select + "\r\n Tiempo de proceso : " + _cronometro.Elapsed;
                            _log.wr(vgl._Directorio, "Oraclesuccessful.txt", _mensajeExitoso);
                            break;
                        }
                        catch (OracleException ex)
                        {
                            _cronometro.Stop();
                            string _mensajeError = @"Cadena Conexion : " + vgl._Cadena + "\n Error Number: " + ex.Number + "\nSource: " +
                                        ex.Source + "\nData source: " + ex.DataSource + "\nProcedure: " +
                                            ex.Procedure + "\nMessage: " + ex.Message + "\nInnerException: " + ex.InnerException +
                            "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                            _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                            Console.WriteLine(_mensajeError);
                            _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                            if (_intento > 100)
                            {
                                break;
                            }
                            else
                            {
                                _intento++;
                                Thread.Sleep(10000);
                            }
                        }
                        catch (InvalidOperationException ex)
                        {
                            _cronometro.Stop();
                            string _mensajeError = @"InvalidOperationException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                            "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                            _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                            Console.WriteLine(_mensajeError);
                            _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                            if (_intento > 100)
                            {
                                break;
                            }
                            else
                            {
                                _intento++;
                                Thread.Sleep(10000);
                            }
                        }
                        catch (Exception ex)
                        {
                            _cronometro.Stop();
                            string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                            "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                            _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                            Console.WriteLine(_mensajeError);
                            _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                            if (_intento > 100)
                            {
                                break;
                            }
                            else
                            {
                                _intento++;
                                Thread.Sleep(10000);
                            }
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                _cronometro.Stop();
                string _mensajeError = @"Cadena Conexion : " + vgl._Cadena + "\n Error Number: " + ex.Number + "\nSource: " +
                            ex.Source + "\nData source: " + ex.DataSource + "\nProcedure: " +
                                ex.Procedure + "\nMessage: " + ex.Message + "\nInnerException: " + ex.InnerException +
                "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                Console.WriteLine(_mensajeError);
                _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
            }
            catch (InvalidOperationException ex)
            {
                _cronometro.Stop();
                string _mensajeError = @"InvalidOperationException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                Console.WriteLine(_mensajeError);
                _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
            }
            catch (Exception ex)
            {
                _cronometro.Stop();
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                Console.WriteLine(_mensajeError);
                _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
            }
            return dt;
        }

        public void execute(string select, Vgp vgl)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(vgl._Cadena))
                {
                    OracleCommand cmd = new OracleCommand(select, con);
                    cmd.CommandType = CommandType.Text;
                    _cronometro.Start();

                    _intento = 0;
                    while (true)
                    {
                        _intento++;
                        try
                        {
                            con.Open();
                            con.ClientId = vgl._ClienteID;
                            //con.Failover += new OracleFailoverEventHandler(OnFailover);
                            int intExecuta = (int)cmd.ExecuteNonQuery();
                            _cronometro.Stop();
                            con.Close();
                            OracleConnection.ClearAllPools();
                            string _mensajeExitoso = "Ejecucion Exitosa.  \r\n Comando : " + select + "\r\n Tiempo de proceso : " + _cronometro.Elapsed;
                            _log.wr(vgl._Directorio, "Oraclesuccessful.txt", _mensajeExitoso);
                            break;
                        }
                        catch (OracleException ex)
                        {
                            _cronometro.Stop();
                            string _mensajeError = @"Cadena Conexion : " + vgl._Cadena + "\n Error Number: " + ex.Number + "\nSource: " +
                                        ex.Source + "\nData source: " + ex.DataSource + "\nProcedure: " +
                                            ex.Procedure + "\nMessage: " + ex.Message + "\nInnerException: " + ex.InnerException +
                            "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                            _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                            Console.WriteLine(_mensajeError);
                            _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                            if (_intento > 100)
                            {
                                break;
                            }
                            else
                            {
                                _intento++;
                                Thread.Sleep(10000);
                            }
                        }
                        catch (InvalidOperationException ex)
                        {
                            _cronometro.Stop();
                            string _mensajeError = @"InvalidOperationException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                            "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                            _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                            Console.WriteLine(_mensajeError);
                            _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                            if (_intento > 100)
                            {
                                break;
                            }
                            else
                            {
                                _intento++;
                                Thread.Sleep(10000);
                            }
                        }
                        catch (Exception ex)
                        {
                            _cronometro.Stop();
                            string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                            "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                            _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                            Console.WriteLine(_mensajeError);
                            _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                            if (_intento > 100)
                            {
                                break;
                            }
                            else
                            {
                                _intento++;
                                Thread.Sleep(10000);
                            }
                        }
                    }

                }
            }
            catch (OracleException ex)
            {
                _cronometro.Stop();
                string _mensajeError = @"Cadena Conexion : " + vgl._Cadena + "\n Error Number: " + ex.Number + "\nSource: " +
                            ex.Source + "\nData source: " + ex.DataSource + "\nProcedure: " +
                                ex.Procedure + "\nMessage: " + ex.Message + "\nInnerException: " + ex.InnerException +
                "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                Console.WriteLine(_mensajeError);
                _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
            }
            catch (InvalidOperationException ex)
            {
                _cronometro.Stop();
                string _mensajeError = @"InvalidOperationException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                Console.WriteLine(_mensajeError);
                _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
            }
            catch (Exception ex)
            {
                _cronometro.Stop();
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                Console.WriteLine(_mensajeError);
                _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
            }
        }


        public DataTable getAnexos(Vgp vgl)
        {
            DataTable dtTmp = new DataTable();
            string select = @"FDB_LEER_ANEXOS_DIAN";
            using (OracleConnection con = new OracleConnection(vgl._Cadena))
            {
                OracleCommand cmd = new OracleCommand(select, con);
                cmd.CommandType = CommandType.StoredProcedure;


                OracleParameter p_refcursor = new OracleParameter();
                p_refcursor.OracleDbType = OracleDbType.RefCursor;
                p_refcursor.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(p_refcursor);

                OracleParameter pdocumento = new OracleParameter("p_numdoc_v", OracleDbType.Varchar2, 15, ParameterDirection.Input);
                pdocumento.Value = vgl._LogReporteDian.LODI_LLAVE_V2;//factura;
                cmd.Parameters.Add(pdocumento);

                OracleParameter poficina = new OracleParameter("p_oficina_n", OracleDbType.Int32, 3, ParameterDirection.Input);
                poficina.Value = vgl._LogReporteDian.LODI_OFICINA_NB;//oficina;//15
                cmd.Parameters.Add(poficina);

                OracleParameter ptipodoc = new OracleParameter("p_tipodoc_v", OracleDbType.Varchar2, 3, ParameterDirection.Input);
                ptipodoc.Value = vgl._IcpdbInfoDian.tipodocumento;//"FC";//tipodocumento;//FC
                cmd.Parameters.Add(ptipodoc);

                _intento = 0;
                while (true)
                {
                    _intento++;
                    try
                    {
                        _cronometro.Start();
                        con.Open();
                        con.ClientId = vgl._ClienteID;
                        //con.Failover += new OracleFailoverEventHandler(OnFailover);
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(dtTmp);
                        con.Close();
                        OracleConnection.ClearAllPools();
                        _cronometro.Stop();
                        string _mensajeExitoso = "Ejecucion Exitosa.  \r\n Comando : " + select + "\r\n Tiempo de proceso : " + _cronometro.Elapsed;
                        _log.wr(vgl._Directorio, "Oraclesuccessful.txt", _mensajeExitoso);
                        break;
                    }
                    catch (OracleException ex)
                    {
                        _cronometro.Stop();
                        string _mensajeError = @"Cadena Conexion : " + vgl._Cadena + "\n Error Number: " + ex.Number + "\nSource: " +
                                    ex.Source + "\nData source: " + ex.DataSource + "\nProcedure: " +
                                        ex.Procedure + "\nMessage: " + ex.Message + "\nInnerException: " + ex.InnerException +
                        "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                        _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                        Console.WriteLine(_mensajeError);
                        _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        if (_intento > 100)
                        {
                            break;
                        }
                        else
                        {
                            _intento++;
                            Thread.Sleep(10000);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        _cronometro.Stop();
                        string _mensajeError = @"InvalidOperationException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                        "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                        _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                        Console.WriteLine(_mensajeError);
                        _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                        if (_intento > 100)
                        {
                            break;
                        }
                        else
                        {
                            _intento++;
                            Thread.Sleep(10000);
                        }
                    }
                    catch (Exception ex)
                    {
                        _cronometro.Stop();
                        string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                        "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                        _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                        Console.WriteLine(_mensajeError);
                        _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                        if (_intento > 100)
                        {
                            break;
                        }
                        else
                        {
                            _intento++;
                            Thread.Sleep(10000);
                        }
                    }
                }
            }
            return dtTmp;
        }

        public void executeUploadRequest(string select, Vgp vgl)
        {
            using (OracleConnection con = new OracleConnection(vgl._Cadena))
            {
                OracleCommand cmd = new OracleCommand(select, con);

                OracleParameter pfilename = new OracleParameter(":filename", OracleDbType.Varchar2, 30);
                pfilename.Value = vgl._HttpWebRequestFunction._FileName;//httpWebResponseXmlGet._fileName;
                cmd.Parameters.Add(pfilename);

                OracleParameter pfiledata = new OracleParameter(":filedata", OracleDbType.Blob);
                using (MemoryStream stream = new MemoryStream())
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(vgl._HttpWebRequestFunction._FileData);////httpWebResponseXmlGet._fileData
                    writer.Flush();
                    stream.Position = 0;
                    byte[] bfiledata = new byte[stream.Length];
                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                    stream.Close();
                    pfiledata.Value = bfiledata;
                    stream.Flush();

                }
                cmd.Parameters.Add(pfiledata);

                OracleParameter pcompanyid = new OracleParameter(":companyid", OracleDbType.Varchar2, 30);
                pcompanyid.Value = vgl._HttpWebRequestFunction._companyId;//httpWebResponseXmlGet._companyId;
                cmd.Parameters.Add(pcompanyid);

                OracleParameter paccountid = new OracleParameter(":accountid", OracleDbType.Varchar2, 30);
                paccountid.Value = vgl._HttpWebRequestFunction._accountid;//httpWebResponseXmlGet._accountId;
                cmd.Parameters.Add(paccountid);

                OracleParameter pstatus = new OracleParameter(":status", OracleDbType.Varchar2, 2500);
                pstatus.Value = vgl._HttpWebRequestFunction._status;//httpWebResponseXmlGet._status;
                cmd.Parameters.Add(pstatus);

                OracleParameter ptransactionid = new OracleParameter(":transactionid", OracleDbType.Varchar2, 250);
                ptransactionid.Value = vgl._HttpWebRequestFunction._transactionId;//httpWebResponseXmlGet._transactionId;
                cmd.Parameters.Add(ptransactionid);

                OracleParameter pxmlfactura = new OracleParameter(":xmlfactura", OracleDbType.Blob);
                using (MemoryStream stream = new MemoryStream())
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(vgl._HttpWebRequestFunction._FacturaXml);//httpWebResponseXmlGet._facturaXml
                    writer.Flush();
                    stream.Position = 0;
                    byte[] bxmlfactura = new byte[stream.Length];
                    stream.Read(bxmlfactura, 0, System.Convert.ToInt32(stream.Length));
                    stream.Close();
                    pxmlfactura.Value = bxmlfactura;
                    stream.Flush();
                }
                cmd.Parameters.Add(pxmlfactura);

                OracleParameter psoapenviado = new OracleParameter(":soapenviado", OracleDbType.Blob);
                using (MemoryStream stream = new MemoryStream())
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(vgl._HttpWebRequestFunction._soapEnviado);//httpWebResponseXmlGet._soapEnviado
                    writer.Flush();
                    stream.Position = 0;
                    byte[] bsoapenviado = new byte[stream.Length];
                    stream.Read(bsoapenviado, 0, System.Convert.ToInt32(stream.Length));
                    stream.Close();
                    psoapenviado.Value = bsoapenviado;
                    stream.Flush();
                }
                cmd.Parameters.Add(psoapenviado);

                OracleParameter psoaprespuesta = new OracleParameter(":soaprespuesta", OracleDbType.Blob);
                using (MemoryStream stream = new MemoryStream())
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(vgl._HttpWebRequestFunction._soapRecibido);//httpWebResponseXmlGet._soapRecibido
                    writer.Flush();
                    stream.Position = 0;
                    byte[] bsoaprespuesta = new byte[stream.Length];
                    stream.Read(bsoaprespuesta, 0, System.Convert.ToInt32(stream.Length));
                    stream.Close();
                    psoaprespuesta.Value = bsoaprespuesta;
                    stream.Flush();
                }
                cmd.Parameters.Add(psoaprespuesta);

                _intento = 0;
                while (true)
                {
                    _intento++;
                    try
                    {
                        _cronometro.Start();
                        con.Open();
                        con.ClientId = vgl._ClienteID;
                        //con.Failover += new OracleFailoverEventHandler(OnFailover);
                        int resultado = (int)cmd.ExecuteNonQuery();
                        con.Close();
                        _cronometro.Stop();
                        con.Close();
                        OracleConnection.ClearAllPools();
                        string _mensajeExitoso = "Ejecucion Exitosa.  \r\n Comando : " + select + "\r\n Tiempo de proceso : " + _cronometro.Elapsed;
                        _log.wr(vgl._Directorio, "Oraclesuccessful.txt", _mensajeExitoso);
                        break;
                    }
                    catch (OracleException ex)
                    {
                        _cronometro.Stop();
                        string _mensajeError = @"Cadena Conexion : " + vgl._Cadena + "\n Error Number: " + ex.Number + "\nSource: " +
                                    ex.Source + "\nData source: " + ex.DataSource + "\nProcedure: " +
                                        ex.Procedure + "\nMessage: " + ex.Message + "\nInnerException: " + ex.InnerException +
                        "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                        _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                        Console.WriteLine(_mensajeError);
                        _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                        if (_intento > 100)
                        {
                            break;
                        }
                        else
                        {
                            _intento++;
                            Thread.Sleep(10000);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        _cronometro.Stop();
                        string _mensajeError = @"InvalidOperationException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                        "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                        _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                        Console.WriteLine(_mensajeError);
                        _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                        if (_intento > 100)
                        {
                            break;
                        }
                        else
                        {
                            _intento++;
                            Thread.Sleep(10000);
                        }
                    }
                    catch (Exception ex)
                    {
                        _cronometro.Stop();
                        string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                        "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                        _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                        Console.WriteLine(_mensajeError);
                        _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                        if (_intento > 100)
                        {
                            break;
                        }
                        else
                        {
                            _intento++;
                            Thread.Sleep(10000);
                        }
                    }
                }
            }
        }

        public void executeDetLogDian(string select, Vgp vgl)
        {
            using (OracleConnection con = new OracleConnection(vgl._Cadena))
            {
                OracleCommand cmd = new OracleCommand(select, con);

                OracleParameter psecuencia = new OracleParameter(":secuencia", OracleDbType.Int32, 13);
                psecuencia.Value = vgl._LogReporteDian.LODI_SECUENCIA_NB;
                cmd.Parameters.Add(psecuencia);

                OracleParameter poficina = new OracleParameter(":oficina", OracleDbType.Int32, 3);
                poficina.Value = vgl._LogReporteDian.LODI_OFICINA_NB;
                cmd.Parameters.Add(poficina);

                OracleParameter ptransaccion = new OracleParameter(":transaccion", OracleDbType.Int32, 3);
                ptransaccion.Value = vgl._LogReporteDian.LODI_TRANSACCION_NB;
                cmd.Parameters.Add(ptransaccion);

                OracleParameter pllave = new OracleParameter(":llave", OracleDbType.Varchar2, 15);
                pllave.Value = vgl._LogReporteDian.LODI_LLAVE_V2;
                cmd.Parameters.Add(pllave);

                OracleParameter pestado = new OracleParameter(":estado", OracleDbType.Varchar2, 1);
                pestado.Value = "E";
                cmd.Parameters.Add(pestado);

                OracleParameter piddian = new OracleParameter(":iddian", OracleDbType.Varchar2, 100);
                piddian.Value = vgl._HttpWebRequestFunction._transactionId;//vgs.httpWebResponseXmlGet._transactionId;
                cmd.Parameters.Add(piddian);

                OracleParameter pcufe = new OracleParameter(":cufe", OracleDbType.Varchar2, 100);
                pcufe.Value = vgl._HttpWebRequestFunction._cufe;//vgs.httpWebResponseXmlGet._cufe;
                cmd.Parameters.Add(pcufe);


                OracleParameter psoapEnviado = new OracleParameter(":soapEnviado", OracleDbType.Blob);
                using (MemoryStream stream = new MemoryStream())
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(vgl._HttpWebRequestFunction._soapEnviado);
                    writer.Flush();
                    stream.Position = 0;
                    byte[] bfiledata = new byte[stream.Length];
                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                    stream.Close();
                    psoapEnviado.Value = bfiledata;
                    stream.Flush();
                }
                cmd.Parameters.Add(psoapEnviado);

                OracleParameter psoapRecibido = new OracleParameter(":soapRecibido", OracleDbType.Blob);
                using (MemoryStream stream = new MemoryStream())
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(vgl._HttpWebRequestFunction._soapRecibido);
                    writer.Flush();
                    stream.Position = 0;
                    byte[] bfiledata = new byte[stream.Length];
                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                    stream.Close();
                    psoapRecibido.Value = bfiledata;
                    stream.Flush();

                }
                cmd.Parameters.Add(psoapRecibido);

                _intento = 0;
                while (true)
                {
                    _intento++;
                    try
                    {
                        _cronometro.Start();
                        con.Open();
                        con.ClientId = vgl._ClienteID;
                        //con.Failover += new OracleFailoverEventHandler(OnFailover);
                        int resultado = (int)cmd.ExecuteNonQuery();
                        con.Close();
                        _cronometro.Stop();
                        con.Close();
                        OracleConnection.ClearAllPools();
                        string _mensajeExitoso = "Ejecucion Exitosa.  \r\n Comando : " + select + "\r\n Tiempo de proceso : " + _cronometro.Elapsed;
                        _log.wr(vgl._Directorio, "Oraclesuccessful.txt", _mensajeExitoso);
                        break;
                    }
                    catch (OracleException ex)
                    {
                        _cronometro.Stop();
                        string _mensajeError = @"Cadena Conexion : " + vgl._Cadena + "\n Error Number: " + ex.Number + "\nSource: " +
                                    ex.Source + "\nData source: " + ex.DataSource + "\nProcedure: " +
                                        ex.Procedure + "\nMessage: " + ex.Message + "\nInnerException: " + ex.InnerException +
                        "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                        _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                        Console.WriteLine(_mensajeError);
                        _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                        if (_intento > 100)
                        {
                            break;
                        }
                        else
                        {
                            _intento++;
                            Thread.Sleep(10000);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        _cronometro.Stop();
                        string _mensajeError = @"InvalidOperationException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                        "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                        _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                        Console.WriteLine(_mensajeError);
                        _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                        if (_intento > 100)
                        {
                            break;
                        }
                        else
                        {
                            _intento++;
                            Thread.Sleep(10000);
                        }
                    }
                    catch (Exception ex)
                    {
                        _cronometro.Stop();
                        string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                        "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                        _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                        Console.WriteLine(_mensajeError);
                        _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                        if (_intento > 100)
                        {
                            break;
                        }
                        else
                        {
                            _intento++;
                            Thread.Sleep(10000);
                        }
                    }
                }
            }
        }
        public void executeUpdateInfoDian(string select, Vgp vgl)
        {
            using (OracleConnection con = new OracleConnection(vgl._Cadena))
            {
                OracleCommand cmd = new OracleCommand(select, con);
                cmd.CommandType = CommandType.Text;

                OracleParameter pIdCarvajal = new OracleParameter(":INDI_IDCARVAJAL", OracleDbType.Varchar2, 40);
                pIdCarvajal.Value = vgl._HttpWebRequestFunction._transactionId;
                cmd.Parameters.Add(pIdCarvajal);

                OracleParameter pNumDoc = new OracleParameter(":INDI_NUMDOC", OracleDbType.Varchar2, 40);
                pNumDoc.Value = vgl._LogReporteDian.LODI_LLAVE_V2;
                cmd.Parameters.Add(pNumDoc);

                _intento = 0;

                while (true)
                {
                    _intento++;
                    try
                    {
                        _cronometro.Start();
                        con.Open();
                        con.ClientId = vgl._ClienteID;
                        //con.Failover += new OracleFailoverEventHandler(OnFailover);
                        int resultado = (int)cmd.ExecuteNonQuery();//cmd.ExecuteNonQuery();
                        con.Close();
                        _cronometro.Stop();
                        con.Close();
                        OracleConnection.ClearAllPools();
                        string _mensajeExitoso = "Ejecucion Exitosa.  \r\n Comando : " + select + "\r\n Tiempo de proceso : " + _cronometro.Elapsed;
                        _log.wr(vgl._Directorio, "Oraclesuccessful.txt", _mensajeExitoso);
                        break;
                    }
                    catch (OracleException ex)
                    {
                        _cronometro.Stop();
                        string _mensajeError = @"Cadena Conexion : " + vgl._Cadena + "\n Error Number: " + ex.Number + "\nSource: " +
                                    ex.Source + "\nData source: " + ex.DataSource + "\nProcedure: " +
                                        ex.Procedure + "\nMessage: " + ex.Message + "\nInnerException: " + ex.InnerException +
                        "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                        _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                        Console.WriteLine(_mensajeError);
                        _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                        if (_intento > 100)
                        {
                            break;
                        }
                        else
                        {
                            _intento++;
                            Thread.Sleep(10000);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        _cronometro.Stop();
                        string _mensajeError = @"InvalidOperationException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                        "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                        _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                        Console.WriteLine(_mensajeError);
                        _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                        if (_intento > 100)
                        {
                            break;
                        }
                        else
                        {
                            _intento++;
                            Thread.Sleep(10000);
                        }
                    }
                    catch (Exception ex)
                    {
                        _cronometro.Stop();
                        string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                        "Comando : " + select + "   \r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Intento : " + _intento + " De 100 ";
                        _log.wr(_vgp._Directorio, "OracleException.txt", _mensajeError);
                        Console.WriteLine(_mensajeError);
                        _correo.envioCorreoBaseDatos(ex.Message, _mensajeError, vgl);
                        if (_intento > 100)
                        {
                            break;
                        }
                        else
                        {
                            _intento++;
                            Thread.Sleep(10000);
                        }
                    }
                }
            }
        }
        private OracleParameter parametroInt(string pnombre, object valor)
        {

            bool continua = true;
            OracleParameter op = new OracleParameter();

            op.ParameterName = pnombre;
            op.Direction = ParameterDirection.Input;
            while (continua)
            {
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
                if (valor.GetType() == Type.GetType("System.String"))
                {
                    if (pnombre == ":xmlfactura" || pnombre == ":soapenviado" || pnombre == ":soaprespuesta" || pnombre == ":XMLENV")//":xmlfactura", ":soapenviado", ":soaprespuesta"
                    {
                        //FileStream fs;

                        // Get Image Data from the Filesystem if User has loaded a Photo
                        // by the 'Browse' button
                        string tmpvalo = (string)valor;
                        MemoryStream stream = new MemoryStream();
                        StreamWriter writer = new StreamWriter(stream);
                        writer.Write(tmpvalo);
                        writer.Flush();
                        stream.Position = 0;
                        //fs = new FileStream(tmpvalo, FileMode.Open, FileAccess.Read);

                        // Create a byte array of file stream length
                        //byte[] _imageData = new byte[fs.Length];
                        byte[] _imageData = new byte[stream.Length];

                        // Read block of bytes from stream into the byte array
                        stream.Read(_imageData, 0, System.Convert.ToInt32(stream.Length));
                        //fs.Read(_imageData, 0, System.Convert.ToInt32(fs.Length));

                        // Close the File Stream
                        //fs.Close();
                        stream.Close();
                        op.Value = _imageData;
                        op.OracleDbType = OracleDbType.Blob;
                        continua = false;
                        break;
                    }
                    else
                    {
                        op.Value = (string)valor;
                        op.OracleDbType = OracleDbType.Varchar2;
                        continua = false;
                        break;
                    }
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
                    byte[] myBytes = (byte[])valor;
                    op.Value = myBytes;
                    op.OracleDbType = OracleDbType.Clob;
                    continua = false;
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
                    _log.wr(_vgp._Directorio, "noseReconoceParametro.txt", "No fue posbile determinar la naturaleza del parametro. " + "Nombre del Parametro :" + pnombre);//(_vgs._archivo, "No fue posbile determinar la naturaleza del parametro. " + "Nombre del Parametro :" + pnombre);
                    continua = false;
                    break;
                }
            }
            return op;
        }
        //private FailoverReturnCode OnFailover(object sender, OracleFailoverEventArgs eventArgs)
        //{
        //    //throw new NotImplementedException();
        //    switch (eventArgs.FailoverEvent)
        //    {
        //        case FailoverEvent.Begin:
        //            {
        //                _failOver += DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n";
        //                _failOver += @"FailoverEvent.Begin - Failover is starting\r\n";
        //                _failOver += @"FailoverType = " + eventArgs.FailoverType;
        //                _failOver += @"* * * * * * * * * * * * * * * * * * * * * * * ";
        //                _log.wr(_vgp._Directorio, "FailoverEvent.txt", _failOver);
        //                _correo.envioCorreoBaseDatos("FailoverEvent.Begin", _failOver, _vgp);//(ex.Message, _mensajeError, vgl);
        //                break;
        //            }
        //        case FailoverEvent.Abort:
        //            {
        //                _failOver += DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n";
        //                _failOver += @"FailoverEvent.Abort - Failover was unsuccessful\r\n";
        //                _failOver += @"FailoverType = " + eventArgs.FailoverType;
        //                _failOver += @"* * * * * * * * * * * * * * * * * * * * * * * ";
        //                _log.wr(_vgp._Directorio, "FailoverEvent.txt", _failOver);
        //                _correo.envioCorreoBaseDatos("FailoverEvent.Abort", _failOver, _vgp);//(ex.Message, _mensajeError, vgl);
        //                break;
        //            }
        //        case FailoverEvent.End:
        //            {
        //                _failOver += DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n";
        //                _failOver += @"FailoverEvent.End - Failover was successful\r\n";
        //                _failOver += @"FailoverType = " + eventArgs.FailoverType;
        //                _failOver += @"* * * * * * * * * * * * * * * * * * * * * * * ";
        //                _log.wr(_vgp._Directorio, "FailoverEvent.txt", _failOver);
        //                _correo.envioCorreoBaseDatos("FailoverEvent.End", _failOver, _vgp);//(ex.Message, _mensajeError, vgl);
        //                break;
        //            }
        //        case FailoverEvent.Reauth:
        //            {
        //                _failOver += DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n";
        //                _failOver += @"FailoverEvent.Reauth - User reauthenticated\r\n";
        //                _failOver += @"FailoverType = " + eventArgs.FailoverType;
        //                _failOver += @"* * * * * * * * * * * * * * * * * * * * * * * ";
        //                _log.wr(_vgp._Directorio, "FailoverEvent.txt", _failOver);
        //                _correo.envioCorreoBaseDatos("FailoverEvent.Reauth", _failOver, _vgp);//(ex.Message, _mensajeError, vgl);
        //                break;
        //            }
        //        case FailoverEvent.Error:
        //            {
        //                _failOver += DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n";
        //                _failOver += @"FailoverEvent.Error - Failover was unsuccessful\r\n";
        //                _failOver += @"FailoverType = " + eventArgs.FailoverType;
        //                _failOver += @"* * * * * * * * * * * * * * * * * * * * * * * ";
        //                _log.wr(_vgp._Directorio, "FailoverEvent.txt", _failOver);
        //                _correo.envioCorreoBaseDatos("FailoverEvent.Error", _failOver, _vgp);//(ex.Message, _mensajeError, vgl);
        //                return FailoverReturnCode.Retry;
        //            }
        //        default:
        //            {
        //                _failOver += DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n";
        //                _failOver += @"Invalid FailoverEvent : " + eventArgs.FailoverEvent;
        //                _failOver += @"FailoverType = " + eventArgs.FailoverType;
        //                _failOver += @"* * * * * * * * * * * * * * * * * * * * * * * ";
        //                _log.wr(_vgp._Directorio, "FailoverEvent.txt", _failOver);
        //                _correo.envioCorreoBaseDatos("default", _failOver, _vgp);//(ex.Message, _mensajeError, vgl);
        //                break;
        //            }
        //    }
        //    return FailoverReturnCode.Success;
        //}

        internal DataTable daDataTable(Func<string> func, string[] _nParametros, object[] _vParametros, Vgp _vgp)
        {
            throw new NotImplementedException();
        }
    }
}
