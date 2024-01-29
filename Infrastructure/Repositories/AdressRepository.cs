

using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class AdressRepository : BaseRepository<AdressEntity>
{
    public AdressRepository(DataContext context) : base(context)
    {
    }
}


