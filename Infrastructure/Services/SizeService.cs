

using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class SizeService
{
    private readonly SizeRepository _sizeRepository;

    public SizeService(SizeRepository sizeRepository)
    {
        _sizeRepository = sizeRepository;
    }




    public Size CreateSize(int quantity, string unit)
    {
        var sizeEntity = _sizeRepository.Get(x => x.Quantity == quantity && x.Unit == unit);
        sizeEntity ??= _sizeRepository.Create(new Size { Quantity = quantity, Unit = unit });

        return sizeEntity;

    }


    public Size GetSizeById(int id)
    {
        var sizeEntity = _sizeRepository.Get(x => x.Id == id);
        return sizeEntity;
    }

    public IEnumerable<Size> GetSizes()
    {
        var sizeEntities = _sizeRepository.GetAll();
        return sizeEntities;
    }

    public Size UpdateSize(Size sizeEntity)
    {
        var updatedSizeEntity = _sizeRepository.Update(x => x.Id == sizeEntity.Id, sizeEntity);
        return updatedSizeEntity;
    }

    public void DeleteSize(int id)
    {
        _sizeRepository.Delete(x => x.Id == id);
    }
}
