using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.LiveEntities;
using Services.Filtration;
using Services.Filtration.FilterOptions;

namespace WebAPI.Controllers.Filters.Impls;

[Route("/persons")]
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
            Ideology = GetQueryEnum<IdeologyType>(nameof(optionNames.Ideology)),
            Level = GetQueryInt(nameof(optionNames.Level)),
            Name = GetQueryString(nameof(optionNames.Name)),
            PersonClasses = GetQueryArrayOf(nameof(optionNames.PersonClasses), Parse<ClassType>)?
                .Cast<ClassType>()
                .ToList(),
            PersonRace = GetQueryEnum<RaceType>(nameof(optionNames.PersonRace))
        };
        return options;
    }
}