using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace Cugar
{
    class CaoConnector
    {
        //Private Members
        private const string csQueryTempName = "qryCao";
        private String m_server;
        private String m_user;
        private String m_pw;
        private String m_dbname;
        private OleDbConnection m_cnCaoConnection;
        private DataSet m_dsCao = new DataSet();
        private OleDbDataAdapter m_daCao;
        private DataView m_dvCao;

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

        public void CaoConnect()
        {
            StringBuilder m_sCaoConnect = new StringBuilder();
            /* Original
            m_sSugarConnect.Append("Provider=MySQL Provider; Data Source=localhost; User ID=root; Password=00mysql00; Initial Catalog=caofaktura; Activation=Q34J-8GXH-X3T9-DURZ;");
            */
            m_sCaoConnect.Append("Provider=MySQL Provider; ");
            m_sCaoConnect.Append("Data Source=" + m_server + "; ");
            m_sCaoConnect.Append("User ID=" + m_user + "; ");
            m_sCaoConnect.Append("Password=" + m_pw + "; ");
            m_sCaoConnect.Append("Initial Catalog=" + m_dbname + "; ");
            m_sCaoConnect.Append("Activation=Q34J-8GXH-X3T9-DURZ;");

            m_cnCaoConnection = new OleDbConnection(m_sCaoConnect.ToString());
            //myConnection = m_conCaoConnection;

            m_cnCaoConnection.Open();
            LoadFirstRecord();

            m_cnCaoConnection.Close();
        }
        
        public void LoadFirstRecord()
        {
            m_daCao = new OleDbDataAdapter("SELECT * FROM adressen", m_cnCaoConnection);

            //OleDbCommand myUpdateCommand = new OleDbCommand("UPDATE qryNotenStudent SET fldStudentNr = ?, fldName = ?, fldVorname = ?, fldKlassenNr = ?, fldKlassenBez = ?, fldNotenNr = ?, fldNote = ?, fldFachNr = ?, fldBezeichnung = ? WHERE fldStudentNr = ?", myConnection);
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
            //OleDbCommand myDeleteCommand = new OleDbCommand("DELETE FROM qryNotenStudent WHERE fldStudentNr = ?", myConnection);
            //myDeleteCommand.Parameters.Add("@fldStudentNr", OleDbType.Integer, 2, "fldStudentNr");
            //m_daCao.DeleteCommand = myDeleteCommand;

            //m_daCao.Fill(m_dsCao, csQueryTempName);
            //m_dvCao = m_dsCao.Tables[csQueryTempName].DefaultView;            
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
        public DataView dvCaoFirsRecord
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
