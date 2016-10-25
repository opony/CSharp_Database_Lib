using DatabaseLib.Util;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace DatabaseLib.Database
{
    public class DatabaseFactory
    {
        public static OracleDatabase GetOracleDatabaseByConfig(string key)
        {
            string connStr = ConfigurationManager.AppSettings[key];
            return new OracleDatabase(connStr);
        }


        public static OracleDatabase GetOracleDatabaseByConfigEncrypt(string key)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings[key].ConnectionString;

            OracleConnectionStringBuilder builder = new OracleConnectionStringBuilder(connStr);
            builder.Password = EncryptUtil.Decrypt(builder.Password);

            return new OracleDatabase(builder.ToString());
        }

    }
}