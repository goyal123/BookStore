using BookStore.BusinessLayer.Interface;
using BusinessLayer.Service;
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
    public class AdminController : ControllerBase
    {
        private readonly IAdminBL adminBL;

        public AdminController(IAdminBL adminBL)
        {
            this.adminBL = adminBL;
        }

        [HttpPost("Login")]
        public IActionResult Login(Login login)
        {
            try
            {
                var userdata = adminBL.LoginAdmin(login);
                if (userdata != null)
                {
                    return this.Ok(new { success = true, message = "Admin Login Successfull", data = userdata });
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
                var result = adminBL.ForgetPassword(emailid);
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

        [Authorize(Roles = Role.Admin)]
        [HttpPost("ResetPassword")]

        public IActionResult ResetPassword(ResetPassword resetpass)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var admindata = adminBL.ResetPassAdmin(email, resetpass);
                if (admindata != null)
                {
                    return this.Ok(new { success = true, message = "Reset password Successfull"});
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
