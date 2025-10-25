using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    //public class Connection
    public static class Connection
    {
        //private string SQL_NAME { get; set; }
        //private string DB_NAME { get; set; }


        //public Connection(string sql_name)
        //{
        //    SQL_NAME = sql_name;
        //}




        // Connection String
        //public string ConnectionString = $"Server={};Database={DB_NAME};Trusted_Connection=True;";
        public static string ConnectionString = "Server=.\\MSSQLSERVER2022;Database=LMS;Trusted_Connection=True;";
        
        // Start Connection
        public static SqlConnection GetConn() {
            SqlDependency.Stop(ConnectionString);
            SqlDependency.Start(ConnectionString);
            return new SqlConnection(ConnectionString);
        }

        // Close Connection
        public static void CloseConn()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Close();
            //SqlDependency.Stop(ConnectionString);
        }
    }
}
