using System;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MailKit.Security;
using System.Collections.Generic;
using System.IO;

namespace MailKit
{
    class Program
    {
        static void Main(string[] args)
        {
            ImessageService mail = new MessageService();
            string message = @"Implementando Envio de correo segun instruccion de la pagina https://www.youtube.com/watch?v=Y2X5wtuzuX4";
            mail.SendEmailAsync("Francisco Montoya", "francisco.montoya.l@gmail.com", "Francisco Montoya Lopez", "fmontoya@transer.com.co", "Probando MailKit", message);
            //Console.ReadKey();
        }
    }
}
