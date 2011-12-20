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

        bool sugarok = false;
        bool caook = false;

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

        /// <summary>
        /// Checks if the settings are valid or not. If not it just returns a warning
        /// just because i don't have enough time to finish this stuff.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (sugarok != true && caook != true)
            {
                MessageBox.Show("Die Einstellungen wurden nicht getestet. \nCugar wird möglicherweise nicht funktionieren!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// Saves the necessary connection information into AppData.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {           
            Cugar.Properties.Settings.Default.first_start = false;
            Cugar.Properties.Settings.Default.Save();
            Cugar.Properties.Settings.Default.Upgrade();
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            Cugar.Properties.Settings.Default.caohost = txtCaoHost.Text;
            Cugar.Properties.Settings.Default.caouser = txtCaoUser.Text;
            Cugar.Properties.Settings.Default.caopw = txtCaoPW.Text;

            Cugar.Properties.Settings.Default.sugarhost = txtSugarHost.Text;
            Cugar.Properties.Settings.Default.sugaruser = txtSugarUser.Text;
            Cugar.Properties.Settings.Default.sugarpw = txtSugarPW.Text;

            Cugar.Properties.Settings.Default.Save();
            Cugar.Properties.Settings.Default.Upgrade();

            DataSet m_ds = new DataSet();
            cCao m_objCao = new cCao(m_ds);

            /* Test Cao connection */
            if (m_objCao.testConnection == true)
            {
                /* on Success show a Message and save the success into caook */
                MessageBox.Show("Cao Verbindung erfolgreich getestet.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                caook = true;
            }
            else
            {
                MessageBox.Show("Fehler in Cao Verbindung. \n Bitte überprüfen Sie die Einstellungen!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /* Test Sugar Connection */
            cSugar m_objSugar = new cSugar(m_ds);
            if (m_objSugar.testConnection == true)
            {
                /* on success display a message and save the success into sugarok */
                MessageBox.Show("Sugar Verbindung erfolgreich getestet.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                sugarok = true;
            }
            else
            {
                MessageBox.Show("Fehler in Sugar Verbindung. \n Bitte überprüfen Sie die Einstellungen!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (caook == true && sugarok == true)
            {
                /* the user may only save hes settings if both settings are correct */
                MessageBox.Show("Beide Verbindungen erfolgreich getestet. Klicken Sie auf Speichern um fortzufahren...", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmdSave.Enabled = true;
            }

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
