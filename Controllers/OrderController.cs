using BookStore.BusinessLayer.Interface;
using BusinessLayer.Service;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderBL orderBL;
        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }
        [Authorize]
        [HttpPost("AddOrder")]
        public IActionResult AddOrder(long CartId)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var userdata = orderBL.AddOrder(email,CartId);
                if (userdata)
                {
                    return this.Ok(new { success = true, message = "Order Placed Successfully" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Order Place failed" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("DeleteOrder")]
        public IActionResult DeleteOrder(long OrderId)
        {
            try
            {
                var userdata = orderBL.DeleteOrder(OrderId);
                if (userdata)
                {
                    return this.Ok(new { success = true, message = "Order Cancelled Successfully" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Order Cancellation failed" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetAllOrders")]

        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = orderBL.GetAllOrders(email);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Fetch Orders Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Fetch UnSuccessfull" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
