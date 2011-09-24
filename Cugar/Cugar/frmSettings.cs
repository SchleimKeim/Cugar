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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_new_Load(object sender, EventArgs e)
        {
            txtCaoHost.Text = Cugar.Properties.Settings.Default.caohost;
            txtCaoPW.Text = Cugar.Properties.Settings.Default.caopw;
            txtCaoUser.Text = Cugar.Properties.Settings.Default.caouser;
            txtSugarHost.Text = Cugar.Properties.Settings.Default.sugarhost;
            txtSugarUser.Text = Cugar.Properties.Settings.Default.sugaruser;
            txtSugarPW.Text = Cugar.Properties.Settings.Default.sugarpw;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Cugar.Properties.Settings.Default.caohost = txtCaoHost.Text;
            Cugar.Properties.Settings.Default.caouser = txtCaoUser.Text;
            Cugar.Properties.Settings.Default.caopw = txtCaoPW.Text;

            Cugar.Properties.Settings.Default.sugarhost = txtSugarHost.Text;
            Cugar.Properties.Settings.Default.sugaruser = txtSugarUser.Text;
            Cugar.Properties.Settings.Default.sugarpw = txtSugarPW.Text;
            Cugar.Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
