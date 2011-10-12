using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cugar
{
    public partial class frmSuche : Form
    {
        private string m_strSuchstring;

        public frmSuche()
        {
            InitializeComponent();
        }

        private void frmSuche_Load(object sender, EventArgs e)
        {
            rbName.Checked = true;
            rbStrasse.Checked = false;
            rbTelefon.Checked = false;
        }
    }
}
