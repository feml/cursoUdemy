using executionreports;
using infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfProductoTerminado
{
    public partial class Form1 : Form
    {
        public DataTable dtConsultaReporte { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Ambiente { get; set; }
        public Consola consola { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize();
            dgv.DataSource = consulta();
        }

        private void Initialize()
        {
            dtConsultaReporte = new DataTable();
            dtConsultaReporte.Columns.Add("CODOFI", typeof(string));
            dtConsultaReporte.Columns.Add("OFICINA", typeof(string));
            dtConsultaReporte.Columns.Add("CLIENTE", typeof(string));
            dtConsultaReporte.Columns.Add("ESTADO", typeof(string));
            dtConsultaReporte.Columns.Add("SEC", typeof(string));
            dtConsultaReporte.Columns.Add("LOGSEC", typeof(string));
            dtConsultaReporte.Columns.Add("ORDEN", typeof(string));
            dtConsultaReporte.Columns.Add("DESTADO", typeof(string));
            dtConsultaReporte.Columns.Add("ENVIADO", typeof(string));
            dtConsultaReporte.Columns.Add("FECHA", typeof(string));
            dtConsultaReporte.Columns.Add("RECIBIDO", typeof(string));



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
            Usuario = usuario;
            Password = password;
            Ambiente = ambiente;
        }

        private DataTable consulta()
        {
            DataTable dtConsulta = new DataTable();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[0] { };
            _vParametros = new object[0] { };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                dtConsulta = data.getTable("getOrdenesRechazadas", _nParametros, _vParametros);
                if (dtConsulta.Rows.Count>0)
                {
                    foreach (DataRow dritem in dtConsulta.Rows)
                    {
                        procesarRegistro(dritem);
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }

            return dtConsultaReporte;
        }

        private void procesarRegistro(DataRow dritem)
        {
            string CODOFI = dritem["CODOFI"].ToString();
            string OFICINA = dritem["OFICINA"].ToString();
            string CLIENTE = dritem["CLIENTE"].ToString();
            string ESTADO = dritem["ESTADO"].ToString();
            string SEC = dritem["SEC"].ToString();
            string LOGSEC = dritem["LOGSEC"].ToString();
            string ORDEN = dritem["ORDEN"].ToString();
            string DESTADO = dritem["DETESTADO"].ToString();
            string ENVIADO = dritem["ENVIADO"].ToString();
            string FECHA = dritem["FECHA"].ToString();
            string RECIBIDO = dritem["RECIBIDO"].ToString();

            if (RECIBIDO.Contains("REM381"))
            {
                dtConsultaReporte.Rows.Add(CODOFI,OFICINA,CLIENTE,ESTADO,SEC,LOGSEC,ORDEN,DESTADO,ENVIADO,FECHA,RECIBIDO);
            }            
        }

        private void ManejoError(Exception ex, string texto)
        {
            using (StreamWriter writer = new StreamWriter("Robots.txt", true))
            {
                writer.WriteLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                writer.WriteLine("Se Produjo un error de tipo Exception:");
                writer.WriteLine(ex.Message);
            }            
        }
        private class SecurityPrvt
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
