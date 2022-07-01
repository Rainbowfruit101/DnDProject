using Microsoft.AspNetCore.Mvc;
using Services.Filtration;

namespace WebAPI.Controllers;

[Route("/test")]
public class TestController : Controller
{
    private readonly SearchByNameService _searchByNameService;

    public TestController(SearchByNameService searchByNameService)
    {
        _searchByNameService = searchByNameService;
    }

    [HttpGet("/search-value")]
    public IActionResult SearchValue(string searchedValue)
    {
        var searchService = new SearchByNameServiceDecorator(_searchByNameService, searchedValue);

        var foundCreatures = searchService
            .SearchEntities(dbContext => dbContext.Creatures);
        var foundWeapons = searchService
            .SearchEntities(dbContext => dbContext.Weapons);
        var foundSpells = searchService
            .SearchEntities(dbContext => dbContext.Spells);
        var foundSpellComponents = searchService
            .SearchEntities(dbContext => dbContext.SpellComponents);
        var foundClasses = searchService
            .SearchEntities(dbContext => dbContext.Classes);
        var foundRaces = searchService
            .SearchEntities(dbContext => dbContext.Races);
        var foundItem = searchService
            .SearchEntities(dbContext => dbContext.Items);
        var foundNPC = searchService
            .SearchEntities(dbContext => dbContext.NonPlayerCharacters);
        var foundItemRarities = searchService
            .SearchEntities(dbContext => dbContext.ItemRarities);
        var foundItemTypes = searchService
            .SearchEntities(dbContext => dbContext.ItemTypes);
        var foundPersons = searchService
            .SearchEntities(dbContext => dbContext.Persons);
        var foundDamageType = searchService
            .SearchEntities(dbContext => dbContext.DamageTypes);
        var foundStatuses = searchService
            .SearchEntities(dbContext => dbContext.Statuses);

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
}