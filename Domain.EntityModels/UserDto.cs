namespace Domain.EntityModels
{
    public class UserDto
    {
        public virtual long? Id { get; set; }
        public virtual string? Email { get; set; }
        public virtual string? UserName { get; set; }
        public virtual DateTime? CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
    }
}