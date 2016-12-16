using DatabaseLib.Util;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Text;

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

        public static OracleDatabase GetOracleDatabaseByConnStr(string connStr)
        {
            OracleConnectionStringBuilder builder = new OracleConnectionStringBuilder(connStr);
            builder.Password = EncryptUtil.Decrypt(builder.Password);

            return new OracleDatabase(builder.ToString());

        }


        /// <summary>
        /// Get Oracle database
        /// </summary>
        /// <param name="ip">Host IP</param>
        /// <param name="port">Port</param>
        /// <param name="servName">Service Name</param>
        /// <param name="userName">User Name</param>
        /// <param name="pwd">Password</param>
        /// <returns></returns>
        public static OracleDatabase GetOracleDatabase(string ip, int port, string servName, string userName, string pwd)
        {
            
            StringBuilder connStr = new StringBuilder();
            connStr.Append("(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=").Append(ip).Append(")(PORT=").Append(port)
                .Append(")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=").Append(servName).Append(")))");

            OracleConnectionStringBuilder builder = new OracleConnectionStringBuilder(connStr.ToString());
            builder.UserID = userName;
            builder.Password = pwd;

            return new OracleDatabase(builder.ToString());

        }
    }
}