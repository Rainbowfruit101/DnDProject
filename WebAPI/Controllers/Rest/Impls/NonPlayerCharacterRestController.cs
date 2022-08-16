using Microsoft.AspNetCore.Mvc;
using Models.LiveEntities;
using Services.Crud;

namespace WebAPI.Controllers.Rest.Impls;

[Route("/non-player-characters")]
public class NonPlayerCharacterRestController : RestControllerBase<NonPlayerCharacter>
{
    public NonPlayerCharacterRestController(ICrudService<NonPlayerCharacter> entityCrudService) : base(entityCrudService)
    {
    }
}