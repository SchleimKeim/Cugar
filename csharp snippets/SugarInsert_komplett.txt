        private void SugarInsert()
        {
            if (m_bNew == true)
            {

                #region Insert Command Text
                if (m_objSugar.SugarConnection.State != ConnectionState.Open )
                {
                    m_objSugar.SugarConnection.Open();
                }
                StringBuilder sb_SugarInsert = new StringBuilder();
                sb_SugarInsert.Append("INSERT INTO contacts(");

                #region rows for insert command text
                sb_SugarInsert.Append("id, ");
                sb_SugarInsert.Append("date_entered, ");
                sb_SugarInsert.Append("date_modified, ");
                sb_SugarInsert.Append("modified_user_id, ");
                sb_SugarInsert.Append("created_by, ");
                sb_SugarInsert.Append("description, ");
                sb_SugarInsert.Append("deleted, ");
                sb_SugarInsert.Append("assigned_user_id, ");
                sb_SugarInsert.Append("salutation, ");
                sb_SugarInsert.Append("first_name, ");
                sb_SugarInsert.Append("last_name, ");
                sb_SugarInsert.Append("title, ");
                sb_SugarInsert.Append("department, ");
                sb_SugarInsert.Append("phone_home, ");
                sb_SugarInsert.Append("phone_mobile, ");
                sb_SugarInsert.Append("phone_work, ");
                sb_SugarInsert.Append("phone_fax, ");
                sb_SugarInsert.Append("primary_address_street, ");
                sb_SugarInsert.Append("primary_address_city, ");
                sb_SugarInsert.Append("primary_address_postalcode, ");
                sb_SugarInsert.Append("primary_address_country, ");
                sb_SugarInsert.Append("lead_source, ");
                sb_SugarInsert.Append(@"birthdate)");
                #endregion
                sb_SugarInsert.Append(@" VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");
                #region cmSugar + Parameters
                MySqlCommand cmSugarInsert = new MySqlCommand(sb_SugarInsert.ToString(), m_objSugar.SugarConnection);
                cmSugarInsert.Parameters.Add("@id", MySqlDbType.VarChar, 36, "@id");
                cmSugarInsert.Parameters["@id"].Value = System.Guid.NewGuid().ToString();
                cmSugarInsert.Parameters.Add("@date_entered", MySqlDbType.DateTime);
                cmSugarInsert.Parameters["@date_entered"].Value = DateTime.Today.ToString();
                cmSugarInsert.Parameters.Add("@date_modified", MySqlDbType.DateTime);
                cmSugarInsert.Parameters["@date_modified"].Value = DateTime.Today.ToString();
                cmSugarInsert.Parameters.Add("@modified_user_id", MySqlDbType.VarChar, 36, "@modified_user_id");
                cmSugarInsert.Parameters["@modified_user_id"].Value = "ed2d04a5-8264-45e7-fbdb-4ebebdf8375a";
                cmSugarInsert.Parameters.Add("@created_by", MySqlDbType.VarChar, 36, "@created_by");
                cmSugarInsert.Parameters["@created_by"].Value = "ed2d04a5-8264-45e7-fbdb-4ebebdf8375a";
                cmSugarInsert.Parameters.Add("@description", MySqlDbType.Text);
                cmSugarInsert.Parameters["@description"].Value = txtBemerkung.Text;
                cmSugarInsert.Parameters.Add("@deleted", MySqlDbType.Int16, 1, "@deleted");
                cmSugarInsert.Parameters["@deleted"].Value = 0;
                cmSugarInsert.Parameters.Add("@assigned_user_id", MySqlDbType.VarChar, 36, "@assigned_user_id");
                cmSugarInsert.Parameters["@assigned_user_id"].Value = "ed2d04a5-8264-45e7-fbdb-4ebebdf8375a";
                cmSugarInsert.Parameters.Add("@salutation", MySqlDbType.VarChar, 255, "@salutation");
                cmSugarInsert.Parameters["@salutation"].Value = txtAnrede.Text;
                cmSugarInsert.Parameters.Add("@first_name", MySqlDbType.VarChar, 100, "@first_name");
                cmSugarInsert.Parameters["@first_name"].Value = txtVorname.Text;
                cmSugarInsert.Parameters.Add("@last_name", MySqlDbType.VarChar, 100, "@last_name");
                cmSugarInsert.Parameters["@last_name"].Value = txtName.Text;
                cmSugarInsert.Parameters.Add("@title", MySqlDbType.VarChar, 100, "@title");
                cmSugarInsert.Parameters["@title"].Value = txtSugarTitle.Text;
                cmSugarInsert.Parameters.Add("@department", MySqlDbType.VarChar, 255, "@department");
                cmSugarInsert.Parameters["@department"].Value = txtSugarAbteilung.Text;
                cmSugarInsert.Parameters.Add("@phone_home", MySqlDbType.VarChar, 100, "@phone_home");
                cmSugarInsert.Parameters["@phone_home"].Value = txtPhone1.Text;
                cmSugarInsert.Parameters.Add("@phone_mobile", MySqlDbType.VarChar, 100, "@phone_mobile");
                cmSugarInsert.Parameters["@phone_mobile"].Value = txtMobile.Text;
                cmSugarInsert.Parameters.Add("@phone_work", MySqlDbType.VarChar, 100, "@phone_work");
                cmSugarInsert.Parameters["@phone_work"].Value = txtPhon2.Text;
                cmSugarInsert.Parameters.Add("@phone_fax", MySqlDbType.VarChar, 100, "@phone_fax");
                cmSugarInsert.Parameters["@phone_fax"].Value = txtFax.Text;
                cmSugarInsert.Parameters.Add("@primary_address_street", MySqlDbType.VarChar, 150, "@primary_address_street");
                cmSugarInsert.Parameters["@primary_address_street"].Value = txtStrasse1.Text;
                cmSugarInsert.Parameters.Add("@primary_address_city", MySqlDbType.VarChar, 100, "@primary_address_city");
                cmSugarInsert.Parameters["@primary_address_city"].Value = txtOrt.Text;
                cmSugarInsert.Parameters.Add("@primary_address_postalcode", MySqlDbType.VarChar, 20, "@primary_address_postalcode");
                cmSugarInsert.Parameters["@primary_address_postalcode"].Value = txtPLZ.Text;
                cmSugarInsert.Parameters.Add("@primary_address_country", MySqlDbType.VarChar, 255, "@primary_address_country");
                cmSugarInsert.Parameters["@primary_address_country"].Value = txtSugarLand.Text;
                cmSugarInsert.Parameters.Add("@lead_source", MySqlDbType.VarChar, 255, "@lead_source");
                cmSugarInsert.Parameters["@lead_source"].Value = txtSugarLeadSource.Text;
                cmSugarInsert.Parameters.Add("@birthdate", MySqlDbType.Date);
                cmSugarInsert.Parameters["@birthdate"].Value = txtCaoGeb.Text;
                #endregion
                #endregion

                try
                {
                    cmSugarInsert.ExecuteNonQuery();
                    m_objSugar.SugarConnection.Close();
                }
                catch (Exception asdf)
                {
                    MessageBox.Show(asdf.ToString());
                    throw;
                }
            }
        }
		