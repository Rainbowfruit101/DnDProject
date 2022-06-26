using Database;
using Microsoft.AspNetCore.Mvc;
using Models.LiveEntities;
using Services.Filtration;

namespace WebAPI.Controllers;

[Route("/test")]
public class TestController : Controller
{
    private readonly CommonDbContext _commonDbContext;
    private readonly SearchByNameService _searchByNameService;


    public TestController(CommonDbContext commonDbContext, SearchByNameService searchByNameService)
    {
        _commonDbContext = commonDbContext;
        _searchByNameService = searchByNameService;
    }

    [HttpGet("/search-value")]
    public IActionResult SearchValue(string searchedValue)
    {
        var searchService = new SearchByNameServiceDecorator(_searchByNameService, searchedValue);

        var foundCreatures = searchService.SearchEntities(_commonDbContext.Creatures);
        var foundWeapons = searchService.SearchEntities(_commonDbContext.Weapons);
        var foundSpells = searchService.SearchEntities(_commonDbContext.Spells);
        var foundSpellComponents = searchService.SearchEntities(_commonDbContext.SpellComponents);
        var foundClasses = searchService.SearchEntities(_commonDbContext.Classes);
        var foundRaces = searchService.SearchEntities(_commonDbContext.Races);
        var foundItem = searchService.SearchEntities(_commonDbContext.Items);
        var foundNPC = searchService.SearchEntities(_commonDbContext.NonPlayerCharacters).Cast<NonPlayerCharacter>();
        var foundItemRarities = searchService.SearchEntities(_commonDbContext.ItemRarities);
        var foundItemTypes = searchService.SearchEntities(_commonDbContext.ItemTypes);
        var foundPersons = searchService.SearchEntities(_commonDbContext.Persons);
        var foundDamageType = searchService.SearchEntities(_commonDbContext.DamageTypes);
        var foundStatuses = searchService.SearchEntities(_commonDbContext.Statuses);

        return Json(new
        {
            foundCreatures,
            foundWeapons,
            foundSpells,
            foundSpellComponents,
            foundClasses,
            foundRaces,
            foundItem,
            foundNPC,
            foundItemRarities,
            foundItemTypes,
            foundPersons,
            foundDamageType,
            foundStatuses
        });
    }

    /*     [HttpPost("/add-creature")]
     public IActionResult AddCreature([FromBody] Creature addedCreature)
     {
         var creature = new Creature()
         {
             Id = Guid.NewGuid(),
             Level = addedCreature.Level,
             Name = addedCreature.Name,
             Ideology = addedCreature.Ideology,
             Background = addedCreature.Background,
             MaxHealth = addedCreature.MaxHealth,
             Сharacteristics = addedCreature.Сharacteristics,
             PersonRace = addedCreature.PersonRace,
             PersonClass = addedCreature.PersonClass,
             Spells = addedCreature.Spells,
             Description = addedCreature.Description,
             ImageSource = addedCreature.ImageSource
         };
         _commonDbContext.Creatures.Add(creature);
         _commonDbContext.SaveChanges();
    
         return Json(creature);
     }*/
}