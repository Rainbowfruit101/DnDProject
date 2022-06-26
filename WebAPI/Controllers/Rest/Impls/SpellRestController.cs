using Microsoft.AspNetCore.Mvc;
using Models.Common;
using Services.Crud;

namespace WebAPI.Controllers.Rest.Impls;

[Route("/spells")]
public class SpellRestController : RestControllerBase<Spell>
{
    public SpellRestController(ICrudService<Spell> entityCrudService) : base(entityCrudService)
    {
    }
}