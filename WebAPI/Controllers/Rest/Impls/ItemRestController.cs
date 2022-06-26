using Microsoft.AspNetCore.Mvc;
using Models.Items;
using Services.Crud;

namespace WebAPI.Controllers.Rest.Impls;

[Route("/items")]
public class ItemRestController : RestControllerBase<Item>
{
    public ItemRestController(ICrudService<Item> entityCrudService) : base(entityCrudService)
    {
    }
}