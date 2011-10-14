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
    public class CToolbox
    {
        #region private members
        private String m_server;
        private String m_user;
        private String m_pw;
        private String m_dbname;
        #endregion


        #region constructors
        public CToolbox()
        {
        }
        public CToolbox(string server, string user, string pw, string dbname)
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
        public void Merge()
        {
        }
        public string[] VornameNachname(string name)
        {
            string[] w00p;
            w00p = name.Split();
            return w00p;
        }
        #endregion

    }
}
