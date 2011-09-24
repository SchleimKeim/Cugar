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
        private string m_caouser = Cugar.Properties.Settings.Default.caouser;
        private string m_caopw = Cugar.Properties.Settings.Default.caopw;
        private string m_caohost = Cugar.Properties.Settings.Default.caohost;

        private string m_sugaruser = Cugar.Properties.Settings.Default.sugaruser;
        private string m_sugarpw = Cugar.Properties.Settings.Default.sugarpw;
        private string m_sugarhost = Cugar.Properties.Settings.Default.sugarhost;
        

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Cugar.Properties.Settings.Default.first_start == true)
            {                
                frmSettings m_SubForm_Settings = new frmSettings();
                m_SubForm_Settings.ShowDialog();
                Cugar.Properties.Settings.Default.first_start = false;
                Cugar.Properties.Settings.Default.Save();
            }
           
            //MessageBox.Show(Cugar.Properties.Settings.Default.sugarhost);
            
            //string foo = "asdf2";
            
            //Cugar.Properties.Settings.Default.sugarhost = foo;

            
            //MessageBox.Show(Cugar.Properties.Settings.Default.sugarhost);
            //Cugar.Properties.Settings.Default.Save();
            
            //MessageBox.Show(Cugar.Properties.Settings.Default.sugarhost);

            //this.Close();
            
            CDatabasecon myConCao = new CDatabasecon();
            myConCao.ConnectCao(m_caouser, m_caopw, m_caohost);
            CDatabasecon myConSugar = new CDatabasecon();
            myConSugar.ConnectSugar(m_sugaruser, m_sugarpw, m_sugarhost);

        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings m_SubForm_Settings = new frmSettings();
            m_SubForm_Settings.ShowDialog();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
