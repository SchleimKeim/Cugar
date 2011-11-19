        /// <summary>
        /// Fills all the textfields with values from the current
        /// selected DataRow out of the BindingSource. (tblSearch*Companies)
        /// </summary>
        public void DatensatzLadenCompany()
        {
            if (m_BS_CaoSearchContacts.Current != null)
            {
                //m_BS_CaoSearchFirma
                //reset ts textfields
                tstxtSuchePrivat.Text = "Personen...";
                tstxtSucheFirma.Text = "Firmen...";

                txtFName1.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["NAME1"].ToString();

                #region fill cbos and set them to the right index
                // set cboCaoVersand to the right index
                int VerdsandId = 0;
                VerdsandId = Convert.ToInt32(((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_LIEFART"]);
                cboFVersand.SelectedIndex = VerdsandId - 1;

                //set cboCaoZahlart to the right index
                int ZahlartId = 0;
                ZahlartId = Convert.ToInt32(((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_ZAHLART"]);
                cboFZahlart.SelectedIndex = ZahlartId - 1;
                #endregion

                /* Fills in all the textfield using databinding object casted into a datarowview */

                cboFAnrede.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["ANREDE"].ToString();
                txtFStrasse.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["STRASSE"].ToString();
                txtFPLZ.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["PLZ"].ToString();
                txtFOrt.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["ORT"].ToString();
                txtFWeb.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["INTERNET"].ToString();
                txtFMail.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["EMAIL"].ToString();
                txtFFax.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["FAX"].ToString();
                //txtMobile.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["FUNK"].ToString();
                //txtPhon2.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["TELE2"].ToString();
                txtFPhone.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["TELE1"].ToString();
                cboFAnrede.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["BRIEFANREDE"].ToString();
                txtFZahlungsziel.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["BRT_TAGE"].ToString();
                txtFKunSeit.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["KUN_SEIT"].ToString();
                txtFBemerkung.Text = ((DataRowView)m_BS_CaoSearchContacts.Current)["INFO"].ToString();

                //((DataRowView)m_BS_CaoSearchContacts.Current)["INFO"] = txtBemerkung.Text;

                //txtSugarZugewiesenAn.Text = ((DataRowView)m_BS.Current)[].ToString();
                //txtSugarLeadSource.Text = ((DataRowView)m_BS.Current)[].ToString();

                //txtSugarReportsTo.Text = ((DataRowView)m_BS.Current)[].ToString();
                //txtSugarTitle.Text = ((DataRowView)m_BS.Current)[].ToString();
            }

            //((DataRowView)m_BS.Current)["NAME1"] = txtName.Text;
            //((DataRowView)m_BS_Sugar.Current)["last_name"] = 
            //m_BS.Current

        }

