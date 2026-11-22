using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Journal
{
    public class GetJournalEntriesHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public GetJournalEntriesHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<JournalEntry>> Execute()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.JournalEntries
                .AsNoTracking()
                .OrderByDescending(j => j.TimeOfEntry)
                .ToListAsync();
        }
    }
}
