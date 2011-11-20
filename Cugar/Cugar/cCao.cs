using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.Odbc;

namespace Cugar
{
    /// <summary>
    ///  CaoConnector Class
    /// </summary>
    public class cCao
    {
        #region private members
        private const string m_const_strCaoTablePrivate = "tblCaoPrivate";
        private const string m_const_strCaoTableSearchAllPrivate = "tblCaoSearchAllPrivate";
        private const string m_const_strCaoTableSearchAllCompanies = "tblCaoSearchAllCompanies";

        private const string m_const_strCaoTableSearchHuman = "tblCaoSearchHuman";
        private const string m_const_strSugarTableSearchHuman = "tblSugarSearchHuman";

        private const string m_const_strAktuellerCaoDatensatz = "tblCaoSelected";
        private const string m_const_strAktuellerSugarDatensatz = "tblSugarSelected";

        private const string m_const_strCaoVersandarten = "tblCaoVersandarten";
        private const string m_const_strCaoZahlarten = "tblcaoversandarten";

        private String m_server;
        private String m_user;
        private String m_pw;
        private String m_dbname;
        private BindingSource m_BS;

        private StringBuilder m_sCaoConnect = new StringBuilder();

        private DataSet m_dsCao;
        private OdbcConnection m_cnCao;
        private OdbcDataAdapter m_daCao;
        #endregion       


        /// <summary>
        ///  Constructor expecting a DataSet
        /// </summary>
        /// <param name="ds">DataSet für Referenzierung</param>
        public cCao(DataSet ds)
        {
            m_dsCao = ds;
            m_server = Cugar.Properties.Settings.Default.caohost;
            m_user = Cugar.Properties.Settings.Default.caouser;
            m_pw = Cugar.Properties.Settings.Default.caopw;
            m_dbname = Cugar.Properties.Settings.Default.caodb;
            /*
            binding1.DataSource = fonts;
            listBox1.DataSource = binding1;
             */

            
            try
            {
                CaoConnect();
            }
            catch (Exception asdf)
            {
                MessageBox.Show(asdf.ToString());
                throw;
            }
        }

        /// <summary>
        ///  Constructor expecting a DataSet
        /// </summary>
        /// <param name="bs">Binding Source to reference</param>
        /// <param name="ds">DataSet to reference</param>
        public cCao(DataSet ds, BindingSource bs)
        {
            m_dsCao = ds;
            m_server = Cugar.Properties.Settings.Default.caohost;
            m_user = Cugar.Properties.Settings.Default.caouser;
            m_pw = Cugar.Properties.Settings.Default.caopw;
            m_dbname = Cugar.Properties.Settings.Default.caodb;
            /*
            binding1.DataSource = fonts;
            listBox1.DataSource = binding1;
             */
            m_BS = bs;           

            try
            {
                CaoConnect();
            }
            catch (Exception asdf)
            {
                MessageBox.Show(asdf.ToString());
                throw;
            }
        }


        #region methods
        /// <summary>
        ///  Builds a Connection to the given CaoHost
        ///  using the User Settings.
        /// </summary>
        private void CaoConnect()
        {
            //StringBuilder m_sCaoConnect = new StringBuilder();

            #region connection string for odbc
            m_sCaoConnect.Append("Driver={MySQL ODBC 5.1 Driver};");
            m_sCaoConnect.Append("Server=" + m_server + ";");
            m_sCaoConnect.Append("Database=" + m_dbname + ";");
            m_sCaoConnect.Append("User=" + m_user + ";");
            m_sCaoConnect.Append("Password=" + m_pw + ";");
            m_sCaoConnect.Append("Option=3");
            #endregion
            m_cnCao = new OdbcConnection(m_sCaoConnect.ToString());
        }

        /// <summary>
        ///  Loads all private Customers into the referenced DataSet.
        ///  Using a Tablename "tblCaoPrivate"
        /// </summary>
        public void LoadPrivateCustomers()
        {
            OdbcCommand m_cmdCaoSelect = new OdbcCommand("select * FROM ADRESSEN WHERE KUNDENGRUPPE=1 ORDER BY REC_ID;", m_cnCao);
            m_daCao = new OdbcDataAdapter(m_cmdCaoSelect);
            m_daCao.Fill(m_dsCao, m_const_strCaoTablePrivate);
        }

        /// <summary>
        ///  Loads the "Cao Versandarten" into the referenced DataSet
        /// </summary>
        public void LoadCaoVersandarten()
        {
            //load the list into a table
            OdbcCommand m_cmdCaoVersandarten = new OdbcCommand(@"select NAME from registry where MAINKEY='MAIN\\LIEFART';", m_cnCao);
            m_daCao = new OdbcDataAdapter(m_cmdCaoVersandarten);
            m_daCao.Fill(m_dsCao, m_const_strCaoVersandarten);
            m_BS.DataSource = m_dsCao.Tables[m_const_strCaoVersandarten];           
        }

        /// <summary>
        ///  Loads the "Cao Zahlungsarten" into the referenced combobox
        ///  <param name="cb">a combobox control</param>
        /// </summary>
        //public void LoadCaoZahlungsartenCBO(ComboBox cb)
        //{
        //    ComboBox m_cboFoo;
        //    m_cboFoo = cb;

