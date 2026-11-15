namespace MoveX.Domain
{
    public class Habit
    {
        public int Id { get; set; }
        public string Subject { get; set; } = "";
        public bool IsBad { get; set; }
        public DateTime? LastCompleted { get; set; }
        public int Streak { get; set; } = 0;
        public DateOnly Started { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        public bool IsCompletedToday => LastCompleted?.Date == DateTime.Today;
        public int CurrentStreak => LastCompleted is not null && LastCompleted.Value.Date >= DateTime.Today.AddDays(-1) ? Streak : 0;
    }
}
