using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

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

        private const string csSugar = "Driver={MySQL ODBC 5.1 Driver};";
        private const string csCao = "Driver={MySQL ODBC 5.1 Driver};";
        private const string csQuerySugar = "qrySugar";
        private const string csQueryCao = "qryCao";

        private OleDbConnection m_SugarConnection;
        private OleDbConnection m_CaoConnection;
        

        //Provider MySQLProv; Data Source =mydb; User Id =myUsername; Password =myPassword; 
        //Driver={MySQL ODBC 5.1 Driver}; Server =localhost; Database =myDataBase; User =myUsername; Password =myPassword; Option =3; 

        public CDatabasecon()
        {

        }

        public void ConnectSugar(string user, string pw, string server)
        {
            StringBuilder m_SugarConnect_string = new StringBuilder();
            m_SugarConnect_string.Append(csSugar);
            m_SugarConnect_string.Append("Server=");
            m_SugarConnect_string.Append(server);
            m_SugarConnect_string.Append(";");
            m_SugarConnect_string.Append("Databbase=sugarcrm;");
            m_SugarConnect_string.Append("User=");
            m_SugarConnect_string.Append(user);            
            m_SugarConnect_string.Append(";");
            m_SugarConnect_string.Append("Password=");
            m_SugarConnect_string.Append(pw);
            //result: Driver={MySQL ODBC 5.1 Driver};Server=sugarcrm.lan.darktemple.ch;Databbase=sugarcrm;User=sugarcrm;Password=00sugar00
        }
        public void ConnectCao(string user, string pw, string server)
        {
            StringBuilder m_CaoConnect = new StringBuilder();
            m_CaoConnect.Append(csCao);
            m_CaoConnect.Append("Server=");
            m_CaoConnect.Append(server);
            m_CaoConnect.Append(";");
            m_CaoConnect.Append("Databbase=caofaktura;");
            m_CaoConnect.Append("User=");
            m_CaoConnect.Append(user);            
            m_CaoConnect.Append(";");
            m_CaoConnect.Append("Password=");
            m_CaoConnect.Append(pw);
            //result:{Driver={MySQL ODBC 5.1 Driver};Server=localhost;Databbase=caofaktura;User=root;Password=00mysql00

        }

    }
}
