﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace control_flota.Formularios.Consultas
{
    public partial class frm_cons_taller : Form
    {
        private Control_flota.Interfaces.I_cont_control_flota _negocio;
        private DataSet _ds;

        public frm_cons_taller(string usuario, string password, string cadena)
        {
            InitializeComponent();
            lblUsuarioConectado.Text = usuario;
            _negocio = new Control_flota.Clases.C_cont_control_flota(usuario, password, cadena);
            _ds = new DataSet();

        }

        private void frm_cons_taller_Load(object sender, EventArgs e)
        {
            cargar_consulta();
        }

        private void cargar_consulta()
        {
            _ds = _negocio.consulta_vehiculos_taller();
            lbl_total_enturnados.Text = _ds.Tables[0].Rows.Count.ToString();
            DataView dw = new DataView(_ds.Tables[0]);
            dgv_consulta.DataSource = dw;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
