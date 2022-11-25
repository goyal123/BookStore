using BookStore.CommonLayer.Model;
using CommonLayer.Model;

namespace BookStore.BusinessLayer.Interface
{
    public interface IUserBL
    {
        public Register UserRegistration(Register registration);
        public string LoginUser(Login login);
        public string ForgetPassword(string email);
        public string ResetPassUser(string email, ResetPassword resetpass);

    }
}
