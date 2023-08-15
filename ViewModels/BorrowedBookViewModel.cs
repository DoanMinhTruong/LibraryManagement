using LibraryManagement.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LibraryManagement.ViewModels
{
    public class BorrowedBookViewModel
    {
       
        [Required(ErrorMessage = "BookId is required")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "BorrowDate is required")]
        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; }

        [Required(ErrorMessage = "ReturnDate is required")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ActualReturnDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public byte Status { get; set; } = 0;
    }
}
