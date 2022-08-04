using System.Linq.Expressions;
using LiteDB;
using SimpleCQRSApi.Domain.Common;
using SimpleCQRSApi.Infrastructure.Contexts;

namespace SimpleCQRSApi.Infrastructure;

public class LiteDbRepository<T> : IRepository<T> where T : Entity
{
    private LiteDatabase _liteDb;
    private readonly ILiteCollection<T> collection;

    public LiteDbRepository(LiteDbContext liteDbContext)
    {
        _liteDb = liteDbContext.Database;
        collection = _liteDb.GetCollection<T>(typeof(T).Name);
    }

    public Task Delete(Guid id)
    {
        collection.Delete(id);

        return default(Task);
    }

    public Task<T> Get(Guid id)
    {
        var result = collection.FindById(id);

        return Task.FromResult(result);
    }

    public Task<IEnumerable<T>> GetAll()
    {
        var result = collection.FindAll();

        return Task.FromResult(result);
    }

    public Task Insert(T entity)
    {
        var result = collection.Insert(entity);

        return Task.FromResult(result);
    }

    public Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate)
    {
        var result = collection.Find(predicate);

        return Task.FromResult(result);
    }

    public Task<T> Update(T entity)
    {
        var result = collection.Update(entity);

        return Task.FromResult(entity);
    }
}
