/**************************************************************************
@author  Francisco Emilio Montoya Lopez
@version 1.0
Development Environment        :  MS Visual Studio 2012 .NET C#
Name of the File               :  class ccorreo:transer.cclases.ccorreo
Creation/Modification History  :  25-julio-2013     Created
                               :  31-julio-2013 Modificado
                               :  09-septiembre-2013 Modificado 
                               :  21-octubre-2013 Modificado 
                               :  00-mes-año Modificado 
Overview:
 * 
**************************************************************************/
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace caOspAdminsatV1
{
    class ccorreo
    {
        private string _password_correo;
        private string _user_correo;
        public ccorreo()
        {
            _password_correo = "Tys860504882";
            _user_correo = "robotcorreo";
        }
        public void envioCorreo(string asunto, string cuerpo)
        {
            #region Envio de correo
            MailMessage msg = new MailMessage();
            //msg.To.Add("soporte@transer.com.co");
            msg.To.Add("trafico@transer.com.co");
            msg.CC.Add("soporte@transer.com.co");
            //msg.Bcc.Add("francisco.e.montoya.l@gmail.com");
            //msg.CC.Add("fmontoya@transer.com.co");
            msg.From = new MailAddress("robotcorreo@transer.com.co", "Robot Correo", System.Text.Encoding.UTF8);
            msg.Subject = asunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cuerpo;
            msg.BodyEncoding = System.Text.Encoding.Unicode;
            msg.IsBodyHtml = false;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_user_correo, _password_correo);
            client.Port = 25;
            client.Host = "192.168.30.8";
            client.EnableSsl = false;
            try
            {
                //if (!asunto.Contains(":{\"detail\":\"Método"))//El valor no puede ser nulo
                //{
                //    client.Send(msg);                    
                //}
                //else
                //{
                //    if (!asunto.Contains("Error al momento de procesar el envio JSON"))//
                //    {
                //        client.Send(msg);
                //    }
                //}
                if (cuerpo.Contains("La ruta con origen:"))
                {
                    client.Send(msg);
                }
            }
            catch (SmtpException smtp_exception)
            {
                mensajeError(smtp_exception);
            }
            catch (Exception exception)
            {
                mensajeError(exception);
            }

            #endregion // fin del Envio de correo

        }
        public void envioCorreoDesarrolador(string asunto, string cuerpo)
        {
            #region Envio de correo
            MailMessage msg = new MailMessage();
            //msg.To.Add("soporte@transer.com.co");
            msg.To.Add("fmontoya@transer.com.co");
            //msg.Bcc.Add("francisco.e.montoya.l@gmail.com");
            //msg.CC.Add("lcubillos@transer.com.co");
            msg.From = new MailAddress("robotcorreo@transer.com.co", "Robot Correo", System.Text.Encoding.UTF8);
            msg.Subject = asunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cuerpo;
            msg.BodyEncoding = System.Text.Encoding.Unicode;
            msg.IsBodyHtml = false;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_user_correo, _password_correo);
            client.Port = 25;
            client.Host = "192.168.30.8";
            client.EnableSsl = false;
            try
            {
                //client.Send(msg);
            }
            catch (SmtpException smtp_exception)
            {
                mensajeError(smtp_exception);
            }
            catch (Exception exception)
            {
                mensajeError(exception);
            }

            #endregion // fin del Envio de correo

        }
        private static void mensajeError(SmtpException mensaje)
        {
            using (StreamWriter writer =
                        new StreamWriter(@"c:\transer\ws\adminsat\errorCorreo.txt", true))
            {
                writer.WriteLine(" ");
                writer.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                writer.WriteLine(mensaje);
                writer.WriteLine("*");
            }
        }
        private static void mensajeError(Exception ex)
        {
            using (StreamWriter writer =
                        new StreamWriter(@"c:\transer\ws\adminsat\logError.txt", true))
            {
                writer.WriteLine(" ");
                writer.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                writer.WriteLine(ex.Message);
                writer.WriteLine("*");
            }
        }

    }
}
