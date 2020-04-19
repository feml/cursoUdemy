namespace control_flota.Formularios.Consultas
{
    partial class frm_cons_reparacion_externa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_informativo = new System.Windows.Forms.Panel();
            this.lblTituloUsuarioConectado = new System.Windows.Forms.Label();
            this.lblUsuarioConectado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_version_forma = new System.Windows.Forms.Label();
            this.pnl_acciones = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_consulta = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.pnl_titulo = new System.Windows.Forms.Panel();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.lbl_total_enturnados = new System.Windows.Forms.Label();
            this.pnl_informativo.SuspendLayout();
            this.pnl_acciones.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consulta)).BeginInit();
            this.pnl_titulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_informativo
            // 
            this.pnl_informativo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_informativo.Controls.Add(this.lblTituloUsuarioConectado);
            this.pnl_informativo.Controls.Add(this.lblUsuarioConectado);
            this.pnl_informativo.Controls.Add(this.label1);
            this.pnl_informativo.Controls.Add(this.lbl_version_forma);
            this.pnl_informativo.Location = new System.Drawing.Point(4, 886);
            this.pnl_informativo.Name = "pnl_informativo";
            this.pnl_informativo.Size = new System.Drawing.Size(1207, 22);
            this.pnl_informativo.TabIndex = 22;
            // 
            // lblTituloUsuarioConectado
            // 
            this.lblTituloUsuarioConectado.AutoSize = true;
            this.lblTituloUsuarioConectado.Location = new System.Drawing.Point(515, 3);
            this.lblTituloUsuarioConectado.Name = "lblTituloUsuarioConectado";
            this.lblTituloUsuarioConectado.Size = new System.Drawing.Size(107, 13);
            this.lblTituloUsuarioConectado.TabIndex = 2;
            this.lblTituloUsuarioConectado.Text = "Usuario Conectado : ";
            // 
            // lblUsuarioConectado
            // 
            this.lblUsuarioConectado.AutoSize = true;
            this.lblUsuarioConectado.Location = new System.Drawing.Point(620, 3);
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
            this.lbl_version_forma.Location = new System.Drawing.Point(1082, 5);
            this.lbl_version_forma.Name = "lbl_version_forma";
            this.lbl_version_forma.Size = new System.Drawing.Size(113, 13);
            this.lbl_version_forma.TabIndex = 0;
            this.lbl_version_forma.Text = "v.1.1.10122014.64bits";
            // 
            // pnl_acciones
            // 
            this.pnl_acciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_acciones.Controls.Add(this.panel1);
            this.pnl_acciones.Controls.Add(this.button2);
            this.pnl_acciones.Location = new System.Drawing.Point(4, 67);
            this.pnl_acciones.Name = "pnl_acciones";
            this.pnl_acciones.Size = new System.Drawing.Size(1207, 813);
            this.pnl_acciones.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dgv_consulta);
            this.panel1.Location = new System.Drawing.Point(38, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1126, 756);
            this.panel1.TabIndex = 4;
            // 
            // dgv_consulta
            // 
            this.dgv_consulta.AllowUserToOrderColumns = true;
            this.dgv_consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_consulta.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_consulta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_consulta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgv_consulta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgv_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_consulta.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_consulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_consulta.Location = new System.Drawing.Point(0, 0);
            this.dgv_consulta.Name = "dgv_consulta";
            this.dgv_consulta.Size = new System.Drawing.Size(1122, 752);
            this.dgv_consulta.TabIndex = 0;
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
            // pnl_titulo
            // 
            this.pnl_titulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_titulo.Controls.Add(this.lbl_titulo);
            this.pnl_titulo.Controls.Add(this.lbl_total_enturnados);
            this.pnl_titulo.Location = new System.Drawing.Point(4, 2);
            this.pnl_titulo.Name = "pnl_titulo";
            this.pnl_titulo.Size = new System.Drawing.Size(1207, 59);
            this.pnl_titulo.TabIndex = 20;
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.Location = new System.Drawing.Point(207, 11);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(756, 33);
            this.lbl_titulo.TabIndex = 0;
            this.lbl_titulo.Text = "VEHICULOS CON ORDEN DE REPARACION EXTERNA";
            // 
            // lbl_total_enturnados
            // 
            this.lbl_total_enturnados.AutoSize = true;
            this.lbl_total_enturnados.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_enturnados.Location = new System.Drawing.Point(975, 16);
            this.lbl_total_enturnados.Name = "lbl_total_enturnados";
            this.lbl_total_enturnados.Size = new System.Drawing.Size(21, 22);
            this.lbl_total_enturnados.TabIndex = 3;
            this.lbl_total_enturnados.Text = "0";
            // 
            // frm_cons_reparacion_externa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 910);
            this.Controls.Add(this.pnl_informativo);
            this.Controls.Add(this.pnl_acciones);
            this.Controls.Add(this.pnl_titulo);
            this.Name = "frm_cons_reparacion_externa";
            this.Text = "frm_cons_reparacion_externa";
            this.Load += new System.EventHandler(this.frm_cons_reparacion_externa_Load);
            this.pnl_informativo.ResumeLayout(false);
            this.pnl_informativo.PerformLayout();
            this.pnl_acciones.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consulta)).EndInit();
            this.pnl_titulo.ResumeLayout(false);
            this.pnl_titulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_informativo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_version_forma;
        private System.Windows.Forms.Panel pnl_acciones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_consulta;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnl_titulo;
        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.Label lbl_total_enturnados;
        private System.Windows.Forms.Label lblTituloUsuarioConectado;
        private System.Windows.Forms.Label lblUsuarioConectado;
    }
}