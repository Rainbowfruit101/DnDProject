using Microsoft.AspNetCore.Mvc;
using Models.LiveEntities;
using Services.Crud;

namespace WebAPI.Controllers.Rest.Impls;

[Route("/creatures")]
public class CreatureRestController : RestControllerBase<Creature>
{
    public CreatureRestController(ICrudService<Creature> entityCrudService) : base(entityCrudService)
    {
    }
}