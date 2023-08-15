using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public interface IAuthorService
    {
        Task<Author?> GetAuthorById(int id);
        Task<IEnumerable<Author>?> GetAllAuthors();
    }
}


