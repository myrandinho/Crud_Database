

using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class AdressService
{
    private readonly AdressRepository _adressRepository;

    public AdressService(AdressRepository adressRepository)
    {
        _adressRepository = adressRepository;
    }


    public AdressEntity CreateAdress(string streetName, string postalCode, string city)
    {
        try
        {
            var adressEntity = _adressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            adressEntity ??= _adressRepository.Create(new AdressEntity { StreetName = streetName, PostalCode = postalCode, City = city });

            if (adressEntity != null)
            {
                
                return adressEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;



    }

    public AdressEntity GetAdress(string streetName, string postalCode, string city)
    {
        try
        {
            var adressEntity = _adressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            if (adressEntity != null)
            {
                return adressEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    public AdressEntity GetAdressById(int id)
    {
        try
        {
            var adressEntity = _adressRepository.Get(x => x.Id == id);
            if (adressEntity != null)
            {
                return adressEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    public IEnumerable<AdressEntity> GetAdresses()
    {
        try
        {
            var adresses = _adressRepository.GetAll();
            if (adresses != null)
            {
                return adresses;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    public AdressEntity UpdateAdress(AdressEntity adressEntity)
    {
        try
        {
            var updatedAdressEntity = _adressRepository.Update(x => x.Id == adressEntity.Id, adressEntity);
            if (updatedAdressEntity != null)
            {
                return updatedAdressEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    public bool DeleteAdress(int id)
    {
        try
        {
            if (id != 0)
            {
                _adressRepository.Delete(x => x.Id == id);
                return true;
            }
              
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }
}
