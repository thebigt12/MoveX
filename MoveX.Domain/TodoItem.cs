namespace MoveX.Domain
{
    public class TodoItem
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public string Description { get; set; } = "";
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
