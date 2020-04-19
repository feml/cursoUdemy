/**************************************************************************
@author  FMONTOYA
@version 1.0
Development Environment        :  MS Visual Studio .NET
Name of the File               :  frm_tran_solicitar_turno.cs
Creation/Modification History  :  23-Enero-2014     Created
                               :  23-Enero-2014     Modificado 
                               :  10-02-14     Modificado 
                               :  00-00-00     Modificado 
Overview:
 * 
 * 
 * 
**************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace control_flota.Formularios.Transacciones
{
    public partial class frm_tran_solicitar_turno : Form
    {
        Interfaces.I_tran_solicitar_turno _negocio;
        private string _cedula;
        private string _vehiculo;
        private string _trailer;
        private DataSet _ds;
        /// <summary>
        /// public frm_tran_solicitar_turno(string usuario, string password, string cadena)
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <param name="cadena"></param>
        public frm_tran_solicitar_turno(string usuario, string password, string cadena)
        {
            InitializeComponent();
            lblUsuarioConectado.Text = usuario;
            _negocio = new Clases.C_tran_solicitar_turno(usuario, password, cadena);
            _ds = new DataSet();
        }
        /// <summary>
        /// private void button2_Click(object sender, EventArgs e)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// private void frm_tran_solicitar_turno_Load(object sender, EventArgs e)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_tran_solicitar_turno_Load(object sender, EventArgs e)
        {
            _vehiculo = "ZZZZZZ";
            _trailer = "ZZZZZZ";
            _ds = _negocio.combobox_vehiculos();//Revisado 10/02/2014
            cbx_vehiculo.ValueMember = "VEHI_PLACA_CH";
            cbx_vehiculo.DisplayMember = "VEHI_PLACA_CH";
            cbx_vehiculo.DataSource = _ds.Tables[0].DefaultView;
            _ds = _negocio.combobox_trailers();//Revisado 10/02/2014
            cbx_trailer.ValueMember = "TRAI_PLACA_CH";
            cbx_trailer.DisplayMember = "TRAI_PLACA_CH";
            cbx_trailer.DataSource = _ds.Tables[0].DefaultView;
            _ds = _negocio.combobox_conductores();//Revisado 10/02/2014
            cbx_conductor.ValueMember = "COND_CEDULA";
            cbx_conductor.DisplayMember = "COND_NOMBRE";
            cbx_conductor.DataSource = _ds.Tables[0].DefaultView;
            cargar_consulta();//Revisado 10/02/2014
            btn_registrar.Enabled = false;
            cbx_vehiculo.Enabled = false;
            cbx_trailer.Enabled = false;
        }
        /// <summary>
        /// private void cbx_conductor_SelectedIndexChanged(object sender, EventArgs e)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_conductor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cedula = ((DataRowView)cbx_conductor.SelectedItem).Row.ItemArray[0].ToString();//Revisado 10/02/2014
            cbx_vehiculo.Enabled = true;
        }
        /// <summary>
        /// private void cbx_vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _vehiculo = ((DataRowView)cbx_vehiculo.SelectedItem).Row.ItemArray[0].ToString();//Revisado 10/02/2014
            cbx_trailer.Enabled = true;
            btn_registrar.Enabled = true;
        }
        /// <summary>
        /// private void cbx_trailer_SelectedIndexChanged(object sender, EventArgs e)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_trailer_SelectedIndexChanged(object sender, EventArgs e)
        {
            _trailer = ((DataRowView)cbx_trailer.SelectedItem).Row.ItemArray[0].ToString();//Revisado 10/02/2014
            btn_registrar.Enabled = true;
        }
        /// <summary>
        /// private void btn_registrar_Click(object sender, EventArgs e)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_registrar_Click(object sender, EventArgs e)
        {
            _negocio.registrar_turno(_cedula, _vehiculo, _trailer, lblUsuarioConectado.Text);//Revisado 10/02/2014
            this.Close();
        }
        /// <summary>
        /// private void cargar_consulta()
        /// </summary>
        private void cargar_consulta()
        {
            _ds = _negocio.generar_reporte();//Revisado 10/02/2014
            lbl_total_enturnados.Text = _ds.Tables[0].Rows.Count.ToString();
            DataView dw = new DataView(_ds.Tables[0]);
            dgv_solicitar_turno.DataSource = dw;
        }
    }
}
