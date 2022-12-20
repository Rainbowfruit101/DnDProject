using Database;
using Microsoft.EntityFrameworkCore;
using Models.LiveEntities;

namespace Services.Crud.Impls;

public class PersonCrudService : CrudServiceBase<Person>
{
    public PersonCrudService(IRepository<Person> repository) : base(repository)
    {
    }
}