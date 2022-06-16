using Database;
using Microsoft.EntityFrameworkCore;
using Models.LiveEntities;

namespace Services.Crud.Impls;

public class CreatureCustomCrudService: CrudServiceBase<Creature>, ICreatureCrudService
{
    private readonly CommonDbContext _dbContext;

    public CreatureCustomCrudService(CommonDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    protected override DbSet<Creature> GetDbSet(CommonDbContext dbContext)
    {
        return _dbContext.Creatures;
    }
    
    public override Creature? Delete(Guid id)
    {
        var creature = base.Delete(id);
        Console.WriteLine($"creature {id} deleted");
        return creature;
    }
}