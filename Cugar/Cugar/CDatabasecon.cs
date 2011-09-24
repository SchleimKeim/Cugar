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
        private string m_user;
        private string m_password;
        private string m_server;
        private string m_constring_sugar;
        private string m_constring_cao;

        private const string csSugar = "Provider=MySQLProv;Data Source=sugarcrm";
        private const string csCao = "Provider=MySQLProv;Data Source=caofaktura";
        private const string csQuerySugar = "qrySugar";
        private const string csQueryCao = "qryCao";

        private OleDbConnection m_SugarConnection;
        private OleDbConnection m_CaoConnection;
        

        //Provider =MySQLProv; Data Source =mydb; User Id =myUsername; Password =myPassword; 

        public CDatabasecon()
        {

        }

        public void ConnectSugar(string user, string pw, string server)
        {

        }
        public void ConnectCao(string user, string pw, string server)
        {

        }

    }
}
