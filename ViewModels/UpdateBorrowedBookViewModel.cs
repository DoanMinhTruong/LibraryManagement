using LibraryManagement.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LibraryManagement.ViewModels
{
    public class UpdateBorrowedBookViewModel
    {
        [Required(ErrorMessage = "Can not determined borrowed book without Id")]
        public int BorrowedBookId { get; set; }

        public int? BookId { get; set; }

        public int? UserId { get; set; }
       
        public DateTime? BorrowDate { get; set; }
       
        public DateTime? ReturnDate { get; set; }
       
        public DateTime? ActualReturnDate { get; set; }
       
        public byte? Status { get; set; } = 0;
    }
}
