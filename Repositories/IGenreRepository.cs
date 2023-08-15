using LibraryManagement.Models;
using LibraryManagement.ViewModels;

namespace LibraryManagement.Repositories
{
    public interface IGenreRepository
    {
        Task<Genre?> GetByName(string name);
        Task<Genre?> GetById(int id);
        Task<IEnumerable<Genre>?> GetAll();   
    }
}
