namespace control_flota.Formularios.Solucionar_Inconsistencias
{
    partial class frm_inco_consultar_parqueadero
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_solicitar_turno = new System.Windows.Forms.DataGridView();
            this.lbl_total_enturnados = new System.Windows.Forms.Label();
            this.lbl_consulta = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
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
            this.pnl_informativo.TabIndex = 10;
            // 
            // lblTituloUsuarioConectado
            // 
            this.lblTituloUsuarioConectado.AutoSize = true;
            this.lblTituloUsuarioConectado.Location = new System.Drawing.Point(517, 5);
            this.lblTituloUsuarioConectado.Name = "lblTituloUsuarioConectado";
            this.lblTituloUsuarioConectado.Size = new System.Drawing.Size(107, 13);
            this.lblTituloUsuarioConectado.TabIndex = 6;
            this.lblTituloUsuarioConectado.Text = "Usuario Conectado : ";
            // 
            // lblUsuarioConectado
            // 
            this.lblUsuarioConectado.AutoSize = true;
            this.lblUsuarioConectado.Location = new System.Drawing.Point(622, 5);
            this.lblUsuarioConectado.Name = "lblUsuarioConectado";
            this.lblUsuarioConectado.Size = new System.Drawing.Size(67, 13);
            this.lblUsuarioConectado.TabIndex = 7;
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
            this.lbl_version_forma.Location = new System.Drawing.Point(1087, 6);
            this.lbl_version_forma.Name = "lbl_version_forma";
            this.lbl_version_forma.Size = new System.Drawing.Size(113, 13);
            this.lbl_version_forma.TabIndex = 0;
            this.lbl_version_forma.Text = "v.1.1.10122014.64bits";
            // 
            // pnl_acciones
            // 
            this.pnl_acciones.Controls.Add(this.panel1);
            this.pnl_acciones.Controls.Add(this.lbl_total_enturnados);
            this.pnl_acciones.Controls.Add(this.lbl_consulta);
            this.pnl_acciones.Controls.Add(this.button2);
            this.pnl_acciones.Location = new System.Drawing.Point(4, 67);
            this.pnl_acciones.Name = "pnl_acciones";
            this.pnl_acciones.Size = new System.Drawing.Size(1207, 813);
            this.pnl_acciones.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_solicitar_turno);
            this.panel1.Location = new System.Drawing.Point(8, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1194, 669);
            this.panel1.TabIndex = 4;
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
            this.dgv_solicitar_turno.Location = new System.Drawing.Point(11, 24);
            this.dgv_solicitar_turno.Name = "dgv_solicitar_turno";
            this.dgv_solicitar_turno.Size = new System.Drawing.Size(1172, 627);
            this.dgv_solicitar_turno.TabIndex = 0;
            // 
            // lbl_total_enturnados
            // 
            this.lbl_total_enturnados.AutoSize = true;
            this.lbl_total_enturnados.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_enturnados.Location = new System.Drawing.Point(823, 35);
            this.lbl_total_enturnados.Name = "lbl_total_enturnados";
            this.lbl_total_enturnados.Size = new System.Drawing.Size(21, 22);
            this.lbl_total_enturnados.TabIndex = 3;
            this.lbl_total_enturnados.Text = "0";
            // 
            // lbl_consulta
            // 
            this.lbl_consulta.AutoSize = true;
            this.lbl_consulta.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_consulta.Location = new System.Drawing.Point(363, 35);
            this.lbl_consulta.Name = "lbl_consulta";
            this.lbl_consulta.Size = new System.Drawing.Size(457, 22);
            this.lbl_consulta.TabIndex = 3;
            this.lbl_consulta.Text = "REGISTROS QUE PRESENTAN INCONSISTENCIA";
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
            this.pnl_titulo.Controls.Add(this.lbl_titulo);
            this.pnl_titulo.Location = new System.Drawing.Point(4, 2);
            this.pnl_titulo.Name = "pnl_titulo";
            this.pnl_titulo.Size = new System.Drawing.Size(1207, 59);
            this.pnl_titulo.TabIndex = 8;
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.Location = new System.Drawing.Point(372, 19);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(693, 33);
            this.lbl_titulo.TabIndex = 0;
            this.lbl_titulo.Text = "CONSULTAR INCONSISTENCIAS PARQUEADERO";
            // 
            // frm_inco_consultar_parqueadero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 910);
            this.Controls.Add(this.pnl_informativo);
            this.Controls.Add(this.pnl_acciones);
            this.Controls.Add(this.pnl_titulo);
            this.Name = "frm_inco_consultar_parqueadero";
            this.Text = "frm_inco_consultar_parqueadero";
            this.Load += new System.EventHandler(this.frm_inco_consultar_parqueadero_Load);
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
        private System.Windows.Forms.Label lblTituloUsuarioConectado;
        private System.Windows.Forms.Label lblUsuarioConectado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_version_forma;
        private System.Windows.Forms.Panel pnl_acciones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_solicitar_turno;
        private System.Windows.Forms.Label lbl_total_enturnados;
        private System.Windows.Forms.Label lbl_consulta;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnl_titulo;
        private System.Windows.Forms.Label lbl_titulo;
    }
}