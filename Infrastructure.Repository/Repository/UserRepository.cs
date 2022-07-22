using Domain.BusinessRules.Repository;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repository
{
    public class UserRepository : DefaultRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DbSet<UserEntity> dbset)
            : base(dbset)
        {
        }

    }
}
