using Models.LiveEntities;
using Services.Filtration;
using Services.Filtration.FilterOptions;

namespace WebAPI.Controllers.Filters.Impls;

public class CreatureFilterController : FilterControllerBase<Creature, CreatureFilterOptions>
{
    public CreatureFilterController(IFilterService<Creature, CreatureFilterOptions> entityFilterService) : base(
        entityFilterService)
    {
    }

    protected override CreatureFilterOptions GetFilterOptions()
    {
        var optionNames = new CreatureFilterOptions();
        var options = new CreatureFilterOptions()
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