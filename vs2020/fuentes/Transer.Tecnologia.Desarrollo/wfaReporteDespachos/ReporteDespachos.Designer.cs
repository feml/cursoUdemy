namespace wfaReporteDespachos
{
    partial class ReporteDespachos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxInfoPlanilla = new System.Windows.Forms.CheckBox();
            this.cbxInfoAnticipos = new System.Windows.Forms.CheckBox();
            this.cbxInfoFactura = new System.Windows.Forms.CheckBox();
            this.cbxInfoFletes = new System.Windows.Forms.CheckBox();
            this.cbxInfoPlantas = new System.Windows.Forms.CheckBox();
            this.cbxInfoPropietario = new System.Windows.Forms.CheckBox();
            this.cbxInfoClienteNegocio = new System.Windows.Forms.CheckBox();
            this.cbxInfoRuta = new System.Windows.Forms.CheckBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.cbxOficina = new System.Windows.Forms.ComboBox();
            this.dtpFecFin = new System.Windows.Forms.DateTimePicker();
            this.lblOficina = new System.Windows.Forms.Label();
            this.dtpFecIni = new System.Windows.Forms.DateTimePicker();
            this.lblFecIni = new System.Windows.Forms.Label();
            this.lblFecFin = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvConsulta = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.cbxOficina);
            this.panel1.Controls.Add(this.dtpFecFin);
            this.panel1.Controls.Add(this.lblOficina);
            this.panel1.Controls.Add(this.dtpFecIni);
            this.panel1.Controls.Add(this.lblFecIni);
            this.panel1.Controls.Add(this.lblFecFin);
            this.panel1.Location = new System.Drawing.Point(10, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1043, 119);
            this.panel1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxInfoPlanilla);
            this.groupBox1.Controls.Add(this.cbxInfoAnticipos);
            this.groupBox1.Controls.Add(this.cbxInfoFactura);
            this.groupBox1.Controls.Add(this.cbxInfoFletes);
            this.groupBox1.Controls.Add(this.cbxInfoPlantas);
            this.groupBox1.Controls.Add(this.cbxInfoPropietario);
            this.groupBox1.Controls.Add(this.cbxInfoClienteNegocio);
            this.groupBox1.Controls.Add(this.cbxInfoRuta);
            this.groupBox1.Location = new System.Drawing.Point(139, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 62);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros Consulta";
            // 
            // cbxInfoPlanilla
            // 
            this.cbxInfoPlanilla.AutoSize = true;
            this.cbxInfoPlanilla.Checked = true;
            this.cbxInfoPlanilla.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxInfoPlanilla.Location = new System.Drawing.Point(76, 23);
            this.cbxInfoPlanilla.Name = "cbxInfoPlanilla";
            this.cbxInfoPlanilla.Size = new System.Drawing.Size(59, 17);
            this.cbxInfoPlanilla.TabIndex = 1;
            this.cbxInfoPlanilla.Text = "Planilla";
            this.cbxInfoPlanilla.UseVisualStyleBackColor = true;
            // 
            // cbxInfoAnticipos
            // 
            this.cbxInfoAnticipos.AutoSize = true;
            this.cbxInfoAnticipos.Checked = true;
            this.cbxInfoAnticipos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxInfoAnticipos.Location = new System.Drawing.Point(196, 23);
            this.cbxInfoAnticipos.Name = "cbxInfoAnticipos";
            this.cbxInfoAnticipos.Size = new System.Drawing.Size(69, 17);
            this.cbxInfoAnticipos.TabIndex = 3;
            this.cbxInfoAnticipos.Text = "Anticipos";
            this.cbxInfoAnticipos.UseVisualStyleBackColor = true;
            // 
            // cbxInfoFactura
            // 
            this.cbxInfoFactura.AutoSize = true;
            this.cbxInfoFactura.Checked = true;
            this.cbxInfoFactura.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxInfoFactura.Location = new System.Drawing.Point(328, 23);
            this.cbxInfoFactura.Name = "cbxInfoFactura";
            this.cbxInfoFactura.Size = new System.Drawing.Size(62, 17);
            this.cbxInfoFactura.TabIndex = 3;
            this.cbxInfoFactura.Text = "Factura";
            this.cbxInfoFactura.UseVisualStyleBackColor = true;
            // 
            // cbxInfoFletes
            // 
            this.cbxInfoFletes.AutoSize = true;
            this.cbxInfoFletes.Checked = true;
            this.cbxInfoFletes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxInfoFletes.Location = new System.Drawing.Point(268, 23);
            this.cbxInfoFletes.Name = "cbxInfoFletes";
            this.cbxInfoFletes.Size = new System.Drawing.Size(54, 17);
            this.cbxInfoFletes.TabIndex = 3;
            this.cbxInfoFletes.Text = "Fletes";
            this.cbxInfoFletes.UseVisualStyleBackColor = true;
            // 
            // cbxInfoPlantas
            // 
            this.cbxInfoPlantas.AutoSize = true;
            this.cbxInfoPlantas.Location = new System.Drawing.Point(588, 23);
            this.cbxInfoPlantas.Name = "cbxInfoPlantas";
            this.cbxInfoPlantas.Size = new System.Drawing.Size(61, 17);
            this.cbxInfoPlantas.TabIndex = 3;
            this.cbxInfoPlantas.Text = "Plantas";
            this.cbxInfoPlantas.UseVisualStyleBackColor = true;
            // 
            // cbxInfoPropietario
            // 
            this.cbxInfoPropietario.AutoSize = true;
            this.cbxInfoPropietario.Location = new System.Drawing.Point(398, 23);
            this.cbxInfoPropietario.Name = "cbxInfoPropietario";
            this.cbxInfoPropietario.Size = new System.Drawing.Size(76, 17);
            this.cbxInfoPropietario.TabIndex = 7;
            this.cbxInfoPropietario.Text = "Propietario";
            this.cbxInfoPropietario.UseVisualStyleBackColor = true;
            // 
            // cbxInfoClienteNegocio
            // 
            this.cbxInfoClienteNegocio.AutoSize = true;
            this.cbxInfoClienteNegocio.Location = new System.Drawing.Point(480, 23);
            this.cbxInfoClienteNegocio.Name = "cbxInfoClienteNegocio";
            this.cbxInfoClienteNegocio.Size = new System.Drawing.Size(101, 17);
            this.cbxInfoClienteNegocio.TabIndex = 4;
            this.cbxInfoClienteNegocio.Text = "Cliente Negocio";
            this.cbxInfoClienteNegocio.UseVisualStyleBackColor = true;
            // 
            // cbxInfoRuta
            // 
            this.cbxInfoRuta.AutoSize = true;
            this.cbxInfoRuta.Checked = true;
            this.cbxInfoRuta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxInfoRuta.Location = new System.Drawing.Point(141, 23);
            this.cbxInfoRuta.Name = "cbxInfoRuta";
            this.cbxInfoRuta.Size = new System.Drawing.Size(49, 17);
            this.cbxInfoRuta.TabIndex = 1;
            this.cbxInfoRuta.Text = "Ruta";
            this.cbxInfoRuta.UseVisualStyleBackColor = true;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(802, 69);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(98, 26);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Consulta";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cbxOficina
            // 
            this.cbxOficina.FormattingEnabled = true;
            this.cbxOficina.Location = new System.Drawing.Point(165, 7);
            this.cbxOficina.Name = "cbxOficina";
            this.cbxOficina.Size = new System.Drawing.Size(171, 21);
            this.cbxOficina.TabIndex = 2;
            this.cbxOficina.SelectedIndexChanged += new System.EventHandler(this.cbxOficina_SelectedIndexChanged);
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Location = new System.Drawing.Point(722, 7);
            this.dtpFecFin.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dtpFecFin.MinDate = new System.DateTime(2006, 5, 1, 0, 0, 0, 0);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFecFin.TabIndex = 3;
            this.dtpFecFin.ValueChanged += new System.EventHandler(this.dtpFecFin_ValueChanged);
            // 
            // lblOficina
            // 
            this.lblOficina.AutoSize = true;
            this.lblOficina.Location = new System.Drawing.Point(116, 11);
            this.lblOficina.Name = "lblOficina";
            this.lblOficina.Size = new System.Drawing.Size(43, 13);
            this.lblOficina.TabIndex = 1;
            this.lblOficina.Text = "Oficina:";
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Location = new System.Drawing.Point(436, 7);
            this.dtpFecIni.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dtpFecIni.MinDate = new System.DateTime(2006, 5, 1, 0, 0, 0, 0);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(200, 20);
            this.dtpFecIni.TabIndex = 3;
            this.dtpFecIni.ValueChanged += new System.EventHandler(this.dtpFecIni_ValueChanged);
            // 
            // lblFecIni
            // 
            this.lblFecIni.AutoSize = true;
            this.lblFecIni.Location = new System.Drawing.Point(359, 11);
            this.lblFecIni.Name = "lblFecIni";
            this.lblFecIni.Size = new System.Drawing.Size(70, 13);
            this.lblFecIni.TabIndex = 1;
            this.lblFecIni.Text = "Fecha Inicial:";
            // 
            // lblFecFin
            // 
            this.lblFecFin.AutoSize = true;
            this.lblFecFin.Location = new System.Drawing.Point(651, 11);
            this.lblFecFin.Name = "lblFecFin";
            this.lblFecFin.Size = new System.Drawing.Size(65, 13);
            this.lblFecFin.TabIndex = 1;
            this.lblFecFin.Text = "Fecha Final:";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.dgvConsulta);
            this.panel4.Location = new System.Drawing.Point(8, 226);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1047, 399);
            this.panel4.TabIndex = 8;
            // 
            // dgvConsulta
            // 
            this.dgvConsulta.AllowUserToOrderColumns = true;
            this.dgvConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvConsulta.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvConsulta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConsulta.Location = new System.Drawing.Point(0, 0);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.Size = new System.Drawing.Size(1043, 395);
            this.dgvConsulta.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(8, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1047, 100);
            this.panel2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(315, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "MONITOREO DESPACHOS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(399, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "TABLERO DE CONTROL";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::wfaReporteDespachos.Properties.Resources.Logo_transer;
            this.pictureBox1.Location = new System.Drawing.Point(821, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(219, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ReporteDespachos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 629);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "ReporteDespachos";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ReporteDespachos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbxInfoPlanilla;
        private System.Windows.Forms.CheckBox cbxInfoAnticipos;
        private System.Windows.Forms.CheckBox cbxInfoFactura;
        private System.Windows.Forms.CheckBox cbxInfoFletes;
        private System.Windows.Forms.CheckBox cbxInfoPlantas;
        private System.Windows.Forms.CheckBox cbxInfoPropietario;
        private System.Windows.Forms.CheckBox cbxInfoClienteNegocio;
        private System.Windows.Forms.CheckBox cbxInfoRuta;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.ComboBox cbxOficina;
        private System.Windows.Forms.DateTimePicker dtpFecFin;
        private System.Windows.Forms.Label lblOficina;
        private System.Windows.Forms.DateTimePicker dtpFecIni;
        private System.Windows.Forms.Label lblFecIni;
        private System.Windows.Forms.Label lblFecFin;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvConsulta;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

