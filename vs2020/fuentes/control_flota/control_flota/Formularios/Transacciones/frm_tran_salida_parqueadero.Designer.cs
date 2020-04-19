namespace control_flota.Formularios.Transacciones
{
    partial class frm_tran_salida_parqueadero
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_informativo = new System.Windows.Forms.Panel();
            this.lblTituloUsuarioConectado = new System.Windows.Forms.Label();
            this.lblUsuarioConectado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_version_forma = new System.Windows.Forms.Label();
            this.pnl_acciones = new System.Windows.Forms.Panel();
            this.lbl_total_enturnados = new System.Windows.Forms.Label();
            this.btn_registrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_solicitar_turno = new System.Windows.Forms.DataGridView();
            this.lbl_consulta = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cbx_trailer = new System.Windows.Forms.ComboBox();
            this.lbl_trailer = new System.Windows.Forms.Label();
            this.cbx_vehiculo = new System.Windows.Forms.ComboBox();
            this.lbl_vehiculo = new System.Windows.Forms.Label();
            this.cbx_conductor = new System.Windows.Forms.ComboBox();
            this.lbl_conductor = new System.Windows.Forms.Label();
            this.pnl_titulo = new System.Windows.Forms.Panel();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.pnl_informativo.SuspendLayout();
            this.pnl_acciones.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_solicitar_turno)).BeginInit();
            this.pnl_titulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_informativo
            // 
            this.pnl_informativo.Controls.Add(this.lblTituloUsuarioConectado);
            this.pnl_informativo.Controls.Add(this.lblUsuarioConectado);
            this.pnl_informativo.Controls.Add(this.label1);
            this.pnl_informativo.Controls.Add(this.lbl_version_forma);
            this.pnl_informativo.Location = new System.Drawing.Point(4, 886);
            this.pnl_informativo.Name = "pnl_informativo";
            this.pnl_informativo.Size = new System.Drawing.Size(1207, 22);
            this.pnl_informativo.TabIndex = 16;
            this.pnl_informativo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_informativo_Paint);
            // 
            // lblTituloUsuarioConectado
            // 
            this.lblTituloUsuarioConectado.AutoSize = true;
            this.lblTituloUsuarioConectado.Location = new System.Drawing.Point(517, 5);
            this.lblTituloUsuarioConectado.Name = "lblTituloUsuarioConectado";
            this.lblTituloUsuarioConectado.Size = new System.Drawing.Size(107, 13);
            this.lblTituloUsuarioConectado.TabIndex = 2;
            this.lblTituloUsuarioConectado.Text = "Usuario Conectado : ";
            // 
            // lblUsuarioConectado
            // 
            this.lblUsuarioConectado.AutoSize = true;
            this.lblUsuarioConectado.Location = new System.Drawing.Point(622, 5);
            this.lblUsuarioConectado.Name = "lblUsuarioConectado";
            this.lblUsuarioConectado.Size = new System.Drawing.Size(67, 13);
            this.lblUsuarioConectado.TabIndex = 3;
            this.lblUsuarioConectado.Text = "FMONTOYA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dpto de Sistemas";
            // 
            // lbl_version_forma
            // 
            this.lbl_version_forma.AutoSize = true;
            this.lbl_version_forma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_version_forma.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_version_forma.Location = new System.Drawing.Point(1091, 6);
            this.lbl_version_forma.Name = "lbl_version_forma";
            this.lbl_version_forma.Size = new System.Drawing.Size(113, 13);
            this.lbl_version_forma.TabIndex = 0;
            this.lbl_version_forma.Text = "v.1.1.10122014.64bits";
            // 
            // pnl_acciones
            // 
            this.pnl_acciones.Controls.Add(this.lbl_total_enturnados);
            this.pnl_acciones.Controls.Add(this.btn_registrar);
            this.pnl_acciones.Controls.Add(this.label2);
            this.pnl_acciones.Controls.Add(this.panel1);
            this.pnl_acciones.Controls.Add(this.lbl_consulta);
            this.pnl_acciones.Controls.Add(this.button2);
            this.pnl_acciones.Controls.Add(this.cbx_trailer);
            this.pnl_acciones.Controls.Add(this.lbl_trailer);
            this.pnl_acciones.Controls.Add(this.cbx_vehiculo);
            this.pnl_acciones.Controls.Add(this.lbl_vehiculo);
            this.pnl_acciones.Controls.Add(this.cbx_conductor);
            this.pnl_acciones.Controls.Add(this.lbl_conductor);
            this.pnl_acciones.Location = new System.Drawing.Point(4, 67);
            this.pnl_acciones.Name = "pnl_acciones";
            this.pnl_acciones.Size = new System.Drawing.Size(1207, 813);
            this.pnl_acciones.TabIndex = 15;
            // 
            // lbl_total_enturnados
            // 
            this.lbl_total_enturnados.AutoSize = true;
            this.lbl_total_enturnados.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_enturnados.Location = new System.Drawing.Point(742, 177);
            this.lbl_total_enturnados.Name = "lbl_total_enturnados";
            this.lbl_total_enturnados.Size = new System.Drawing.Size(21, 22);
            this.lbl_total_enturnados.TabIndex = 7;
            this.lbl_total_enturnados.Text = "0";
            // 
            // btn_registrar
            // 
            this.btn_registrar.Enabled = false;
            this.btn_registrar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_registrar.Location = new System.Drawing.Point(413, 113);
            this.btn_registrar.Name = "btn_registrar";
            this.btn_registrar.Size = new System.Drawing.Size(381, 35);
            this.btn_registrar.TabIndex = 2;
            this.btn_registrar.Text = "SALIDA PARQUEADERO";
            this.btn_registrar.UseVisualStyleBackColor = true;
            this.btn_registrar.Click += new System.EventHandler(this.btn_registrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(431, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "VEHICULOS EN PARQUEADERO";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_solicitar_turno);
            this.panel1.Location = new System.Drawing.Point(34, 206);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1139, 527);
            this.panel1.TabIndex = 5;
            // 
            // dgv_solicitar_turno
            // 
            this.dgv_solicitar_turno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_solicitar_turno.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_solicitar_turno.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_solicitar_turno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_solicitar_turno.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgv_solicitar_turno.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgv_solicitar_turno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_solicitar_turno.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_solicitar_turno.Location = new System.Drawing.Point(6, 26);
            this.dgv_solicitar_turno.Name = "dgv_solicitar_turno";
            this.dgv_solicitar_turno.Size = new System.Drawing.Size(1126, 474);
            this.dgv_solicitar_turno.TabIndex = 0;
            this.dgv_solicitar_turno.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_solicitar_turno_ColumnHeaderMouseClick);
            // 
            // lbl_consulta
            // 
            this.lbl_consulta.AutoSize = true;
            this.lbl_consulta.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_consulta.Location = new System.Drawing.Point(341, 210);
            this.lbl_consulta.Name = "lbl_consulta";
            this.lbl_consulta.Size = new System.Drawing.Size(524, 22);
            this.lbl_consulta.TabIndex = 3;
            this.lbl_consulta.Text = "VEHICULOS SOLICITADOS PARA INGRESAR AL TALLER";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(507, 765);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(193, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "CONTROL DE FLOTA";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbx_trailer
            // 
            this.cbx_trailer.Enabled = false;
            this.cbx_trailer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_trailer.FormattingEnabled = true;
            this.cbx_trailer.Location = new System.Drawing.Point(861, 55);
            this.cbx_trailer.Name = "cbx_trailer";
            this.cbx_trailer.Size = new System.Drawing.Size(155, 33);
            this.cbx_trailer.TabIndex = 1;
            this.cbx_trailer.SelectedIndexChanged += new System.EventHandler(this.cbx_trailer_SelectedIndexChanged);
            // 
            // lbl_trailer
            // 
            this.lbl_trailer.AutoSize = true;
            this.lbl_trailer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_trailer.Location = new System.Drawing.Point(917, 31);
            this.lbl_trailer.Name = "lbl_trailer";
            this.lbl_trailer.Size = new System.Drawing.Size(43, 16);
            this.lbl_trailer.TabIndex = 0;
            this.lbl_trailer.Text = "Trailer";
            // 
            // cbx_vehiculo
            // 
            this.cbx_vehiculo.Enabled = false;
            this.cbx_vehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_vehiculo.FormattingEnabled = true;
            this.cbx_vehiculo.Location = new System.Drawing.Point(671, 55);
            this.cbx_vehiculo.Name = "cbx_vehiculo";
            this.cbx_vehiculo.Size = new System.Drawing.Size(155, 33);
            this.cbx_vehiculo.TabIndex = 1;
            this.cbx_vehiculo.SelectedIndexChanged += new System.EventHandler(this.cbx_vehiculo_SelectedIndexChanged);
            // 
            // lbl_vehiculo
            // 
            this.lbl_vehiculo.AutoSize = true;
            this.lbl_vehiculo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_vehiculo.Location = new System.Drawing.Point(720, 33);
            this.lbl_vehiculo.Name = "lbl_vehiculo";
            this.lbl_vehiculo.Size = new System.Drawing.Size(57, 16);
            this.lbl_vehiculo.TabIndex = 0;
            this.lbl_vehiculo.Text = "Vehiculo";
            // 
            // cbx_conductor
            // 
            this.cbx_conductor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_conductor.FormattingEnabled = true;
            this.cbx_conductor.Location = new System.Drawing.Point(190, 55);
            this.cbx_conductor.Name = "cbx_conductor";
            this.cbx_conductor.Size = new System.Drawing.Size(441, 33);
            this.cbx_conductor.TabIndex = 1;
            this.cbx_conductor.SelectedIndexChanged += new System.EventHandler(this.cbx_conductor_SelectedIndexChanged);
            // 
            // lbl_conductor
            // 
            this.lbl_conductor.AutoSize = true;
            this.lbl_conductor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_conductor.Location = new System.Drawing.Point(377, 33);
            this.lbl_conductor.Name = "lbl_conductor";
            this.lbl_conductor.Size = new System.Drawing.Size(67, 16);
            this.lbl_conductor.TabIndex = 0;
            this.lbl_conductor.Text = "Conductor";
            // 
            // pnl_titulo
            // 
            this.pnl_titulo.Controls.Add(this.lbl_titulo);
            this.pnl_titulo.Location = new System.Drawing.Point(4, 2);
            this.pnl_titulo.Name = "pnl_titulo";
            this.pnl_titulo.Size = new System.Drawing.Size(1207, 59);
            this.pnl_titulo.TabIndex = 14;
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.Location = new System.Drawing.Point(489, 19);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(345, 33);
            this.lbl_titulo.TabIndex = 0;
            this.lbl_titulo.Text = "SALIDA PARQUEADERO";
            // 
            // frm_tran_salida_parqueadero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 910);
            this.Controls.Add(this.pnl_informativo);
            this.Controls.Add(this.pnl_acciones);
            this.Controls.Add(this.pnl_titulo);
            this.Name = "frm_tran_salida_parqueadero";
            this.Text = "frm_tran_salida_parqueadero";
            this.Load += new System.EventHandler(this.frm_tran_salida_parqueadero_Load);
            this.pnl_informativo.ResumeLayout(false);
            this.pnl_informativo.PerformLayout();
            this.pnl_acciones.ResumeLayout(false);
            this.pnl_acciones.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_solicitar_turno)).EndInit();
            this.pnl_titulo.ResumeLayout(false);
            this.pnl_titulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_informativo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_version_forma;
        private System.Windows.Forms.Panel pnl_acciones;
        private System.Windows.Forms.Label lbl_total_enturnados;
        private System.Windows.Forms.Button btn_registrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_solicitar_turno;
        private System.Windows.Forms.Label lbl_consulta;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbx_trailer;
        private System.Windows.Forms.Label lbl_trailer;
        private System.Windows.Forms.ComboBox cbx_vehiculo;
        private System.Windows.Forms.Label lbl_vehiculo;
        private System.Windows.Forms.ComboBox cbx_conductor;
        private System.Windows.Forms.Label lbl_conductor;
        private System.Windows.Forms.Panel pnl_titulo;
        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.Label lblTituloUsuarioConectado;
        private System.Windows.Forms.Label lblUsuarioConectado;
    }
}