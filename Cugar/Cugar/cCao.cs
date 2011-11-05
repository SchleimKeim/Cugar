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
        private const string m_const_strCaoTableSearchAll = "tblCaoSearchAll";
        private const string m_const_strCaoTableSearchHuman = "tblCaoSearchHuman";
        private const string m_const_strCaoVersandarten = "tblCaoVersandarten";
        private const string m_const_strCaoZahlarten = "tblcaoversandarten";

        private String m_server;
        private String m_user;
        private String m_pw;
        private String m_dbname;
        private BindingSource m_BS;

        private DataSet m_dsCao;
        private OdbcConnection m_cnCao;
        private OdbcDataAdapter m_daCao;
        #endregion       


        /// <summary>
        ///  Constructor expecting a DataSet
        /// </summary>
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
            StringBuilder m_sCaoConnect = new StringBuilder();

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
            //return m_dsCao;
        }

        /// <summary>
        ///  Loads the "Cao Versandarten" into the referenced DataSet   
        /// </summary>
        public void LoadCaoVersandarten()
        {
            OdbcCommand m_cmdCaoVersandarten = new OdbcCommand(@"select NAME from registry where MAINKEY='MAIN\\LIEFART';", m_cnCao);
            m_daCao = new OdbcDataAdapter(m_cmdCaoVersandarten);
            m_daCao.Fill(m_dsCao, m_const_strCaoVersandarten);
            m_BS.DataSource = m_dsCao.Tables[m_const_strCaoVersandarten];
        }
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
        ///Searches the table adressen for a given Searchstring
        ///and inserts a "tblCaoSearchAll" into the DataSet.</summary>
        /// <param name="searchstring">the search string</param>
        public void search_ds_all_persons(string searchstring)
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
            m_daCao.FillSchema(m_dsCao, SchemaType.Source, m_const_strCaoTableSearchAll);
            m_daCao.Fill(m_dsCao, m_const_strCaoTableSearchAll);

            //added 03.11.2011
            
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

        public void UpdateAll()
        {
            //Update
            //OdbcCommand myUpdateCommand = new OdbcCommand("UPDATE adressen SET fldStudentNr = ?, fldName = ?, fldVorname = ?, fldKlassenNr = ?, fldKlassenBez = ?, fldNotenNr = ?, fldNote = ?, fldFachNr = ?, fldBezeichnung = ? WHERE fldStudentNr = ?", m_cnCao);            
            #region string build for update commant
            StringBuilder sbUpdate = new StringBuilder();
            sbUpdate.Append("UPDATE adressen SET REC_ID = ?, ");
            sbUpdate.Append("MATCHCODE = ?, ");
            sbUpdate.Append("KUNDENGRUPPE = ?, ");
            sbUpdate.Append("SPRACH_ID = ?, ");
            sbUpdate.Append("GESCHLECHT = ?, ");
            sbUpdate.Append("KUNNUM1 = ?, ");
            sbUpdate.Append("KUNNUM2 = ?, ");
            sbUpdate.Append("NAME1 = ?, ");
            sbUpdate.Append("PLZ = ?, ");
            sbUpdate.Append("ORT = ?, ");
            sbUpdate.Append("LAND = ?, ");
            sbUpdate.Append("NAME2 = ?, ");
            sbUpdate.Append("NAME3 = ?, ");
            sbUpdate.Append("ABTEILUNG = ?, ");
            sbUpdate.Append("ANREDE = ?, ");
            sbUpdate.Append("STRASSE = ?, ");
            sbUpdate.Append("POSTFACH = ?, ");
            sbUpdate.Append("PF_PLZ = ?, ");
            sbUpdate.Append("DEFAULT_LIEFANSCHRIFT_ID = ?, ");
            sbUpdate.Append("GRUPPE = ?, ");
            sbUpdate.Append("TELE1 = ?, ");
            sbUpdate.Append("TELE2 = ?, ");
            sbUpdate.Append("FAX = ?, ");
            sbUpdate.Append("FUNK = ?, ");
            sbUpdate.Append("EMAIL = ?, ");
            sbUpdate.Append("EMAIL2 = ?, ");
            sbUpdate.Append("INTERNET = ?, ");
            sbUpdate.Append("DIVERSES = ?, ");
            sbUpdate.Append("BRIEFANREDE = ?, ");
            sbUpdate.Append("BLZ = ?, ");
            sbUpdate.Append("KTO = ?, ");
            sbUpdate.Append("BANK = ?, ");
            sbUpdate.Append("IBAN = ?, ");
            sbUpdate.Append("SWIFT = ?, ");
            sbUpdate.Append("KTO_INHABER = ?, ");
            sbUpdate.Append("DEB_NUM = ?, ");
            sbUpdate.Append("KRD_NUM = ?, ");
            sbUpdate.Append("STATUS = ?, ");
            sbUpdate.Append("NET_SKONTO = ?, ");
            sbUpdate.Append("NET_TAGE = ?, ");
            sbUpdate.Append("BRT_TAGE = ?, ");
            sbUpdate.Append("WAEHRUNG = ?, ");
            sbUpdate.Append("UST_NUM = ?, ");
            sbUpdate.Append("VERTRETER_ID = ?, ");
            sbUpdate.Append("PROVIS_PROZ = ?, ");
            sbUpdate.Append("INFO = ?, ");
            sbUpdate.Append("GRABATT = ?, ");
            sbUpdate.Append("KUN_KRDLIMIT = ?, ");
            sbUpdate.Append("KUN_LIEFART = ?, ");
            sbUpdate.Append("KUN_ZAHLART = ?, ");
            sbUpdate.Append("KUN_PRLISTE = ?, ");
            sbUpdate.Append("KUN_LIEFSPERRE = ?, ");
            sbUpdate.Append("LIEF_LIEFART = ?, ");
            sbUpdate.Append("LIEF_ZAHLART = ?, ");
            sbUpdate.Append("LIEF_PRLISTE = ?, ");
            sbUpdate.Append("LIEF_TKOSTEN = ?, ");
            sbUpdate.Append("LIEF_MBWERT = ?, ");
            sbUpdate.Append("PR_EBENE = ?, ");
            sbUpdate.Append("BRUTTO_FLAG = ?, ");
            sbUpdate.Append("MWST_FREI_FLAG = ?, ");
            sbUpdate.Append("KUNPREIS_AUTO = ?, ");
            sbUpdate.Append("KUN_SEIT = ?, ");
            sbUpdate.Append("KUN_GEBDATUM = ?, ");
            sbUpdate.Append("ENTFERNUNG = ?, ");
            sbUpdate.Append("ERSTELLT = ?, ");
            sbUpdate.Append("ERST_NAME = ?, ");
            sbUpdate.Append("GEAEND = ?, ");
            sbUpdate.Append("GEAEND_NAME = ?, ");
            sbUpdate.Append("SHOP_KUNDE = ?, ");
            sbUpdate.Append("SHOP_ID = ?, ");
            sbUpdate.Append("SHOP_NEWSLETTER = ?, ");
            sbUpdate.Append("SHOP_KUNDE_ID = ?, ");
            sbUpdate.Append("SHOP_CHANGE_FLAG = ?, ");
            sbUpdate.Append("SHOP_DEL_FLAG = ?, ");
            sbUpdate.Append("SHOP_PASSWORD = ?, ");
            sbUpdate.Append("USERFELD_01 = ?, ");
            sbUpdate.Append("USERFELD_02 = ?, ");
            sbUpdate.Append("USERFELD_03 = ?, ");
            sbUpdate.Append("USERFELD_04 = ?, ");
            sbUpdate.Append("USERFELD_05 = ?, ");
            sbUpdate.Append("USERFELD_06 = ?, ");
            sbUpdate.Append("USERFELD_07 = ?, ");
            sbUpdate.Append("USERFELD_08 = ?, ");
            sbUpdate.Append("USERFELD_09 = ?, ");
            sbUpdate.Append("USERFELD_10 = ?");
            sbUpdate.Append(" WHERE REC_ID = ?");
            #endregion
            
            OdbcCommand myUpdateCommand = new OdbcCommand(sbUpdate.ToString(), m_cnCao);

            #region parameters
            myUpdateCommand.Parameters.Add("@REC_ID", OdbcType.Int, 11, "@REC_ID");
            myUpdateCommand.Parameters.Add("@MATCHCODE", OdbcType.VarChar, 255, "@MATCHCODE");
            myUpdateCommand.Parameters.Add("@KUNDENGRUPPE", OdbcType.Int, 11, "@KUNDENGRUPPE");
            myUpdateCommand.Parameters.Add("@SPRACH_ID", OdbcType.Int, 11, "@SPRACH_ID");
            myUpdateCommand.Parameters.Add("@GESCHLECHT", OdbcType.Char, 1, "@GESCHLECHT");
            myUpdateCommand.Parameters.Add("@KUNNUM1", OdbcType.VarChar, 20, "@KUNNUM1");
            myUpdateCommand.Parameters.Add("@KUNNUM2", OdbcType.VarChar, 20, "@KUNNUM2");
            myUpdateCommand.Parameters.Add("@NAME1", OdbcType.VarChar, 40, "@NAME1");
            myUpdateCommand.Parameters.Add("@PLZ", OdbcType.VarChar, 10, "@PLZ");
            myUpdateCommand.Parameters.Add("@ORT", OdbcType.VarChar, 40, "@ORT");
            myUpdateCommand.Parameters.Add("@LAND", OdbcType.VarChar, 5, "@LAND");
            myUpdateCommand.Parameters.Add("@NAME2", OdbcType.VarChar, 40, "@NAME2");
            myUpdateCommand.Parameters.Add("@NAME3", OdbcType.VarChar, 40, "@NAME3");
            myUpdateCommand.Parameters.Add("@ABTEILUNG", OdbcType.VarChar, 40, "@ABTEILUNG");
            myUpdateCommand.Parameters.Add("@ANREDE", OdbcType.VarChar, 40, "@ANREDE");
            myUpdateCommand.Parameters.Add("@STRASSE", OdbcType.VarChar, 40, "@STRASSE");
            myUpdateCommand.Parameters.Add("@POSTFACH", OdbcType.VarChar, 40, "@POSTFACH");
            myUpdateCommand.Parameters.Add("@PF_PLZ", OdbcType.VarChar, 10, "@PF_PLZ");
            myUpdateCommand.Parameters.Add("@DEFAULT_LIEFANSCHRIFT_ID", OdbcType.Int, 11, "@DEFAULT_LIEFANSCHRIFT_ID");
            myUpdateCommand.Parameters.Add("@GRUPPE", OdbcType.VarChar, 4, "@GRUPPE");
            myUpdateCommand.Parameters.Add("@TELE1", OdbcType.VarChar, 100, "@TELE1");
            myUpdateCommand.Parameters.Add("@TELE2", OdbcType.VarChar, 100, "@TELE2");
            myUpdateCommand.Parameters.Add("@FAX", OdbcType.VarChar, 100, "@FAX");
            myUpdateCommand.Parameters.Add("@FUNK", OdbcType.VarChar, 100, "@FUNK");
            myUpdateCommand.Parameters.Add("@EMAIL", OdbcType.VarChar, 100, "@EMAIL");
            myUpdateCommand.Parameters.Add("@EMAIL2", OdbcType.VarChar, 100, "@EMAIL2");
            myUpdateCommand.Parameters.Add("@INTERNET", OdbcType.VarChar, 100, "@INTERNET");
            myUpdateCommand.Parameters.Add("@DIVERSES", OdbcType.VarChar, 100, "@DIVERSES");
            myUpdateCommand.Parameters.Add("@BRIEFANREDE", OdbcType.VarChar, 100, "@BRIEFANREDE");
            myUpdateCommand.Parameters.Add("@BLZ", OdbcType.VarChar, 20, "@BLZ");
            myUpdateCommand.Parameters.Add("@KTO", OdbcType.VarChar, 20, "@KTO");
            myUpdateCommand.Parameters.Add("@BANK", OdbcType.VarChar, 40, "@BANK");
            myUpdateCommand.Parameters.Add("@IBAN", OdbcType.VarChar, 100, "@IBAN");
            myUpdateCommand.Parameters.Add("@SWIFT", OdbcType.VarChar, 100, "@SWIFT");
            myUpdateCommand.Parameters.Add("@KTO_INHABER", OdbcType.VarChar, 40, "@KTO_INHABER");
            myUpdateCommand.Parameters.Add("@DEB_NUM", OdbcType.Int, 11, "@DEB_NUM");
            myUpdateCommand.Parameters.Add("@KRD_NUM", OdbcType.Int, 11, "@KRD_NUM");
            myUpdateCommand.Parameters.Add("@STATUS", OdbcType.Int, 11, "@STATUS");
            myUpdateCommand.Parameters.Add("@NET_SKONTO", OdbcType.Decimal, 5, "@NET_SKONTO");
            myUpdateCommand.Parameters.Add("@NET_TAGE", OdbcType.TinyInt, 4, "@NET_TAGE");
            myUpdateCommand.Parameters.Add("@BRT_TAGE", OdbcType.TinyInt, 4, "@BRT_TAGE");
            myUpdateCommand.Parameters.Add("@WAEHRUNG", OdbcType.VarChar, 5, "@WAEHRUNG");
            myUpdateCommand.Parameters.Add("@UST_NUM", OdbcType.VarChar, 25, "@UST_NUM");
            myUpdateCommand.Parameters.Add("@VERTRETER_ID", OdbcType.Int, 11, "@VERTRETER_ID");
            myUpdateCommand.Parameters.Add("@PROVIS_PROZ", OdbcType.Decimal, 5,, "@PROVIS_PROZ");
            myUpdateCommand.Parameters.Add("@INFO", OdbcType.Text, 65537, "@INFO");
            myUpdateCommand.Parameters.Add("@GRABATT", OdbcType.Decimal, 5, "@GRABATT");
            myUpdateCommand.Parameters.Add("@KUN_KRDLIMIT", OdbcType.Decimal, 10, "@KUN_KRDLIMIT");
            myUpdateCommand.Parameters.Add("@KUN_LIEFART", OdbcType.Int, 11, "@KUN_LIEFART");
            myUpdateCommand.Parameters.Add("@KUN_ZAHLART", OdbcType.Int, 11, "@KUN_ZAHLART");
            //myUpdateCommand.Parameters.Add("@KUN_PRLISTE", OdbcType.enum('N','Y'), "@KUN_PRLISTE");
            //myUpdateCommand.Parameters.Add("@KUN_LIEFSPERRE", OdbcType.enum('N','Y'), , "@KUN_LIEFFSPERRE");
            myUpdateCommand.Parameters.Add("@LIEF_LIEFART", OdbcType.Int, 11, "@LIEF_LIEFART");
            myUpdateCommand.Parameters.Add("@LIEF_ZAHLART", OdbcType.Int, 11, "@LIEF_ZAHLART");
            //myUpdateCommand.Parameters.Add("@LIEF_PRLISTE", OdbcType.enum('N','Y'), , "@LIEF_PRLISTE");
            myUpdateCommand.Parameters.Add("@LIEF_TKOSTEN", OdbcType.Decimal, 10, "@LIEF_TKOSTEN");
            myUpdateCommand.Parameters.Add("@LIEF_MBWERT", OdbcType.Decimal, 10, "@LIEF_MBWERT");
            myUpdateCommand.Parameters.Add("@PR_EBENE", OdbcType.TinyInt, 1, "@PR_EBENE");
            //myUpdateCommand.Parameters.Add("@BRUTTO_FLAG", OdbcType.enum('N','Y'), , "@BRUTTO_FLAG");
            //myUpdateCommand.Parameters.Add("@MWST_FREI_FLAG", OdbcType.enum('N','Y') , , "@MWST_FREI_FLAG");
            //myUpdateCommand.Parameters.Add("@KUNPREIS_AUTO", OdbcType.enum('N','Y') , , "@KUNPREIS_AUTO");
            myUpdateCommand.Parameters.Add("@KUN_SEIT", OdbcType.Date, , "@KUN_SEIT");
            myUpdateCommand.Parameters.Add("@KUN_GEBDATUM", OdbcType.Date, , "@KUN_GEBDATUM");
            myUpdateCommand.Parameters.Add("@ERSTELLT", OdbcType.Date, , "@ERSTELLT");
            myUpdateCommand.Parameters.Add("@ERST_NAME", OdbcType.VarChar, 20, "@ERST_NAME"); 
            //myUpdateCommand.Parameters.Add("@GEAEND", OdbcType.Date, , "@GEAND");
            //myUpdateCommand.Parameters.Add("@GEAEND_NAME", OdbcType.VarChar, 20, "@GEAEND_NAME");
            //myUpdateCommand.Parameters.Add("@SHOP_KUNDE", enum('N','Y'), , "@SHOP_KUNDE");
            myUpdateCommand.Parameters.Add("@SHOP_ID", OdbcType.TinyInt, 3, "@SHOP_ID");
            //myUpdateCommand.Parameters.Add("@SHOP_NEWSLETTER", enum('N','Y'), , "@SHOP_NEWSLETTER");
            myUpdateCommand.Parameters.Add("@SHOP_KUNDE_ID", OdbcType.Int, 11, "@SHOP_KUNDE_ID");
            myUpdateCommand.Parameters.Add("@SHOP_CHANGE_FLAG", OdbcType.TinyInt, 1, "@SHOP_CHANGE_FLAG");
            //myUpdateCommand.Parameters.Add("@SHOP_DEL_FLAG", enum('N','Y'), , "@SHOP_DEL_FLAG");
            myUpdateCommand.Parameters.Add("@SHOP_PASSWORD", OdbcType.VarChar, 20, "@SHOP_PASSWORD");
            myUpdateCommand.Parameters.Add("@USERFELD_01", OdbcType.VarChar, 255, "@USERFELD_01");
            myUpdateCommand.Parameters.Add("@USERFELD_02", OdbcType.VarChar, 255, "@USERFELD_02");
            myUpdateCommand.Parameters.Add("@USERFELD_03", OdbcType.VarChar, 255, "@USERFELD_03");
            myUpdateCommand.Parameters.Add("@USERFELD_04", OdbcType.VarChar, 255, "@USERFELD_04");
            myUpdateCommand.Parameters.Add("@USERFELD_05", OdbcType.VarChar, 255, "@USERFELD_05");
            myUpdateCommand.Parameters.Add("@USERFELD_06", OdbcType.VarChar, 255, "@USERFELD_06");
            myUpdateCommand.Parameters.Add("@USERFELD_07", OdbcType.VarChar, 255, "@USERFELD_07");
            myUpdateCommand.Parameters.Add("@USERFELD_08", OdbcType.VarChar, 255, "@USERFELD_08");
            myUpdateCommand.Parameters.Add("@USERFELD_09", OdbcType.VarChar, 255, "@USERFELD_09");
            myUpdateCommand.Parameters.Add("@USERFELD_10", OdbcType.VarChar, 255, "@USERFELD_10");
            #endregion


            /* Try this if size fails
            OdbcParameter myParam = new OdbcParameter();
            myParam.ParameterName = "@REC_ID";
            myParam.OdbcType = OdbcType.Int;
            myParam.SourceColumn = "@REC_ID";
             */










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


            //delete
            //OdbcCommand myDeleteCommand = new OdbcCommand("delete from ADRESSEN_LIEF Where ADDR_ID=3;delete from ADRESSEN_TO_MERK Where ADDR_ID=3;DELETE FROM ADRESSEN WHERE REC_ID=3.DeleteCommand = myDeleteCommand;", myConnection);
            //myDeleteCommand.Parameters.Add("@fldStudentNr", OleDbType.Integer, 2, "fldStudentNr");
        }
        #endregion

        #region propertys
        ///// <summary>
        /////  Read only
        /////  Returns the DataSet
        /////  </summary>
        //public DataSet ds
        //{           
        //    get
        //    {
        //        return m_dsCao;
        //    }
        //}
        #endregion
    }
}