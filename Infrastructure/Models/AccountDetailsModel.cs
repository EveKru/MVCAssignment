using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class AccountDetailsModel
{
    [DataType(DataType.Text)]
    [Display(Name = "First name", Prompt = "Enter your first name")]
    [Required(ErrorMessage = "Required")]
    public string FirstName { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Last name", Prompt = "Enter your last name")]
    [Required(ErrorMessage = "Required")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter your email")]
    [Required(ErrorMessage = "Required")]
    public string Email { get; set; } = null!;

    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone number", Prompt = "Enter your phone number")]
    [Required(ErrorMessage = "Required")]
    public string Phone { get; set; } = null!;

    [Display(Name = "Bio", Prompt = "Add a short bio...")]
    [DataType(DataType.MultilineText)]
    public string? Bio { get; set; }

    [DataType(DataType.ImageUrl)]
    public string? ProfileImage { get; set; }
}
