using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class SubscriberService(SubscriberRepository subscriberRepository)
{
    private readonly SubscriberRepository _subscriberRepository = subscriberRepository;

    public async Task<SubscriberEntity> GetSubscriberByEmailAsync(string email)
    {
        try
        {
            var subscriberEntity = await _subscriberRepository.GetOneAsync(x => x.Email == email);
            return subscriberEntity!;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

    public async Task<bool> CreateSubscriberAsync(SubscriberEntity subscriber)
    {
        try
        {
            var adress = await _subscriberRepository.CreateOneAsync(subscriber);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return false!;
    }

    public async Task<bool> DeleteSubscriberByEmailAsync(string email)
    {
        try
        {
            var subscriberEntity = await _subscriberRepository.DeleteOneAsync(x => x.Email == email);
            return true!;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return false!;
    }
}
