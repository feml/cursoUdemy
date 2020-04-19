using System;
using System.Text;

namespace fml.Ministerio
{
    public partial class WsRndc
    {
        public string enviar(string xml)
        {
            string xml_respuesta = "";
            StringBuilder Mensaje = new StringBuilder();
            try
            {
                Mensaje.Append("         Estableciendo Comunicacion con el Web Services del Ministerio    \r\n");
                Mensaje.Append("         ============= ============ === == === ======== === ==========    \r\n");
                Mensaje.Append(xml);
                srRndc.BPMServicesClient envio_xml = new srRndc.BPMServicesClient();
                xml_respuesta = envio_xml.AtenderMensajeRNDC(xml);
            }
            catch (InvalidOperationException ex)
            {
                string _mensajeError = @"El Web service del ministerio de transporte, " + "Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caMinisterio_enviar_dato" + "\r\nXML : \r\n" + xml;
                //_log.wr(_vgp._directorio, "Exception.txt", _mensajeError);
                //Correo _correo = new Correo(_vgp);
                Mensaje.Append("         SE PRESENTO UN ERROR EN LA CONEXION CON EL WEB SERVICES DEL MINISTERIO    \r\n");
                Mensaje.Append("         == ======== == ===== == == ======== === == === ======== === ==========    \r\n");
                Mensaje.Append("\r\n");
                Mensaje.Append("\r\nDetalle del error.\r\n");
                Mensaje.Append(_mensajeError);
                xml_respuesta = ex.Message;
            }
            catch (Exception ex)
            {
                //Console.Clear();
                string _mensajeError = @"El Web service del ministerio de transporte, " + "Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caMinisterio_enviar_dato" + "\r\nXML : \r\n" + xml;
                //_log.wr(_vgp._directorio, "Exception.txt", _mensajeError);
                //Correo _correo = new Correo(_vgp);
                Mensaje.Append("         SE PRESENTO UN ERROR EN LA CONEXION CON EL WEB SERVICES DEL MINISTERIO    \r\n");
                Mensaje.Append("         == ======== == ===== == == ======== === == === ======== === ==========    \r\n");
                Mensaje.Append("\r\n");
                Mensaje.Append("\r\nDetalle del error.\r\n");
                Mensaje.Append(_mensajeError);
                xml_respuesta = ex.Message;
            }
            return xml_respuesta;
        }
    }
}
