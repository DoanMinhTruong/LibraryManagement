using System;
using LibraryManagement.Models;
using LibraryManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryManagementContext _context;
        public AuthorRepository(LibraryManagementContext context)
        {
            _context = context;
        }

        public async Task<Author?> GetById(int id)
        {
            return await _context.Authors.FindAsync(id);
        }
        public async Task<IEnumerable<Author>?> GetAll()
        {
            return await _context.Authors.ToListAsync();
        }


    }
}
