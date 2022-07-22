using Infrastructure.Data.Entities.Contracts;

namespace Infrastructure.Data.Entities
{
    public abstract class DefaultEntity : IEntity
    {
        public virtual long? Id { get; set; }
        public virtual DateTime? CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
    }
}
