using Database;
using Models.LiveEntities;

namespace Services.Crud.Impls;

public class CreatureCrudService : CrudServiceBase<Creature>
{
    public CreatureCrudService(IRepository<Creature> repository) : base(repository)
    {
    }
}