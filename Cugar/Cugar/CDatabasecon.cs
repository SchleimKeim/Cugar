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
            
//MyConnection = New OleDbConnection("Provider=MySQLProv;server=xxx.xxx.xxx.xxx;uid=xxx; pwdxxx=;database=xxx")
            //m_sSugarConnect.Append();
            //m_sSugarConnect.Append("DRIVER={MySQL ODBC 5.1 Driver};");
            //m_sSugarConnect.Append("SERVER=" + server + ";");
            //m_sSugarConnect.Append("DATABASE=" + dbname + ";");
            //m_sSugarConnect.Append("UID=" + user + ";");
            //m_sSugarConnect.Append("PASSWORD=" + pw + ";");

            //Result:
            //string myConnectionString = "SERVER=localhost;" +
            //"DATABASE=mydatabase;" +
            //"UID=user;" +
            //"PASSWORD=mypassword;";
            
            try
            {
                //MySqlConnection m_conSugarConnection = new MySqlConnection(m_sSugarConnect.ToString());
                OleDbConnection m_conSugarConnection = new OleDbConnection(m_sSugarConnect.ToString());
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
            m_sCaoConnect.Append("Provider=MySQL Provider; Data Source=localhost; User ID=root; Password=00mysql00; Initial Catalog=caofaktura; Activation=Q34J-8GXH-X3T9-DURZ;");
            //m_sCaoConnect.Append("Driver={MySQL ODBC 5.1 Driver}; Server =localhost; Database =caofaktura; User =root; Password =00mysql00; Option =3;");
            //m_sCaoConnect.Append("DRIVER={MySQL ODBC 5.1 Driver};");
            //m_sCaoConnect.Append("SERVER=" + server + ";");
            //m_sCaoConnect.Append("DATABASE=" + dbname + ";");
            //m_sCaoConnect.Append("UID=" + user + ";");
            //m_sCaoConnect.Append("PASSWORD=" + pw + ";");
            


            //Result:
            //string myConnectionString = "SERVER=localhost;" +
            //"DATABASE=mydatabase;" +
            //"UID=user;" +
            //"PASSWORD=mypassword;";


            try
            {
                //MySqlConnection m_conCaoConnection = new MySqlConnection(m_sCaoConnect.ToString());
                
                OleDbConnection m_conCaoConnection = new OleDbConnection(m_sCaoConnect.ToString());
                m_conCaoConnection.Open();
            }
            catch (Exception asdf2)
            {
                MessageBox.Show(asdf2.ToString());
                throw;
            }

        }

    }
}
