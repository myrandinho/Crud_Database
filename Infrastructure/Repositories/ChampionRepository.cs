

using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class ChampionRepository : BaseRepository<ChampionEntity>
{

    private readonly DataContext _context;

    public ChampionRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override ChampionEntity Get(Expression<Func<ChampionEntity, bool>> expression)
    {
        var entity = _context.Champions
            .Include(i => i.Team)
            .Include(i => i.League)
            .FirstOrDefault(expression);
        return entity!;
    }

    public override IEnumerable<ChampionEntity> GetAll()
    {
        return _context.Champions
            .Include(i => i.Team)
            .Include(i => i.League)
            .ToList();
    }
}


