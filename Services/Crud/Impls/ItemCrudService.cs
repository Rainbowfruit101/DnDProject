using Database;
using Microsoft.EntityFrameworkCore;
using Models.Items;
using Models.LiveEntities;

namespace Services.Crud.Impls;

public class ItemCrudService : CrudServiceBase<Item>
{
    private readonly CommonDbContext _dbContext;

    public ItemCrudService(CommonDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    protected override DbSet<Item> GetDbSet(CommonDbContext dbContext)
    {
        return _dbContext.Items;
    }
}