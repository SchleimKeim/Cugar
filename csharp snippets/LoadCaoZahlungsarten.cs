        private void LoadCaoZahlungsarten()
        {
            
            StringBuilder m_sCaoConnect = new StringBuilder();            
            m_sCaoConnect.Append("Driver={MySQL ODBC 5.1 Driver};");
            m_sCaoConnect.Append("Server=" + Cugar.Properties.Settings.Default.caohost + ";");
            m_sCaoConnect.Append("Database=" + Cugar.Properties.Settings.Default.caodb + ";");
            m_sCaoConnect.Append("User=" + Cugar.Properties.Settings.Default.caouser + ";");
            m_sCaoConnect.Append("Password=" + Cugar.Properties.Settings.Default.caopw + ";");
            m_sCaoConnect.Append("Option=3");
            
            OdbcConnection m_cnFoo = new OdbcConnection(m_sCaoConnect.ToString());


            int spalten_nr = 0; //Nummer der Spalte, in der das gewnschte Element steht
            OdbcCommand cmd = new OdbcCommand(@"select NAME from ZAHLUNGSARTEN;", m_cnFoo);

            cmd.Connection = m_cnFoo;
            m_cnFoo.Open();
            
            cboCaoZahlart.Items.Clear();
            OdbcDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboCaoZahlart.Items.Add(dr.GetValue(spalten_nr).ToString());                
            }
            dr.Close();
            m_cnFoo.Close();
            #endregion
        }