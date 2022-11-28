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
    public class WishlistRL:IWishlistRL
    {
        private readonly string Connectionstring;
        public WishlistRL(IConfiguration configuration)
        {
            Connectionstring = configuration.GetConnectionString("BookStoreDB");

        }

        public bool AddItem(string email,long BookId)
        {
            string Connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            SqlConnection connection = new SqlConnection(Connectionstring);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_UserIdcheck", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                connection.Open();
                var userid = cmd.ExecuteScalar();

                SqlCommand cmd1 = new SqlCommand("sp_AddItemWishList", connection);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@BookId",BookId);
                cmd1.Parameters.AddWithValue("@UserId",userid);
                var result = cmd1.ExecuteNonQuery();
                connection.Close();

                if (result != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteItem(string email, long WishlistId)
        {
            string Connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            SqlConnection connection = new SqlConnection(Connectionstring);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_UserIdcheck", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                connection.Open();
                var userid = cmd.ExecuteScalar();

                SqlCommand cmd1 = new SqlCommand("sp_DeleteItemWishList", connection);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@WishListId", WishlistId);
                cmd1.Parameters.AddWithValue("@UserId", userid);
                var result = cmd1.ExecuteNonQuery();
                connection.Close();

                if (result != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
