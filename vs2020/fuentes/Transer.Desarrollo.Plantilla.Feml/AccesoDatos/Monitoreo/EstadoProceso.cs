using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace AccesoDatos.Monitoreo
{
    public class EstadoProceso
    {
        public string _Excepcion { get; set; }
        public bool _Continua { get; set; }
        public DateTime _Fecha { get; set; }
        public string _Mensaje { get; set; }
        public DataTable _dataTable { get; set; }
        public TimeSpan _timeSpan { get; set; }

        public void Registro(string Mensaje)
        {
            //https://www.dotnetperls.com/stringbuilder
            // Declare a new StringBuilder.
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.Append("       = = = =  = = =   = = = = = ");
            builder.Append("       INFORME  AVANCE  APLICATIVO ");
            builder.Append("       = = = =  = = =   = = = = = ");
            builder.AppendLine();
            builder.Append("Fecha : ").Append(DateTime.Now.ToLongDateString()).Append(" ").Append(DateTime.Now.ToLongTimeString()).AppendLine();
            builder.AppendLine();
            builder.Append(Mensaje);
            builder.AppendLine();
            builder.Append("                ***  ***  ****** ");
            builder.Append("                FIN  DEL  AVANCE");
            builder.Append("                ***  ***  ****** ");

            Console.WriteLine(builder.ToString());

            writleMensaje(builder.ToString());
        }

        private void writleMensaje(string mensaje)
        {
            string ruta = @"C:\transer\ws\logs\";
            //string target = GetTarget("log_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".txt");
            string target = GetTarget("log_" + DateTime.Now.ToShortDateString()  + ".txt");

            using (StreamWriter writer = new StreamWriter(validarDirectorio(ruta, target), true))
            {
                writer.WriteLine(mensaje);
            }
        }

        private string GetTarget(string v)
        {
            string target = v.Replace("/", "");
            return target;
        }

        private string validarDirectorio(string ruta, string target)
        {
            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);
            string rutaFichero = ruta+@"\"+target;
            return rutaFichero;
        }
    }
}
