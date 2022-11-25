using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IAdminRL
    {
        public string LoginAdmin(Login login);
        public string ForgetPassword(string email);
        public string ResetPassAdmin(string email, ResetPassword resetpass);
    }
}
