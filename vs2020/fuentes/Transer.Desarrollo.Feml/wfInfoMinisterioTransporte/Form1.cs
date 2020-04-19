using fml.Varios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfInfoMinisterioTransporte
{
    public partial class Form1 : Form
    {
        public DateTime dtFecIni { get; set; }
        public DateTime dtFecFin { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtFecIni = DateTime.Now;
            dtFecFin = DateTime.Now;
        }

        private void dtpFecIni_ValueChanged(object sender, EventArgs e)
        {
            dtFecIni = dtpFecIni.Value;
        }

        private void dtpFecFin_ValueChanged(object sender, EventArgs e)
        {
            dtFecFin = dtpFecFin.Value;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            main();
        }

        private void main()
        {
            string LogAplication = string.Empty;
            DateTime fecIni = DateTime.Now;
            #region Definicion del bloque de seguridad
            string usuario = string.Empty;
            string password = string.Empty;
            string usuEmail = string.Empty;
            string passEmail = string.Empty;
            string ambiente = string.Empty;
            SecurityPrvt security = new SecurityPrvt();
            try
            {
                usuario = security.Decode("fmontoya");
            }
            catch (System.Exception)
            {
                usuario = security.Decode("usuario");
            }
            try
            {
                password = security.Decode("f935cjm9262");
            }
            catch (System.Exception)
            {
                password = security.Decode("password");
            }
            try
            {
                usuEmail = security.Decode("robotcorreo");
            }
            catch (System.Exception)
            {
                usuEmail = security.Decode("usuEmail");
            }
            try
            {
                passEmail = security.Decode("Tys860504882");
            }
            catch (System.Exception)
            {
                passEmail = security.Decode("passEmail");
            }
            try
            {
                ambiente = security.Decode("produccion");
            }
            catch (System.Exception)
            {
                ambiente = security.Decode("desarrollo");
            }
            #endregion fin de la Definicion del bloque de seguridad

            DataTable dt = new DataTable();

            using (LogicaCaVarios lg = new LogicaCaVarios(usuario, password, usuEmail, passEmail, ambiente))
            {
                try
                {
                    dt = lg.InicioNn(dtFecIni, dtFecFin);
                }
                catch (Exception ex)
                {
                    LogAplication += ex.Message;
                    Console.WriteLine(LogAplication);
                }
            }
            if (dt.Rows.Count>0)
            {
                dgvConsulta.DataSource = dt;
            }
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
