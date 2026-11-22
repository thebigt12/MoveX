using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.TimeEntries
{
    public class AddTimeEntryHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public AddTimeEntryHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(TimeEntry entry)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            await context.TimeEntries.AddAsync(entry);
            await context.SaveChangesAsync();
        }
    }
}
