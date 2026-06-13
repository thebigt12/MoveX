namespace MoveX.Domain
{
    public class TimeEntry
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public string Text { get; set; } = "";
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime FinishTime { get; set; }
    }
}
