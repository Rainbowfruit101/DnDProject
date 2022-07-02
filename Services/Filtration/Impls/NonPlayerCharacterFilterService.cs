using Database;
using Models.LiveEntities;
using Services.Filtration.FilterOptions;
using Services.Filtration.TextSearchPredicate;
using Services.Filtration.Utils;

namespace Services.Filtration.Impls;

public class NonPlayerCharacterFilterService : IFilterService<NonPlayerCharacter, NonPlayerCharacterFilterOptions>
{
    private readonly CommonDbContext _dbContext;
    private readonly ITextSearchPredicate _textSearchPredicate;

    public NonPlayerCharacterFilterService(CommonDbContext dbContext, ITextSearchPredicate textSearchPredicate)
    {
        _dbContext = dbContext;
        _textSearchPredicate = textSearchPredicate;
    }

    public IEnumerable<NonPlayerCharacter> Filter(NonPlayerCharacterFilterOptions filterOptions)
    {
        return new OptionsFilter<NonPlayerCharacter, NonPlayerCharacterFilterOptions>(_dbContext.NonPlayerCharacters,
                filterOptions)
            .FilterBy(npcOptions => npcOptions.Ideology,
                (npc, ideology) => npc.Ideology.EType == ideology)
            .FilterBy(npcOptions => npcOptions.Level,
                (npc, level) => npc.Level == level)
            .FilterBy(npcOptions => npcOptions.PersonClass,
                (npc, npcClass) => npc.PersonClass.EType == npcClass)
            .FilterBy(npcOptions => npcOptions.PersonRace,
                (npc, npcRace) => npc.PersonRace.ERace == npcRace)
            .FilterBy(npcOptions => npcOptions.Name,
                (npc, name) => _textSearchPredicate.Run(npc.Name, name))
            .Finish();
    }
}