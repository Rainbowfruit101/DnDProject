using Database;
using Models.Common;
using Services.Filtration.FilterOptions;
using Services.Filtration.TextSearchPredicate;
using Services.Filtration.Utils;

namespace Services.Filtration.Impls;

public class SpellFilterService
{
    private readonly CommonDbContext _dbContext;
    private readonly ITextSearchPredicate _textSearchPredicate;

    public SpellFilterService(CommonDbContext dbContext, ITextSearchPredicate textSearchPredicate)
    {
        _dbContext = dbContext;
        _textSearchPredicate = textSearchPredicate;
    }

    public IEnumerable<Spell> Filter(SpellFilterOptions filterOptions)
    {
        return new OptionsFilter<Spell, SpellFilterOptions>(_dbContext.Spells, filterOptions)
            .FilterBy(spellOptions => spellOptions.Level,
                (spell, level) => spell.Level == level)
            .FilterBy(spellOptions => spellOptions.School,
                (spell, school) => spell.School == school)
            .FilterBy(spellOptions => spellOptions.UseConcentration,
                (spell, concentration) => spell.UseConcentration == concentration)
            .FilterBy(spellOptions => spellOptions.Name,
                (spell, name) => _textSearchPredicate.Run(spell.Name, name))
            .FilterBy(spellOptions => spellOptions.AvailableClasses,
                (spell, listClasses) => listClasses.All(spell.AvailableClasses.Contains))
            .FilterBy(spellOptions => spellOptions.AvailableComponents,
                (spell, listComponents) => listComponents.All(spell.AvailableComponents.Contains))
            .Finish();
    }
}