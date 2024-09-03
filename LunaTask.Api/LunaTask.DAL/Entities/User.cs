namespace LunaTask.DAL.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
        public ICollection<Entities.Task> Tasks { get; set; } = new List<Entities.Task>();
    }
}
