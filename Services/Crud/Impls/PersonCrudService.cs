using Database;
using Microsoft.EntityFrameworkCore;
using Models.LiveEntities;

namespace Services.Crud.Impls;

public class PersonCrudService  : CrudServiceBase<Person>
{
    private readonly CommonDbContext _dbContext;

    public PersonCrudService(CommonDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    protected override DbSet<Person> GetDbSet(CommonDbContext dbContext)
    {
        return _dbContext.Persons;
    }
}