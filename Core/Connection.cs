using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace LMS
{
    public static class Connection
    {
        private static string GetConnectionStringName()
        {
            bool useLocal = Convert.ToBoolean(ConfigurationManager.AppSettings["UseLocalDatabase"] ?? "true");
            return useLocal ? "LocalConnection" : "ProductionConnection";
        }

        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings[GetConnectionStringName()].ConnectionString;

        // Get connection string by name (optional)
        public static string GetConnectionString(string connectionName = null)
        {
            if (string.IsNullOrEmpty(connectionName))
                connectionName = GetConnectionStringName();

            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        // Start Connection
        public static SqlConnection GetConn()
        {
            try
            {
                SqlDependency.Stop(ConnectionString);
                SqlDependency.Start(ConnectionString);
                return new SqlConnection(ConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to establish database connection: {ex.Message}");
            }
        }

        // Get connection without SqlDependency (for simple operations)
        public static SqlConnection GetSimpleConn()
        {
            return new SqlConnection(ConnectionString);
        }

        // Close Connection (improved)
        public static void CloseConn(SqlConnection conn)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
        }

        // Test connection
        public static async Task<bool> TestConnectionAsync(string connectionName = null)
        {
            string connString = string.IsNullOrEmpty(connectionName)
                ? ConnectionString
                : GetConnectionString(connectionName);

            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    await conn.OpenAsync();
                    return conn.State == ConnectionState.Open;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}