using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//using MySql.Data.MySqlClient;


namespace Cugar
{
    class CDatabasecon
    {
        #region ein schwall kommentare die nicht gebraucht werden
        //private string m_CaoUser;
        //private string m_Caopw;
        //private string m_CaoHost;

        //private string m_SugarUser;
        //private string m_Sugarpw;
        //private string m_SugarHost;
        //private string m_constring_sugar;
        //private string m_constring_cao;

        //private const string csSugar = "Driver={MySQL ODBC 5.1 Driver};";
        //private const string csCao = "Driver={MySQL ODBC 5.1 Driver};";
        #endregion
        private const string csQuerySugar = "qrySugar";
        private const string csQueryCao = "qryCao";

        #region noch mehr comments die keiner braucht
        //private MySqlConnection m_conSugarConnection;
        //private MySqlConnection m_conCaoConnection;
        
        //Provider MySQLProv; Data Source =mydb; User Id =myUsername; Password =myPassword; 
        //Driver={MySQL ODBC 5.1 Driver}; Server =localhost; Database =myDataBase; User =myUsername; Password =myPassword; Option =3; 
        #endregion
        public CDatabasecon()
        {

        }

        public void ConnectSugar(string user, string pw, string server, string dbname)
        {
            StringBuilder m_sSugarConnect = new StringBuilder();
            /* Original
            m_sSugarConnect.Append("Provider=MySQL Provider; Data Source=localhost; User ID=root; Password=00mysql00; Initial Catalog=caofaktura; Activation=Q34J-8GXH-X3T9-DURZ;");
            */
            m_sSugarConnect.Append("Provider=MySQL Provider; ");
            m_sSugarConnect.Append("Data Source=" + server + "; ");
            m_sSugarConnect.Append("User ID=" + user + "; ");
            m_sSugarConnect.Append("Password=" + pw + "; ");
            m_sSugarConnect.Append("Initial Catalog=" + dbname + "; ");
            m_sSugarConnect.Append("Activation=Q34J-8GXH-X3T9-DURZ;");
            
            try
            {
                //MySqlConnection m_conSugarConnection = new MySqlConnection(m_sSugarConnect.ToString());
                OleDbConnection m_conSugarConnection = new OleDbConnection(m_sSugarConnect.ToString());
                m_conSugarConnection.Open();
                m_conSugarConnection.Close();
            }
            catch (Exception asdf)
            {
                MessageBox.Show(asdf.ToString());
                throw;
            }
        }
        public void ConnectCao(string user, string pw, string server, string dbname)
        {
            StringBuilder m_sCaoConnect = new StringBuilder();
            /* Original
            m_sCaoConnect.Append("Provider=MySQL Provider; Data Source=localhost; User ID=root; Password=00mysql00; Initial Catalog=caofaktura; Activation=Q34J-8GXH-X3T9-DURZ;");
            */
            m_sCaoConnect.Append("Provider=MySQL Provider; ");
            m_sCaoConnect.Append("Data Source=" + server + "; ");
            m_sCaoConnect.Append("User ID=" + user + "; ");
            m_sCaoConnect.Append("Password=" + pw + "; ");
            m_sCaoConnect.Append("Initial Catalog=" + dbname + "; ");
            m_sCaoConnect.Append("Activation=Q34J-8GXH-X3T9-DURZ;");

            #region debug zeug
            //MessageBox.Show(m_sCaoConnect.ToString());

            //StringBuilder m_sCaoTemp = new StringBuilder();
            //m_sCaoTemp.Append("Provider=MySQL Provider; Data Source=localhost; User ID=root; Password=00mysql00; Initial Catalog=caofaktura; Activation=Q34J-8GXH-X3T9-DURZ;");
            //MessageBox.Show(m_sCaoTemp.ToString());
            //Result:
            //string myConnectionString = "SERVER=localhost;" +
            //"DATABASE=mydatabase;" +
            //"UID=user;" +
            //"PASSWORD=mypassword;";
            #endregion

            try
            {                
                /* Alte Variante
                MySqlConnection m_conCaoConnection = new MySqlConnection(m_sCaoConnect.ToString());
                */

                OleDbConnection m_conCaoConnection = new OleDbConnection(m_sCaoConnect.ToString());
                m_conCaoConnection.Open();
                m_conCaoConnection.Close();

            }
            catch (Exception asdf2)
            {
                MessageBox.Show(asdf2.ToString());
                throw;
            }

        }

    }
}
