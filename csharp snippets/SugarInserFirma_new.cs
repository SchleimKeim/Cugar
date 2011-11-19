 private void SugarInsertFirma()
        {
            if (m_bNew == true)
            {
                #region Insert Command Text
                if (m_objSugar.SugarConnection.State != ConnectionState.Open)
                {
                    m_objSugar.SugarConnection.Open();
                }
                StringBuilder sb_SugarInsert = new StringBuilder();
                sb_SugarInsert.Append("INSERT INTO accounts(");

                #region rows for insert command text
                sb_SugarInsert.Append("id, ");
                sb_SugarInsert.Append("name, ");
                sb_SugarInsert.Append("date_entered, ");
                //sb_SugarInsert.Append("date_modified, ");
                sb_SugarInsert.Append("modified_user_id, ");
                sb_SugarInsert.Append("created_by, ");
                sb_SugarInsert.Append("description, ");
                sb_SugarInsert.Append("deleted, ");
                sb_SugarInsert.Append("assigned_user_id, ");
                sb_SugarInsert.Append("account_type, ");
                //!
                sb_SugarInsert.Append("industry, ");
                //!
                sb_SugarInsert.Append("annual_revenue, ");
                //!
                sb_SugarInsert.Append("phone_fax, ");
                sb_SugarInsert.Append("billing_address_street, ");
                sb_SugarInsert.Append("billing_address_city, ");
                sb_SugarInsert.Append("billing_address_state, ");
                sb_SugarInsert.Append("billing_address_country, ");
                //! 
                //sb_SugarInsert.Append("rating, ");
                //!
                sb_SugarInsert.Append("phone_office, ");
                sb_SugarInsert.Append("phone_alternate, ");
                sb_SugarInsert.Append("website, ");
                //!
                //sb_SugarInsert.Append("ownership, ");
                sb_SugarInsert.Append("employees)");
                //sb_SugarInsert.Append("ticker_symbol, ");
                //!

                /* 
                 * sbSugarInsert.Append("shipping_address_street, ");
                 * sbSugarInsert.Append("shipping_address_city, ");
                 * sbSugarInsert.Append("shipping_address_state, ");
                 * sbSugarInsert.Append("shipping_address_postalcode, ");
                 * sbSugarInsert.Append("shipping_address_country, ");
                 */

                /*
                 * sbSugarInsert.Append("parent_id, ");
                 * sbSugarInsert.Append("sic_code, ");
                 * sbSugarInsert.Append("campaign_id", );
                 */

                #endregion
                sb_SugarInsert.Append(@" VALUES(@id, @name, @date_entered, @modified_user_id, @created_by, @description, @deleted, @assigned_user_id, @account_type, @industry, @annual_revenue, @phone_fax, @billing_address_street, @billing_address_city, @billing_address_state, @billing_address_country, @phone_office, @Phone_alternate, @website, @employees)");
                #region cmSugar + Parameters
                MySqlCommand cmSugarInsert = new MySqlCommand(sb_SugarInsert.ToString(), m_objSugar.SugarConnection);
                cmSugarInsert.Parameters.Add("@id", MySqlDbType.VarChar, 36, "@id");
                cmSugarInsert.Parameters["@id"].Value = System.Guid.NewGuid().ToString();
                cmSugarInsert.Parameters.Add("@name", MySqlDbType.VarChar, 150, "@name");
                cmSugarInsert.Parameters["@name"].Value = txtFName1.Text;
                cmSugarInsert.Parameters.Add("@date_entered", MySqlDbType.DateTime);
                cmSugarInsert.Parameters["@date_entered"].Value = DateTime.Today.ToShortDateString();
                //cmSugarInsert.Parameters.Add("@date_modified", MySqlDbType.DateTime);
                //cmSugarInsert.Parameters["@date_modified"].Value = DateTime.Today.ToString();
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
                cmSugarInsert.Parameters.Add("@account_type", MySqlDbType.VarChar, 50, "@account_type");
                cmSugarInsert.Parameters["@account_type"].Value = cboFSugarType.Text;
                cmSugarInsert.Parameters.Add("@industry", MySqlDbType.VarChar, 50, "@industry");
                cmSugarInsert.Parameters["@industry"].Value = txtFSugarBranche.Text;
                cmSugarInsert.Parameters.Add("@annual_revenue", MySqlDbType.VarChar, 100, "@annual_revenue");
                cmSugarInsert.Parameters["@annual_revenue"].Value = txtFSugarUmsatz.Text;
                cmSugarInsert.Parameters.Add("@phone_fax", MySqlDbType.VarChar, 100, "@phone_fax");
                cmSugarInsert.Parameters["@phone_fax"].Value = txtFFax.Text;
                cmSugarInsert.Parameters.Add("@primary_address_street", MySqlDbType.VarChar, 150, "@primary_address_street");
                cmSugarInsert.Parameters["@primary_address_street"].Value = txtFStrasse.Text;
                cmSugarInsert.Parameters.Add("@primary_address_city", MySqlDbType.VarChar, 100, "@primary_address_city");
                cmSugarInsert.Parameters["@primary_address_city"].Value = txtFOrt.Text;
                cmSugarInsert.Parameters.Add("@primary_address_postalcode", MySqlDbType.VarChar, 20, "@primary_address_postalcode");
                cmSugarInsert.Parameters["@primary_address_postalcode"].Value = txtFPLZ.Text;
                cmSugarInsert.Parameters.Add("@primary_address_country", MySqlDbType.VarChar, 255, "@primary_address_country");
                cmSugarInsert.Parameters["@primary_address_country"].Value = txtFSugarLand.Text;
                cmSugarInsert.Parameters.Add("@phone_office", MySqlDbType.VarChar, 100, "@phone_office");
                cmSugarInsert.Parameters["@phone_office"].Value = txtFPhone.Text;
                cmSugarInsert.Parameters.Add("@website", MySqlDbType.VarChar, 255, "@website");
                cmSugarInsert.Parameters["@website"].Value = txtFWeb.Text;
                cmSugarInsert.Parameters.Add("@employees", MySqlDbType.VarChar, 10, "@employees");
                cmSugarInsert.Parameters["@employees"].Value = txtFSugarMitarbeiter.Text;
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
            //...
        }

