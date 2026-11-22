using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Goals
{
    public class GetGoalsHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public GetGoalsHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Goal>> Execute()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Goals
                .AsNoTracking()
                .Include(g => g.Subject)
                .OrderBy(g => g.IsDone)
                .ThenByDescending(g => g.Id)
                .ToListAsync();
        }
    }
}
