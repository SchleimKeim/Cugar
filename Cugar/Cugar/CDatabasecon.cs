using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Cugar
{
    class CDatabasecon
    {
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
        private const string csQuerySugar = "qrySugar";
        private const string csQueryCao = "qryCao";

        //private MySqlConnection m_conSugarConnection;
        //private MySqlConnection m_conCaoConnection;
        


        //Provider MySQLProv; Data Source =mydb; User Id =myUsername; Password =myPassword; 
        //Driver={MySQL ODBC 5.1 Driver}; Server =localhost; Database =myDataBase; User =myUsername; Password =myPassword; Option =3; 




        public CDatabasecon()
        {

        }

        public void ConnectSugar(string user, string pw, string server, string dbname)
        {
            StringBuilder m_sSugarConnect = new StringBuilder();
            m_sSugarConnect.Append("SERVER=" + server + ";");
            m_sSugarConnect.Append("DATABASE=" + dbname + ";");
            m_sSugarConnect.Append("UID=" + user + ";");
            m_sSugarConnect.Append("PASSWORD=" + pw + ";");

            //Result:
            //string myConnectionString = "SERVER=localhost;" +
            //"DATABASE=mydatabase;" +
            //"UID=user;" +
            //"PASSWORD=mypassword;";
            
            try
            {
                MySqlConnection m_conSugarConnection = new MySqlConnection(m_sSugarConnect.ToString());
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
            m_sCaoConnect.Append("SERVER=" + server + ";");
            m_sCaoConnect.Append("DATABASE=" + dbname + ";");
            m_sCaoConnect.Append("UID=" + user + ";");
            m_sCaoConnect.Append("PASSWORD=" + pw + ";");

            //Result:
            //string myConnectionString = "SERVER=localhost;" +
            //"DATABASE=mydatabase;" +
            //"UID=user;" +
            //"PASSWORD=mypassword;";


            try
            {
                MySqlConnection m_conCaoConnection = new MySqlConnection(m_sCaoConnect.ToString());
                
            }
            catch (Exception asdf2)
            {
                MessageBox.Show(asdf2.ToString());
                throw;
            }

        }

    }
}
