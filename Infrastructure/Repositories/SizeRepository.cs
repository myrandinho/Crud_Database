

using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class SizeRepository : BaseRepository2<Size>
{
    public SizeRepository(DataContext2 context2) : base(context2)
    {
    }
}


