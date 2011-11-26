using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc; //remove afterwards!
using MySql.Data.MySqlClient;

namespace Cugar
{
    /* **************************
     * 14.11.2011 New ToDo list:
     * **************************
     * - Insert Companys (prepare @ school)
     * - Update Records
     * - clean up main.cs
     * 
     * 
     * 3.11.2011
     * *********************
     * REMOVE TXTSTRASSE 2 UND 3
     * add name 2 und 3
     * clean up vorname, nachname!!
     * 
     * To Do HIGH PRIO:
     * - Find out how to "Load" from frmSuche.cs
     * current status of this issue:
     * every search result gets loadet into the dataset m_DS under "tbl$DBNAMESearchAll" or "tbl$DBNAMESearchHuman"
     * when using the update command i just have to pass the DataSet from main.cf with the corresponding Table Name!
     * That means Updating the Databases shoudln't be a Problem anymore.
     * Now i have to find out the following: 
     * 
     * ********************************
     * cmdLoad in frmSearch:
     * ********************************
     * * What happens when the user loads two Corresponding Datasets into the main.cf?     *
     *first: there should be a comparison and if to many attributes are different then there is an error.
     * -> compare name AND Street, this should be save enough. -> CompareRows()
     * -> 1. load the corresponding cao (or sugar, depends on the settings) dataset into main.cf -> LoadMainTexts()
     * -> 2. fill out cao section -> fillCao();
     * -> 3. fill out Sugar section -> fillSugar();
     * 
     * use onChange() events to recognise the changes
     * When the user saves the record there has got to be a cCao.UpdateRecord() and a cSugar.UpdateRecord()
     * 
     * 
     * *******************************
     * Creating a new record
     * *******************************
     * -> user clicks toolStrip New()
     * -> frmNeu Appears
     * -> User edits the textfields and clicks "Save"
     * -> use (and first: create) a cCao.Insert() and a cSugar.Inser() routine.
     * 
     * 
     * ******************************
     * Deleting a record
     * ******************************
     * This has the least priority due to the fact that practically no Record gets deleted at CalandaComp
     * -> cCao.Delete() and cSugar.Delete()
     * 
     * 
     * 
     * 
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
     * 
     * 
     * *******************
     * READ ME ON SUNDAY!
     * *******************
     * - get loading out of frm search working!
     * 
     * 
     * 
     * 
     * ********************
     * QUESTIONS
     * ********************
     * how to public void DatensatzLaden()
     * :(
     * 
     * 
     */

    public partial class frmMain : Form
    {
        #region members

        private DataView m_dvCao;
        private DataView m_dvSugar;

        private DataSet m_DS = new DataSet();
        private cCao m_objCao;
        private cSugar m_objSugar;

        private DataTable m_dtDatensatzCao;
        private DataTable m_dtDatensatzSugar;
        
        private const string m_const_strSugarTable = "tblSugar";
        private const string m_const_strCaoTable = "tblCao";

        private const string m_const_strCaoTablePrivate = "tblCaoPrivate";
        private const string m_const_strSugarTablePrivate = "tblSugarContacts";

        private const string m_const_strCaoTableSearchAllPrivate = "tblCaoSearchAllPrivate";
        private const string m_const_strCaoTableSearchAllCompanies = "tblCaoSearchAllCompanies";
        private const string m_const_strSugarTableSearchAllPrivate = "tblSugarSearchAllPrivate";
        private const string m_const_strSugarTableSearchAllCompanies = "tblSugarSearchAllCompanies";

        private const string m_const_strCaoTableSearchHuman = "tblCaoSearchHuman";
        private const string m_const_strSugarTableSearchHuman = "tblSugarSearchHuman";

        private const string m_const_strCaoVersandarten = "tblCaoVersandarten";
        private const string m_const_strCaoZahlarten = "tblCaoZahlarten";

        private const string m_const_strAktuellerCaoDatensatz = "tblCaoSelected";
        private const string m_const_strAktuellerSugarDatensatz = "tblSugarSelected";

        /* binding sources */
        private BindingSource m_BS_CaoSearchContacts = new BindingSource();
        private BindingSource m_BS_CaoSearchFirma = new BindingSource();
        private BindingSource m_BS_SugarSearchContacts = new BindingSource();
        private BindingSource m_BS_SugarSearchFirma = new BindingSource();
        
        //private BindingSource m_BS_CaoZahlarten = new BindingSource();
        //private BindingSource m_BS_CaoVersandarten = new BindingSource();

        private bool m_bNew = false;

        #endregion


        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /* If its the first start show frmSettings */
            if (Cugar.Properties.Settings.Default.first_start == true)
            {                
                frmSettings m_SubForm_Settings = new frmSettings();
                m_SubForm_Settings.ShowDialog();
                MessageBox.Show("Please Restart Cugar to load the mew settings.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);             
            }

            if (m_DS.Tables.Count == 0)
            {
                #region prepare cCao Object and cSugar Object
                try
                {
                    m_objCao = new cCao(m_DS);

                    #region obsolete
                    /* vorgang:
                     * neues cao objekt wird erstellt mit dem DataSet der main.cf
                     * die methode LoadDataSet() fllt das DataSet mit informationen 
                     * aus der Cao Datenbank
                     * das DataView der main.cf wird mit den tables aus dem DataSet der main.cf gefllt
                     * dgv kriegt als source das DataView der main.cf
                     */

                    //m_objCao = new cCao(m_DS);

                    //searchme
                    //m_objCao = new cCao(m_DS, m_BS_CaoSearchContacts);
                    //m_objCao = new cCao(m_DS);
                    

                    //load all private customers, propably obsolete but good
                    //m_objCao.LoadPrivateCustomers();
                    //m_dvCao = m_DS.Tables[m_const_strCaoTablePrivate].DefaultView;
                    //dgvCao.DataSource = m_dvCao;

                    //load cbo Versandarten, currently not working :(
                    #endregion
                }
                catch (Exception asdf)
                {
                    MessageBox.Show(asdf.ToString());
                    Application.Exit();
                }

                try
                {
                    m_objSugar = new cSugar(m_DS);
                    #region obsolete
                    //searchme 
                    //m_objSugar = new cSugar(m_DS, m_BS_SugarSearchContacts);
                    //m_objSugar = new cSugar(m_DS);
                    //m_objSugar.LoadPrivateCustomers();
                    //m_dvSugar = m_DS.Tables[m_const_strSugarTablePrivate].DefaultView;
                    //dgvSugar.DataSource = m_dvSugar;
                    #endregion
                }
                catch (Exception asdf)
                {
                    MessageBox.Show("Ein Fehler ist aufgetreten!\n Bitte berprfen Sie die Einstellungen!");
                    MessageBox.Show(asdf.ToString());
                    Application.Exit();
                }
                #endregion

                /* Versandarten ausfüllen */
                LoadCaoVersandArten();                
                cboCaoVersand.SelectedIndex = 0;

                /* zahlunggsarten ausfüllen */
                LoadCaoZahlungsarten();                
                cboCaoZahlart.SelectedIndex = 0;                

            }
            // Prepare cbos
            cboAnrede.SelectedIndex = 0;
            cboFAnrede.SelectedIndex = 0;
            cboFSugarType.SelectedIndex = 0;
            cboFCaoBriefanrede.SelectedIndex = 0;
            cboFSugarType.SelectedIndex = 0;
            cboCaoBriefanrede.SelectedIndex = 0;
        }
        /// <summary>
        /// Loads "Cao Versandarten" in the cbos
        /// in tabMain.tabPrivat and tabMain.tabCompany
        /// and sets the SelectedIndex = 0
        /// </summary>
        private void LoadCaoVersandArten()
        {
            #region testing to fill it without cCao, works but its not beautiful :(            
            StringBuilder m_sCaoConnect = new StringBuilder();
            #region connection string for odbc
            m_sCaoConnect.Append("Driver={MySQL ODBC 5.1 Driver};");
            m_sCaoConnect.Append("Server=" + Cugar.Properties.Settings.Default.caohost + ";");
            m_sCaoConnect.Append("Database=" + Cugar.Properties.Settings.Default.caodb + ";");
            m_sCaoConnect.Append("User=" + Cugar.Properties.Settings.Default.caouser + ";");
            m_sCaoConnect.Append("Password=" + Cugar.Properties.Settings.Default.caopw + ";");
            m_sCaoConnect.Append("Option=3");
            #endregion
            OdbcConnection m_cnFoo = new OdbcConnection(m_sCaoConnect.ToString());            


            int spalten_nr = 0; //Nummer der Spalte, in der das gewnschte Element steht
            OdbcCommand cmd = new OdbcCommand(@"select NAME from registry where MAINKEY='MAIN\\LIEFART' order by VAL_INT;", m_cnFoo);
            
            cmd.Connection = m_cnFoo;
            m_cnFoo.Open();
            cboCaoVersand.Items.Clear();
            
            OdbcDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboCaoVersand.Items.Add(dr.GetValue(spalten_nr).ToString());
                cboFVersand.Items.Add(dr.GetValue(spalten_nr).ToString());
            }
            dr.Close();
            m_cnFoo.Close();
            cboCaoVersand.SelectedIndex = 0;
            cboFVersand.SelectedIndex = 0;
            #endregion
        }

