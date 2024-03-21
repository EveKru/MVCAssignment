using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class AdressEntity
{
    public string UserId { get; set; } = null!;
    public UserEntity User { get; set; } = null!;

    [Key]
    public int Id { get; set; } 
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!; 
}
