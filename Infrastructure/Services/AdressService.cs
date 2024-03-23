using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class AdressService(AdressRepository repository)
{
    private readonly AdressRepository _adressRepository = repository;

    public async Task<AdressEntity> GetAdressAsync(string UserId)
    {
        try
        {
            var adressEntity = await _adressRepository.GetOneAsync(x => x.UserId == UserId);
            return adressEntity!;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

    public async Task<bool> CreateAdressAsync(AdressEntity adressEntity)
    {
        try
        {
            var adress = await _adressRepository.CreateOneAsync(adressEntity);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return false!;
    }

    public async Task<bool> UpdateAdressAsync(AdressEntity adressEntity)
    {
        try
        {
            var exists = await _adressRepository.UpdateOneAsync(x => x.UserId == adressEntity.UserId, adressEntity);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return false!;
    }

}
