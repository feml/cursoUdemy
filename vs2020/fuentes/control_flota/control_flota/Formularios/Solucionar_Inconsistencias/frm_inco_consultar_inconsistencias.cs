using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace control_flota.Formularios.Solucionar_Inconsistencias
{
    public partial class frm_inco_consultar_inconsistencias : Form
    {
        Interfaces.I_inco_consultar_inconsistencias _negocio;
        private string _cedula;
        private string _vehiculo;
        private string _trailer;
        private DataSet _ds;

        public frm_inco_consultar_inconsistencias(string usuario, string password, string cadena)
        {
            InitializeComponent();
            lblUsuarioConectado.Text = usuario;
            _negocio = new Clases.C_inco_consultar_inconsistencias(usuario, password, cadena);
            _ds = new DataSet();
        }

        private void frm_inco_consultar_inconsistencias_Load(object sender, EventArgs e)
        {
            cargar_consulta();
        }
        private void cargar_consulta()
        {
            _ds = _negocio.generar_reporte();
            lbl_total_enturnados.Text = _ds.Tables[0].Rows.Count.ToString();
            DataView dw = new DataView(_ds.Tables[0]);
            dgv_solicitar_turno.DataSource = dw;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
