using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.ViewModels
{
    public class RegisterViewModel
    {
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "You must enter your phone")]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = "";

        public string? FullName { get; set; }

        [Required(ErrorMessage = "You must enter your date of birth")]
        public DateTime? DateOfBirth { get; set; }

        public byte? Gender { get; set; }

        
    }
}
