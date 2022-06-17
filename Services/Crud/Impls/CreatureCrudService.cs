using Database;
using Microsoft.EntityFrameworkCore;
using Models.LiveEntities;

namespace Services.Crud.Impls;

public class CreatureCrudService : CrudServiceBase<Creature>
{
    private readonly CommonDbContext _dbContext;
    
    public CreatureCrudService(CommonDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    protected override DbSet<Creature> GetDbSet(CommonDbContext dbContext)
    {
        return _dbContext.Creatures;
    }
}