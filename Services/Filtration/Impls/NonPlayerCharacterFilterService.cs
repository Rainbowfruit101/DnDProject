using Database;
using Models.LiveEntities;
using Services.Filtration.FilterOptions;
using Services.Filtration.TextSearchPredicate;
using Services.Filtration.Utils;

namespace Services.Filtration.Impls;

public class NonPlayerCharacterFilterService
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
        return new OptionsFilter<NonPlayerCharacter, NonPlayerCharacterFilterOptions>(_dbContext.NonPlayerCharacters, filterOptions)
            .FilterBy(NPCOptions => NPCOptions.Ideology,
                (NPC, ideology) => NPC.Ideology == ideology)
            .FilterBy(NPCOptions => NPCOptions.Level,
                (NPC, level) => NPC.Level == level)
            .FilterBy(NPCOptions => NPCOptions.PersonClass,
                (NPC, NPCClass) => NPC.PersonClass == NPCClass)
            .FilterBy(NPCOptions => NPCOptions.PersonRace,
                (NPC, NPCRace) => NPC.PersonRace== NPCRace)
            .FilterBy(NPCOptions => NPCOptions.Name,
                (NPC, name) => _textSearchPredicate.Run(NPC.Name, name))
            .Finish();
    }
}