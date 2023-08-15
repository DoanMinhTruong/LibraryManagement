using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace LibraryManagement.Models
{
    [Table("borrowed_books")]
    public class BorrowedBook 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("borrow_id")]
        public int BorrowId { get; set; }

        [Column("book_id")]
        [Required(ErrorMessage = "BookId is required")]
        public int BookId { get; set; }
        public virtual Book? Book { get; set; }

        [Column("user_id")]
        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        [Column("borrow_date")]
        [Required(ErrorMessage = "BorrowDate is required")]
        [CustomValidation(typeof(Book), "ValidateBorrowDate")]
        public DateTime BorrowDate { get; set; }

        [Column("return_date")]
        [Required(ErrorMessage = "ReturnDate is required")]
        [CustomValidation(typeof(Book), "ValidateReturnDate")]
        public DateTime ReturnDate { get; set; }

        [Column("actual_return_date")]
        [CustomValidation(typeof(Book), "ValidateActualReturnDate")]
        public DateTime ActualReturnDate { get; set; }

        [Column("status")]
        [Required(ErrorMessage = "Status is required")]
        [Range(0, 1, ErrorMessage = "Gender must be between 0 and 1 ('Borrow - Return')")]
        public byte Status { get; set; }

        

    }
}
