

using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class LeagueRepository : BaseRepository<LeagueEntity>
{
    public LeagueRepository(DataContext context) : base(context)
    {
    }
}


