using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Journal
{
    public class AddJournalEntryHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public AddJournalEntryHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(JournalEntry entry)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            await context.JournalEntries.AddAsync(entry);
            await context.SaveChangesAsync();
        }
    }
}
