﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace control_flota.Formularios.Transacciones
{
    public partial class frm_tran_salida_taller : Form
    {
        Interfaces.I_tran_salida_taller _negocio;
        private string _cedula;
        private string _vehiculo;
        private string _trailer;
        private DataSet _ds;

        public frm_tran_salida_taller(string usuario, string password, string cadena)
        {
            InitializeComponent();
            lblUsuarioConectado.Text = usuario;
            _negocio = new Clases.C_tran_salida_taller(usuario, password, cadena);
            _ds = new DataSet();

        }

        private void frm_tran_salida_taller_Load(object sender, EventArgs e)
        {
            _vehiculo = "ZZZZZZ";
            _trailer = "ZZZZZZ";
            _ds = _negocio.combobox_conductores();
            foreach (DataRow dr in _ds.Tables["CONSULTA"].Rows)
            {
                cbx_conductor.Items.Add(dr[1].ToString());
            }
            cargar_consulta();

        }

        private void cargar_consulta()
        {
            _ds = _negocio.generar_reporte();
            lbl_total_enturnados.Text = _ds.Tables[0].Rows.Count.ToString();
            DataView dw = new DataView(_ds.Tables[0]);
            dgv_solicitar_turno.DataSource = dw;
        }


        private void cbx_conductor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ds = _negocio.combobox_conductores();
            foreach (DataRow dr in _ds.Tables["CONSULTA"].Rows)
            {
                if (cbx_conductor.SelectedItem.ToString() == dr[1].ToString())
                {
                    _cedula = dr[0].ToString();
                    break;
                }
            }

            if (_cedula.Length>3)
            {
                cbx_vehiculo.Items.Clear();
                _ds = _negocio.combobox_vehiculos(_cedula);
                foreach (DataRow dr in _ds.Tables["CONSULTA"].Rows)
                {
                    cbx_vehiculo.Items.Add(dr[0].ToString());
                    cbx_vehiculo.Enabled = true;
                }
                cbx_trailer.Items.Clear();
                _ds = _negocio.combobox_trailers(_cedula);
                foreach (DataRow dr in _ds.Tables["CONSULTA"].Rows)
                {
                    cbx_trailer.Items.Add(dr[0].ToString());
                    cbx_trailer.Enabled = true;
                }
                btn_registrar.Enabled = true;
            }
            else
            {
                MessageBox.Show("El conductor seleccionado no tiene vehiculos ni trailers en el taller", "INCONSISTENCIA, EL CONDUCTOR SELECCIONADO NO TIENE VEHICULOS REGISTRADOS EN TALLER", MessageBoxButtons.OK);
            }
        }

        private void cbx_vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _vehiculo = cbx_vehiculo.SelectedItem.ToString();
            btn_registrar.Enabled = true;

        }

        private void cbx_trailer_SelectedIndexChanged(object sender, EventArgs e)
        {
            _trailer = cbx_trailer.SelectedItem.ToString();
            btn_registrar.Enabled = true;
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            _negocio.registrar_transaccion(_cedula, _vehiculo, _trailer,lblUsuarioConectado.Text);
            cargar_consulta();
            cbx_conductor.Items.Clear();
            cbx_vehiculo.Items.Clear();
            cbx_vehiculo.Enabled = false;
            cbx_trailer.Items.Clear();
            cbx_trailer.Enabled = false;
            _vehiculo = "ZZZZZZ";
            _trailer = "ZZZZZZ";
            /*_ds = _negocio.combobox_conductores();
            foreach (DataRow dr in _ds.Tables["CONSULTA"].Rows)
            {
                cbx_conductor.Items.Add(dr[1].ToString() + " " + dr[2].ToString());
            }*/
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_solicitar_turno_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string titulo_columna = dgv_solicitar_turno.Columns[e.ColumnIndex].HeaderText;
        }
    }
}
