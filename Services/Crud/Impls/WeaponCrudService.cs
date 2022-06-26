using Database;
using Microsoft.EntityFrameworkCore;
using Models.Items;
using Models.LiveEntities;

namespace Services.Crud.Impls;

public class WeaponCrudService : CrudServiceBase<Weapon>
{
    private readonly CommonDbContext _dbContext;

    public WeaponCrudService(CommonDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    protected override DbSet<Weapon> GetDbSet(CommonDbContext dbContext)
    {
        return _dbContext.Weapons;
    }
}