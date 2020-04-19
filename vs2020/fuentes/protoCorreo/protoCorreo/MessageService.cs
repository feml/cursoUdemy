using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace protoCorreo
{
    public class MessageService : IMessageService
    {
        public string Exceptions { get; set; }
        public async Task SendEmailAsync(string fromDisplayName, 
            string fromEmailAddress, 
            string toName, 
            string toEmailAddress, 
            string subject, 
            string message, 
            params Attachment[] attachments)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(fromDisplayName, fromEmailAddress));
            email.To.Add(new MailboxAddress(toName, toEmailAddress));
            email.Subject = subject;

            var body = new BodyBuilder
            {
                HtmlBody = message
            };

            foreach (var attachment in attachments)
            {
                using (var stream = await attachment.ContentToStreamAsync())
                {
                    body.Attachments.Add(attachment.FileName, stream);
                }
            }

            using(var client = new SmtpClient())
			{
                client.ServerCertificateValidationCallback =
                (sender, certificate, certChainType, errors) => true;
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                try
                {
                    //await client.ConnectAsync("192.168.30.8", 25, false).ConfigureAwait(false);
                    //await client.ConnectAsync("smtp.gmail.com", 465, false).ConfigureAwait(false);
                    //await client.ConnectAsync("smtp.gmail.com", 465, false).ConfigureAwait(true);
                    client.Connect("smtp.gmail.com", 465, false);//.ConfigureAwait(false);
                    //await client.ConnectAsync("smtp.gmail.com", 587, false).ConfigureAwait(false);
                }
                catch(SmtpProtocolException ex)
                {
                    Exceptions += "* ";
                    Exceptions += ex.Message + "\r\n";
                    Console.Clear();
                    Console.WriteLine(Exceptions);
                    Console.Write("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                }
                catch (SocketException ex)
                {
                    Exceptions += "* ";
                    Exceptions += ex.Message +"\r\n";
                    Console.Clear();
                    Console.WriteLine(Exceptions);
                    Console.Write("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                }
                catch (MailKit.Security.SaslException ex)
                {
                    Exceptions += "* ";
                    Exceptions += ex.Message + "\r\n";
                    Console.Clear();
                    Console.WriteLine(Exceptions);
                    Console.Write("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                }
                catch (MailKit.Security.SslHandshakeException ex)
                {
                    Exceptions += "* ";
                    Exceptions += ex.Message + "\r\n";
                    Console.Clear();
                    Console.WriteLine(Exceptions);
                    Console.Write("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                }
                catch (MailKit.Security.AuthenticationException ex)
                {
                    Exceptions += "* ";
                    Exceptions += ex.Message + "\r\n";
                    Console.Clear();
                    Console.WriteLine(Exceptions);
                    Console.Write("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                }


                try
                {
                    //await client.AuthenticateAsync("robotcorreo", "Tys860504882").ConfigureAwait(false);
                    //await client.AuthenticateAsync("francisco.montoya.l@gmail.com", "@Jsd2@xr1").ConfigureAwait(false);
                    await client.AuthenticateAsync("francisco.montoya.l@gmail.com", "@Jsd2@xr1").ConfigureAwait(false);
                }
                catch (MailKit.Security.SaslException ex)
                {
                    Exceptions += "* ";
                    Exceptions += ex.Message + "\r\n";
                    Console.Clear();
                    Console.WriteLine(Exceptions);
                    Console.Write("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                }
                catch (MailKit.Security.SslHandshakeException ex)
                {
                    Exceptions += "* ";
                    Exceptions += ex.Message + "\r\n";
                    Console.Clear();
                    Console.WriteLine(Exceptions);
                    Console.Write("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                }
                catch (MailKit.Security.AuthenticationException ex)
                {
                    Exceptions += "* ";
                    Exceptions += ex.Message + "\r\n";
                    Console.Clear();
                    Console.WriteLine(Exceptions);
                    Console.Write("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                }

                try
                {
                    await client.SendAsync(email).ConfigureAwait(false);
                }
                catch (MailKit.Security.SaslException ex)
                {
                    Exceptions += "* ";
                    Exceptions += ex.Message + "\r\n";
                    Console.Clear();
                    Console.WriteLine(Exceptions);
                    Console.Write("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                }
                catch (MailKit.Security.SslHandshakeException ex)
                {
                    Exceptions += "* ";
                    Exceptions += ex.Message + "\r\n";
                    Console.Clear();
                    Console.WriteLine(Exceptions);
                    Console.Write("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                }
                catch (MailKit.Security.AuthenticationException ex)
                {
                    Exceptions += "* ";
                    Exceptions += ex.Message + "\r\n";
                    Console.Clear();
                    Console.WriteLine(Exceptions);
                    Console.Write("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                }

                try
                {
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }
                catch (MailKit.Security.SaslException ex)
                {
                    Exceptions += "* ";
                    Exceptions += ex.Message + "\r\n";
                    Console.Clear();
                    Console.WriteLine(Exceptions);
                    Console.Write("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                }
                catch (MailKit.Security.SslHandshakeException ex)
                {
                    Exceptions += "* ";
                    Exceptions += ex.Message + "\r\n";
                    Console.Clear();
                    Console.WriteLine(Exceptions);
                    Console.Write("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                }
                catch (MailKit.Security.AuthenticationException ex)
                {
                    Exceptions += "* ";
                    Exceptions += ex.Message + "\r\n";
                    Console.Clear();
                    Console.WriteLine(Exceptions);
                    Console.Write("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                }
            }
        }
    }
}
