using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace control_flota.Formularios.Consultas
{
    public partial class frm_cons_atendidos : Form
    {
        private Control_flota.Interfaces.I_cont_control_flota _negocio;
        private DataSet _ds;

        public frm_cons_atendidos(string usuario, string password, string cadena)
        {
            InitializeComponent();
            lblUsuarioConectado.Text = usuario;
            _negocio = new Control_flota.Clases.C_cont_control_flota(usuario, password, cadena);
            _ds = new DataSet();
        }

        private void frm_cons_atendidos_Load(object sender, EventArgs e)
        {
            cargar_consulta();
        }
        private void cargar_consulta()
        {
            _ds = _negocio.consulta_vehiculos_atendidos_taller(fecini, fecfin);
            lbl_total_enturnados.Text = _ds.Tables[0].Rows.Count.ToString();
            DataView dw = new DataView(_ds.Tables[0]);
            dgv_consulta.DataSource = dw;

        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btn_consultar_atendidos_taller_Click(object sender, EventArgs e)
        {
            cargar_consulta();
        }

        private void btnGenerarArchivoPlano_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            _negocio.generarArchivoPlanoNew("ATENDIDOS_TALLER", fecini, fecfin);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            // Format and display the TimeSpan value.
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",ts.Hours, ts.Minutes + 45, ts.Seconds,ts.Milliseconds / 10);
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            MessageBox.Show("Archivo Generado Con exito. Duracion del proceso : " + elapsedTime);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            _negocio.generarArchivoPlanoonemes("ATENDIDOS_TALLER", fecini, fecfin);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            // Format and display the TimeSpan value.
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",ts.Hours, ts.Minutes + 45, ts.Seconds,ts.Milliseconds / 10);
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            MessageBox.Show("Archivo Generado Con exito. Duracion del proceso : " + elapsedTime);

        }
    }
}
