using LibraryManagement.Models;
using LibraryManagement.Repositories;

namespace LibraryManagement.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<Genre?> GetGenreByName(string name)
        {
            return await _genreRepository.GetByName(name);
        }
        public async Task<Genre?> GetGenreById(int id)
        {
            return await _genreRepository.GetById(id);
        }
        public async Task<IEnumerable<Genre>?> GetAllGenres()
        {
            return await _genreRepository.GetAll();
        }

    }
}
