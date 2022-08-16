using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Models.Common;
using Models.Enums;
using Models.LiveEntities;
using Services.Filtration;
using Services.Filtration.FilterOptions;

namespace WebAPI.Controllers.Filters.Impls;

[Route("/spells")]
public class SpellFilterController : FilterControllerBase<Spell, SpellFilterOptions>
{
    public SpellFilterController(IFilterService<Spell, SpellFilterOptions> entityFilterService) : base(
        entityFilterService)
    {
    }

    protected override SpellFilterOptions GetFilterOptions()
    {
        var optionNames = new SpellFilterOptions();
        var options = new SpellFilterOptions()
        {
            Name = GetQueryString(nameof(optionNames.Name)),
            Level = GetQueryInt(nameof(optionNames.Level)),
            School = GetQueryEnum<SchoolType>(nameof(optionNames.School)),
            AvailableClasses = GetQueryArrayOf(nameof(optionNames.AvailableClasses), Parse<ClassType>)?
                .Cast<ClassType>()
                .ToList(),
            AvailableComponents = GetQueryArrayOf(nameof(optionNames.AvailableComponents), Parse<ComponentType>)?
                .Cast<ComponentType>()
                .ToList(),
            UseConcentration = GetQueryBool(nameof(optionNames.UseConcentration))
        };
        return options;
    }

}