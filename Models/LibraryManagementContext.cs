using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models
{
    public class LibraryManagementContext : DbContext
    {
        public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<WatchList>()
            //    .HasKey(w => new { w.UserId, w.StockId });
            //modelBuilder.Entity<Order>()
            //    .ToTable(table => table.HasTrigger("trigger_orders"));
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(); // Thêm dòng này để sử dụng Lazy Loading Proxies
                                                    // ...
        }

    }
}
