using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Data.Odbc;
//using MySql.Data;

namespace Cugar
{
    /// <summary>
    ///  Alle relevanten CAO Funktionen.
    /// </summary>
    public class CaoConnector
    {
        #region private members
        //Private Members
        //private const string csQueryTempName = "qryCao";
        private String m_server;
        private String m_user;
        private String m_pw;
        private String m_dbname;

        private int m_intSearchCaoResult;
        
        private OdbcConnection m_cnCaoConnection;        
        private DataSet m_dsCao = new DataSet();
        private DataSet m_dsSearchCao = new DataSet();
        private OdbcDataAdapter m_daCao;
        private DataView m_dvCao;
        private DataView m_dvSearchCao;
        #endregion

        /// <summary>
        /// Please enter host, user, pw and databasename</summary>
        public CaoConnector(string server, string user, string pw, string dbname)
        {
            m_server = server;
            m_user = user;
            m_pw = pw;
            m_dbname = dbname;

            try
            {
                CaoConnect();     
            }
            catch (Exception asdf)
            {
                //MessageBox.Show("Beim Verbinden mit CAO-Faktura ist ein Fehler aufgetreten. \nBitte überprüfen Sie Ihre Einstellungen.");
                MessageBox.Show(asdf.ToString());
                throw;
            }

        }
        
