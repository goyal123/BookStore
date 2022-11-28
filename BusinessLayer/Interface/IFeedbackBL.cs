using CommonLayer.Model;
using System.Collections.Generic;

namespace BookStore.BusinessLayer.Interface
{
    public interface IFeedbackBL
    {
        public Feedmodel AddFeedback(string email, Feedmodel feed);
        public List<Feedmodel> GetAllFeedback(long BookId);
    }
}
