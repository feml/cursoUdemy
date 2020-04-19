using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Utils;
using Org.BouncyCastle.Crypto.Tls;
using System.Threading.Tasks;

namespace MailKit
{
    public class MessageService : ImessageService
    {

        //http://www.mimekit.net/docs/html/T_MimeKit_AttachmentCollection.htm
        //https://www.youtube.com/watch?v=Y2X5wtuzuX4
        //https://www.taithienbo.com/send-email-with-attachments-using-mailkit-for-net-core/
        //https://dotnetcoretutorials.com/2017/11/02/using-mailkit-send-receive-email-asp-net-core/
        public async Task SSendEmailAsync(string fromDisplayName,
    string fromEmailAddress,
    string toName,
    string toEmailAddress,
    string subject,
    string menssage)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(fromDisplayName, fromEmailAddress));
            email.To.Add(new MailboxAddress(toName, toEmailAddress));
            email.Subject = subject;

            var builder = new BodyBuilder();

            // Set the plain-text version of the message text
            builder.TextBody = menssage;

            // In order to reference selfie.jpg from the html text, we'll need to add it
            // to builder.LinkedResources and then use its Content-Id value in the img src.


            var image = builder.LinkedResources.Add(@"C:\transer\imagenes\firmaDigital.PNG");
            image.ContentId = MimeUtils.GenerateMessageId();

            // Set the html version of the message text
            builder.HtmlBody = 
                
                /*string.Format(@"<leftr><img src=""cid:{0}""></left>
<p>El contenido de este mensaje pertenece a TRANSER S.A. y puede ser información privilegiada y confidencial. Si Usted no es el destinatario real del mismo, por favor informe de ello a quien lo envía y destrúyalo en forma inmediata. Está prohibida su retención, grabación, utilización o divulgación con cualquier propósito. Este mensaje ha sido verificado con software antivirus, en consecuencia, TRANSER S.A. no se hace responsable por la presencia en el o en sus anexos de algún virus que pueda generar daños en los equipos o programas del destinatario.<br>
<p>The content of this message belong to TRANSER S.A. and may be privileged and confidential information. If you are not the real recipient, please inform to sender and delete it immediately. The withholding, saving, use or release for any purpose of this message is restricted. This message has been checked with antivirus software; Accordingly, TRANSER S.A. is not liable for the presence of any virus in its attachments that causes or may cause damage to the recipient's equipment or software.<br>
<p>www.transer.com.co<br>", image.ContentId);


            */
                        builder.HtmlBody = string.Format(@"<p>El contenido de este mensaje pertenece a TRANSER S.A. y puede ser información privilegiada y confidencial. <br>
                                                           <p>Si Usted no es el destinatario real del mismo, por favor informe de ello a quien lo envía y destrúyalo en <br>
                                                           <p>forma inmediata. Está prohibida su retención, grabación, utilización o divulgación con cualquier propósito.<br>
                                                           <p>Este mensaje ha sido verificado con software antivirus, en consecuencia, TRANSER S.A. no se hace responsable <br>
                                                           <p>por la presencia en el o en sus anexos de algún virus que pueda generar daños en los equipos o programas del <br>
            <p>destinatario.<br>
            <p>www.transer.com.co<br>
            <center><img src=""cid:{0}""></center>", image.ContentId);
            
            // We may also want to attach a calendar event for Monica's party...
            
            
            //builder.Attachments.Add(@"C:\transer\documentos\condorito.pdf");

            // Now we just need to set the message body and we're done
            email.Body = builder.ToMessageBody();


            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback =
                    (sender, certificate, certChainType, errors) => true;
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                await client.ConnectAsync("smtp.gmail.com", 465, true).ConfigureAwait(false);
                await client.AuthenticateAsync("francisco.montoya.l", "@Jsd2@xr1").ConfigureAwait(false);

                await client.SendAsync(email).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
        public async Task SendEmailAsync(string fromDisplayName,
            string fromEmailAddress,
            string toName,
            string toEmailAddress,
            string subject,
            string menssage)//,            params Attachment[] attachments)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(fromDisplayName, fromEmailAddress));
            email.To.Add(new MailboxAddress(toName, toEmailAddress));
            email.Subject = subject;

            var body = new BodyBuilder
            {
                HtmlBody = menssage
            };

            /*foreach (var attachment in attachments)
            {
                using (var stream = await attachment.ContentToStreamAsync())
                {
                    body.Attachments.Add(attachment.FileName, stream);
                }
            }*/

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback =
                    (sender, certificate, certChainType, errors) => true;
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                await client.ConnectAsync("192.168.30.8", 25, true).ConfigureAwait(false);
                await client.AuthenticateAsync("fmontoya", "@Jsd2@xr1").ConfigureAwait(false);

                await client.SendAsync(email).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}
