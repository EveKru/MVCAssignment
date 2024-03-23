using Infrastructure.Entities;
using System.Diagnostics;
using WebApp.ViewModels.Authentication;

namespace Infrastructure.Factories;

public class UserFactory 
{ 
    public static UserEntity Create(SignUpModel model)
    {
        try
        {
            var date = DateTime.Now;

            var userEntity = new UserEntity
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Created = date,
                Modified = date,
                UserName = model.Email,
            };
            return userEntity;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }
}
