﻿using System;
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

        private const string m_const_strCaoTableSearchAll = "tblCaoSearchAll";
        private const string m_const_strSugarTableSearchAll = "tblSugarSearchAll";
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

        private BindingSource m_BS;

        #endregion

        /// <summary>
        /// The Constructor requires two connector objects</summary>
        /// <param name="ds">a DataSet</param>
        /// <param name="searchstring">the search string</param>  
        public frmSuche(DataSet ds, string searchstring)
        {
            m_strSuchstring = searchstring;
            m_DS = ds;
            InitializeComponent();
            
        }

        public frmSuche(DataSet ds, string searchstring, BindingSource bs)
        {
            m_strSuchstring = searchstring;
            m_DS = ds;
            m_BS = bs;
            InitializeComponent();
        }
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
        /// The Constructor requires two connector objects</summary>
        /// <param name="ds">a DataSet</param>
        /// <param name="searchstring">the search string</param>  
        /// <param name="obj_cao">the cCao Object from frmMain</param>
        /// <param name="obj_sugar">the cSugar Object from frmMain</param>
        /// <param name="mainform">reference to the frmMain</param>
        public frmSuche(DataSet ds, string searchstring, cCao obj_cao, cSugar obj_sugar, frmMain mainform, BindingSource bs)
        {
            m_strSuchstring = searchstring;
            m_DS = ds;
            m_objCao = obj_cao;
            m_objSugar = obj_sugar;
            this.frmMain = mainform;
            m_BS = bs;
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
                ClearBothDgvsNew();
                StartSearch(m_strSuchstring);
            }
            catch (Exception adsf)
            {
                MessageBox.Show(adsf.ToString());
                throw;
            }
        }

        private void cmdSuche_Click(object sender, EventArgs e)
        {
            StartSearch(txtSuche.Text);
        }

        private void StartSearch(string searchstring)
        {
            m_objCao = new cCao(m_DS, m_BS);
            //m_objCao.search_ds_human_persons(searchstring);
            m_objCao.search_ds_all_persons(searchstring);
            //m_DV_Search_Cao_human = m_DS.Tables[m_const_strCaoTableSearchAll].DefaultView;
            m_BS.DataSource = m_DS.Tables[m_const_strCaoTableSearchAll];

            dgvCaoSuche.DataSource = m_BS;

            m_objSugar = new cSugar(m_DS, m_BS);
            //m_objSugar.search_ds_human_persons(searchstring);
            m_objSugar.search_ds_all_persons(searchstring);
            m_DV_Search_Sugar_human = m_DS.Tables[m_const_strSugarTableSearchAll].DefaultView;
            //m_BS.DataSource = m_DS.Tables[m_const_strSugarTableSearchAll];
            dgvSugarSuche.DataSource = m_DV_Search_Sugar_human;
            //dgvSugarSuche.DataSource = m_BS;
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            ClearBothDgvs();
            txtSuche.Text = "";
            txtSuche.Focus();

        }

        private void ClearBothDgvs()
        {
            /* if the DatagridView is empty do nothing
             * else set the source to null to clear the DataGridView
             * at last clear the search field and set the Focus to it.
             */

            if (dgvCaoSuche.ColumnCount > 0)
            {
                dgvCaoSuche.DataSource = null;
                m_DV_Search_Cao_human = null;
                m_DS.Tables.Remove(m_const_strCaoTableSearchAll);
            }
            if (dgvSugarSuche.ColumnCount > 0)
            {
                dgvSugarSuche.DataSource = null;
                m_DV_Search_Sugar_human = null;
                m_DS.Tables.Remove(m_const_strSugarTableSearchAll);
            }
        }

        private void ClearBothDgvsNew()
        {

            /* if the DatagridView is empty do nothing
             * else set the source to null to clear the DataGridView
             * at last clear the search field and set the Focus to it.
             */
            dgvCaoSuche.DataSource = null;
            m_DV_Search_Cao_human = null;
            if (m_DS.Tables[m_const_strCaoTableSearchAll] != null)
            {
                m_DS.Tables.Remove(m_const_strCaoTableSearchAll);
            }                
      
            dgvSugarSuche.DataSource = null;
            m_DV_Search_Sugar_human = null;
            if (m_DS.Tables[m_const_strSugarTableSearchAll] != null)
            {
                m_DS.Tables.Remove(m_const_strSugarTableSearchAll);
            }           
            
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            /* temporary solution, find somethingg to bind the textfields to the actual m_DS */
            //this.frmMain.dtDatensatzCao = m_DS.Tables[m_const_strCaoTableSearchAll];
            
            this.frmMain.DatensatzLaden();
            this.frmMain.SaveButtonEnabled = true;
            this.Close();
        }
    }
}
