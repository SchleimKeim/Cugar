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
    public partial class frmChanges_new : Form
    {

        private DataSet m_DS;
        private BindingSource m_BS;
        private const string m_const_strCaoTableSearchAllPrivate = "tblCaoSearchAllPrivate";
        private const string m_const_strCaoTableSearchAllCompanies = "tblCaoSearchAllCompanies";
        private const string m_const_strSugarTableSearchAllPrivate = "tblSugarSearchAllPrivate";
        private const string m_const_strSugarTableSearchAllCompanies = "tblSugarSearchAllCompanies";

        private const string m_const_strCaoTableSearchHuman = "tblCaoSearchHuman";
        private const string m_const_strSugarTableSearchHuman = "tblSugarSearchHuman";

        private const string m_const_strAktuellerCaoDatensatz = "tblCaoSelected";
        private const string m_const_strAktuellerSugarDatensatz = "tblSugarSelected";

        public frmChanges_new()
        {
            InitializeComponent();
        }


        public frmChanges_new(DataSet ds, BindingSource bs)
        {
            m_DS = ds;
            m_BS = bs;
            InitializeComponent();
        }

        private void frmChanges_new_Load(object sender, EventArgs e)
        {
            dgvSugarActive.DataSource = m_BS;
            FillTextBox();
        }

        private void FillTextBox()
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
                    foo.Append(" \n");
                    i++;
                }
                txtResult.Text = foo.ToString();
        }



        private void cmdAcceptChanges_Click(object sender, EventArgs e)
        {

            FillTextBox();
            dgvSugarActive.DataSource = null;
            dgvSugarActive.DataSource = m_DS.Tables[m_const_strSugarTableSearchAllPrivate].DefaultView;
            cSugar m_objSugar = new cSugar(m_DS, m_BS);
            m_objSugar.SaveChanges();
        }
    }
}
