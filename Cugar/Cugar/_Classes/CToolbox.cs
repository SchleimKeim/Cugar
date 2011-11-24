using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;


namespace Cugar
{
    /// <summary>
    ///  Verschiedene Tools und Funktionen
    /// </summary>
    public class cToolbox
    {
        #region private members
        private String m_server;
        private String m_user;
        private String m_pw;
        private String m_dbname;
        #endregion


        #region constructors
        public cToolbox()
        {
        }
        public cToolbox(string server, string user, string pw, string dbname)
        {
            m_server = server;
            m_user = user;
            m_pw = pw;
            m_dbname = dbname;
        }
        #endregion

        #region public methods
        public void RestartApplication()
        {
            // log exception somewhere, EventLog is one option
            // MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Process.Start(Application.ExecutablePath);
            Application.Exit();
        }

        public void FindDifference()
        {
        }

        /// <summary>
        /// Splits a given String and givs back the Result as String[]</summary>
        /// <param name="foo"> Parameter description for s goes here</param>
        public string[] SplitName(string foo)
        {
            string[] result;
            result = foo.Split();
            return result;
        }
        /// <summary>
        /// Combines two given strings.
        /// Used to Make a string with surname + lastname
        /// </summary>
        /// <param name="surname">the surname</param>
        /// <param name="lastname">the lastname</param>
        public string UniteName(string surname, string lastname)
        {
            string name = surname + " " + lastname;
            return name;
        }
        #endregion

    }
}
