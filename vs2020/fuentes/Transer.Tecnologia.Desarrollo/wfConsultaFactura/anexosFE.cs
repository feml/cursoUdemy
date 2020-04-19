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

namespace wfConsultaFactura
{
    public partial class anexosFE : Form
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Ambiente { get; set; }
        public Consola consola { get; set; }
        private int _codofi { get; set; }
        public DataTable _tableAnexos { get; set; }

        public anexosFE()
        {
            InitializeComponent();
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

        private void txbFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txbFactura.Text.Length > 4)
                {
                    buscarFactura(txbFactura.Text);
                }
                else
                {
                    MessageBox.Show("El valor ingresado no parece ser un numero de factura valido.\r\n\r\nPor Favor Ingrese el numero de la Factura", "Ingrese un numero de factura Valido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void buscarFactura(string text)
        {
            _tableAnexos = new DataTable("anexos");
            _tableAnexos.Columns.Add("Nombre", typeof(string));
            _tableAnexos.Columns.Add("Extension", typeof(string));
            _tableAnexos.Columns.Add("Tamaño", typeof(string));
            _tableAnexos.Columns.Add("Ubicacion", typeof(string));

            DataTable dtInfoFactura = new DataTable();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":factura" };
            _vParametros = new object[1] { text };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                dtInfoFactura = data.getTable("getInfoFactura", _nParametros, _vParametros);
                if (dtInfoFactura.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtInfoFactura.Rows)
                    {
                        lblOficina.Text = dr[0].ToString();
                        lblCliente.Text = dr[1].ToString();
                        lblNit.Text = dr[2].ToString();
                        lblDireccion.Text = dr[3].ToString();
                        try
                        {
                           _codofi = int.Parse(dr[4].ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Se presento un error inesperado\r\n\r\n " + ex, "Codigo de Oficina Invalido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        lblFecha.Text = dr[5].ToString();
                        lblValor.Text = dr[6].ToString();
                        panel2.Visible = true;
                        btnCorreo.Visible = true;
                        btnGuardar.Visible = true;
                        facturaPDF(text);
                    }
                }

            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }

            //return dtTmp;
        }
        private void facturaPDF(string factura)
        {
            DataTable dtInfoFactura = new DataTable();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":factura"};
            _vParametros = new object[1] { factura };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                dtInfoFactura = data.getTable("getSelectInfoDian", _nParametros, _vParametros);
                if (dtInfoFactura.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtInfoFactura.Rows)
                    {
                        procesarFacturaPdf(dr, txbFactura.Text);
                    }
                }

            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }
        }
        private void procesarFacturaPdf(DataRow dr, string factura)
        {
            string nombre = factura;
            string extension = ".pdf";
            var mifile = dr[4];
            byte[] cadena_bytes = (byte[])mifile;
            Encoding.GetEncoding(1252).GetString(cadena_bytes);
            string x = Encoding.GetEncoding(1252).GetString(cadena_bytes);
            switch (extension)
            {
                case "PDF":
                    {
                        string output = string.Empty;
                        try
                        {
                            output = x.Substring(x.IndexOf("%PDF"));
                            int index = output.LastIndexOf("%%EOF");
                            if (index > 0)
                                output = output.Substring(0, index + 5);
                            byte[] bytes = Encoding.GetEncoding(1252).GetBytes(output);
                            System.IO.File.WriteAllBytes("c:\\tmp\\facturacion\\" + factura + "\\" + nombre, bytes);
                            string filename = "c:\\tmp\\facturacion\\" + factura + "\\" + nombre + ".pdf";
                            System.Diagnostics.Process.Start(filename);
                            FileInfo file = new FileInfo("c:\\tmp\\facturacion\\" + factura + "\\" + nombre + ".pdf");
                            string flength = (file.Length / 1024).ToString();
                            //pacho04122018lbxAnexos.Items.Add("c:\\tmp\\facturacion\\" + factura + "\\" + nombre);
                            //_tableAnexos.Rows.Add(nombre, extension, flength + " KB", "c:\\tmp\\facturacion\\" + factura + "\\" + nombre, x);
                            _tableAnexos.Rows.Add(nombre, extension, flength + " KB", "c:\\tmp\\facturacion\\" + factura + "\\" + nombre);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error Win32Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            byte[] bytes = Encoding.GetEncoding(1252).GetBytes(output);
                            System.IO.File.WriteAllBytes("c:\\tmp\\facturacion\\" + factura + "\\" + nombre, bytes);
                            //pacho04122018lbxAnexos.Items.Add("c:\\tmp\\facturacion\\" + factura + "\\" + nombre);
                        }
                        break;
                    }
                default:
                    {
                        string output = x.Substring(x.IndexOf("%PDF"));
                        int index = output.LastIndexOf("%%EOF");
                        if (index > 0)
                            output = output.Substring(0, index + 5);
                        byte[] bytes = Encoding.GetEncoding(1252).GetBytes(output);
                        try
                        {
                            System.IO.File.WriteAllBytes("c:\\tmp\\facturacion\\" + factura + "\\" + nombre + ".pdf", bytes);
                            string filename = "c:\\tmp\\facturacion\\" + factura + "\\" + nombre + ".pdf";
                            System.Diagnostics.Process.Start(filename);
                            FileInfo file = new FileInfo("c:\\tmp\\facturacion\\" + factura + "\\" + nombre + ".pdf");
                            string flength = (file.Length / 1024).ToString();
                            //pacho04122018lbxAnexos.Items.Add("c:\\tmp\\facturacion\\" + factura + "\\" + nombre);
                            //_tableAnexos.Rows.Add(nombre, extension, flength + " KB", "c:\\tmp\\facturacion\\" + factura + "\\" + nombre, x);
                            _tableAnexos.Rows.Add(nombre, extension, flength + " KB", "c:\\tmp\\facturacion\\" + factura + "\\" + nombre);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error Win32Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        break;
                    }
            }
        }//private static void procesarAdjuntos(DataRow dr, string factura)    

        private void ManejoError(Exception ex, string texto)
        {
            using (StreamWriter writer = new StreamWriter("Robots.txt", true))
            {
                writer.WriteLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                writer.WriteLine("Se Produjo un error de tipo Exception:");
                writer.WriteLine(ex.Message);
            }
            consola.ReadKey("Se presento un error ...!!!!\r\n\r\n\r\n" + texto + ex.Message, true);
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
