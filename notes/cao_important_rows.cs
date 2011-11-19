//REC_ID
//KUNDENGRUPPE
//NAME1
//PLZ
//ORT
//ANREDE
//STRASSE
//TELE1
//TELE2
//FAX
//FUNK
//EMAIL
//INTERNET
//BRIEFANREDE
//BRT_TAGE
//INFO
//KUN_LIEFART
//KUN_ZAHLART

#region Insert Command Text
StringBuilder sbInsert = new StringBuilder();
sbInsert.Append("INSERT INTO adressen(");
sbInsert.Append("REC_ID, ");
sbInsert.Append("KUNDENGRUPPE, ");
sbInsert.Append("NAME1, ");
sbInsert.Append("PLZ, ");
sbInsert.Append("ORT, ");
sbInsert.Append("ANREDE, ");
sbInsert.Append("STRASSE, ");
sbInsert.Append("TELE1, ");
sbInsert.Append("TELE2, ");
sbInsert.Append("FAX, ");
sbInsert.Append("FUNK, ");
sbInsert.Append("EMAIL, ");
sbInsert.Append("INTERNET, ");
sbInsert.Append("BRIEFANREDE, ");
sbInsert.Append("BRT_TAGE, ");
sbInsert.Append("INFO, ")
sbInsert.Append("KUN_LIEFART, ");

sbInsert.Append(@"KUN_ZAHLART)");
sbInsert.Append(@" VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");
#endregion

//create insert command with the given string and an former defined connectiton
OdbcCommand caoInsert = new OdbcCommand(sbInsert.ToString(), m_objCao.CaoConnection);

#region parameter definition
caoInsert.Parameters.Add["@REC_ID"].


result
sbInsert = {INSERT INTO adressen(REC_ID, KUNDENGRUPPE, NAME1, PLZ, ORT, ANREDE, STRASSE, TELE1, TELE2, FAX, FUNK, EMAIL, INTERNET, BRIEFANREDE, BRT_TAGE, INFO, KUN_LIEFART, KUN_ZAHLART) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)}
