using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace LibraryManagement.Models
{
    [Table("books")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("book_id")]
        public int BookId { get; set; }

        [Required(ErrorMessage="Book Title is required")]
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Book Author is required")]
        [Column("author_id")]
        public int AuthorId { get; set; }
        public virtual Author? Author { get; set; }

        [Required(ErrorMessage = "Book Genre is required")]
        [Column("genre_id")]
        public int GenreId { get; set; }
        public virtual Genre? Genre { get; set; }

        [Column("publication_date")]
        public DateTime PublicationDate { get; set; }
    }
}
