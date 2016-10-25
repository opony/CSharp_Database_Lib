using DatabaseLib.DataBase;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System;

namespace DatabaseLib.Database
{
    public class OracleDatabase : ADatabase
    {
        private string connStr;

        public OracleDatabase(string connStr)
        {
            this.connStr = connStr;
        }

        public override IDbConnection GetConnection()
        {
            if (conn == null)
            {
                conn = new OracleConnection(this.connStr);
            }

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                OracleGlobalization oracleInfo = ((OracleConnection)conn).GetSessionInfo();
                oracleInfo.Language = "AMERICAN";
                ((OracleConnection)conn).SetSessionInfo(oracleInfo);
            }
            

            return conn;
        }

        public override DataTable ExecuteResult(IDbCommand cmd)
        {
            //GetConnection();
            cmd.Connection = this.conn;
            DataTable result = new DataTable();
            using (OracleDataAdapter adapter = new OracleDataAdapter((OracleCommand)cmd))
            {
                adapter.Fill(result);
            }

            return result;
        }

        public override void ExecuteNonQuery(IDbCommand cmd)
        {
            //GetConnection();
            cmd.Connection = this.conn;
            cmd.ExecuteNonQuery();
        }

    }
}