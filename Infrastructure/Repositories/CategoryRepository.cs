

using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class CategoryRepository : BaseRepository<CategoryEntity>
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}


