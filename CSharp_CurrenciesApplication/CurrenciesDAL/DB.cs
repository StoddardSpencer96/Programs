using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CurrenciesDAL
{
    public static class DB
    {
        public static SqlConnection GetConnection()
        {
               //string connectionString = @"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=CurrenciesDB;Integrated Security=True";
                //string connectionString = @"Data Source = currenciesdb2019.database.windows.net; User ID = w0286670; Password = MyCurrenciesApplication.; Connect Timeout = 60; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

                string activeCS = ConfigurationManager.AppSettings["activeConnectionString"];

                string connectionString = ConfigurationManager
                    .ConnectionStrings[activeCS]
                    .ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            return connection;
            }
        //public static SqlConnection GetConnection()
        //{
        //    SqlConnection connection = new SqlConnection(ConnectionString);

        //    connection.Open();

        //    return connection;
        //}

    }
}
