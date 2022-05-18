using Database;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.LiveEntities;

namespace WebAPI.Controllers;

[Route("/api")]
public class TestController : Controller
{
    private readonly DnDDatabaseContext _dbContext;

    public TestController(DnDDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpGet("/create")]
    public IActionResult CreateDb()
    {
        var resultText = "none";
        try
        {
            _dbContext.Database.EnsureCreated();
            foreach (LiveEntityClass.ClassType classType in Enum.GetValues(typeof(LiveEntityClass.ClassType)))
            {
                _dbContext.Classes.Add(new LiveEntityClass()
                {
                    Id = Guid.NewGuid(),
                    Name = classType.ToString(),
                    EClassType = classType
                });
            }

            _dbContext.SaveChanges();

            resultText = "ok";
        }
        catch (Exception e)
        {
            resultText = e.Message;
        }
        
        return Json(new {result = resultText});
    }

    [HttpGet("/class/search")]
    public IActionResult ClassSearch(LiveEntityClass.ClassType type)
    {
        try
        {
            var leClass = _dbContext.FindByType(type);
            if (leClass == null)
                throw new Exception("NotFound");

            return Json(leClass);
        }
        catch (Exception e)
        {
            return NotFound(new {result = e.Message});
        }
    }
}