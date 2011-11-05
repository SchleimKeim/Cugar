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

namespace Cugar
{
    /* *********************
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
        //private cCao m_objCaoVersand;

        private cSugar m_objSugar;

        private DataTable m_dtDatensatzCao;
        private DataTable m_dtDatensatzSugar;
        
        private const string m_const_strSugarTable = "tblSugar";
        private const string m_const_strCaoTable = "tblCao";

        /* Added on 1.11. just for testing */
        private const string m_const_strCaoTablePrivate = "tblCaoPrivate";
        private const string m_const_strSugarTableSearchAll = "tblSugarSearchAll";
        private const string m_const_strCaoTableSearchHuman = "tblCaoSearchHuman";
        private const string m_const_strSugarTableSearchHuman = "tblSugarSearchHuman";

        private const string m_const_strCaoVersandarten = "tblCaoVersandarten";
        private const string m_const_strCaoZahlarten = "tblCaoZahlarten";

        private const string m_const_strAktuellerCaoDatensatz = "tblCaoSelected";
        private const string m_const_strAktuellerSugarDatensatz = "tblSugarSelected";

        /* binding sources */
        private BindingSource m_BS_CaoSearchContacts = new BindingSource();
        private BindingSource m_BS_CaoZahlarten = new BindingSource();
        private BindingSource m_BS_CaoVersandarten = new BindingSource();
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

            if (m_DS.Tables.Count == 0)
            {

                #region fill dgvCao
                try
                {
                    /* vorgang:
                     * neues cao objekt wird erstellt mit dem DataSet der main.cf
                     * die methode LoadDataSet() fllt das DataSet mit informationen 
                     * aus der Cao Datenbank
                     * das DataView der main.cf wird mit den tables aus dem DataSet der main.cf gefllt
                     * dgv kriegt als source das DataView der main.cf
                     */

                    //m_objCao = new cCao(m_DS);

                    // added on 03.11.
                    m_objCao = new cCao(m_DS, m_BS_CaoSearchContacts);

                    //load all private customers, propably obsolete but good
                    m_objCao.LoadPrivateCustomers();                    
                    m_dvCao = m_DS.Tables[m_const_strCaoTablePrivate].DefaultView;
                    dgvCao.DataSource = m_dvCao;

                    //load cbo Versandarten, currently not working :(
                }
                catch (Exception asdf)
                {
                    MessageBox.Show(asdf.ToString());
                    Application.Exit();
                }
                #endregion

                #region fill dgvSugar
                /* Fills out dgvSugar */
                try
                {
                    //m_objSugar = new cSugar(m_DS);
                    // added on 03.11.
                    m_objSugar = new cSugar(m_DS, m_BS_CaoSearchContacts);
                    m_objSugar.LoadDataSet();
                    m_dvSugar = m_DS.Tables[m_const_strSugarTable].DefaultView;
                    dgvSugar.DataSource = m_dvSugar;
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
                //m_objCao.LoadCaoVersandarten();
                cboCaoVersand.SelectedIndex = 0;

                /* zahlunggsarten ausfüllen */
                LoadCaoZahlungsarten();
                m_objCao.LoadCaoZahlarten();
                cboCaoZahlart.SelectedIndex = 0;                

            }
            else
            { 
                //txtStrasse1.Text = m_DS.Tables[m_const_strCaoTable].
            }

        }
        /// <summary>
        ///  Loads all cao Versandarten into cboVersand
        ///  and initialises an object m_objCaoVersand which
        ///  has a BindingSource named m_BS_CaoVersandarten
        ///  Using a Tablename "tblCaoPrivate"
        /// </summary>
        private void LoadCaoVersandArten()
        {
            #region old
            //int foo = 0;

            //if (m_objCao.Versandarten == null)
            //{
            //    m_objCao.LoadCaoVersandarten();
            //}

            //string[] bla;
            //bla = m_objCao.Versandarten;


            //foreach (string x in bla)
            //{
            //    cboCaoVersand.Items.Add(m_objCao.Versandarten[foo]);
            //    foo++;
            //}
            #endregion

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
            }
            dr.Close();
            m_cnFoo.Close();
            #endregion
        }

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
            }
            dr.Close();
            m_cnFoo.Close();
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

        }

        
        private void tstxtSuche_Click(object sender, EventArgs e)
        {
            tstxtSuchePrivat.Clear();
        }

        private void tsCmdSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            //frmSuche m_objSuche = new frmSuche(m_DS, tstxtSuche.Text);
            frmSuche m_objSuche = new frmSuche(m_DS, tstxtSuchePrivat.Text, m_objCao, m_objSugar, this, m_BS_CaoSearchContacts);
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
            if (m_dtDatensatzCao == null)
            {
                StringBuilder foo = new StringBuilder();
                foo.Append("Aktuelle Anzahl Tabellen im DataSet m_DS: ");
                foo.Append(m_DS.Tables.Count.ToString());
                foo.Append(" DataTables\n");                
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

        public void DatensatzLaden()
        {
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
                //set searchtext to personen
                tstxtSuchePrivat.Text = "Personen...";

                #region Convert the name filed into two fields using CToolbox
                CToolbox m_objTool = new CToolbox();                
                string[] foo2;                
                foo2 = m_objTool.VornameNachname(((DataRowView)m_BS_CaoSearchContacts.Current)["NAME1"].ToString());
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

                txtAnrede.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["ANREDE"].ToString();         
                txtStrasse1.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["STRASSE"].ToString();
                txtPLZ.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["PLZ"].ToString();
                txtOrt.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["ORT"].ToString();                
                txtWebpage.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["INTERNET"].ToString();
                txtEmail.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["EMAIL"].ToString();
                txtFax.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["FAX"].ToString();
                txtMobile.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["FUNK"].ToString();
                txtPhon2.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["TELE2"].ToString();
                txtPhone1.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["TELE1"].ToString();
                txtCaoBriefanrede.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["BRIEFANREDE"].ToString();
                txtCaoZahlungsziel.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["BRT_TAGE"].ToString();
                txtCaoCustomerSince.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_SEIT"].ToString();
                txtCaoGeb.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_GEBDATUM"].ToString();
                txtBemerkung.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["INFO"].ToString();
                

                //txtSugarZugewiesenAn.Text = ((DataRowView)m_BS.Current)[].ToString();
                //txtSugarLeadSource.Text = ((DataRowView)m_BS.Current)[].ToString();

                //txtSugarReportsTo.Text = ((DataRowView)m_BS.Current)[].ToString();
                //txtSugarTitle.Text = ((DataRowView)m_BS.Current)[].ToString();

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
            cmdPrivatSave.Enabled = true;
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


        #endregion



    }
}
