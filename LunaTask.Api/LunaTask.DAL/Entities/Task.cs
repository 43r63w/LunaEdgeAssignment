using LunaTask.DAL.Enums;
using LunaTask.DAL.Entities;

namespace LunaTask.DAL.Entities
{
    public class Task
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public Status Status { get; set; } = Status.Pending;

        public Priority Priority { get; set; } = Priority.Low;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public User User { get; set; }

        public Guid? UserId { get; set; }

    }
}
