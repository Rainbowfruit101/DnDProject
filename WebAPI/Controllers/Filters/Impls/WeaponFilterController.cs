using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.Items;
using Services.Filtration;
using Services.Filtration.FilterOptions;

namespace WebAPI.Controllers.Filters.Impls;

[Route("/weapons")]
public class WeaponFilterController : FilterControllerBase<Weapon, WeaponFilterOptions>
{
    public WeaponFilterController(IFilterService<Weapon, WeaponFilterOptions> entityFilterService) 
        : base(entityFilterService)
    {
    }

    protected override WeaponFilterOptions GetFilterOptions()
    {
        var minCost = GetQueryInt("minCost");
        var maxCost = GetQueryInt("maxCost");

        var optionNames = new WeaponFilterOptions();
        var options = new WeaponFilterOptions()
        {
            Name = GetQueryString(nameof(optionNames.Name)),
            Properties = GetQueryArrayOf(nameof(optionNames.Properties), Parse<PropertyType>)?
                .Cast<PropertyType>()
                .ToList(),
            CostRange = new Range<int>()
            {
                HasMin = minCost.HasValue,
                HasMax = maxCost.HasValue,
                Min = minCost ?? 0,
                Max = maxCost ?? 0
            },
            DamageType = GetQueryEnum<DamageEType>(nameof(optionNames.DamageType))
        };
        return options;
    }
}