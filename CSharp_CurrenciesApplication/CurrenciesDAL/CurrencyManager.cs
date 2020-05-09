using CurrenciesDAL.Models;
using CurrenciesDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrenciesDAL
{
    public static class CurrencyManager
    {
        public static Currency GetCurrency(int Id)
        {
            //get connection from DB class

            using (SqlConnection conn = DB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetOneCurrency";
                    cmd.Parameters.AddWithValue("@Id", Id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();

                        //generate a new category object
                        //and fill it with data from the reader
                        Currency c = new Currency();
                        c.Id = reader.GetInt32(0);
                        c.Name = reader.GetString(1);
                        c.ColourId = reader.GetInt32(2);
                        c.CountryCode = reader.GetString(3);
                        return c;

                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public static List<Currency> GetCurrencyListForCountry(string countryCode)
        {
            //create empty list to hold currency objects
            List<Currency> currencies = new List<Currency>();

            //get a connection from DB class
            using (SqlConnection conn = DB.GetConnection())
            {   //create a command using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetCurrencyByCountry";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //generatate a new category object
                        //and fill it with data from the reader
                        Currency currency = new Currency();
                        currency.Id = reader.GetInt32(0);
                        currency.Name = reader.GetString(1);
                        currency.ColourId = reader.GetInt32(2);
                        currency.CountryCode = reader.GetString(3);
                        //add the filled category to my list
                        currencies.Add(currency);
                    }
                }
            }

            //return the list
            return currencies;

        }

        public static List<Currency> GetCurrencyListForType(int typeId)
        {
            //create empty list to hold currency objects
            List<Currency> currencies = new List<Currency>();

            //get a connection from DB class
            using (SqlConnection conn = DB.GetConnection())
            {   //create a command using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetCurrencyByType";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@typeId", typeId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //generatate a new category object
                        //and fill it with data from the reader
                        Currency currency = new Currency();
                        currency.Id = reader.GetInt32(0);
                        currency.Name = reader.GetString(1);
                        currency.ColourId = reader.GetInt32(2);
                        currency.CountryCode = reader.GetString(3);
                        //add the filled category to my list
                        currencies.Add(currency);
                    }
                }
            }

            //return the list
            return currencies;
    }

        public static List<Currency> GetCurrencyListForColour()
        {
            //create empty list to hold currency objects
            List<Currency> currencies = new List<Currency>();

            //get a connection from DB class
            using (SqlConnection conn = DB.GetConnection())
            {   //create a command using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetCurrencyByColor";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //generatate a new category object
                        //and fill it with data from the reader
                        Currency currency = new Currency();
                        currency.Id = reader.GetInt32(0);
                        currency.Name = reader.GetString(1);
                        currency.ColourId = reader.GetInt32(2);
                        currency.CountryCode = reader.GetString(3);
                        //add the filled category to my list
                        currencies.Add(currency);
                    }
                }
            }

            //return the list
            return currencies;

        }

        public static List<Currency> GetCurrencyList()
        {
            //create empty list to hold currency objects
            List<Currency> currencies = new List<Currency>();

            //get a connection from DB class
            using (SqlConnection conn = DB.GetConnection())
            {   //create a command using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetCurrency";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //generatate a new category object
                        //and fill it with data from the reader
                        Currency currency = new Currency();
                        currency.Id = reader.GetInt32(0);
                        currency.Name = reader.GetString(1);
                        currency.ColourId = reader.GetInt32(2);
                        currency.CountryCode = reader.GetString(3);
                        //add the filled category to my list
                        currencies.Add(currency);
                    }
                }
            }

            //return the list
            return currencies;
        }

        public static Currency AddCurrency(Currency currency)
        {
            //get connection
            using (SqlConnection conn = DB.GetConnection()) //different from "using" on the top
            {
                //define a command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "AddCurrency";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    //input parameter
                    cmd.Parameters.AddWithValue("@Name", currency.Name);

                    //output parameter
                    SqlParameter outParam = new SqlParameter();
                    outParam.SqlDbType = System.Data.SqlDbType.Int;
                    outParam.ParameterName = "@new_Identity";
                    outParam.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    //run the command
                    cmd.ExecuteScalar();

                    //set the id with the new row id
                    currency.Id = (int)cmd.Parameters["@newIdentity"].Value;
                    return currency;
                }
            }
            //confirm command execution
            ///close connection
        }

        /// <summary>
        /// Delete a currency 
        /// </summary>
        /// <param name="Id">The id of the Currency to delete</param>
        /// <returns>Number of rows affected</returns>
        public static int DeleteCurrency(int Id)
        {
            //get connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //create a command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DeleteCurrency";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);

                    //run command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected;
                }
            }
        }

        public static int UpdateCurrency(int currencyId, string currencyName, int colourId, string countryCode)
        {
            //get connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //create a command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UpdateCurrency";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", currencyId);
                    cmd.Parameters.AddWithValue("@Name", currencyName);
                    cmd.Parameters.AddWithValue("@ColourId", colourId);
                    cmd.Parameters.AddWithValue("@CountryCode", countryCode);

                    //run command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    //return the value
                    return rowsAffected;
                }

            }
        }
    }
};