namespace Todos.Domain.Entities
{
    public class TodoEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; } = TaskStatus.New;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? CompletedAt { get; set; }

        public int UserId { get; set; }
    }

    public enum TaskStatus
    {
        New,
        InProgress,
        Completed
    }
}
