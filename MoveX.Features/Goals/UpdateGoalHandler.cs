using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Goals
{
    public class UpdateGoalHandler
    {
        private readonly MoveXContext _context;
        public UpdateGoalHandler(MoveXContext context) { _context = context; }

        public async Task Execute(Goal replacement)
        {
            var goal = await _context.Goals.FindAsync(replacement.Id);
            goal!.SubjectId = replacement.SubjectId;
            goal.TargetHours = replacement.TargetHours;
            goal.TimeFrame = replacement.TimeFrame;
            await _context.SaveChangesAsync();
        }
    }
}