        /// <summary>
        /// Second Constructor: Enter a DataSet</summary>
        public CaoConnector(DataSet ds)
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
                //MessageBox.Show("Beim Verbinden mit CAO-Faktura ist ein Fehler aufgetreten. \nBitte überprüfen Sie Ihre Einstellungen.");
                MessageBox.Show(asdf.ToString());
                throw;
            }
        }

        #region public methods
        /* Public Functons
         * - CaoConnect: connects to cao
         * - GetRecord(): shows a record
         * - SaveRecord(): Saves it
         * - UpdateRecord(): Updates a Record
         * - DeleteRecord(): Deletes a Record
         * */

        /// <summary>
        /// Connects to the Database</summary>
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

            #region connection string for oledb addon - currently not in use!
            //m_sCaoConnect.Append("Provider=MySQL Provider; ");
            //m_sCaoConnect.Append("Data Source=" + m_server + "; ");
            //m_sCaoConnect.Append("User ID=" + m_user + "; ");
            //m_sCaoConnect.Append("Password=" + m_pw + "; ");
            //m_sCaoConnect.Append("Initial Catalog=" + m_dbname + "; ");
            //m_sCaoConnect.Append("Activation=Q34J-8GXH-X3T9-DURZ;");
            #endregion
            #region connection string using official mysql.data connector - not in use!
            /* myConnectionString = "server=127.0.0.1;" _
            & "uid=root;" _
            & "pwd=12345;" _
            & "database=test;"  */

            //m_sCaoConnect.Append("server=" + m_server + ";");
            //m_sCaoConnect.Append("uid=" + m_user + ";");
            //m_sCaoConnect.Append("pwd=" + m_pw + ";");
            //m_sCaoConnect.Append("database=" + m_dbname + ";");
            #endregion    

            m_cnCaoConnection = new OdbcConnection(m_sCaoConnect.ToString());
        }
        /// <summary>
        /// Loads all address records</summary>
        private void LoadFirstRecord()
        {
            OdbcCommand m_cmdCaoSelect = new OdbcCommand("select ADRESSEN.* FROM ADRESSEN WHERE KUNDENGRUPPE=1 ORDER BY REC_ID;", m_cnCaoConnection);
            //von Silvio:
            //OdbcDataReader rd = cmd.ExecuteReader();
            //List<string> values = new  List<string>(10);
            //while (rd.Read())
            //{
            //    values.Add(rd.GetValue(0).ToString());
            //}
            #region temp
            //m_daCao = new OleDbDataAdapter("SELECT * FROM adressen", m_cnCaoConnection);

            //OleDbCommand myUpdateCommand = new OleDbCommand("UPDATE qryNotenStudent SET fldStudentNr = ?, fldName = ?, fldVorname = ?, fldKlassenNr = ?, fldKlassenBez = ?, fldNotenNr = ?, fldNote = ?, fldFachNr = ?, fldBezeichnung = ? WHERE fldStudentNr = ?", myConnection);
            //OleDbCommand myUpdateCommand = new OleDbCommand("UPDATE ADRESSEN SET NAME1 ='Hans Müller' where REC_ID=3", m_cnCaoConnection);
            //myUpdateCommand.Parameters.Add("@fldStudentNr", OleDbType.Integer, 2, "fldStudentNr");
            //myUpdateCommand.Parameters.Add("@fldName", OleDbType.VarChar, 255, "fldName");
            //myUpdateCommand.Parameters.Add("@fldVorname", OleDbType.VarChar, 255, "fldVorname");
            //myUpdateCommand.Parameters.Add("@fldKlassenNr", OleDbType.Integer, 2, "fldKlassenNr");
            //myUpdateCommand.Parameters.Add("@fldKlassenBez", OleDbType.VarChar, 255, "fldKlassenBez");
            //myUpdateCommand.Parameters.Add("@fldNotenNr", OleDbType.Integer, 2, "fldNotenNr");
            //myUpdateCommand.Parameters.Add("@fldNote", OleDbType.Single, 2, "fldNote");
            //myUpdateCommand.Parameters.Add("@fldFachNr", OleDbType.Integer, 2, "fldFachNr");
            //myUpdateCommand.Parameters.Add("@fldBezeichnung", OleDbType.VarChar, 255, "fldBezeichnung");
            //m_daCao.UpdateCommand = myUpdateCommand;

            //delete
//            OleDbCommand myDeleteCommand = new OleDbCommand("delete from ADRESSEN_LIEF Where ADDR_ID=3;delete from ADRESSEN_TO_MERK Where ADDR_ID=3;DELETE FROM ADRESSEN WHERE REC_ID=3.DeleteCommand = myDeleteCommand;", myConnection);
            //myDeleteCommand.Parameters.Add("@fldStudentNr", OleDbType.Integer, 2, "fldStudentNr");
            //m_daCaodelete from ADRESSEN_ASP Where ADDR_ID=3
//delete from ADRESSEN_LIEF Where ADDR_ID=3
//delete from ADRESSEN_TO_MERK Where ADDR_ID=3
            //DELETE FROM ADRESSEN WHERE REC_ID=3.DeleteCommand = myDeleteCommand;
            #endregion
            m_daCao = new OdbcDataAdapter(m_cmdCaoSelect);            
            m_daCao.FillSchema(m_dsCao, SchemaType.Source, "tblAdressen");
            m_daCao.Fill(m_dsCao, "tblAdressen");
            m_dvCao = m_dsCao.Tables["tblAdressen"].DefaultView;     
 
        }
        public void foo(DataSet asdf, DataTable asdf2)
        {
            m_daCao.Update(asdf, "tblCao");

        }
        public void GetRecord()
        {
        }
        public void SaveRecord()
        {
        }
        public void UpdateRecord()
        {
        }
        public void DeleteRecord()
        {
        }
        public int GetMaxRecord()
        {
            return m_dsCao.Tables[0].Rows.Count;
        }
        
        public void CreateView()
        {
            
        }
        /// <summary>
        ///Searches the table adressen and returns a DataView with all columns</summary>
        /// <param name="searchstring">the search string</param>
        public DataView generate_dv_all(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            m_strCommand.Append(@"select * from adressen where NAME1 like ");
            m_strCommand.Append(@"'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append(@"%'");
            //m_strCommand.Append(@"select  * from adressen where NAME1 like 'Meier'");

            OdbcCommand m_cmdSearchCommand = new OdbcCommand(m_strCommand.ToString());
            OdbcDataAdapter m_daSearchCao = new OdbcDataAdapter(m_cmdSearchCommand.CommandText, m_cnCaoConnection);
            m_daSearchCao.FillSchema(m_dsSearchCao, SchemaType.Source, "tblCaoSuche");
            m_daSearchCao.Fill(m_dsSearchCao, "tblCaoSuche");
            m_dvSearchCao = m_dsSearchCao.Tables["tblCaoSuche"].DefaultView;             
            return m_dvSearchCao;            
        }
        /// <summary>
        ///Searches the table adressen and returns a DataView with a selection of columns.</summary>
        /// <param name="searchstring">the search string</param>
        public DataView generate_dv_human(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            //SELECT `REC_ID`, `MATCHCODE`, `KUNDENGRUPPE`, `SPRACH_ID`, `GESCHLECHT`, `KUNNUM1`, `KUNNUM2`, `NAME1`, `PLZ`, `ORT`, `LAND`, `NAME2`, `NAME3`, `ABTEILUNG`, `ANREDE`, `STRASSE`, `POSTFACH`, `PF_PLZ`, `DEFAULT_LIEFANSCHRIFT_ID`, `GRUPPE`, `TELE1`, `TELE2`, `FAX`, `FUNK`, `EMAIL`, `EMAIL2`, `INTERNET`, `DIVERSES`, `BRIEFANREDE`, `BLZ`, `KTO`, `BANK`, `IBAN`, `SWIFT`, `KTO_INHABER`, `DEB_NUM`, `KRD_NUM`, `STATUS`, `NET_SKONTO`, `NET_TAGE`, `BRT_TAGE`, `WAEHRUNG`, `UST_NUM`, `VERTRETER_ID`, `PROVIS_PROZ`, LEFT(`INFO`, 256), `GRABATT`, `KUN_KRDLIMIT`, `KUN_LIEFART`, `KUN_ZAHLART`, `KUN_PRLISTE`, `KUN_LIEFSPERRE`, `LIEF_LIEFART`, `LIEF_ZAHLART`, `LIEF_PRLISTE`, `LIEF_TKOSTEN`, `LIEF_MBWERT`, `PR_EBENE`, `BRUTTO_FLAG`, `MWST_FREI_FLAG`, `KUNPREIS_AUTO`, `KUN_SEIT`, `KUN_GEBDATUM`, `ENTFERNUNG`, `ERSTELLT`, `ERST_NAME`, `GEAEND`, `GEAEND_NAME`, `SHOP_KUNDE`, `SHOP_ID`, `SHOP_NEWSLETTER`, `SHOP_KUNDE_ID`, `SHOP_CHANGE_FLAG`, `SHOP_DEL_FLAG`, `SHOP_PASSWORD`, `USERFELD_01`, `USERFELD_02`, `USERFELD_03`, `USERFELD_04`, `USERFELD_05`, `USERFELD_06`, `USERFELD_07`, `USERFELD_08`, `USERFELD_09`, `USERFELD_10` FROM `caofaktura`.`adressen` LIMIT 0, 1000;
            m_strCommand.Append(@"select ANREDE as Anrede, NAME1 as Name, STRASSE as Strasse, PLZ as PLZ, ORT as Ort, TELE1 as Telefon, FUNK as Mobile, EMAIL as Email from adressen where NAME1 like ");
            m_strCommand.Append(@"'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append(@"%'");
            //m_strCommand.Append(@"select  * from adressen where NAME1 like 'Meier'");

            OdbcCommand m_cmdSearchCommand = new OdbcCommand(m_strCommand.ToString());
            OdbcDataAdapter m_daSearchCao = new OdbcDataAdapter(m_cmdSearchCommand.CommandText, m_cnCaoConnection);
            m_daSearchCao.FillSchema(m_dsSearchCao, SchemaType.Source, "tblCaoSuche");
            m_daSearchCao.Fill(m_dsSearchCao, "tblCaoSuche");
            m_dvSearchCao = m_dsSearchCao.Tables["tblCaoSuche"].DefaultView;
            return m_dvSearchCao;

            //m_daCao.Update();
        }

        #endregion


        #region private methods
        /* Private Functions to call from within the Class */
        private void FillListBriefanrede()
        {
        }

        private void FillListVersand()
        {
        }

        private void FillListZahlart()
        {
        }
        #endregion

        #region public propertys
        /// <summary>
        ///Returns the a DataView with all Private Customers</summary>
        public DataView dvCao
        {
            get
            {
                if (m_dvCao == null)
                {
                    LoadFirstRecord();
                }
                return m_dvCao;

            }
        }

        /// <summary>
        ///Returns the a DataSet with all Private Customers</summary>
        public DataSet dsCaoDataSet
        {
            get
            {
                if (m_dsCao == null)
                {
                    LoadFirstRecord();
                }
                return m_dsCao;
            }
        }
        /// <summary>
        ///Returns the number of search results</summary>
        public int CaoSearchResults
        {
            get
            {
                if (m_dsCao.Tables["tblCaoSuche"].Rows.Count > 0)
                {
                    m_intSearchCaoResult = m_dsSearchCao.Tables["tblCaoSuche"].Rows.Count;
                    return m_intSearchCaoResult;
                }
                else
                {
                    return 0;
                } 
            }
        }
        #endregion
    }
}
