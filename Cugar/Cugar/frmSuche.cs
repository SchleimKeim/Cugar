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

        private const string m_const_strCaoTableSearchAll = "tblCaoSearchAll";
        private const string m_const_strSugarTableSearchAll = "tblSugarSearchAll";
        private const string m_const_strCaoTableSearchHuman = "tblCaoSearchHuman";
        private const string m_const_strSugarTableSearchHuman = "tblSugarSearchHuman";


        private string m_strSuchstring;
        private cCao m_objCao;
        private cSugar m_objSugar;
        private DataSet m_DS;
        private DataView m_DV;
        private DataView m_DV_Search_Cao;
        private DataView m_DV_Search_Cao_human = new DataView();
        private DataView m_DV_Search_Sugar;
        private DataView m_DV_Search_Sugar_human = new DataView();
        #endregion

        /// <summary>
        /// The Constructor requires two connector objects</summary>
        /// <param name="ds">a DataSet</param>
        /// <param name="searchstring">the search string</param>  
        public frmSuche(DataSet ds, string searchstring)
        {
            InitializeComponent();
            m_strSuchstring = searchstring;
            m_DS = ds;
        }

        public frmSuche(DataSet ds, string searchstring, cCao obj_cao, cSugar obj_sugar)
        {
            InitializeComponent();
            m_strSuchstring = searchstring;
            m_DS = ds;
            m_objCao = obj_cao;
            m_objSugar = obj_sugar;
        }

        private void frmSuche_Load(object sender, EventArgs e)
        {
            rbName.Checked = true;
            rbStrasse.Checked = false;
            rbTelefon.Checked = false;
            txtSuche.Text = m_strSuchstring;

            try
            {
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
            ClearBothDgvs();
            m_objCao = new cCao(m_DS);
            m_objCao.search_ds_human(searchstring);
            m_DV_Search_Cao_human = m_DS.Tables[m_const_strCaoTableSearchHuman].DefaultView;
            dgvCaoSuche.DataSource = m_DV_Search_Cao_human;

            m_objSugar = new cSugar(m_DS);
            m_objSugar.search_ds_human(searchstring);
            m_DV_Search_Sugar_human = m_DS.Tables[m_const_strSugarTableSearchHuman].DefaultView;
            dgvSugarSuche.DataSource = m_DV_Search_Sugar_human;
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

            if (dgvCaoSuche.ColumnCount > 1)
            {
                dgvCaoSuche.DataSource = null;
                m_DV_Search_Cao_human = null;
                m_DS.Tables[m_const_strCaoTableSearchHuman].Clear();
            }
            if (dgvSugarSuche.ColumnCount > 1)
            {
                dgvSugarSuche.DataSource = null;
                m_DV_Search_Sugar_human = null;
                m_DS.Tables[m_const_strSugarTableSearchHuman].Clear();
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
