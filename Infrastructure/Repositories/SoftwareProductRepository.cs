

using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class SoftwareProductRepository : BaseRepository<SoftwareProduct>
{
    private readonly DataContext _context;


    public SoftwareProductRepository(DataContext context) : base(context)
    {
        _context = context;
    }


    public override SoftwareProduct Get(Expression<Func<SoftwareProduct, bool>> expression)
    {
        var entity = _context.SoftwareProducts
                .Include(i => i.Size)
                .FirstOrDefault(expression);
        return entity!;
    }

    public override IEnumerable<SoftwareProduct> GetAll()
    {
        return _context.SoftwareProducts
               .Include(i => i.Size)
               .ToList();
    }
}


