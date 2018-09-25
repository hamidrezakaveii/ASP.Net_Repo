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


        internal List<Movie> GetListeMovie()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLlocalDB;Initial Catalog=MovieDB;Integrated Security=True;Pooling=False");

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



        public List<Movie> GetMovieById(List<Movie> list, int id)
        {
            List<Movie> listById = new List<Movie>();

            foreach (var item in list)
            {
                if(item.Id == id)
                {
                    listById.Add(item);
                }
            }



            return listById;
        }

        internal void UpdateMovie(int id, string title, string genre, int year)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLlocalDB;Initial Catalog=MovieDB;Integrated Security=True;Pooling=False");

            SqlCommand cmd = new SqlCommand();
            //SqlDataReader reader;
         //   @Id INT,
         //   @Title NVARCHAR(50),
	        //@Genre NVARCHAR(50),
	        //@Year INT

            cmd.CommandText = "UpdateMovieById";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Genre", genre);
            cmd.Parameters.AddWithValue("@Year", year);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;


            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }



}