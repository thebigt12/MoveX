using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Habits
{
    public class UpdateHabitHandler
    {
        private readonly MoveXContext _context;
        public UpdateHabitHandler(MoveXContext context) { _context = context; }

        public async Task Execute(Habit replacement)
        {
            var habit = await _context.Habits.FindAsync(replacement.Id);
            habit!.Subject = replacement.Subject;
            habit.IsBad = replacement.IsBad;
            await _context.SaveChangesAsync();
        }
    }
}
