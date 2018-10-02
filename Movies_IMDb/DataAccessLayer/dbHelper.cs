using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Movies_IMDb.Models;

namespace Movies_IMDb.DataAccessLayer
{
    public class dbHelper
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public void AddNewMovie(Movie addMovie)
        {
            SqlCommand com = new SqlCommand("InsertNewMovie", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Movie_Name", addMovie.MovieName);
            com.Parameters.AddWithValue("@Movie_Plot", addMovie.Plot);
            com.Parameters.AddWithValue("@Movie_Release_Date", addMovie.DateOfRelease);
            com.Parameters.AddWithValue("@Movie_Poster", addMovie.Poster);
            com.Parameters.Add("@Movie_Id", SqlDbType.Int).Direction = ParameterDirection.Output;
            con.Open();
            com.ExecuteNonQuery();

            Int64 id = Convert.ToInt64(com.Parameters["@Movie_Id"].Value);
            SqlCommand comm = new SqlCommand("InsertMapMovieProducer", con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Producer_Id", addMovie.ProducerId);
            comm.Parameters.AddWithValue("@Movie_Id", id);
            comm.ExecuteNonQuery();

            SqlCommand commd = new SqlCommand("InsertMapMovieActor", con);
            commd.CommandType = CommandType.StoredProcedure;
            foreach (Int64 actid in addMovie.ActorId)
            {
                commd.Parameters.AddWithValue("@Actor_Id", actid);
                commd.Parameters.AddWithValue("@Movie_Id", id);
                commd.ExecuteNonQuery();
                commd.Parameters.Clear();
            }
            
            con.Close();
        }
        public void EditMovieDetail(Movie movie)
        {
            SqlCommand com = new SqlCommand("EditMovieDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Movie_Plot", movie.Plot);
            com.Parameters.AddWithValue("@Movie_Id", movie.MovieId);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void AddNewProducer(Producer producer)
        {
            SqlCommand com = new SqlCommand("InsertNewProducer", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProducerName", producer.ProducerName);
            com.Parameters.AddWithValue("@Gender", producer.Gender);
            com.Parameters.AddWithValue("@DateOfBirth", producer.DateOfBirth);
            com.Parameters.AddWithValue("@Bio", producer.Bio);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void AddNewActor(Actor actor)
        {
            SqlCommand com = new SqlCommand("InsertNewActor", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ActorName", actor.ActorName);
            com.Parameters.AddWithValue("@Gender", actor.Gender);
            com.Parameters.AddWithValue("@DateOfBirth", actor.DateOfBirth);
            com.Parameters.AddWithValue("@Bio", actor.Bio);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet GetRecord(string Proc_Name)
        {
            SqlCommand com = new SqlCommand(Proc_Name, con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
    }
}