using Models.LiveEntities;
using Services.Filtration;
using Services.Filtration.FilterOptions;

namespace WebAPI.Controllers.Filters.Impls;

public class PersonFilterController : FilterControllerBase<Person, PersonFilterOptions>
{
    public PersonFilterController(IFilterService<Person, PersonFilterOptions> entityFilterService) : base(
        entityFilterService)
    {
    }

    protected override PersonFilterOptions GetFilterOptions()
    {
        var optionNames = new PersonFilterOptions();
        var options = new PersonFilterOptions()
        {
            Ideology = GetQueryEnum<Ideology.Type>(nameof(optionNames.Ideology)),
            Level = GetQueryInt(nameof(optionNames.Level)),
            Name = GetQueryString(nameof(optionNames.Name)),
            PersonClasses = GetQueryArrayOf(nameof(optionNames.PersonClasses), ParseClassType)?
                .Cast<LiveEntityClass.Type>()
                .ToList(),
            PersonRace = GetQueryEnum<LiveEntityRace.Race>(nameof(optionNames.PersonRace))
        };
        return options;
    }

    private LiveEntityClass.Type? ParseClassType(string className)
    {
        if (Enum.TryParse<LiveEntityClass.Type>(className, out var result))
            return result;
        return null;
    }
}