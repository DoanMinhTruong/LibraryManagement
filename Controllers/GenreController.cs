using LibraryManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService) { 
            _genreService = genreService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {

            var getAllGenres = await _genreService.GetAllGenres();
            return Ok(getAllGenres);    
        }
    }
}
