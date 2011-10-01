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

        private DataSet m_dsMainCao;


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

            CaoConnector myConCao = new CaoConnector(m_caohost, m_caouser, m_caopw, m_caodb);
            

//            myConCao.ConnectCao(m_caouser, m_caopw, m_caohost, m_caodb);
//            CDatabasecon myConSugar = new CDatabasecon();
            //myConSugar.ConnectSugar(m_sugaruser, m_sugarpw, m_sugarhost, m_sugardb);

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
