using Database;
using Microsoft.EntityFrameworkCore;
using Models.Items;
using Models.LiveEntities;

namespace Services.Crud.Impls;

public class WeaponCrudService : CrudServiceBase<Weapon>
{
    public WeaponCrudService(IRepository<Weapon> repository) : base(repository)
    {
    }
}