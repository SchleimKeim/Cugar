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
    /* To Do HIGH PRIO:
     * - Find out how to "Load" from frmSuche.cs
     * that means: find a solution to combine two datasets into one and seperate them later
     * 
     * - Implement searching by street or p phone number
     * - Implement search for Companys
     * note: cao = select * from Adressen where Kundengruppe=2;
     * note: sugar = select * from accounts;
     * 
     * distinguish between company and private accounts
     * - Create Property in both connectors: bool Firma, Privat
     * - Create property in main.cs: bool Firma, Privat
     * - in main.cs set the property depending on active tab (Privat, Firma)
     * - implement main.cs cao sector
     * - implement main.cs sugar sector
     * 
     * To Do low prio: 
     * - implement Print function
     * - clean up main.cs (remove the two dgv tabs)
     * - set correct tabIndexes for usability
     * - clean up main.cs in general, menus etc...
     * 
     * 
     * To do very low prio:
     * complete xml documentation on all classes
     * 
     * 
     * **************
     * IDEAS:
     * **************
     * - Set preferred database
     * 
     * **************
     * CLEAN UP:
     * **************
     * - loading settings into members of main.cs because they are accessible by all classes in the project
     */

    public partial class frmMain : Form
    {
        #region loading settings into private members, probaply obsolete
        //Form mySettings = new frmSettings();
        //private string m_caouser = Cugar.Properties.Settings.Default.caouser;
        //private string m_caopw = Cugar.Properties.Settings.Default.caopw;
        //private string m_caohost = Cugar.Properties.Settings.Default.caohost;
        //private string m_caodb = Cugar.Properties.Settings.Default.caodb;

        //private string m_sugaruser = Cugar.Properties.Settings.Default.sugaruser;
        //private string m_sugarpw = Cugar.Properties.Settings.Default.sugarpw;
        //private string m_sugarhost = Cugar.Properties.Settings.Default.sugarhost;
        //private string m_sugardb = Cugar.Properties.Settings.Default.sugardb;
        #endregion

        #region members
        //private DataSet m_dsMainCao;
        //private int m_intCaoRows;
        //private int m_intSugarRows;
        //private DataSet m_dsCao;
        //private DataSet m_dsSugar;
        private DataView m_dvCao = new DataView();
        private DataView m_dvSugar;
        private CaoConnector myConCao;
        private SugarConnector myConSugar;
        private DataSet m_DS = new DataSet();
        private cCao m_objCao;
        private cSugar m_objSugar;
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
            }

            /* Fills out dgvCao */
            try
            {
                /* vorgang:
                 * neues cao objekt wird erstellt mit dem DataSet der main.cf
                 * die methode LoadDataSet() füllt das DataSet mit informationen 
                 * aus der Cao Datenbank
                 * das DataView der main.cf wird mit den tables aus dem DataSet der main.cf gefüllt
                 * dgv kriegt als source das DataView der main.cf
                 */

                m_objCao = new cCao(m_DS);
                m_objCao.LoadDataSet();
                m_dvCao = m_DS.Tables["tblCao"].DefaultView;
                dgvCao.DataSource = m_dvCao;
            }
            catch (Exception asdf)
            {
                MessageBox.Show(asdf.ToString());
                Application.Exit();
            }

            /* Fills out dgvSugar */
            try
            {
                m_objSugar = new cSugar(m_DS);
                m_objSugar.LoadDataSet();
                m_dvSugar = m_DS.Tables["tblSugar"].DefaultView;
                dgvSugar.DataSource = m_dvSugar;
            }
            catch (Exception asdf)
            {
                MessageBox.Show(asdf.ToString());
                Application.Exit();
            }
        }

        #region old connect sugar, obsolete!
        //private void ConnectSugar()
        //{
        //    #region old
        //    //myConSugar = new SugarConnector(m_sugarhost, m_sugaruser, m_sugarpw, m_sugardb);
        //    #endregion
        //    myConSugar = new SugarConnector(m_DS);
        //}
        #endregion

        #region old LoaddgvSugar, obsolete!
        private void loaddgvSugar()
        {
            dgvSugar.DataSource = myConSugar.dvSugar;
        }
        #endregion

        #region old connect cao, obsolete!
        //private void ConnectCao()
        //{
        //    myConCao = new CaoConnector(m_caohost, m_caouser, m_caopw, m_caodb);
        //    myConCao = new CaoConnector(m_myDS);
        //    m_objCao = new cCao(m_DS);

        //    try
        //    {
        //        loaddgvCao();
        //    }
        //    catch (Exception asdf)
        //    {
        //        MessageBox.Show(asdf.ToString());
        //        Application.Exit();
        //    }
        //}
        #endregion

        //private void loaddgvCao()
        //{
        //    dgvCao.DataSource = myConCao.dvCao;
        //}

        #region old LoadDGVCao(), obsolete!!
        //private void loaddgvCao()
        //{

        //    m_DS = m_objCao.ds;
        //    m_dvCao = m_DS.Tables["tblCao"].DefaultView;
        //    dgvCao.DataSource = m_dvCao;
        //    //m_dvCao = m_myDS.Tables["tblCao"].DefaultView;   
        //    //dgvCao.DataSource = myConCao.dvCao;
        //}
        #endregion

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

        
        private void tstxtSuche_Click(object sender, EventArgs e)
        {
            tstxtSuche.Clear();
        }

        private void tsCmdSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            //frmSuche m_objSuche = new frmSuche(m_DS, tstxtSuche.Text);
            frmSuche m_objSuche = new frmSuche(m_DS, tstxtSuche.Text, m_objCao, m_objSugar);
            //frmSuche m_objSuche = new frmSuche(m_DS, tstxtSuche.Text, m_objCao, m_objSugar);
            m_objSuche.ShowDialog();
        }

        private void tstxtSuche_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }

        }

        private void hilfeToolStripButton_Click(object sender, EventArgs e)
        {
            StringBuilder foo = new StringBuilder();
            foo.Append("Aktuelle Anzahl Tabellen im DataSet m_DS: ");
            foo.Append(m_DS.Tables.Count.ToString());
            MessageBox.Show(foo.ToString());
        }

        //private void tstxtSuche_Enter(object sender, EventArgs e)
        //{
        //    Search();
        //}

        //private void tstxtSuche_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}
