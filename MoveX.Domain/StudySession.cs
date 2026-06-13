namespace MoveX.Domain
{
    public class StudySession
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public string Notes { get; set; } = "";
        public DateTime StartedAt { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
