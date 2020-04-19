using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace control_flota.Formularios.Control_flota
{
    public partial class frm_control_flota : Form
    {
        private Interfaces.I_cont_control_flota _negocio;
        private DataSet _ds;

        public frm_control_flota(string usuario, string password, string cadena)
        {
            InitializeComponent();
            lblUsuarioConectado.Text = usuario;
            _negocio = new Clases.C_cont_control_flota(usuario, password, cadena);
            cargar_consulta();
        }

        private void frm_control_flota_Load(object sender, EventArgs e)
        {
            consultar_flota();
        }
        private void consultar_flota()
        {
            int[] c_f = new int[6];
            c_f = _negocio.consulta_flota();
            lbl_tot_veh_ent_oficinas.Text = c_f[0].ToString();
            lbl_tot_veh_ent_taller.Text = c_f[1].ToString();
            lbl_tot_veh_atendidos_taller.Text = c_f[2].ToString();
            lbl_tot_veh_entaller.Text = c_f[3].ToString();
            lbl_tot_veh_siniestrado.Text = c_f[4].ToString();            
            consulta_vehiculos_parqueadero();
            consulta_vehiculos_atendidos();
        }

        private void consulta_vehiculos_atendidos()
        {
            _ds = _negocio.consulta_vehiculos_atendidos_taller(dateTimePicker1, dateTimePicker2);
            lbl_tot_veh_atendidos_taller.Text = _ds.Tables[0].Rows.Count.ToString();
            DataView dw = new DataView(_ds.Tables[0]);
            dgv_consulta.DataSource = dw;
        }

        private void consulta_vehiculos_parqueadero()
        {
            _ds = _negocio.consulta_vehiculos_parqueadero();
            lbl_tot_veh_parqueadero.Text = _ds.Tables[0].Rows.Count.ToString();
        }

        private void cargar_consulta()
        {
            inicializar_titulos();
            _ds = _negocio.consulta_vehiculos_taller();
            lbl_tot_veh_entaller.Text = _ds.Tables[0].Rows.Count.ToString();
            DataView dw = new DataView(_ds.Tables[0]);
            dgv_consulta.DataSource = dw;
        }

        private void btn_consultar_ent_oficinas_Click(object sender, EventArgs e)
        {
            inicializar_titulos();
            consultar_flota();
            _ds = _negocio.consulta_vehiculos_oficinas();
            lbl_tot_veh_ent_oficinas.Text = _ds.Tables[0].Rows.Count.ToString();
            DataView dw = new DataView(_ds.Tables[0]);
            dgv_consulta.DataSource = dw;
        }
        private void inicializar_titulos()
        {
            lbl_tot_veh_ent_oficinas.Text = "0";
            lbl_tot_veh_ent_taller.Text = "0";
            lbl_tot_veh_atendidos_taller.Text = "0";
            lbl_tot_veh_entaller.Text = "0";
            lbl_tot_veh_parqueadero.Text = "0";
            lbl_tot_veh_siniestrado.Text = "0";
            lbl_tot_veh_ent_taller.Text = "0";
        }

        private void btn_consultar_taller_Click(object sender, EventArgs e)
        {
            inicializar_titulos();
            consultar_flota();
            _ds = _negocio.consulta_vehiculos_taller();
            lbl_tot_veh_entaller.Text = _ds.Tables[0].Rows.Count.ToString();
            DataView dw = new DataView(_ds.Tables[0]);
            dgv_consulta.DataSource = dw;
        }

        private void btn_consultar_despachados_Click(object sender, EventArgs e)
        {
            inicializar_titulos();
            consultar_flota();
            _ds = _negocio.consulta_vehiculos_atendidos_taller(dateTimePicker1, dateTimePicker2);
            lbl_tot_veh_atendidos_taller.Text = _ds.Tables[0].Rows.Count.ToString();
            DataView dw = new DataView(_ds.Tables[0]);
            dgv_consulta.DataSource = dw;
        }

        private void btn_consultar_siniestrados_Click(object sender, EventArgs e)
        {
            inicializar_titulos();
            consultar_flota();            
            _ds = _negocio.consulta_vehiculos_siniestrados();
            lbl_tot_veh_atendidos_taller.Text = _ds.Tables[0].Rows.Count.ToString();
            //DataView dw = new DataView(_ds.Tables[0]);
            //dgv_consulta.DataSource = dw;
        }

        private void btn_consultar_ent_taller_Click(object sender, EventArgs e)
        {
            inicializar_titulos();
            consultar_flota();
            _ds = _negocio.consulta_vehiculos_enturnados_taller();
            lbl_tot_veh_ent_taller.Text = _ds.Tables[0].Rows.Count.ToString();
            DataView dw = new DataView(_ds.Tables[0]);
            dgv_consulta.DataSource = dw;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consultar_flota();
            _ds = _negocio.consulta_vehiculos_parqueadero();
            lbl_tot_veh_parqueadero.Text = _ds.Tables[0].Rows.Count.ToString();
            DataView dw = new DataView(_ds.Tables[0]);
            dgv_consulta.DataSource = dw;
        }

        private void btnRepacionesExternas_Click(object sender, EventArgs e)
        {
            inicializar_titulos();
            consultar_flota();
            _ds = _negocio.consulta_reparaciones_externas();
            lbl_tot_veh_ent_oficinas.Text = _ds.Tables[0].Rows.Count.ToString();
            DataView dw = new DataView(_ds.Tables[0]);
            dgv_consulta.DataSource = dw;
        }
    }
}
