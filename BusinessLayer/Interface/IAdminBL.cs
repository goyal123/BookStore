using CommonLayer.Model;

namespace BookStore.BusinessLayer.Interface
{
    public interface IAdminBL
    {
        public string LoginAdmin(Login login);
        public string ForgetPassword(string email);
        public string ResetPassAdmin(string email, ResetPassword resetpass);
    }
}
