using BookStore.CommonLayer.Model;
using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;

namespace RepositoryLayer.Service
{
    public class AddressRL:IAddressRL
    {
        private readonly string Connectionstring;

        public AddressRL(IConfiguration configuration)
        {
            Connectionstring = configuration.GetConnectionString("BookStoreDB");
        }

        public AddressModel CreateAddress(string email,long Address_Type, AddressModel addressModel)
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

                SqlCommand cmd1 = new SqlCommand("sp_AddAddress", connection);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Address", addressModel.Address);
                cmd1.Parameters.AddWithValue("@City", addressModel.City);
                cmd1.Parameters.AddWithValue("@State", addressModel.State);
                cmd1.Parameters.AddWithValue("@Address_Type",Address_Type);
                cmd1.Parameters.AddWithValue("@UserId", userid);

                var result = cmd1.ExecuteNonQuery();
                connection.Close();

                if (result != 0)
                {
                    return addressModel;
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

        public AddressModel UpdateAddress(string email, long Address_Type, AddressModel addressModel)
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

                SqlCommand cmd1 = new SqlCommand("sp_UpdateAddress", connection);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Address", addressModel.Address);
                cmd1.Parameters.AddWithValue("@City", addressModel.City);
                cmd1.Parameters.AddWithValue("@State", addressModel.State);
                cmd1.Parameters.AddWithValue("@Address_Type",Address_Type);
                cmd1.Parameters.AddWithValue("@UserId", userid);

                var result = cmd1.ExecuteNonQuery();
                connection.Close();

                if (result != 0)
                {
                    return addressModel;
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

        public AddressModel GetAddress(string email, int Address_Type)
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

                AddressModel addressModelobj = new AddressModel();
                SqlCommand cmd1 = new SqlCommand("sp_GetAddress", connection);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Address_Type",Address_Type);
                cmd1.Parameters.AddWithValue("@UserId", userid);
                SqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    addressModelobj.Address = reader.GetValue(1).ToString();
                    addressModelobj.City = reader.GetValue(2).ToString();
                    addressModelobj.State = reader.GetValue(3).ToString();
                }
                if (addressModelobj != null)
                {
                    return addressModelobj;
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
