

using Infrastructure.Entities;
using Infrastructure.Repositories;

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



        var sizeEntity = _sizeService.CreateSize(quantity, unit);

        var softwareProductEntity = new SoftwareProduct
        {
            Title = title,
            SizeId = sizeEntity.Id

        };

        softwareProductEntity = _softwareProductRepository.Create(softwareProductEntity);
        return softwareProductEntity;

    }





    public SoftwareProduct GetSoftwareProductById(int id)
    {
        var softwareProductEntity = _softwareProductRepository.Get(x => x.Id == id);
        return softwareProductEntity;
    }

    public IEnumerable<SoftwareProduct> GetSoftwareProducts()
    {
        var softwareProduct = _softwareProductRepository.GetAll();
        return softwareProduct;
    }

    public SoftwareProduct UpdateSoftwareProduct(SoftwareProduct softwareProductEntity)
    {
        var updatedsoftwareProductEntity = _softwareProductRepository.Update(x => x.Id == softwareProductEntity.Id, softwareProductEntity);
        return updatedsoftwareProductEntity;
    }

    public void DeleteSoftwareProduct(int id)
    {
        _softwareProductRepository.Delete(x => x.Id == id);
    }
}
