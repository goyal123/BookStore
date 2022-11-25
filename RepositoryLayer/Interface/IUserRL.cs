using BookStore.CommonLayer.Model;
using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public Register UserRegistration(Register registration);
        public string LoginUser(Login login);
        public string ForgetPassword(string email);
        public string ResetPassUser(string email, ResetPassword resetpass);

    }
}
