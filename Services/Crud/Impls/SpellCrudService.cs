using Database;
using Microsoft.EntityFrameworkCore;
using Models.Common;

namespace Services.Crud.Impls;

public class SpellCrudService : CrudServiceBase<Spell>
{
    public SpellCrudService(IRepository<Spell> repository) : base(repository)
    {
    }
}