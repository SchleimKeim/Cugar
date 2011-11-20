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
                throw;
            }
        }

        private void cmdSuche_Click(object sender, EventArgs e)
        {
            if (m_privat == true)
            {
                StartSearchPrivat(txtSuche.Text);
            }
            else
            {
                StartSearchFirma(txtSuche.Text);
            }
        }

        /// <summary>
        /// Searches for Private Customers
        /// </summary>
        /// <param name="searchstring">searchstring</param>
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
        }

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
        }
        private void cmdClear_Click(object sender, EventArgs e)
        {
            ClearBothDgvs();
            txtSuche.Text = "";
            txtSuche.Focus();
        }

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

        private void ClearDataSet(string tablename)
        {
            if (m_DS.Tables.Contains(tablename) == true)
            {
                m_DS.Tables.Remove(tablename);
            }
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

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            /* temporary solution, find somethingg to bind the textfields to the actual m_DS */
            //this.frmMain.dtDatensatzCao = m_DS.Tables[m_const_strCaoTableSearchAll];
            if (m_privat == true)
            {
                this.frmMain.DatensatzLadenPrivate();
                //this.frmMain.SaveButtonEnabled = true;
                this.Close();
            }
            else
            {
                this.frmMain.DatensatzLadenCompany();
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
    }
}
