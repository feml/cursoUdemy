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
    public partial class frm_inco_atender_parqueadero : Form
    {
        Interfaces.I_inco_corregir_inconsistencia _negocio;
        private string _cedula;
        private string _vehiculo;
        private string _trailer;
        private DataSet _ds;
        private int _year;
        private int _mounth;
        private int _day;
        private int _hours;
        private int _minute;
        private int _seconds;
        private int _secuencia;
        private string _estado;
        private DateTime _dtp_temporal;

        public frm_inco_atender_parqueadero(string usuario, string password, string cadena)
        {
            InitializeComponent();
            lblUsuarioConectado.Text = usuario;
            _negocio = new Clases.C_inco_corregir_inconsistencia(usuario, password, cadena);
            _ds = new DataSet();
            _secuencia = -1;
            _estado = "";

        }

        private void frm_inco_atender_parqueadero_Load(object sender, EventArgs e)
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

    }
}
