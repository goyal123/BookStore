using BookStore.BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;

namespace BookStore.BusinessLayer.Service
{
    public class FeedbackBL:IFeedbackBL
    {
        private readonly IFeedbackRL feedbackRL;
        public FeedbackBL(IFeedbackRL feedbackRL)
        {
            this.feedbackRL = feedbackRL;
        }

        public Feedmodel AddFeedback(string email,Feedmodel feed)
        {
            try
            {
                return feedbackRL.AddFeedback(email, feed);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Feedmodel> GetAllFeedback(long BookId)
        {
            try
            {
                return feedbackRL.GetAllFeedback(BookId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
