using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace JangMVCWebSite.Utile.DB
{
    public static class SqlHelper
    {
        public static SqlCommand GetCommand(this SqlConnection conn, string query)
        {
            SqlCommand cm = conn.CreateCommand();
            cm.CommandTimeout = conn.ConnectionTimeout;
            cm.CommandText = query;
            return cm;
        }

        public static void AddParameter(this SqlCommand cm, string paramName, object paramValue, SqlDbType paramSqlType)
        {
            if (!paramName.StartsWith("@"))
            {
                paramName = $"@{paramName}";
            }
            cm.Parameters.Add(paramName, paramSqlType);
            cm.Parameters[paramName].Value = paramValue;
        }
    }
}