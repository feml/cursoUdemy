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
    public partial class frm_tran_anular_registro : Form
    {
        Interfaces.I_tran_anular_registro _negocio;
        private string _cedula;
        private string _vehiculo;
        private string _trailer;
        private DataSet _ds;
        private int _secuencia;

        public frm_tran_anular_registro(string usuario, string password, string cadena)
        {
            InitializeComponent();
            lblUsuarioConectado.Text = usuario;
            _negocio = new Clases.C_tran_anular_registro(usuario, password, cadena);
            _ds = new DataSet();
            _secuencia = -1;
        }

        private void frm_tran_anular_registro_Load(object sender, EventArgs e)
        {
            cargar_consulta();
        }
        private void cargar_consulta()
        {
            _secuencia = -1;
            _ds = _negocio.generar_reporte();
            lbl_total_enturnados.Text = _ds.Tables[0].Rows.Count.ToString();
            DataView dw = new DataView(_ds.Tables[0]);
            dgv_solicitar_turno.DataSource = dw;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_solicitar_turno_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _secuencia = -1;
            lbl_conductor_valor.Text = dgv_solicitar_turno.Rows[dgv_solicitar_turno.CurrentRow.Index].Cells[1].Value.ToString();
            lbl_placa_valor.Text = dgv_solicitar_turno.Rows[dgv_solicitar_turno.CurrentRow.Index].Cells[3].Value.ToString();
            lbl_secuencia_valor.Text = dgv_solicitar_turno.Rows[dgv_solicitar_turno.CurrentRow.Index].Cells[2].Value.ToString();
            _secuencia = int.Parse(lbl_secuencia_valor.Text.ToString());
        }

        private void btn_corregir_Click(object sender, EventArgs e)
        {
            if (_secuencia>0)
            {
                _negocio.anular_registro(_secuencia, "L",lblUsuarioConectado.Text);
                cargar_consulta();
            }
            this.Close();
        }

    }
}
