using CurrenciesDAL.Models;
using CurrenciesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Colour = CurrenciesDAL.Models.Colour;

namespace CurrenciesDAL
{
    public static class ColoursManager
    {
        public static Colour GetColour(int Id)
        {
            //get connection from DB class

            using (SqlConnection conn = DB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetOneColour";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();

                        //generate a new category object
                        //and fill it with data from the reader
                       Colour c = new Colour();
                        c.Id = reader.GetInt32(0);
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
        public static List<Colour> GetColourList()
        {
            //create empty list to hold currency objects
            List<Colour> colours = new List<Colour>();

            //get a connection from DB class
            using (SqlConnection conn = DB.GetConnection())

            {   //create a command using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetColour";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //generatate a new category object
                        //and fill it with data from the reader
                        Colour colour = new Colour();
                        colour.Id = reader.GetInt32(0);
                        colour.Name = reader.GetString(1);
                        //add the filled category to my list
                        colours.Add(colour);
                    }
                }
            }

            //return the list
            return colours;
        }

        public static Colour AddColour(Colour colour)
        {
            //get connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //define a command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "AddColour";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    //input parameter 
                    cmd.Parameters.AddWithValue("@Name", colour.Name);

                    //Create the out paramenter, set the properites and add to command).
                    SqlParameter outParamColour = new SqlParameter();
                    outParamColour.SqlDbType = System.Data.SqlDbType.Int;
                    outParamColour.ParameterName = "@newIdentity";
                    outParamColour.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outParamColour);

                    cmd.ExecuteScalar();

                    //set the id with the new row id
                    colour.Id = Convert.ToInt32(cmd.Parameters["@newIdentity"].Value);

                    //return the value
                    return colour;

                }
            }
        }

        public static int DeleteColour(int Id)
        {
            //get a connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //create a command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DeleteColour";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);

                    //run command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    //return the value
                    return rowsAffected;

                }
            }
        }

        public static int UpdateColour(int Id, string Name)
        {
            //get a connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //create a command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UpdateColour";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Name", Name);

                    //run a command
                    int rowsAffected = cmd.ExecuteNonQuery();
                    //return the value
                    return rowsAffected;
                }
            }
        }
    }
};