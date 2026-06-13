using MoveX.Database;

namespace MoveX.Features.Habits
{
    public class DeleteHabitHandler
    {
        private readonly MoveXContext _context;
        public DeleteHabitHandler(MoveXContext context) { _context = context; }

        public async Task Execute(int id)
        {
            var habit = await _context.Habits.FindAsync(id);
            _context.Habits.Remove(habit!);
            await _context.SaveChangesAsync();
        }
    }
}
