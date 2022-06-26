using Microsoft.AspNetCore.Mvc;
using Models.LiveEntities;
using Services.Crud;

namespace WebAPI.Controllers.Rest.Impls;

[Route("/persons")]
public class PersonRestController : RestControllerBase<Person>
{
    public PersonRestController(ICrudService<Person> entityCrudService) : base(entityCrudService)
    {
    }
}