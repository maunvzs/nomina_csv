using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace EnviaNomina
{
    public partial class frmAcercaDe : Form
    {
        public frmAcercaDe()
        {
            InitializeComponent();
        }


        private static frmAcercaDe form;

        public frmAcercaDe Get
        {
            get
            {
                if (form == null || form.IsDisposed)
                    form = new frmAcercaDe();
                return form;
            }
        }


        private void frmAcercaDe_Load(object sender, EventArgs e)
        {
            var o = Assembly.GetExecutingAssembly().GetName().Version;
            lblversion.Text += " " + o;
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            form.Dispose();
        }
    }
}
