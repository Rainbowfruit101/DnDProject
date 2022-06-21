using Database;
using Models.Items;
using Services.Filtration.FilterOptions;
using Services.Filtration.TextSearchPredicate;
using Services.Filtration.Utils;

namespace Services.Filtration.Impls;

public class WeaponFilterService
{
    private readonly CommonDbContext _dbContext;
    private readonly ITextSearchPredicate _textSearchPredicate;

    public WeaponFilterService(CommonDbContext dbContext, ITextSearchPredicate textSearchPredicate)
    {
        _dbContext = dbContext;
        _textSearchPredicate = textSearchPredicate;
    }

    public IEnumerable<Weapon> Filter(WeaponFilterOptions filterOptions)
    {
        return new OptionsFilter<Weapon, WeaponFilterOptions>(_dbContext.Weapons, filterOptions)
            .FilterBy(weaponOptions => weaponOptions.CostRange,
                (weapon, range) => range.InRange(weapon.Cost))
            .FilterBy(weaponOptions => weaponOptions.Properties,
                (weapon, listProperties) => listProperties.All(weapon.Properties.Contains))
            .FilterBy(weaponOptions => weaponOptions.DamageType,
                (weapon, damageType) => weapon.DamageType == damageType)
            .FilterBy(weaponOptions => weaponOptions.Name,
                (weapon, name) => _textSearchPredicate.Run(weapon.Name, name))
            .Finish();
    }
}