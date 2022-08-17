using Microsoft.AspNetCore.Mvc;
using Models.Interfaces;
using Services.Crud;
using WebAPI.Utils;

namespace WebAPI.Controllers.Rest;

public abstract class RestControllerBase<TEntity> : Controller
    where TEntity : IIdentifiable
{
    private readonly ICrudService<TEntity> _entityCrudService;

    protected RestControllerBase(ICrudService<TEntity> entityCrudService)
    {
        _entityCrudService = entityCrudService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return Json(await _entityCrudService.ReadAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var entity = await _entityCrudService.ReadAsync(id);
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
    public async Task<IActionResult> Add([FromBody] TEntity entity)
    {
        var newEntity = await _entityCrudService.CreateAsync(id => entity.AttachId(id));
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
    public async Task<IActionResult> Update(Guid id, [FromBody] TEntity entity)
    {
        try
        {
            var updatedEntity = await _entityCrudService.UpdateAsync(entity.AttachId(id));
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
    public async Task<IActionResult> Delete(Guid id)
    {
        var entity = await _entityCrudService.DeleteAsync(id);
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