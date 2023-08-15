using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public interface IGenreService
    {
        Task<Genre?> GetGenreByName(string name);
        Task<Genre?> GetGenreById(int id);
        Task<IEnumerable<Genre>?> GetAllGenres();
    }
}
