using System.ComponentModel.DataAnnotations;
using WebApp.Helpers;

namespace WebApp.Models;

public class SignUpModel
{
    [DataType(DataType.Text)]
    [Display(Name = "First name", Prompt = "Enter your first name")]
    [Required(ErrorMessage = "Enter a first name")]
    public string FirstName { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Last name", Prompt = "Enter your last name")]
    [Required(ErrorMessage = "Enter a last name")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email adress", Prompt = "Enter your email adress")]
    [Required(ErrorMessage = "Enter a valid email adress")]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password)] 
    [Display(Name = "Password", Prompt = "Enter your password")]
    [Required(ErrorMessage = "Enter a valid password")]
    public string Password { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password", Prompt = "Confirm your password")]
    [Compare(nameof(Password), ErrorMessage = "Does not match")]
    [Required(ErrorMessage = "Not confirmed")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "I agree to the terms & conditions")]
    [CheckBoxRequired(ErrorMessage = "You must accept the terms and conditions")]
    public bool TermsAndConditions { get; set; } = false;

}
