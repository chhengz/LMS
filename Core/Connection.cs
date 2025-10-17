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



    public static class Connection
    {
        // TODO: Replace with your actual SQL Server connection string
        public static string ConnectionString = "Server=.\\MSSQLSERVER2022;Database=LMS;Trusted_Connection=True;";

        public static SqlConnection GetConn() {
            SqlDependency.Stop(ConnectionString);
            SqlDependency.Start(ConnectionString);
            return new SqlConnection(ConnectionString);
        }



    }


}
