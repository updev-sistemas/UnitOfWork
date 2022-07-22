using Domain.BusinessRules.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repository
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        Task SaveChanges(CancellationToken cancellationToken);
        Task<IDbContextTransaction?> BeginTransactionAsync(CancellationToken cancellationToken);
    }
}
