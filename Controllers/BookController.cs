using BusinessLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBL bookBL;

        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost("AddBook")]
        public IActionResult AddBook(Book bookmodel)
        {
            try
            {
                var result = bookBL.AddBook(bookmodel);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Book Added Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Book Add UnSuccessfull" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost("UpdateBook")]
        public IActionResult UpdateBook(int BookId,Book bookmodel)
        {
            try
            {
                var result = bookBL.UpdateBook(BookId,bookmodel);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Book Updated Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Book Update UnSuccessfull" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [Authorize]
        [HttpGet("GetAllBooks")]

        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var result = bookBL.GetAllBooks();
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Book Updated Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Book Update UnSuccessfull" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [Authorize]
        [HttpGet("GetBookByid")]

        public IActionResult GetBookById(long BookId)
        {
            try
            {
                var result = bookBL.GetBookById(BookId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Book Fetch Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Book Fetch UnSuccessfull" });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("DeleteBook")]

        public IActionResult DeleteBook(int BookId)
        {
            try
            {
                var result = bookBL.DeleteBook(BookId);
                if (result)
                {
                    return this.Ok(new { success = true, message = "Book Deleted Successfull"});
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Book Delete UnSuccessfull" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
