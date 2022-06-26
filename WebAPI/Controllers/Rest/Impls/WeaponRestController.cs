using Microsoft.AspNetCore.Mvc;
using Models.Items;
using Services.Crud;

namespace WebAPI.Controllers.Rest.Impls;

[Route("/weapons")]
public class WeaponRestController : RestControllerBase<Weapon>
{
    public WeaponRestController(ICrudService<Weapon> entityCrudService) : base(entityCrudService)
    {
    }
}