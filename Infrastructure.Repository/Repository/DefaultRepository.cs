using Infrastructure.Data.Entities;
using Infrastructure.Data.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repository
{
    public abstract class DefaultRepository<T> where T : DefaultEntity
    {
        private readonly DbSet<T> _data;
        protected DefaultRepository(DbSet<T> data)
        {
            this._data = data;
        }

        public virtual async Task<T?> AddAsync(T target, CancellationToken cancellationToken)
        {
            var result = await this._data!.AddAsync(target, cancellationToken);

            return result?.Entity;
        }

        public virtual T? Update(T target)
        {
            _ = this._data!.Update(target).State = EntityState.Modified;

            return target;
        }

        public virtual async Task<int> CountAsync(CancellationToken cancellationToken, Expression<Func<T, bool>>? expression = null)
        {
            if (expression == null)
            {
                return await this._data!.CountAsync(cancellationToken);
            }
            else
            {
                return await this._data!.CountAsync(expression, cancellationToken);
            }
        }

        public virtual T Delete(T target)
        {
            var result = this._data!.Remove(target);

            return result.Entity;
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression,CancellationToken cancellationToken)
        {
            return await this._data!.AnyAsync(expression, cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            var result = await this._data!.Where(expression).ToArrayAsync(cancellationToken);

            return result;
        }

        public virtual async Task<T?> FindByIdAsync(long id, CancellationToken cancellationToken)
        {
            var result = await this._data!.Where(x => x.Id.HasValue && x.Id == id).FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
