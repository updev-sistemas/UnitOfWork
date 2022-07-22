using Infrastructure.Data.Entities.Contracts;
using System.Linq.Expressions;

namespace Domain.BusinessRules.Repository
{
    public interface IDefaultRepository<T> where T : IEntity
    {
        Task<T?> FindByIdAsync(long id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
        Task<T?> AddAsync(T target, CancellationToken cancellationToken);
        T? Update(T target);
        T Delete(T target);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
        Task<int> CountAsync(CancellationToken cancellationToken, Expression<Func<T, bool>>? expression = null);
    }
}
