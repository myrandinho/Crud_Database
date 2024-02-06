

using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

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
        try
        {
            var sizeEntity = _sizeRepository.Get(x => x.Quantity == quantity && x.Unit == unit);
            if (sizeEntity == null)
            {
                sizeEntity ??= _sizeRepository.Create(new Size { Quantity = quantity, Unit = unit });
            }

            return sizeEntity;

        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }


    public Size GetSizeById(int id)
    {
        try
        {
            var sizeEntity = _sizeRepository.Get(x => x.Id == id);
            if (sizeEntity != null)
            {
                return sizeEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public IEnumerable<Size> GetSizes()
    {
        try
        {
            var sizeEntities = _sizeRepository.GetAll();
            if (sizeEntities != null)
            {
                return sizeEntities;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public Size UpdateSize(Size sizeEntity)
    {
        try
        {
            var updatedSizeEntity = _sizeRepository.Update(x => x.Id == sizeEntity.Id, sizeEntity);
            if (updatedSizeEntity != null)
            {
                return updatedSizeEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public bool DeleteSize(int id)
    {
        try
        {
            if (id != 0)
            {
                _sizeRepository.Delete(x => x.Id == id);
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }
}
