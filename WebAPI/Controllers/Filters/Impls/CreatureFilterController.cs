using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.LiveEntities;
using Services.Filtration;
using Services.Filtration.FilterOptions;

namespace WebAPI.Controllers.Filters.Impls;

[Route("/creatures")]
public class CreatureFilterController : FilterControllerBase<Creature, CreatureFilterOptions>
{
    public CreatureFilterController(IFilterService<Creature, CreatureFilterOptions> entityFilterService) 
        :base(entityFilterService)
    {
    }

    protected override CreatureFilterOptions GetFilterOptions()
    {
        var optionNames = new CreatureFilterOptions();
        var options = new CreatureFilterOptions()
        {
            Ideology = GetQueryEnum<IdeologyType>(nameof(optionNames.Ideology)),
            Level = GetQueryInt(nameof(optionNames.Level)),
            Name = GetQueryString(nameof(optionNames.Name)),
            PersonClass = GetQueryEnum<ClassType>(nameof(optionNames.PersonClass)),
            PersonRace = GetQueryEnum<RaceType>(nameof(optionNames.PersonRace))
        };
        return options;
    }
}