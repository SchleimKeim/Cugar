public void UpdateCaoPrivate()
{
    m_daCao = new OdbcDataAdapter();
    #region string build for update commant
    StringBuilder sbUpdate = new StringBuilder();
    sbUpdate.Append("UPDATE adressen SET REC_ID = ?, ");
    #endregion
}