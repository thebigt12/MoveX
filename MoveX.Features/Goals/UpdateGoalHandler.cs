using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Goals
{
    public class UpdateGoalHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public UpdateGoalHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Goal replacement)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var goal = await context.Goals.FindAsync(replacement.Id);
            goal!.SubjectId = replacement.SubjectId;
            goal.TargetHours = replacement.TargetHours;
            goal.TimeFrame = replacement.TimeFrame;
            await context.SaveChangesAsync();
        }
    }
}
