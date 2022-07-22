using Infrastructure.Data.Entities.Contracts;

namespace Infrastructure.Data.Entities
{
    public class UserEntity : DefaultEntity
    {
        public virtual string? Email { get; set; }
        public virtual string? UserName { get; set; }
    }
}
