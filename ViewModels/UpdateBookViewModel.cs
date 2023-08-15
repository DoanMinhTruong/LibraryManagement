using LibraryManagement.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.ViewModels
{
    public class UpdateBookViewModel
    {
        [Required(ErrorMessage = "Can not determined book without Id")]
        public int BookId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? AuthorId { get; set; }
        public int? GenreId { get; set; }
        public DateTime? PublicationDate { get; set; }

    }

}
