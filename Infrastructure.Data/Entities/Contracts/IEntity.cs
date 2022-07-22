namespace Infrastructure.Data.Entities.Contracts
{
    public interface IEntity
    {
        long? Id { get; set; }
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
