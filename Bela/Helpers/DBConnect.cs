using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Threading;

namespace Bella.Helpers
{

    public static class DBConnect
    {
        public static class Data
        {
            static SqlConnection conn;
            public static SqlConnection Connection
            {
                get
                {
                    if (conn == null)
                        //If connection is close then open
                        LazyInitializer.EnsureInitialized(ref conn, CreateConnection);
                    return conn;
                }
            }

            static SqlConnection CreateConnection()
            {
                //Create connection
                string connectionString =  ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                conn = new SqlConnection(connectionString);
                conn.Open();
                //Open
                return conn;
            }

        }
    }
}

