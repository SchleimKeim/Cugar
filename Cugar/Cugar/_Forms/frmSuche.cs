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
        /// <summary>
        ///  The Search Form
        /// </summary>

        #region private members

        private const string m_const_strCaoTableSearchAllPrivate = "tblCaoSearchAllPrivate";
        private const string m_const_strCaoTableSearchAllCompanies = "tblCaoSearchAllCompanies";
        private const string m_const_strSugarTableSearchAllPrivate = "tblSugarSearchAllPrivate";
        private const string m_const_strSugarTableSearchAllCompanies = "tblSugarSearchAllCompanies";

        private const string m_const_strCaoTableSearchHuman = "tblCaoSearchHuman";
        private const string m_const_strSugarTableSearchHuman = "tblSugarSearchHuman";

        private const string m_const_strAktuellerCaoDatensatz = "tblCaoSelected";
        private const string m_const_strAktuellerSugarDatensatz = "tblSugarSelected";

        private string m_strSuchstring;
        private cCao m_objCao;
        private cSugar m_objSugar;
        private DataSet m_DS;
        //private DataView m_DV;
        //private DataView m_DV_Search_Cao_all;
        private DataView m_DV_Search_Cao_human = new DataView();
        //private DataView m_DV_Search_Sugar_all;
        private DataView m_DV_Search_Sugar_human = new DataView();

        /* Reference to frmMain */
        private frmMain frmMain = null;

        private BindingSource m_BS_Cao;
        private BindingSource m_BS_Sugar;

        // Bool to decide weither its a search for normal contacts or for companys
        private bool m_privat = false;

        #endregion

        #region obsolete
        ///// <summary>
        ///// The Constructor requires two connector objects</summary>
        ///// <param name="ds">a DataSet</param>
        ///// <param name="searchstring">the search string</param>  
        //public frmSuche(DataSet ds, string searchstring)
        //{
        //    m_strSuchstring = searchstring;
        //    m_DS = ds;
        //    InitializeComponent();
            
        //}

        //public frmSuche(DataSet ds, string searchstring, BindingSource bs)
        //{
        //    m_strSuchstring = searchstring;
        //    m_DS = ds;
        //    m_BS = bs;
        //    InitializeComponent();
        //}
        /*
        /// <summary>
        /// The Constructor requires two connector objects</summary>
        /// <param name="ds">a DataSet</param>
        /// <param name="searchstring">the search string</param>  
        /// <param name="mainform">reference to the frmMain</param>
        public frmSuche(DataSet ds, string searchstring, frmMain mainform)
        {
            m_strSuchstring = searchstring;
            m_DS = ds;
            this.frmMain = mainform;
            InitializeComponent();
        }
        */
        /*
        public frmSuche(DataSet ds, string searchstring, frmMain mainform, BindingSource bs)
        {
            m_strSuchstring = searchstring;
            m_DS = ds;
            this.frmMain = mainform;
            m_BS = bs;
            InitializeComponent();
        }
        */
        #endregion

        /// <summary>
        /// Please make sure to set the property Privat to true or false 
        /// before calling any functions!
        /// </summary>
        /// <param name="ds">a DataSet</param>
        /// <param name="searchstring">the searchstring</param>
        /// <param name="obj_cao">the cCao Object from frmMain</param>
        /// <param name="obj_sugar">the cSugar Object from frmMain</param>
        /// <param name="mainform">reference to the frmMain</param>
        /// <param name="bsCao">The Databinding for Cao</param>
        /// <param name="bsSugar">The Databinding for Sugar</param>
        public frmSuche(DataSet ds, string searchstring, cCao obj_cao, cSugar obj_sugar, frmMain mainform, BindingSource bsCao, BindingSource bsSugar)
        {
            m_strSuchstring = searchstring;
            m_DS = ds;
            m_objCao = obj_cao;
            m_objSugar = obj_sugar;
            this.frmMain = mainform;
            m_BS_Cao = bsCao;
            m_BS_Sugar = bsSugar;
            InitializeComponent();
        }

        private void frmSuche_Load(object sender, EventArgs e)
        {
            /* Basic settings */
            rbName.Checked = true;
            rbStrasse.Checked = false;
            rbTelefon.Checked = false;
            txtSuche.Text = m_strSuchstring;
            
            try
            {
                ClearBothDgvs();
                if (m_privat == true)
                {
                    StartSearchPrivat(m_strSuchstring);
                }
                else
                {
                    StartSearchFirma(m_strSuchstring);
                }

            }
            catch (Exception adsf)
            {
                MessageBox.Show(adsf.ToString());
            }
        }

        private void cmdSuche_Click(object sender, EventArgs e)
        {
            if (m_privat == true)
            {
                ClearBothDgvs();
                StartSearchPrivat(txtSuche.Text);
            }
            else
            {
                ClearBothDgvs();
                StartSearchFirma(txtSuche.Text);
            }
        }

        /// <summary>
        /// Searches Cao and Sugar for contacts
        /// according to the checked search criterion.
        /// </summary>
        /// <param name="searchstring">the stirng to search for</param>
        public void StartSearchPrivat(string searchstring)
        {
            /* Create new Object cCao.
             * Use the Search Contacts Method.
             * Bind the DataSource from the Binding Source
             * Set the DataSource for the dgv */

            m_objCao = new cCao(m_DS, m_BS_Cao);
            if (rbName.Checked == true)
            {
                m_objCao.SearchContactsByName(searchstring);
            }
            if (rbStrasse.Checked == true)
            {
                m_objCao.SearchContactsBySteet(searchstring);
            }
            if (rbTelefon.Checked == true)
            {
                m_objCao.SearchContactsByPhone(searchstring);
            }
            m_BS_Cao.DataSource = m_DS.Tables[m_const_strCaoTableSearchAllPrivate];
            dgvCaoSuche.DataSource = m_BS_Cao;
            HideRowsCao();

            m_objSugar = new cSugar(m_DS, m_BS_Sugar);
            if (rbName.Checked == true)
            {
                m_objSugar.SearchContactsByName(searchstring);
            }
            if (rbStrasse.Checked == true)
            {
                m_objSugar.SearchContactsByStreet(searchstring);
            }
            if (rbTelefon.Checked == true)
            {
                m_objSugar.SearchContactsByPhone(searchstring);
            }
            m_BS_Sugar.DataSource = m_DS.Tables[m_const_strSugarTableSearchAllPrivate];
            dgvSugarSuche.DataSource = m_BS_Sugar;
            HideRowsSugarContacts();
        }
        /// <summary>
        /// Searches Cao and Sugar for companies
        /// according to the checked search criterion.
        /// </summary>
        /// <param name="searchstring">the stirng to search for</param>
        public void StartSearchFirma(string searchstring)
        {
            m_objCao = new cCao(m_DS, m_BS_Cao);
            if (rbName.Checked == true)
            {
                m_objCao.SearchCompanyByName(searchstring);   
            }
            if (rbStrasse.Checked == true)
            {
                m_objCao.SearchCompanyByStreet(searchstring);
            }
            if (rbTelefon.Checked == true)
            {
                m_objCao.SearchCompanyByPhone(searchstring);
            }
            m_BS_Cao.DataSource = m_DS.Tables[m_const_strCaoTableSearchAllCompanies];
            dgvCaoSuche.DataSource = m_BS_Cao;
            HideRowsCao();
           
            m_objSugar = new cSugar(m_DS, m_BS_Sugar);
            if (rbName.Checked == true)
            {
                m_objSugar.SearchCompanyByName(searchstring);   
            }
            if (rbStrasse.Checked == true)
            {
                m_objSugar.SearchCompanyByStreet(searchstring);
            }
            if (rbTelefon.Checked == true)
            {
                m_objSugar.SearchCompanyByPhone(searchstring);
            }
            m_BS_Sugar.DataSource = m_DS.Tables[m_const_strSugarTableSearchAllCompanies];
            dgvSugarSuche.DataSource = m_BS_Sugar;
            HideRowsSugarCompanies();
        }
        private void cmdClear_Click(object sender, EventArgs e)
        {
            ClearBothDgvs();
            txtSuche.Text = "";
            txtSuche.Focus();
        }
        /// <summary>
        /// Clears Both DGVs from the frmSuche
        /// </summary>
        public void ClearBothDgvs()
        {
            /* if the DatagridView is empty do nothing
             * else set the source to null to clear the DataGridView
             * at last clear the search field and set the Focus to it.
             */

            ClearDataSet(m_const_strCaoTableSearchAllPrivate);
            ClearDataSet(m_const_strCaoTableSearchAllCompanies);
            ClearDataSet(m_const_strSugarTableSearchAllPrivate);
            ClearDataSet(m_const_strSugarTableSearchAllCompanies);

            if (dgvCaoSuche.ColumnCount > 0)
            {
                dgvCaoSuche.DataSource = null;
                #region obsolete
                //if (m_privat == true)
                //{
                //    m_DS.Tables.Remove(m_const_strCaoTableSearchAllPrivate);
                //}
                //else if (m_privat == false)
                //{
                //    m_DS.Tables.Remove(m_const_strCaoTableSearchAllCompanies);
                //}
                #endregion
            }

            if (dgvSugarSuche.ColumnCount > 0)
            {
                dgvSugarSuche.DataSource = null;
                #region obsolete
                //if (m_privat == true)
                //{
                //    m_DS.Tables.Remove(m_const_strSugarTableSearchAllPrivate);
                //}
                //else if (m_privat == false)
                //{
                //    m_DS.Tables.Remove(m_const_strSugarTableSearchAllCompanies);
                //}
                #endregion
            }

        }
        /// <summary>
        /// Removes a given Table from the DataSet
        /// </summary>
        /// <param name="tablename">the table name</param>
        private void ClearDataSet(string tablename)
        {
            if (m_DS.Tables.Contains(tablename) == true)
            {
                m_DS.Tables.Remove(tablename);
            }
        }
        #region the hide row methods
        /// <summary>
        /// Hides the unneccesary rows from the user.
        /// </summary>
        private void HideRowsCao()
        {
            dgvCaoSuche.Columns["REC_ID"].Visible = false;
            dgvCaoSuche.Columns["MATCHCODE"].Visible = false;
            dgvCaoSuche.Columns["KUNDENGRUPPE"].Visible = false;
            dgvCaoSuche.Columns["SPRACH_ID"].Visible = false;
            dgvCaoSuche.Columns["GESCHLECHT"].Visible = false;
            dgvCaoSuche.Columns["KUNNUM1"].Visible = false;
            dgvCaoSuche.Columns["KUNNUM2"].Visible = false;
            dgvCaoSuche.Columns["LAND"].Visible = false;
            dgvCaoSuche.Columns["NAME2"].Visible = false;
            dgvCaoSuche.Columns["NAME3"].Visible = false;
            dgvCaoSuche.Columns["ABTEILUNG"].Visible = false;
            dgvCaoSuche.Columns["DEFAULT_LIEFANSCHRIFT_ID"].Visible = false;
            dgvCaoSuche.Columns["GRUPPE"].Visible = false;
            dgvCaoSuche.Columns["BRIEFANREDE"].Visible = false;
            dgvCaoSuche.Columns["BLZ"].Visible = false;
            dgvCaoSuche.Columns["KTO"].Visible = false;
            dgvCaoSuche.Columns["BANK"].Visible = false;
            dgvCaoSuche.Columns["IBAN"].Visible = false;
            dgvCaoSuche.Columns["SWIFT"].Visible = false;
            dgvCaoSuche.Columns["KTO_INHABER"].Visible = false;
            dgvCaoSuche.Columns["DEB_NUM"].Visible = false;
            dgvCaoSuche.Columns["KRD_NUM"].Visible = false;
            dgvCaoSuche.Columns["STATUS"].Visible = false;
            dgvCaoSuche.Columns["NET_SKONTO"].Visible = false;
            dgvCaoSuche.Columns["NET_TAGE"].Visible = false;
            dgvCaoSuche.Columns["BRT_TAGE"].Visible = false;
            dgvCaoSuche.Columns["WAEHRUNG"].Visible = false;
            dgvCaoSuche.Columns["UST_NUM"].Visible = false;
            dgvCaoSuche.Columns["VERTRETER_ID"].Visible = false;
            dgvCaoSuche.Columns["PROVIS_PROZ"].Visible = false;
            dgvCaoSuche.Columns["INFO"].Visible = false;
            dgvCaoSuche.Columns["GRABATT"].Visible = false;
            dgvCaoSuche.Columns["KUN_KRDLIMIT"].Visible = false;
            dgvCaoSuche.Columns["KUN_LIEFART"].Visible = false;
            dgvCaoSuche.Columns["KUN_ZAHLART"].Visible = false;
            dgvCaoSuche.Columns["KUN_PRLISTE"].Visible = false;
            dgvCaoSuche.Columns["KUN_LIEFSPERRE"].Visible = false;
            dgvCaoSuche.Columns["LIEF_LIEFART"].Visible = false;
            dgvCaoSuche.Columns["LIEF_ZAHLART"].Visible = false;
            dgvCaoSuche.Columns["LIEF_PRLISTE"].Visible = false;
            dgvCaoSuche.Columns["LIEF_TKOSTEN"].Visible = false;
            dgvCaoSuche.Columns["LIEF_MBWERT"].Visible = false;
            dgvCaoSuche.Columns["PR_EBENE"].Visible = false;
            dgvCaoSuche.Columns["BRUTTO_FLAG"].Visible = false;
            dgvCaoSuche.Columns["MWST_FREI_FLAG"].Visible = false;
            dgvCaoSuche.Columns["KUNPREIS_AUTO"].Visible = false;
            dgvCaoSuche.Columns["KUN_SEIT"].Visible = false;
            dgvCaoSuche.Columns["KUN_GEBDATUM"].Visible = false;
            dgvCaoSuche.Columns["ENTFERNUNG"].Visible = false;
            dgvCaoSuche.Columns["ERSTELLT"].Visible = false;
            dgvCaoSuche.Columns["ERST_NAME"].Visible = false;
            dgvCaoSuche.Columns["GEAEND"].Visible = false;
            dgvCaoSuche.Columns["GEAEND_NAME"].Visible = false;
            dgvCaoSuche.Columns["SHOP_KUNDE"].Visible = false;
            dgvCaoSuche.Columns["SHOP_ID"].Visible = false;
            dgvCaoSuche.Columns["SHOP_NEWSLETTER"].Visible = false;
            dgvCaoSuche.Columns["SHOP_KUNDE_ID"].Visible = false;
            dgvCaoSuche.Columns["SHOP_CHANGE_FLAG"].Visible = false;
            dgvCaoSuche.Columns["SHOP_DEL_FLAG"].Visible = false;
            dgvCaoSuche.Columns["SHOP_PASSWORD"].Visible = false;
            dgvCaoSuche.Columns["USERFELD_01"].Visible = false;
            dgvCaoSuche.Columns["USERFELD_02"].Visible = false;
            dgvCaoSuche.Columns["USERFELD_03"].Visible = false;
            dgvCaoSuche.Columns["USERFELD_04"].Visible = false;
            dgvCaoSuche.Columns["USERFELD_05"].Visible = false;
            dgvCaoSuche.Columns["USERFELD_06"].Visible = false;
            dgvCaoSuche.Columns["USERFELD_07"].Visible = false;
            dgvCaoSuche.Columns["USERFELD_08"].Visible = false;
            dgvCaoSuche.Columns["USERFELD_09"].Visible = false;
            dgvCaoSuche.Columns["USERFELD_10"].Visible = false;
        }
        /// <summary>
        /// Hides the unneccesary rows from the user.
        /// </summary>
        private void HideRowsSugarContacts()
        {
            dgvSugarSuche.Columns["id"].Visible = false;
            dgvSugarSuche.Columns["date_entered"].Visible = false;
            dgvSugarSuche.Columns["date_modified"].Visible = false;
            dgvSugarSuche.Columns["modified_user_id"].Visible = false;
            dgvSugarSuche.Columns["created_by"].Visible = false;
            dgvSugarSuche.Columns["description"].Visible = false;
            dgvSugarSuche.Columns["deleted"].Visible = false;
            dgvSugarSuche.Columns["assigned_user_id"].Visible = false;
            //dgvSugarSuche.Columns["salutation"].Visible = false;
            //dgvSugarSuche.Columns["first_name"].Visible = false;
            //dgvSugarSuche.Columns["last_name"].Visible = false;
            dgvSugarSuche.Columns["title"].Visible = false;
            dgvSugarSuche.Columns["department"].Visible = false;
            dgvSugarSuche.Columns["do_not_call"].Visible = false;
            dgvSugarSuche.Columns["phone_home"].Visible = false;
            dgvSugarSuche.Columns["phone_mobile"].Visible = false;
            dgvSugarSuche.Columns["phone_work"].Visible = false;
            dgvSugarSuche.Columns["phone_other"].Visible = false;
            dgvSugarSuche.Columns["phone_fax"].Visible = false;
            //dgvSugarSuche.Columns["primary_address_street"].Visible = false;
            //dgvSugarSuche.Columns["primary_address_city"].Visible = false;
            //dgvSugarSuche.Columns["primary_address_state"].Visible = false;
            //dgvSugarSuche.Columns["primary_address_postalcode"].Visible = false;
            //dgvSugarSuche.Columns["primary_address_country"].Visible = false;
            dgvSugarSuche.Columns["alt_address_street"].Visible = false;
            dgvSugarSuche.Columns["alt_address_city"].Visible = false;
            dgvSugarSuche.Columns["alt_address_state"].Visible = false;
            dgvSugarSuche.Columns["alt_address_postalcode"].Visible = false;
            dgvSugarSuche.Columns["alt_address_country"].Visible = false;
            dgvSugarSuche.Columns["assistant"].Visible = false;
            dgvSugarSuche.Columns["assistant_phone"].Visible = false;
            dgvSugarSuche.Columns["lead_source"].Visible = false;
            dgvSugarSuche.Columns["reports_to_id"].Visible = false;
            dgvSugarSuche.Columns["birthdate"].Visible = false;
            dgvSugarSuche.Columns["campaign_id"].Visible = false;
        }
        /// <summary>
        /// Hides the unneccesary rows from the user.
        /// </summary>
        private void HideRowsSugarCompanies()
        {
            dgvSugarSuche.Columns["id"].Visible = false;
            //dgvSugarSuche.Columns["name"].Visible = false;
            dgvSugarSuche.Columns["date_entered"].Visible = false;
            dgvSugarSuche.Columns["date_modified"].Visible = false;
            dgvSugarSuche.Columns["modified_user_id"].Visible = false;
            dgvSugarSuche.Columns["created_by"].Visible = false;
            dgvSugarSuche.Columns["description"].Visible = false;
            dgvSugarSuche.Columns["deleted"].Visible = false;
            dgvSugarSuche.Columns["assigned_user_id"].Visible = false;
            dgvSugarSuche.Columns["account_type"].Visible = false;
            dgvSugarSuche.Columns["industry"].Visible = false;
            dgvSugarSuche.Columns["annual_revenue"].Visible = false;
            dgvSugarSuche.Columns["phone_fax"].Visible = false;
            //dgvSugarSuche.Columns["billing_address_street"].Visible = false;
            //dgvSugarSuche.Columns["billing_address_city"].Visible = false;
            //dgvSugarSuche.Columns["billing_address_state"].Visible = false;
            //dgvSugarSuche.Columns["billing_address_postalcode"].Visible = false;
            //dgvSugarSuche.Columns["billing_address_country"].Visible = false;
            dgvSugarSuche.Columns["rating"].Visible = false;
            //dgvSugarSuche.Columns["phone_office"].Visible = false;
            //dgvSugarSuche.Columns["phone_alternate"].Visible = false;
            //dgvSugarSuche.Columns["website"].Visible = false;
            dgvSugarSuche.Columns["ownership"].Visible = false;
            dgvSugarSuche.Columns["employees"].Visible = false;
            dgvSugarSuche.Columns["ticker_symbol"].Visible = false;
            dgvSugarSuche.Columns["shipping_address_street"].Visible = false;
            dgvSugarSuche.Columns["shipping_address_city"].Visible = false;
            dgvSugarSuche.Columns["shipping_address_state"].Visible = false;
            dgvSugarSuche.Columns["shipping_address_postalcode"].Visible = false;
            dgvSugarSuche.Columns["shipping_address_country"].Visible = false;
            dgvSugarSuche.Columns["parent_id"].Visible = false;
            dgvSugarSuche.Columns["sic_code"].Visible = false;
            dgvSugarSuche.Columns["campaign_id"].Visible = false;
        }
        //private void ClearBothDgvsNew()
        //{

        //    /* if the DatagridView is empty do nothing
        //     * else set the source to null to clear the DataGridView
        //     * at last clear the search field and set the Focus to it.
        //     */
        //    dgvCaoSuche.DataSource = null;
        //    m_DV_Search_Cao_human = null;
        //    if (m_DS.Tables[m_const_strCaoTableSearchAllPrivate] != null)
        //    {
        //        m_DS.Tables.Remove(m_const_strCaoTableSearchAllPrivate);
        //    }

        //    dgvSugarSuche.DataSource = null;
        //    m_DV_Search_Sugar_human = null;
        //    if (m_DS.Tables[m_const_strSugarTableSearchAllPrivate] != null)
        //    {
        //        m_DS.Tables.Remove(m_const_strSugarTableSearchAllPrivate);
        //    }

        //}
        #endregion

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            if (m_privat == true)
            {
                CompareContacts();
                this.Close();
            }
            else
            {
                CompareCompanies();
                this.Close();
            }
        }

        #region propertys
        /// <summary>
        /// Sets weither if the search is for Private Customers
        /// or for a Company
        /// </summary>
        /// <value>true or false, true = private, false = company</value>
        public bool Privat
        {
            get
            {
                return m_privat;
            }
            set
            {
                m_privat = value;
            }
        }
        #endregion

        private void txtSuche_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Checks a few Entrys from the two different selected Rows
        /// and gives a Message if there are fundamental differences.
        /// </summary>
        private void CompareContacts()
        {
            if (m_BS_Cao.Current != null)
            {
                cToolbox m_objTool = new cToolbox();
                string[] foo2;
                foo2 = m_objTool.SplitName(((DataRowView)m_BS_Cao.Current)["NAME1"].ToString());

                if (foo2[1] != ((DataRowView)m_BS_Sugar.Current)["last_name"].ToString())
                {
                    DialogResult dr = MessageBox.Show("Unterschiedliche Datenstze festgestellt (Nachname).\n Datenstze Konsolidieren?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        this.frmMain.DatensatzLadenPrivate();
                    }
                }

                else if (((DataRowView)m_BS_Cao.Current)["STRASSE"].ToString() != ((DataRowView)m_BS_Sugar.Current)["primary_address_street"].ToString())
                {
                    DialogResult dr = MessageBox.Show("Unterschiedliche Datenstze festgestellt (Strasse).\n Datenstze Konsolidieren?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        this.frmMain.DatensatzLadenPrivate();
                    }
                }

                else if (((DataRowView)m_BS_Cao.Current)["TELE1"].ToString() != ((DataRowView)m_BS_Sugar.Current)["phone_home"].ToString())
                {
                    DialogResult dr = MessageBox.Show("Unterschiedliche Datenstze festgestellt (Telefon).\n Datenstze Konsolidieren?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        this.frmMain.DatensatzLadenPrivate();
                    }
                }
                else
                {
                    this.frmMain.DatensatzLadenPrivate();
                }
            }
            else
            {
                MessageBox.Show("Es muss mindestens ein Cao Datensatz ausgewhlt sein!");
            }

        }

        /// <summary>
        /// Checks a few Entrys from the two different selected Rows
        /// and gives a Message if there are fundamental differences.
        /// </summary>
        private void CompareCompanies()
        {
            if (m_BS_Cao.Current != null)
            {
                if (((DataRowView)m_BS_Cao.Current)["NAME1"].ToString() != ((DataRowView)m_BS_Sugar.Current)["name"].ToString())
                {
                    DialogResult dr = MessageBox.Show("Unterschiedliche Datenstze festgestellt (Nachname).\n Datenstze Konsolidieren?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        this.frmMain.DatensatzLadenCompany();
                    }
                }

                else if (((DataRowView)m_BS_Cao.Current)["STRASSE"].ToString() != ((DataRowView)m_BS_Sugar.Current)["billing_address_street"].ToString())
                {
                    DialogResult dr = MessageBox.Show("Unterschiedliche Datenstze festgestellt (Strasse).\n Datenstze Konsolidieren?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        this.frmMain.DatensatzLadenCompany();
                    }
                }

                else if (((DataRowView)m_BS_Cao.Current)["TELE1"].ToString() != ((DataRowView)m_BS_Sugar.Current)["phone_office"].ToString())
                {
                    DialogResult dr = MessageBox.Show("Unterschiedliche Datenstze festgestellt (Telefon).\n Datenstze Konsolidieren?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        this.frmMain.DatensatzLadenCompany();
                    }
                }
                else
                {
                    this.frmMain.DatensatzLadenCompany();
                }

            }
            else
            {
                MessageBox.Show("Es muss mindestens ein Cao Datensatz angewählt sein!");
            }
        }
    }
}
