using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.LiveEntities;
using Services.Filtration;
using Services.Filtration.FilterOptions;

namespace WebAPI.Controllers.Filters.Impls;

[Route("/non-player-characters")]
public class NonPlayerCharacterFilterController : FilterControllerBase<NonPlayerCharacter, NonPlayerCharacterFilterOptions>
{
    public NonPlayerCharacterFilterController(IFilterService<NonPlayerCharacter, NonPlayerCharacterFilterOptions> entityFilterService) : base(entityFilterService)
    {
    }

    protected override NonPlayerCharacterFilterOptions GetFilterOptions()
    {
        var optionNames = new NonPlayerCharacterFilterOptions();
        var options = new NonPlayerCharacterFilterOptions()
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