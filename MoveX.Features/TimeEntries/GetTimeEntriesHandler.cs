using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.TimeEntries
{
    public class GetTimeEntriesHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public GetTimeEntriesHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<TimeEntry>> Execute()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.TimeEntries
                .AsNoTracking()
                .Include(t => t.Subject)
                .OrderByDescending(t => t.StartTime)
                .ToListAsync();
        }
    }
}
