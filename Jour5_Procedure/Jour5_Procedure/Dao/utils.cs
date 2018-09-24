using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Jour5_Procedure.Models;

namespace Jour5_Procedure.Dao
{
    public class Utils
    {
        static Utils utils;


        public static Utils GetInstance()
        {

            if(utils != null)
            {
                return utils;
            }
            else
                utils = new Utils(); 

            return utils;

        }


        public List<Movie> GetListeMovie()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True;Pooling=False");

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText ="GetListeFilms";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;
            

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            List<Models.Movie> result = new List<Models.Movie>();

            while (reader.Read())
            {
                Models.Movie item = new Models.Movie()
                {

                    Id = (int)reader["id"],
                    Title = reader["title"].ToString(),
                    Genre = reader["genre"].ToString(),
                    Year = (int)reader["year"],

                };

                result.Add(item);

            }




            return result;
        }
    }


    /*public List<Movie> GetMovieById(List<> list, int id)
    {
        List<Movie> listById = new List<Movie>();




        return listById;
    }*/
}