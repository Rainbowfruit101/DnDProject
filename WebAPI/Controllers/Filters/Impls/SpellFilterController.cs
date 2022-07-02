using System.ComponentModel;
using Models.Common;
using Models.LiveEntities;
using Services.Filtration;
using Services.Filtration.FilterOptions;

namespace WebAPI.Controllers.Filters.Impls;

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
            School = GetQueryEnum<School.Type>(nameof(optionNames.School)),
            AvailableClasses = GetQueryArrayOf(nameof(optionNames.AvailableClasses), ParseClassType)?
                .Cast<LiveEntityClass.Type>()
                .ToList(),
            AvailableComponents = GetQueryArrayOf(nameof(optionNames.AvailableComponents), ParseComponentType)?
                .Cast<SpellComponent.Type>()
                .ToList(),
            UseConcentration = GetQueryBool(nameof(optionNames.UseConcentration))
        };
        return options;
    }

    private LiveEntityClass.Type? ParseClassType(string className)
    {
        if (Enum.TryParse<LiveEntityClass.Type>(className, out var result))
            return result;
        return null;
    }

    private SpellComponent.Type? ParseComponentType(string componentName)
    {
        if (Enum.TryParse<SpellComponent.Type>(componentName, out var result))
            return result;
        return null;
    }
}