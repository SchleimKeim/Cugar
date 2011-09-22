using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cugar
{
    public partial class frmMain : Form
    {
        //Form mySettings = new frmSettings();
       
        

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            //MessageBox.Show(Cugar.Properties.Settings.Default.sugarhost);
            
            //string foo = "asdf2";
            
            //Cugar.Properties.Settings.Default.sugarhost = foo;

            
            //MessageBox.Show(Cugar.Properties.Settings.Default.sugarhost);
            //Cugar.Properties.Settings.Default.Save();
            
            //MessageBox.Show(Cugar.Properties.Settings.Default.sugarhost);

            //this.Close();
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form mySettings = new 
            
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
