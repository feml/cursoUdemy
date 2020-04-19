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
    public partial class frm_inco_atender_inconsistencias : Form
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

        public frm_inco_atender_inconsistencias(string usuario, string password, string cadena)
        {
            InitializeComponent();
            lblUsuarioConectado.Text = usuario;
            _negocio = new Clases.C_inco_corregir_inconsistencia(usuario, password, cadena);
            _ds = new DataSet();
            _secuencia = -1;
            _estado = "";
        }

        private void frm_inco_atender_inconsistencias_Load(object sender, EventArgs e)
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

        private void btn_corregir_Click(object sender, EventArgs e)
        {
            if (validar_parametros())
            {
                _negocio.actualizar_inconsistencia(_secuencia, _estado, dtp_enturne, dtp_solicitud, dtp_ingreso, dtp_salida,lblUsuarioConectado.Text);
            }
            cbx_estado.SelectedItem = 0;
            cbx_estado.SelectedIndex = 0;
            cbx_estado.Enabled = false;
            txb_fecha_enturne.Text = "";
            txb_fecha_salicitud.Text = "";
            txb_fecha_ingreso.Text = "";
            txb_fecha_salida.Text = "";
            txb_fecha_enturne.Enabled = false;
            txb_fecha_salicitud.Enabled = false;
            txb_fecha_ingreso.Enabled = false;
            txb_fecha_salida.Enabled = false;
            txb_hora_enturne.Text = "";
            txb_hora_solicitud.Text = "";
            txb_hora_ingreso.Text = "";
            txb_hora_salida.Text = "";
            cargar_consulta();
        }

        private void dgv_solicitar_turno_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string error = "";
            bool fecha_correcta = true;
            lbl_conductor_valor.Text = dgv_solicitar_turno.Rows[dgv_solicitar_turno.CurrentRow.Index].Cells[0].Value.ToString();
            lbl_placa_valor.Text = dgv_solicitar_turno.Rows[dgv_solicitar_turno.CurrentRow.Index].Cells[2].Value.ToString();
            lbl_secuencia_valor.Text = dgv_solicitar_turno.Rows[dgv_solicitar_turno.CurrentRow.Index].Cells[1].Value.ToString();
            txb_observacion.Text = dgv_solicitar_turno.Rows[dgv_solicitar_turno.CurrentRow.Index].Cells[9].Value.ToString();
            _secuencia = int.Parse(lbl_secuencia_valor.Text.ToString());
            
                     
            cbx_estado.Enabled = true;
        }

        private void fecha_enturne()
        {
            string error = "";
            bool fecha_correcta = true;
            #region definicion de la fecha de enturne
            txb_fecha_enturne.Text = dgv_solicitar_turno.Rows[dgv_solicitar_turno.CurrentRow.Index].Cells[4].Value.ToString();
            try
            {
                _year = int.Parse(txb_fecha_enturne.Text.Substring(6, 4));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _mounth = int.Parse(txb_fecha_enturne.Text.Substring(3, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _day = int.Parse(txb_fecha_enturne.Text.Substring(0, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _hours = int.Parse(txb_fecha_enturne.Text.Substring(11, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _minute = int.Parse(txb_fecha_enturne.Text.Substring(14, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _seconds = int.Parse(txb_fecha_enturne.Text.Substring(17, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }

            if (fecha_correcta)
            {
                dtp_enturne.Value = new DateTime(_year, _mounth, _day, _hours, _minute, _seconds);
                txb_hora_enturne.Text = _hours.ToString() + ":" + _minute.ToString();
                txb_fecha_enturne.Enabled = true;
            }
            else
            {
                txb_fecha_enturne.Enabled = false;
                txb_fecha_enturne.Visible = false;
                dtp_enturne.Enabled = true;
                txb_hora_enturne.Enabled = true;
            }
            #endregion definicion de la fecha de enturne
        }

        private void fecha_solicitud()
        {
            string error = "";
            bool fecha_correcta = true;
            #region definicion de la fecha de solicitud
            txb_fecha_salicitud.Text = dgv_solicitar_turno.Rows[dgv_solicitar_turno.CurrentRow.Index].Cells[5].Value.ToString();
            try
            {
                _year = int.Parse(txb_fecha_salicitud.Text.Substring(6, 4));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _mounth = int.Parse(txb_fecha_salicitud.Text.Substring(3, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _day = int.Parse(txb_fecha_salicitud.Text.Substring(0, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _hours = int.Parse(txb_fecha_salicitud.Text.Substring(11, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _minute = int.Parse(txb_fecha_salicitud.Text.Substring(14, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _seconds = int.Parse(txb_fecha_salicitud.Text.Substring(17, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }

            if (fecha_correcta)
            {
                dtp_solicitud.Value = new DateTime(_year, _mounth, _day, _hours, _minute, _seconds);
                txb_hora_solicitud.Text = _hours.ToString() + ":" + _minute.ToString();
                txb_fecha_salicitud.Enabled = true;
            }
            else
            {
                txb_fecha_salicitud.Enabled = false;
                txb_fecha_salicitud.Visible = false;
                dtp_solicitud.Enabled = true;
                txb_hora_solicitud.Enabled = true;
            }
            #endregion definicion de la fecha de enturne
        }

        private void fecha_ingreso()
        {
            string error = "";
            bool fecha_correcta = true;
            #region definicion de la fecha de ingreso
            txb_fecha_ingreso.Text = dgv_solicitar_turno.Rows[dgv_solicitar_turno.CurrentRow.Index].Cells[6].Value.ToString();
            try
            {
                _year = int.Parse(txb_fecha_ingreso.Text.Substring(6, 4));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _mounth = int.Parse(txb_fecha_ingreso.Text.Substring(3, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _day = int.Parse(txb_fecha_ingreso.Text.Substring(0, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _hours = int.Parse(txb_fecha_ingreso.Text.Substring(11, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _minute = int.Parse(txb_fecha_ingreso.Text.Substring(14, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _seconds = int.Parse(txb_fecha_ingreso.Text.Substring(17, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }

            if (fecha_correcta)
            {
                dtp_ingreso.Value = new DateTime(_year, _mounth, _day, _hours, _minute, _seconds);
                txb_hora_ingreso.Text = _hours.ToString() + ":" + _minute.ToString();
                txb_fecha_ingreso.Enabled = true;
            }
            else
            {
                txb_fecha_ingreso.Enabled = false;
                txb_fecha_ingreso.Visible = false;
                dtp_ingreso.Enabled = true;
                txb_hora_ingreso.Enabled = true;
            }
            #endregion definicion de la fecha de enturne
        }

        private void fecha_salida()
        {
            string error = "";
            bool fecha_correcta = true;
            #region definicion de la fecha de salida
            txb_fecha_salida.Text = dgv_solicitar_turno.Rows[dgv_solicitar_turno.CurrentRow.Index].Cells[7].Value.ToString();
            try
            {
                _year = int.Parse(txb_fecha_salida.Text.Substring(6, 4));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _mounth = int.Parse(txb_fecha_salida.Text.Substring(3, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _day = int.Parse(txb_fecha_salida.Text.Substring(0, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _hours = int.Parse(txb_fecha_salida.Text.Substring(11, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _minute = int.Parse(txb_fecha_salida.Text.Substring(14, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }
            try
            {
                _seconds = int.Parse(txb_fecha_salida.Text.Substring(17, 2));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                fecha_correcta = false;
            }

            if (fecha_correcta)
            {
                dtp_salida.Value = new DateTime(_year, _mounth, _day, _hours, _minute, _seconds);
                txb_hora_salida.Text = _hours.ToString() + ":" + _minute.ToString();
                txb_fecha_salida.Enabled = true;
            }
            else
            {
                txb_fecha_salida.Enabled = false;
                txb_fecha_salida.Visible = false;
                dtp_salida.Enabled = true;
                txb_hora_salida.Enabled = true;
            }
            #endregion definicion de la fecha de salida
        }

        private void dtp_enturne_ValueChanged(object sender, EventArgs e)
        {
            txb_hora_enturne.Text = "";
            txb_hora_enturne.Focus();
        }

        private void dtp_solicitud_ValueChanged(object sender, EventArgs e)
        {
            txb_hora_solicitud.Focus(); 
            txb_hora_solicitud.Text = "";            
        }

        private void dtp_ingreso_ValueChanged(object sender, EventArgs e)
        {
            txb_hora_ingreso.Text = "";
            txb_hora_ingreso.Focus();
        }

        private void dtp_salida_ValueChanged(object sender, EventArgs e)
        {
            txb_hora_salida.Focus();
            txb_hora_salida.Text = "";
        }

        private void txb_fecha_enturne_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txb_fecha_enturne.Visible = false;
            dtp_enturne.Enabled = true;
            dtp_enturne.Visible = true;
            txb_hora_enturne.Enabled = true;
            txb_hora_enturne.Visible = true;
            txb_hora_enturne.Focus();
        }

        private void txb_hora_enturne_DoubleClick(object sender, EventArgs e)
        {
            string error = "";
            bool fecha_correcta = true;
            bool continua = true;

            //txb_fecha_enturne.Visible = true;
            //txb_fecha_enturne.Text = dtp_enturne.Value.ToShortDateString() + " " + txb_hora_enturne.Text;

            try
            {
                _hours = int.Parse(txb_hora_enturne.Text.Substring(0, 2).ToString());
                if (_hours > 23)
                {
                    //MessageBox.Show("LA HORA INGRESADA NO CORRESPONDE AL FORMATO PERMITIDO (24)","HORA NO VALIDA",MessageBoxButtons.OK);
                    continua = false;
                    txb_hora_enturne.Text = "";
                }
                if (_hours < 0)
                {
                    //MessageBox.Show("LA HORA INGRESADA NO CORRESPONDE AL FORMATO PERMITIDO (24)", "HORA NO VALIDA", MessageBoxButtons.OK);
                    continua = false;
                    txb_hora_enturne.Text = "";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("LA HORA INGRESADA NO CORRESPONDE AL FORMATO PERMITIDO (24)","HORA NO VALIDA",MessageBoxButtons.OK);
                txb_hora_enturne.Text = "";
                continua = false;
            }
            try
            {
                _minute = int.Parse(txb_hora_enturne.Text.Substring(3, 2).ToString());
                if (_minute > 59)
                {
                    //MessageBox.Show("EL MINUTO INGRESADO NO CORRESPONDE AL FORMATO PERMITIDO (60)", "MINUTOS NO VALIDOS", MessageBoxButtons.OK);
                    txb_hora_enturne.Text = "";
                    continua = false;
                }
                if (_minute < 0)
                {
                    //MessageBox.Show("EL MINUTO INGRESADO NO CORRESPONDE AL FORMATO PERMITIDO (60)", "MINUTOS NO VALIDOS", MessageBoxButtons.OK);
                    txb_hora_enturne.Text = "";
                    continua = false;
                }
            }
            catch (Exception EX)
            {
                //MessageBox.Show("EL MINUTO INGRESADO NO CORRESPONDE AL FORMATO PERMITIDO (60)","MINUTOS NO VALIDOS",MessageBoxButtons.OK);
                continua = false;
            }
            if (continua)
            {

                txb_fecha_enturne.Visible = true;
                txb_fecha_enturne.Text = dtp_enturne.Value.ToShortDateString() + " " + txb_hora_enturne.Text;

                #region definicion de la fecha de enturne
                try
                {
                    _year = int.Parse(txb_fecha_enturne.Text.Substring(6, 4));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                try
                {
                    _mounth = int.Parse(txb_fecha_enturne.Text.Substring(3, 2));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                try
                {
                    _day = int.Parse(txb_fecha_enturne.Text.Substring(0, 2));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                try
                {
                    _hours = int.Parse(txb_fecha_enturne.Text.Substring(11, 2));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                try
                {
                    _minute = int.Parse(txb_fecha_enturne.Text.Substring(14, 2));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                if (fecha_correcta)
                {
                    dtp_enturne.Value = new DateTime(_year, _mounth, _day, _hours, _minute, _seconds);
                    txb_hora_enturne.Text = _hours.ToString() + ":" + _minute.ToString();
                    txb_fecha_enturne.Enabled = true;
                }
                else
                {
                    txb_fecha_enturne.Enabled = false;
                    txb_fecha_enturne.Visible = false;
                    dtp_enturne.Enabled = true;
                    txb_hora_enturne.Enabled = true;
                }
                #endregion definicion de la fecha de enturne
            }
            else
            {
                MessageBox.Show("LA HORA INGRESADA NO CORRESPONDE AL FORMATO PERMITIDO (24)", "HORA NO VALIDA", MessageBoxButtons.OK);
                txb_hora_enturne.Text = "";
                txb_hora_enturne.Focus();
            }
        }

        private void txb_fecha_ingreso_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txb_fecha_ingreso.Visible = false;
            dtp_ingreso.Enabled = true;
            dtp_ingreso.Visible = true;
            txb_hora_ingreso.Enabled = true;
            txb_hora_ingreso.Visible = true;
            txb_hora_ingreso.Focus();
        }

        private void txb_fecha_salicitud_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txb_fecha_salicitud.Visible = false;
            dtp_solicitud.Enabled = true;
            dtp_solicitud.Visible = true;
            txb_hora_solicitud.Enabled = true;
            txb_hora_solicitud.Visible = true;
            txb_hora_solicitud.Focus();
        }

        private void txb_fecha_salida_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txb_fecha_salida.Visible = false;
            dtp_salida.Enabled = true;
            dtp_salida.Visible = true;
            txb_hora_salida.Enabled = true;
            txb_hora_salida.Visible = true;
            txb_hora_salida.Focus();

        }

        private void cbx_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            _estado = "";
            string estado = cbx_estado.SelectedItem.ToString();
            switch (estado)
            {
                case "ENTURNADO":
                    {
                        fecha_enturne();
                        _estado="E";
                        
                        dtp_enturne.Enabled = false;
                        dtp_enturne.Visible = false;
                        txb_hora_enturne.Enabled = false;
                        txb_hora_enturne.Visible = false;
                        txb_fecha_enturne.Enabled = true;
                        txb_fecha_enturne.Visible = true;


                        dtp_solicitud.Enabled = false;
                        dtp_solicitud.Visible = true;
                        txb_hora_solicitud.Enabled = false;
                        txb_hora_solicitud.Visible = false;
                        txb_fecha_salicitud.Enabled = false;
                        txb_fecha_salicitud.Visible = false;

                        dtp_ingreso.Enabled = false;
                        dtp_ingreso.Visible = true;
                        txb_hora_ingreso.Enabled = false;
                        txb_hora_ingreso.Visible = false;
                        txb_fecha_ingreso.Enabled = false;
                        txb_fecha_ingreso.Visible = false;

                        dtp_salida.Enabled = false;
                        dtp_salida.Visible = true;
                        txb_hora_ingreso.Enabled = false;
                        txb_hora_ingreso.Visible = false;
                        txb_fecha_salida.Enabled = false;
                        txb_fecha_salida.Visible = false;
                        
                        break;
                    }
                case "SOLICITADO":
                    {
                        fecha_enturne();
                        fecha_solicitud();
                        _estado="S";

                        dtp_enturne.Enabled = false;
                        dtp_enturne.Visible = false;
                        txb_hora_enturne.Enabled = false;
                        txb_hora_enturne.Visible = false;
                        txb_fecha_enturne.Enabled = true;
                        txb_fecha_enturne.Visible = true;


                        dtp_solicitud.Enabled = false;
                        dtp_solicitud.Visible = false;
                        txb_hora_solicitud.Enabled = false;
                        txb_hora_solicitud.Visible = false;
                        txb_fecha_salicitud.Enabled = true;
                        txb_fecha_salicitud.Visible = true;

                        dtp_ingreso.Enabled = false;
                        dtp_ingreso.Visible = true;
                        txb_hora_ingreso.Enabled = false;
                        txb_hora_ingreso.Visible = false;
                        txb_fecha_ingreso.Enabled = false;
                        txb_fecha_ingreso.Visible = false;

                        dtp_salida.Enabled = false;
                        dtp_salida.Visible = true;
                        txb_hora_ingreso.Enabled = false;
                        txb_hora_ingreso.Visible = false;
                        txb_fecha_salida.Enabled = false;
                        txb_fecha_salida.Visible = false;
                        
                        break;
                    }
                case "INGRESADO":
                    {
                        fecha_enturne();
                        fecha_solicitud();
                        fecha_ingreso();
                        _estado = "I";

                        dtp_enturne.Enabled = false;
                        dtp_enturne.Visible = false;
                        txb_hora_enturne.Enabled = false;
                        txb_hora_enturne.Visible = false;
                        txb_fecha_enturne.Enabled = true;
                        txb_fecha_enturne.Visible = true;


                        dtp_solicitud.Enabled = false;
                        dtp_solicitud.Visible = false;
                        txb_hora_solicitud.Enabled = false;
                        txb_hora_solicitud.Visible = false;
                        txb_fecha_salicitud.Enabled = true;
                        txb_fecha_salicitud.Visible = true;

                        dtp_ingreso.Enabled = false;
                        dtp_ingreso.Visible = false;
                        txb_hora_ingreso.Enabled = false;
                        txb_hora_ingreso.Visible = false;
                        txb_fecha_ingreso.Enabled = true;
                        txb_fecha_ingreso.Visible = true;

                        dtp_salida.Enabled = false;
                        dtp_salida.Visible = true;
                        txb_hora_salida.Enabled = false;
                        txb_hora_salida.Visible = false;
                        txb_fecha_salida.Enabled = false;
                        txb_fecha_salida.Visible = false;
                        
                        break;
                    }
                case "ATENDIDO":
                    {
                        fecha_enturne();
                        fecha_solicitud();
                        fecha_ingreso();
                        fecha_salida();

                        _estado = "A";

                        dtp_enturne.Enabled = false;
                        dtp_enturne.Visible = false;
                        txb_hora_enturne.Enabled = false;
                        txb_hora_enturne.Visible = false;
                        txb_fecha_enturne.Enabled = true;
                        txb_fecha_enturne.Visible = true;


                        dtp_solicitud.Enabled = false;
                        dtp_solicitud.Visible = false;
                        txb_hora_solicitud.Enabled = false;
                        txb_hora_solicitud.Visible = false;
                        txb_fecha_salicitud.Enabled = true;
                        txb_fecha_salicitud.Visible = true;

                        dtp_ingreso.Enabled = false;
                        dtp_ingreso.Visible = false;
                        txb_hora_ingreso.Enabled = false;
                        txb_hora_ingreso.Visible = false;
                        txb_fecha_ingreso.Enabled = true;
                        txb_fecha_ingreso.Visible = true;

                        dtp_salida.Enabled = false;
                        dtp_salida.Visible = false;
                        txb_hora_salida.Enabled = false;
                        txb_hora_salida.Visible = false;
                        txb_fecha_salida.Enabled = true;
                        txb_fecha_salida.Visible = true;

                        break;
                    }
                case "ANULAR":
                    {
                        fecha_enturne();
                        fecha_solicitud();
                        fecha_ingreso();
                        fecha_salida();
                        _estado = "L";

                        dtp_enturne.Enabled = false;
                        dtp_enturne.Visible = false;
                        txb_hora_enturne.Enabled = false;
                        txb_hora_enturne.Visible = false;
                        txb_fecha_enturne.Enabled = true;
                        txb_fecha_enturne.Visible = true;


                        dtp_solicitud.Enabled = false;
                        dtp_solicitud.Visible = false;
                        txb_hora_solicitud.Enabled = false;
                        txb_hora_solicitud.Visible = false;
                        txb_fecha_salicitud.Enabled = true;
                        txb_fecha_salicitud.Visible = true;

                        dtp_ingreso.Enabled = false;
                        dtp_ingreso.Visible = false;
                        txb_hora_ingreso.Enabled = false;
                        txb_hora_ingreso.Visible = false;
                        txb_fecha_ingreso.Enabled = true;
                        txb_fecha_ingreso.Visible = true;

                        dtp_salida.Enabled = false;
                        dtp_salida.Visible = false;
                        txb_hora_salida.Enabled = false;
                        txb_hora_salida.Visible = false;
                        txb_fecha_salida.Enabled = true;
                        txb_fecha_salida.Visible = true;
                        
                        break;
                    }
                default:
                    {
                        _estado = "";
                        break;
                    }
                    
            }           
        }

        private bool validar_parametros()
        {
            bool valido = true;
            if (_secuencia<0)
            {
                valido = false;
                MessageBox.Show("No se ha seleccionado ningun registro","PARAMETROS INCOMPLETOS",MessageBoxButtons.OK);
            }
            if (_estado.Length<1)
            {
                valido = false;
                MessageBox.Show("No se ha seleccionado ningun estado", "PARAMETROS INCOMPLETOS", MessageBoxButtons.OK);
            }
            if (!validar_fechas(_estado))
            {
                valido = false;
                MessageBox.Show("Las fechas no se encuentran en orden cronologico", "INCONSISTENCIA EN LAS FECHAS INGRESADAS", MessageBoxButtons.OK);
            }
            return valido;
        }

        private bool validar_fechas(string estado)
        {
            bool valido = true;
            switch (estado)
            {
                case "E":
                    {
                        break;
                    }
                case "S":
                    {
                        if (dtp_solicitud.Value<dtp_enturne.Value)
                        {
                            valido = false;
                            break;
                        }
                        break;
                    }
                case "I":
                    {
                        if (dtp_solicitud.Value < dtp_enturne.Value)
                        {
                            valido = false;
                            break;
                        }
                        if (dtp_ingreso.Value<dtp_solicitud.Value)
                        {
                             valido = false;
                             break;
                        }
                        break;
                    }
                case "A":
                    {
                        if (dtp_solicitud.Value < dtp_enturne.Value)
                        {
                            valido = false;
                            break;
                        }
                        if (dtp_ingreso.Value < dtp_solicitud.Value)
                        {
                            valido = false;
                            break;
                        }
                        if (dtp_salida.Value < dtp_ingreso.Value)
                        {
                            valido = false;
                            break;
                        }
                        break;
                    }
                default:
                    break;
            }
            return valido;
        }
        private void txb_hora_solicitud_DoubleClick(object sender, EventArgs e)
        {
            string error = "";
            bool fecha_correcta = true;
            bool continua = true;
            
            //txb_fecha_salicitud.Visible = true;
            //txb_fecha_salicitud.Text = dtp_solicitud.Value.ToShortDateString() + " " + txb_hora_solicitud.Text;

            try
            {
                _hours = int.Parse(txb_hora_solicitud.Text.Substring(0, 2).ToString());
                if (_hours > 23)
                {
                    //MessageBox.Show("LA HORA INGRESADA NO CORRESPONDE AL FORMATO PERMITIDO (24)","HORA NO VALIDA",MessageBoxButtons.OK);
                    continua = false;
                    txb_hora_enturne.Text = "";
                }
                if (_hours < 0)
                {
                    //MessageBox.Show("LA HORA INGRESADA NO CORRESPONDE AL FORMATO PERMITIDO (24)", "HORA NO VALIDA", MessageBoxButtons.OK);
                    continua = false;
                    txb_hora_enturne.Text = "";
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("LA HORA INGRESADA NO CORRESPONDE AL FORMATO PERMITIDO (24)", "HORA NO VALIDA", MessageBoxButtons.OK);
                continua = false;
            }
            try
            {
                _minute = int.Parse(txb_hora_solicitud.Text.Substring(3, 2).ToString());
                if (_minute > 59)
                {
                    //MessageBox.Show("EL MINUTO INGRESADO NO CORRESPONDE AL FORMATO PERMITIDO (60)", "MINUTOS NO VALIDOS", MessageBoxButtons.OK);
                    txb_hora_enturne.Text = "";
                    continua = false;
                }
                if (_minute < 0)
                {
                    //MessageBox.Show("EL MINUTO INGRESADO NO CORRESPONDE AL FORMATO PERMITIDO (60)", "MINUTOS NO VALIDOS", MessageBoxButtons.OK);
                    txb_hora_enturne.Text = "";
                    continua = false;
                }
            }
            catch (Exception EX)
            {
                //MessageBox.Show("EL MINUTO INGRESADO NO CORRESPONDE AL FORMATO PERMITIDO (60)", "MINUTOS NO VALIDOS", MessageBoxButtons.OK);
                continua = false;
            }
            if (continua)
            {

                txb_fecha_salicitud.Visible = true;
                txb_fecha_salicitud.Text = dtp_solicitud.Value.ToShortDateString() + " " + txb_hora_solicitud.Text;
                #region definicion de la fecha de enturne
                try
                {
                    _year = int.Parse(txb_fecha_salicitud.Text.Substring(6, 4));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                try
                {
                    _mounth = int.Parse(txb_fecha_salicitud.Text.Substring(3, 2));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                try
                {
                    _day = int.Parse(txb_fecha_salicitud.Text.Substring(0, 2));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                try
                {
                    _hours = int.Parse(txb_fecha_salicitud.Text.Substring(11, 2));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                try
                {
                    _minute = int.Parse(txb_fecha_salicitud.Text.Substring(14, 2));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                if (fecha_correcta)
                {
                    dtp_solicitud.Value = new DateTime(_year, _mounth, _day, _hours, _minute, _seconds);
                    txb_hora_solicitud.Text = _hours.ToString() + ":" + _minute.ToString();
                    txb_fecha_salicitud.Enabled = true;
                }
                else
                {
                    txb_fecha_salicitud.Enabled = false;
                    txb_fecha_salicitud.Visible = false;
                    dtp_solicitud.Enabled = true;
                    txb_hora_solicitud.Enabled = true;
                }
                #endregion definicion de la fecha de enturne
            }
            else
            {
                MessageBox.Show("LA HORA INGRESADA NO CORRESPONDE AL FORMATO PERMITIDO (24)", "HORA NO VALIDA", MessageBoxButtons.OK);
                txb_hora_solicitud.Text = "";
                txb_hora_solicitud.Focus();

            }
        }

        private void txb_hora_salida_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string error = "";
            bool fecha_correcta = true;
            bool continua = true;

            //txb_fecha_salida.Visible = true;
            //txb_fecha_salida.Text = dtp_salida.Value.ToShortDateString() + " " + txb_hora_salida.Text;

            try
            {
                _hours = int.Parse(txb_hora_salida.Text.Substring(0, 2).ToString());
                if (_hours > 23)
                {
                    //MessageBox.Show("LA HORA INGRESADA NO CORRESPONDE AL FORMATO PERMITIDO (24)","HORA NO VALIDA",MessageBoxButtons.OK);
                    continua = false;
                    txb_hora_enturne.Text = "";
                }
                if (_hours < 0)
                {
                    //MessageBox.Show("LA HORA INGRESADA NO CORRESPONDE AL FORMATO PERMITIDO (24)", "HORA NO VALIDA", MessageBoxButtons.OK);
                    continua = false;
                    txb_hora_enturne.Text = "";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("LA HORA INGRESADA NO CORRESPONDE AL FORMATO PERMITIDO (24)", "HORA NO VALIDA", MessageBoxButtons.OK);
                continua = false;
            }
            try
            {
                _minute = int.Parse(txb_hora_salida.Text.Substring(3, 2).ToString());
                if (_minute > 59)
                {
                    //MessageBox.Show("EL MINUTO INGRESADO NO CORRESPONDE AL FORMATO PERMITIDO (60)", "MINUTOS NO VALIDOS", MessageBoxButtons.OK);
                    txb_hora_enturne.Text = "";
                    continua = false;
                }
                if (_minute < 0)
                {
                    //MessageBox.Show("EL MINUTO INGRESADO NO CORRESPONDE AL FORMATO PERMITIDO (60)", "MINUTOS NO VALIDOS", MessageBoxButtons.OK);
                    txb_hora_enturne.Text = "";
                    continua = false;
                }
            }
            catch (Exception EX)
            {
                //MessageBox.Show("EL MINUTO INGRESADO NO CORRESPONDE AL FORMATO PERMITIDO (60)", "MINUTOS NO VALIDOS", MessageBoxButtons.OK);
                continua = false;
            }
            if (continua)
            {
                txb_fecha_salida.Visible = true;
                txb_fecha_salida.Text = dtp_salida.Value.ToShortDateString() + " " + txb_hora_salida.Text;

                #region definicion de la fecha de enturne
                try
                {
                    _year = int.Parse(txb_fecha_salida.Text.Substring(6, 4));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                try
                {
                    _mounth = int.Parse(txb_fecha_salida.Text.Substring(3, 2));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                try
                {
                    _day = int.Parse(txb_fecha_salida.Text.Substring(0, 2));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                try
                {
                    _hours = int.Parse(txb_fecha_salida.Text.Substring(11, 2));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                try
                {
                    _minute = int.Parse(txb_fecha_salida.Text.Substring(14, 2));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                if (fecha_correcta)
                {
                    dtp_salida.Value = new DateTime(_year, _mounth, _day, _hours, _minute, _seconds);
                    txb_hora_salida.Text = _hours.ToString() + ":" + _minute.ToString();
                    txb_fecha_salida.Enabled = true;
                }
                else
                {
                    txb_fecha_salida.Enabled = false;
                    txb_fecha_salida.Visible = false;
                    dtp_salida.Enabled = true;
                    txb_hora_salida.Enabled = true;
                }
                #endregion definicion de la fecha de enturne
            }
            else
            {
                MessageBox.Show("LA HORA INGRESADA NO CORRESPONDE AL FORMATO PERMITIDO (24)", "HORA NO VALIDA", MessageBoxButtons.OK);
                txb_hora_salida.Text = "";
                txb_hora_salida.Focus();
            }
        }

        private void txb_hora_ingreso_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string error = "";
            bool fecha_correcta = true;
            bool continua = true;

            //txb_fecha_ingreso.Visible = true;
            //txb_fecha_ingreso.Text = dtp_ingreso.Value.ToShortDateString() + " " + txb_hora_ingreso.Text;

            try
            {
                _hours = int.Parse(txb_hora_ingreso.Text.Substring(0, 2).ToString());
                if (_hours > 23)
                {
                    //MessageBox.Show("LA HORA INGRESADA NO CORRESPONDE AL FORMATO PERMITIDO (24)","HORA NO VALIDA",MessageBoxButtons.OK);
                    continua = false;
                    txb_hora_enturne.Text = "";
                }
                if (_hours < 0)
                {
                    //MessageBox.Show("LA HORA INGRESADA NO CORRESPONDE AL FORMATO PERMITIDO (24)", "HORA NO VALIDA", MessageBoxButtons.OK);
                    continua = false;
                    txb_hora_enturne.Text = "";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("LA HORA INGRESADA NO CORRESPONDE AL FORMATO PERMITIDO (24)", "HORA NO VALIDA", MessageBoxButtons.OK);
                continua = false;
            }
            try
            {
                _minute = int.Parse(txb_hora_ingreso.Text.Substring(3, 2).ToString());
                if (_minute > 59)
                {
                    //MessageBox.Show("EL MINUTO INGRESADO NO CORRESPONDE AL FORMATO PERMITIDO (60)", "MINUTOS NO VALIDOS", MessageBoxButtons.OK);
                    txb_hora_enturne.Text = "";
                    continua = false;
                }
                if (_minute < 0)
                {
                    //MessageBox.Show("EL MINUTO INGRESADO NO CORRESPONDE AL FORMATO PERMITIDO (60)", "MINUTOS NO VALIDOS", MessageBoxButtons.OK);
                    txb_hora_enturne.Text = "";
                    continua = false;
                }
            }
            catch (Exception EX)
            {
                //MessageBox.Show("EL MINUTO INGRESADO NO CORRESPONDE AL FORMATO PERMITIDO (60)", "MINUTOS NO VALIDOS", MessageBoxButtons.OK);
                continua = false;
            }
            if (continua)
            {
                txb_fecha_ingreso.Visible = true;
                txb_fecha_ingreso.Text = dtp_ingreso.Value.ToShortDateString() + " " + txb_hora_ingreso.Text;

                #region definicion de la fecha de enturne
                try
                {
                    _year = int.Parse(txb_fecha_ingreso.Text.Substring(6, 4));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                try
                {
                    _mounth = int.Parse(txb_fecha_ingreso.Text.Substring(3, 2));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                try
                {
                    _day = int.Parse(txb_fecha_ingreso.Text.Substring(0, 2));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                try
                {
                    _hours = int.Parse(txb_fecha_ingreso.Text.Substring(11, 2));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                try
                {
                    _minute = int.Parse(txb_fecha_ingreso.Text.Substring(14, 2));
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    fecha_correcta = false;
                }
                if (fecha_correcta)
                {
                    dtp_ingreso.Value = new DateTime(_year, _mounth, _day, _hours, _minute, _seconds);
                    txb_hora_ingreso.Text = _hours.ToString() + ":" + _minute.ToString();
                    txb_fecha_ingreso.Enabled = true;
                }
                else
                {
                    txb_fecha_ingreso.Enabled = false;
                    txb_fecha_ingreso.Visible = false;
                    dtp_ingreso.Enabled = true;
                    txb_hora_ingreso.Enabled = true;
                }
                #endregion definicion de la fecha de enturne
            }
            else
            {
                MessageBox.Show("LA HORA INGRESADA NO CORRESPONDE AL FORMATO PERMITIDO (24)", "HORA NO VALIDA", MessageBoxButtons.OK);
                txb_hora_ingreso.Text = "";
                txb_hora_ingreso.Focus();
            }

        }

        private void dgv_solicitar_turno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
