namespace MoveX.Domain
{
    public class Goal
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public int TargetHours { get; set; }
        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        public GoalType TimeFrame { get; set; }
        public bool IsDone { get; set; }
    }
}
