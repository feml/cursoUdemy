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
    public partial class frm_tran_solicitud_ingreso : Form
    {
        Interfaces.I_tran_solicitud_ingreso _negocio;
        private string _cedula;
        private string _vehiculo;
        private string _trailer;
        private DataSet _ds;

        public frm_tran_solicitud_ingreso(string usuario, string password, string cadena)
        {
            InitializeComponent();
            lblUsuarioConectado.Text = usuario;
            _negocio = new Clases.C_tran_solicitud_ingreso(usuario, password, cadena);
            _ds = new DataSet();
        }

        private void frm_tran_solicitud_ingreso_Load(object sender, EventArgs e)
        {
            _vehiculo = "ZZZZZZ";
            _trailer = "ZZZZZZ";
            _ds = _negocio.combobox_conductores();
            cbx_conductor.ValueMember = "COND_CEDULA";
            cbx_conductor.DisplayMember = "COND_NOMBRE";
            cbx_conductor.DataSource = _ds.Tables[0].DefaultView;
            /*foreach (DataRow dr in _ds.Tables["CONSULTA"].Rows)
                        {
                            cbx_conductor.Items.Add(dr[2].ToString() + " " + dr[1].ToString());
                        }*/

            cargar_consulta();
        }

        private void cbx_conductor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cedula = ((DataRowView)cbx_conductor.SelectedItem).Row.ItemArray[0].ToString();//Revisado 10/02/2014
            cbx_vehiculo.Enabled = true;
            try
            {
                cbx_vehiculo.Items.Clear();
            }
            catch (Exception ex)
            {
            }
            _vehiculo = "ZZZZZZ";

            _ds = _negocio.combobox_vehiculos(_cedula);
            cbx_vehiculo.ValueMember = "INTA_PLACA_CH";
            cbx_vehiculo.DisplayMember = "INTA_PLACA_CH";
            cbx_vehiculo.DataSource = _ds.Tables[0].DefaultView;
            
            _ds = _negocio.combobox_trailers(_cedula);
            cbx_trailer.ValueMember = "INTA_PLACA_CH";
            cbx_trailer.DisplayMember = "INTA_PLACA_CH";
            cbx_trailer.DataSource = _ds.Tables[0].DefaultView;
            btn_registrar.Enabled = true;

        }

        private void cbx_trailer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_trailer = cbx_trailer.SelectedItem.ToString();
            _trailer = ((DataRowView)cbx_trailer.SelectedItem).Row.ItemArray[0].ToString();//Revisado 10/02/2014
            btn_registrar.Enabled = true;

        }
        private void cargar_consulta()
        {
            _ds = _negocio.generar_reporte();
            lbl_total_enturnados.Text = _ds.Tables[0].Rows.Count.ToString();
            DataView dw = new DataView(_ds.Tables[0]);
            dgv_solicitar_turno.DataSource = dw;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_vehiculo!="ZZZZZZ")
            {
                _negocio.registrar_turno(_cedula, _vehiculo, _trailer, lblUsuarioConectado.Text);
            }
            else
            {
                if (_trailer!="ZZZZZZ")
                {
                    _negocio.registrar_turno(_cedula, _vehiculo, _trailer,lblUsuarioConectado.Text);
                }
            }            
            //cargar_consulta();
            try
            {
                cbx_conductor.Items.Clear();
            }
            catch (Exception ex)
            {

            }
            try
            {
                cbx_vehiculo.Items.Clear();
            }
            catch (Exception ex)
            {
            }
            cbx_vehiculo.Enabled = false;
            try
            {
                cbx_trailer.Items.Clear();
            }
            catch (Exception ex)
            {
            }
            cbx_trailer.Enabled = false;
            _vehiculo = "ZZZZZZ";
            _trailer = "ZZZZZZ";
            //_ds = _negocio.combobox_conductores();
            /*foreach (DataRow dr in _ds.Tables["CONSULTA"].Rows)
            {
                cbx_conductor.Items.Add(dr[2].ToString() + " " + dr[1].ToString());
            }*/
            this.Close();
        }

        private void cbx_vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_vehiculo = cbx_vehiculo.SelectedItem.ToString();
            _vehiculo = ((DataRowView)cbx_vehiculo.SelectedItem).Row.ItemArray[0].ToString();//Revisado 10/02/2014
            btn_registrar.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
