

using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class SoftwareProductService
{
    private readonly SoftwareProductRepository _softwareProductRepository;
    private readonly SizeService _sizeService;


    public SoftwareProductService(SoftwareProductRepository softwareProductRepository, SizeService sizeService)
    {
        _softwareProductRepository = softwareProductRepository;
        _sizeService = sizeService;

    }



    public SoftwareProduct CreateSoftwareProduct(string title, int quantity, string unit)
    {



        try
        {
            var sizeEntity = _sizeService.CreateSize(quantity, unit);

            var softwareProductEntity = new SoftwareProduct
            {
                Title = title,
                SizeId = sizeEntity.Id

            };

            softwareProductEntity = _softwareProductRepository.Create(softwareProductEntity);
            if (softwareProductEntity != null)
            {
                return softwareProductEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }



    public SoftwareProduct GetSoftwareProductById(int id)
    {
        try
        {
            var softwareProductEntity = _softwareProductRepository.Get(x => x.Id == id);
            if (softwareProductEntity != null)
            {
                return softwareProductEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public IEnumerable<SoftwareProduct> GetSoftwareProducts()
    {
        try
        {
            var softwareProduct = _softwareProductRepository.GetAll();
            if (softwareProduct != null)
            {
                return softwareProduct;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public SoftwareProduct UpdateSoftwareProduct(SoftwareProduct softwareProductEntity)
    {
        try
        {
            var updatedsoftwareProductEntity = _softwareProductRepository.Update(x => x.Id == softwareProductEntity.Id, softwareProductEntity);
            if (updatedsoftwareProductEntity != null)
            {
                return updatedsoftwareProductEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public bool DeleteSoftwareProduct(int id)
    {
        try
        {
            if (id != 0)
            {
                _softwareProductRepository.Delete(x => x.Id == id);
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }
}
