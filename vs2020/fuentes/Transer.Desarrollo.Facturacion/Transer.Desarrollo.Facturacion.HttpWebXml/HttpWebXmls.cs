using System;
using System.Data;
using System.IO;
using System.Xml;
using Transer.Desarrollo.Facturacion.BuildCommand;
using Transer.Desarrollo.Facturacion.Correo;
using Transer.Desarrollo.Facturacion.OracleManagedData;
using Transer.Desarrollo.Facturacion.Registro;
using Transer.Desarrollo.Facturacion.VariablesGlobalesProyecto;

namespace Transer.Desarrollo.Facturacion.HttpWebXml
{
    public class HttpWebXmls
    {
        public Vgp _vgp { get; set; }
        public Registro.Registro _log;
        public HttpWebXmls(Vgp vgl)
        {
            _vgp = vgl;
            _log = new Registro.Registro();
        }
        public string getHttpWebXml(string HttpWebResponseXml, string nombreArchivo, XmlDocument xmlDocumentResponse)
        {
            while (true)
            {
                using (XmlReader reader = XmlReader.Create(nombreArchivo))
                {
                    while (reader.Read())
                    {
                        // Only detect start elements.
                        if (reader.IsStartElement())
                        {
                            // Get element name and switch on it.
                            switch (reader.Name)
                            {
                                case "status":
                                    Console.Write("<status>");
                                    if (reader.Read())
                                    {
                                        Console.WriteLine("  Valor : " + reader.Value.Trim());
                                        _vgp._HttpWebRequestFunction._status = reader.Value.Trim();
                                    }
                                    break;
                                case "transactionId":
                                    Console.Write("<transactionId>");
                                    if (reader.Read())
                                    {
                                        Console.WriteLine("  Valor : " + reader.Value.Trim());
                                        _vgp._HttpWebRequestFunction._transactionId = reader.Value.Trim();
                                    }
                                    break;
                                default:
                                    Console.WriteLine(reader.Name);
                                    break;
                            }
                        }
                    }
                }
                break;
            }

            if (_vgp._HttpWebRequestFunction._status == "Archivo recibido con exito.")
            {
                if (_vgp._HttpWebRequestFunction._transactionId.Length > 12)
                {
                    actualizarlogReporteDian("E", HttpWebResponseXml);
                    _log.wr(_vgp._Directorio + "\\" + _vgp._LogReporteDian.LODI_LLAVE_V2 + "\\", _vgp._LogReporteDian.LODI_LLAVE_V2 + "_id.txt", _vgp._HttpWebRequestFunction._transactionId);
                }

            }

            /*if (HttpWebResponseXml.Contains("Error en el servidor remoto: (500) Error interno del servidor."))
            {
                actualizarlogReporteDian("Z", HttpWebResponseXml);
            }
            else
            {
                try
                {
                    XmlDocument soapReturn = CreateSoapEnvelopeCarvajal(HttpWebResponseXml);
                    XmlNodeList elemListstatus = soapReturn.GetElementsByTagName("status");
                    _vgp.httpwebrequestFunction._status = elemListstatus[0].InnerXml.ToString();
                    XmlNodeList elemListtransactionId = soapReturn.GetElementsByTagName("transactionId");
                    _vgp.httpwebrequestFunction._transactionId = elemListtransactionId[0].InnerXml.ToString();
                    if (_vgp.httpwebrequestFunction._status.Contains("Archivo recibido con exito"))
                    {
                        actualizarlogReporteDian("E", HttpWebResponseXml);
                        _log.wr(_vgp.directorio + "\\" + _vgp.logreportedian.LODI_LLAVE_V2 + "\\", _vgp.logreportedian.LODI_LLAVE_V2 + "_id.txt", _vgp.httpwebrequestFunction._transactionId);
                    }
                    else
                    {
                        _log.wr(_vgp.directorio + "\\" + _vgp.logreportedian.LODI_LLAVE_V2 + "\\", _vgp.logreportedian.LODI_LLAVE_V2 + "_error.txt", HttpWebResponseXml);
                    }
                }
                catch (Exception ex)
                {
                    string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                          "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio()" + "\r\nSOAP : \r\n" + HttpWebResponseXml;
                    _log.wr(_vgp.directorio, "Exception.txt", _mensajeError);
                    ccorreo _correo = new ccorreo(_vgp);
                    _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
                }
            }*/
            return _vgp._HttpWebRequestFunction._transactionId;
        }
        private XmlDocument CreateSoapEnvelopeCarvajal(string myXmlSoap)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            try
            {
                soapEnvelop.LoadXml(myXmlSoap);
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio()" + "\r\nSOAP : \r\n" + myXmlSoap;
                _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                Correo.Correo _correo = new Correo.Correo(_vgp);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
            return soapEnvelop;
        }

        public void actualizarlogReporteDian(string estado, string HttpWebResponseXml)
        {
            if (estado == "E")
            {
                OracleData _datos = new OracleData(_vgp);
                BuildCommands select = new BuildCommands();
                _datos.executeUploadRequest(select.UploadRequestFE(), _vgp);
                _datos.executeDetLogDian(select.insertDetLogDian(), _vgp);
                //_datos.execute(select.updateLogReporteDian(estado, _vgp.logreportedian.LODI_LLAVE_V2), _vgp);
                //_datos.executeUpdateInfoDian(select.updateInformacionDian(), _vgp);
            }
            else
            {
                Correo.Correo _correo = new Correo.Correo(_vgp);
                _correo.envioCorreoDesarrollador("La factura  : " + _vgp._LogReporteDian.LODI_LLAVE_V2 + " No fue aceptada por el CENF.", "Se presento alguna novedad durante el envio de la factura : " + _vgp._LogReporteDian.LODI_LLAVE_V2 + " Adjunto respuesta del CENF. \r\n" + HttpWebResponseXml, _vgp);
            }
        }

    }
}
