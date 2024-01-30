

using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class SizeRepository : BaseRepository<Size>
{
    public SizeRepository(DataContext context) : base(context)
    {
    }
}


