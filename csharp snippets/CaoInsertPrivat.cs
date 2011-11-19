        private void CaoInsertPrivat()
        {
            if (m_bNew == true)
            {
                /* - create insert command text
                 * - create command itself
                 * - set all parameters for the values */

                #region Insert Command Text
                StringBuilder sb_CaoInsert = new StringBuilder();
                sb_CaoInsert.Append("INSERT INTO adressen(");
                sb_CaoInsert.Append("REC_ID, ");
                sb_CaoInsert.Append("KUNDENGRUPPE, ");
                sb_CaoInsert.Append("NAME1, ");
                sb_CaoInsert.Append("PLZ, ");
                sb_CaoInsert.Append("ORT, ");
                sb_CaoInsert.Append("ANREDE, ");
                sb_CaoInsert.Append("STRASSE, ");
                sb_CaoInsert.Append("TELE1, ");
                sb_CaoInsert.Append("TELE2, ");
                sb_CaoInsert.Append("FAX, ");
                sb_CaoInsert.Append("FUNK, ");
                sb_CaoInsert.Append("EMAIL, ");
                sb_CaoInsert.Append("INTERNET, ");
                sb_CaoInsert.Append("BRIEFANREDE, ");
                sb_CaoInsert.Append("BRT_TAGE, ");
                sb_CaoInsert.Append("INFO, ");
                sb_CaoInsert.Append("KUN_LIEFART, ");
                sb_CaoInsert.Append("KUN_SEIT, ");
                sb_CaoInsert.Append("GEAEND_NAME, ");
                sb_CaoInsert.Append("KUN_ZAHLART, ");
                sb_CaoInsert.Append(@"BRUTTO_FLAG)");
                sb_CaoInsert.Append(@" VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");
                #endregion

                OdbcCommand caoInsert = new OdbcCommand(sb_CaoInsert.ToString(), m_objCao.CaoConnection);

                #region parameters
                caoInsert.Parameters.Add("@REC_ID", OdbcType.Int, 11, "@REC_ID");
                caoInsert.Parameters["@REC_ID"].Value = m_objCao.LatestRecId;
                caoInsert.Parameters.Add("@KUNDENGRUPPE", OdbcType.Int, 11, "@KUNDENGRUPPE");
                caoInsert.Parameters["@KUNDENGRUPPE"].Value = 1;

                caoInsert.Parameters.Add("@NAME1", OdbcType.VarChar, 40, "@NAME1");
                CToolbox tool = new CToolbox();
                caoInsert.Parameters["@NAME1"].Value = tool.UniteName(txtVorname.Text, txtName.Text);

                caoInsert.Parameters.Add("@PLZ", OdbcType.VarChar, 10, "@PLZ");
                caoInsert.Parameters["@PLZ"].Value = txtPLZ.Text;
                caoInsert.Parameters.Add("@ORT", OdbcType.VarChar, 40, "@ORT");
                caoInsert.Parameters["@ORT"].Value = txtOrt.Text;
                caoInsert.Parameters.Add("@ANREDE", OdbcType.VarChar, 40, "@ANREDE");
                caoInsert.Parameters["@ANREDE"].Value = cboAnrede.Text;
                caoInsert.Parameters.Add("@STRASSE", OdbcType.VarChar, 40, "@STRASSE");
                caoInsert.Parameters["@STRASSE"].Value = txtStrasse1.Text;
                caoInsert.Parameters.Add("@TELE1", OdbcType.VarChar, 100, "@TELE1");
                caoInsert.Parameters["@TELE1"].Value = txtPhone1.Text;
                caoInsert.Parameters.Add("@TELE2", OdbcType.VarChar, 100, "@TELE2");
                caoInsert.Parameters["@TELE2"].Value = txtPhon2.Text;
                caoInsert.Parameters.Add("@FAX", OdbcType.VarChar, 100, "@FAX");
                caoInsert.Parameters["@FAX"].Value = txtFax.Text;
                caoInsert.Parameters.Add("@FUNK", OdbcType.VarChar, 100, "@FUNK");
                caoInsert.Parameters["@FUNK"].Value = txtMobile.Text;
                caoInsert.Parameters.Add("@EMAIL", OdbcType.VarChar, 100, "@EMAIL");
                caoInsert.Parameters["@EMAIL"].Value = txtEmail.Text;
                caoInsert.Parameters.Add("@INTERNET", OdbcType.VarChar, 100, "@INTERNET");
                caoInsert.Parameters["@INTERNET"].Value = txtWebpage.Text;
                caoInsert.Parameters.Add("@BRIEFANREDE", OdbcType.VarChar, 100, "@BRIEFANREDE");
                caoInsert.Parameters["@BRIEFANREDE"].Value = cboCaoBriefanrede.Text;

                

                caoInsert.Parameters.Add("@BRT_TAGE", OdbcType.TinyInt, 4, "@BRT_TAGE");
                if (txtCaoZahlungsziel.Text == "")
                {
                    caoInsert.Parameters["@BRT_TAGE"].Value = 30;
                }
                else
                {
                    caoInsert.Parameters["@BRT_TAGE"].Value = Convert.ToInt16(txtCaoZahlungsziel.Text);
                }

                caoInsert.Parameters.Add("@INFO", OdbcType.Text, 65537, "@INFO");
                caoInsert.Parameters["@INFO"].Value = txtBemerkung.Text;
                caoInsert.Parameters.Add("@KUN_LIEFART", OdbcType.Int, 11, "@KUN_LIEFART");
                caoInsert.Parameters["@KUN_LIEFART"].Value = cboCaoVersand.SelectedIndex + 1;
                caoInsert.Parameters.Add("@KUN_SEIT", OdbcType.Date);
                caoInsert.Parameters["@KUN_SEIT"].Value = DateTime.Today.ToShortDateString();
                caoInsert.Parameters.Add("@GEAND_NAME", OdbcType.VarChar, 20, "@GEAND_NAME");
                caoInsert.Parameters["@GEAND_NAME"].Value = "Cugar";

                caoInsert.Parameters.Add("@KUN_ZAHLART", OdbcType.Int, 11, "@KUN_ZAHLART");
                caoInsert.Parameters["@KUN_ZAHLART"].Value = cboCaoZahlart.SelectedIndex + 1;
                caoInsert.Parameters.Add("@BRUTTO_FLAG", OdbcType.Char, 2, "@BRUTTO_FLAG");
                caoInsert.Parameters["@BRUTTO_FLAG"].Value = 'Y';
                #endregion
                try
                {
                    caoInsert.ExecuteNonQuery();
                }
                catch (Exception asdf)
                {
                    MessageBox.Show(asdf.ToString());
                    throw;
                }

            }
        }

        /// <summary>
        /// Creates a new Sugar record.
        /// </summary>
        private void SugarInsertPrivat()
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
                /* original insert into text:
                 * INSERT INTO sugarcrm.contacts(
                 * id,
                 * date_entered,  
                 * modified_user_id, 
                 * created_by, 
                 * description, 
                 * deleted, 
                 * assigned_user_id, 
                 * salutation, 
                 * first_name, 
                 * last_name, 
                 * title, 
                 * department, 
                 * phone_home, 
                 * phone_mobile, 
                 * phone_work, 
                 * phone_fax, 
                 * primary_address_street, 
                 * primary_address_city, 
                 * primary_address_postalcode, 
                 * primary_address_country
                 * )
                 * VALUES (
                 * '82da7b1d-46de-403b-ac5b-f77edc2803ba', 
                 * '2011.11.14',
                 * 'ed2d04a5-8264-45e7-fbdb-4ebebdf8375a', 
                 * 'ed2d04a5-8264-45e7-fbdb-4ebebdf8375a', 
                 * 'asdf', 
                 * 0, 
                 * 'ed2d04a5-8264-45e7-fbdb-4ebebdf8375a', 
                 * 'Sehr geehrter Herr', 
                 * 'Anton', 
                 * 'Good', 
                 * 'CIO', 
                 * 'Informatikbro', 
                 * '0817236908', 
                 * '0817236908', 
                 * '0817236908', 
                 * '0817236908', 
                 * 'Staatsstrasse 11', 
                 * 'Plons', 
                 * '8889', 
                 * 'Schweiz'); */

                sb_SugarInsert.Append("id, ");
                sb_SugarInsert.Append("date_entered, ");
                //sb_SugarInsert.Append("date_modified, ");
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
                sb_SugarInsert.Append("primary_address_country)");
                //sb_SugarInsert.Append("lead_source, ");
                //sb_SugarInsert.Append("lead_source)");
                //sb_SugarInsert.Append(@"birthdate)");

                #endregion
                sb_SugarInsert.Append(@" VALUES(@id, @date_entered, @modified_user_id, @created_by, @description, @deleted, @assigned_user_id, @salutation, @first_name, @last_name, @title, @department, @phone_home, @phone_mobile, @phone_work, @phone_fax, @primary_address_street, @primary_address_city, @primary_address_postalcode, @primary_address_country)");
                //@sb_SugarInsert.Append(@" VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"); 
                #region cmSugar + Parameters
                MySqlCommand cmSugarInsert = new MySqlCommand(sb_SugarInsert.ToString(), m_objSugar.SugarConnection);
                cmSugarInsert.Parameters.Add("@id", MySqlDbType.VarChar, 36, "@id");
                cmSugarInsert.Parameters["@id"].Value = System.Guid.NewGuid().ToString();

 
                //MySqlParameter myparam = new MySqlParameter();
                //myparam.ParameterName = "@date_entered";
                //myparam.SourceColumn = "@date_entered";
                //myparam.DbType = (DbType)MySqlDbType.DateTime;
                //myparam.Value = DateTime.Today.ToShortDateString();
                //cmSugarInsert.Parameters.Add(myparam);

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
                cmSugarInsert.Parameters.Add("@salutation", MySqlDbType.VarChar, 255, "@salutation");
                cmSugarInsert.Parameters["@salutation"].Value = cboAnrede.Text;
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
                //cmSugarInsert.Parameters.Add("@lead_source", MySqlDbType.VarChar, 255, "@lead_source");
                //cmSugarInsert.Parameters["@lead_source"].Value = txtSugarLeadSource.Text;
                //cmSugarInsert.Parameters.Add("@birthdate", MySqlDbType.Date);
                //cmSugarInsert.Parameters["@birthdate"].Value = txtCaoGeb.Text;
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
