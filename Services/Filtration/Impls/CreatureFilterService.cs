using Database;
using Models.LiveEntities;
using Services.Filtration.FilterOptions;
using Services.Filtration.TextSearchPredicate;
using Services.Filtration.Utils;

namespace Services.Filtration.Impls;

public class CreatureFilterService : IFilterService<Creature, CreatureFilterOptions>
{
    private readonly CommonDbContext _dbContext;
    private readonly ITextSearchPredicate _textSearchPredicate;

    public CreatureFilterService(CommonDbContext dbContext, ITextSearchPredicate textSearchPredicate)
    {
        _dbContext = dbContext;
        _textSearchPredicate = textSearchPredicate;
    }

    public IEnumerable<Creature> Filter(CreatureFilterOptions filterOptions)
    {
        return new OptionsFilter<Creature, CreatureFilterOptions>(_dbContext.Creatures, filterOptions)
            .FilterBy(creatureOptions => creatureOptions.Ideology,
                (creature, ideology) => creature.Ideology.Type == ideology)
            .FilterBy(creatureOptions => creatureOptions.Level,
                (creature, level) => creature.Level == level)
            .FilterBy(creatureOptions => creatureOptions.PersonClass,
                (creature, creatureClass) => creature.PersonClass.Type == creatureClass)
            .FilterBy(creatureOptions => creatureOptions.PersonRace,
                (creature, creatureRace) => creature.PersonRace.Type == creatureRace)
            .FilterBy(creatureOptions => creatureOptions.Name,
                (creature, name) => _textSearchPredicate.Run(creature.Name, name))
            .Finish();
    }
}