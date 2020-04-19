namespace wfEnvioUnitario
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelTransacciones = new System.Windows.Forms.Panel();
            this.groupBoxXmlRecibido = new System.Windows.Forms.GroupBox();
            this.txbXmlRecibido = new System.Windows.Forms.TextBox();
            this.groupBoxXmlEnviado = new System.Windows.Forms.GroupBox();
            this.txbXmlEnviado = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.panelConsulta = new System.Windows.Forms.Panel();
            this.dgvConsulta = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbxTransaccion = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txbLlave = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelPrincipal.SuspendLayout();
            this.panelTransacciones.SuspendLayout();
            this.groupBoxXmlRecibido.SuspendLayout();
            this.groupBoxXmlEnviado.SuspendLayout();
            this.panelConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1406, 100);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(494, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(415, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "MINITERIO DE TRANSPORTE - ENVIO UNITARIO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(620, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "TRANSER S.A";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::wfEnvioUnitario.Properties.Resources.Logo_transer;
            this.pictureBox1.Location = new System.Drawing.Point(1133, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPrincipal.Controls.Add(this.panelTransacciones);
            this.panelPrincipal.Controls.Add(this.panelConsulta);
            this.panelPrincipal.Controls.Add(this.panel3);
            this.panelPrincipal.Location = new System.Drawing.Point(2, 105);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1406, 714);
            this.panelPrincipal.TabIndex = 0;
            // 
            // panelTransacciones
            // 
            this.panelTransacciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTransacciones.Controls.Add(this.groupBoxXmlRecibido);
            this.panelTransacciones.Controls.Add(this.groupBoxXmlEnviado);
            this.panelTransacciones.Controls.Add(this.btnSalir);
            this.panelTransacciones.Controls.Add(this.btnActualizar);
            this.panelTransacciones.Controls.Add(this.btnEnviar);
            this.panelTransacciones.Location = new System.Drawing.Point(5, 138);
            this.panelTransacciones.Name = "panelTransacciones";
            this.panelTransacciones.Size = new System.Drawing.Size(1394, 569);
            this.panelTransacciones.TabIndex = 7;
            this.panelTransacciones.Visible = false;
            // 
            // groupBoxXmlRecibido
            // 
            this.groupBoxXmlRecibido.Controls.Add(this.txbXmlRecibido);
            this.groupBoxXmlRecibido.Location = new System.Drawing.Point(751, 25);
            this.groupBoxXmlRecibido.Name = "groupBoxXmlRecibido";
            this.groupBoxXmlRecibido.Size = new System.Drawing.Size(634, 536);
            this.groupBoxXmlRecibido.TabIndex = 1;
            this.groupBoxXmlRecibido.TabStop = false;
            this.groupBoxXmlRecibido.Text = "XML Recibido";
            // 
            // txbXmlRecibido
            // 
            this.txbXmlRecibido.Location = new System.Drawing.Point(12, 21);
            this.txbXmlRecibido.Multiline = true;
            this.txbXmlRecibido.Name = "txbXmlRecibido";
            this.txbXmlRecibido.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbXmlRecibido.Size = new System.Drawing.Size(611, 495);
            this.txbXmlRecibido.TabIndex = 0;
            // 
            // groupBoxXmlEnviado
            // 
            this.groupBoxXmlEnviado.Controls.Add(this.txbXmlEnviado);
            this.groupBoxXmlEnviado.Location = new System.Drawing.Point(7, 24);
            this.groupBoxXmlEnviado.Name = "groupBoxXmlEnviado";
            this.groupBoxXmlEnviado.Size = new System.Drawing.Size(632, 536);
            this.groupBoxXmlEnviado.TabIndex = 1;
            this.groupBoxXmlEnviado.TabStop = false;
            this.groupBoxXmlEnviado.Text = "XML Enviado";
            // 
            // txbXmlEnviado
            // 
            this.txbXmlEnviado.Location = new System.Drawing.Point(6, 19);
            this.txbXmlEnviado.Multiline = true;
            this.txbXmlEnviado.Name = "txbXmlEnviado";
            this.txbXmlEnviado.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbXmlEnviado.Size = new System.Drawing.Size(620, 499);
            this.txbXmlEnviado.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(652, 533);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(86, 29);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(652, 263);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(86, 29);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(652, 46);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(86, 29);
            this.btnEnviar.TabIndex = 0;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // panelConsulta
            // 
            this.panelConsulta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelConsulta.Controls.Add(this.dgvConsulta);
            this.panelConsulta.Location = new System.Drawing.Point(3, 51);
            this.panelConsulta.Name = "panelConsulta";
            this.panelConsulta.Size = new System.Drawing.Size(1396, 81);
            this.panelConsulta.TabIndex = 6;
            this.panelConsulta.Visible = false;
            // 
            // dgvConsulta
            // 
            this.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsulta.Location = new System.Drawing.Point(3, 3);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.Size = new System.Drawing.Size(1386, 72);
            this.dgvConsulta.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbxTransaccion);
            this.panel3.Controls.Add(this.btnConsultar);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txbLlave);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(208, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(986, 40);
            this.panel3.TabIndex = 5;
            // 
            // cbxTransaccion
            // 
            this.cbxTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTransaccion.FormattingEnabled = true;
            this.cbxTransaccion.Location = new System.Drawing.Point(273, 9);
            this.cbxTransaccion.Name = "cbxTransaccion";
            this.cbxTransaccion.Size = new System.Drawing.Size(188, 24);
            this.cbxTransaccion.TabIndex = 1;
            this.cbxTransaccion.SelectedIndexChanged += new System.EventHandler(this.cbxTransaccion_SelectedIndexChanged);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Location = new System.Drawing.Point(715, 9);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(95, 25);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(177, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Transaccion : ";
            // 
            // txbLlave
            // 
            this.txbLlave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLlave.Location = new System.Drawing.Point(550, 11);
            this.txbLlave.Name = "txbLlave";
            this.txbLlave.Size = new System.Drawing.Size(133, 20);
            this.txbLlave.TabIndex = 3;
            this.txbLlave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbLlave_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(493, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Llave : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 821);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRANSPORTES Y SERVICIOS TRANSER S.A  - ENVIO UNITARIO MINSTRANSPORTE";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelPrincipal.ResumeLayout(false);
            this.panelTransacciones.ResumeLayout(false);
            this.groupBoxXmlRecibido.ResumeLayout(false);
            this.groupBoxXmlRecibido.PerformLayout();
            this.groupBoxXmlEnviado.ResumeLayout(false);
            this.groupBoxXmlEnviado.PerformLayout();
            this.panelConsulta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.ComboBox cbxTransaccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txbLlave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelConsulta;
        private System.Windows.Forms.DataGridView dgvConsulta;
        private System.Windows.Forms.Panel panelTransacciones;
        private System.Windows.Forms.GroupBox groupBoxXmlRecibido;
        private System.Windows.Forms.TextBox txbXmlRecibido;
        private System.Windows.Forms.GroupBox groupBoxXmlEnviado;
        private System.Windows.Forms.TextBox txbXmlEnviado;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnSalir;
    }
}

