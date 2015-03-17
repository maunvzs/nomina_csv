using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;

using System.Configuration;

namespace EnviaNomina
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private static frmConfiguracion form;

        public frmConfiguracion Get //Singleton
        {
            get
            {
                if (form == null || form.IsDisposed)
                    form = new frmConfiguracion();
                return form;
            }
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            form.Dispose();
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            txtusuario.Text = Settings.App.Default.usuario;
            txtsucursal.Text = Settings.App.Default.sucursal;
            txturl.Text = Settings.App.Default.url;
            numerictiempo.Value = decimal.Parse(TimeSpan.FromMilliseconds(Settings.App.Default.timeout).TotalMinutes.ToString());


            var t = new ToolTip();
            t.SetToolTip(btnaceptar, "Salir sin modificar la configuración");
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            //String reg = "^(http|https|ftp)\\://[a-zA-Z0-9\\-\\.]+\\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\\-\\._\\?\\,\'/\\\\+&amp;%\\$#\\=~])*$";

            if (txturl.Text == string.Empty || txtusuario.Text == string.Empty || txtsucursal.Text == string.Empty || txturl.Text == string.Empty)
                MessageBox.Show("Verfique los campos hay campos vacios");
                else if (numerictiempo.Value == 0)
                    MessageBox.Show("El tiempo de espera debe ser mayor a 0");
                /*
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txturl.Text, reg))
            {
                MessageBox.Show("URLInvalida");
            }*/
                //Validar conexiòn correcta
            else
            {
                Settings.App.Default.usuario = txtusuario.Text;
                Settings.App.Default.sucursal = txtsucursal.Text;
                Settings.App.Default.url = txturl.Text;
                Settings.App.Default.timeout = int.Parse(TimeSpan.FromMinutes(double.Parse(numerictiempo.Value.ToString())).TotalMilliseconds.ToString());
                Settings.App.Default.Save();
                MessageBox.Show("Datos guardados con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form.Dispose();
            }        
        }
    }
}
