using BookStore.BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpPost("AddOrder")]
        public IActionResult AddOrder(long CartId)
        {
            try
            {
                var userdata = orderBL.AddOrder(CartId);
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

    }
}
