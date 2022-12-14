using myPosGift.Core.Services.Constants;
using System.ComponentModel.DataAnnotations;

namespace myPosGift.Core.ViewModel.User
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [MinLength(ConstViewModel.MinUsernameLength, ErrorMessage = ConstViewModel.UsernameMinLengthErrorMessage)]
        [MaxLength(ConstViewModel.MaxUsernameLength, ErrorMessage = ConstViewModel.UsernameMaxLengthErrorMessage)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(ConstViewModel.MinPasswordLength, ErrorMessage = ConstViewModel.MinPasswordLengthErrorMessage)]
        [MaxLength(ConstViewModel.MaxPasswordLength, ErrorMessage = ConstViewModel.MaxPasswordLengthErrorMessage)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare(ConstViewModel.RegisterAccountCompare, ErrorMessage = ConstViewModel.ConfirmPasswordErrorMessage)]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MinLength(ConstViewModel.MinFirstNameLength, ErrorMessage = ConstViewModel.FirstNameMinLengthErrorMessage)]
        [MaxLength(ConstViewModel.MaxFirstNameLength, ErrorMessage = ConstViewModel.FirstNameMaxLengthErrorMessage)]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        [MinLength(ConstViewModel.MinLastNameLength, ErrorMessage = ConstViewModel.LastNameMinLengthErrorMessage)]
        [MaxLength(ConstViewModel.MaxLastNameLength, ErrorMessage = ConstViewModel.LastNameMaxLengthErrorMessage)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

    }
}
