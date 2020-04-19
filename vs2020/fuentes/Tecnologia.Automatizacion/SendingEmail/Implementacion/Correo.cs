using SecurityScheme;
using SendingEmail.Implementacion;
using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace SendingEmail
{
    public partial class Correo
    {
        public void CorreoBaseDatos(string asunto, string cuerpo)
        {
            #region Envio de correo
            MailMessage msg = getMailMessage(asunto,cuerpo);//= new MailMessage();
            msg.To.Add("lcubillos@transer.com.co");
            msg.CC.Add("soporte@transer.com.co");
            SmtpClient client = getSmtpClient();//new SmtpClient();
            try
            {
                client.Send(msg);
            }
            catch (SmtpException ex)
            {
                _log = ex.Message;
            }
            catch (Exception ex)
            {
                _log = ex.Message;
            }
            #endregion // fin del Envio de correo
        }
        public void CorreoDesarrollador(string asunto, string cuerpo)
        {
            #region Envio de correo
            MailMessage msg = getMailMessage(asunto, cuerpo);//= new MailMessage();
            msg.To.Add("fmontoya@transer.com.co");
            SmtpClient client = getSmtpClient();//new SmtpClient();
            try
            {
                client.Send(msg);
            }
            catch (SmtpException ex)
            {
                _log = ex.Message;
            }
            catch (Exception ex)
            {
                _log = ex.Message;
            }
            #endregion // fin del Envio de correo
        }
        public void CorreoDesarrollador(string asunto, string cuerpo, string correoCliente, params MailAttachment[] attachments)
        {
            #region Envio de correo
            MailMessage msg = getMailMessage(asunto, cuerpo);//= new MailMessage();
            msg.To.Add(correoCliente);
            msg.Bcc.Add("fmontoya@transer.com.co");
            SmtpClient client = getSmtpClient();//new SmtpClient();
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
                sb.Append("\ncredentialUser:" + security.SecurityEMail.Usuario);
                sb.Append("\ncredentialPasswordto:" + security.SecurityEMail.Password);
                sb.Append("\nHosting:"+ security.Host);
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
                client.Send(msg);
            }
            catch (SmtpException ex)
            {
                _log = ex.Message;
            }
            catch (Exception ex)
            {
                _log = ex.Message;
            }
            #endregion // fin del Envio de correo

        }
        private MailMessage getMailMessage(string asunto, string cuerpo)
        {
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
            msg.Body = cuerpo;
            msg.BodyEncoding = System.Text.Encoding.Unicode;
            msg.IsBodyHtml = false;
            return msg;
        }
        private SmtpClient getSmtpClient()
        {
            SmtpClient client = new SmtpClient();

            client.Credentials = new System.Net.NetworkCredential(security.SecurityEMail.Usuario, security.SecurityEMail.Password);   //(_authorizationKey.Credentials.user, _authorizationKey.Credentials.password);
            client.Port = security.Port;//_security.port;//vgp._AuthorizationKey._Port;
            client.Host = security.Host;//_security.Host;//vgp._AuthorizationKey._Host;
            client.EnableSsl = security.EnableSsl;//_security.EnableSsl;//vgp._AuthorizationKey._EnableSsl;
            return client;
        }

    }
}
