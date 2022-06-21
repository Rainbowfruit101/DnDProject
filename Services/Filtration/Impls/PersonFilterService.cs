using Database;
using Models.LiveEntities;
using Services.Filtration.FilterOptions;
using Services.Filtration.TextSearchPredicate;
using Services.Filtration.Utils;

namespace Services.Filtration.Impls;

public class PersonFilterService
{
    private readonly CommonDbContext _dbContext;
    private readonly ITextSearchPredicate _textSearchPredicate;

    public PersonFilterService(CommonDbContext dbContext, ITextSearchPredicate textSearchPredicate)
    {
        _dbContext = dbContext;
        _textSearchPredicate = textSearchPredicate;
    }

    public IEnumerable<Person> Filter(PersonFilterOptions filterOptions)
    {
        return new OptionsFilter<Person, PersonFilterOptions>(_dbContext.Persons, filterOptions)
            .FilterBy(personOptions => personOptions.Ideology,
                (person, ideology) => person.Ideology == ideology)
            .FilterBy(personOptions => personOptions.Level,
                (person, level) => person.Level == level)
            .FilterBy(personOptions => personOptions.PersonClass,
                (person, personClass) => person.PersonClass == personClass)
            .FilterBy(personOptions => personOptions.PersonRace,
                (person, personRace) => person.PersonRace== personRace)
            .FilterBy(personOptions => personOptions.Name,
                (person, name) => _textSearchPredicate.Run(person.Name, name))
            .Finish();
    }
}