using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;


namespace Cugar
{
    class CToolbox
    {
        public CToolbox()
        {
        }


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
    }
}
