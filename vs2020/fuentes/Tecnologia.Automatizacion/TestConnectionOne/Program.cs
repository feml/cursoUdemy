using DataFactory;
using DataFactory.Interfaces;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace TestConnectionOne
{
    class Program
    {
        static void Main(string[] args)
        {
            IFactory factory = new Factory("produccion", "fmontoya", "f935cjm9262", "robotcorreo", "Tys860504882");
            string[] nParametros;
            object[] vParametros;
            nParametros = new string[1] { ":LRMI_ESTADO" };
            vParametros = new object[1] { "P" };
            //DataTable dt = factory.GetTable("Varios", "getOficinas", nParametros, vParametros);
            DataTable dt = factory.GetTable("Varios", "getOficinas");
            Stopwatch stopwatch = factory.GetTimeMeasure();

            string HostName = Dns.GetHostName();
            IPAddress[] ipaddress = Dns.GetHostAddresses(HostName);

            if (factory.GetSuccessfulexecution())
            {
                Console.Write("Tiempo de Ejecucion : ");
                Console.WriteLine(stopwatch.ElapsedMilliseconds.ToString() + " .mls");
                Console.WriteLine("Operacion Exitosa");
                Console.Write("Detalle de la Instruccion : ");
                Console.WriteLine(factory.GetComandoConsulta());
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                    }
                }
            }
            else
            {
                Console.Write("Tiempo de Ejecucion : ");
                Console.WriteLine(stopwatch.ElapsedMilliseconds.ToString() + " .mls");
                Console.WriteLine("Se presento un Error durante la Ejecucion del Programa");
                Console.Write("Detalle del error : ");
                StringBuilder sb = new StringBuilder();
                DataTable dtError = new DataTable();
                string mensaje = string.Empty;
                dtError = factory.GetExcepcionOracle();
                if (dtError.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtError.Rows)
                    {
                        sb.AppendLine();
                        sb.AppendLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                        sb.AppendLine("Se Produjo un error al ejecutar el comando de tipo OracleException:");
                        sb.AppendLine(" ");
                        sb.AppendLine(" # # # #  # # # #  # # # #  # # # #  # # # # ");
                        sb.AppendLine("Informacion Asociada al Error... ");
                        sb.AppendLine("Number : " + dr["Number"].ToString());
                        sb.AppendLine("Procedure : " + dr["Procedure"].ToString());
                        sb.AppendLine("DataSource : " + dr["DataSource"].ToString());
                        sb.AppendLine("Source : " + dr["Source"].ToString());
                        sb.AppendLine("ErrorCode : " + dr["ErrorCode"].ToString());
                        sb.AppendLine("Mensaje : " + dr["Mensaje"].ToString());
                        if (vParametros.Length > 0)
                        {
                            sb.AppendLine(" ");
                            sb.AppendLine(" # # # #  # # # #  # # # #  # # # #  # # # # ");
                            sb.AppendLine(" Informacion de los parametros");
                            for (int i = 0; i < vParametros.Length; i++)
                            {
                                sb.AppendLine("Nombre del Parametro : " + nParametros[i].ToString());
                                sb.AppendLine("Valor del Parametro : " + vParametros[i].ToString());
                            }
                        }
                        sb.AppendLine(" ");
                        sb.AppendLine(" # # # #  # # # #  # # # #  # # # #  # # # # ");
                        sb.AppendLine(" Informacion del Equipo ");
                        sb.AppendLine(" Nombre del Equipo : " + HostName);
                        sb.AppendLine(" Detalle de la tarjeta de Red ");
                        foreach (IPAddress ip4 in ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
                        {
                            sb.AppendLine("IPv4 of Machine is ");
                            sb.AppendLine(ip4.ToString());
                        }
                        foreach (IPAddress ip6 in ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6))
                        {
                            sb.AppendLine("IPv6 of Machine is ");
                            sb.AppendLine(ip6.ToString());
                        }
                        sb.AppendLine(" * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                        sb.AppendLine(" ");
                        mensaje = sb.ToString();
                    }

                }
                else
                {
                    dtError = factory.GetException();
                    foreach (DataRow dr in dtError.Rows)
                    {
                        sb.AppendLine("Informacion Asociada al Error... ");
                        sb.AppendLine("Message : " + dr["Message"].ToString());
                        sb.AppendLine("StackTrace : " + dr["StackTrace"].ToString());
                        sb.AppendLine("Source : " + dr["Source"].ToString());
                        sb.AppendLine("select : " + dr["select"].ToString());
                        if (vParametros.Length > 0)
                        {
                            sb.AppendLine(" ");
                            sb.AppendLine(" # # # #  # # # #  # # # #  # # # #  # # # # ");
                            sb.AppendLine(" Informacion de los parametros");
                            for (int i = 0; i < vParametros.Length; i++)
                            {
                                sb.AppendLine("Nombre del Parametro : " + nParametros[i].ToString());
                                sb.AppendLine("Valor del Parametro : " + vParametros[i].ToString());
                            }
                        }
                        sb.AppendLine(" ");
                        sb.AppendLine(" # # # #  # # # #  # # # #  # # # #  # # # # ");
                        sb.AppendLine(" Informacion del Equipo ");
                        sb.AppendLine(" Nombre del Equipo : " + HostName);
                        sb.AppendLine(" Detalle de la tarjeta de Red ");
                        foreach (IPAddress ip4 in ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
                        {
                            sb.AppendLine("IPv4 of Machine is ");
                            sb.AppendLine(ip4.ToString());
                        }
                        foreach (IPAddress ip6 in ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6))
                        {
                            sb.AppendLine("IPv6 of Machine is ");
                            sb.AppendLine(ip6.ToString());
                        }
                        sb.AppendLine(" * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                        sb.AppendLine(" ");
                    }
                    mensaje = sb.ToString();
                }
                Console.WriteLine(mensaje);
                Console.ReadKey();
            }
        }
    }
}
