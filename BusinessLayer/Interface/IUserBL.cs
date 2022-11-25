using BookStore.CommonLayer.Model;

namespace BookStore.BusinessLayer.Interface
{
    public interface IUserBL
    {
        public Register UserRegistration(Register registration);
    }
}
