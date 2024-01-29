

using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class RoleRepository : BaseRepository<RoleEntity>
{
    public RoleRepository(DataContext context) : base(context)
    {
    }
}


