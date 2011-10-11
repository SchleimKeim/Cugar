using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;




namespace Cugar
{
    class SugarConnector
    {
        #region private members
        //Private Members
        private const string csQueryTempName = "qrySugar";
        private String m_server;
        private String m_user;
        private String m_pw;
        private String m_dbname;
        private MySqlConnection m_cnSugarConnection;
        private DataSet m_dsSugar = new DataSet();
        private MySqlDataAdapter m_daSugar;
        private DataView m_dvSugar;
        #endregion

                //Constructor
        public SugarConnector(string server, string user, string pw, string dbname)
        {
            m_server = server;
            m_user = user;
            m_pw = pw;
            m_dbname = dbname;

            try
            {
                SugarConnect();     
            }
            catch (Exception asdf)
            {
                //MessageBox.Show("Beim Verbinden mit Sugar-Faktura ist ein Fehler aufgetreten. \nBitte überprüfen Sie Ihre Einstellungen.");
                MessageBox.Show(asdf.ToString());
                throw;
            }

        }

        #region public methods
        /* Public Functons
         * - SugarConnect: connects to Sugar
         * - GetRecord(): shows a record
         * - SaveRecord(): Saves it
         * - UpdateRecord(): Updates a Record
         * - DeleteRecord(): Deletes a Record
         * */

        public void SugarConnect()
        {
            StringBuilder m_sSugarConnect = new StringBuilder();
            /* Original
            m_sSugarConnect.Append("Provider=MySQL Provider; Data Source=localhost; User ID=root; Password=00mysql00; Initial Catalog=Sugarfaktura; Activation=Q34J-8GXH-X3T9-DURZ;");
            */

            #region connection string for oledb addon - currently not in use!
            //m_sSugarConnect.Append("Provider=MySQL Provider; ");
            //m_sSugarConnect.Append("Data Source=" + m_server + "; ");
            //m_sSugarConnect.Append("User ID=" + m_user + "; ");
            //m_sSugarConnect.Append("Password=" + m_pw + "; ");
            //m_sSugarConnect.Append("Initial Catalog=" + m_dbname + "; ");
            //m_sSugarConnect.Append("Activation=Q34J-8GXH-X3T9-DURZ;");
            #endregion

            #region current connection string using official mysql.data connector
            /* myConnectionString = "server=127.0.0.1;" _
            & "uid=root;" _
            & "pwd=12345;" _
            & "database=test;"  */

            m_sSugarConnect.Append("server=" + m_server + ";");
            m_sSugarConnect.Append("uid=" + m_user + ";");
            m_sSugarConnect.Append("pwd=" + m_pw + ";");
            m_sSugarConnect.Append("database=" + m_dbname + ";");
            #endregion

            m_cnSugarConnection = new MySqlConnection(m_sSugarConnect.ToString());
        }

        public void LoadFirstRecord()
        {
            MySqlCommand m_cmdSugarSelect = new MySqlCommand("select * from contacts where deleted=0;", m_cnSugarConnection);
            m_daSugar = new MySqlDataAdapter(m_cmdSugarSelect);
            m_daSugar.FillSchema(m_dsSugar, SchemaType.Source, "tblContacts");
            m_daSugar.Fill(m_dsSugar, "tblContacts");
            m_dvSugar = m_dsSugar.Tables["tblContacts"].DefaultView;

            #region w00p
            //OleDbCommand myUpdateCommand = new OleDbCommand("UPDATE qryNotenStudent SET fldStudentNr = ?, fldName = ?, fldVorname = ?, fldKlassenNr = ?, fldKlassenBez = ?, fldNotenNr = ?, fldNote = ?, fldFachNr = ?, fldBezeichnung = ? WHERE fldStudentNr = ?", myConnection);
            //OleDbCommand myUpdateCommand = new OleDbCommand("UPDATE ADRESSEN SET NAME1 ='Hans Müller' where REC_ID=3", m_cnSugarConnection);
            //myUpdateCommand.Parameters.Add("@fldStudentNr", OleDbType.Integer, 2, "fldStudentNr");
            //myUpdateCommand.Parameters.Add("@fldName", OleDbType.VarChar, 255, "fldName");
            //myUpdateCommand.Parameters.Add("@fldVorname", OleDbType.VarChar, 255, "fldVorname");
            //myUpdateCommand.Parameters.Add("@fldKlassenNr", OleDbType.Integer, 2, "fldKlassenNr");
            //myUpdateCommand.Parameters.Add("@fldKlassenBez", OleDbType.VarChar, 255, "fldKlassenBez");
            //myUpdateCommand.Parameters.Add("@fldNotenNr", OleDbType.Integer, 2, "fldNotenNr");
            //myUpdateCommand.Parameters.Add("@fldNote", OleDbType.Single, 2, "fldNote");
            //myUpdateCommand.Parameters.Add("@fldFachNr", OleDbType.Integer, 2, "fldFachNr");
            //myUpdateCommand.Parameters.Add("@fldBezeichnung", OleDbType.VarChar, 255, "fldBezeichnung");
            //m_daSugar.UpdateCommand = myUpdateCommand;

            //delete
            //            OleDbCommand myDeleteCommand = new OleDbCommand("delete from ADRESSEN_LIEF Where ADDR_ID=3;delete from ADRESSEN_TO_MERK Where ADDR_ID=3;DELETE FROM ADRESSEN WHERE REC_ID=3.DeleteCommand = myDeleteCommand;", myConnection);
            //myDeleteCommand.Parameters.Add("@fldStudentNr", OleDbType.Integer, 2, "fldStudentNr");
            //m_daSugardelete from ADRESSEN_ASP Where ADDR_ID=3
            //delete from ADRESSEN_LIEF Where ADDR_ID=3
            //delete from ADRESSEN_TO_MERK Where ADDR_ID=3
            //DELETE FROM ADRESSEN WHERE REC_ID=3.DeleteCommand = myDeleteCommand;
            #endregion


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
        public DataView dvSugar
        {
            get
            {
                if (m_dvSugar == null)
                {
                    LoadFirstRecord();
                }
                return m_dvSugar;
            }
        }

        public DataSet dsSugarDataSet
        {
            get
            {
                if (m_dsSugar == null)
                {
                    LoadFirstRecord();
                }
                return m_dsSugar;
            }
        }
        #endregion

    }
}
