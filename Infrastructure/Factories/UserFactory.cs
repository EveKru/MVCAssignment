using Infrastructure.Entities;
using Infrastructure.Helpers;
using Infrastructure.Models;
using System.Diagnostics;

namespace Infrastructure.Factories;

public class UserFactory
{
    public static UserEntity Create(SignUpModel model)
    {
        try
        {
            var date = DateTime.Now;
            var (password, securityKey) = PasswordHasher.GenerateSecurePassword(model.Password);

            return new UserEntity
            {
                //Id = Guid.NewGuid().ToString(), (id is currently type int)
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = password,
                SecurityKey = securityKey,
                Created = date,
                Modified = date
            };
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }
}
