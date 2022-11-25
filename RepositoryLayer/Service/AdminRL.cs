using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Service
{
    public class AdminRL:IAdminRL
    {
        private readonly string Connectionstring;
        public AdminRL(IConfiguration configuration)
        {
            Connectionstring = configuration.GetConnectionString("BookStoreDB");
        }
        public string LoginAdmin(Login login)
        {
            string Connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

            SqlConnection connection = new SqlConnection(Connectionstring);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_LoginAdmin", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", login.Email);
                cmd.Parameters.AddWithValue("@Password", login.Password);
                connection.Open();
                var result = cmd.ExecuteScalar();
                connection.Close();
                if (result != null)
                {
                    return GetJWTToken(login.Email, login.Password);
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

        public string ForgetPassword(string email)
        {
            string Connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            SqlConnection connection = new SqlConnection(Connectionstring);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_AdminCheck", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                connection.Open();
                var email_check = cmd.ExecuteScalar();
                if (email_check != null)
                {
                    SqlCommand cmd1 = new SqlCommand("sp_AdminIdcheck", connection);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@Email", email);
                    var adminid = cmd1.ExecuteScalar();
                    connection.Close();
                    var token = GetJWTToken(email_check.ToString(), adminid.ToString());
                    return token.ToString();
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

        public string ResetPassAdmin(string email, ResetPassword resetpass)
        {
            string Connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            SqlConnection connection = new SqlConnection(Connectionstring);

            try
            {
                if ((resetpass.Password).Equals(resetpass.confirmPassword))
                {
                    SqlCommand cmd = new SqlCommand("sp_ResetPassAdmin", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", resetpass.Password);
                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    connection.Close();

                    return ("Successfully Reset Password");
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

        private static string GetJWTToken(string email, string password)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("pintusharmaqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqweqwe");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role,"Admin"),
                    new Claim("email", email),
                    new Claim("password", password),
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
