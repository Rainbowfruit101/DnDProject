using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Common;
using Models.Interfaces;
using Models.LiveEntities;
using Services;

namespace WebAPI.Controllers;

[Route("/test")]
public class TestController : Controller
{
    private readonly CommonDbContext _commonDbContext;

    public TestController(CommonDbContext commonDbContext)
    {
        _commonDbContext = commonDbContext;
    }

    List<TEntity> SearchEntities<TEntity>(DbSet<TEntity> dbSet, string desiredValue)
        where TEntity : class, IHasName
    {
        var selectedList = dbSet
            .Where(desiredTable => desiredTable.Name.Contains(desiredValue))
            .ToList();
        return selectedList;
    }

    [HttpGet("/search-value")]
    public IActionResult SearchValue(string searchedValue)
    {
        //var searchService = new SearchByNameService();
        var searchService = new SearchByNameDecoratorService(new SearchByNameService(), searchedValue);

        var foundCreatures = searchService.SearchEntities(_commonDbContext.Creatures);
        var foundWeapons = searchService.SearchEntities(_commonDbContext.Weapons);
        var foundSpells = searchService.SearchEntities(_commonDbContext.Spells);
        var foundSpellComponents = searchService.SearchEntities(_commonDbContext.SpellComponents);
        var foundClasses = searchService.SearchEntities(_commonDbContext.Classes);
        var foundRaces = searchService.SearchEntities(_commonDbContext.Races);
        var foundItem = searchService.SearchEntities(_commonDbContext.Items);
        var foundNPC = searchService.SearchEntities(_commonDbContext.NonPlayerCharacters);
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

    [HttpPost("/add-creature")]
    public IActionResult AddCreature([FromBody] Creature addedCreature)
    {
        var d = new Creature()
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
        _commonDbContext.Creatures.Add(d);
        _commonDbContext.SaveChanges();

        return Json(d);
    }
}