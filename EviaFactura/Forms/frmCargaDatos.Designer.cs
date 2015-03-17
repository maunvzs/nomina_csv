namespace EnviaNomina
{
    partial class frmCargaDatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaDatos));
            this.btncargar = new System.Windows.Forms.Button();
            this.txtruta = new System.Windows.Forms.TextBox();
            this.lblnombreruta = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.griddatos = new System.Windows.Forms.DataGridView();
            this.gpbvalores = new System.Windows.Forms.GroupBox();
            this.lblestado = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblmensaje = new System.Windows.Forms.Label();
            this.pbarcarga = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblnumempleados = new System.Windows.Forms.Label();
            this.btnexaminar = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.griddatos)).BeginInit();
            this.gpbvalores.SuspendLayout();
            this.SuspendLayout();
            // 
            // btncargar
            // 
            this.btncargar.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncargar.Location = new System.Drawing.Point(521, 445);
            this.btncargar.Name = "btncargar";
            this.btncargar.Size = new System.Drawing.Size(131, 30);
            this.btncargar.TabIndex = 0;
            this.btncargar.Text = "Enviar";
            this.btncargar.UseVisualStyleBackColor = true;
            this.btncargar.Click += new System.EventHandler(this.btncargar_Click);
            // 
            // txtruta
            // 
            this.txtruta.Location = new System.Drawing.Point(146, 76);
            this.txtruta.Name = "txtruta";
            this.txtruta.Size = new System.Drawing.Size(342, 20);
            this.txtruta.TabIndex = 1;
            // 
            // lblnombreruta
            // 
            this.lblnombreruta.AutoSize = true;
            this.lblnombreruta.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombreruta.Location = new System.Drawing.Point(142, 53);
            this.lblnombreruta.Name = "lblnombreruta";
            this.lblnombreruta.Size = new System.Drawing.Size(42, 20);
            this.lblnombreruta.TabIndex = 2;
            this.lblnombreruta.Text = "Ruta:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuracionToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(663, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuracionToolStripMenuItem.Text = "Configuración";
            this.configuracionToolStripMenuItem.Click += new System.EventHandler(this.configuracionToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // griddatos
            // 
            this.griddatos.AllowUserToAddRows = false;
            this.griddatos.AllowUserToDeleteRows = false;
            this.griddatos.AllowUserToResizeColumns = false;
            this.griddatos.AllowUserToResizeRows = false;
            this.griddatos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.griddatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.griddatos.Location = new System.Drawing.Point(12, 147);
            this.griddatos.Name = "griddatos";
            this.griddatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.griddatos.Size = new System.Drawing.Size(640, 254);
            this.griddatos.TabIndex = 7;
            this.griddatos.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.griddatos_ColumnAdded);
            // 
            // gpbvalores
            // 
            this.gpbvalores.Controls.Add(this.lblestado);
            this.gpbvalores.Controls.Add(this.cboEstado);
            this.gpbvalores.Location = new System.Drawing.Point(663, 138);
            this.gpbvalores.Name = "gpbvalores";
            this.gpbvalores.Size = new System.Drawing.Size(217, 254);
            this.gpbvalores.TabIndex = 10;
            this.gpbvalores.TabStop = false;
            this.gpbvalores.Text = "Valores";
            // 
            // lblestado
            // 
            this.lblestado.AutoSize = true;
            this.lblestado.Font = new System.Drawing.Font("Nirmala UI", 11.25F);
            this.lblestado.Location = new System.Drawing.Point(15, 20);
            this.lblestado.Name = "lblestado";
            this.lblestado.Size = new System.Drawing.Size(57, 20);
            this.lblestado.TabIndex = 11;
            this.lblestado.Text = "Estado:";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Font = new System.Drawing.Font("Nirmala UI", 11.25F);
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(78, 19);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(133, 28);
            this.cboEstado.TabIndex = 10;
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged);
            // 
            // lblmensaje
            // 
            this.lblmensaje.AutoSize = true;
            this.lblmensaje.Font = new System.Drawing.Font("Nirmala UI", 11.25F);
            this.lblmensaje.Location = new System.Drawing.Point(3, 424);
            this.lblmensaje.Name = "lblmensaje";
            this.lblmensaje.Size = new System.Drawing.Size(0, 20);
            this.lblmensaje.TabIndex = 11;
            // 
            // pbarcarga
            // 
            this.pbarcarga.Location = new System.Drawing.Point(12, 445);
            this.pbarcarga.Name = "pbarcarga";
            this.pbarcarga.Size = new System.Drawing.Size(342, 30);
            this.pbarcarga.Step = 50;
            this.pbarcarga.TabIndex = 12;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lblnumempleados
            // 
            this.lblnumempleados.AutoSize = true;
            this.lblnumempleados.Font = new System.Drawing.Font("Nirmala UI", 11.25F);
            this.lblnumempleados.Location = new System.Drawing.Point(13, 408);
            this.lblnumempleados.Name = "lblnumempleados";
            this.lblnumempleados.Size = new System.Drawing.Size(0, 20);
            this.lblnumempleados.TabIndex = 14;
            // 
            // btnexaminar
            // 
            this.btnexaminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnexaminar.BackgroundImage")));
            this.btnexaminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnexaminar.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexaminar.Location = new System.Drawing.Point(494, 76);
            this.btnexaminar.Name = "btnexaminar";
            this.btnexaminar.Size = new System.Drawing.Size(24, 20);
            this.btnexaminar.TabIndex = 3;
            this.btnexaminar.UseVisualStyleBackColor = true;
            this.btnexaminar.Click += new System.EventHandler(this.btnexaminar_Click);
            // 
            // frmCargaDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(663, 484);
            this.Controls.Add(this.lblnumempleados);
            this.Controls.Add(this.pbarcarga);
            this.Controls.Add(this.lblmensaje);
            this.Controls.Add(this.gpbvalores);
            this.Controls.Add(this.griddatos);
            this.Controls.Add(this.btnexaminar);
            this.Controls.Add(this.lblnombreruta);
            this.Controls.Add(this.txtruta);
            this.Controls.Add(this.btncargar);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmCargaDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnviaNomina";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.griddatos)).EndInit();
            this.gpbvalores.ResumeLayout(false);
            this.gpbvalores.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncargar;
        private System.Windows.Forms.TextBox txtruta;
        private System.Windows.Forms.Label lblnombreruta;
        private System.Windows.Forms.Button btnexaminar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.DataGridView griddatos;
        private System.Windows.Forms.GroupBox gpbvalores;
        private System.Windows.Forms.Label lblestado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblmensaje;
        private System.Windows.Forms.ProgressBar pbarcarga;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblnumempleados;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
    }
}

