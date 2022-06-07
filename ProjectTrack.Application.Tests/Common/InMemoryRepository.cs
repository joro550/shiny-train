using ProjectTrack.Application.Common.Interfaces;
using ProjectTrack.Domain;

namespace ProjectTrack.Application.Tests.Common;

public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly List<T> _records = new();
    
    public Task<T> SaveAsync(T entity)
    {
        entity.Id = _records.Count + 1;
        _records.Add(entity);
        return Task.FromResult(entity);
    }

    public Task<T> GetById(int id)
    {
        var firstOrDefault = _records.First(x => x.Id == id);
        return Task.FromResult(firstOrDefault);
    }

    public Task<List<T>> GetListAsync() => Task.FromResult(_records);
}