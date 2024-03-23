using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels.Authentication;

public class SignInModel
{
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email adress", Prompt = "Enter your email adress")]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter your password")]
    public string Password { get; set; } = null!;

    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; }

    public string? ErrorMessage { get; set; }
}
