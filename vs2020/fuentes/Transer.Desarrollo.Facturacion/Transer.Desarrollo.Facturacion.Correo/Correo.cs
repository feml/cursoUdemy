using System;
using System.IO;
using System.Net.Mail;
using System.Text;
using Transer.Desarrollo.Facturacion.Registro;
using Transer.Desarrollo.Facturacion.VariablesGlobalesProyecto;

namespace Transer.Desarrollo.Facturacion.Correo
{
    public class Correo
    {
        private Registro.Registro _log;
        //private Vgp _vgp;
        public Correo(Vgp vgp)
        {
            _log = new Registro.Registro();
            //_vgp = Vgp;
        }
        public void envioCorreoBaseDatos(string asunto, string cuerpo, Vgp vgp)
        {
            #region Envio de correo
            MailMessage msg = new MailMessage();
            msg.To.Add("lcubillos@transer.com.co");
            msg.CC.Add("soporte@transer.com.co");
            //msg.Bcc.Add("francisco.e.montoya.l@gmail.com");
            msg.From = new MailAddress("fmontoya@transer.com.co", "Source: Oracle Data Provider for .NET", System.Text.Encoding.UTF8);
            try
            {
                msg.Subject = asunto;
            }
            catch (Exception ex)
            {
                msg.Subject = "Source: Oracle Data Provider for .NET";//PACHOasunto.Substring(0,40);
                cuerpo += "\r\n" + ex.Message;
            }
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = "Durante el reporte de la factura : " +   vgp._LogReporteDian.LODI_LLAVE_V2 + " se presento el siguiente error .\r\n" + cuerpo + "\r\nVersion del Programa : caFEtysVS02_28092018a";
            msg.BodyEncoding = System.Text.Encoding.Unicode;
            msg.IsBodyHtml = false;
            SmtpClient client = new SmtpClient();

            client.Credentials = new System.Net.NetworkCredential(vgp._AuthorizationKey._Credentialmail._User, vgp._AuthorizationKey._Credentialmail._Password);   //(_authorizationKey.Credentials.user, _authorizationKey.Credentials.password);
            client.Port = vgp._AuthorizationKey._Port;
            client.Host = vgp._AuthorizationKey._Host;
            client.EnableSsl = vgp._AuthorizationKey._EnableSsl;
            try
            {
                //client.Send(msg);
            }
            catch (SmtpException exception)
            {
                _log.mensajeError(vgp._Directorio, "Smtpexception.txt", exception);
            }
            catch (Exception exception)
            {
                _log.mensajeError(vgp._Directorio, "Exception.txt", exception);
            }
            #endregion // fin del Envio de correo
        }
        public void envioCorreoDesarrollador(string asunto, string cuerpo, Vgp vgp)
        {
            #region Envio de correo
            MailMessage msg = new MailMessage();
            msg.To.Add("fmontoya@transer.com.co");
            //msg.CC.Add("soporte@transer.com.co");
            //msg.Bcc.Add("francisco.e.montoya.l@gmail.com");
            msg.From = new MailAddress("fmontoya@transer.com.co", "Correo Desarrollador", System.Text.Encoding.UTF8);
            try
            {
                msg.Subject = asunto;
            }
            catch (Exception ex)
            {
                msg.Subject = "Correo Desarrollador";
                cuerpo += "\r\n" + ex.Message;
            }
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            //msg.Body = cuerpo;
            msg.Body = "Durante el reporte de la factura : " + vgp._LogReporteDian.LODI_LLAVE_V2 + " se presento el siguiente error .\r\n" + cuerpo + "\r\nVersion del Programa : caFEtysVS02_28092018a";
            msg.BodyEncoding = System.Text.Encoding.Unicode;
            msg.IsBodyHtml = false;
            SmtpClient client = new SmtpClient();

            client.Credentials = new System.Net.NetworkCredential(vgp._AuthorizationKey._Credentialmail._User, vgp._AuthorizationKey._Credentialmail._Password);   //(_authorizationKey.Credentials.user, _authorizationKey.Credentials.password);
            client.Port = vgp._AuthorizationKey._Port;
            client.Host = vgp._AuthorizationKey._Host;
            client.EnableSsl = vgp._AuthorizationKey._EnableSsl;
            try
            {
                //client.Send(msg);
            }
            catch (SmtpException exception)
            {
                _log.mensajeError(vgp._Directorio, "Smtpexception.txt", exception);
            }
            catch (Exception exception)
            {
                _log.mensajeError(vgp._Directorio, "Exception.txt", exception);
            }
            #endregion // fin del Envio de correo
        }
        public void envioCorreoDesarrolador(string asunto, string cuerpo, string correoCliente, Vgp vgp, params MailAttachment[] attachments)
        {
            #region Envio de correo
            MailMessage msg = new MailMessage();
            //msg.To.Add("soporte@transer.com.co");
            msg.To.Add(correoCliente);
            msg.Bcc.Add("fmontoya@transer.com.co");
            //msg.Bcc.Add("jvillamizar@transer.com.co");
            //msg.Bcc.Add("francisco.e.montoya.l@gmail.com");
            //msg.CC.Add("lcubillos@transer.com.co");
            msg.From = new MailAddress("robotcorreo@transer.com.co", "Robot Correo", System.Text.Encoding.UTF8);
            msg.Subject = asunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            //msg.Body = cuerpo;
            msg.Body = "Durante el reporte de la factura : " + vgp._LogReporteDian.LODI_LLAVE_V2 + " se presento el siguiente error .\r\n" + cuerpo + "\r\nVersion del Programa : caFEtysVS02_28092018a";
            msg.BodyEncoding = System.Text.Encoding.Unicode;
            msg.IsBodyHtml = false;
            msg.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();

            client.Credentials = new System.Net.NetworkCredential(vgp._AuthorizationKey._Credentialmail._User, vgp._AuthorizationKey._Credentialmail._Password);   //(_authorizationKey.Credentials.user, _authorizationKey.Credentials.password);
            client.Port = vgp._AuthorizationKey._Port;
            client.Host = vgp._AuthorizationKey._Host;
            client.EnableSsl = vgp._AuthorizationKey._EnableSsl;

            try
            {
                foreach (MailAttachment ma in attachments)
                {
                    msg.Attachments.Add(ma.File);
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder(1024);
                sb.Append("\nTo:fmontoya@transer.com.co");
                sb.Append("\nbody:" + cuerpo);
                sb.Append("\nsubject:" + asunto);
                sb.Append("\nfromAddress:robotcorreo@transer.com.co");
                sb.Append("\nfromDisplay:Robot Correo");
                sb.Append("\ncredentialUser:" + vgp._AuthorizationKey._Credentialmail._User);
                sb.Append("\ncredentialPasswordto:" + vgp._AuthorizationKey._Credentialmail._Password);
                sb.Append("\nHosting:192.168.30.8");
                using (StreamWriter writer =
                        new StreamWriter(@"C:\Transer\ws\facturacion\errorCorreo.txt", true))
                {
                    writer.WriteLine(" ");
                    writer.WriteLine(sb.ToString() + ex.ToString());
                    writer.WriteLine("*");
                    writer.WriteLine(" ");
                }
            }
            try
            {
                //client.Send(msg);
            }
            catch (SmtpException exception)
            {
                _log.mensajeError(vgp._Directorio, "Smtpexception.txt", exception);
            }
            catch (Exception exception)
            {
                _log.mensajeError(vgp._Directorio, "Exception.txt", exception);
            }
            #endregion // fin del Envio de correo

        }

    }
}