        //    OdbcConnection m_cnFoo = new OdbcConnection(m_sCaoConnect.ToString());

        //    int spalten_nr = 0; //Nummer der Spalte, in der das gewnschte Element steht
        //    OdbcCommand cmd = new OdbcCommand(@"select NAME from ZAHLUNGSARTEN;", m_cnFoo);

        //    cmd.Connection = m_cnFoo;
        //    m_cnFoo.Open();

        //    m_cboFoo.Items.Clear();
        //    OdbcDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        m_cboFoo.Items.Add(dr.GetValue(spalten_nr).ToString());
        //    }
        //    dr.Close();
        //    m_cnFoo.Close();
        //}
        /// <summary>
        ///  Loads the "Cao Versandarten" into the referenced combobox
        ///  <param name="cb">a combobox control</param>
        /// </summary>
        //public void LoadCaoVersandArtenCBO(ComboBox cb)
        //{
        //    ComboBox m_cboFoo;
        //    m_cboFoo = cb;
        //    OdbcConnection m_cnFoo = new OdbcConnection(m_sCaoConnect.ToString());


        //    int spalten_nr = 0; //Nummer der Spalte, in der das gewnschte Element steht
        //    OdbcCommand cmd = new OdbcCommand(@"select NAME from registry where MAINKEY='MAIN\\LIEFART' order by VAL_INT;", m_cnFoo);

        //    cmd.Connection = m_cnFoo;
        //    m_cnFoo.Open();
        //    m_cboFoo.Items.Clear();

        //    OdbcDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        m_cboFoo.Items.Add(dr.GetValue(spalten_nr).ToString());
        //    }
        //    dr.Close();
        //    m_cnFoo.Close();
        //}

        /// <summary>
        ///  Loads the "Cao Zahlarten" into the referenced DataSet
        /// </summary>
        public void LoadCaoZahlarten()
        {
            OdbcCommand m_cmdCaoZahlungsarten = new OdbcCommand(@"select NAME from ZAHLUNGSARTEN;", m_cnCao);
            m_daCao = new OdbcDataAdapter(m_cmdCaoZahlungsarten);
            m_daCao.Fill(m_dsCao, m_const_strCaoZahlarten);
        }


