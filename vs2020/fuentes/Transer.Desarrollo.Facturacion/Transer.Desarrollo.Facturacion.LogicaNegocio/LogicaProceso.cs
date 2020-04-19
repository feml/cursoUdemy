using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Transer.Desarrollo.Facturacion.BuildCommand;
using Transer.Desarrollo.Facturacion.Correo;
using Transer.Desarrollo.Facturacion.OracleManagedData;
using Transer.Desarrollo.Facturacion.Registro;
using Transer.Desarrollo.Facturacion.VariablesGlobalesProyecto;
using Transer.Desarrollo.Facturacion.EncodingFE;
using System.Threading.Tasks;
using Transer.Desarrollo.Facturacion.ProcesarAnexos;
using Transer.Desarrollo.Facturacion.HttpWebFeml;
using Transer.Desarrollo.Facturacion.HttpWebXml;
using Transer.Desarrollo.Facturacion.PdbInfoDian;

namespace Transer.Desarrollo.Facturacion.LogicaNegocio
{
    public class LogicaProceso
    {
        public string _newconsecutivo { get; set; }
        private Vgp _vgp { get; set; }
        private Registro.Registro _log { get; set; }
        private OracleData _datos { get; set; }
        private BuildCommands _select { get; set; }
        private Stopwatch _cronometro { get; set; }
        private Correo.Correo _correo { get; set; }
        public DateTime fecini { get; set; }
        public LogicaProceso(DateTime fecini)
        {
            this.fecini = fecini;
        }
        public void Inicio(string nfactura)
        {
            _vgp = new Vgp();
            _log = new Registro.Registro();
            _datos = new OracleData(_vgp);
            _select = new BuildCommands();
            _cronometro = new Stopwatch();
            _correo = new Correo.Correo(_vgp);
            _vgp._ClienteID = "FacElcV2_logicaProceso_inicio";
            DataTable dtlogReporteDian = new DataTable();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":LODI_ESTADO" };
            _vParametros = new object[1] { "P" };
            dtlogReporteDian = _datos.daDataTable(_select.logReporteDian(), _nParametros, _vParametros, _vgp);
            if (dtlogReporteDian.Rows.Count > 0)
            {
                try
                {
                    _vgp._LogReporteDian.totalFacturasPendientes = dtlogReporteDian.Rows.Count;
                    _log.msg("Facturas pendientes por procesar : " + _vgp._LogReporteDian.totalFacturasPendientes);
                    foreach (DataRow drFacturas in dtlogReporteDian.Rows)
                    {
                        _cronometro.Start();
                        inicializarVariablesLogReporteDian();
                        #region informacion log_reporte_dian
                        try
                        {
                            _vgp._LogReporteDian.LODI_SECUENCIA_NB = long.Parse(drFacturas[0].ToString());
                        }
                        catch (Exception ex)
                        {
                            _cronometro.Stop();
                            string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                                  "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                                  "instruccion : _vgp._LogReporteDian.LODI_SECUENCIA_NB = long.Parse(drFacturas[0].ToString());" + "\r\nTiempo de proceso : " + _cronometro.Elapsed;
                            _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                            _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
                        }
                        try
                        {
                            _vgp._LogReporteDian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());
                        }
                        catch (Exception ex)
                        {
                            _cronometro.Stop();
                            string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                                  "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                                  "instruccion : _vgp._LogReporteDian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());" + "\r\nTiempo de proceso : " + _cronometro.Elapsed;
                            _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                            _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
                        }
                        try
                        {
                            _vgp._LogReporteDian.LODI_TRANSACCION_NB = int.Parse(drFacturas[2].ToString());
                        }
                        catch (Exception ex)
                        {
                            _cronometro.Stop();
                            string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                                  "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                                  "instruccion : _vgp._LogReporteDian.LODI_TRANSACCION_NB = int.Parse(drFacturas[2].ToString());" + "\r\nTiempo de proceso : " + _cronometro.Elapsed;
                            _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                            _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
                        }
                        _vgp._LogReporteDian.LODI_LLAVE_V2 = drFacturas[3].ToString();
                        //consecutivo++;
                        //_newconsecutivo = "PRUE98000" + consecutivo.ToString();
                        _newconsecutivo = nfactura;//"SETT3";

                        try
                        {
                            _vgp._LogReporteDian.LODI_FECREGISTRO_DT = DateTime.Parse(drFacturas[4].ToString());
                        }
                        catch (Exception ex)
                        {
                            _cronometro.Stop();
                            string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                                  "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                                  "instruccion : _vgp._LogReporteDian.LODI_FECREGISTRO_DT = DateTime.Parse(drFacturas[4].ToString());" + "\r\nTiempo de proceso : " + _cronometro.Elapsed;
                            _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                            _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
                        }
                        _vgp._LogReporteDian.LODI_ESTADO_V2 = drFacturas[5].ToString();
                        try
                        {
                            _vgp._LogReporteDian.LODI_CAMPO1_NB = int.Parse(drFacturas[6].ToString());
                        }
                        catch (Exception ex)
                        {
                            _cronometro.Stop();
                            string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                                  "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                                  "instruccion : _vgp._LogReporteDian.LODI_CAMPO1_NB = int.Parse(drFacturas[6].ToString());" + "\r\nTiempo de proceso : " + _cronometro.Elapsed;
                            //_log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                            //_correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
                        }
                        _vgp._LogReporteDian.LODI_CAMPO2_V2 = drFacturas[7].ToString();
                        try
                        {
                            _vgp._LogReporteDian.LODI_CAMPO3_DT = DateTime.Parse(drFacturas[8].ToString());
                        }
                        catch (Exception ex)
                        {
                            _cronometro.Stop();
                            string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                                  "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                                  "instruccion : _vgp._LogReporteDian.LODI_CAMPO1_NB = int.Parse(drFacturas[6].ToString());" + "\r\nTiempo de proceso : " + _cronometro.Elapsed;
                            //_log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                            //_correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
                        }
                        _vgp._LogReporteDian.LODI_ESTADODIAN_V2 = drFacturas[9].ToString();
                        #endregion fin informacion log_reporte_dian

                        _log.msg("Secuencia : " + _vgp._LogReporteDian.LODI_SECUENCIA_NB + "  Oficina : " + _vgp._LogReporteDian.LODI_OFICINA_NB + "  Llave : " + _vgp._LogReporteDian.LODI_LLAVE_V2 + "  Fecha : " + _vgp._LogReporteDian.LODI_FECREGISTRO_DT);
                        if (_vgp._LogReporteDian.LODI_LLAVE_V2 == "EVVC653")
                            procesarFacturaAsync();
                        //procesarFacturaAsync();
                        _vgp._FacturasProcesadas += 1;
                        _cronometro.Stop();
                        _log.msg("Factura procesada : " + _vgp._LogReporteDian.LODI_LLAVE_V2 + "\r\nTiempo de proceso : " + _cronometro.Elapsed + "\r\n Facturas Procesadas : " + _vgp._FacturasProcesadas + "     Facturas Restantes : " + " " + (_vgp._LogReporteDian.totalFacturasPendientes - _vgp._FacturasProcesadas).ToString());
                        _cronometro.Reset();
                    }

                }
                catch (Exception ex)
                {
                    _cronometro.Stop();
                    string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                          "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() \r\nTiempo de proceso : " + _cronometro.Elapsed;
                    _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                    _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
                }
            }
            else
            {
                _log.wr(_vgp._TargetFile._Directorio, _vgp._TargetFile._Archivo, "No hay facturas para procesar.");
            }
        }

        private async void procesarFacturaAsync()
        {
            string respuesta = await Task.Run(() => procesarFactura(_vgp));
            //string respuesta = procesarFactura();
        }

        private string procesarFactura(Vgp vgl)
        {
            controlDirectorio cd = new controlDirectorio();
            cd.validarDirectorio(vgl._LogReporteDian.LODI_LLAVE_V2);
            if (pdbinfodian(vgl._LogReporteDian.LODI_LLAVE_V2, vgl._LogReporteDian.LODI_OFICINA_NB, vgl._LogReporteDian.LODI_TRANSACCION_NB))
            {
                //_vgs._tipoDocumento=
                Anexos anexos = new Anexos(vgl);
                if (anexos.getAnexos(vgl._LogReporteDian.LODI_LLAVE_V2))
                {
                    //vgl.upload.UPLO_FILENAME_V2 = vgl._LogReporteDian.LODI_LLAVE_V2 + ".zip";

                    //18092019vgl._HttpWebRequestFunction._FileName = vgl._LogReporteDian.LODI_LLAVE_V2 + ".zip";
                    vgl._HttpWebRequestFunction._FileName = _newconsecutivo + ".zip";

                    if (anexos.sizeAnexo < 2100000)
                    {
                        //vgl._HttpWebRequestFunction._FileName = _newconsecutivo + ".xml";
                        //18092019anexos.comprimirFacturaAdjuntos(vgl._LogReporteDian.LODI_LLAVE_V2, vgl._InformacionDian.INDI_XMLENV_CB);
                        anexos.comprimirFacturaAdjuntos(vgl._LogReporteDian.LODI_LLAVE_V2, vgl._InformacionDian.INDI_XMLENV_CB);
                        vgl._HttpWebRequestFunction._FileData = anexos.getdataXmlAnexos(_newconsecutivo);
                    }
                    else
                    {

                        ////18092019vgl._HttpWebRequestFunction._FileName = vgl._LogReporteDian.LODI_LLAVE_V2 + ".xml";
                        vgl._HttpWebRequestFunction._FileName = _newconsecutivo + ".xml";

                        _log.cfg(vgl._Directorio + "\\" + vgl._InformacionDian.INDI_NUMDOC_V2 + "\\anexos\\", vgl._InformacionDian.INDI_NUMDOC_V2 + ".xml", vgl._InformacionDian.INDI_XMLENV_CB);
                        EncodingFe encoding = new EncodingFe(vgl);
                        vgl._HttpWebRequestFunction._FileData = encoding.Base64Encode(vgl._InformacionDian.INDI_XMLENV_CB);
                        _log.cfg(vgl._Directorio + "\\" + vgl._InformacionDian.INDI_NUMDOC_V2 + "\\anexos\\", vgl._InformacionDian.INDI_NUMDOC_V2 + ".enc", vgl._HttpWebRequestFunction._FileData);
                    }
                }
                else
                {
                    //18092019vgl._HttpWebRequestFunction._FileName = vgl._LogReporteDian.LODI_LLAVE_V2 + ".xml";
                    vgl._HttpWebRequestFunction._FileName = _newconsecutivo + ".xml";
                    _log.cfg(vgl._Directorio + "\\" + vgl._InformacionDian.INDI_NUMDOC_V2 + "\\anexos\\", vgl._InformacionDian.INDI_NUMDOC_V2 + ".xml", vgl._InformacionDian.INDI_XMLENV_CB);
                    EncodingFe encoding = new EncodingFe(vgl);
                    vgl._HttpWebRequestFunction._FileData = encoding.Base64Encode(vgl._InformacionDian.INDI_XMLENV_CB);
                    _log.cfg(vgl._Directorio + "\\" + vgl._InformacionDian.INDI_NUMDOC_V2 + "\\anexos\\", vgl._InformacionDian.INDI_NUMDOC_V2 + ".enc", vgl._HttpWebRequestFunction._FileData);
                }

                vgl._HttpWebRequestFunction._companyId = "860504882";
                vgl._HttpWebRequestFunction._accountid = "860504882_01";
                vgl._HttpWebRequestFunction._Username = "fmontoya@transer.com.co";
                vgl._HttpWebRequestFunction._userId = "UsernameToken-1";
                EncodingFe conding = new EncodingFe(vgl);
                //PRUEBAS_vgs.upload._Password = conding.SHA256Encrypt("Tys860504882@1"); //"Tys860504882@1";
                //18092019vgl._HttpWebRequestFunction._Password = conding.SHA256Encrypt("F935Cjm9262@"); //"Tys860504882@1";
                vgl._HttpWebRequestFunction._Password = conding.SHA256Encrypt("TranserFac@1"); //"Tys860504882@1";
                vgl._HttpWebRequestFunction._FacturaXml = vgl._InformacionDian.INDI_XMLENV_CB;
                vgl._HttpWebRequestFunction._HttpWebRequestFunction = "UploadRequest";
                EncodingFe sha = new EncodingFe(vgl);
                vgl._HttpWebRequestFunction._create = sha.getCreate();
                //PACHO_vgs.upload._nonce = sha.getNonce(_vgs._LogReporteDian.LODI_LLAVE_V2);
                vgl._HttpWebRequestFunction._nonce = sha.getNonce(vgl._HttpWebRequestFunction._FileName);

                httpWebSend xmlsend = new httpWebSend(vgl);
                //string soap = xmlsend.getSoapEnvio(_vgs);
                vgl._HttpWebRequestFunction._soapEnviado = xmlsend.getSoapEnvio(vgl);
                HttpSendXmlDocument httpsSendXmlDocument = new HttpSendXmlDocument(vgl);


                //HttpWebResponseFunction httpWebResponseFunction = new HttpWebResponseFunction("Upload");
                vgl._HttpWebRequestFunction._RequestXmlf = httpsSendXmlDocument._vgp._HttpWebRequestFunction._RequestXmlf;

                vgl._HttpWebRequestFunction._httpWebResponseXml = httpsSendXmlDocument.httpsSendXmlDocument(vgl._HttpWebRequestFunction._soapEnviado);


                vgl._HttpWebRequestFunction._soapRecibido = vgl._HttpWebRequestFunction._httpWebResponseXml;

                //18092019vgl._StatusFactura = procesarXMLRecibido(vgl._HttpWebRequestFunction._soapRecibido);
            }
            else
            {
                _correo.envioCorreoDesarrollador("No existe XML asociado a la factura", "No fue posible generar el XML de la factura : " + _vgp._LogReporteDian.LODI_LLAVE_V2 + "\r\n La ejecucion del procedimiento : pdbInfoDian(vgl._LogReporteDian.LODI_LLAVE_V2, vgl._LogReporteDian.LODI_OFICINA_NB, vgl._LogReporteDian.LODI_TRANSACCION_NB) no logro generar el XML.", _vgp);
            }
            return vgl._StatusFactura;
        }

        private string procesarXMLRecibido(string soapRecibido)
        {
            string statusProceso = soapRecibido.Replace("< ", "<");
            soapRecibido = statusProceso.Replace(" >", ">");
            statusProceso = string.Empty;
            string nombreArchivo = @"c:\transer\ws\facturacion\" + _vgp._LogReporteDian.LODI_LLAVE_V2 + "\\" + _vgp._LogReporteDian.LODI_LLAVE_V2 + "_xml.xml";
            XmlDocument xmlDocumentResponse = new XmlDocument();
            try
            {
                xmlDocumentResponse.LoadXml(soapRecibido);
                xmlDocumentResponse.Save(nombreArchivo);
                HttpWebXmls httpWebXml = new HttpWebXmls(_vgp);
                statusProceso = httpWebXml.getHttpWebXml(_vgp._HttpWebRequestFunction._httpWebResponseXml, nombreArchivo, xmlDocumentResponse);

            }
            catch (Exception ex)
            {
                statusProceso = ex.Message;
            }
            return statusProceso;
        }

        private void inicializarVariablesLogReporteDian()
        {
            Stopwatch stopwatchLocal = new Stopwatch();
            stopwatchLocal.Start();
            try
            {
                //_vgp._LogReporteDian.totalFacturasPendientes = 0;
                _vgp._LogReporteDian.LODI_SECUENCIA_NB = 0;
                _vgp._LogReporteDian.LODI_OFICINA_NB = 0;
                _vgp._LogReporteDian.LODI_TRANSACCION_NB = 0;
                _vgp._LogReporteDian.LODI_LLAVE_V2 = string.Empty;
                _vgp._LogReporteDian.LODI_FECREGISTRO_DT = DateTime.Now;
                _vgp._LogReporteDian.LODI_ESTADODIAN_V2 = string.Empty;
                _vgp._LogReporteDian.LODI_ESTADO_V2 = string.Empty;
                _vgp._LogReporteDian.LODI_CAMPO1_NB = 0;
                _vgp._LogReporteDian.LODI_CAMPO2_V2 = string.Empty;
                _vgp._LogReporteDian.LODI_CAMPO3_DT = DateTime.Now;
            }
            catch (Exception ex)
            {
                stopwatchLocal.Stop();
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_private void inicializarVariablesLogReporteDian() \r\nTiempo de proceso : " + stopwatchLocal.Elapsed;
                _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
        }


        private bool pdbinfodian(string factura, int oficina, int transaccion)
        {
            Stopwatch cronolocal = new Stopwatch();
            PdbInfDian pdbInfoian = new PdbInfDian(_vgp);
            try
            {
                cronolocal.Start();
                pdbInfoian.generarInfoDian(factura, oficina, transaccion);
                cronolocal.Restart();
            }
            catch (Exception ex)
            {
                cronolocal.Stop();
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_private bool pdbInfoDian(string factura, int oficina, int transaccion) \r\nTiempo de proceso : " + cronolocal.Elapsed;
                _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
            _vgp._IcpdbInfoDian.tipodocumento = pdbInfoian._vgp._IcpdbInfoDian.tipodocumento;
            _vgp._IcpdbInfoDian.tipoDocumentoDescriptivo = pdbInfoian._vgp._IcpdbInfoDian.tipoDocumentoDescriptivo;
            bool xmlCorrecto = false;
            _vgp._ClienteID = "caFEtysVS02";
            _vgp._Directorio = @"c:\transer\ws\facturacion\";
            _vgp._Archivo = "log.txt";
            DataTable dtConsulta = new DataTable();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":INDI_NUMDOC" };
            _vParametros = new object[1] { factura };
            OracleData dts = new OracleData(_vgp);
            try
            {
                cronolocal.Start();
                dtConsulta = dts.daDataTable(_select.getInformacionDian(), _nParametros, _vParametros, _vgp);
                if (dtConsulta.Rows.Count > 0)
                {
                    string _mensajeExitoso = "Ejecucion Exitosa.  \r\n Comando : " + _select.getInformacionDian() + "\r\n Tiempo de proceso : " + cronolocal.Elapsed;
                    _log.wr(_vgp._Directorio, "Oraclesuccessful.txt", _mensajeExitoso);
                    foreach (DataRow dr in dtConsulta.Rows)
                    {
                        _vgp._InformacionDian.INDI_NUMDOC_V2 = dr[0].ToString();
                        _vgp._InformacionDian.INDI_OFICDOC_NB = int.Parse(dr[1].ToString());
                        _vgp._InformacionDian.INDI_TIPODOC_V2 = dr[2].ToString();
                        _vgp._InformacionDian.INDI_EMAIL_V2 = dr[3].ToString();
                        _vgp._InformacionDian.INDI_XMLENV_CB = dr[4].ToString();
                        if (_vgp._InformacionDian.INDI_XMLENV_CB.Length > 0)
                        {
                            xmlCorrecto = true;
                        }
                        else
                        {
                            xmlCorrecto = false;
                            _log.wr(_vgp._Directorio, "errorXMLinfoDian.txt", "El campo INDI_XMLENV_CB para la factura : " + factura + "  esta sin valores");
                            break;
                        }
                        _vgp._InformacionDian.INDI_CUFEDIAN_V2 = dr[5].ToString();
                        _vgp._InformacionDian.INDI_IDCARVAJAL_V2 = dr[6].ToString();
                        _vgp._InformacionDian.INDI_XMLREC_BL = dr[7].ToString();
                        _vgp._InformacionDian.INDI_XMLLEGAL_CB = dr[9].ToString();
                        _vgp._InformacionDian.INDI_IDCUFE_V2 = dr[10].ToString();
                    }
                }
                else
                {
                    string _mensajeExitoso = "Ejecucion Exitosa.  \r\n Comando : " + _select.getInformacionDian() + "\r\n Tiempo de proceso : " + cronolocal.Elapsed;
                    _log.wr(_vgp._Directorio, "Oraclesuccessful.txt", _mensajeExitoso);
                    _log.wr(_vgp._Directorio, "sinRegistroInfoDian.txt", "No hay registro para la factura : " + factura + "  en la tabla Informacion_Dian");
                }
            }
            catch (Exception ex)
            {
                cronolocal.Stop();
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_private bool pdbInfoDian(string factura, int oficina, int transaccion) \r\nTiempo de proceso : " + cronolocal.Elapsed;
                _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
            return xmlCorrecto;
        }

        private class controlDirectorio
        {
            public void validarDirectorio(string factura)
            {
                string ruta = @"c:\transer\ws\facturacion\" + factura;
                if (!Directory.Exists(ruta))
                    Directory.CreateDirectory(ruta);
                string anexos = ruta + "\\anexos";
                if (!Directory.Exists(anexos))
                    Directory.CreateDirectory(anexos);
            }

        }
    }
}
