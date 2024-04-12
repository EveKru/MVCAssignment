using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    [ProtectedPersonalData] // nödvändigt??
    public string? Bio { get; set; }

    [ProtectedPersonalData]
    public string? ProfileImage { get; set; } = "avatar.jpg";

    public DateTime? Created { get; set; }
    public DateTime? Modified { get; set; }

    public ICollection<AdressEntity>? Adresses { get; set; } = [];
}
