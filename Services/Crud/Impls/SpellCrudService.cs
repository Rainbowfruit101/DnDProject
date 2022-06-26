using Database;
using Microsoft.EntityFrameworkCore;
using Models.Common;

namespace Services.Crud.Impls;

public class SpellCrudService : CrudServiceBase<Spell>
{
    private readonly CommonDbContext _dbContext;

    public SpellCrudService(CommonDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    protected override DbSet<Spell> GetDbSet(CommonDbContext dbContext)
    {
        return _dbContext.Spells;
    }
}