namespace Database;

public static class IRepositoryExtensions
{
    public static async Task SaveAsync<TEntity>(this IRepository<TEntity> repository)
        where TEntity : class
    {
        await repository.DbContext.SaveChangesAsync();
    }
}