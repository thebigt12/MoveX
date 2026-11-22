using Microsoft.EntityFrameworkCore;
using MoveX.Database;

namespace MoveX.Features.Journal
{
    public class DeleteJournalEntryHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public DeleteJournalEntryHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(int id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var entry = await context.JournalEntries.FindAsync(id);
            context.JournalEntries.Remove(entry!);
            await context.SaveChangesAsync();
        }
    }
}
