using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IFeedbackRL
    {
        public Feedmodel AddFeedback(string email, Feedmodel feed);
        public List<Feedmodel> GetAllFeedback(long BookId);
    }
}
