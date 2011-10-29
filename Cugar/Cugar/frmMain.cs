﻿using System;
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
     */

    public partial class frmMain : Form
    {
        #region members
        private DataView m_dvCao = new DataView();
        private DataView m_dvSugar;
        private DataSet m_DS = new DataSet();
        private cCao m_objCao;
        private cSugar m_objSugar;
        private const string m_const_strSugarTable = "tblSugar";
        private const string m_const_strCaoTable = "tblCao";
        private frmMain m_objMainform;

        private string[] m_Datensatz;
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
                m_dvCao = m_DS.Tables[m_const_strCaoTable].DefaultView;
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
                m_dvSugar = m_DS.Tables[m_const_strSugarTable].DefaultView;
                dgvSugar.DataSource = m_dvSugar;
            }
            catch (Exception asdf)
            {
                MessageBox.Show("Ein Fehler ist aufgetreten!\n Bitte überprüfen Sie die Einstellungen!");
                MessageBox.Show(asdf.ToString());
                Application.Exit();
            }

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
            tstxtSuche.Clear();
        }

        private void tsCmdSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            //frmSuche m_objSuche = new frmSuche(m_DS, tstxtSuche.Text);
            frmSuche m_objSuche = new frmSuche(m_DS, tstxtSuche.Text, m_objCao, m_objSugar, this);
            //frmSuche m_objSuche = new frmSuche(m_DS, tstxtSuche.Text, m_objCao, m_objSugar);
            this.Hide();
            m_objSuche.Show();      
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
            foo.Append(" DataTables");
            MessageBox.Show(foo.ToString());
        }

        //private void tstxtSuche_Enter(object sender, EventArgs e)
        //{
        //    Search();
        //}

        //private void tstxtSuche_TextChanged(object sender, EventArgs e)
        //{

        //}

        public string[] Datensatz
        {
            get
            {
                return m_Datensatz;
            }
            set
            {
                m_Datensatz = value;
            }
        }

        
    }
}
