using Database;
using Microsoft.EntityFrameworkCore;
using Models.Items;
using Models.LiveEntities;

namespace Services.Crud.Impls;

public class ItemCrudService : CrudServiceBase<Item>
{
    public ItemCrudService(IRepository<Item> repository) : base(repository)
    {
    }
}