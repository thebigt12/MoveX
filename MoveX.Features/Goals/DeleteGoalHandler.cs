using MoveX.Database;

namespace MoveX.Features.Goals
{
    public class DeleteGoalHandler
    {
        private readonly MoveXContext _context;
        public DeleteGoalHandler(MoveXContext context) { _context = context; }

        public async Task Execute(int id)
        {
            var goal = await _context.Goals.FindAsync(id);
            _context.Goals.Remove(goal!);
            await _context.SaveChangesAsync();
        }
    }
}
