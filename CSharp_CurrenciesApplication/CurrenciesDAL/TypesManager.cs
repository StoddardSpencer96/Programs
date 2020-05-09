using CurrenciesDAL.Models;
using CurrenciesDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = CurrenciesDAL.Models.Type;

namespace CurrenciesDAL
{
    public static class TypesManager
    {
        public static Type GetTypes(int Id)
        {
            //get connection from DB class

            using (SqlConnection conn = DB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetOneType";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);


                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();

                        //generate a new category object
                        //and fill it with data from the reader
                        Type t = new Type();
                        t.Id = reader.GetInt32(0);
                        t.Name = reader.GetString(1);
                        return t;

                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        public static List<Type> GetTypeList()
        {
            //create empty list to hold currency objects
            List<Type> types = new List<Type>();

            //get a connection from DB class
            using (SqlConnection conn = DB.GetConnection())
            {   //create a command using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetType";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //generatate a new category object
                        //and fill it with data from the reader
                        Models.Type type = new Models.Type();
                        type.Id = reader.GetInt32(0);
                        type.Name = reader.GetString(1);
                        //add the filled category to my list
                        types.Add(type);
                    }
                }
            }

            //return the list
            return types;
        }

        public static Type AddType(Type type)
        {
            //get a connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //get a command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "AddType";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", type.Name);

                    SqlParameter outParam = new SqlParameter();
                    outParam.SqlDbType = System.Data.SqlDbType.Int;
                    outParam.ParameterName = "@newID";
                    outParam.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    cmd.ExecuteNonQuery();

                    //set the id with the new row id
                    type.Id = (int)cmd.Parameters["@newId"].Value;

                    //return the value
                    return type;
                }
            }
        }

        public static int DeleteType(int Id)
        {
            //get a connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //get a command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DeleteType";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);

                    //run command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected;
                }
            }
        }

        public static int UpdateType(int Id, string Name)
        {
            //get a connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //get a command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UpdateType";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Name", Name);

                    //run command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    //return the value
                    return rowsAffected;
                }
            }
        }
    }
};