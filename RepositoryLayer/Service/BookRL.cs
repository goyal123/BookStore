using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

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
                cmd.Parameters.AddWithValue("@BookStockQty", bookmodel.BookStockQty);
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
            List<Book> books = new List<Book>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllBooks", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book()
                        {
                            Title = reader.GetValue(1).ToString(),
                            Description=reader.GetValue(2).ToString(),
                            Author=reader.GetValue(3).ToString(),
                            Image=reader.GetValue(4).ToString(),
                            ActualPrice=Convert.ToInt64(reader.GetValue(5)),
                            DiscountedPrice= Convert.ToInt64(reader.GetValue(6)),
                            CustomerRatedcount=Convert.ToInt32(reader.GetValue(7))
                        });
                    }
                }

                return books;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Book GetBookById(long BookId)
        {
            string Connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

            SqlConnection connection = new SqlConnection(Connectionstring);

            try
            {
                Book bookobj = new Book();
                SqlCommand cmd = new SqlCommand("sp_GetBookById", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId", BookId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bookobj.Title = reader.GetValue(1).ToString();
                    bookobj.Description = reader.GetValue(2).ToString();
                    bookobj.Author = reader.GetValue(3).ToString();
                    bookobj.Image = reader.GetValue(4).ToString();
                    bookobj.ActualPrice = Convert.ToInt64(reader.GetValue(5));
                    bookobj.DiscountedPrice = Convert.ToInt64(reader.GetValue(6));
                    bookobj.CustomerRatedcount = Convert.ToInt32(reader.GetValue(7));
                }

                if (bookobj != null)
                {
                    return bookobj;
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
