using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Journal
{
    public class AddJournalEntryHandler
    {
        private readonly MoveXContext _context;
        public AddJournalEntryHandler(MoveXContext context) { _context = context; }

        public async Task Execute(JournalEntry entry)
        {
            await _context.JournalEntries.AddAsync(entry);
            await _context.SaveChangesAsync();
        }
    }
}
