using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;




namespace Cugar
{
    /// <summary>
    ///  Alle relevanten Sugar Funktionen.
    /// </summary>
    public class SugarConnector
    {
        #region private members
        //Private Members
        //private const string csQueryTempName = "qrySugar";
        private String m_server;
        private String m_user;
        private String m_pw;
        private String m_dbname;
        private MySqlConnection m_cnSugarConnection;
        private DataSet m_dsSugar = new DataSet();
        private MySqlDataAdapter m_daSugar;
        private MySqlDataAdapter m_daSearchSugar;
        private DataView m_dvSugar;
        private DataView m_dvSearchSugar;
        private int m_intSugarSearchResult;
        #endregion


        //constructor
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

        public SugarConnector(DataSet ds)
        {
            m_dsSugar = ds;
            m_server = Cugar.Properties.Settings.Default.sugarhost;
            m_user = Cugar.Properties.Settings.Default.sugaruser;
            m_pw = Cugar.Properties.Settings.Default.sugarpw;
            m_dbname = Cugar.Properties.Settings.Default.sugardb;
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
            //m_daSugar = new MySqlDataAdapter(m_cmdSugarSelect);
            m_daSugar = new MySqlDataAdapter(m_cmdSugarSelect.ToString(), m_cnSugarConnection);            
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

        public DataView generate_dv_all(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            m_strCommand.Append("select * from contacts where last_name like ");
            m_strCommand.Append("'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append("%' and deleted = 0;");

            MySqlCommand m_cmdSearchCommand = new MySqlCommand(m_strCommand.ToString());
            m_daSearchSugar = new MySqlDataAdapter(m_cmdSearchCommand.CommandText, m_cnSugarConnection);
            m_daSearchSugar.FillSchema(m_dsSugar, SchemaType.Source, "tblSugarSuche");
            m_daSearchSugar.Fill(m_dsSugar, "tblSugarSuche");
            m_dvSearchSugar = m_dsSugar.Tables["tblSugarSuche"].DefaultView;
            return m_dvSearchSugar;
        }
        public DataView generate_dv_human(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            //SELECT `id`, `date_entered`, `date_modified`, `modified_user_id`, `created_by`, LEFT(`description`, 256), `deleted`, `assigned_user_id`, `salutation`, `first_name`, `last_name`, `title`, `department`, `do_not_call`, `phone_home`, `phone_mobile`, `phone_work`, `phone_other`, `phone_fax`, `primary_address_street`, `primary_address_city`, `primary_address_state`, `primary_address_postalcode`, `primary_address_country`, `alt_address_street`, `alt_address_city`, `alt_address_state`, `alt_address_postalcode`, `alt_address_country`, `assistant`, `assistant_phone`, `lead_source`, `reports_to_id`, `birthdate`, `campaign_id` FROM `sugarcrm`.`contacts` LIMIT 0, 1000;
            m_strCommand.Append("select salutation as Anrede, first_name as Vorname, last_name as Nachname, primary_address_street as Strasse, primary_address_postalcode as PLZ, primary_address_city as Ort, phone_home as Telefon, phone_mobile as Mobile from contacts where last_name like ");
            m_strCommand.Append("'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append("%' and deleted = 0;");

            MySqlCommand m_cmdSearchCommand = new MySqlCommand(m_strCommand.ToString());
            m_daSearchSugar = new MySqlDataAdapter(m_cmdSearchCommand.CommandText, m_cnSugarConnection);
            m_daSearchSugar.FillSchema(m_dsSugar, SchemaType.Source, "tblSugarSuche");
            m_daSearchSugar.Fill(m_dsSugar, "tblSugarSuche");
            m_dvSearchSugar = m_dsSugar.Tables["tblSugarSuche"].DefaultView;
            return m_dvSearchSugar;
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

        public int SugarSearchRestults
        {
            get
            {
                if (m_dsSugar.Tables["tblSugarSuche"].Rows.Count > 0)
                {
                    m_intSugarSearchResult = m_dsSugar.Tables["tblSugarSuche"].Rows.Count;
                    return m_intSugarSearchResult;
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
