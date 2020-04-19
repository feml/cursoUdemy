using LogicaNegocio.Ministerio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cacharreo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 80; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write("*");
                }
                //Console.ReadKey();
            }*/
            //Console.ReadKey();
            #region Definicion del bloque de seguridad
            string usuario = string.Empty;
            string password = string.Empty;
            string usuEmail = string.Empty;
            string passEmail = string.Empty;
            string ambiente = string.Empty;
            SecurityPrvt security = new SecurityPrvt();
            try
            {
                usuario = security.Decode(args[0].ToString());
            }
            catch (System.Exception)
            {
                usuario = security.Decode("usuario");
            }
            try
            {
                password = security.Decode(args[1].ToString());
            }
            catch (System.Exception)
            {
                password = security.Decode("password");
            }
            try
            {
                usuEmail = security.Decode(args[2].ToString());
            }
            catch (System.Exception)
            {
                usuEmail = security.Decode("usuEmail");
            }
            try
            {
                passEmail = security.Decode(args[3].ToString());
            }
            catch (System.Exception)
            {
                passEmail = security.Decode("passEmail");
            }
            try
            {
                ambiente = security.Decode(args[4].ToString());
            }
            catch (System.Exception)
            {
                ambiente = security.Decode("desarrollo");
            }
            #endregion fin de la Definicion del bloque de seguridad

            using (LogicaNegocio.Ministerio.LogicaNegocio lg = new LogicaNegocio.Ministerio.LogicaNegocio(usuario, password, usuEmail, passEmail, ambiente))
            {
                lg.prueba();
            }
        }
        public class SecurityPrvt
        {
            public SecurityPrvt()
            {

            }
            public string Decode(string texto)
            {
                string codigo = string.Empty;
                switch (texto)
                {
                    case "usuario":
                        {
                            codigo = Base64Decode("SOPORTE");
                            break;
                        }
                    case "password":
                        {
                            codigo = Base64Decode("SOPORTE");
                            break;
                        }
                    case "usuEmail":
                        {
                            codigo = Base64Decode("robotcorreo");
                            break;
                        }
                    case "passEmail":
                        {
                            codigo = Base64Decode("Tys860504882");
                            break;
                        }
                    default:
                        {
                            codigo = Base64Decode(texto);
                            break;
                        }
                }
                return codigo;
            }
            private string Base64Decode(string base64EncodedData)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(base64EncodedData);
                //string encodedText = Convert.ToBase64String(plainTextBytes);
                return Convert.ToBase64String(plainTextBytes);
                //return System.Text.Encoding.UTF8.GetString(plainTextBytes);
            }
        }
    }
}