        /// <summary>
        /// Loads "Cao Zahlungsarten" in the cbos
        /// in tabMain.tabPrivat and tabMain.tabCompany
        /// and sets the SelectedIndex = 0
        /// </summary>
        private void LoadCaoZahlungsarten()
        {
            #region testing to fill it without cCao, works but its not beautiful :(
            StringBuilder m_sCaoConnect = new StringBuilder();
            #region connection string for odbc
            m_sCaoConnect.Append("Driver={MySQL ODBC 5.1 Driver};");
            m_sCaoConnect.Append("Server=" + Cugar.Properties.Settings.Default.caohost + ";");
            m_sCaoConnect.Append("Database=" + Cugar.Properties.Settings.Default.caodb + ";");
            m_sCaoConnect.Append("User=" + Cugar.Properties.Settings.Default.caouser + ";");
            m_sCaoConnect.Append("Password=" + Cugar.Properties.Settings.Default.caopw + ";");
            m_sCaoConnect.Append("Option=3");
            #endregion
            OdbcConnection m_cnFoo = new OdbcConnection(m_sCaoConnect.ToString());

            
            int spalten_nr = 0; //Nummer der Spalte, in der das gewnschte Element steht
            OdbcCommand cmd = new OdbcCommand(@"select NAME from ZAHLUNGSARTEN;", m_cnFoo);

            cmd.Connection = m_cnFoo;
            m_cnFoo.Open();
            
            cboCaoZahlart.Items.Clear();
            OdbcDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboCaoZahlart.Items.Add(dr.GetValue(spalten_nr).ToString());                
                cboFZahlart.Items.Add(dr.GetValue(spalten_nr).ToString());                
            }
            dr.Close();
            m_cnFoo.Close();
            cboCaoZahlart.SelectedIndex = 0;
            cboFZahlart.SelectedIndex = 0;
            #endregion
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
            PrepareNew();
        }

        #region obsolete
        //private void tstxtSuche_Click(object sender, EventArgs e)
        //{
        //    tstxtSuchePrivat.Clear();
        //}

        //private void tsCmdSearch_Click(object sender, EventArgs e)
        //{
        //    SearchPrivat();
        //}
        #endregion

        /// <summary>
        /// Creates a new frmSuche and starts a new 
        /// search for private contacts.
        /// </summary>
        private void SearchPrivat()
        {
            //frmSuche m_objSuche = new frmSuche(m_DS, tstxtSuche.Text);
            frmSuche m_objSuche = new frmSuche(m_DS, tstxtSuchePrivat.Text, m_objCao, m_objSugar, this, m_BS_CaoSearchContacts, m_BS_SugarSearchContacts);
            m_objSuche.Privat = true;
            //m_objSuche.StartSearchPrivat(tstxtSuchePrivat.Text);
            //frmSuche m_objSuche = new frmSuche(m_DS, tstxtSuche.Text, m_objCao, m_objSugar);            
            m_objSuche.ShowDialog();      
        }

        //private void tstxtSuche_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        SearchPrivat();
        //    }

        //}

        /// <summary>
        /// This Action is just implemented for debugging.
        /// Basically it just shows how many Tables are in the DataSet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hilfeToolStripButton_Click(object sender, EventArgs e)
        {
            if (m_dtDatensatzCao == null)
            {
                int i = 0;
                StringBuilder foo = new StringBuilder();
                foo.Append("Aktuelle Anzahl Tabellen im DataSet m_DS: ");
                foo.Append(m_DS.Tables.Count.ToString());
                foo.Append(" DataTables\n");
                foo.Append("Liste:\n");
                foreach (DataTable dt in m_DS.Tables)
                {
                    foo.Append(m_DS.Tables[i].TableName);
                    foo.Append("\n");
                    i++;
                }
                MessageBox.Show(foo.ToString());
            }
            else
            {
                StringBuilder foo = new StringBuilder();
                foo.Append("Aktuelle Anzahl Tabellen im DataSet m_DS: ");
                foo.Append(m_DS.Tables.Count.ToString());
                foo.Append(" DataTables\n");
                foo.Append("Geladene Datensätze in m_Datensatz: ");
                foo.Append(m_dtDatensatzCao.Rows.Count.ToString());
                MessageBox.Show(foo.ToString());
            }
        }
        /// <summary>
        /// Fills all the textfields with values from the current
        /// selected DataRow out of the BindingSource. (tblSearch*Contacts)
        /// </summary>
        public void DatensatzLadenPrivate()
        {
            tabMain.SelectedTab = tabContacts;
            #region snippet, obsolete
            /* snippet:
             * textBox.DataBindings.Add("Text", ds.Tables["Products"], "ProductName"); */
            //txtName.DataBindings.Add(
            //m_DS.Tables[m_const_strCaoTableSearchHuman].Rows[0];
            //txtName.Text = m_DS.Tables[m_const_strCaoTableSearchAll].Rows[0][1].ToString
            //txtName.DataBindings.Add(m_BS);
            //MessageBox.Show(m_BS.Position.ToString());
            //MessageBox.Show(m_DS.Tables[m_const_strCaoTableSearchAll].Rows[m_BS.Position]["Name1"].ToString());
            //if (m_BS.Current != null)
            //    MessageBox.Show( ((DataRowView)m_BS.Current)["Name1"].ToString());
            #endregion 
            if (m_BS_CaoSearchContacts.Current != null)
            {
                //tabCompanies.
                //set searchtext to personen
                tstxtSuchePrivat.Text = "Personen...";

                #region Convert the name filed into two fields using CToolbox
                cToolbox m_objTool = new cToolbox();                
                string[] foo2;                
                foo2 = m_objTool.SplitName(((DataRowView)m_BS_CaoSearchContacts.Current)["NAME1"].ToString());
                txtVorname.Text = foo2[0];
                txtName.Text = foo2[1];
                #endregion

                #region fill cbos and set them to the right index
                // set cboCaoVersand to the right index
                int VerdsandId = 0;
                VerdsandId = Convert.ToInt32(((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_LIEFART"]);
                cboCaoVersand.SelectedIndex = VerdsandId - 1;

                //set cboCaoZahlart to the right index
                int ZahlartId = 0;
                ZahlartId = Convert.ToInt32(((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_ZAHLART"]);
                cboCaoZahlart.SelectedIndex = ZahlartId - 1;
                #endregion

                /* Fills in all the textfield using databinding object casted into a datarowview */
                txtName2.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["NAME2"].ToString();
                txtName3.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["NAME3"].ToString();
                cboAnrede.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["ANREDE"].ToString();         
                txtStrasse1.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["STRASSE"].ToString();
                txtPLZ.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["PLZ"].ToString();
                txtOrt.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["ORT"].ToString();                
                txtWebpage.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["INTERNET"].ToString();
                txtEmail.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["EMAIL"].ToString();
                txtFax.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["FAX"].ToString();
                txtMobile.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["FUNK"].ToString();
                txtPhon2.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["TELE2"].ToString();
                txtPhone1.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["TELE1"].ToString();
                cboCaoBriefanrede.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["BRIEFANREDE"].ToString();
                txtCaoZahlungsziel.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["BRT_TAGE"].ToString();

                txtCaoCustomerSince.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_SEIT"].ToString();
                //dtpKunSeit.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_SEIT"].ToString();
                txtCaoGeb.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_GEBDATUM"].ToString();
                txtBemerkung.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["INFO"].ToString();

                //((DataRowView)m_BS_CaoSearchContacts.Current)["INFO"] = txtBemerkung.Text;
                
                //txtSugarZugewiesenAn.Text = ((DataRowView)m_BS.Current)[].ToString();
                txtSugarLand.Text = ((DataRowView)m_BS_SugarSearchContacts.Current)["primary_address_country"].ToString();
                txtSugarLeadSource.Text = ((DataRowView)m_BS_SugarSearchContacts.Current)["lead_source"].ToString();
                txtSugarAbteilung.Text = ((DataRowView)m_BS_SugarSearchContacts.Current)["department"].ToString();
                txtSugarTitle.Text = ((DataRowView)m_BS_SugarSearchContacts.Current)["title"].ToString();
            }            

            //((DataRowView)m_BS.Current)["NAME1"] = txtName.Text;
            //((DataRowView)m_BS_Sugar.Current)["last_name"] = 
            //m_BS.Current
        }

        /// <summary>
        /// Fills all the textfields with values from the current
        /// selected DataRow out of the BindingSource. (tblSearch*Companies)
        /// </summary>
        public void DatensatzLadenCompany()
        {
            tabMain.SelectedTab = tabCompanies;
            if (m_BS_CaoSearchFirma.Current != null)
            {
                //m_BS_CaoSearchFirma
                //reset ts textfields
                tstxtSuchePrivat.Text = "Personen...";
                tstxtSucheFirma.Text = "Firmen...";

                #region fill cbos and set them to the right index
                // set cboCaoVersand to the right index
                int VerdsandId = 0;
                VerdsandId = Convert.ToInt32(((DataRowView)m_BS_CaoSearchFirma.Current)["KUN_LIEFART"]);
                cboFVersand.SelectedIndex = VerdsandId - 1;

                //set cboCaoZahlart to the right index
                int ZahlartId = 0;
                ZahlartId = Convert.ToInt32(((DataRowView)m_BS_CaoSearchFirma.Current)["KUN_ZAHLART"]);
                cboFZahlart.SelectedIndex = ZahlartId - 1;
                #endregion

                /* Fills in all the textfield using databinding object casted into a datarowview */

                cboFAnrede.Text = ((DataRowView)m_BS_CaoSearchFirma.Current)["ANREDE"].ToString();
                txtFName1.Text = ((DataRowView)m_BS_CaoSearchFirma.Current)["NAME1"].ToString();
                txtFStrasse.Text = ((DataRowView)m_BS_CaoSearchFirma.Current)["STRASSE"].ToString();
                txtFPLZ.Text = ((DataRowView)m_BS_CaoSearchFirma.Current)["PLZ"].ToString();
                txtFOrt.Text = ((DataRowView)m_BS_CaoSearchFirma.Current)["ORT"].ToString();
                txtFWeb.Text = ((DataRowView)m_BS_CaoSearchFirma.Current)["INTERNET"].ToString();
                txtFMail.Text = ((DataRowView)m_BS_CaoSearchFirma.Current)["EMAIL"].ToString();
                txtFFax.Text = ((DataRowView)m_BS_CaoSearchFirma.Current)["FAX"].ToString();
                txtFPhone.Text = ((DataRowView)m_BS_CaoSearchFirma.Current)["TELE1"].ToString();
                cboFCaoBriefanrede.Text = ((DataRowView)m_BS_CaoSearchFirma.Current)["BRIEFANREDE"].ToString();
                txtFZahlungsziel.Text = ((DataRowView)m_BS_CaoSearchFirma.Current)["BRT_TAGE"].ToString();
                txtFKunSeit.Text = ((DataRowView)m_BS_CaoSearchFirma.Current)["KUN_SEIT"].ToString();
                txtFBemerkung.Text = ((DataRowView)m_BS_CaoSearchFirma.Current)["INFO"].ToString();

                if (m_DS.Tables.Contains(m_const_strSugarTableSearchAllCompanies) == true)
                {
                    cboFSugarType.Text = ((DataRowView)m_BS_SugarSearchFirma.Current)["account_type"].ToString();
                    txtFSugarBranche.Text = ((DataRowView)m_BS_SugarSearchFirma.Current)["industry"].ToString();
                    txtFSugarUmsatz.Text = ((DataRowView)m_BS_SugarSearchFirma.Current)["annual_revenue"].ToString();
                    txtFSugarMitarbeiter.Text = ((DataRowView)m_BS_SugarSearchFirma.Current)["employees"].ToString();
                    txtFSugarLand.Text = ((DataRowView)m_BS_SugarSearchFirma.Current)["billing_address_country"].ToString();
                }
                //((DataRowView)m_BS_CaoSearchFirma.Current)["INFO"] = txtBemerkung.Text;

            }

            //((DataRowView)m_BS.Current)["NAME1"] = txtName.Text;
            //((DataRowView)m_BS_Sugar.Current)["last_name"] = 
            //m_BS.Current

        }

        //private void tstxtSuche_Enter(object sender, EventArgs e)
        //{
        //    Search();
        //}

        //private void tstxtSuche_TextChanged(object sender, EventArgs e)
        //{

        //}
        #region propertys

        /* both dtDatensatz* propertys aren't finished! */
        public DataTable dtDatensatzCao
        {
            get
            {
                return m_dtDatensatzCao;
            }
            set
            {
                m_dtDatensatzCao = value;
            }
        }
        public DataTable dtDatensatzSugar
        {
            get
            {
                return m_dtDatensatzSugar;
            }
            set
            {
                m_dtDatensatzSugar = value;
            }
        }

        private void txtCaoVersand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///Enables the Save Button on the "Privat" tab</summary>
        public void EnableSave()
        {
            if (cmdSave.Enabled == false)
            {
                cmdSave.Enabled = true;
            }
        }

        private void cmdPrivatExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        
        //public DataTable dtDatensatzSugar
        //{
        //    get
        //    {
        //        return m_dtDatensatzSugar;
        //    }
        //    set
        //    {
        //        m_dtDatensatzSugar = value;
        //    }
        //}

        //public DataTable dtDatensatzSugar
        //{
        //    get
        //    {
        //        return m_dtDatensatzSugar;
        //    }
        //    set
        //    {
        //        m_dtDatensatzSugar = value;
        //    }
        //}

        public bool SaveButtonEnabled
        {
            get
            {
                return cmdSave.Enabled;
            }
            set
            {
                cmdSave.Enabled = value;
            }
        }

        #endregion

        private void cmdPrivatSave_Click(object sender, EventArgs e)
        {
            if (m_bNew == true)
            {
                if (tabMain.SelectedTab == tabContacts)
                {
                    CaoInsertPrivat();
                    SugarInsertPrivat();
                    m_bNew = false;
                    cmdSave.Enabled = false;
                }
                else if (tabMain.SelectedTab == tabCompanies)
                {
                    CaoInsertFirma();
                    SugarInsertFirma();
                    m_bNew = false;
                    cmdSave.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Keine Daten eingefügt.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);             
                    m_bNew = false;
                    cmdSave.Enabled = false;
                }
            }
            else
            {
                if (tabMain.SelectedTab == tabContacts)
                {
                    UpdateContactCao();
                    //UpdateContactSugar();
                }
                else if (tabMain.SelectedTab == tabCompanies)
                {
                    //UpdateCompanyCao();
                    //UpdateCompanySugar();
                }
                else
                {
                }
            }

    
            ////Routine für Update vorgang
            //m_DS.AcceptChanges();
            //if (m_DS.HasChanges())
            //{
            //    MessageBox.Show("Änderungen :D");
            //}
            //else
            //{
            //    MessageBox.Show("Keine Änderungen :(");
            //}
            //cCao m_objCao = new cCao(m_DS, m_BS_CaoSearchContacts);
            //m_objCao.UpdateAll();

        }

        /// <summary>
        /// Creates a new Cao record.
        /// </summary>
        private void CaoInsertPrivat()
        {
            if (m_bNew == true)
            {
                /* - create insert command text
                 * - create command itself
                 * - set all parameters for the values */

                #region Insert Command Text
                StringBuilder sb_CaoInsert = new StringBuilder();
                sb_CaoInsert.Append("INSERT INTO adressen(");
                sb_CaoInsert.Append("REC_ID, ");
                sb_CaoInsert.Append("KUNDENGRUPPE, ");
                sb_CaoInsert.Append("NAME1, ");
                sb_CaoInsert.Append("PLZ, ");
                sb_CaoInsert.Append("ORT, ");
                sb_CaoInsert.Append("ANREDE, ");
                sb_CaoInsert.Append("STRASSE, ");
                sb_CaoInsert.Append("TELE1, ");
                sb_CaoInsert.Append("TELE2, ");
                sb_CaoInsert.Append("FAX, ");
                sb_CaoInsert.Append("FUNK, ");
                sb_CaoInsert.Append("EMAIL, ");
                sb_CaoInsert.Append("INTERNET, ");
                sb_CaoInsert.Append("BRIEFANREDE, ");
                sb_CaoInsert.Append("BRT_TAGE, ");
                sb_CaoInsert.Append("INFO, ");
                sb_CaoInsert.Append("KUN_LIEFART, ");
                sb_CaoInsert.Append("KUN_SEIT, ");
                sb_CaoInsert.Append("GEAEND_NAME, ");
                sb_CaoInsert.Append("KUN_ZAHLART, ");
                sb_CaoInsert.Append(@"BRUTTO_FLAG)");
                sb_CaoInsert.Append(@" VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");
                #endregion
                OdbcCommand caoInsert = new OdbcCommand(sb_CaoInsert.ToString(), m_objCao.CaoConnection);

                #region parameters
                caoInsert.Parameters.Add("@REC_ID", OdbcType.Int, 11, "@REC_ID");
                caoInsert.Parameters["@REC_ID"].Value = m_objCao.LatestRecId;
                caoInsert.Parameters.Add("@KUNDENGRUPPE", OdbcType.Int, 11, "@KUNDENGRUPPE");
                caoInsert.Parameters["@KUNDENGRUPPE"].Value = 1;

                caoInsert.Parameters.Add("@NAME1", OdbcType.VarChar, 40, "@NAME1");
                cToolbox tool = new cToolbox();
                caoInsert.Parameters["@NAME1"].Value = tool.UniteName(txtVorname.Text, txtName.Text);

                caoInsert.Parameters.Add("@PLZ", OdbcType.VarChar, 10, "@PLZ");
                caoInsert.Parameters["@PLZ"].Value = txtPLZ.Text;
                caoInsert.Parameters.Add("@ORT", OdbcType.VarChar, 40, "@ORT");
                caoInsert.Parameters["@ORT"].Value = txtOrt.Text;
                caoInsert.Parameters.Add("@ANREDE", OdbcType.VarChar, 40, "@ANREDE");
                caoInsert.Parameters["@ANREDE"].Value = cboAnrede.Text;
                caoInsert.Parameters.Add("@STRASSE", OdbcType.VarChar, 40, "@STRASSE");
                caoInsert.Parameters["@STRASSE"].Value = txtStrasse1.Text;
                caoInsert.Parameters.Add("@TELE1", OdbcType.VarChar, 100, "@TELE1");
                caoInsert.Parameters["@TELE1"].Value = txtPhone1.Text;
                caoInsert.Parameters.Add("@TELE2", OdbcType.VarChar, 100, "@TELE2");
                caoInsert.Parameters["@TELE2"].Value = txtPhon2.Text;
                caoInsert.Parameters.Add("@FAX", OdbcType.VarChar, 100, "@FAX");
                caoInsert.Parameters["@FAX"].Value = txtFax.Text;
                caoInsert.Parameters.Add("@FUNK", OdbcType.VarChar, 100, "@FUNK");
                caoInsert.Parameters["@FUNK"].Value = txtMobile.Text;
                caoInsert.Parameters.Add("@EMAIL", OdbcType.VarChar, 100, "@EMAIL");
                caoInsert.Parameters["@EMAIL"].Value = txtEmail.Text;
                caoInsert.Parameters.Add("@INTERNET", OdbcType.VarChar, 100, "@INTERNET");
                caoInsert.Parameters["@INTERNET"].Value = txtWebpage.Text;
                caoInsert.Parameters.Add("@BRIEFANREDE", OdbcType.VarChar, 100, "@BRIEFANREDE");
                caoInsert.Parameters["@BRIEFANREDE"].Value = cboCaoBriefanrede.Text;

                

                caoInsert.Parameters.Add("@BRT_TAGE", OdbcType.TinyInt, 4, "@BRT_TAGE");
                if (txtCaoZahlungsziel.Text == "")
                {
                    caoInsert.Parameters["@BRT_TAGE"].Value = 30;
                }
                else
                {
                    caoInsert.Parameters["@BRT_TAGE"].Value = Convert.ToInt16(txtCaoZahlungsziel.Text);
                }

                caoInsert.Parameters.Add("@INFO", OdbcType.Text, 65537, "@INFO");
                caoInsert.Parameters["@INFO"].Value = txtBemerkung.Text;
                caoInsert.Parameters.Add("@KUN_LIEFART", OdbcType.Int, 11, "@KUN_LIEFART");
                caoInsert.Parameters["@KUN_LIEFART"].Value = cboCaoVersand.SelectedIndex + 1;
                caoInsert.Parameters.Add("@KUN_SEIT", OdbcType.Date);
                caoInsert.Parameters["@KUN_SEIT"].Value = DateTime.Today.ToShortDateString();
                caoInsert.Parameters.Add("@GEAND_NAME", OdbcType.VarChar, 20, "@GEAND_NAME");
                caoInsert.Parameters["@GEAND_NAME"].Value = "Cugar";

                caoInsert.Parameters.Add("@KUN_ZAHLART", OdbcType.Int, 11, "@KUN_ZAHLART");
                caoInsert.Parameters["@KUN_ZAHLART"].Value = cboCaoZahlart.SelectedIndex + 1;
                caoInsert.Parameters.Add("@BRUTTO_FLAG", OdbcType.Char, 2, "@BRUTTO_FLAG");
                caoInsert.Parameters["@BRUTTO_FLAG"].Value = 'Y';
                #endregion
                try
                {
                    caoInsert.ExecuteNonQuery();
                }
                catch (Exception asdf)
                {
                    MessageBox.Show(asdf.ToString());
                    throw;
                }

            }
        }

        /// <summary>
        /// Creates a new Sugar record.
        /// </summary>
        private void SugarInsertPrivat()
        {
            if (m_bNew == true)
            {

                #region Insert Command Text
                if (m_objSugar.SugarConnection.State != ConnectionState.Open )
                {
                    m_objSugar.SugarConnection.Open();
                }
                StringBuilder sb_SugarInsert = new StringBuilder();
                sb_SugarInsert.Append("INSERT INTO contacts(");

                #region rows for insert command text
                /* original insert into text:
                 * INSERT INTO sugarcrm.contacts(
                 * id,
                 * date_entered,  
                 * modified_user_id, 
                 * created_by, 
                 * description, 
                 * deleted, 
                 * assigned_user_id, 
                 * salutation, 
                 * first_name, 
                 * last_name, 
                 * title, 
                 * department, 
                 * phone_home, 
                 * phone_mobile, 
                 * phone_work, 
                 * phone_fax, 
                 * primary_address_street, 
                 * primary_address_city, 
                 * primary_address_postalcode, 
                 * primary_address_country
                 * )
                 * VALUES (
                 * '82da7b1d-46de-403b-ac5b-f77edc2803ba', 
                 * '2011.11.14',
                 * 'ed2d04a5-8264-45e7-fbdb-4ebebdf8375a', 
                 * 'ed2d04a5-8264-45e7-fbdb-4ebebdf8375a', 
                 * 'asdf', 
                 * 0, 
                 * 'ed2d04a5-8264-45e7-fbdb-4ebebdf8375a', 
                 * 'Sehr geehrter Herr', 
                 * 'Anton', 
                 * 'Good', 
                 * 'CIO', 
                 * 'Informatikbro', 
                 * '0817236908', 
                 * '0817236908', 
                 * '0817236908', 
                 * '0817236908', 
                 * 'Staatsstrasse 11', 
                 * 'Plons', 
                 * '8889', 
                 * 'Schweiz'); */

                sb_SugarInsert.Append("id, ");
                sb_SugarInsert.Append("date_entered, ");
                //sb_SugarInsert.Append("date_modified, ");
                sb_SugarInsert.Append("modified_user_id, ");
                sb_SugarInsert.Append("created_by, ");
                sb_SugarInsert.Append("description, ");
                sb_SugarInsert.Append("deleted, ");
                sb_SugarInsert.Append("assigned_user_id, ");
                sb_SugarInsert.Append("salutation, ");
                sb_SugarInsert.Append("first_name, ");
                sb_SugarInsert.Append("last_name, ");
                sb_SugarInsert.Append("title, ");
                sb_SugarInsert.Append("department, ");
                sb_SugarInsert.Append("phone_home, ");
                sb_SugarInsert.Append("phone_mobile, ");
                sb_SugarInsert.Append("phone_work, ");
                sb_SugarInsert.Append("phone_fax, ");
                sb_SugarInsert.Append("primary_address_street, ");
                sb_SugarInsert.Append("primary_address_city, ");
                sb_SugarInsert.Append("primary_address_postalcode, ");
                sb_SugarInsert.Append("primary_address_country, ");
                sb_SugarInsert.Append("lead_source)");
                //sb_SugarInsert.Append("lead_source)");
                //sb_SugarInsert.Append(@"birthdate)");

                #endregion
                sb_SugarInsert.Append(@" VALUES(@id, @date_entered, @modified_user_id, @created_by, @description, @deleted, @assigned_user_id, @salutation, @first_name, @last_name, @title, @department, @phone_home, @phone_mobile, @phone_work, @phone_fax, @primary_address_street, @primary_address_city, @primary_address_postalcode, @primary_address_country, @lead_source)");
                //@sb_SugarInsert.Append(@" VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"); 
                #region cmSugar + Parameters
                MySqlCommand cmSugarInsert = new MySqlCommand(sb_SugarInsert.ToString(), m_objSugar.SugarConnection);
                cmSugarInsert.Parameters.Add("@id", MySqlDbType.VarChar, 36, "@id");
                cmSugarInsert.Parameters["@id"].Value = System.Guid.NewGuid().ToString();

 
                //MySqlParameter myparam = new MySqlParameter();
                //myparam.ParameterName = "@date_entered";
                //myparam.SourceColumn = "@date_entered";
                //myparam.DbType = (DbType)MySqlDbType.DateTime;
                //myparam.Value = DateTime.Today.ToShortDateString();
                //cmSugarInsert.Parameters.Add(myparam);

                cmSugarInsert.Parameters.Add("@date_entered", MySqlDbType.DateTime);
                cmSugarInsert.Parameters["@date_entered"].Value = DateTime.Today.ToShortDateString();
                //cmSugarInsert.Parameters.Add("@date_modified", MySqlDbType.DateTime);
                //cmSugarInsert.Parameters["@date_modified"].Value = DateTime.Today.ToString();
                cmSugarInsert.Parameters.Add("@modified_user_id", MySqlDbType.VarChar, 36, "@modified_user_id");
                cmSugarInsert.Parameters["@modified_user_id"].Value = "ed2d04a5-8264-45e7-fbdb-4ebebdf8375a";
                cmSugarInsert.Parameters.Add("@created_by", MySqlDbType.VarChar, 36, "@created_by");
                cmSugarInsert.Parameters["@created_by"].Value = "ed2d04a5-8264-45e7-fbdb-4ebebdf8375a";
                cmSugarInsert.Parameters.Add("@description", MySqlDbType.Text);
                cmSugarInsert.Parameters["@description"].Value = txtBemerkung.Text;
                cmSugarInsert.Parameters.Add("@deleted", MySqlDbType.Int16, 1, "@deleted");
                cmSugarInsert.Parameters["@deleted"].Value = 0;
                cmSugarInsert.Parameters.Add("@assigned_user_id", MySqlDbType.VarChar, 36, "@assigned_user_id");
                cmSugarInsert.Parameters["@assigned_user_id"].Value = "ed2d04a5-8264-45e7-fbdb-4ebebdf8375a";
                cmSugarInsert.Parameters.Add("@salutation", MySqlDbType.VarChar, 255, "@salutation");
                cmSugarInsert.Parameters["@salutation"].Value = cboAnrede.Text;
                cmSugarInsert.Parameters.Add("@first_name", MySqlDbType.VarChar, 100, "@first_name");
                cmSugarInsert.Parameters["@first_name"].Value = txtVorname.Text;
                cmSugarInsert.Parameters.Add("@last_name", MySqlDbType.VarChar, 100, "@last_name");
                cmSugarInsert.Parameters["@last_name"].Value = txtName.Text;
                cmSugarInsert.Parameters.Add("@title", MySqlDbType.VarChar, 100, "@title");
                cmSugarInsert.Parameters["@title"].Value = txtSugarTitle.Text;
                cmSugarInsert.Parameters.Add("@department", MySqlDbType.VarChar, 255, "@department");
                cmSugarInsert.Parameters["@department"].Value = txtSugarAbteilung.Text;
                cmSugarInsert.Parameters.Add("@phone_home", MySqlDbType.VarChar, 100, "@phone_home");
                cmSugarInsert.Parameters["@phone_home"].Value = txtPhone1.Text;
                cmSugarInsert.Parameters.Add("@phone_mobile", MySqlDbType.VarChar, 100, "@phone_mobile");
                cmSugarInsert.Parameters["@phone_mobile"].Value = txtMobile.Text;
                cmSugarInsert.Parameters.Add("@phone_work", MySqlDbType.VarChar, 100, "@phone_work");
                cmSugarInsert.Parameters["@phone_work"].Value = txtPhon2.Text;
                cmSugarInsert.Parameters.Add("@phone_fax", MySqlDbType.VarChar, 100, "@phone_fax");
                cmSugarInsert.Parameters["@phone_fax"].Value = txtFax.Text;
                cmSugarInsert.Parameters.Add("@primary_address_street", MySqlDbType.VarChar, 150, "@primary_address_street");
                cmSugarInsert.Parameters["@primary_address_street"].Value = txtStrasse1.Text;
                cmSugarInsert.Parameters.Add("@primary_address_city", MySqlDbType.VarChar, 100, "@primary_address_city");
                cmSugarInsert.Parameters["@primary_address_city"].Value = txtOrt.Text;
                cmSugarInsert.Parameters.Add("@primary_address_postalcode", MySqlDbType.VarChar, 20, "@primary_address_postalcode");
                cmSugarInsert.Parameters["@primary_address_postalcode"].Value = txtPLZ.Text;
                cmSugarInsert.Parameters.Add("@primary_address_country", MySqlDbType.VarChar, 255, "@primary_address_country");
                cmSugarInsert.Parameters["@primary_address_country"].Value = txtSugarLand.Text;
                cmSugarInsert.Parameters.Add("@lead_source", MySqlDbType.VarChar, 255, "@lead_source");
                cmSugarInsert.Parameters["@lead_source"].Value = txtSugarLeadSource.Text;
                //cmSugarInsert.Parameters.Add("@birthdate", MySqlDbType.Date);
                //cmSugarInsert.Parameters["@birthdate"].Value = txtCaoGeb.Text;
                #endregion
                #endregion

                try
                {
                    cmSugarInsert.ExecuteNonQuery();
                    m_objSugar.SugarConnection.Close();
                }
                catch (Exception asdf)
                {
                    MessageBox.Show(asdf.ToString());
                    throw;
                }
            }
        }


        private void neuToolStripButton_Click(object sender, EventArgs e)
        {
            PrepareNew();
        }
        /// <summary>
        /// Asks the User if he wants to clear all Textfields and
        /// enables the Save button.
        /// </summary>
        private void PrepareNew()
        {
            // If the User clicks "yes" all the textfields get cleared.
            // If he clicks "no" the Text stays there, handy if the User
            // forgot to click "add new".
            DialogResult dr = MessageBox.Show("Alle Textfelder clearen?", "Neuer Datensatz...", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Yes)
            {
                #region 1. clear all textfields
                txtVorname.Clear();
                txtName.Clear();
                cboAnrede.SelectedIndex = 0;
                txtStrasse1.Clear();
                txtPLZ.Clear();
                txtOrt.Clear();
                txtWebpage.Clear();
                txtEmail.Clear();
                txtFax.Clear();
                txtMobile.Clear();
                txtPhon2.Clear();
                txtPhone1.Clear();
                txtCaoZahlungsziel.Clear();
                txtCaoCustomerSince.Clear();
                txtCaoGeb.Clear();
                txtBemerkung.Clear();
                #endregion
                m_bNew = true;
                this.EnableSave();
            }
            else
            {
                m_bNew = true;
                this.EnableSave();
            }
        }

        #region obsolete
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    CaoInsertFirma();
        //    //SugarInsertFirma();
        //}
        #endregion

        #region obsolete
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}
        #endregion

        private void CaoInsertFirma()
        {
            if (m_bNew == true)
            {
                /* - create insert command text
                 * - create command itself
                 * - set all parameters for the values */

                #region Insert Command Text
                StringBuilder sb_CaoInsert = new StringBuilder();
                sb_CaoInsert.Append("INSERT INTO adressen(");
                sb_CaoInsert.Append("REC_ID, ");
                sb_CaoInsert.Append("KUNDENGRUPPE, ");
                sb_CaoInsert.Append("NAME1, ");
                sb_CaoInsert.Append("NAME2, ");
                sb_CaoInsert.Append("PLZ, ");
                sb_CaoInsert.Append("ORT, ");
                sb_CaoInsert.Append("ANREDE, ");
                sb_CaoInsert.Append("STRASSE, ");
                sb_CaoInsert.Append("TELE1, ");
                sb_CaoInsert.Append("FAX, ");
                sb_CaoInsert.Append("EMAIL, ");
                sb_CaoInsert.Append("INTERNET, ");
                sb_CaoInsert.Append("BRIEFANREDE, ");
                sb_CaoInsert.Append("BRT_TAGE, ");
                sb_CaoInsert.Append("INFO, ");
                sb_CaoInsert.Append("KUN_LIEFART, ");
                sb_CaoInsert.Append("KUN_SEIT, ");
                sb_CaoInsert.Append("GEAEND_NAME, ");
                sb_CaoInsert.Append("KUN_ZAHLART, ");
                sb_CaoInsert.Append(@"BRUTTO_FLAG)");
                sb_CaoInsert.Append(@" VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"); 
                #endregion

                OdbcCommand caoInsert = new OdbcCommand(sb_CaoInsert.ToString(), m_objCao.CaoConnection);

                #region parameters
                caoInsert.Parameters.Add("@REC_ID", OdbcType.Int, 11, "@REC_ID");
                caoInsert.Parameters["@REC_ID"].Value = m_objCao.LatestRecId;
                caoInsert.Parameters.Add("@KUNDENGRUPPE", OdbcType.Int, 11, "@KUNDENGRUPPE");
                caoInsert.Parameters["@KUNDENGRUPPE"].Value = 2;

                caoInsert.Parameters.Add("@NAME1", OdbcType.VarChar, 40, "@NAME1");
                caoInsert.Parameters["@NAME1"].Value = txtFName1.Text;

                caoInsert.Parameters.Add("@NAME2", OdbcType.VarChar, 40, "@NAME2");
                caoInsert.Parameters["@NAME2"].Value = txtFName2.Text;

                caoInsert.Parameters.Add("@PLZ", OdbcType.VarChar, 10, "@PLZ");
                caoInsert.Parameters["@PLZ"].Value = txtFPLZ.Text;
                caoInsert.Parameters.Add("@ORT", OdbcType.VarChar, 40, "@ORT");
                caoInsert.Parameters["@ORT"].Value = txtFOrt.Text;
                caoInsert.Parameters.Add("@ANREDE", OdbcType.VarChar, 40, "@ANREDE");
                caoInsert.Parameters["@ANREDE"].Value = cboFAnrede.Text;
                caoInsert.Parameters.Add("@STRASSE", OdbcType.VarChar, 40, "@STRASSE");
                caoInsert.Parameters["@STRASSE"].Value = txtFStrasse.Text;
                caoInsert.Parameters.Add("@TELE1", OdbcType.VarChar, 100, "@TELE1");
                caoInsert.Parameters["@TELE1"].Value = txtFPhone.Text;

                caoInsert.Parameters.Add("@FAX", OdbcType.VarChar, 100, "@FAX");
                caoInsert.Parameters["@FAX"].Value = txtFFax.Text;

                caoInsert.Parameters.Add("@EMAIL", OdbcType.VarChar, 100, "@EMAIL");
                caoInsert.Parameters["@EMAIL"].Value = txtFMail.Text;
                caoInsert.Parameters.Add("@INTERNET", OdbcType.VarChar, 100, "@INTERNET");
                caoInsert.Parameters["@INTERNET"].Value = txtFWeb.Text;
                caoInsert.Parameters.Add("@BRIEFANREDE", OdbcType.VarChar, 100, "@BRIEFANREDE");
                caoInsert.Parameters["@BRIEFANREDE"].Value = cboFCaoBriefanrede.Text;
                caoInsert.Parameters.Add("@BRT_TAGE", OdbcType.TinyInt, 4, "@BRT_TAGE");
                caoInsert.Parameters["@BRT_TAGE"].Value = Convert.ToInt16(txtFZahlungsziel.Text);
                caoInsert.Parameters.Add("@INFO", OdbcType.Text, 65537, "@INFO");
                caoInsert.Parameters["@INFO"].Value = txtFBemerkung.Text;
                caoInsert.Parameters.Add("@KUN_LIEFART", OdbcType.Int, 11, "@KUN_LIEFART");
                caoInsert.Parameters["@KUN_LIEFART"].Value = cboFVersand.SelectedIndex + 1;
                caoInsert.Parameters.Add("@KUN_SEIT", OdbcType.Date);
                caoInsert.Parameters["@KUN_SEIT"].Value = DateTime.Today.ToShortDateString();
                caoInsert.Parameters.Add("@GEAND_NAME", OdbcType.VarChar, 20, "@GEAND_NAME");
                caoInsert.Parameters["@GEAND_NAME"].Value = "Cugar";

                caoInsert.Parameters.Add("@KUN_ZAHLART", OdbcType.Int, 11, "@KUN_ZAHLART");
                caoInsert.Parameters["@KUN_ZAHLART"].Value = cboFZahlart.SelectedIndex + 1;
                caoInsert.Parameters.Add("@BRUTTO_FLAG", OdbcType.Char, 2, "@BRUTTO_FLAG");
                caoInsert.Parameters["@BRUTTO_FLAG"].Value = 'Y';
                #endregion
                try
                {
                    caoInsert.ExecuteNonQuery();
                }
                catch (Exception asdf)
                {
                    MessageBox.Show(asdf.ToString());
                    throw;
                }
            }
        }

        private void SugarInsertFirma()
        {
            if (m_bNew == true)
            {
                #region Insert Command Text
                if (m_objSugar.SugarConnection.State != ConnectionState.Open)
                {
                    m_objSugar.SugarConnection.Open();
                }
                StringBuilder sb_SugarInsert = new StringBuilder();
                sb_SugarInsert.Append("INSERT INTO accounts(");

                #region rows for insert command text
                sb_SugarInsert.Append("id, ");
                sb_SugarInsert.Append("name, ");
                sb_SugarInsert.Append("date_entered, ");
                //sb_SugarInsert.Append("date_modified, ");
                sb_SugarInsert.Append("modified_user_id, ");
                sb_SugarInsert.Append("created_by, ");
                sb_SugarInsert.Append("description, ");
                sb_SugarInsert.Append("deleted, ");
                sb_SugarInsert.Append("assigned_user_id, ");
                sb_SugarInsert.Append("account_type, ");
                //!
                sb_SugarInsert.Append("industry, ");
                //!
                sb_SugarInsert.Append("annual_revenue, ");
                //!
                sb_SugarInsert.Append("phone_fax, ");
                sb_SugarInsert.Append("billing_address_street, ");
                sb_SugarInsert.Append("billing_address_city, ");
                sb_SugarInsert.Append("billing_address_country, ");
                //! 
                //sb_SugarInsert.Append("rating, ");
                //!
                sb_SugarInsert.Append("phone_office, ");
                sb_SugarInsert.Append("website, ");
                //!
                //sb_SugarInsert.Append("ownership, ");
                sb_SugarInsert.Append("employees)");
                //sb_SugarInsert.Append("ticker_symbol, ");
                //!

                /* 
                 * sbSugarInsert.Append("shipping_address_street, ");
                 * sbSugarInsert.Append("shipping_address_city, ");
                 * sbSugarInsert.Append("shipping_address_state, ");
                 * sbSugarInsert.Append("shipping_address_postalcode, ");
                 * sbSugarInsert.Append("shipping_address_country, ");
                 */

                /*
                 * sbSugarInsert.Append("parent_id, ");
                 * sbSugarInsert.Append("sic_code, ");
                 * sbSugarInsert.Append("campaign_id", );
                 */

                #endregion
                sb_SugarInsert.Append(@" VALUES(@id, @name, @date_entered, @modified_user_id, @created_by, @description, @deleted, @assigned_user_id, @account_type, @industry, @annual_revenue, @phone_fax, @billing_address_street, @billing_address_city, @billing_address_country, @phone_office, @website, @employees)");
                #region cmSugar + Parameters
                MySqlCommand cmSugarInsert = new MySqlCommand(sb_SugarInsert.ToString(), m_objSugar.SugarConnection);
                cmSugarInsert.Parameters.Add("@id", MySqlDbType.VarChar, 36, "@id");
                cmSugarInsert.Parameters["@id"].Value = System.Guid.NewGuid().ToString();
                cmSugarInsert.Parameters.Add("@name", MySqlDbType.VarChar, 150, "@name");
                cmSugarInsert.Parameters["@name"].Value = txtFName1.Text;
                cmSugarInsert.Parameters.Add("@date_entered", MySqlDbType.DateTime);
                cmSugarInsert.Parameters["@date_entered"].Value = DateTime.Today.ToShortDateString();
                //cmSugarInsert.Parameters.Add("@date_modified", MySqlDbType.DateTime);
                //cmSugarInsert.Parameters["@date_modified"].Value = DateTime.Today.ToString();
                cmSugarInsert.Parameters.Add("@modified_user_id", MySqlDbType.VarChar, 36, "@modified_user_id");
                cmSugarInsert.Parameters["@modified_user_id"].Value = "ed2d04a5-8264-45e7-fbdb-4ebebdf8375a";
                cmSugarInsert.Parameters.Add("@created_by", MySqlDbType.VarChar, 36, "@created_by");
                cmSugarInsert.Parameters["@created_by"].Value = "ed2d04a5-8264-45e7-fbdb-4ebebdf8375a";
                cmSugarInsert.Parameters.Add("@description", MySqlDbType.Text);
                cmSugarInsert.Parameters["@description"].Value = txtBemerkung.Text;
                cmSugarInsert.Parameters.Add("@deleted", MySqlDbType.Int16, 1, "@deleted");
                cmSugarInsert.Parameters["@deleted"].Value = 0;
                cmSugarInsert.Parameters.Add("@assigned_user_id", MySqlDbType.VarChar, 36, "@assigned_user_id");
                cmSugarInsert.Parameters["@assigned_user_id"].Value = "ed2d04a5-8264-45e7-fbdb-4ebebdf8375a";
                cmSugarInsert.Parameters.Add("@account_type", MySqlDbType.VarChar, 50, "@account_type");
                cmSugarInsert.Parameters["@account_type"].Value = cboFSugarType.Text;
                cmSugarInsert.Parameters.Add("@industry", MySqlDbType.VarChar, 50, "@industry");
                cmSugarInsert.Parameters["@industry"].Value = txtFSugarBranche.Text;
                cmSugarInsert.Parameters.Add("@annual_revenue", MySqlDbType.VarChar, 100, "@annual_revenue");
                cmSugarInsert.Parameters["@annual_revenue"].Value = txtFSugarUmsatz.Text;
                cmSugarInsert.Parameters.Add("@phone_fax", MySqlDbType.VarChar, 100, "@phone_fax");
                cmSugarInsert.Parameters["@phone_fax"].Value = txtFFax.Text;
                cmSugarInsert.Parameters.Add("@billing_address_street", MySqlDbType.VarChar, 150, "@billing_address_street");
                cmSugarInsert.Parameters["@billing_address_street"].Value = txtFStrasse.Text;
                cmSugarInsert.Parameters.Add("@billing_address_city", MySqlDbType.VarChar, 100, "@billing_address_city");
                cmSugarInsert.Parameters["@billing_address_city"].Value = txtFOrt.Text;
                cmSugarInsert.Parameters.Add("@billing_address_postalcode", MySqlDbType.VarChar, 20, "@billing_address_postalcode");
                cmSugarInsert.Parameters["@billing_address_postalcode"].Value = txtFPLZ.Text;
                cmSugarInsert.Parameters.Add("@billing_address_country", MySqlDbType.VarChar, 255, "@billing_address_country");
                cmSugarInsert.Parameters["@billing_address_country"].Value = txtFSugarLand.Text;
                cmSugarInsert.Parameters.Add("@phone_office", MySqlDbType.VarChar, 100, "@phone_office");
                cmSugarInsert.Parameters["@phone_office"].Value = txtFPhone.Text;
                cmSugarInsert.Parameters.Add("@website", MySqlDbType.VarChar, 255, "@website");
                cmSugarInsert.Parameters["@website"].Value = txtFWeb.Text;
                cmSugarInsert.Parameters.Add("@employees", MySqlDbType.VarChar, 10, "@employees");
                cmSugarInsert.Parameters["@employees"].Value = txtFSugarMitarbeiter.Text;
                #endregion
                #endregion

                try
                {
                    cmSugarInsert.ExecuteNonQuery();
                    m_objSugar.SugarConnection.Close();
                }
                catch (Exception asdf)
                {
                    MessageBox.Show(asdf.ToString());
                    throw;
                }
            }
            //...
        }

        private void tstxtSucheFirma_Click(object sender, EventArgs e)
        {
            tstxtSucheFirma.Clear();
        }

        private void tstxtSucheFirma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchFirma();
            }

        }

        private void SearchFirma()
        {
            frmSuche m_objSuche = new frmSuche(m_DS, tstxtSucheFirma.Text, m_objCao, m_objSugar, this, m_BS_CaoSearchFirma, m_BS_SugarSearchFirma);
            m_objSuche.Privat = false;
            //m_objSuche.StartSearchFirma(tstxtSucheFirma.Text);
            m_objSuche.ShowDialog();
        }

        private void tstxtSuchePrivat_Click(object sender, EventArgs e)
        {
            tstxtSuchePrivat.Clear();
        }

        private void tstxtSuchePrivat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchPrivat();
            }
        }
        #region keyboard shortcuts
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Control)
            {
                tstxtSuchePrivat.Focus();
            }
        }
        #endregion

        #region unused
        //private void mnuFrmMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{

        //}

        //private void cboFZahlart_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
        #endregion

        private void speichernToolStripButton_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabCompanies)
            {
                //UpdateCompanies()
            }
            else if (tabMain.SelectedTab == tabContacts)
            {
                //UpdateContacts()
            }
            else
            {
                //do nothing
            }
        }

        private void UpdateCompanyCao()
        {
        }

        private void UpdateCompanySugar()
        {
        }

        private void UpdateContactCao()
        {
            /* Set up the databindings */

            // Combine txtVorname + txtName
            string name;
            name = txtVorname.Text + " " + txtName.Text;
            ((DataRowView)m_BS_CaoSearchContacts.Current)["NAME1"] = name;

            // Cao Versandart Id
            int VersandId = 0;
            VersandId = cboCaoVersand.SelectedIndex + 1;
            ((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_LIEFART"] = VersandId.ToString();

            // Cao Zahlart Id
            int ZahlId = 0;
            ZahlId = cboCaoZahlart.SelectedIndex + 1;
            ((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_ZAHLART"] = ZahlId;

            ((DataRowView)m_BS_CaoSearchContacts.Current)["ANREDE"] = cboAnrede.Text;
            ((DataRowView)m_BS_CaoSearchContacts.Current)["STRASSE"] = txtStrasse1.Text;
            ((DataRowView)m_BS_CaoSearchContacts.Current)["PLZ"] = txtPLZ.Text;
            ((DataRowView)m_BS_CaoSearchContacts.Current)["ORT"] = txtOrt.Text;
            ((DataRowView)m_BS_CaoSearchContacts.Current)["INTERNET"] = txtWebpage.Text;
            ((DataRowView)m_BS_CaoSearchContacts.Current)["EMAIL"] = txtEmail.Text;
            ((DataRowView)m_BS_CaoSearchContacts.Current)["FAX"] = txtFax.Text;
            ((DataRowView)m_BS_CaoSearchContacts.Current)["FUNK"] = txtMobile.Text;
            ((DataRowView)m_BS_CaoSearchContacts.Current)["TELE2"] = txtPhon2.Text;
            ((DataRowView)m_BS_CaoSearchContacts.Current)["TELE1"] = txtPhone1.Text;
            ((DataRowView)m_BS_CaoSearchContacts.Current)["BRIEFANREDE"] = cboCaoBriefanrede.Text;
            ((DataRowView)m_BS_CaoSearchContacts.Current)["BRT_TAGE"] = txtCaoZahlungsziel.Text;
            ((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_SEIT"] = txtCaoCustomerSince.Text;

            if (txtCaoGeb.Text != "")
            {
                try
                {
                    ((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_GEBDATUM"] = Convert.ToDateTime(txtCaoGeb.Text);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    ((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_GEBDATUM"] = "01.01.1911";
                }
            }
            
            ((DataRowView)m_BS_CaoSearchContacts.Current)["INFO"] = txtBemerkung.Text;
            ((DataRowView)m_BS_CaoSearchContacts.Current).EndEdit();

            //((DataRowView)m_BS_SugarSearchContacts.Current)["primary_address_country"] = txtSugarLand.Text;
            //((DataRowView)m_BS_SugarSearchContacts.Current)["lead_source"] = txtSugarLeadSource.Text;
            //((DataRowView)m_BS_SugarSearchContacts.Current)["department"] = txtSugarAbteilung.Text;
            //((DataRowView)m_BS_SugarSearchContacts.Current)["title"] = txtSugarTitle.Text;


            cCao m_objCaoUpdate = new cCao(m_DS, m_BS_CaoSearchContacts);
            m_objCaoUpdate.UpdateAll();

            //if (m_BS_CaoSearchContacts.Current != null)
            //{
            //    //tabCompanies.
            //    //set searchtext to personen
            //    tstxtSuchePrivat.Text = "Personen...";

            //    #region Convert the name filed into two fields using CToolbox
            //    CToolbox m_objTool = new CToolbox();
            //    string[] foo2;
            //    foo2 = m_objTool.SplitName(((DataRowView)m_BS_CaoSearchContacts.Current)["NAME1"].ToString());
            //    txtVorname.Text = foo2[0];
            //    txtName.Text = foo2[1];
            //    #endregion

            //    #region fill cbos and set them to the right index
            //    // set cboCaoVersand to the right index
            //    int VerdsandId = 0;
            //    VerdsandId = Convert.ToInt32(((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_LIEFART"]);
            //    cboCaoVersand.SelectedIndex = VerdsandId - 1;

            //    //set cboCaoZahlart to the right index
            //    int ZahlartId = 0;
            //    ZahlartId = Convert.ToInt32(((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_ZAHLART"]);
            //    cboCaoZahlart.SelectedIndex = ZahlartId - 1;
            //    #endregion

            //    /* Fills in all the textfield using databinding object casted into a datarowview */

            //    cboAnrede.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["ANREDE"].ToString();
            //    txtStrasse1.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["STRASSE"].ToString();
            //    txtPLZ.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["PLZ"].ToString();
            //    txtOrt.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["ORT"].ToString();
            //    txtWebpage.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["INTERNET"].ToString();
            //    txtEmail.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["EMAIL"].ToString();
            //    txtFax.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["FAX"].ToString();
            //    txtMobile.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["FUNK"].ToString();
            //    txtPhon2.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["TELE2"].ToString();
            //    txtPhone1.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["TELE1"].ToString();
            //    cboCaoBriefanrede.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["BRIEFANREDE"].ToString();
            //    txtCaoZahlungsziel.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["BRT_TAGE"].ToString();
            //    txtCaoCustomerSince.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_SEIT"].ToString();
            //    txtCaoGeb.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_GEBDATUM"].ToString();
            //    txtBemerkung.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["INFO"].ToString();

            //    //((DataRowView)m_BS_CaoSearchContacts.Current)["INFO"] = txtBemerkung.Text;

            //    //txtSugarZugewiesenAn.Text = ((DataRowView)m_BS.Current)[].ToString();
            //    txtSugarLand.Text = ((DataRowView)m_BS_SugarSearchContacts.Current)["primary_address_country"].ToString();
            //    txtSugarLeadSource.Text = ((DataRowView)m_BS_SugarSearchContacts.Current)["lead_source"].ToString();
            //    txtSugarAbteilung.Text = ((DataRowView)m_BS_SugarSearchContacts.Current)["department"].ToString();
            //    txtSugarTitle.Text = ((DataRowView)m_BS_SugarSearchContacts.Current)["title"].ToString();
            //}

            ////((DataRowView)m_BS.Current)["NAME1"] = txtName.Text;
            ////((DataRowView)m_BS_Sugar.Current)["last_name"] = 
            ////m_BS.Current

        }

        private void UpdateContactSugar()
        {
        }

        private void druckenToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Drucken wird leider noch nicht unterstützt.");
        }
    }
}
