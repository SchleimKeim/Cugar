using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cugar
{
    public partial class frmMain : Form
    {
        #region loading settings into private members
        //Form mySettings = new frmSettings();
        private string m_caouser = Cugar.Properties.Settings.Default.caouser;
        private string m_caopw = Cugar.Properties.Settings.Default.caopw;
        private string m_caohost = Cugar.Properties.Settings.Default.caohost;
        private string m_caodb = Cugar.Properties.Settings.Default.caodb;

        private string m_sugaruser = Cugar.Properties.Settings.Default.sugaruser;
        private string m_sugarpw = Cugar.Properties.Settings.Default.sugarpw;
        private string m_sugarhost = Cugar.Properties.Settings.Default.sugarhost;
        private string m_sugardb = Cugar.Properties.Settings.Default.sugardb;
        #endregion

        #region members
        private DataSet m_dsMainCao;
        private int m_intCaoRow;
        private int m_intSugarRow;
        private CaoConnector myConCao;
        private SugarConnector myConSugar;
        #endregion


        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            if (Cugar.Properties.Settings.Default.first_start == true)
            {                
                frmSettings m_SubForm_Settings = new frmSettings();
                m_SubForm_Settings.ShowDialog();
                MessageBox.Show("Please Restart Cugar to load the mew settings.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //CToolbox m_Toolbox = new CToolbox();
                //m_Toolbox.RestartApplication();               
            }

            ConnectCao();

            ConnectSugar();

            //m_intCaoRow =             
            //txtName.Text = dgvCao[7, 0].Value;
            //txtStrasse1.Text = dgvCao["STRASSE", 0].Value.ToString();
        }

        private void ConnectSugar()
        {
            myConSugar = new SugarConnector(m_sugarhost, m_sugaruser, m_sugarpw, m_sugardb);
            dgvSugar.DataSource = myConSugar.dvSugarFirsRecord;
        }

        private void ConnectCao()
        {
            myConCao = new CaoConnector(m_caohost, m_caouser, m_caopw, m_caodb);
            dgvCao.DataSource = myConCao.dvCaoFirsRecord;
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings m_SubForm_Settings = new frmSettings();
            m_SubForm_Settings.ShowDialog();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
