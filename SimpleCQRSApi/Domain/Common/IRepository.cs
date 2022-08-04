using System.Linq.Expressions;

namespace SimpleCQRSApi.Domain.Common;

public interface IRepository<T> where T : Entity
{
    Task<T> Get(Guid id);

    Task<IEnumerable<T>> GetAll();

    Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate);

    Task Insert(T entity);

    Task<T> Update(T entity);

    Task Delete(Guid id);
}
