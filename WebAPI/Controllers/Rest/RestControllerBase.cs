using Microsoft.AspNetCore.Mvc;
using Models.Interfaces;
using Services.Crud;
using WebAPI.Utils;

namespace WebAPI.Controllers.Rest;

public abstract class RestControllerBase<TEntity> : Controller
    where TEntity : IIdentifiable
{
    private readonly ICrudService<TEntity> _entityCrudService;

    public RestControllerBase(ICrudService<TEntity> entityCrudService)
    {
        _entityCrudService = entityCrudService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return Json(_entityCrudService.ReadAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        var entity = _entityCrudService.Read(id);
        if (entity == null)
        {
            return NotFound(new
            {
                errorText = $"Entity with id {id} not found."
            });
        }

        return Json(entity);
    }

    [HttpPost]
    public IActionResult Add([FromBody] TEntity entity)
    {
        var newEntity = _entityCrudService.Create(id => entity.AttachId(id));
        if (newEntity == null)
        {
            return BadRequest(new
            {
                errorText = "Can not create new entity."
            });
        }

        return Json(newEntity);
    }

    [HttpPatch("{id}")]
    public IActionResult Update(Guid id, [FromBody] TEntity entity)
    {
        try
        {
            var updatedEntity = _entityCrudService.Update(entity.AttachId(id));
            return Json(updatedEntity);
        }
        catch (Exception e)
        {
            return BadRequest(new
            {
                errorText = e.Message
            });
        }

    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var entity = _entityCrudService.Delete(id);
        if (entity == null)
        {
            return NotFound(new
            {
                errorText = $"Entity with id {id} not found."
            });
        }

        return Json(entity);
    }
}