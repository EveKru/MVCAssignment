using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels.Account
{
    public class AccountProfileModel
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? ProfileImage { get; set; }
    }
}