        /// <summary>
        /// Searches for Contacts By Name.</summary>
        /// <param name="searchstring">the search string</param>
        public void SearchContactsByName(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            m_strCommand.Append(@"select * from adressen where NAME1 like ");
            m_strCommand.Append(@"'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append(@"%'");
            m_strCommand.Append(" AND KUNDENGRUPPE=1;");
            //m_strCommand.Append(@"select  * from adressen where NAME1 like 'Meier'");

            OdbcCommand m_cmdSearchCommand = new OdbcCommand(m_strCommand.ToString());
            m_daCao = new OdbcDataAdapter(m_cmdSearchCommand.CommandText, m_cnCao);
            m_daCao.FillSchema(m_dsCao, SchemaType.Source, m_const_strCaoTableSearchAllPrivate);
            m_daCao.Fill(m_dsCao, m_const_strCaoTableSearchAllPrivate);
        }
        /// <summary>
        /// Searches for Contacts by Street.</summary>
        /// <param name="searchstring">the search string</param>
        public void SearchContactsBySteet(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            m_strCommand.Append(@"select * from adressen where STRASSE like ");
            m_strCommand.Append(@"'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append(@"%'");
            m_strCommand.Append(" AND KUNDENGRUPPE=1;");
            //m_strCommand.Append(@"select  * from adressen where NAME1 like 'Meier'");

            OdbcCommand m_cmdSearchCommand = new OdbcCommand(m_strCommand.ToString());
            m_daCao = new OdbcDataAdapter(m_cmdSearchCommand.CommandText, m_cnCao);
            m_daCao.FillSchema(m_dsCao, SchemaType.Source, m_const_strCaoTableSearchAllPrivate);
            m_daCao.Fill(m_dsCao, m_const_strCaoTableSearchAllPrivate);
        }

        /// <summary>
        /// Searches for Contacts By Mainphone.</summary>
        /// <param name="searchstring">the search string</param>
        public void SearchContactsByPhone(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            m_strCommand.Append(@"select * from adressen where TELE1 like ");
            m_strCommand.Append(@"'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append(@"%'");
            m_strCommand.Append(" AND KUNDENGRUPPE=1;");
            //m_strCommand.Append(@"select  * from adressen where NAME1 like 'Meier'");

            OdbcCommand m_cmdSearchCommand = new OdbcCommand(m_strCommand.ToString());
            m_daCao = new OdbcDataAdapter(m_cmdSearchCommand.CommandText, m_cnCao);
            m_daCao.FillSchema(m_dsCao, SchemaType.Source, m_const_strCaoTableSearchAllPrivate);
            m_daCao.Fill(m_dsCao, m_const_strCaoTableSearchAllPrivate);
        }
        /// <summary>
        ///Searches the table adressen for a given Searchstring
        ///and inserts a "tblCaoSearchHuman" into the DataSet.</summary>
        /// <param name="searchstring">the search string</param>
        public void search_ds_human_persons(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            //SELECT `REC_ID`, `MATCHCODE`, `KUNDENGRUPPE`, `SPRACH_ID`, `GESCHLECHT`, `KUNNUM1`, `KUNNUM2`, `NAME1`, `PLZ`, `ORT`, `LAND`, `NAME2`, `NAME3`, `ABTEILUNG`, `ANREDE`, `STRASSE`, `POSTFACH`, `PF_PLZ`, `DEFAULT_LIEFANSCHRIFT_ID`, `GRUPPE`, `TELE1`, `TELE2`, `FAX`, `FUNK`, `EMAIL`, `EMAIL2`, `INTERNET`, `DIVERSES`, `BRIEFANREDE`, `BLZ`, `KTO`, `BANK`, `IBAN`, `SWIFT`, `KTO_INHABER`, `DEB_NUM`, `KRD_NUM`, `STATUS`, `NET_SKONTO`, `NET_TAGE`, `BRT_TAGE`, `WAEHRUNG`, `UST_NUM`, `VERTRETER_ID`, `PROVIS_PROZ`, LEFT(`INFO`, 256), `GRABATT`, `KUN_KRDLIMIT`, `KUN_LIEFART`, `KUN_ZAHLART`, `KUN_PRLISTE`, `KUN_LIEFSPERRE`, `LIEF_LIEFART`, `LIEF_ZAHLART`, `LIEF_PRLISTE`, `LIEF_TKOSTEN`, `LIEF_MBWERT`, `PR_EBENE`, `BRUTTO_FLAG`, `MWST_FREI_FLAG`, `KUNPREIS_AUTO`, `KUN_SEIT`, `KUN_GEBDATUM`, `ENTFERNUNG`, `ERSTELLT`, `ERST_NAME`, `GEAEND`, `GEAEND_NAME`, `SHOP_KUNDE`, `SHOP_ID`, `SHOP_NEWSLETTER`, `SHOP_KUNDE_ID`, `SHOP_CHANGE_FLAG`, `SHOP_DEL_FLAG`, `SHOP_PASSWORD`, `USERFELD_01`, `USERFELD_02`, `USERFELD_03`, `USERFELD_04`, `USERFELD_05`, `USERFELD_06`, `USERFELD_07`, `USERFELD_08`, `USERFELD_09`, `USERFELD_10` FROM `caofaktura`.`adressen` LIMIT 0, 1000;
            m_strCommand.Append(@"select ANREDE as Anrede, NAME1 as Name, STRASSE as Strasse, PLZ as PLZ, ORT as Ort, TELE1 as Telefon, FUNK as Mobile, EMAIL as Email from adressen where NAME1 like ");
            m_strCommand.Append(@"'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append(@"%'");
            m_strCommand.Append(" AND KUNDENGRUPPE=1");
            //m_strCommand.Append(@"select  * from adressen where NAME1 like 'Meier'");
            OdbcCommand m_cmdSearchCommand = new OdbcCommand(m_strCommand.ToString());
            m_daCao = new OdbcDataAdapter(m_cmdSearchCommand.CommandText, m_cnCao);
            m_daCao.FillSchema(m_dsCao, SchemaType.Source, m_const_strCaoTableSearchHuman);
            m_daCao.Fill(m_dsCao, m_const_strCaoTableSearchHuman);            
        }

        /// <summary>
        /// Searches for Companies by Name.
        /// </summary>
        /// <param name="searchstring">the searchstring</param>
        public void SearchCompanyByName(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            m_strCommand.Append(@"select * from adressen where NAME1 like ");
            m_strCommand.Append(@"'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append(@"%'");
            m_strCommand.Append(" AND KUNDENGRUPPE=2;");

            OdbcCommand m_cmdSearchCommand = new OdbcCommand(m_strCommand.ToString());
            m_daCao = new OdbcDataAdapter(m_cmdSearchCommand.CommandText, m_cnCao);
            m_daCao.FillSchema(m_dsCao, SchemaType.Source, m_const_strCaoTableSearchAllCompanies);
            m_daCao.Fill(m_dsCao, m_const_strCaoTableSearchAllCompanies);
        }
        /// <summary>
        /// Searches for Companies by Street.
        /// </summary>
        /// <param name="searchstring">the searchstring</param>
        public void SearchCompanyByStreet(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            m_strCommand.Append(@"select * from adressen where STRASSE like ");
            m_strCommand.Append(@"'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append(@"%'");
            m_strCommand.Append(" AND KUNDENGRUPPE=2;");

            OdbcCommand m_cmdSearchCommand = new OdbcCommand(m_strCommand.ToString());
            m_daCao = new OdbcDataAdapter(m_cmdSearchCommand.CommandText, m_cnCao);
            m_daCao.FillSchema(m_dsCao, SchemaType.Source, m_const_strCaoTableSearchAllCompanies);
            m_daCao.Fill(m_dsCao, m_const_strCaoTableSearchAllCompanies);
        }
        /// <summary>
        /// Searches for Companies by Mainphone.
        /// </summary>
        /// <param name="searchstring">the searchstring</param>
        public void SearchCompanyByPhone(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            m_strCommand.Append(@"select * from adressen where TELE1 like ");
            m_strCommand.Append(@"'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append(@"%'");
            m_strCommand.Append(" AND KUNDENGRUPPE=2;");

            OdbcCommand m_cmdSearchCommand = new OdbcCommand(m_strCommand.ToString());
            m_daCao = new OdbcDataAdapter(m_cmdSearchCommand.CommandText, m_cnCao);
            m_daCao.FillSchema(m_dsCao, SchemaType.Source, m_const_strCaoTableSearchAllCompanies);
            m_daCao.Fill(m_dsCao, m_const_strCaoTableSearchAllCompanies);
        }
        /// <summary>
        ///Updates the Database.
        ///</summary>
        public void UpdateAll()
        {
            m_daCao = new OdbcDataAdapter();

            //Update
            //OdbcCommand myUpdateCommand = new OdbcCommand("UPDATE adressen SET fldStudentNr = ?, fldName = ?, fldVorname = ?, fldKlassenNr = ?, fldKlassenBez = ?, fldNotenNr = ?, fldNote = ?, fldFachNr = ?, fldBezeichnung = ? WHERE fldStudentNr = ?", m_cnCao);            
            
            #region string build for update commant
            StringBuilder sbUpdate = new StringBuilder();
            sbUpdate.Append("UPDATE adressen SET REC_ID = ?, ");

            #region not in use
            //sbUpdate.Append("MATCHCODE = ?, ");
            //sbUpdate.Append("KUNDENGRUPPE = ?, ");
            //sbUpdate.Append("SPRACH_ID = ?, ");
            //sbUpdate.Append("GESCHLECHT = ?, ");
            //sbUpdate.Append("KUNNUM1 = ?, ");
            //sbUpdate.Append("KUNNUM2 = ?, ");
            #endregion
             
            sbUpdate.Append("NAME1 = ?, ");
            sbUpdate.Append("PLZ = ?, ");
            sbUpdate.Append("ORT = ?, ");

            #region not in use
            //sbUpdate.Append("LAND = ?, ");
            //sbUpdate.Append("NAME2 = ?, ");
            //sbUpdate.Append("NAME3 = ?, ");
            //sbUpdate.Append("ABTEILUNG = ?, ");
            #endregion

            sbUpdate.Append("ANREDE = ?, ");
            sbUpdate.Append("STRASSE = ?, ");

            #region not in use
            //sbUpdate.Append("POSTFACH = ?, ");
            //sbUpdate.Append("PF_PLZ = ?, ");
            //sbUpdate.Append("DEFAULT_LIEFANSCHRIFT_ID = ?, ");
            //sbUpdate.Append("GRUPPE = ?, ");
            #endregion

            sbUpdate.Append("TELE1 = ?, ");
            sbUpdate.Append("TELE2 = ?, ");
            sbUpdate.Append("FAX = ?, ");
            sbUpdate.Append("FUNK = ?, ");
            sbUpdate.Append("EMAIL = ?, ");
            //sbUpdate.Append("EMAIL2 = ?, ");
            sbUpdate.Append("INTERNET = ?, ");
            //sbUpdate.Append("DIVERSES = ?, ");
            sbUpdate.Append("BRIEFANREDE = ?, ");

            #region not in use
            //sbUpdate.Append("BLZ = ?, ");
            //sbUpdate.Append("KTO = ?, ");
            //sbUpdate.Append("BANK = ?, ");
            //sbUpdate.Append("IBAN = ?, ");
            //sbUpdate.Append("SWIFT = ?, ");
            //sbUpdate.Append("KTO_INHABER = ?, ");
            //sbUpdate.Append("DEB_NUM = ?, ");
            //sbUpdate.Append("KRD_NUM = ?, ");
            //sbUpdate.Append("STATUS = ?, ");
            //sbUpdate.Append("NET_SKONTO = ?, ");
            //sbUpdate.Append("NET_TAGE = ?, ");
            #endregion

            sbUpdate.Append("BRT_TAGE = ?, ");

            #region not in use
            //sbUpdate.Append("WAEHRUNG = ?, ");
            //sbUpdate.Append("UST_NUM = ?, ");
            //sbUpdate.Append("VERTRETER_ID = ?, ");
            //sbUpdate.Append("PROVIS_PROZ = ?, ");
            #endregion

            sbUpdate.Append("INFO = ?, ");
            //sbUpdate.Append("GRABATT = ?, ");
            //sbUpdate.Append("KUN_KRDLIMIT = ?, ");
            sbUpdate.Append("KUN_LIEFART = ?, ");
            sbUpdate.Append("KUN_ZAHLART = ?, ");

            #region not in use
            //sbUpdate.Append("KUN_PRLISTE = ?, ");
            //sbUpdate.Append("KUN_LIEFSPERRE = ?, ");
            //sbUpdate.Append("LIEF_LIEFART = ?, ");
            //sbUpdate.Append("LIEF_ZAHLART = ?, ");
            //sbUpdate.Append("LIEF_PRLISTE = ?, ");
            //sbUpdate.Append("LIEF_TKOSTEN = ?, ");
            //sbUpdate.Append("LIEF_MBWERT = ?, ");
            //sbUpdate.Append("PR_EBENE = ?, ");
            //sbUpdate.Append("BRUTTO_FLAG = ?, ");
            //sbUpdate.Append("MWST_FREI_FLAG = ?, ");
            //sbUpdate.Append("KUNPREIS_AUTO = ?, ");
            #endregion

            sbUpdate.Append("KUN_SEIT = ?, ");
            sbUpdate.Append("KUN_GEBDATUM = ?, ");

            #region not in use
            //sbUpdate.Append("ENTFERNUNG = ?, ");
            //sbUpdate.Append("ERSTELLT = ?, ");
            //sbUpdate.Append("ERST_NAME = ?, ");
            //sbUpdate.Append("GEAEND = ?, ");
            //sbUpdate.Append("GEAEND_NAME = ?, ");
            //sbUpdate.Append("SHOP_KUNDE = ?, ");
            //sbUpdate.Append("SHOP_ID = ?, ");
            //sbUpdate.Append("SHOP_NEWSLETTER = ?, ");
            //sbUpdate.Append("SHOP_KUNDE_ID = ?, ");
            //sbUpdate.Append("SHOP_CHANGE_FLAG = ?, ");
            //sbUpdate.Append("SHOP_DEL_FLAG = ?, ");
            //sbUpdate.Append("SHOP_PASSWORD = ?, ");
            //sbUpdate.Append("USERFELD_01 = ?, ");
            //sbUpdate.Append("USERFELD_02 = ?, ");
            //sbUpdate.Append("USERFELD_03 = ?, ");
            //sbUpdate.Append("USERFELD_04 = ?, ");
            //sbUpdate.Append("USERFELD_05 = ?, ");
            //sbUpdate.Append("USERFELD_06 = ?, ");
            //sbUpdate.Append("USERFELD_07 = ?, ");
            //sbUpdate.Append("USERFELD_08 = ?, ");
            //sbUpdate.Append("USERFELD_09 = ?, ");
            //sbUpdate.Append("USERFELD_10 = ?");
            #endregion

            sbUpdate.Append(" WHERE REC_ID = ?");
            #endregion
            
            OdbcCommand myUpdateCommand = new OdbcCommand(sbUpdate.ToString(), m_cnCao);

            #region parameters
            myUpdateCommand.Parameters.Add("@REC_ID", OdbcType.Int, 11, "@REC_ID");

            #region not in use
            //myUpdateCommand.Parameters.Add("@MATCHCODE", OdbcType.VarChar, 255, "@MATCHCODE");
            //myUpdateCommand.Parameters.Add("@KUNDENGRUPPE", OdbcType.Int, 11, "@KUNDENGRUPPE");
            //myUpdateCommand.Parameters.Add("@SPRACH_ID", OdbcType.Int, 11, "@SPRACH_ID");
            //myUpdateCommand.Parameters.Add("@GESCHLECHT", OdbcType.Char, 1, "@GESCHLECHT");
            //myUpdateCommand.Parameters.Add("@KUNNUM1", OdbcType.VarChar, 20, "@KUNNUM1");
            //myUpdateCommand.Parameters.Add("@KUNNUM2", OdbcType.VarChar, 20, "@KUNNUM2");
            #endregion

            myUpdateCommand.Parameters.Add("@NAME1", OdbcType.VarChar, 40, "@NAME1");
            myUpdateCommand.Parameters.Add("@PLZ", OdbcType.VarChar, 10, "@PLZ");
            myUpdateCommand.Parameters.Add("@ORT", OdbcType.VarChar, 40, "@ORT");

            #region not in use
            //myUpdateCommand.Parameters.Add("@LAND", OdbcType.VarChar, 5, "@LAND");
            //myUpdateCommand.Parameters.Add("@NAME2", OdbcType.VarChar, 40, "@NAME2");
            //myUpdateCommand.Parameters.Add("@NAME3", OdbcType.VarChar, 40, "@NAME3");
            //myUpdateCommand.Parameters.Add("@ABTEILUNG", OdbcType.VarChar, 40, "@ABTEILUNG");
            #endregion

            myUpdateCommand.Parameters.Add("@ANREDE", OdbcType.VarChar, 40, "@ANREDE");
            myUpdateCommand.Parameters.Add("@STRASSE", OdbcType.VarChar, 40, "@STRASSE");

            #region not in use
            //myUpdateCommand.Parameters.Add("@POSTFACH", OdbcType.VarChar, 40, "@POSTFACH");
            //myUpdateCommand.Parameters.Add("@PF_PLZ", OdbcType.VarChar, 10, "@PF_PLZ");
            //myUpdateCommand.Parameters.Add("@DEFAULT_LIEFANSCHRIFT_ID", OdbcType.Int, 11, "@DEFAULT_LIEFANSCHRIFT_ID");
            //myUpdateCommand.Parameters.Add("@GRUPPE", OdbcType.VarChar, 4, "@GRUPPE");
            #endregion
            myUpdateCommand.Parameters.Add("@TELE1", OdbcType.VarChar, 100, "@TELE1");
            myUpdateCommand.Parameters.Add("@TELE2", OdbcType.VarChar, 100, "@TELE2");
            myUpdateCommand.Parameters.Add("@FAX", OdbcType.VarChar, 100, "@FAX");
            myUpdateCommand.Parameters.Add("@FUNK", OdbcType.VarChar, 100, "@FUNK");
            myUpdateCommand.Parameters.Add("@EMAIL", OdbcType.VarChar, 100, "@EMAIL");
            //myUpdateCommand.Parameters.Add("@EMAIL2", OdbcType.VarChar, 100, "@EMAIL2");
            myUpdateCommand.Parameters.Add("@INTERNET", OdbcType.VarChar, 100, "@INTERNET");
            //myUpdateCommand.Parameters.Add("@DIVERSES", OdbcType.VarChar, 100, "@DIVERSES");
            myUpdateCommand.Parameters.Add("@BRIEFANREDE", OdbcType.VarChar, 100, "@BRIEFANREDE");
            #region not in use
            //myUpdateCommand.Parameters.Add("@BLZ", OdbcType.VarChar, 20, "@BLZ");
            //myUpdateCommand.Parameters.Add("@KTO", OdbcType.VarChar, 20, "@KTO");
            //myUpdateCommand.Parameters.Add("@BANK", OdbcType.VarChar, 40, "@BANK");
            //myUpdateCommand.Parameters.Add("@IBAN", OdbcType.VarChar, 100, "@IBAN");
            //myUpdateCommand.Parameters.Add("@SWIFT", OdbcType.VarChar, 100, "@SWIFT");
            //myUpdateCommand.Parameters.Add("@KTO_INHABER", OdbcType.VarChar, 40, "@KTO_INHABER");
            //myUpdateCommand.Parameters.Add("@DEB_NUM", OdbcType.Int, 11, "@DEB_NUM");
            //myUpdateCommand.Parameters.Add("@KRD_NUM", OdbcType.Int, 11, "@KRD_NUM");
            //myUpdateCommand.Parameters.Add("@STATUS", OdbcType.Int, 11, "@STATUS");            

            ////myUpdateCommand.Parameters.Add("@NET_SKONTO", OdbcType.Decimal, 5, "@NET_SKONTO");
            //OdbcParameter myParam1 = new OdbcParameter();
            //myParam1.ParameterName = "@NET_SKONTO";
            //myParam1.SourceColumn = "@NET_SKONTO";
            //myParam1.DbType = DbType.Decimal;
            //myParam1.Precision = 5;
            //myParam1.Scale = 2;
            //myUpdateCommand.Parameters.Add(myParam1);

            //myUpdateCommand.Parameters.Add("@NET_TAGE", OdbcType.TinyInt, 4, "@NET_TAGE");
            #endregion
            myUpdateCommand.Parameters.Add("@BRT_TAGE", OdbcType.TinyInt, 4, "@BRT_TAGE");

            #region not in use
            //myUpdateCommand.Parameters.Add("@WAEHRUNG", OdbcType.VarChar, 5, "@WAEHRUNG");
            //myUpdateCommand.Parameters.Add("@UST_NUM", OdbcType.VarChar, 25, "@UST_NUM");
            //myUpdateCommand.Parameters.Add("@VERTRETER_ID", OdbcType.Int, 11, "@VERTRETER_ID");

            ////myUpdateCommand.Parameters.Add("@PROVIS_PROZ", OdbcType.Decimal, 5,, "@PROVIS_PROZ");
            //OdbcParameter myParam2 = new OdbcParameter();
            //myParam2.ParameterName = "@PROVIS_PROZ";
            //myParam2.SourceColumn = "@PROVIS_PROZ";
            //myParam2.DbType = DbType.Decimal;
            //myParam2.Precision = 5;
            //myParam2.Scale = 2;
            //myUpdateCommand.Parameters.Add(myParam2);
            #endregion

            myUpdateCommand.Parameters.Add("@INFO", OdbcType.Text, 65537, "@INFO");   
            
            #region not in use
            ////myUpdateCommand.Parameters.Add("@GRABATT", OdbcType.Decimal, 5, "@GRABATT");
            //OdbcParameter myParam3 = new OdbcParameter();
            //myParam3.ParameterName = "@GRABATT";
            //myParam3.SourceColumn = "@GRABATT";
            //myParam3.DbType = DbType.Decimal;
            //myParam3.Precision = 5;
            //myParam3.Scale = 2;
            //myUpdateCommand.Parameters.Add(myParam3);

            ////myUpdateCommand.Parameters.Add("@KUN_KRDLIMIT", OdbcType.Decimal, 10, "@KUN_KRDLIMIT");
            //OdbcParameter myParam4 = new OdbcParameter();
            //myParam4.ParameterName = "@KUN_KRDLIMIT";
            //myParam4.SourceColumn = "@KUN_KRDLIMIT";
            //myParam4.DbType = DbType.Decimal;
            //myParam4.Precision = 10;
            //myParam4.Scale = 2;
            //myUpdateCommand.Parameters.Add(myParam4);
            #endregion

            myUpdateCommand.Parameters.Add("@KUN_LIEFART", OdbcType.Int, 11, "@KUN_LIEFART");
            myUpdateCommand.Parameters.Add("@KUN_ZAHLART", OdbcType.Int, 11, "@KUN_ZAHLART");
            
            #region not in use
            ////myUpdateCommand.Parameters.Add("@KUN_PRLISTE", OdbcType.enum('N','Y'), "@KUN_PRLISTE");
            ////myUpdateCommand.Parameters.Add("@KUN_LIEFSPERRE", OdbcType.enum('N','Y'), , "@KUN_LIEFFSPERRE");
            //myUpdateCommand.Parameters.Add("@LIEF_LIEFART", OdbcType.Int, 11, "@LIEF_LIEFART");
            //myUpdateCommand.Parameters.Add("@LIEF_ZAHLART", OdbcType.Int, 11, "@LIEF_ZAHLART");
            ////myUpdateCommand.Parameters.Add("@LIEF_PRLISTE", OdbcType.enum('N','Y'), , "@LIEF_PRLISTE");
            #endregion

            #region not in use
            ////myUpdateCommand.Parameters.Add("@LIEF_TKOSTEN", OdbcType.Decimal, 10, "@LIEF_TKOSTEN");
            //OdbcParameter myParam5 = new OdbcParameter();
            //myParam5.ParameterName = "@LIEF_TKOSTEN";
            //myParam5.SourceColumn = "@LIEF_TKOSTEN";
            //myParam5.DbType = DbType.Decimal;
            //myParam5.Precision = 10;
            //myParam5.Scale = 2;
            //myUpdateCommand.Parameters.Add(myParam5);

            ////myUpdateCommand.Parameters.Add("@LIEF_MBWERT", OdbcType.Decimal, 10, "@LIEF_MBWERT");
            //OdbcParameter myParam6 = new OdbcParameter();
            //myParam6.ParameterName = "@LIEF_MBWERT";
            //myParam6.SourceColumn = "@LIEF_MBWERT";
            //myParam6.DbType = DbType.Decimal;
            //myParam6.Precision = 10;
            //myParam6.Scale = 2;
            //myUpdateCommand.Parameters.Add(myParam6);


            //myUpdateCommand.Parameters.Add("@PR_EBENE", OdbcType.TinyInt, 1, "@PR_EBENE");
            ////myUpdateCommand.Parameters.Add("@BRUTTO_FLAG", OdbcType.enum('N','Y'), , "@BRUTTO_FLAG");
            ////myUpdateCommand.Parameters.Add("@MWST_FREI_FLAG", OdbcType.enum('N','Y') , , "@MWST_FREI_FLAG");
            ////myUpdateCommand.Parameters.Add("@KUNPREIS_AUTO", OdbcType.enum('N','Y') , , "@KUNPREIS_AUTO");
            #endregion

            //myUpdateCommand.Parameters.Add("@KUN_SEIT", OdbcType.Date, , "@KUN_SEIT");
            OdbcParameter myParam7 = new OdbcParameter();
            myParam7.ParameterName = "@KUN_SEIT";
            myParam7.SourceColumn = "@KUN_SEIT";
            myParam7.DbType = DbType.Date;            
            myUpdateCommand.Parameters.Add(myParam7);

            //myUpdateCommand.Parameters.Add("@KUN_GEBDATUM", OdbcType.Date, , "@KUN_GEBDATUM");
            OdbcParameter myParam8 = new OdbcParameter();
            myParam8.ParameterName = "@KUN_GEBDATUM";
            myParam8.SourceColumn = "@KUN_GEBDATUM";
            myParam8.DbType = DbType.Date;            
            myUpdateCommand.Parameters.Add(myParam8);

            #region not in use
            ////myUpdateCommand.Parameters.Add("@ERSTELLT", OdbcType.Date, , "@ERSTELLT");
            //OdbcParameter myParam9 = new OdbcParameter();
            //myParam9.ParameterName = "@ERSTELLT";
            //myParam9.SourceColumn = "@ERSTELLT";
            //myParam9.DbType = DbType.Date;
            //myUpdateCommand.Parameters.Add(myParam9);
            

            //myUpdateCommand.Parameters.Add("@ERST_NAME", OdbcType.VarChar, 20, "@ERST_NAME"); 
            ////myUpdateCommand.Parameters.Add("@GEAEND", OdbcType.Date, , "@GEAND");
            ////myUpdateCommand.Parameters.Add("@GEAEND_NAME", OdbcType.VarChar, 20, "@GEAEND_NAME");
            ////myUpdateCommand.Parameters.Add("@SHOP_KUNDE", enum('N','Y'), , "@SHOP_KUNDE");
            //myUpdateCommand.Parameters.Add("@SHOP_ID", OdbcType.TinyInt, 3, "@SHOP_ID");
            ////myUpdateCommand.Parameters.Add("@SHOP_NEWSLETTER", enum('N','Y'), , "@SHOP_NEWSLETTER");
            //myUpdateCommand.Parameters.Add("@SHOP_KUNDE_ID", OdbcType.Int, 11, "@SHOP_KUNDE_ID");
            //myUpdateCommand.Parameters.Add("@SHOP_CHANGE_FLAG", OdbcType.TinyInt, 1, "@SHOP_CHANGE_FLAG");
            ////myUpdateCommand.Parameters.Add("@SHOP_DEL_FLAG", enum('N','Y'), , "@SHOP_DEL_FLAG");
            //myUpdateCommand.Parameters.Add("@SHOP_PASSWORD", OdbcType.VarChar, 20, "@SHOP_PASSWORD");
            //myUpdateCommand.Parameters.Add("@USERFELD_01", OdbcType.VarChar, 255, "@USERFELD_01");
            //myUpdateCommand.Parameters.Add("@USERFELD_02", OdbcType.VarChar, 255, "@USERFELD_02");
            //myUpdateCommand.Parameters.Add("@USERFELD_03", OdbcType.VarChar, 255, "@USERFELD_03");
            //myUpdateCommand.Parameters.Add("@USERFELD_04", OdbcType.VarChar, 255, "@USERFELD_04");
            //myUpdateCommand.Parameters.Add("@USERFELD_05", OdbcType.VarChar, 255, "@USERFELD_05");
            //myUpdateCommand.Parameters.Add("@USERFELD_06", OdbcType.VarChar, 255, "@USERFELD_06");
            //myUpdateCommand.Parameters.Add("@USERFELD_07", OdbcType.VarChar, 255, "@USERFELD_07");
            //myUpdateCommand.Parameters.Add("@USERFELD_08", OdbcType.VarChar, 255, "@USERFELD_08");
            //myUpdateCommand.Parameters.Add("@USERFELD_09", OdbcType.VarChar, 255, "@USERFELD_09");
            //myUpdateCommand.Parameters.Add("@USERFELD_10", OdbcType.VarChar, 255, "@USERFELD_10");
            #endregion
            #endregion
                        
            m_daCao.UpdateCommand = myUpdateCommand;


            #region example
            /*
            myUpDateCommand.Parameters.Add("@fldStudentNr", OleDbType.Integer, 2, "fldStudentNr");
            myUpdateCommand.Parameters.Add("@fldName", OleDbType.VarChar, 255, "fldName");
            myUpdateCommand.Parameters.Add("@fldVorname", OleDbType.VarChar, 255, "fldVorname");
            myUpdateCommand.Parameters.Add("@fldKlassenNr", OleDbType.Integer, 2, "fldKlassenNr");
            myUpdateCommand.Parameters.Add("@fldKlassenBez", OleDbType.VarChar, 255, "fldKlassenBez");
            myUpdateCommand.Parameters.Add("@fldNotenNr", OleDbType.Integer, 2, "fldNotenNr");
            myUpdateCommand.Parameters.Add("@fldNote", OleDbType.Single, 2, "fldNote");
            myUpdateCommand.Parameters.Add("@fldFachNr", OleDbType.Integer, 2, "fldFachNr");
            myUpdateCommand.Parameters.Add("@fldBezeichnung", OleDbType.VarChar, 255, "fldBezeichnung");
            m_daCao.UpdateCommand = myUpdateCommand;
             */
            #endregion

            //delete
            //OdbcCommand myDeleteCommand = new OdbcCommand("delete from ADRESSEN_LIEF Where ADDR_ID=3;delete from ADRESSEN_TO_MERK Where ADDR_ID=3;DELETE FROM ADRESSEN WHERE REC_ID=3.DeleteCommand = myDeleteCommand;", myConnection);
            //myDeleteCommand.Parameters.Add("@fldStudentNr", OleDbType.Integer, 2, "fldStudentNr");
            m_daCao.Update(m_dsCao, m_const_strCaoTableSearchAllPrivate);         
            
        }


        /// <summary>
        ///  Creates a New Contact
        /// </summary>
        /// <param name="command">a complete odbccommand with parameters</param>
        public void CreateNew(OdbcCommand command)
        {
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception asdf)
            {
                MessageBox.Show(asdf.ToString()); 
                throw;
            }

            
        }

        private int GetLatestRecId()
        {
            OdbcCommand cmDB = new OdbcCommand("SELECT Max(REC_ID) as REC_ID FROM adressen;", m_cnCao);
            if (m_cnCao.State == ConnectionState.Closed)
            {
                m_cnCao.Open();
            }   

            OdbcDataReader dr = cmDB.ExecuteReader();
            int m_int_REC_ID = 1;
            if (dr.Read() == true)
            {
                m_int_REC_ID = Convert.ToInt32(dr.GetValue(0)) + 1;
            }
            dr.Close();
            return m_int_REC_ID;
        }
        #endregion

        #region propertys

        /// <summary>
        /// Returns the latest REC_ID from cao.adressen
        /// </summary>
        public int LatestRecId
        {
            get
            {
                return GetLatestRecId();
            }
        }
        /// <summary>
        /// Returns the CaoConnection
        /// </summary>
        public OdbcConnection CaoConnection
        {
            get
            {
                return m_cnCao;
            }
        }
        #endregion
    }
}