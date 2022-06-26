using Microsoft.AspNetCore.Mvc;
using Models.LiveEntities;
using Services.Crud;

namespace WebAPI.Controllers.Rest.Impls;

[Route("/non-player-characters")]
public class NPCRestController : RestControllerBase<NonPlayerCharacter>
{
    public NPCRestController(ICrudService<NonPlayerCharacter> entityCrudService) : base(entityCrudService)
    {
    }
}