using Models.Interfaces;

namespace Services;

public class SearchByNameService
{
    public IEnumerable<IHasName> SearchEntities(IEnumerable<IHasName> dbSet, string desiredValue)
    {
        return dbSet.Where(desiredTable => desiredTable.Name.Contains(desiredValue));
    }
}