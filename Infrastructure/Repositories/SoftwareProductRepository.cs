

using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class SoftwareProductRepository : BaseRepository2<SoftwareProduct>
{
    private readonly DataContext2 _context2;


    public SoftwareProductRepository(DataContext2 context2) : base(context2)
    {
        _context2 = context2;
    }


    public override SoftwareProduct Get(Expression<Func<SoftwareProduct, bool>> expression)
    {
        var entity = _context2.SoftwareProducts
                .Include(i => i.Size)
                .FirstOrDefault(expression);
        return entity!;
    }

    public override IEnumerable<SoftwareProduct> GetAll()
    {
        return _context2.SoftwareProducts
               .Include(i => i.Size)
               .ToList();
    }
}


