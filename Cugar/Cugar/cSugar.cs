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
    ///  SugarConnector Class
    /// </summary>
    public class cSugar
    {
        #region private members
        private const string m_const_strSugarTable = "tblSugar";
        private const string m_const_strSugarTableSearchAll = "tblSugarSearchAll";
        private const string m_const_strSugarTableSearchHuman = "tblSugarSearchHuman";
        private String m_server;
        private String m_user;
        private String m_pw;
        private String m_dbname;

        private DataSet m_dsSugar;
        private MySqlConnection m_cnSugar;
        private MySqlDataAdapter m_daSugar;
        #endregion
        
        /// <summary>
        ///  Constructor expecting a DataSet
        /// </summary>
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

        #region methods
        /// <summary>
        ///  Builds a Connection to the given SugarHost
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
        ///  Loads the whole Database into the referenced DataSet.
        ///  Using a Tablename "tblSugar"
        /// </summary>
        public void LoadDataSet()
        {
            MySqlCommand m_cmdCaoSelect = new MySqlCommand("select * from contacts where deleted=0", m_cnSugar);
            m_daSugar = new MySqlDataAdapter(m_cmdCaoSelect);
            m_daSugar.Fill(m_dsSugar, m_const_strSugarTable);
            //return m_dsSugar;
        }

        /// <summary>
        ///Searches the table adressen for a given Searchstring
        ///and inserts a "tblSugarSearchAll" into the DataSet.</summary>
        /// <param name="searchstring">the search string</param>
        public void search_ds_all(string searchstring)
        {
            StringBuilder m_strCommand = new StringBuilder();
            m_strCommand.Append("select * from contacts where last_name like ");
            m_strCommand.Append("'%");
            m_strCommand.Append(searchstring);
            m_strCommand.Append("%' and deleted = 0;");

            MySqlCommand m_cmdSearchCommand = new MySqlCommand(m_strCommand.ToString());
            m_daSugar = new MySqlDataAdapter(m_cmdSearchCommand.CommandText, m_cnSugar);
            m_daSugar.FillSchema(m_dsSugar, SchemaType.Source, m_const_strSugarTableSearchAll);
            m_daSugar.Fill(m_dsSugar, "tblSugarSearchAll");            
        }
        /// <summary>
        ///Searches the table adressen for a given Searchstring
        ///and inserts a "tblSugarSearchHuman" into the DataSet.</summary>
        /// <param name="searchstring">the search string</param>
        public void search_ds_human(string searchstring)
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
        //        return LoadDataSet();
        //    }
        //}
        #endregion
    }
}