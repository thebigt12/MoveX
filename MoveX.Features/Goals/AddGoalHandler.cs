using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Goals
{
    public class AddGoalHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public AddGoalHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Goal goal)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            await context.Goals.AddAsync(goal);
            await context.SaveChangesAsync();
        }
    }
}
