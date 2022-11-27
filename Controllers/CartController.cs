using BusinessLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartBL cartBL;
        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;
        }

        [HttpPost("AddCart")]
        public IActionResult AddCart(Cartmodel cartmodel)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var userdata = cartBL.AddCart(email,cartmodel);
                if (userdata != null)
                {
                    return this.Ok(new { success = true, message = "Cart Add Successfull", data = userdata });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Cart add failed" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("UpdateCart")]
        public IActionResult AddCart(long CartId,Cartmodel cartmodel)
        {
            try
            {
                var userdata = cartBL.UpdateCart(CartId, cartmodel);
                if (userdata != null)
                {
                    return this.Ok(new { success = true, message = "Cart Update Successfull", data = userdata });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Cart Update failed" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteCart")]
        public IActionResult DeleteCart(long CartId)
        {
            try
            {
                var userdata = cartBL.DeleteCart(CartId);
                if (userdata != null)
                {
                    return this.Ok(new { success = true, message = "Cart Delete Successfull"});
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Cart Delete failed" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }


}
