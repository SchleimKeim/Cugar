﻿using System;
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
        //private cCao m_objCaoVersand;

        private cSugar m_objSugar;

        private DataTable m_dtDatensatzCao;
        private DataTable m_dtDatensatzSugar;
        
        private const string m_const_strSugarTable = "tblSugar";
        private const string m_const_strCaoTable = "tblCao";

        /* Added on 1.11. just for testing */
        private const string m_const_strCaoTablePrivate = "tblCaoPrivate";
        private const string m_const_strSugarTablePrivate = "tblSugarContacts";
        private const string m_const_strCaoTableSearchAllPrivate = "tblCaoSearchAllPrivate";
        private const string m_const_strCaoTableSearchAllCompanies = "tblCaoSearchAllCompanies";
        private const string m_const_strCaoTableSearchHuman = "tblCaoSearchHuman";
        private const string m_const_strSugarTableSearchHuman = "tblSugarSearchHuman";
        

        private const string m_const_strCaoVersandarten = "tblCaoVersandarten";
        private const string m_const_strCaoZahlarten = "tblCaoZahlarten";

        private const string m_const_strAktuellerCaoDatensatz = "tblCaoSelected";
        private const string m_const_strAktuellerSugarDatensatz = "tblSugarSelected";

        /* binding sources */
        private BindingSource m_BS_CaoSearchContacts = new BindingSource();
        private BindingSource m_BS_CaoSearchFirma = new BindingSource();
        private BindingSource m_BS_CaoZahlarten = new BindingSource();
        private BindingSource m_BS_CaoVersandarten = new BindingSource();
        private BindingSource m_BS_SugarSearchContacts = new BindingSource();
        

        private bool m_bNew = false;

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
                    m_objSugar = new cSugar(m_DS, m_BS_SugarSearchContacts);
                    m_objSugar.LoadPrivateCustomers();
                    m_dvSugar = m_DS.Tables[m_const_strSugarTablePrivate].DefaultView;
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
                //LoadCaoVersandArten();
                m_objCao.LoadCaoVersandarten();
                LoadCaoVersandArten();                
                cboCaoVersand.SelectedIndex = 0;

                /* zahlunggsarten ausfüllen */
                //LoadCaoZahlungsarten();
                m_objCao.LoadCaoZahlarten();
                LoadCaoZahlungsarten();                
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

        
        //private void tstxtSuche_Click(object sender, EventArgs e)
        //{
        //    tstxtSuchePrivat.Clear();
        //}

        private void tsCmdSearch_Click(object sender, EventArgs e)
        {
            SearchPrivat();
        }

        private void SearchPrivat()
        {
            //frmSuche m_objSuche = new frmSuche(m_DS, tstxtSuche.Text);
            frmSuche m_objSuche = new frmSuche(m_DS, tstxtSuchePrivat.Text, m_objCao, m_objSugar, this, m_BS_CaoSearchContacts);
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
            if (cmdPrivatSave.Enabled == false)
            {
                cmdPrivatSave.Enabled = true;
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
                return cmdPrivatSave.Enabled;
            }
            set
            {
                cmdPrivatSave.Enabled = value;
            }
        }

        #endregion

        private void cmdPrivatSave_Click(object sender, EventArgs e)
        {
            CaoInsertPrivat();
            SugarInsertPrivat();
    
            //Routine für Update vorgang
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
                sb_CaoInsert.Append(@"KUN_ZAHLART)");
                sb_CaoInsert.Append(@" VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");
                #endregion

                OdbcCommand caoInsert = new OdbcCommand(sb_CaoInsert.ToString(), m_objCao.CaoConnection);

                #region parameters
                caoInsert.Parameters.Add("@REC_ID", OdbcType.Int, 11, "@REC_ID");
                caoInsert.Parameters["@REC_ID"].Value = m_objCao.LatestRecId;
                caoInsert.Parameters.Add("@KUNDENGRUPPE", OdbcType.Int, 11, "@KUNDENGRUPPE");
                caoInsert.Parameters["@KUNDENGRUPPE"].Value = 1;

                caoInsert.Parameters.Add("@NAME1", OdbcType.VarChar, 40, "@NAME1");
                CToolbox tool = new CToolbox();
                caoInsert.Parameters["@NAME1"].Value = tool.UniteName(txtVorname.Text, txtName.Text);

                caoInsert.Parameters.Add("@PLZ", OdbcType.VarChar, 10, "@PLZ");
                caoInsert.Parameters["@PLZ"].Value = txtPLZ.Text;
                caoInsert.Parameters.Add("@ORT", OdbcType.VarChar, 40, "@ORT");
                caoInsert.Parameters["@ORT"].Value = txtOrt.Text;
                caoInsert.Parameters.Add("@ANREDE", OdbcType.VarChar, 40, "@ANREDE");
                caoInsert.Parameters["@ANREDE"].Value = txtAnrede.Text;
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
                caoInsert.Parameters["@BRIEFANREDE"].Value = txtCaoBriefanrede.Text;
                caoInsert.Parameters.Add("@BRT_TAGE", OdbcType.TinyInt, 4, "@BRT_TAGE");
                caoInsert.Parameters["@BRT_TAGE"].Value = Convert.ToInt16(txtCaoZahlungsziel.Text);
                caoInsert.Parameters.Add("@INFO", OdbcType.Text, 65537, "@INFO");
                caoInsert.Parameters["@INFO"].Value = txtBemerkung.Text;
                caoInsert.Parameters.Add("@KUN_LIEFART", OdbcType.Int, 11, "@KUN_LIEFART");
                caoInsert.Parameters["@KUN_LIEFART"].Value = cboCaoVersand.SelectedIndex - 1;
                caoInsert.Parameters.Add("@KUN_SEIT", OdbcType.Date);
                caoInsert.Parameters["@KUN_SEIT"].Value = DateTime.Today.ToShortDateString();
                caoInsert.Parameters.Add("@GEAND_NAME", OdbcType.VarChar, 20, "@GEAND_NAME");
                caoInsert.Parameters["@GEAND_NAME"].Value = "Cugar";

                caoInsert.Parameters.Add("@KUN_ZAHLART", OdbcType.Int, 11, "@KUN_ZAHLART");
                caoInsert.Parameters["@KUN_ZAHLART"].Value = cboCaoZahlart.SelectedIndex - 1;
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
                sb_SugarInsert.Append("primary_address_country)");
                //sb_SugarInsert.Append("lead_source, ");
                //sb_SugarInsert.Append("lead_source)");
                //sb_SugarInsert.Append(@"birthdate)");

                #endregion
                sb_SugarInsert.Append(@" VALUES(@id, @date_entered, @modified_user_id, @created_by, @description, @deleted, @assigned_user_id, @salutation, @first_name, @last_name, @title, @department, @phone_home, @phone_mobile, @phone_work, @phone_fax, @primary_address_street, @primary_address_city, @primary_address_postalcode, @primary_address_country)");
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
                cmSugarInsert.Parameters["@salutation"].Value = txtAnrede.Text;
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
                //cmSugarInsert.Parameters.Add("@lead_source", MySqlDbType.VarChar, 255, "@lead_source");
                //cmSugarInsert.Parameters["@lead_source"].Value = txtSugarLeadSource.Text;
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
            #region 1. clear all textfields
            txtVorname.Clear();
            txtName.Clear();
            txtAnrede.Clear();
            txtStrasse1.Clear();
            txtPLZ.Clear();
            txtOrt.Clear();
            txtWebpage.Clear();
            txtEmail.Clear();
            txtFax.Clear();
            txtMobile.Clear();
            txtPhon2.Clear();
            txtPhone1.Clear();
            txtCaoBriefanrede.Clear();
            //txtCaoZahlungsziel.Clear();
            txtCaoCustomerSince.Clear();
            txtCaoGeb.Clear();
            txtBemerkung.Clear();
            #endregion

            m_bNew = true;
            this.EnableSave();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CaoInsertFirma();
            SugarInsertFirma();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CaoInsertFirma()
        {
            //just use the code from privat with kundengruppe=2
        }

        private void SugarInsertFirma()
        {
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
            frmSuche m_objSuche = new frmSuche(m_DS, tstxtSucheFirma.Text, m_objCao, m_objSugar, this, m_BS_CaoSearchFirma);
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
                SearchFirma();
            }
        }

    }
}
