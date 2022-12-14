using BookStore.CommonLayer.Model;
using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RepositoryLayer.Service
{
    public class OrderRL:IorderRL
    {
        private readonly string Connectionstring;
        public OrderRL(IConfiguration configuration)
        {
            Connectionstring = configuration.GetConnectionString("BookStoreDB");

        }

        public bool AddOrder(string email, long CartId)
        {
            string Connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            SqlConnection connection = new SqlConnection(Connectionstring);
            DateTime orderDate = DateTime.Now;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UserIdcheck", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                connection.Open();
                var userid = cmd.ExecuteScalar();

                SqlCommand cmd1 = new SqlCommand("sp_GetQuantityFromCart", connection);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@CartId", CartId);
                cmd1.Parameters.AddWithValue("@UserId", userid);
                var Quantity = cmd1.ExecuteScalar();

                SqlCommand cmd2 = new SqlCommand("sp_GetBookIdFromCart", connection);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@CartId", CartId);
                cmd2.Parameters.AddWithValue("@UserId", userid);
                var BookId = cmd2.ExecuteScalar();


                SqlCommand cmd3 = new SqlCommand("sp_AddOrder", connection);
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@OrderDate", orderDate);
                cmd3.Parameters.AddWithValue("@CartId", CartId);
                cmd3.Parameters.AddWithValue("@BookId", BookId);
                cmd3.Parameters.AddWithValue("@UserId", userid);
                cmd3.Parameters.AddWithValue("Book_Quantity",Quantity);

                var result = cmd3.ExecuteNonQuery();
                //connection.Close();
                if (result != 0)
                {
                    SqlCommand cmd4 = new SqlCommand("sp_UpdateBookQuantity", connection);
                    cmd4.CommandType = CommandType.StoredProcedure;
                    cmd4.Parameters.AddWithValue("@BookId",BookId);
                    cmd4.Parameters.AddWithValue("@BookStockQuantity", Quantity);
                    var result1 = cmd4.ExecuteNonQuery();

                    CartRL cartRL = new CartRL();
                    cartRL.DeleteCart(CartId);
                    
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

        public bool DeleteOrder(long OrderId)
        {
            string Connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            SqlConnection connection = new SqlConnection(Connectionstring);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteOrder", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
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

        public List<OrderModel> GetAllOrders(string email)
        {
            string Connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            SqlConnection connection = new SqlConnection(Connectionstring);
            List<OrderModel> orderlist = new List<OrderModel>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UserIdcheck", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                connection.Open();
                var userid = cmd.ExecuteScalar();

                SqlCommand cmd1 = new SqlCommand("sp_GetAllOrders", connection);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@UserId", userid);
                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orderlist.Add(new OrderModel()
                        {
                            OrderId=Convert.ToInt32(reader.GetValue(0)),
                            OrderDate = reader.GetValue(1).ToString(),
                            CartId = Convert.ToInt32(reader.GetValue(2))
                        });
                    }
                }

                return orderlist;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
