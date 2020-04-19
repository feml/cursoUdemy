using System;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace infrastructure
{
    public partial class CorreoElectronico
    {
        private bool EnviarCorreo(ConfiguracionEmail cfEmail)
        {
            bool CorreoExitoso = true;
            #region Envio de correo
            MailMessage msg = new MailMessage();
            //msg.To.Add("fmontoya@transer.com.co");
            msg.To.Add(cfEmail.Para);
            if (cfEmail.Copia.Length>0)
             msg.CC.Add(cfEmail.Copia);
            if (cfEmail.CopiaOculta.Length>0)
             msg.Bcc.Add(cfEmail.CopiaOculta);
            msg.From = new MailAddress(cfEmail.cuentaCorreo, cfEmail.Titulo, System.Text.Encoding.UTF8);
            try
            {
                msg.Subject = cfEmail.Asunto;
            }
            catch (Exception ex)
            {
                msg.Subject = ex.Message;
            }
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cfEmail.Mensaje;
            msg.BodyEncoding = System.Text.Encoding.Unicode;
            msg.IsBodyHtml = false;
            SmtpClient client = new SmtpClient();
            Security security = new Security();
            client.Credentials = new System.Net.NetworkCredential(security.Base64Decode(cfEmail.user), security.Base64Decode(cfEmail.password));
            client.Port = cfEmail.port;
            client.Host = cfEmail.host;
            client.EnableSsl = cfEmail.enableSsl;
            try
            {
                client.Send(msg);
            }
            catch (SmtpException ex)
            {
                CorreoExitoso = false;
                MensajeError = "Excepcion de tipo SmtpException\r\n" + ex.Message;
            }
            catch (Exception ex)
            {
                CorreoExitoso = false;
                MensajeError = "Excepcion de tipo Exception\r\n" + ex.Message;
            }
            #endregion // fin del Envio de correo

            return CorreoExitoso;
        }
        private bool EnviarCorreo(ConfiguracionEmail cfEmail, params MailAttachment[] attachments)
        {
            bool CorreoExitoso = true;
            #region Envio de correo
            MailMessage msg = new MailMessage();
            msg.To.Add(cfEmail.Para);
            if (cfEmail.Copia.Length > 0)
                msg.CC.Add(cfEmail.Copia);
            if (cfEmail.CopiaOculta.Length > 0)
                msg.Bcc.Add(cfEmail.CopiaOculta);
            msg.From = new MailAddress(cfEmail.cuentaCorreo, cfEmail.Titulo, System.Text.Encoding.UTF8);
            try
            {
                msg.Subject = cfEmail.Asunto;
            }
            catch (Exception ex)
            {
                msg.Subject = ex.Message;
            }
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cfEmail.Mensaje;
            msg.BodyEncoding = System.Text.Encoding.Unicode;
            msg.IsBodyHtml = false;
            SmtpClient client = new SmtpClient();
            Security security = new Security();
            client.Credentials = new System.Net.NetworkCredential(security.Base64Decode(cfEmail.user), security.Base64Decode(cfEmail.password));
            client.Port = cfEmail.port;
            client.Host = cfEmail.host;
            client.EnableSsl = cfEmail.enableSsl;

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
                sb.Append("\nbody:" + cfEmail.Mensaje);
                sb.Append("\nsubject:" + cfEmail.Asunto);
                sb.Append("\nfromAddress:robotcorreo@transer.com.co");
                sb.Append("\nfromDisplay:Robot Correo");
                sb.Append("\ncredentialUser:" + cfEmail.user);
                sb.Append("\ncredentialPasswordto:" + cfEmail.password);
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
                client.Send(msg);
            }
            catch (SmtpException ex)
            {
                CorreoExitoso = false;
                MensajeError = "Excepcion de tipo SmtpException\r\n" + ex.Message;
            }
            catch (Exception ex)
            {
                CorreoExitoso = false;
                MensajeError = "Excepcion de tipo Exception\r\n" + ex.Message;
            }
            #endregion // fin del Envio de correo

            return CorreoExitoso;
        }
    }
}
