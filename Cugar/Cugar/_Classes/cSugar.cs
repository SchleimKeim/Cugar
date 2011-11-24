using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.OleDb;

namespace Cugar
{
    /// <summary>
    /// SugarConnector Class. Connects to Sugar
    /// and works with a referenced DataSet and 
    /// a referenced BindingSource.
    /// </summary>
    public class cSugar
    {
        #region private members
        private const string m_const_strSugarTable = "tblSugarContacts";
        private const string m_const_strSugarTableSearchAllPrivate = "tblSugarSearchAllPrivate";
        private const string m_const_strSugarTableSearchAllCompanies = "tblSugarSearchAllCompanies";
        private const string m_const_strSugarTableSearchHuman = "tblSugarSearchHuman";

        private String m_server;
        private String m_user;
        private String m_pw;
        private String m_dbname;

        private DataSet m_dsSugar;
        private BindingSource m_BS;

        private MySqlConnection m_cnSugar;
        private MySqlDataAdapter m_daSugar;
        #endregion
        
        /// <summary>
        ///  Constructor expecting a DataSet.
        ///  Note: its recommencet to use the one who expects
        ///  a DataSet AND a Bindingsource!
        /// </summary>
        /// <param name="ds">Referenced DataSet</param>
        public cSugar(DataSet ds)
        {
            m_dsSugar = ds;
            m_server = Cugar.Properties.Settings.Default.sugarhost;
            m_user = Cugar.Properties.Settings.Default.sugaruser;
            m_pw = Cugar.Properties.Settings.Default.sugarpw;
            m_dbname = Cugar.Properties.Settings.Default.sugardb;

            try
            {
                SugarConnect();
            }
            catch (Exception asdf)
            {
                MessageBox.Show(asdf.ToString());
                throw;
            }
        }

        /// <summary>
        ///  Constructor expecting a DataSet and a Bindingsource.
        /// </summary>
        /// <param name="ds">DataSet to reference</param>
        /// <param name="bs">Referenced BindingSource</param>
        public cSugar(DataSet ds, BindingSource bs)
        {
            m_dsSugar = ds;
            m_server = Cugar.Properties.Settings.Default.sugarhost;
            m_user = Cugar.Properties.Settings.Default.sugaruser;
            m_pw = Cugar.Properties.Settings.Default.sugarpw;
            m_dbname = Cugar.Properties.Settings.Default.sugardb;
            

            m_BS = bs;
            try
            {
                SugarConnect();
            }
            catch (Exception asdf)
            {
                MessageBox.Show(asdf.ToString());
                throw;
            }
        }

        #region methods
        /// <summary>
        ///  Builds a Connection to the given Sugar Server
        ///  using the User Settings.
        /// </summary>
        private void SugarConnect()
        {
            StringBuilder m_sSugarConnect = new StringBuilder();

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

            m_cnSugar = new MySqlConnection(m_sSugarConnect.ToString());
        }

        /// <summary>
        ///  Loads all private Sugar Customers into the referenced DataSet.
        ///  Using a Tablename "tblSugarContacts"
        /// </summary>
        public void LoadPrivateCustomers()
        {
            MySqlCommand m_cmdSugarSelect = new MySqlCommand("select * from contacts where deleted=0", m_cnSugar);
            m_daSugar = new MySqlDataAdapter(m_cmdSugarSelect);
            m_daSugar.Fill(m_dsSugar, m_const_strSugarTable);
        }

