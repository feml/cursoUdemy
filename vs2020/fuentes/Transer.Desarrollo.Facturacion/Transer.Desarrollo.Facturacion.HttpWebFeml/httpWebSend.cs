using System;
using System.Xml;
using Transer.Desarrollo.Facturacion.BuildCommand;
using Transer.Desarrollo.Facturacion.OracleManagedData;
using Transer.Desarrollo.Facturacion.VariablesGlobalesProyecto;

namespace Transer.Desarrollo.Facturacion.HttpWebFeml
{
    public class httpWebSend
    {
        public Vgp _vgp { get; set; }
        public Registro.Registro _log { get; set; }
        public OracleData _datos { get; set; }
        public BuildCommands selects { get; set; }
        public httpWebSend(Vgp vgl)
        {
            _vgp = vgl;
            _datos = new OracleData(_vgp);
            _log = new Registro.Registro();
            selects = new BuildCommands();
        }

        public string getSoapEnvio(Vgp vgl)
        {
            string myXmlSoap = selects.getInformacionDian(_vgp);
            _log.wrXml(vgl._Directorio + "\\" + vgl._LogReporteDian.LODI_LLAVE_V2, "\\soapEnviado.txt", myXmlSoap);

            XmlDocument soapEnvelopeXml = CreateSoapEnvelopeCarvajal(myXmlSoap);
            return soapEnvelopeXml.InnerXml;
        }
        private XmlDocument CreateSoapEnvelopeCarvajal(string myXmlSoap)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            try
            {
                soapEnvelop.LoadXml(myXmlSoap);
            }
            catch (XmlException ex)
            {
                string _mensajeError = @"XmlException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio()" + "\r\n XML : \r\n" + myXmlSoap;
                _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                Correo.Correo _correo = new Correo.Correo(_vgp);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio()";
                _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                Correo.Correo _correo = new Correo.Correo(_vgp);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
            return soapEnvelop;
        }

    }


}
