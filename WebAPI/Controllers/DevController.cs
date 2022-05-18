using Database;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.LiveEntities;

namespace WebAPI.Controllers;

[Route("/dev")]
public class DevController : Controller
{
    private readonly LiveEntitiesDbContext _dbContext;

    public DevController(LiveEntitiesDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpGet("/create-db")]
    public IActionResult CreateDb()
    {
        string resultText;
        try
        {
            _dbContext.Database.EnsureCreated();
            
            _dbContext.Classes.RemoveAll();
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
}