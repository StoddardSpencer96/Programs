using CurrenciesDAL.Models;
using CurrenciesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CurrenciesDAL
{
    public static class CountryManager
    {
        public static Country GetCountry(string CountryCode)
        {
            //get connection from DB class

            using (SqlConnection conn = DB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetOneCountry";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CountryCode", CountryCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();

                        //generate a new category object
                        //and fill it with data from the reader
                        Country c = new Country();
                        c.CountryCode = reader.GetString(0);
                        c.Name = reader.GetString(1);
                        return c;

                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        public static List<Country> GetCountryList()
        {
            //create empty list to hold currency objects
            List<Country> countries = new List<Country>();

            //get a connection from DB class
            using (SqlConnection conn = DB.GetConnection())
            {   //create a command using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetCountry";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //generatate a new category object
                        //and fill it with data from the reader
                        Country country = new Country();
                        country.CountryCode = reader.GetString(0);
                        country.Name = reader.GetString(1);
                        //add the filled category to my list
                        countries.Add(country);
                    }
                }
            }

            //return the list
            return countries;
        }

        public static Country AddCountry(Country country)
        {
            //get connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //define a command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "AddCountry";
                    cmd.Parameters.AddWithValue("@Code", country.CountryCode);
                    cmd.Parameters.AddWithValue("@Name", country.Name);
                    cmd.Connection = conn;

                    cmd.ExecuteNonQuery();

                    //run the command
                    country.CountryCode = Convert.ToString(cmd.Parameters["@Code"].Value);

                    //return the value
                    return country;

                }
            }
        }

        public static string DeleteCountry(string countryCode)
        {
            //get a connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //get a command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DeleteCountry";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CountryCode", countryCode);

                    //run command
                   string rowsAffected = cmd.ExecuteNonQuery().ToString(); //convert to a string

                    return rowsAffected.ToString(); // convert the return type to a string
                }
            }
        }

        public static string UpdateCountry(string countryCode, string countryName)
        {
            //get connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //create a command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UpdateCountry";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CountryCode", countryCode);
                    cmd.Parameters.AddWithValue("@Name", countryName);

                    //run command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    //return the value
                    return rowsAffected.ToString(); //convert the return type to a string
                }
            }
        }
    }
};
