using MailKit.Net.Smtp;
using MimeKit;
using System.Net.Sockets;

namespace protoCorreo
{
    public class easilyMail
    {
        public string Exceptions { get; set; }
        public void sned()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("robotcorreo", "Tys860504882"));
            message.To.Add(new MailboxAddress("Dotnet Training Academy", "robotcorreo@transer.com.co"));
            message.Subject = "I lerant to send a mail";
            message.Body = new TextPart("plain")
            {
                Text = "I am using MailKit nuget package to send email easily"
            };

            using (var client = new SmtpClient())
            {


                try
                {
                    //client.Connect("smtp.gamil.com", 465, false);
                    client.Connect("192.168.30.8", 25, false);
                    //await client.ConnectAsync("192.168.30.8", 25, false).ConfigureAwait(false);
                    //await client.ConnectAsync("smtp.gmail.com", 465, false).ConfigureAwait(false);
                    //await client.ConnectAsync("smtp.gmail.com", 587, false).ConfigureAwait(false);
                }
                catch (SocketException ex)
                {
                    Exceptions = ex.Message;
                }
                catch (MailKit.Security.SaslException ex)
                {
                    Exceptions = ex.Message;
                }
                catch (MailKit.Security.SslHandshakeException ex)
                {
                    Exceptions = ex.Message;
                }
                catch (MailKit.Security.AuthenticationException ex)
                {
                    Exceptions = ex.Message;
                }

                try
                {
                    //client.Authenticate("francisco.montoya.l@gmail.com", "@Jsd2@xr1");
                    client.Authenticate("robotcorreo", "Tys860504882");
                    //await client.AuthenticateAsync("robotcorreo", "Tys860504882").ConfigureAwait(false);
                    //await client.AuthenticateAsync("francisco.montoya.l@gmail.com", "@Jsd2@xr1").ConfigureAwait(false);
                    //await client.AuthenticateAsync("francisco.montoya.l@gmail.com", "@Jsd2@xr1").ConfigureAwait(false);

                }
                catch (SocketException ex)
                {
                    Exceptions = ex.Message;
                }
                catch (MailKit.Security.SaslException ex)
                {
                    Exceptions = ex.Message;
                }
                catch (MailKit.Security.SslHandshakeException ex)
                {
                    Exceptions = ex.Message;
                }
                catch (MailKit.Security.AuthenticationException ex)
                {
                    Exceptions = ex.Message;
                }
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
