using Database;
using Microsoft.EntityFrameworkCore;
using Models.LiveEntities;

namespace Services.Crud.Impls;

public class NPCCrudService : CrudServiceBase<NonPlayerCharacter>
{
    private readonly CommonDbContext _dbContext;

    public NPCCrudService(CommonDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    protected override DbSet<NonPlayerCharacter> GetDbSet(CommonDbContext dbContext)
    {
        return _dbContext.NonPlayerCharacters;
    }
}