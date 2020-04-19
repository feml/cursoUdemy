using System;
using System.IO;
using System.Net;
using Transer.Desarrollo.Facturacion.Correo;
using Transer.Desarrollo.Facturacion.Registro;
using Transer.Desarrollo.Facturacion.VariablesGlobalesProyecto;

namespace Transer.Desarrollo.Facturacion.HttpWebFeml
{
    public class HttpSendXmlDocument
    {
        public Vgp _vgp { get; set; }
        public Registro.Registro _log { get; set; }

        public HttpSendXmlDocument(Vgp vgp)
        {
            _vgp = vgp;
            _log = new Registro.Registro();
        }

        public string httpsSendXmlDocument(string HttpXmlSender)
        {
            string xml = HttpXmlSender;
            string url = "https://wscenflab.cen.biz/isows/InvoiceService?wsdl";//PILOTO
            //string url = "https://wscenf.cen.biz/isows/InvoiceService?wsdl";//PRODUCCION
            //string url = "https://cenfinancierolab.cen.biz/isows/InvoiceService?wsdl";//PRUEBAS
            //string url = "https://cenfinanciero.cen.biz/isows/InvoiceService?wsdl";//PRODUCCION
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(xml);
            req.Method = "POST";
            req.ContentType = "text/xml;charset=utf-8";
            req.ContentLength = requestBytes.Length;
            try
            {
                Stream requestStream = req.GetRequestStream();
                requestStream.Write(requestBytes, 0, requestBytes.Length);
                requestStream.Close();
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default);
                string backstr = sr.ReadToEnd();
                sr.Close();
                res.Close();

                _vgp._HttpWebRequestFunction._RequestXmlf = getXMLReturn(backstr);
            }
            catch (HttpListenerException ex)
            {
                _vgp._HttpWebRequestFunction._RequestXmlf = ex.Message;
                string _mensajeError = @"HttpListenerException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio()" + "\r\n SOAP : \r\n" + HttpXmlSender;
                _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                Correo.Correo _correo = new Correo.Correo(_vgp);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
            catch (Exception ex)
            {
                _vgp._HttpWebRequestFunction._RequestXmlf = ex.Message;
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio()" + "\r\nSOAP : \r\n" + HttpXmlSender;
                _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                Correo.Correo _correo = new Correo.Correo(_vgp);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }

            return _vgp._HttpWebRequestFunction._RequestXmlf;
        }
        private string getXMLReturn(string txbRequestXmlf)
        {
            string output = txbRequestXmlf;
            if (txbRequestXmlf == "Error en el servidor remoto: (500) Error interno del servidor.")
            {
                _log.wr(_vgp._Directorio, "Exception.txt", txbRequestXmlf);
                Correo.Correo _correo = new Correo.Correo(_vgp);
                _correo.envioCorreoDesarrollador("Error en el servidor remoto: (500) Error interno del servidor.", txbRequestXmlf, _vgp);
            }
            if (txbRequestXmlf == "No es posible conectar con el servidor remoto")
            {
                _log.wr(_vgp._Directorio, "Exception.txt", txbRequestXmlf);
                Correo.Correo _correo = new Correo.Correo(_vgp);
                _correo.envioCorreoDesarrollador("No es posible conectar con el servidor remoto", txbRequestXmlf, _vgp);
            }
            else
            {
                if (txbRequestXmlf.Contains("<soap:") && txbRequestXmlf.Contains(":Envelope>"))
                {
                    output = txbRequestXmlf;
                    try
                    {
                        txbRequestXmlf = output.Substring(output.IndexOf("<soap:"));
                        int index = txbRequestXmlf.LastIndexOf(":Envelope>");
                        if (index > 0)
                            txbRequestXmlf = txbRequestXmlf.Substring(0, index + 10);
                        _log.wr(_vgp._Directorio, "soapRespuesta.txt", txbRequestXmlf);
                    }
                    catch (Exception ex)
                    {
                        string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                              "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio()" + "\r\nSOAP : \r\n" + txbRequestXmlf;
                        _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                        Correo.Correo _correo = new Correo.Correo(_vgp);
                        _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
                    }
                }
                else
                {
                    if (txbRequestXmlf.Contains("<soapenv:") && txbRequestXmlf.Contains(":Envelope>"))
                    {
                        output = txbRequestXmlf;
                        try
                        {
                            txbRequestXmlf = output.Substring(output.IndexOf("<soapenv:"));
                            int index = txbRequestXmlf.LastIndexOf(":Envelope>");
                            if (index > 0)
                                txbRequestXmlf = txbRequestXmlf.Substring(0, index + 10);
                            _log.wr(_vgp._Directorio, "soapRespuesta.txt", txbRequestXmlf);
                        }
                        catch (Exception ex)
                        {
                            string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                                  "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio()" + "\r\nSOAP : \r\n" + txbRequestXmlf;
                            _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                            Correo.Correo _correo = new Correo.Correo(_vgp);
                            _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
                        }
                    }
                }
            }
            return txbRequestXmlf;
        }
    }
}
