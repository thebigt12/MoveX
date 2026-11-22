using Microsoft.EntityFrameworkCore;
using MoveX.Database;

namespace MoveX.Features.Goals
{
    public class CompleteGoalHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public CompleteGoalHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(int id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var goal = await context.Goals.FindAsync(id);
            goal!.IsDone = true;
            await context.SaveChangesAsync();
        }
    }
}
