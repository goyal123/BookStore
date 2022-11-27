using CommonLayer.Model;

namespace BookStore.BusinessLayer.Interface
{
    public interface IFeedbackBL
    {
        public Feedmodel AddFeedback(string email, Feedmodel feed);
    }
}
