using MoveX.Database;

namespace MoveX.Features.Goals
{
    public class CompleteGoalHandler
    {
        private readonly MoveXContext _context;
        public CompleteGoalHandler(MoveXContext context) { _context = context; }

        public async Task Execute(int id)
        {
            var goal = await _context.Goals.FindAsync(id);
            goal!.IsDone = true;
            await _context.SaveChangesAsync();
        }
    }
}
