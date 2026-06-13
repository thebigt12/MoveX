using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Habits
{
    public class AddHabitHandler
    {
        private readonly MoveXContext _context;
        public AddHabitHandler(MoveXContext context) { _context = context; }

        public async Task Execute(Habit habit)
        {
            await _context.Habits.AddAsync(habit);
            await _context.SaveChangesAsync();
        }
    }
}
