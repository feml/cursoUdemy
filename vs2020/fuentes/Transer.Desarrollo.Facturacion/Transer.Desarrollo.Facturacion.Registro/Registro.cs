using System;
using System.IO;
using System.Net.Mail;
namespace Transer.Desarrollo.Facturacion.Registro
{
    public class Registro
    {
        public string _ruta { get; set; }
        public Registro()
        {
        }

        public void wr(string directorio, string archivo, string mensaje)
        {
            validarDirectorio(directorio);
            _ruta = directorio + "\\" + archivo;
            using (StreamWriter writer = new StreamWriter(_ruta, true))
            {
                try
                {
                    writer.WriteLine(" ");
                    writer.WriteLine(" * * * * * * * * * * * * * INICIO * * * * * * * * * * * * *");
                    writer.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
                    writer.WriteLine(mensaje);
                    writer.WriteLine(" * * * * * * * * * * * * * FIN * * * * * * * * * * * * *");
                    writer.WriteLine(" ");
                }
                catch (Exception exception)
                {
                    validarDirectorio(@"c:\transer\ws\logs\");
                    wr(@"c:\transer\ws\logs\", "exception.txt", DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\n\r" + exception.Message);
                }
            }

        }

        public void msg(string mensaje)
        {
            Console.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n" + mensaje);
        }
        public void msgclear(string mensaje)
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n" + mensaje);
        }

        public void cfg(string directorio, string archivo, string mensaje)
        {
            validarDirectorio(directorio);
            _ruta = directorio + "\\" + archivo;

            using (StreamWriter writer = new StreamWriter(_ruta, false))
            {
                try
                {
                    //writer.WriteLine(" ");
                    //writer.WriteLine(" * * * * * * * * * * * * * INICIO * * * * * * * * * * * * *");
                    //writer.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
                    writer.WriteLine(mensaje);
                    //writer.WriteLine(" * * * * * * * * * * * * * FIN * * * * * * * * * * * * *");
                    //writer.WriteLine(" ");

                }
                catch (Exception exception)
                {
                    validarDirectorio(@"c:\transer\ws\logs\");
                    wr(@"c:\transer\ws\logs\", "exception.txt", DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\n\r" + exception.Message);
                }
            }
        }

        public void wrXml(string directorio, string archivo, string mensaje)
        {
            validarDirectorio(directorio);
            _ruta = directorio + "\\" + archivo;

            using (StreamWriter writer = new StreamWriter(_ruta, true))
            {
                try
                {
                    writer.WriteLine(" ");
                    //writer.WriteLine(" * * * * * * * * * * * * * INICIO * * * * * * * * * * * * *");
                    writer.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
                    writer.WriteLine(mensaje);
                    //writer.WriteLine(" * * * * * * * * * * * * * FIN * * * * * * * * * * * * *");
                    writer.WriteLine(" ");

                }
                catch (Exception exception)
                {
                    validarDirectorio(@"c:\transer\ws\logs\");
                    wr(@"c:\transer\ws\logs\", "exception.txt", DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\n\r" + exception.Message);
                }
            }
        }















        public void mensajeError(string directorio, string archivo, SmtpException mensaje)
        {
            validarDirectorio(directorio);
            _ruta = directorio + "\\" + archivo;

            using (StreamWriter writer = new StreamWriter(_ruta, true))
            {
                try
                {
                    writer.WriteLine(" ");
                    writer.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                    writer.WriteLine(mensaje.InnerException);
                    writer.WriteLine(mensaje);
                    writer.WriteLine("*");
                }
                catch (Exception exception)
                {
                    validarDirectorio(@"c:\transer\ws\logs\");
                    wr(@"c:\transer\ws\logs\", "exception.txt", DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\n\r" + exception.Message);
                }
            }
        }
        public void mensajeError(string directorio, string archivo, Exception mensaje)
        {
            validarDirectorio(directorio);
            _ruta = directorio + "\\" + archivo;

            using (StreamWriter writer = new StreamWriter(_ruta, true))
            {
                try
                {
                    writer.WriteLine(" ");
                    writer.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                    writer.WriteLine(mensaje.Message);
                    writer.WriteLine("*");
                }
                catch (Exception exception)
                {
                    validarDirectorio(@"c:\transer\ws\logs\");
                    wr(@"c:\transer\ws\logs\", "exception.txt", DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\n\r" + exception.Message);
                }
            }
        }

















        public void validarDirectorio(string ruta)
        {
            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);
        }

        public void validarDirectorioFacturacion(string factura)
        {
            string ruta = @"c:\transer\ws\facturacion\" + factura;
            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);
            string anexos = ruta + "\\anexos";
            if (!Directory.Exists(anexos))
                Directory.CreateDirectory(anexos);
        }

    }
}
