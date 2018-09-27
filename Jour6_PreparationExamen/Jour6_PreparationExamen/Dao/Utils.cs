using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Jour6_PreparationExamen.Dao
{
    public class Utils
    {
        static Utils utils;


        public static Utils GetInstance()
        {

            if (utils != null)
            {
                return utils;
            }
            else
                utils = new Utils();

            return utils;

        }


        public List<Models.Activity> GetListeActivity()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=activite;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "GetListActivity";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;


            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            List<Models.Activity> result = new List<Models.Activity>();

            while (reader.Read())
            {
                Models.Activity item = new Models.Activity()
                {

                    Nom = reader["nom"].ToString(),
                    Duree = (int) reader["duree"],
                    Cout = (int) reader["cout"],

                };

                result.Add(item);

            }




            return result;
        }




        internal void InsertVote(string nom, string activity)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=activite;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            //SqlDataReader reader;
            //   @Id INT,
            //   @Title NVARCHAR(50),
            //@Genre NVARCHAR(50),
            //@Year INT

            cmd.CommandText = "InsertVote";
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.Parameters.AddWithValue("@activity", activity);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;


            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }


        internal Dictionary<string, string> GetVotes()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=activite;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader; 

            cmd.CommandText = "GetVotes";
            //cmd.Parameters.AddWithValue("@nom", nom);
            //cmd.Parameters.AddWithValue("@activity", activity);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;


            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            Dictionary<string, string> result = new Dictionary<string, string>();

            while (reader.Read())
            {
                result.Add(reader["activity"].ToString(), reader["vcount"].ToString());
            }

            sqlConnection.Close();
            return result;
        }

    }
}