using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Cugar
{
    class CaoConnector
    {
        //Constructor

        String m_server;
        String m_user;
        String m_pw;
        String m_dbname;
        


        
        public CaoConnector(string server, string user, string pw, string dbname)
        {
            m_server = server;
            m_user = user;
            m_pw = pw;
            m_dbname = dbname;

            try
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


                OleDbConnection m_conCaoConnection = new OleDbConnection(m_sCaoConnect.ToString());
                m_conCaoConnection.Open();
                m_conCaoConnection.Close(); ;
            }
            catch (Exception )
            {
                MessageBox.Show("Beim Verbinden mit CAO-Faktura ist ein Fehler aufgetreten. \nBitte überprüfen Sie Ihre Einstellungen.");
                
                throw;
            }
            

        }
        /* Public Functons
         * - CaoConnect: connects to cao
         * - GetRecord(): shows a record
         * - SaveRecord(): Saves it
         * - UpdateRecord(): Updates a Record
         * - DeleteRecord(): Deletes a Record
         * */
         
        //public void CaoConnect()
        //{
        //    StringBuilder m_sCaoConnect = new StringBuilder();
        //    /* Original
        //    m_sSugarConnect.Append("Provider=MySQL Provider; Data Source=localhost; User ID=root; Password=00mysql00; Initial Catalog=caofaktura; Activation=Q34J-8GXH-X3T9-DURZ;");
        //    */
        //    m_sCaoConnect.Append("Provider=MySQL Provider; ");
        //    m_sCaoConnect.Append("Data Source=" + m_server + "; ");
        //    m_sCaoConnect.Append("User ID=" + m_user + "; ");
        //    m_sCaoConnect.Append("Password=" + m_pw + "; ");
        //    m_sCaoConnect.Append("Initial Catalog=" + m_dbname + "; ");
        //    m_sCaoConnect.Append("Activation=Q34J-8GXH-X3T9-DURZ;");

            
        //    OleDbConnection m_conCaoConnection = new OleDbConnection(m_sCaoConnect.ToString());
        //    m_conCaoConnection.Open();
        //    m_conCaoConnection.Close();
        //}

        public void GetFirstRecord()
        {
            
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

    }
}
