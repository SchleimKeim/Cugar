            if (m_BS_CaoSearchContacts.Current != null)
            {
                //tabCompanies.
                //set searchtext to personen
                tstxtSuchePrivat.Text = "Personen...";

                #region Convert the name filed into two fields using CToolbox
                CToolbox m_objTool = new CToolbox();                
                string[] foo2;                
                foo2 = m_objTool.SplitName(((DataRowView)m_BS_CaoSearchContacts.Current)["NAME1"].ToString());
                txtVorname.Text = foo2[0];
                txtName.Text = foo2[1];
                #endregion

                #region fill cbos and set them to the right index
                // set cboCaoVersand to the right index
                int VerdsandId = 0;
                VerdsandId = Convert.ToInt32(((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_LIEFART"]);
                cboCaoVersand.SelectedIndex = VerdsandId - 1;

                //set cboCaoZahlart to the right index
                int ZahlartId = 0;
                ZahlartId = Convert.ToInt32(((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_ZAHLART"]);
                cboCaoZahlart.SelectedIndex = ZahlartId - 1;
                #endregion

                /* Fills in all the textfield using databinding object casted into a datarowview */

                cboAnrede.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["ANREDE"].ToString();         
                txtStrasse1.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["STRASSE"].ToString();
                txtPLZ.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["PLZ"].ToString();
                txtOrt.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["ORT"].ToString();                
                txtWebpage.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["INTERNET"].ToString();
                txtEmail.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["EMAIL"].ToString();
                txtFax.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["FAX"].ToString();
                txtMobile.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["FUNK"].ToString();
                txtPhon2.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["TELE2"].ToString();
                txtPhone1.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["TELE1"].ToString();
                cboCaoBriefanrede.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["BRIEFANREDE"].ToString();
                txtCaoZahlungsziel.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["BRT_TAGE"].ToString();
                txtCaoCustomerSince.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_SEIT"].ToString();
                txtCaoGeb.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_GEBDATUM"].ToString();
                txtBemerkung.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["INFO"].ToString();

                //((DataRowView)m_BS_CaoSearchContacts.Current)["INFO"] = txtBemerkung.Text;
                
                //txtSugarZugewiesenAn.Text = ((DataRowView)m_BS.Current)[].ToString();
                txtSugarLand.Text = ((DataRowView)m_BS_SugarSearchContacts.Current)["primary_address_country"].ToString();
                txtSugarLeadSource.Text = ((DataRowView)m_BS_SugarSearchContacts.Current)["lead_source"].ToString();
                txtSugarAbteilung.Text = ((DataRowView)m_BS_SugarSearchContacts.Current)["department"].ToString();
                txtSugarTitle.Text = ((DataRowView)m_BS_SugarSearchContacts.Current)["title"].ToString();
            }            

            //((DataRowView)m_BS.Current)["NAME1"] = txtName.Text;
            //((DataRowView)m_BS_Sugar.Current)["last_name"] = 
            //m_BS.Current

