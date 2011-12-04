using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Diagnostics;
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
            txtCaoDBName.Text = Cugar.Properties.Settings.Default.caodb;
            txtSugarHost.Text = Cugar.Properties.Settings.Default.sugarhost;
            txtSugarUser.Text = Cugar.Properties.Settings.Default.sugaruser;
            txtSugarPW.Text = Cugar.Properties.Settings.Default.sugarpw;
            txtSugarDBName.Text = Cugar.Properties.Settings.Default.sugardb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Saves the necessary connection information into AppData.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {           
            Cugar.Properties.Settings.Default.caohost = txtCaoHost.Text;
            Cugar.Properties.Settings.Default.caouser = txtCaoUser.Text;
            Cugar.Properties.Settings.Default.caopw = txtCaoPW.Text;

            Cugar.Properties.Settings.Default.sugarhost = txtSugarHost.Text;
            Cugar.Properties.Settings.Default.sugaruser = txtSugarUser.Text;
            Cugar.Properties.Settings.Default.sugarpw = txtSugarPW.Text;

            Cugar.Properties.Settings.Default.first_start = false;
            Cugar.Properties.Settings.Default.Save();
            Cugar.Properties.Settings.Default.Upgrade();

            //RestartApplication();            
        }

        //private static void RestartApplication()
        //{
        //    // log exception somewhere, EventLog is one option
        //    // MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //    Process.Start(Application.ExecutablePath);
        //    Application.Exit();
        //}
    }
}
