using LibraryManagement.Models;
using LibraryManagement.Repositories;

namespace LibraryManagement.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        
        public async Task<Author?> GetAuthorById(int id)
        {
            return await _authorRepository.GetById(id);
        }
        public async Task<IEnumerable<Author>?> GetAllAuthors()
        {
            return await _authorRepository.GetAll();
        }

    }
}
