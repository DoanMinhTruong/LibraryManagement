using System;
using LibraryManagement.Models;
using LibraryManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly LibraryManagementContext _context;
        public GenreRepository(LibraryManagementContext context)
        {
            _context = context;
        }
        public async Task<Genre?> GetByName(string name)
        {
            return await _context.Genres.FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<Genre?> GetById(int id)
        {
            return await _context.Genres.FindAsync(id);
        }
        public async Task<IEnumerable<Genre>?> GetAll()
        {
            return await _context.Genres.ToListAsync();
        }


    }
}
