using Domain.BusinessRules.Repository;
using Infrastructure.Data.Context;
using Infrastructure.Data.Entities;
using Infrastructure.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly LocalDbContext? _db;

        private readonly DbSet<UserEntity> _users;

        public UnitOfWork(LocalDbContext context)
        {
            this._db = context;

            this._users = this._db.Set<UserEntity>();

            this._userDbSet = new UserRepository(this._users);

        }

        private readonly IUserRepository _userDbSet;
        public IUserRepository User => this._userDbSet;

        public async Task<IDbContextTransaction?> BeginTransactionAsync(CancellationToken cancellationToken)
        {
            return await this._db!.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task SaveChanges(CancellationToken cancellationToken)
        {
            var entries = this._db!.ChangeTracker
                                   .Entries()
                                   .Where(e => e.Entity is DefaultEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((DefaultEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                }

                ((DefaultEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;
            }

            await this._db!.SaveChangesAsync(cancellationToken);
        }

        public ValueTask DisposeAsync()
        {
            return ValueTask.CompletedTask;
        }
    }
}
