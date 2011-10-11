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
    class CaoConnector
    {
        #region private members
        //Private Members
        private const string csQueryTempName = "qryCao";
        private String m_server;
        private String m_user;
        private String m_pw;
        private String m_dbname;
        private OdbcConnection m_cnCaoConnection;
        
        private DataSet m_dsCao = new DataSet();
        private OdbcDataAdapter m_daCao;
        private DataView m_dvCao;
        #endregion

        //Constructor
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

        #region public methods
        /* Public Functons
         * - CaoConnect: connects to cao
         * - GetRecord(): shows a record
         * - SaveRecord(): Saves it
         * - UpdateRecord(): Updates a Record
         * - DeleteRecord(): Deletes a Record
         * */

        /* Connects to CAO */
        public void CaoConnect()
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
            #region current connection string using official mysql.data connector - not in use!
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
        
        public void LoadFirstRecord()
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
        #endregion
    }
}
