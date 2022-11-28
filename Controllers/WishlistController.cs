using BookStore.BusinessLayer.Interface;
using BookStore.BusinessLayer.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistBL wishlistBL;
        public WishlistController(IWishlistBL wishlistBL)
        {
            this.wishlistBL = wishlistBL;
        }

        [Authorize]
        [HttpPost("AddItem")]

        public IActionResult AddItem(long BookId)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = wishlistBL.AddItem(email,BookId);
                if (result)
                {
                    return this.Ok(new { success = true, message = "Item added Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Item added UnSuccessfull" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("DeleteItem")]

        public IActionResult DeleteItem(long WishlistId)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = wishlistBL.DeleteItem(email, WishlistId);
                if (result)
                {
                    return this.Ok(new { success = true, message = "Item deleted from Wishlist Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Item deletion from wishlist UnSuccessfull" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
