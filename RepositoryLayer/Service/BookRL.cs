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
    public class BookRL:IBookRL
    {
        private readonly string Connectionstring;

        public BookRL(IConfiguration configuration)
        {
            Connectionstring = configuration.GetConnectionString("BookStoreDB");
        }
        public Book AddBook(Book bookmodel)
        {
            string Connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

            SqlConnection connection = new SqlConnection(Connectionstring);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_AddBook", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", bookmodel.Title);
                cmd.Parameters.AddWithValue("@Description",bookmodel.Description);
                cmd.Parameters.AddWithValue("@Author", bookmodel.Author);
                cmd.Parameters.AddWithValue("@Image", bookmodel.Image);
                cmd.Parameters.AddWithValue("@ActualPrice", bookmodel.ActualPrice);
                cmd.Parameters.AddWithValue("@DiscountPrice", bookmodel.DiscountedPrice);
                cmd.Parameters.AddWithValue("@Rating", bookmodel.Rating);
                cmd.Parameters.AddWithValue("@CustomerRatedCount", bookmodel.CustomerRatedcount);
                connection.Open();
                var result = cmd.ExecuteNonQuery();
                connection.Close();

                if (result != 0)
                {
                    return bookmodel;
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

        public Book UpdateBook(int BookId,Book bookmodel)
        {
            string Connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

            SqlConnection connection = new SqlConnection(Connectionstring);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateBook", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId", BookId);
                cmd.Parameters.AddWithValue("@Name", bookmodel.Title);
                cmd.Parameters.AddWithValue("@Description", bookmodel.Description);
                cmd.Parameters.AddWithValue("@Author", bookmodel.Author);
                cmd.Parameters.AddWithValue("@Image", bookmodel.Image);
                cmd.Parameters.AddWithValue("@ActualPrice", bookmodel.ActualPrice);
                cmd.Parameters.AddWithValue("@DiscountPrice", bookmodel.DiscountedPrice);
                cmd.Parameters.AddWithValue("@Rating", bookmodel.Rating);
                cmd.Parameters.AddWithValue("@CustomerRatedCount", bookmodel.CustomerRatedcount);
                connection.Open();
                var result = cmd.ExecuteNonQuery();
                connection.Close();

                if (result != 0)
                {
                    return bookmodel;
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

        public List<Book> GetAllBooks()
        {
            string Connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

            SqlConnection connection = new SqlConnection(Connectionstring);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllBooks", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                var result = cmd.ExecuteScalar();
                connection.Close();

                if (result != null)
                {
                    return null;
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
        public bool DeleteBook(int BookId)
        {
            string Connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

            SqlConnection connection = new SqlConnection(Connectionstring);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteBook", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId", BookId);
                connection.Open();
                var result = cmd.ExecuteNonQuery();
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
