//using Infrastructure.Entities;
//using Infrastructure.Repositories;
//using System.Diagnostics;
//using Infrastructure.Models;
//using Infrastructure.Factories;
//using Infrastructure.Helpers;

//namespace Infrastructure.Services;

//public class UserService(UserRepository userRepository/*, AdressService adressService*/)
//{
//    private readonly UserRepository _userRepository = userRepository;
//    //private readonly AdressService _adressService = adressService;

//    public async Task<UserEntity> CreateUserAsync(SignUpModel model)
//    {
//        try
//        {
//            var userEntity = await _userRepository.GetOneAsync(x => x.Email == model.Email);
//            if (userEntity == null)
//            {
//                await _userRepository.CreateOneAsync(UserFactory.Create(model));
//                return userEntity!;
//            }
//            else
//            {
//                return null!;
//            }    
//        }
//        catch (Exception ex) { Debug.WriteLine(ex); }
//        return null!;
//    }
               
               

//    public async Task<UserEntity> SignInUserAsync(SignInModel model)
//    {
//        try
//        {
//            var user = await _userRepository.GetOneAsync(x => x.Email == model.Email);
//            if (user != null)
//            {
//                //var userEntity = user;
//                //if (PasswordHasher.ValidateSecurePassword(model.Password, userEntity.SecurityKey, userEntity.Password))
//                //{
//                //    return userEntity;
//                //} 
//            }
//            return null!;
//        }
//        catch (Exception ex) { Debug.WriteLine(ex); }
//        return null!;
//    } 
//}
