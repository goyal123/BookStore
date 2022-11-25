using System;
using System.Collections.Generic;
using System.Text;
using BookStore.BusinessLayer.Interface;
using BookStore.CommonLayer.Model;
using CommonLayer.Model;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class UserBL:IUserBL
    {
        private readonly IUserRL userRL;
        
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public Register UserRegistration(Register registration)
        {

            try
            {
                return userRL.UserRegistration(registration);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string LoginUser(Login login)
        {
            try
            {
                return userRL.LoginUser(login);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string ForgetPassword(string email)
        {
            try
            {
                return this.userRL.ForgetPassword(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string ResetPassUser(string email, ResetPassword resetpass)
        {
            try
            {
                return userRL.ResetPassUser(email, resetpass);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
