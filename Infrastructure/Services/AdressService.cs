//using Infrastructure.Entities;
//using Infrastructure.Repositories;
//using System.Diagnostics;
//using Infrastructure.Models;

//namespace Infrastructure.Services;

//public class AdressService(AdressRepository repository)
//{
    //    private readonly AdressRepository _adressRepository = repository;

    //    public async Task<AdressEntity> GetOrCreateAdressAsync()
    //    {
    //        try
    //        {
    //            var adressEntity = await _adressRepository.GetOneAsync(x => x.StreetName == adressModel.StreetName && x.City == adressModel.City && x.PostalCode == adressModel.PostalCode);
    //            adressEntity ??= await _adressRepository.CreateOneAsync(new AdressEntity { StreetName = adressModel.StreetName, PostalCode = adressModel.PostalCode, City = adressModel.City});
    //            return adressEntity!;
    //        }
    //        catch (Exception ex) { Debug.WriteLine(ex); }
    //        return null!;
    //    }
//}
