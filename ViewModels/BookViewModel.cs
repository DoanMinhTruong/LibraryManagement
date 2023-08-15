using LibraryManagement.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.ViewModels
{
    public class BookViewModel
    {
            [Required(ErrorMessage = "Book Title is required")]
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            
            [Required(ErrorMessage = "Book Author is required")]
            public int AuthorId { get; set; }

            [Required(ErrorMessage = "Book Genre is required")]
            public int GenreId { get; set; }
            
            public DateTime PublicationDate { get; set; }
        
    }

}
