using MoveX.Database;

namespace MoveX.Features.Habits
{
    public class CompleteHabitHandler
    {
        private readonly MoveXContext _context;
        public CompleteHabitHandler(MoveXContext context) { _context = context; }

        public async Task Execute(int id)
        {
            var habit = await _context.Habits.FindAsync(id);
            if (DateOnly.FromDateTime(DateTime.Today) != DateOnly.FromDateTime(habit!.LastCompleted ?? DateTime.MinValue))
            {
                habit.Streak++;
            }
            habit.LastCompleted = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }
}
