using LiteDB.Async;
using ProjectTrack.Domain;
using ProjectTrack.Application.Common.Interfaces;

namespace ProjectTrack.Infrastructure;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ILiteDatabaseAsync _database;

    public Repository(ILiteDatabaseAsync database) 
        => _database = database;

    public async Task<T> SaveAsync(T entity) =>
        await WithCollection(async col =>
        {
            await col.InsertAsync(entity);
            return entity;
        });

    public async Task<T> GetById(int id) 
        => await WithCollection(async coll => await coll.Query().Where(x => x.Id == id).FirstOrDefaultAsync());


    private async Task<T> WithCollection(Func<ILiteCollectionAsync<T>, Task<T>> action)
    {
        var collection = _database.GetCollection<T>(typeof(T).Name);
        return await action(collection);
    }
}