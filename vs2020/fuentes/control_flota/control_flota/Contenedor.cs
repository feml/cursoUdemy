using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace control_flota
{
    /// <summary>
    /// public partial class frm_contenedor : Form
    /// </summary>
    public partial class frm_contenedor : Form
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

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        Formularios.Control_flota.frm_Validacion f_validacion;
        /// <summary>
        /// public frm_contenedor()
        /// </summary>
        public frm_contenedor()
        {
            InitializeComponent();
        }
        private void enturneTallerToolStripMenuItem_Click(object sender, EventArgs e)
        {                        
            cargarCadena();
            Formularios.Consultas.frm_cons_enturnados_taller f_Vehiculos_Enturnados_taller = new Formularios.Consultas.frm_cons_enturnados_taller(_usuario, _password, _cadena);
            f_Vehiculos_Enturnados_taller.MdiParent = this;
            f_Vehiculos_Enturnados_taller.Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Application.Exit();
            this.Close();
        }

        private void vehiculosEnturnadosOficinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Consultas.frm_cons_enturnados_oficinas f_enturnados_oficinas = new Formularios.Consultas.frm_cons_enturnados_oficinas(_usuario, _password, _cadena);
            f_enturnados_oficinas.MdiParent = this;
            f_enturnados_oficinas.Show();
        }

        private void controlDeFlotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Control_flota.frm_control_flota f_control_flota = new Formularios.Control_flota.frm_control_flota(_usuario, _password, _cadena);
            f_control_flota.MdiParent = this;
            f_control_flota.Show();
        }

        private void frm_contenedor_Load(object sender, EventArgs e)
        {
            f_validacion = new Formularios.Control_flota.frm_Validacion();
            //f_validacion.MdiParent = this;
            DialogResult dr = f_validacion.ShowDialog();
            if (dr == DialogResult.OK)
            {
                cargarCadena();
                Formularios.Control_flota.frm_control_flota f_control_flota = new Formularios.Control_flota.frm_control_flota(_usuario, _password, _cadena);
                f_control_flota.MdiParent = this;
                f_control_flota.Show();
            }
        }

        private void solicitarTurnoTallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Transacciones.frm_tran_solicitar_turno f_solicitar_turno = new Formularios.Transacciones.frm_tran_solicitar_turno(_usuario, _password, _cadena);
            f_solicitar_turno.MdiParent = this;
            f_solicitar_turno.Show();
        }

        private void llamadoIngresoTallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Transacciones.frm_tran_solicitud_ingreso f_solicitud_ingreso = new Formularios.Transacciones.frm_tran_solicitud_ingreso(_usuario, _password, _cadena);
            f_solicitud_ingreso.MdiParent = this;
            f_solicitud_ingreso.Show();
        }

        private void registrarIngresoTallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Transacciones.frm_tran_ingreso_taller f_ingreso_taller = new Formularios.Transacciones.frm_tran_ingreso_taller(_usuario, _password, _cadena);
            f_ingreso_taller.MdiParent = this;
            f_ingreso_taller.Show();
        }

        private void salidaTallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Transacciones.frm_tran_salida_taller f_salida_taller = new Formularios.Transacciones.frm_tran_salida_taller(_usuario, _password, _cadena);
            f_salida_taller.MdiParent = this;
            f_salida_taller.Show();
        }

        private void consultarInconsistenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Solucionar_Inconsistencias.frm_inco_consultar_inconsistencias f_consultar_inconsistencias = new Formularios.Solucionar_Inconsistencias.frm_inco_consultar_inconsistencias(_usuario, _password, _cadena);
            f_consultar_inconsistencias.MdiParent = this;
            f_consultar_inconsistencias.Show();
        }

        private void solucionarInconsistenciasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Solucionar_Inconsistencias.frm_inco_atender_inconsistencias f_atender_inconsistencias = new Formularios.Solucionar_Inconsistencias.frm_inco_atender_inconsistencias(_usuario, _password, _cadena);
            f_atender_inconsistencias.MdiParent = this;
            f_atender_inconsistencias.Show();
        }

        private void anularProcesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Transacciones.frm_tran_anular_registro f_anular_registro = new Formularios.Transacciones.frm_tran_anular_registro(_usuario, _password, _cadena);
            f_anular_registro.MdiParent = this;
            f_anular_registro.Show();
        }

        private void ingresoParqueaderoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Transacciones.frm_tran_ingreso_parqueadero f_ingreso_parqueadero = new Formularios.Transacciones.frm_tran_ingreso_parqueadero(_usuario, _password, _cadena);
            f_ingreso_parqueadero.MdiParent = this;
            f_ingreso_parqueadero.Show();
        }

        private void salidaParqueaderoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Transacciones.frm_tran_salida_parqueadero f_salida_parqueadero = new Formularios.Transacciones.frm_tran_salida_parqueadero(_usuario, _password, _cadena);
            f_salida_parqueadero.MdiParent = this;
            f_salida_parqueadero.Show();
        }

        private void turnosOficinasAnuladosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Consultas.frm_cons_anulacion_oficinas f_cons_anulacion_oficinas = new Formularios.Consultas.frm_cons_anulacion_oficinas(_usuario, _password, _cadena);
            f_cons_anulacion_oficinas.MdiParent = this;
            f_cons_anulacion_oficinas.Show();
        }

        private void vehiculosSolicitadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Consultas.frm_cons_solicitud_ingreso f_cons_solicitud_ingreso = new Formularios.Consultas.frm_cons_solicitud_ingreso(_usuario, _password, _cadena);
            f_cons_solicitud_ingreso.MdiParent = this;
            f_cons_solicitud_ingreso.Show();
        }

        private void vehiculosEnTallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Consultas.frm_cons_taller f_cons_taller = new Formularios.Consultas.frm_cons_taller(_usuario, _password, _cadena);
            f_cons_taller.MdiParent = this;
            f_cons_taller.Show();
        }

        private void vehiculosAtendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Consultas.frm_cons_atendidos f_cons_atendidos = new Formularios.Consultas.frm_cons_atendidos(_usuario, _password, _cadena);
            f_cons_atendidos.MdiParent = this;
            f_cons_atendidos.Show();
        }

        private void tunosAnuladosTallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Consultas.frm_cons_anulaciones_taller f_cons_anulaciones_taller = new Formularios.Consultas.frm_cons_anulaciones_taller(_usuario, _password, _cadena);
            f_cons_anulaciones_taller.MdiParent = this;
            f_cons_anulaciones_taller.Show();
        }
        private void cargarCadena()
        {
            _usuario = f_validacion.Usuario;
            _password = f_validacion.Password;
            _cadena = f_validacion.Cadena;
        }

        private void vehiculosEnParqueaderoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Consultas.frm_cons_parqueaderos f_Vehiculos_Parqueadero = new Formularios.Consultas.frm_cons_parqueaderos(_usuario, _password, _cadena);
            f_Vehiculos_Parqueadero.MdiParent = this;
            f_Vehiculos_Parqueadero.Show();
        }

        private void consultarInconsistenciasParqueaderoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Solucionar_Inconsistencias.frm_inco_consultar_parqueadero f_consultar_inconsistencias_parqueadero = new Formularios.Solucionar_Inconsistencias.frm_inco_consultar_parqueadero(_usuario, _password, _cadena);
            f_consultar_inconsistencias_parqueadero.MdiParent = this;
            f_consultar_inconsistencias_parqueadero.Show();
        }

        private void solucionarInconsistenciasParqueaderoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCadena();
            Formularios.Solucionar_Inconsistencias.frm_inco_atender_parqueadero f_atender_inconsistencias_parqueadero = new Formularios.Solucionar_Inconsistencias.frm_inco_atender_parqueadero(_usuario, _password, _cadena);
            f_atender_inconsistencias_parqueadero.MdiParent = this;
            f_atender_inconsistencias_parqueadero.Show();
        }
    }
}
