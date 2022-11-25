using BookStore.BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using RepositoryLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Service;

namespace BusinessLayer.Service
{
    public class AdminBL:IAdminBL
    {
        private readonly IAdminRL adminRL;
        public AdminBL(IAdminRL adminRL)
        {
            this.adminRL = adminRL;
        }
        public string LoginAdmin(Login login)
        {
            try
            {
                return adminRL.LoginAdmin(login);
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
                return this.adminRL.ForgetPassword(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string ResetPassAdmin(string email, ResetPassword resetpass)
        {
            try
            {
                return adminRL.ResetPassAdmin(email, resetpass);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
