using LibraryManagement.Attributes;
using LibraryManagement.Extensions;
using LibraryManagement.Services;
using LibraryManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        public BookController(IBookService bookService, IUserService userService)
        {
            _bookService = bookService;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {  
            var books = await _bookService.GetAllBooks(); 
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetBookById(id);
            return Ok(book);
        }
        [HttpGet("genre/{genreId}")]
        public async Task<IActionResult> GetBooksByGenre(int genreId)
        {
            var books = await _bookService.GetBooksByGenre(genreId);
            return Ok(books);
        }
        [HttpGet("author/{authorId}")]
        public async Task<IActionResult> GetBooksByAuthor(int authorId)
        {
            var books = await _bookService.GetBooksByGenre(authorId);
            return Ok(books);
        }

        [HttpPost]
        [JwtAuthorize]
        public async Task<IActionResult> CreateBook(BookViewModel bookViewModel)
        {
            int userId = HttpContext.GetUserId();
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound("Invalid User.");
            }
            if (user.Role == 2)
            {
                return Unauthorized("Permission Denied.");
            }
            try
            {
                var createdBook = await _bookService.CreateBook(bookViewModel);
                return Ok(createdBook);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            
        }
        [HttpPut]
        [JwtAuthorize]
        public async Task<IActionResult> UpdateBook(UpdateBookViewModel updateBookViewModel)
        {
            int userId = HttpContext.GetUserId();
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound("Invalid User.");
            }
            if (user.Role == 2)
            {
                return Unauthorized("Permission Denied.");
            }
            try
            {
                //Dang fix dong` nay
                var res = await _bookService.UpdateBook(updateBookViewModel);
                if (res == null) return NotFound();
                return Ok(new { res });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        [JwtAuthorize]
        public async Task<IActionResult> DeleteBook(int id)
        {
            int userId = HttpContext.GetUserId();
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound("Invalid User.");
            }
            if (user.Role == 2)
            {
                return Unauthorized("Permission Denied.");
            }
            try
            {
                //Dang fix dong` nay
                var res = await _bookService.DeleteBook(id);
                return Ok(new { Message = res });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
