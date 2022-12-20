using Database;
using Microsoft.EntityFrameworkCore;
using Models.LiveEntities;

namespace Services.Crud.Impls;

public class NPCCrudService : CrudServiceBase<NonPlayerCharacter>
{
    public NPCCrudService(IRepository<NonPlayerCharacter> repository) : base(repository)
    {
    }
}