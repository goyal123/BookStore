using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class FeedbackRL:IFeedbackRL
    {
        private readonly string Connectionstring;
        public FeedbackRL(IConfiguration configuration)
        {
            Connectionstring = configuration.GetConnectionString("BookStoreDB");

        }
        public Feedmodel AddFeedback(string email, Feedmodel feed)
        {
            string Connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            SqlConnection connection = new SqlConnection(Connectionstring);
            try
            {
                SqlCommand cmd1 = new SqlCommand("sp_UserIdcheck", connection);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Email", email);
                connection.Open();
                var userid = cmd1.ExecuteScalar();

                SqlCommand cmd2 = new SqlCommand("sp_AddFeedback", connection);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@Comment",feed.Comment);
                cmd2.Parameters.AddWithValue("@Rating", feed.Rating);
                cmd2.Parameters.AddWithValue("@UserId", userid);
                cmd2.Parameters.AddWithValue("@BookId", feed.BookId);
                var result = cmd2.ExecuteNonQuery();
                connection.Close();

                if (result != 0)
                {
                    return feed;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
