using BookStore.BusinessLayer.Interface;
using BookStore.CommonLayer.Model;
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
    public class AddressController : ControllerBase
    {
        private readonly IAddressBL addressBL;
        public AddressController(IAddressBL addressBL)
        {
            this.addressBL = addressBL;
        }

        [Authorize]
        [HttpPost("CreateAddress")]

        public IActionResult CreateAddress(long Address_Type,AddressModel addressModel)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var userdata=addressBL.CreateAddress(email, Address_Type, addressModel);
                if (userdata!=null)
                {
                    return this.Ok(new { success = true, message = "Address Addedd Successfully",data=userdata });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Address Add failed" });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [Authorize]
        [HttpPut("UpdateAddress")]

        public IActionResult UpdateAddress(long Address_Type,AddressModel addressModel)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var userdata = addressBL.UpdateAddress(email,Address_Type,addressModel);
                if (userdata != null)
                {
                    return this.Ok(new { success = true, message = "Address Updated Successfully", data = userdata });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Address Update failed" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetAddress")]
        public IActionResult GetAddress(int Address_Type)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var userdata = addressBL.GetAddress(email,Address_Type);
                if(userdata!=null)
                {
                    return this.Ok(new { success = true, message = "Address Fetch Successfully", data = userdata });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Address Fetch failed" });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
