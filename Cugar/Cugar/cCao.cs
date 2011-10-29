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
        private String m_server;
        private String m_user;
        private String m_pw;
        private String m_dbname;

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
        ///  Loads the whole Database into the referenced DataSet.
        ///  Using a Tablename "tblCao"
        /// </summary>
        #region obsolete
        //public DataSet LoadDataSet()
        //{
        //    OdbcCommand m_cmdCaoSelect = new OdbcCommand("select * FROM ADRESSEN WHERE KUNDENGRUPPE=1 ORDER BY REC_ID;", m_cnCao);
        //    m_daCao = new OdbcDataAdapter(m_cmdCaoSelect);
        //    m_daCao.Fill(m_dsCao, "tblCao");   
        //    return m_dsCao;
        //}
        #endregion obsolete
        public void LoadDataSet()
        {
            OdbcCommand m_cmdCaoSelect = new OdbcCommand("select * FROM ADRESSEN WHERE KUNDENGRUPPE=1 ORDER BY REC_ID;", m_cnCao);
            m_daCao = new OdbcDataAdapter(m_cmdCaoSelect);
            m_daCao.Fill(m_dsCao, "tblCao");
            //return m_dsCao;
        }

        /// <summary>
        ///Searches the table adressen for a given Searchstring
        ///and inserts a "tblCaoSearchAll" into the DataSet.</summary>
        /// <param name="searchstring">the search string</param>
        public void search_ds_all(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            m_strCommand.Append(@"select * from adressen where NAME1 like ");
            m_strCommand.Append(@"'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append(@"%'");
            //m_strCommand.Append(@"select  * from adressen where NAME1 like 'Meier'");

            OdbcCommand m_cmdSearchCommand = new OdbcCommand(m_strCommand.ToString());
            m_daCao = new OdbcDataAdapter(m_cmdSearchCommand.CommandText, m_cnCao);
            m_daCao.FillSchema(m_dsCao, SchemaType.Source, "tblCaoSearchAll");
            m_daCao.Fill(m_dsCao, "tblCaoSearchAll");
        }

        /// <summary>
        ///Searches the table adressen for a given Searchstring
        ///and inserts a "tblCaoSearchHuman" into the DataSet.</summary>
        /// <param name="searchstring">the search string</param>
        public void search_ds_human(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            //SELECT `REC_ID`, `MATCHCODE`, `KUNDENGRUPPE`, `SPRACH_ID`, `GESCHLECHT`, `KUNNUM1`, `KUNNUM2`, `NAME1`, `PLZ`, `ORT`, `LAND`, `NAME2`, `NAME3`, `ABTEILUNG`, `ANREDE`, `STRASSE`, `POSTFACH`, `PF_PLZ`, `DEFAULT_LIEFANSCHRIFT_ID`, `GRUPPE`, `TELE1`, `TELE2`, `FAX`, `FUNK`, `EMAIL`, `EMAIL2`, `INTERNET`, `DIVERSES`, `BRIEFANREDE`, `BLZ`, `KTO`, `BANK`, `IBAN`, `SWIFT`, `KTO_INHABER`, `DEB_NUM`, `KRD_NUM`, `STATUS`, `NET_SKONTO`, `NET_TAGE`, `BRT_TAGE`, `WAEHRUNG`, `UST_NUM`, `VERTRETER_ID`, `PROVIS_PROZ`, LEFT(`INFO`, 256), `GRABATT`, `KUN_KRDLIMIT`, `KUN_LIEFART`, `KUN_ZAHLART`, `KUN_PRLISTE`, `KUN_LIEFSPERRE`, `LIEF_LIEFART`, `LIEF_ZAHLART`, `LIEF_PRLISTE`, `LIEF_TKOSTEN`, `LIEF_MBWERT`, `PR_EBENE`, `BRUTTO_FLAG`, `MWST_FREI_FLAG`, `KUNPREIS_AUTO`, `KUN_SEIT`, `KUN_GEBDATUM`, `ENTFERNUNG`, `ERSTELLT`, `ERST_NAME`, `GEAEND`, `GEAEND_NAME`, `SHOP_KUNDE`, `SHOP_ID`, `SHOP_NEWSLETTER`, `SHOP_KUNDE_ID`, `SHOP_CHANGE_FLAG`, `SHOP_DEL_FLAG`, `SHOP_PASSWORD`, `USERFELD_01`, `USERFELD_02`, `USERFELD_03`, `USERFELD_04`, `USERFELD_05`, `USERFELD_06`, `USERFELD_07`, `USERFELD_08`, `USERFELD_09`, `USERFELD_10` FROM `caofaktura`.`adressen` LIMIT 0, 1000;
            m_strCommand.Append(@"select ANREDE as Anrede, NAME1 as Name, STRASSE as Strasse, PLZ as PLZ, ORT as Ort, TELE1 as Telefon, FUNK as Mobile, EMAIL as Email from adressen where NAME1 like ");
            m_strCommand.Append(@"'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append(@"%'");
            //m_strCommand.Append(@"select  * from adressen where NAME1 like 'Meier'");
            OdbcCommand m_cmdSearchCommand = new OdbcCommand(m_strCommand.ToString());
            //OdbcDataAdapter m_daSearchCao = new OdbcDataAdapter(m_cmdSearchCommand.CommandText, m_cnCao);
            m_daCao = new OdbcDataAdapter(m_cmdSearchCommand.CommandText, m_cnCao);
            m_daCao.FillSchema(m_dsCao, SchemaType.Source, "tblCaoSearchHuman");
            m_daCao.Fill(m_dsCao, "tblCaoSearchHuman");            
            //return m_dsCao;            
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