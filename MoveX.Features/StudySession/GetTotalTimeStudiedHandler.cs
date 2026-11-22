using Microsoft.EntityFrameworkCore;
using MoveX.Database;

namespace MoveX.Features.StudySessions
{
    public class GetTotalTimeStudiedHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public GetTotalTimeStudiedHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<TimeSpan> Execute()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var sessions = await context.StudySessions.AsNoTracking().ToListAsync();
            return sessions.Aggregate(TimeSpan.Zero, (total, s) => total + s.Duration);
        }
    }
}
