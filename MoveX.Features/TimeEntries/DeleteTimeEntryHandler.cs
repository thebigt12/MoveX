using Microsoft.EntityFrameworkCore;
using MoveX.Database;

namespace MoveX.Features.TimeEntries
{
    public class DeleteTimeEntryHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public DeleteTimeEntryHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(int id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var entry = await context.TimeEntries.FindAsync(id);
            context.TimeEntries.Remove(entry!);
            await context.SaveChangesAsync();
        }
    }
}
