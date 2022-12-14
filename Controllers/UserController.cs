using BookStore.BusinessLayer.Interface;
using BookStore.CommonLayer.Model;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        
        [HttpPost("Register")]

        public IActionResult Registration(Register registration)
        {
            try
            {
                var result = userBL.UserRegistration(registration);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "User Registration Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "User Registration UnSuccessfull" });
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(Login login)
        {
            try
            {
                var userdata = userBL.LoginUser(login);
                if (userdata != null)
                {
                    return this.Ok(new { success = true, message = "User Login Successfull", data = userdata });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Invalid Credentials" });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPost("ForgotPassword")]
        public IActionResult forgotpassword(string emailid)
        {
            try
            {
                var result = userBL.ForgetPassword(emailid);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Password reset link send Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "User not registered" });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        [Authorize(Roles =Role.User)]
        [HttpPost("ResetPassword")]

        public IActionResult ResetPassword(ResetPassword resetpass)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var userdata = userBL.ResetPassUser(email, resetpass);

                if (userdata != null)
                {
                    return this.Ok(new { success = true, message = "Reset password Successfull", data = userdata });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Reset Password failed" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
