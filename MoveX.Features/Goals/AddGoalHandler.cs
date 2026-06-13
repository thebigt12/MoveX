using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Goals
{
    public class AddGoalHandler
    {
        private readonly MoveXContext _context;
        public AddGoalHandler(MoveXContext context) { _context = context; }

        public async Task Execute(Goal goal)
        {
            await _context.Goals.AddAsync(goal);
            await _context.SaveChangesAsync();
        }
    }
}
