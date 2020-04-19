using EntityMinisterio;
using fml.wfEnvioUnitario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfEnvioUnitario
{
    public partial class Form1 : Form
    {
        public int _CodigoTransaccion { get; set; }
        public string _llave { get; set; }
        public string _xml_envio { get; set; }
        public string _xml_recibido { get; set; }
        public string _funcion { get; set; }
        public LogReporteMinisterio pLogReporteMinisterio { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboTransacciones();
        }

        private void comboTransacciones()
        {
            cbxTransaccion.DisplayMember = "Transaccion";
            cbxTransaccion.ValueMember = "Codigo";

            DataTable dtTransacciones = new DataTable("Log");

            dtTransacciones.Columns.Add("Transaccion", typeof(string));
            dtTransacciones.Columns.Add("Codigo", typeof(int));

            dtTransacciones.Rows.Add("Orden de Cargue", 3);
            dtTransacciones.Rows.Add("Planilla", 4);
            dtTransacciones.Rows.Add("Tiempos", 5);
            dtTransacciones.Rows.Add("Cumplimiento", 6);
            dtTransacciones.Rows.Add("Anular Orden de Cargue", 9);
            dtTransacciones.Rows.Add("Propietarios Nit", 10);
            dtTransacciones.Rows.Add("Propietarios Cedula", 11);
            dtTransacciones.Rows.Add("Conductores", 12);
            dtTransacciones.Rows.Add("Clientes Nit", 13);
            dtTransacciones.Rows.Add("Clientes Cedula", 14);
            dtTransacciones.Rows.Add("Vehiculos", 15);
            dtTransacciones.Rows.Add("Trailers", 16);
            dtTransacciones.Rows.Add("Anular Planilla", 32);

            cbxTransaccion.DataSource = dtTransacciones;

            _CodigoTransaccion = 3;
        }

        private void cbxTransaccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _CodigoTransaccion = (int)cbxTransaccion.SelectedValue;
                txbLlave.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _CodigoTransaccion = -1;
            }
        }

        private void txbLlave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnConsultar.Enabled = false;
                _llave = txbLlave.Text;
                consultar(_llave,true);
            }
        }

        private void consultar(string llave)
        {
            btnConsultar.Enabled = false;
            txbXmlEnviado.Text = string.Empty;
            txbXmlRecibido.Text = string.Empty;

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


            LogicaWfEnvioUnitario logica = new LogicaWfEnvioUnitario(usuario, password, usuEmail, passEmail, ambiente);
            DataTable dt = new DataTable();
            dt = logica.consultarRegistro(_llave,_CodigoTransaccion);
            if (dt.Rows.Count > 0)
            {
                btnConsultar.Enabled = true;
                panelConsulta.Visible = true;
                panelTransacciones.Visible = true;
                _xml_envio = logica._xml_envio;
                txbXmlEnviado.Text = _xml_envio;
                _funcion = logica._funtion;
                pLogReporteMinisterio = logica.pLogReporteMinisterio;
                dgvConsulta.DataSource = dt;
                btnEnviar.Focus();
            }
            btnConsultar.Enabled = true;
        }

        private void consultar(string llave, bool clean)
        {
            btnConsultar.Enabled = false;
            if (clean)
            {
                txbXmlEnviado.Text = string.Empty;
                txbXmlRecibido.Text = string.Empty;
            }

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


            LogicaWfEnvioUnitario logica = new LogicaWfEnvioUnitario(usuario, password, usuEmail, passEmail, ambiente);
            DataTable dt = new DataTable();
            dt = logica.consultarRegistro(_llave, _CodigoTransaccion);
            if (dt.Rows.Count > 0)
            {
                btnConsultar.Enabled = true;
                panelConsulta.Visible = true;
                panelTransacciones.Visible = true;
                _xml_envio = logica._xml_envio;
                txbXmlEnviado.Text = _xml_envio;
                _funcion = logica._funtion;
                pLogReporteMinisterio = logica.pLogReporteMinisterio;
                dgvConsulta.DataSource = dt;
                btnEnviar.Focus();
            }
            btnConsultar.Enabled = true;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            _llave = txbLlave.Text;
            consultar(_llave,true);
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            btnEnviar.Enabled = false;
            txbXmlRecibido.Text = string.Empty;

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

            _xml_envio = txbXmlEnviado.Text;
            LogicaWfEnvioUnitario logica = new LogicaWfEnvioUnitario(usuario, password, usuEmail, passEmail, ambiente);

            _xml_recibido = logica.enviarMinisterio(_xml_envio);

            if (_xml_recibido.Length > 10)
            {
                txbXmlRecibido.Text = _xml_recibido;
                actualizar();
                consultar(_llave,false);
            }
            else
            {
                txbXmlRecibido.Text = "No se obtuvo respuesta por parte del servidor del ministerio.";
            }
            btnEnviar.Enabled = true;
            //logica.procesarEnvioMinisterio(_funcion, txbXmlEnviado.Text, xml_recibido, pLogReporteMinisterio);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        private void actualizar()
        {
            btnActualizar.Enabled = false;
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


            LogicaWfEnvioUnitario logica = new LogicaWfEnvioUnitario(usuario, password, usuEmail, passEmail, ambiente);

            logica.procesarEnvioMinisterio(_funcion, _xml_envio, _xml_recibido, pLogReporteMinisterio);

            btnActualizar.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
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
