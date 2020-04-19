using System;
using System.IO;
using System.Windows.Forms;

namespace control_flota.Formularios.Control_flota
{
    public partial class frm_Validacion : Form
    {
        private string _cadena;

        public string Cadena
        {
            get { return _cadena; }
            set { _cadena = value; }
        }

        private string _usuario;

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private string _password;

        private int _CodigoOficina;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public frm_Validacion()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            validarDatos();
        }

        private void validarDatos()
        {
            _usuario = txbUsuario.Text;
            _password = txbContrasena.Text;
            //_cadena = "User Id=" + _usuario + ";Password=" + _password + ";Data Source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.30.11)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=MILDESA)));";
            //_cadena = "User Id=" + _usuario + ";Password=" + _password + ";Data Source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.31.3)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=MILEOPE1)));";
            //_cadena = "User Id=" + _usuario + ";Password=" + _password + ";Data Source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.30.6)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=MILEBOG1)));";
            //_cadena = "User Id=" + _usuario + ";Password=" + _password + ";Data Source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=krowten)));";
            //_cadena = "User Id=TRANSER;Password=TRANSER;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=krowten)));";            
            _cadena = obtenerCadenaConexion(_usuario, _password);
            if (validarUsuario(_cadena))
            {
                frm_contenedor contenedor = new frm_contenedor();
                contenedor.Usuario = _usuario;
                contenedor.Password = _password;
                contenedor.Cadena = _cadena;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblMensajeError.Text = "USUARIO O CONTRASEÑA INVALIDA\r\n";
                txbContrasena.Text = "";
                txbUsuario.Text = "";
                txbUsuario.Focus();
            }
        }

        private string obtenerCadenaConexion(string usr, string pas)
        {
            string sLine = "";// variable utilizada para almacenar linea a linea el contenido del archivo conexion.ora
            string cadena = "";

            #region Leer el archivo plano
            try
            {
                StreamReader objReader = new StreamReader("c:\\orant\\net80\\admin\\conexion.ora");
                #region bloque Leer el archivo conexion.ora
                while (sLine != null)
                {
                    try
                    {
                        sLine = objReader.ReadLine();
                        cadena = cadena + sLine;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR AL LEER EL ARCHIVO c:\\orant\\net80\\admin\\conexion.ora " + ex.Message, "ERROR AL LEER EL ARCHIVO DE CONFIGURACION", MessageBoxButtons.OK);
                    }
                }
                objReader.Close();
                #endregion // fin del bloque Leer el archivo conexion.ora
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL LEER EL ARCHIVO c:\\orant\\net80\\admin\\conexion.ora " + ex.Message, "ERROR AL LEER EL ARCHIVO DE CONFIGURACION", MessageBoxButtons.OK);
            }
            #endregion fin de la lectura del archivo plano

            #region definicion de la cadena de conexion a utilizar
            switch (cadena)
            {
                case ".30":
                    cadena = "User Id=" + usr + ";Password=" + pas + ";Data Source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.30.119)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=DBMILE)));";
                    break;
                case ".31":
                    cadena = "User Id=" + usr + ";Password=" + pas + ";Data Source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.31.3)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=MILEOPE1)));";
                    break;
                case ".32":
                    cadena = "User Id=" + usr + ";Password=" + pas + ";Data Source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.32.3)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=MILETOC1)));";
                    break;
                case ".33":
                    cadena = "User Id=" + usr + ";Password=" + pas + ";Data Source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.33.3)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=MILEBOG2)));";
                    break;
                case ".34":
                    cadena = "User Id=" + usr + ";Password=" + pas + ";Data Source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.34.3)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=MILEYUM1)));";
                    break;
                case ".35":
                    cadena = "User Id=" + usr + ";Password=" + pas + ";Data Source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.35.3)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=MILEBUG1)));";
                    break;
                case ".36":
                    cadena = "User Id=" + usr + ";Password=" + pas + ";Data Source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.36.3)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=MILEBUE1)));";
                    break;
                case ".37":
                    cadena = "MEDELLIN";
                    break;
                case ".38":
                    cadena = "User Id=" + usr + ";Password=" + pas + ";Data Source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.38.3)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=MILEBAR1)));";
                    break;
                case ".39":
                    cadena = "User Id=" + usr + ";Password=" + pas + ";Data Source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.39.3)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=MILECAR1)));";
                    break;
                case ".40":
                    cadena = "User Id=" + usr + ";Password=" + pas + ";Data Source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.40.3)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=MILEDUI1)));";
                    break;
                case ".41":
                    cadena = "SANTAMARTA";
                    break;
                case ".50":
                    cadena = "User Id=" + usr + ";Password=" + pas + ";Data Source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.30.11)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=MILDESA)));";
                    break;
                case ".99":
                    cadena = "User Id=" + usr + ";Password=" + pas + ";Data Source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.30.31)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=KROWTEN)));";
                    break;
                default:
                    cadena = "User Id=" + usr + ";Password=" + pas + ";Data Source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.30.31)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=KROWTEN)));";
                    break;
            }

            #endregion fin de la definicion de la cadena de conexion a utilizar

            return (cadena);
        }

        private bool validarUsuario(string Cadena)
        {
            bool conexion = false;
            control_flota.Interfaces.I_Datos datos = new control_flota.Clases.C_Datos(Usuario, Password, Cadena);
            conexion = datos.validarUsuario(Cadena);
            return conexion;
        }

        private void txbContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblMensajeError.Text = "";
            if (e.KeyChar == (char)13)//validamos si se presiono la tecla enter
            {
                validarDatos();
            }
        }

        private void txbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblMensajeError.Text = "";
            if (e.KeyChar == (char)13)//validamos si se presiono la tecla enter
            {
                txbContrasena.Focus();
            }
        }

        public int Codigo_Oficina_Valido()
        {
            string ruta_oficina = @"C:\orant\NET80\ADMIN\conexion.ora";
            int codigoOficina = -1;
            string codigo = "";
                using (TextReader rw = new StreamReader(ruta_oficina, true))
                {
                    codigo = rw.ReadToEnd();
                }
                try
                {
                    codigoOficina = int.Parse(codigo.ToString());
                }
                catch (Exception ex)
                {
                    codigoOficina = 99;
                }
            return codigoOficina;
        }

        private void frm_Validacion_Load(object sender, EventArgs e)
        {

        }
    }
}
