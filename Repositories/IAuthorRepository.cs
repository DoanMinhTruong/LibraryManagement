using LibraryManagement.Models;
using LibraryManagement.ViewModels;

namespace LibraryManagement.Repositories
{
    public interface IAuthorRepository
    {
        
        Task<Author?> GetById(int id);
        Task<IEnumerable<Author>?> GetAll();
    }
}
