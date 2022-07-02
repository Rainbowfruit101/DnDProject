using Models.LiveEntities;
using Services.Filtration;
using Services.Filtration.FilterOptions;

namespace WebAPI.Controllers.Filters.Impls;

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
            Ideology = GetQueryEnum<Ideology.Type>(nameof(optionNames.Ideology)),
            Level = GetQueryInt(nameof(optionNames.Level)),
            Name = GetQueryString(nameof(optionNames.Name)),
            PersonClass = GetQueryEnum<LiveEntityClass.Type>(nameof(optionNames.PersonClass)),
            PersonRace = GetQueryEnum<LiveEntityRace.Race>(nameof(optionNames.PersonRace))
        };
        return options;
    }
}