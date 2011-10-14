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
        private string m_strSuchstring;

        public frmSuche(string suchstring)
        {
            InitializeComponent();
            m_strSuchstring = suchstring;
        }

        private void frmSuche_Load(object sender, EventArgs e)
        {
            rbName.Checked = true;
            rbStrasse.Checked = false;
            rbTelefon.Checked = false;
            txtSuche.Text = m_strSuchstring;
        }

        private void cmdSuche_Click(object sender, EventArgs e)
        {
            m_strSuchstring = txtSuche.Text;

            CaoConnector m_myCaoSearch = new CaoConnector(m_caohost, m_caouser, m_caopw, m_caodb);            
            dgvCaoSuche.DataSource = m_myCaoSearch.generate_dv_human(m_strSuchstring);
            

            SugarConnector m_mySugarSearch = new SugarConnector(m_sugarhost, m_sugaruser, m_sugarpw, m_sugardb);            
            dgvSugarSuche.DataSource = m_mySugarSearch.generate_dv_human(m_strSuchstring);
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            if (dgvCaoSuche.ColumnCount > 1)
            {
                dgvCaoSuche.DataSource = null;                
            }
            if (dgvSugarSuche.ColumnCount > 1)
            {
                dgvSugarSuche.DataSource = null;
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {

        }
    }
}
