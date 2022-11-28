using BookStore.BusinessLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackBL feedbackBL;
        
        public FeedbackController(IFeedbackBL feedbackBL)
        {
            this.feedbackBL = feedbackBL;
        }

        [Authorize]
        [HttpPost("AddFeedback")]
        public IActionResult AddFeedback(Feedmodel feed)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = feedbackBL.AddFeedback(email,feed);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "FeedBack added Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Feedback added UnSuccessfull" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        [HttpGet("GetAllFeedBack")]
        public async Task<IActionResult> GetAllFeedback(long BookId)
        {
            try
            {
                var result = feedbackBL.GetAllFeedback(BookId);
                if (result != null)
                {
                    return (this.Ok(new { success = true, message = "Feedback fetch Successfull", data = result }));
                }
                else
                {
                    return (this.BadRequest(new { success = false, message = "Feedback fetch UnSuccessfull" }));
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
