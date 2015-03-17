namespace EnviaNomina
{
    partial class frmConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracion));
            this.lblusuario = new System.Windows.Forms.Label();
            this.lblsucursal = new System.Windows.Forms.Label();
            this.lblurl = new System.Windows.Forms.Label();
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.txtsucursal = new System.Windows.Forms.TextBox();
            this.txturl = new System.Windows.Forms.TextBox();
            this.btnaceptar = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbltimeout = new System.Windows.Forms.Label();
            this.numerictiempo = new System.Windows.Forms.NumericUpDown();
            this.lblminutos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numerictiempo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.Location = new System.Drawing.Point(30, 56);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(62, 20);
            this.lblusuario.TabIndex = 3;
            this.lblusuario.Text = "Usuario:";
            // 
            // lblsucursal
            // 
            this.lblsucursal.AutoSize = true;
            this.lblsucursal.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsucursal.Location = new System.Drawing.Point(26, 101);
            this.lblsucursal.Name = "lblsucursal";
            this.lblsucursal.Size = new System.Drawing.Size(66, 20);
            this.lblsucursal.TabIndex = 4;
            this.lblsucursal.Text = "Sucursal:";
            // 
            // lblurl
            // 
            this.lblurl.AutoSize = true;
            this.lblurl.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblurl.Location = new System.Drawing.Point(26, 147);
            this.lblurl.Name = "lblurl";
            this.lblurl.Size = new System.Drawing.Size(38, 20);
            this.lblurl.TabIndex = 5;
            this.lblurl.Text = "URL:";
            // 
            // txtusuario
            // 
            this.txtusuario.Location = new System.Drawing.Point(285, 56);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(222, 20);
            this.txtusuario.TabIndex = 6;
            // 
            // txtsucursal
            // 
            this.txtsucursal.Location = new System.Drawing.Point(285, 101);
            this.txtsucursal.Name = "txtsucursal";
            this.txtsucursal.Size = new System.Drawing.Size(222, 20);
            this.txtsucursal.TabIndex = 7;
            // 
            // txturl
            // 
            this.txturl.Location = new System.Drawing.Point(285, 147);
            this.txturl.Name = "txturl";
            this.txturl.Size = new System.Drawing.Size(222, 20);
            this.txturl.TabIndex = 8;
            // 
            // btnaceptar
            // 
            this.btnaceptar.BackColor = System.Drawing.Color.White;
            this.btnaceptar.BackgroundImage = global::EnviaNomina.Properties.Resources._1421797088_678134_sign_check_1281;
            this.btnaceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnaceptar.Font = new System.Drawing.Font("Nirmala UI", 11.25F);
            this.btnaceptar.Location = new System.Drawing.Point(445, 286);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(62, 46);
            this.btnaceptar.TabIndex = 9;
            this.btnaceptar.UseVisualStyleBackColor = false;
            this.btnaceptar.Click += new System.EventHandler(this.btnaceptar_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnguardar.BackgroundImage")));
            this.btnguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnguardar.Font = new System.Drawing.Font("Nirmala UI", 11.25F);
            this.btnguardar.Location = new System.Drawing.Point(267, 257);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(33, 29);
            this.btnguardar.TabIndex = 10;
            this.btnguardar.UseVisualStyleBackColor = true;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(261, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Guardar";
            // 
            // lbltimeout
            // 
            this.lbltimeout.AutoSize = true;
            this.lbltimeout.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltimeout.Location = new System.Drawing.Point(26, 187);
            this.lbltimeout.Name = "lbltimeout";
            this.lbltimeout.Size = new System.Drawing.Size(227, 20);
            this.lbltimeout.TabIndex = 12;
            this.lbltimeout.Text = "Tiempo de espera de la petición:";
            // 
            // numerictiempo
            // 
            this.numerictiempo.Location = new System.Drawing.Point(285, 187);
            this.numerictiempo.Name = "numerictiempo";
            this.numerictiempo.Size = new System.Drawing.Size(67, 20);
            this.numerictiempo.TabIndex = 13;
            // 
            // lblminutos
            // 
            this.lblminutos.AutoSize = true;
            this.lblminutos.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblminutos.Location = new System.Drawing.Point(358, 187);
            this.lblminutos.Name = "lblminutos";
            this.lblminutos.Size = new System.Drawing.Size(62, 20);
            this.lblminutos.TabIndex = 14;
            this.lblminutos.Text = "Minutos";
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(530, 344);
            this.Controls.Add(this.lblminutos);
            this.Controls.Add(this.numerictiempo);
            this.Controls.Add(this.lbltimeout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.btnaceptar);
            this.Controls.Add(this.txturl);
            this.Controls.Add(this.txtsucursal);
            this.Controls.Add(this.txtusuario);
            this.Controls.Add(this.lblurl);
            this.Controls.Add(this.lblsucursal);
            this.Controls.Add(this.lblusuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Configuracion";
            this.Load += new System.EventHandler(this.frmConfiguracion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numerictiempo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.Label lblsucursal;
        private System.Windows.Forms.Label lblurl;
        private System.Windows.Forms.TextBox txtusuario;
        private System.Windows.Forms.TextBox txtsucursal;
        private System.Windows.Forms.TextBox txturl;
        private System.Windows.Forms.Button btnaceptar;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbltimeout;
        private System.Windows.Forms.NumericUpDown numerictiempo;
        private System.Windows.Forms.Label lblminutos;
    }
}