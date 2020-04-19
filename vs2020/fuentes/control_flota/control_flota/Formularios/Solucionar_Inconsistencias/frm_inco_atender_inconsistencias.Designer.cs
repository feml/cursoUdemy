namespace control_flota.Formularios.Solucionar_Inconsistencias
{
    partial class frm_inco_atender_inconsistencias
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
            this.lbl_dpt_sistemas = new System.Windows.Forms.Label();
            this.lbl_version_forma = new System.Windows.Forms.Label();
            this.pnl_acciones = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbx_estado = new System.Windows.Forms.ComboBox();
            this.txb_fecha_salida = new System.Windows.Forms.TextBox();
            this.txb_fecha_salicitud = new System.Windows.Forms.TextBox();
            this.txb_fecha_ingreso = new System.Windows.Forms.TextBox();
            this.txb_fecha_enturne = new System.Windows.Forms.TextBox();
            this.txb_observacion = new System.Windows.Forms.TextBox();
            this.txb_hora_salida = new System.Windows.Forms.TextBox();
            this.txb_hora_ingreso = new System.Windows.Forms.TextBox();
            this.txb_hora_solicitud = new System.Windows.Forms.TextBox();
            this.txb_hora_enturne = new System.Windows.Forms.TextBox();
            this.btn_corregir = new System.Windows.Forms.Button();
            this.dtp_salida = new System.Windows.Forms.DateTimePicker();
            this.dtp_ingreso = new System.Windows.Forms.DateTimePicker();
            this.dtp_solicitud = new System.Windows.Forms.DateTimePicker();
            this.dtp_enturne = new System.Windows.Forms.DateTimePicker();
            this.lbl_observacion = new System.Windows.Forms.Label();
            this.lbl_secuencia_valor = new System.Windows.Forms.Label();
            this.lbl_estado = new System.Windows.Forms.Label();
            this.lbl_secuencia = new System.Windows.Forms.Label();
            this.lbl_fecha_salida = new System.Windows.Forms.Label();
            this.lbl_placa_valor = new System.Windows.Forms.Label();
            this.lbl_fecha_ingreso = new System.Windows.Forms.Label();
            this.lbl_placa = new System.Windows.Forms.Label();
            this.lbl_fecha_solicitud_ingreso = new System.Windows.Forms.Label();
            this.lbl_conductor_valor = new System.Windows.Forms.Label();
            this.lbl_fecha_enturne = new System.Windows.Forms.Label();
            this.lbl_conductor = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_solicitar_turno = new System.Windows.Forms.DataGridView();
            this.lbl_total_enturnados = new System.Windows.Forms.Label();
            this.lbl_consulta = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pnl_titulo = new System.Windows.Forms.Panel();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.pnl_informativo.SuspendLayout();
            this.pnl_acciones.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_solicitar_turno)).BeginInit();
            this.pnl_titulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_informativo
            // 
            this.pnl_informativo.Controls.Add(this.lblTituloUsuarioConectado);
            this.pnl_informativo.Controls.Add(this.lblUsuarioConectado);
            this.pnl_informativo.Controls.Add(this.lbl_dpt_sistemas);
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
            this.lblTituloUsuarioConectado.TabIndex = 4;
            this.lblTituloUsuarioConectado.Text = "Usuario Conectado : ";
            // 
            // lblUsuarioConectado
            // 
            this.lblUsuarioConectado.AutoSize = true;
            this.lblUsuarioConectado.Location = new System.Drawing.Point(622, 5);
            this.lblUsuarioConectado.Name = "lblUsuarioConectado";
            this.lblUsuarioConectado.Size = new System.Drawing.Size(67, 13);
            this.lblUsuarioConectado.TabIndex = 5;
            this.lblUsuarioConectado.Text = "FMONTOYA";
            // 
            // lbl_dpt_sistemas
            // 
            this.lbl_dpt_sistemas.AutoSize = true;
            this.lbl_dpt_sistemas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbl_dpt_sistemas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_dpt_sistemas.Location = new System.Drawing.Point(4, 6);
            this.lbl_dpt_sistemas.Name = "lbl_dpt_sistemas";
            this.lbl_dpt_sistemas.Size = new System.Drawing.Size(90, 13);
            this.lbl_dpt_sistemas.TabIndex = 0;
            this.lbl_dpt_sistemas.Text = "Dpto de Sistemas";
            // 
            // lbl_version_forma
            // 
            this.lbl_version_forma.AutoSize = true;
            this.lbl_version_forma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_version_forma.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_version_forma.Location = new System.Drawing.Point(1086, 6);
            this.lbl_version_forma.Name = "lbl_version_forma";
            this.lbl_version_forma.Size = new System.Drawing.Size(113, 13);
            this.lbl_version_forma.TabIndex = 0;
            this.lbl_version_forma.Text = "v.1.1.10122014.64bits";
            // 
            // pnl_acciones
            // 
            this.pnl_acciones.Controls.Add(this.panel2);
            this.pnl_acciones.Controls.Add(this.panel1);
            this.pnl_acciones.Controls.Add(this.lbl_total_enturnados);
            this.pnl_acciones.Controls.Add(this.lbl_consulta);
            this.pnl_acciones.Controls.Add(this.button2);
            this.pnl_acciones.Location = new System.Drawing.Point(4, 67);
            this.pnl_acciones.Name = "pnl_acciones";
            this.pnl_acciones.Size = new System.Drawing.Size(1207, 813);
            this.pnl_acciones.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbx_estado);
            this.panel2.Controls.Add(this.txb_fecha_salida);
            this.panel2.Controls.Add(this.txb_fecha_salicitud);
            this.panel2.Controls.Add(this.txb_fecha_ingreso);
            this.panel2.Controls.Add(this.txb_fecha_enturne);
            this.panel2.Controls.Add(this.txb_observacion);
            this.panel2.Controls.Add(this.txb_hora_salida);
            this.panel2.Controls.Add(this.txb_hora_ingreso);
            this.panel2.Controls.Add(this.txb_hora_solicitud);
            this.panel2.Controls.Add(this.txb_hora_enturne);
            this.panel2.Controls.Add(this.btn_corregir);
            this.panel2.Controls.Add(this.dtp_salida);
            this.panel2.Controls.Add(this.dtp_ingreso);
            this.panel2.Controls.Add(this.dtp_solicitud);
            this.panel2.Controls.Add(this.dtp_enturne);
            this.panel2.Controls.Add(this.lbl_observacion);
            this.panel2.Controls.Add(this.lbl_secuencia_valor);
            this.panel2.Controls.Add(this.lbl_estado);
            this.panel2.Controls.Add(this.lbl_secuencia);
            this.panel2.Controls.Add(this.lbl_fecha_salida);
            this.panel2.Controls.Add(this.lbl_placa_valor);
            this.panel2.Controls.Add(this.lbl_fecha_ingreso);
            this.panel2.Controls.Add(this.lbl_placa);
            this.panel2.Controls.Add(this.lbl_fecha_solicitud_ingreso);
            this.panel2.Controls.Add(this.lbl_conductor_valor);
            this.panel2.Controls.Add(this.lbl_fecha_enturne);
            this.panel2.Controls.Add(this.lbl_conductor);
            this.panel2.Location = new System.Drawing.Point(6, 360);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1194, 380);
            this.panel2.TabIndex = 5;
            // 
            // cbx_estado
            // 
            this.cbx_estado.Enabled = false;
            this.cbx_estado.FormattingEnabled = true;
            this.cbx_estado.Items.AddRange(new object[] {
            "",
            "ENTURNADO",
            "SOLICITADO",
            "INGRESADO",
            "ATENDIDO",
            "ANULAR"});
            this.cbx_estado.Location = new System.Drawing.Point(1054, 23);
            this.cbx_estado.Name = "cbx_estado";
            this.cbx_estado.Size = new System.Drawing.Size(121, 21);
            this.cbx_estado.TabIndex = 9;
            this.cbx_estado.SelectedIndexChanged += new System.EventHandler(this.cbx_estado_SelectedIndexChanged);
            // 
            // txb_fecha_salida
            // 
            this.txb_fecha_salida.Enabled = false;
            this.txb_fecha_salida.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_fecha_salida.Location = new System.Drawing.Point(848, 230);
            this.txb_fecha_salida.Name = "txb_fecha_salida";
            this.txb_fecha_salida.Size = new System.Drawing.Size(250, 26);
            this.txb_fecha_salida.TabIndex = 8;
            this.txb_fecha_salida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txb_fecha_salida.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txb_fecha_salida_MouseDoubleClick);
            // 
            // txb_fecha_salicitud
            // 
            this.txb_fecha_salicitud.Enabled = false;
            this.txb_fecha_salicitud.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_fecha_salicitud.Location = new System.Drawing.Point(848, 179);
            this.txb_fecha_salicitud.Name = "txb_fecha_salicitud";
            this.txb_fecha_salicitud.Size = new System.Drawing.Size(250, 26);
            this.txb_fecha_salicitud.TabIndex = 7;
            this.txb_fecha_salicitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txb_fecha_salicitud.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txb_fecha_salicitud_MouseDoubleClick);
            // 
            // txb_fecha_ingreso
            // 
            this.txb_fecha_ingreso.Enabled = false;
            this.txb_fecha_ingreso.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_fecha_ingreso.Location = new System.Drawing.Point(242, 240);
            this.txb_fecha_ingreso.Name = "txb_fecha_ingreso";
            this.txb_fecha_ingreso.Size = new System.Drawing.Size(253, 26);
            this.txb_fecha_ingreso.TabIndex = 6;
            this.txb_fecha_ingreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txb_fecha_ingreso.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txb_fecha_ingreso_MouseDoubleClick);
            // 
            // txb_fecha_enturne
            // 
            this.txb_fecha_enturne.Enabled = false;
            this.txb_fecha_enturne.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_fecha_enturne.Location = new System.Drawing.Point(242, 173);
            this.txb_fecha_enturne.Name = "txb_fecha_enturne";
            this.txb_fecha_enturne.Size = new System.Drawing.Size(253, 26);
            this.txb_fecha_enturne.TabIndex = 5;
            this.txb_fecha_enturne.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txb_fecha_enturne.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txb_fecha_enturne_MouseDoubleClick);
            // 
            // txb_observacion
            // 
            this.txb_observacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_observacion.Enabled = false;
            this.txb_observacion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_observacion.Location = new System.Drawing.Point(213, 93);
            this.txb_observacion.Multiline = true;
            this.txb_observacion.Name = "txb_observacion";
            this.txb_observacion.Size = new System.Drawing.Size(840, 58);
            this.txb_observacion.TabIndex = 4;
            this.txb_observacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txb_hora_salida
            // 
            this.txb_hora_salida.Enabled = false;
            this.txb_hora_salida.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_hora_salida.Location = new System.Drawing.Point(1051, 232);
            this.txb_hora_salida.Name = "txb_hora_salida";
            this.txb_hora_salida.Size = new System.Drawing.Size(47, 20);
            this.txb_hora_salida.TabIndex = 3;
            this.txb_hora_salida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txb_hora_salida.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txb_hora_salida_MouseDoubleClick);
            // 
            // txb_hora_ingreso
            // 
            this.txb_hora_ingreso.Enabled = false;
            this.txb_hora_ingreso.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_hora_ingreso.Location = new System.Drawing.Point(445, 243);
            this.txb_hora_ingreso.Name = "txb_hora_ingreso";
            this.txb_hora_ingreso.Size = new System.Drawing.Size(50, 20);
            this.txb_hora_ingreso.TabIndex = 3;
            this.txb_hora_ingreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txb_hora_ingreso.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txb_hora_ingreso_MouseDoubleClick);
            // 
            // txb_hora_solicitud
            // 
            this.txb_hora_solicitud.Enabled = false;
            this.txb_hora_solicitud.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_hora_solicitud.Location = new System.Drawing.Point(1051, 179);
            this.txb_hora_solicitud.Name = "txb_hora_solicitud";
            this.txb_hora_solicitud.Size = new System.Drawing.Size(47, 20);
            this.txb_hora_solicitud.TabIndex = 3;
            this.txb_hora_solicitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txb_hora_solicitud.DoubleClick += new System.EventHandler(this.txb_hora_solicitud_DoubleClick);
            // 
            // txb_hora_enturne
            // 
            this.txb_hora_enturne.Enabled = false;
            this.txb_hora_enturne.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_hora_enturne.Location = new System.Drawing.Point(445, 179);
            this.txb_hora_enturne.Name = "txb_hora_enturne";
            this.txb_hora_enturne.Size = new System.Drawing.Size(47, 20);
            this.txb_hora_enturne.TabIndex = 3;
            this.txb_hora_enturne.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txb_hora_enturne.DoubleClick += new System.EventHandler(this.txb_hora_enturne_DoubleClick);
            // 
            // btn_corregir
            // 
            this.btn_corregir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_corregir.Location = new System.Drawing.Point(472, 299);
            this.btn_corregir.Name = "btn_corregir";
            this.btn_corregir.Size = new System.Drawing.Size(250, 45);
            this.btn_corregir.TabIndex = 2;
            this.btn_corregir.Text = "GRABAR";
            this.btn_corregir.UseVisualStyleBackColor = true;
            this.btn_corregir.Click += new System.EventHandler(this.btn_corregir_Click);
            // 
            // dtp_salida
            // 
            this.dtp_salida.Enabled = false;
            this.dtp_salida.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_salida.Location = new System.Drawing.Point(848, 232);
            this.dtp_salida.Name = "dtp_salida";
            this.dtp_salida.Size = new System.Drawing.Size(200, 20);
            this.dtp_salida.TabIndex = 1;
            this.dtp_salida.ValueChanged += new System.EventHandler(this.dtp_salida_ValueChanged);
            // 
            // dtp_ingreso
            // 
            this.dtp_ingreso.Enabled = false;
            this.dtp_ingreso.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_ingreso.Location = new System.Drawing.Point(242, 243);
            this.dtp_ingreso.Name = "dtp_ingreso";
            this.dtp_ingreso.Size = new System.Drawing.Size(200, 20);
            this.dtp_ingreso.TabIndex = 1;
            this.dtp_ingreso.ValueChanged += new System.EventHandler(this.dtp_ingreso_ValueChanged);
            // 
            // dtp_solicitud
            // 
            this.dtp_solicitud.Enabled = false;
            this.dtp_solicitud.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_solicitud.Location = new System.Drawing.Point(848, 179);
            this.dtp_solicitud.Name = "dtp_solicitud";
            this.dtp_solicitud.Size = new System.Drawing.Size(200, 20);
            this.dtp_solicitud.TabIndex = 1;
            this.dtp_solicitud.ValueChanged += new System.EventHandler(this.dtp_solicitud_ValueChanged);
            // 
            // dtp_enturne
            // 
            this.dtp_enturne.Enabled = false;
            this.dtp_enturne.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_enturne.Location = new System.Drawing.Point(242, 179);
            this.dtp_enturne.Name = "dtp_enturne";
            this.dtp_enturne.Size = new System.Drawing.Size(200, 20);
            this.dtp_enturne.TabIndex = 1;
            this.dtp_enturne.ValueChanged += new System.EventHandler(this.dtp_enturne_ValueChanged);
            // 
            // lbl_observacion
            // 
            this.lbl_observacion.AutoSize = true;
            this.lbl_observacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_observacion.Location = new System.Drawing.Point(44, 88);
            this.lbl_observacion.Name = "lbl_observacion";
            this.lbl_observacion.Size = new System.Drawing.Size(165, 29);
            this.lbl_observacion.TabIndex = 0;
            this.lbl_observacion.Text = "Inconsistencia";
            // 
            // lbl_secuencia_valor
            // 
            this.lbl_secuencia_valor.AutoSize = true;
            this.lbl_secuencia_valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_secuencia_valor.Location = new System.Drawing.Point(837, 21);
            this.lbl_secuencia_valor.Name = "lbl_secuencia_valor";
            this.lbl_secuencia_valor.Size = new System.Drawing.Size(0, 24);
            this.lbl_secuencia_valor.TabIndex = 0;
            // 
            // lbl_estado
            // 
            this.lbl_estado.AutoSize = true;
            this.lbl_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_estado.Location = new System.Drawing.Point(975, 22);
            this.lbl_estado.Name = "lbl_estado";
            this.lbl_estado.Size = new System.Drawing.Size(78, 24);
            this.lbl_estado.TabIndex = 0;
            this.lbl_estado.Text = "Estado :";
            // 
            // lbl_secuencia
            // 
            this.lbl_secuencia.AutoSize = true;
            this.lbl_secuencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_secuencia.Location = new System.Drawing.Point(728, 21);
            this.lbl_secuencia.Name = "lbl_secuencia";
            this.lbl_secuencia.Size = new System.Drawing.Size(110, 24);
            this.lbl_secuencia.TabIndex = 0;
            this.lbl_secuencia.Text = "Secuencia :";
            // 
            // lbl_fecha_salida
            // 
            this.lbl_fecha_salida.AutoSize = true;
            this.lbl_fecha_salida.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fecha_salida.Location = new System.Drawing.Point(606, 232);
            this.lbl_fecha_salida.Name = "lbl_fecha_salida";
            this.lbl_fecha_salida.Size = new System.Drawing.Size(229, 24);
            this.lbl_fecha_salida.TabIndex = 0;
            this.lbl_fecha_salida.Text = "Fecha y hora Salida Taller";
            // 
            // lbl_placa_valor
            // 
            this.lbl_placa_valor.AutoSize = true;
            this.lbl_placa_valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_placa_valor.Location = new System.Drawing.Point(577, 22);
            this.lbl_placa_valor.Name = "lbl_placa_valor";
            this.lbl_placa_valor.Size = new System.Drawing.Size(0, 24);
            this.lbl_placa_valor.TabIndex = 0;
            // 
            // lbl_fecha_ingreso
            // 
            this.lbl_fecha_ingreso.AutoSize = true;
            this.lbl_fecha_ingreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fecha_ingreso.Location = new System.Drawing.Point(40, 240);
            this.lbl_fecha_ingreso.Name = "lbl_fecha_ingreso";
            this.lbl_fecha_ingreso.Size = new System.Drawing.Size(189, 24);
            this.lbl_fecha_ingreso.TabIndex = 0;
            this.lbl_fecha_ingreso.Text = "Fecha y hora Ingreso";
            // 
            // lbl_placa
            // 
            this.lbl_placa.AutoSize = true;
            this.lbl_placa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_placa.Location = new System.Drawing.Point(508, 21);
            this.lbl_placa.Name = "lbl_placa";
            this.lbl_placa.Size = new System.Drawing.Size(66, 24);
            this.lbl_placa.TabIndex = 0;
            this.lbl_placa.Text = "Placa :";
            // 
            // lbl_fecha_solicitud_ingreso
            // 
            this.lbl_fecha_solicitud_ingreso.AutoSize = true;
            this.lbl_fecha_solicitud_ingreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fecha_solicitud_ingreso.Location = new System.Drawing.Point(570, 176);
            this.lbl_fecha_solicitud_ingreso.Name = "lbl_fecha_solicitud_ingreso";
            this.lbl_fecha_solicitud_ingreso.Size = new System.Drawing.Size(268, 24);
            this.lbl_fecha_solicitud_ingreso.TabIndex = 0;
            this.lbl_fecha_solicitud_ingreso.Text = "Fecha y Hora Solicitud Ingreso";
            // 
            // lbl_conductor_valor
            // 
            this.lbl_conductor_valor.AutoSize = true;
            this.lbl_conductor_valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_conductor_valor.Location = new System.Drawing.Point(124, 22);
            this.lbl_conductor_valor.Name = "lbl_conductor_valor";
            this.lbl_conductor_valor.Size = new System.Drawing.Size(0, 24);
            this.lbl_conductor_valor.TabIndex = 0;
            // 
            // lbl_fecha_enturne
            // 
            this.lbl_fecha_enturne.AutoSize = true;
            this.lbl_fecha_enturne.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fecha_enturne.Location = new System.Drawing.Point(39, 178);
            this.lbl_fecha_enturne.Name = "lbl_fecha_enturne";
            this.lbl_fecha_enturne.Size = new System.Drawing.Size(193, 24);
            this.lbl_fecha_enturne.TabIndex = 0;
            this.lbl_fecha_enturne.Text = "Fecha y hora Enturne";
            // 
            // lbl_conductor
            // 
            this.lbl_conductor.AutoSize = true;
            this.lbl_conductor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_conductor.Location = new System.Drawing.Point(17, 21);
            this.lbl_conductor.Name = "lbl_conductor";
            this.lbl_conductor.Size = new System.Drawing.Size(108, 24);
            this.lbl_conductor.TabIndex = 0;
            this.lbl_conductor.Text = "Conductor :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_solicitar_turno);
            this.panel1.Location = new System.Drawing.Point(6, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1194, 294);
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
            this.dgv_solicitar_turno.Location = new System.Drawing.Point(11, 12);
            this.dgv_solicitar_turno.Name = "dgv_solicitar_turno";
            this.dgv_solicitar_turno.Size = new System.Drawing.Size(1172, 268);
            this.dgv_solicitar_turno.TabIndex = 0;
            this.dgv_solicitar_turno.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_solicitar_turno_CellContentClick);
            this.dgv_solicitar_turno.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_solicitar_turno_CellDoubleClick);
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
            this.lbl_titulo.Location = new System.Drawing.Point(365, 19);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(477, 33);
            this.lbl_titulo.TabIndex = 0;
            this.lbl_titulo.Text = "SOLUCIONAR INCONSISTENCIAS";
            // 
            // frm_inco_atender_inconsistencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 910);
            this.Controls.Add(this.pnl_informativo);
            this.Controls.Add(this.pnl_acciones);
            this.Controls.Add(this.pnl_titulo);
            this.Name = "frm_inco_atender_inconsistencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_inco_atender_inconsistencias";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_inco_atender_inconsistencias_Load);
            this.pnl_informativo.ResumeLayout(false);
            this.pnl_informativo.PerformLayout();
            this.pnl_acciones.ResumeLayout(false);
            this.pnl_acciones.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_solicitar_turno)).EndInit();
            this.pnl_titulo.ResumeLayout(false);
            this.pnl_titulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_informativo;
        private System.Windows.Forms.Label lbl_dpt_sistemas;
        private System.Windows.Forms.Label lbl_version_forma;
        private System.Windows.Forms.Panel pnl_acciones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_solicitar_turno;
        private System.Windows.Forms.Label lbl_total_enturnados;
        private System.Windows.Forms.Label lbl_consulta;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnl_titulo;
        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_secuencia;
        private System.Windows.Forms.Label lbl_placa;
        private System.Windows.Forms.Label lbl_conductor;
        private System.Windows.Forms.DateTimePicker dtp_salida;
        private System.Windows.Forms.DateTimePicker dtp_ingreso;
        private System.Windows.Forms.DateTimePicker dtp_solicitud;
        private System.Windows.Forms.DateTimePicker dtp_enturne;
        private System.Windows.Forms.Label lbl_observacion;
        private System.Windows.Forms.Label lbl_secuencia_valor;
        private System.Windows.Forms.Label lbl_fecha_salida;
        private System.Windows.Forms.Label lbl_placa_valor;
        private System.Windows.Forms.Label lbl_fecha_ingreso;
        private System.Windows.Forms.Label lbl_fecha_solicitud_ingreso;
        private System.Windows.Forms.Label lbl_conductor_valor;
        private System.Windows.Forms.Label lbl_fecha_enturne;
        private System.Windows.Forms.Button btn_corregir;
        private System.Windows.Forms.TextBox txb_hora_salida;
        private System.Windows.Forms.TextBox txb_hora_ingreso;
        private System.Windows.Forms.TextBox txb_hora_solicitud;
        private System.Windows.Forms.TextBox txb_hora_enturne;
        private System.Windows.Forms.TextBox txb_observacion;
        private System.Windows.Forms.TextBox txb_fecha_enturne;
        private System.Windows.Forms.TextBox txb_fecha_ingreso;
        private System.Windows.Forms.TextBox txb_fecha_salida;
        private System.Windows.Forms.TextBox txb_fecha_salicitud;
        private System.Windows.Forms.ComboBox cbx_estado;
        private System.Windows.Forms.Label lbl_estado;
        private System.Windows.Forms.Label lblTituloUsuarioConectado;
        private System.Windows.Forms.Label lblUsuarioConectado;
    }
}