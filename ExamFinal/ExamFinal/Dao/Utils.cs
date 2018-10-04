using ExamFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamFinal.Dao
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


        public List<Models.Ville> GetListeVille()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Frais;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "GetListVille";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;


            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            List<Models.Ville> result = new List<Models.Ville>();

            while (reader.Read())
            {
                Models.Ville item = new Models.Ville()
                {

                    Nom = reader["nom"].ToString(),

                };

                result.Add(item);

            }




            return result;
        }




        internal void InsertFrais(string nom,string prenom,string date,int kilometre,string ville, double fraisresturant,string codepostal,string courriel)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Frais;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "InsertFrais";
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.Parameters.AddWithValue("@prenom", prenom);
            cmd.Parameters.AddWithValue("@data", date);
            cmd.Parameters.AddWithValue("@kilometre", kilometre);
            cmd.Parameters.AddWithValue("@ville", ville);
            cmd.Parameters.AddWithValue("@fraisrestaurant", fraisresturant);
            cmd.Parameters.AddWithValue("@codepostal", codepostal);
            cmd.Parameters.AddWithValue("@courriel", courriel);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;


            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }


        internal List<Frais> GetListFrais()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Frais;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "GetListFrais";

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;


            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            List<Frais> result = new List<Frais>();

            while (reader.Read())
            {
                result.Add(new Frais(reader["nom"].ToString(), reader["prenom"].ToString(), reader["data"].ToString(), int.Parse(reader["kilometre"].ToString()), reader["ville"].ToString(), double.Parse(reader["fraisrestaurant"].ToString()), reader["codepostal"].ToString(), reader["courriel"].ToString()));
            }

            sqlConnection.Close();


            return result;
        }

    }
}