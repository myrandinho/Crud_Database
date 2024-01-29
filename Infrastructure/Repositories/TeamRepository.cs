

using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class TeamRepository : BaseRepository<TeamEntity>
{
    public TeamRepository(DataContext context) : base(context)
    {
    }
}


