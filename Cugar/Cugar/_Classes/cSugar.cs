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

        public void SaveChanges()
        {
            m_daSugar = new MySqlDataAdapter();
            try
            {
                m_daSugar.SelectCommand = CreateSelectCommand();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            try
            {
                m_daSugar.DeleteCommand = CreateDeleteCommand();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());               
            }
            try
            {
                m_daSugar.UpdateCommand = CreateUpdateCommand();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());                              
            }

            try
            {
                m_daSugar.InsertCommand = CreateInsertCommand();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());                                             
            }

            
            try
            {
               // m_daSugar
                //m_dsSugar.Tables[m_const_strSugarTableSearchAllPrivate].AcceptChanges();
                m_dsSugar.AcceptChanges();
                m_daSugar.Update(m_dsSugar, m_const_strSugarTableSearchAllPrivate);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
        }


        /// <summary>
        /// Creates the InsertCommand
        /// </summary>
        /// <returns>MySqlCommand myInsertCommand</returns>
        public MySqlCommand CreateInsertCommand()
        {
            StringBuilder sb_SugarInsert = new StringBuilder();
            sb_SugarInsert.Append("INSERT INTO contacts(");

            #region rows for insert command text
            sb_SugarInsert.Append("id, ");
            sb_SugarInsert.Append("date_entered, ");
            sb_SugarInsert.Append("modified_user_id, ");
            sb_SugarInsert.Append("created_by, ");
            sb_SugarInsert.Append("description, ");
            sb_SugarInsert.Append("deleted, ");
            sb_SugarInsert.Append("assigned_user_id, ");
            sb_SugarInsert.Append("salutation, ");
            sb_SugarInsert.Append("first_name, ");
            sb_SugarInsert.Append("last_name, ");
            sb_SugarInsert.Append("title, ");
            sb_SugarInsert.Append("department, ");
            sb_SugarInsert.Append("phone_home, ");
            sb_SugarInsert.Append("phone_mobile, ");
            sb_SugarInsert.Append("phone_work, ");
            sb_SugarInsert.Append("phone_fax, ");
            sb_SugarInsert.Append("primary_address_street, ");
            sb_SugarInsert.Append("primary_address_city, ");
            sb_SugarInsert.Append("primary_address_postalcode, ");
            sb_SugarInsert.Append("primary_address_country, ");
            sb_SugarInsert.Append("lead_source, ");
            sb_SugarInsert.Append(@"birthdate)");

            #endregion
            sb_SugarInsert.Append(@" VALUES(@id, @date_entered, @modified_user_id, @created_by, @description, @deleted, @assigned_user_id, @salutation, @first_name, @last_name, @title, @department, @phone_home, @phone_mobile, @phone_work, @phone_fax, @primary_address_street, @primary_address_city, @primary_address_postalcode, @primary_address_country, @lead_source, @birthdate)");

            #region cmSugar + Parameters
            MySqlCommand myInsertCommand = new MySqlCommand(sb_SugarInsert.ToString(), m_cnSugar);
            myInsertCommand.Parameters.Add("@id", MySqlDbType.VarChar, 36, "@id");
            myInsertCommand.Parameters.Add("@date_entered", MySqlDbType.DateTime);
            myInsertCommand.Parameters.Add("@modified_user_id", MySqlDbType.VarChar, 36, "@modified_user_id");
            myInsertCommand.Parameters.Add("@created_by", MySqlDbType.VarChar, 36, "@created_by");
            myInsertCommand.Parameters.Add("@description", MySqlDbType.Text);
            myInsertCommand.Parameters.Add("@deleted", MySqlDbType.Int16, 1, "@deleted");
            myInsertCommand.Parameters.Add("@assigned_user_id", MySqlDbType.VarChar, 36, "@assigned_user_id");
            myInsertCommand.Parameters.Add("@salutation", MySqlDbType.VarChar, 255, "@salutation");
            myInsertCommand.Parameters.Add("@first_name", MySqlDbType.VarChar, 100, "@first_name");
            myInsertCommand.Parameters.Add("@last_name", MySqlDbType.VarChar, 100, "@last_name");
            myInsertCommand.Parameters.Add("@title", MySqlDbType.VarChar, 100, "@title");
            myInsertCommand.Parameters.Add("@department", MySqlDbType.VarChar, 255, "@department");
            myInsertCommand.Parameters.Add("@phone_home", MySqlDbType.VarChar, 100, "@phone_home");
            myInsertCommand.Parameters.Add("@phone_mobile", MySqlDbType.VarChar, 100, "@phone_mobile");
            myInsertCommand.Parameters.Add("@phone_work", MySqlDbType.VarChar, 100, "@phone_work");
            myInsertCommand.Parameters.Add("@phone_fax", MySqlDbType.VarChar, 100, "@phone_fax");
            myInsertCommand.Parameters.Add("@primary_address_street", MySqlDbType.VarChar, 150, "@primary_address_street");
            myInsertCommand.Parameters.Add("@primary_address_city", MySqlDbType.VarChar, 100, "@primary_address_city");
            myInsertCommand.Parameters.Add("@primary_address_postalcode", MySqlDbType.VarChar, 20, "@primary_address_postalcode");
            myInsertCommand.Parameters.Add("@primary_address_country", MySqlDbType.VarChar, 255, "@primary_address_country");
            myInsertCommand.Parameters.Add("@lead_source", MySqlDbType.VarChar, 255, "@lead_source");
            myInsertCommand.Parameters.Add("@birthdate", MySqlDbType.Date);
            #endregion
            return myInsertCommand;
        }

        /// <summary>
        /// Creates the Update Command
        /// </summary>
        /// <returns>MySqlCommand myUpdateCommand</returns>
        public MySqlCommand CreateUpdateCommand()
        {
            //#region old
            //#region parameters
            //StringBuilder sbUpdate = new StringBuilder();
            //sbUpdate.Append("UPDATE contacts SET id = ?, ");
            //sbUpdate.Append("first_name = ?, ");
            //sbUpdate.Append("salutation = ?, ");
            //sbUpdate.Append("primary_address_street = ?, ");
            //sbUpdate.Append("primary_address_postalcode = ?, ");
            //sbUpdate.Append("primary_address_city = ?, ");
            //sbUpdate.Append("phone_fax = ?, ");
            //sbUpdate.Append("phone_mobile = ?, ");
            //sbUpdate.Append("phone_work = ?, ");
            //sbUpdate.Append("phone_home = ?, ");
            //sbUpdate.Append("birthdate = ?, ");
            //sbUpdate.Append("description = ?, ");
            //sbUpdate.Append("primary_address_country = ?, ");
            //sbUpdate.Append("lead_source = ?, ");
            //sbUpdate.Append("department = ?, ");
            //sbUpdate.Append("last_name = ?, ");
            //sbUpdate.Append("title = ?");
            //sbUpdate.Append(" WHERE id = ?");

            //MySqlCommand myUpdateCommand = new MySqlCommand(sbUpdate.ToString(), m_cnSugar);
            //myUpdateCommand.Parameters.Add("@id", MySqlDbType.VarChar, 36, "@id");
            //myUpdateCommand.Parameters.Add("@first_name", MySqlDbType.VarChar, 100, "@first_name");
            //myUpdateCommand.Parameters.Add("@last_name", MySqlDbType.VarChar, 100, "@last_name");
            //myUpdateCommand.Parameters.Add("@salutation", MySqlDbType.VarChar, 255, "@salutation");
            //myUpdateCommand.Parameters.Add("@primary_address_street", MySqlDbType.VarChar, 150, "@primary_address_street");
            //myUpdateCommand.Parameters.Add("@primary_address_postalcode", MySqlDbType.VarChar, 20, "@primary_address_postalcode");
            //myUpdateCommand.Parameters.Add("@primary_address_city", MySqlDbType.VarChar, 100, "@primary_address_city");
            //myUpdateCommand.Parameters.Add("@phone_fax", MySqlDbType.VarChar, 100, "@phone_fax");
            //myUpdateCommand.Parameters.Add("@phone_mobile", MySqlDbType.VarChar, 100, "@phone_mobile");
            //myUpdateCommand.Parameters.Add("@phone_work", MySqlDbType.VarChar, 100, "@phone_work");
            //myUpdateCommand.Parameters.Add("@phone_home", MySqlDbType.VarChar, 100, "@phone_home");
            //myUpdateCommand.Parameters.Add("@birthdate", MySqlDbType.Date);
            //myUpdateCommand.Parameters.Add("@description", MySqlDbType.Text);
            //myUpdateCommand.Parameters.Add("@primary_address_country", MySqlDbType.VarChar, 255, "@primary_address_country");
            //myUpdateCommand.Parameters.Add("@lead_source", MySqlDbType.VarChar, 255, "@lead_source");
            //myUpdateCommand.Parameters.Add("@department", MySqlDbType.VarChar, 255, "@department");
            //myUpdateCommand.Parameters.Add("@title", MySqlDbType.VarChar, 100, "@title");
            //#endregion
            //#endregion
            StringBuilder sbUpdate = new StringBuilder();
            sbUpdate.Append("UPDATE contacts SET ");
            sbUpdate.Append("first_name = @first_name, ");
            sbUpdate.Append("salutation = @salutation, ");
            sbUpdate.Append("primary_address_street = @primary_address_street, ");
            sbUpdate.Append("primary_address_postalcode = @primary_address_postalcode, ");
            sbUpdate.Append("primary_address_city = @primary_address_city, ");
            sbUpdate.Append("phone_fax = @phone_fax, ");
            sbUpdate.Append("phone_mobile = @phone_mobile, ");
            sbUpdate.Append("phone_work = @phone_work, ");
            sbUpdate.Append("phone_home = @phone_home, ");
            sbUpdate.Append("birthdate = @birthdate, ");
            sbUpdate.Append("description = @description, ");
            sbUpdate.Append("primary_address_country = @primary_address_country, ");
            sbUpdate.Append("lead_source = @lead_source, ");
            sbUpdate.Append("department = @department, ");
            sbUpdate.Append("last_name = @last_name, ");
            sbUpdate.Append("title = @title");
            sbUpdate.Append(" WHERE id = @id");

            MySqlCommand myUpdateCommand = new MySqlCommand(sbUpdate.ToString(), m_cnSugar);
            myUpdateCommand.Parameters.Add("@id", MySqlDbType.VarChar, 36, "@id");
            myUpdateCommand.Parameters.Add("@first_name", MySqlDbType.VarChar, 100, "@first_name");
            myUpdateCommand.Parameters.Add("@last_name", MySqlDbType.VarChar, 100, "@last_name");
            myUpdateCommand.Parameters.Add("@salutation", MySqlDbType.VarChar, 255, "@salutation");
            myUpdateCommand.Parameters.Add("@primary_address_street", MySqlDbType.VarChar, 150, "@primary_address_street");
            myUpdateCommand.Parameters.Add("@primary_address_postalcode", MySqlDbType.VarChar, 20, "@primary_address_postalcode");
            myUpdateCommand.Parameters.Add("@primary_address_city", MySqlDbType.VarChar, 100, "@primary_address_city");
            myUpdateCommand.Parameters.Add("@phone_fax", MySqlDbType.VarChar, 100, "@phone_fax");
            myUpdateCommand.Parameters.Add("@phone_mobile", MySqlDbType.VarChar, 100, "@phone_mobile");
            myUpdateCommand.Parameters.Add("@phone_work", MySqlDbType.VarChar, 100, "@phone_work");
            myUpdateCommand.Parameters.Add("@phone_home", MySqlDbType.VarChar, 100, "@phone_home");
            myUpdateCommand.Parameters.Add("@birthdate", MySqlDbType.Date);
            myUpdateCommand.Parameters.Add("@description", MySqlDbType.Text);
            myUpdateCommand.Parameters.Add("@primary_address_country", MySqlDbType.VarChar, 255, "@primary_address_country");
            myUpdateCommand.Parameters.Add("@lead_source", MySqlDbType.VarChar, 255, "@lead_source");
            myUpdateCommand.Parameters.Add("@department", MySqlDbType.VarChar, 255, "@department");
            myUpdateCommand.Parameters.Add("@title", MySqlDbType.VarChar, 100, "@title");

            return myUpdateCommand;
        }

        /// <summary>
        /// Creates the Delete Command
        /// </summary>
        /// <returns>MySqlCommand myDeleteCommand</returns>
        public MySqlCommand CreateDeleteCommand()
        {
            #region parameters
            StringBuilder sbUpdate = new StringBuilder();
            sbUpdate.Append("DELETE from contacts WHERE id = ?");

            MySqlCommand myDeleteCommand = new MySqlCommand(sbUpdate.ToString(), m_cnSugar);
            myDeleteCommand.Parameters.Add("@id", MySqlDbType.VarChar, 36, "@id");
            #endregion
            return myDeleteCommand;
        }

        /// <summary>
        /// Creates the Select Command
        /// </summary>
        /// <returns>MySqlCommand myDeleteCommand</returns>
        private MySqlCommand CreateSelectCommand()
        {
            StringBuilder sb_SelectCommand = new StringBuilder();
            sb_SelectCommand.Append("SELECT id, date_entered, modified_user_id, created_by, description, deleted, assigned_user_id, salutation, first_name, last_name, title, department, phone_home, phone_mobile, phone_work, phone_fax, primary_address_street, primary_address_city, primary_address_postalcode, primary_address_country, lead_source, birthdate FROM contacts where deleted=0");
            MySqlCommand mySelectCommand = new MySqlCommand(sb_SelectCommand.ToString(), m_cnSugar);
            return mySelectCommand;
        }

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