        /// <summary>
        /// Searches for Contacts by Name.
        /// Table: tblSugarSearchAllCompanies</summary>
        /// <param name="searchstring">the search string</param>
        public void SearchContactsByName(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            m_strCommand.Append("select * from contacts where last_name like ");
            m_strCommand.Append("'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append("%' and deleted = 0;");

            MySqlCommand m_cmdSearchCommand = new MySqlCommand(m_strCommand.ToString());
            m_daSugar = new MySqlDataAdapter(m_cmdSearchCommand.CommandText, m_cnSugar);
            m_daSugar.FillSchema(m_dsSugar, SchemaType.Source, m_const_strSugarTableSearchAllPrivate);
            m_daSugar.Fill(m_dsSugar, m_const_strSugarTableSearchAllPrivate);            
        }

        /// <summary>
        /// Searches for Contacts by Street.
        /// Table: tblSugarSearchAllCompanies</summary>
        /// <param name="searchstring">the search string</param>
        public void SearchContactsByStreet(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            m_strCommand.Append("select * from contacts where primary_address_street like ");
            m_strCommand.Append("'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append("%' and deleted = 0;");

            MySqlCommand m_cmdSearchCommand = new MySqlCommand(m_strCommand.ToString());
            m_daSugar = new MySqlDataAdapter(m_cmdSearchCommand.CommandText, m_cnSugar);
            m_daSugar.FillSchema(m_dsSugar, SchemaType.Source, m_const_strSugarTableSearchAllPrivate);
            m_daSugar.Fill(m_dsSugar, m_const_strSugarTableSearchAllPrivate);            
        }

        /// <summary>
        /// Searches for Contacts by Mainphone.
        /// Table: tblSugarSearchAllCompanies</summary>
        /// <param name="searchstring">the search string</param>
        public void SearchContactsByPhone(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            m_strCommand.Append("select * from contacts where phone_home like ");
            m_strCommand.Append("'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append("%' and deleted = 0;");

            MySqlCommand m_cmdSearchCommand = new MySqlCommand(m_strCommand.ToString());
            m_daSugar = new MySqlDataAdapter(m_cmdSearchCommand.CommandText, m_cnSugar);
            m_daSugar.FillSchema(m_dsSugar, SchemaType.Source, m_const_strSugarTableSearchAllPrivate);
            m_daSugar.Fill(m_dsSugar, m_const_strSugarTableSearchAllPrivate);            
        }

        /// <summary>
        /// Searches for Companies by Name.
        /// Table: tblSugarSearchAllCompanies</summary>
        /// <param name="searchstring">the search string</param>
        public void SearchCompanyByName(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            m_strCommand.Append("select * from accounts where name like ");
            m_strCommand.Append("'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append("%' and deleted = 0;");

            MySqlCommand m_cmdSearchCommand = new MySqlCommand(m_strCommand.ToString());
            m_daSugar = new MySqlDataAdapter(m_cmdSearchCommand.CommandText, m_cnSugar);
            m_daSugar.FillSchema(m_dsSugar, SchemaType.Source, m_const_strSugarTableSearchAllCompanies);
            m_daSugar.Fill(m_dsSugar, m_const_strSugarTableSearchAllCompanies);            
        }

        /// <summary>
        /// Searches for Companies by Street.
        /// Table: tblSugarSearchAllCompanies</summary>
        /// <param name="searchstring">the search string</param>
        public void SearchCompanyByStreet(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            m_strCommand.Append("select * from accounts where billing_address_street like ");
            m_strCommand.Append("'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append("%' and deleted = 0;");

            MySqlCommand m_cmdSearchCommand = new MySqlCommand(m_strCommand.ToString());
            m_daSugar = new MySqlDataAdapter(m_cmdSearchCommand.CommandText, m_cnSugar);
            m_daSugar.FillSchema(m_dsSugar, SchemaType.Source, m_const_strSugarTableSearchAllCompanies);
            m_daSugar.Fill(m_dsSugar, m_const_strSugarTableSearchAllCompanies);            
        }

        /// <summary>
        /// Searches for Companies by Mainphone.
        /// Table: tblSugarSearchAllCompanies</summary>
        /// <param name="searchstring">the search string</param>
        public void SearchCompanyByPhone(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            m_strCommand.Append("select * from accounts where phone_office like ");
            m_strCommand.Append("'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append("%' and deleted = 0;");

            MySqlCommand m_cmdSearchCommand = new MySqlCommand(m_strCommand.ToString());
            m_daSugar = new MySqlDataAdapter(m_cmdSearchCommand.CommandText, m_cnSugar);
            m_daSugar.FillSchema(m_dsSugar, SchemaType.Source, m_const_strSugarTableSearchAllCompanies);
            m_daSugar.Fill(m_dsSugar, m_const_strSugarTableSearchAllCompanies);            
        }

        /// <summary>
        ///Searches the table adressen for a given Searchstring
        ///and inserts a "tblSugarSearchHuman" into the DataSet.</summary>
        /// <param name="searchstring">the search string</param>
        public void search_ds_human_persons(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            //SELECT `id`, `date_entered`, `date_modified`, `modified_user_id`, `created_by`, LEFT(`description`, 256), `deleted`, `assigned_user_id`, `salutation`, `first_name`, `last_name`, `title`, `department`, `do_not_call`, `phone_home`, `phone_mobile`, `phone_work`, `phone_other`, `phone_fax`, `primary_address_street`, `primary_address_city`, `primary_address_state`, `primary_address_postalcode`, `primary_address_country`, `alt_address_street`, `alt_address_city`, `alt_address_state`, `alt_address_postalcode`, `alt_address_country`, `assistant`, `assistant_phone`, `lead_source`, `reports_to_id`, `birthdate`, `campaign_id` FROM `sugarcrm`.`contacts` LIMIT 0, 1000;
            m_strCommand.Append("select salutation as Anrede, first_name as Vorname, last_name as Nachname, primary_address_street as Strasse, primary_address_postalcode as PLZ, primary_address_city as Ort, phone_home as Telefon, phone_mobile as Mobile from contacts where last_name like ");
            m_strCommand.Append("'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append("%' and deleted = 0;");

            MySqlCommand m_cmdSearchCommand = new MySqlCommand(m_strCommand.ToString());
            m_daSugar = new MySqlDataAdapter(m_cmdSearchCommand.CommandText, m_cnSugar);
            m_daSugar.FillSchema(m_dsSugar, SchemaType.Source, m_const_strSugarTableSearchHuman);
            m_daSugar.Fill(m_dsSugar, m_const_strSugarTableSearchHuman);
            
            //return m_dsSugar;
        }

        //experimental
        //public void Update()
        //{
        //    OleDbCommand myUpdateCommand = new OleDbCommand();

        //    myUpdateCommand.Parameters.Add("@REC_ID", OleDbType.Decimal, , "@REC_ID");
        //    OleDbParameter myPara = new OleDbParameter();
        //    myPara.ParameterName = "@REC_ID";
        //    myPara.OleDbType = OleDbType.Decimal;
        //    myPara.Direction = ParameterDirection.Input;
        //    myPara.SourceColumn = "@REC_ID";
            





        //    //myUpdateCommand.Parameters.Add("@REC_ID", MySqlDbType.Decimal, 
        //    //myUpdateCommand.Parameters.Add("@REC_ID", OdbcType.Int, 2, "@REC_ID");
        //}
        #region obsolete
        /// <summary>
        ///  Creates a New Contact
        /// </summary>
        /// <param name="command">a complete odbccommand with parameters</param>
        public void CreateNew(MySqlCommand command)
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
        #endregion
        #endregion

        #region propertys

        /// <summary>
        /// Returns the SugarConnection
        /// </summary>
        public MySqlConnection SugarConnection
        {
            get
            {
                return m_cnSugar;
            }
        }
        #endregion
    }
}