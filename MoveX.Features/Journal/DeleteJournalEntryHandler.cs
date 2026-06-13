using MoveX.Database;

namespace MoveX.Features.Journal
{
    public class DeleteJournalEntryHandler
    {
        private readonly MoveXContext _context;
        public DeleteJournalEntryHandler(MoveXContext context) { _context = context; }

        public async Task Execute(int id)
        {
            var entry = await _context.JournalEntries.FindAsync(id);
            _context.JournalEntries.Remove(entry!);
            await _context.SaveChangesAsync();
        }
    }
}
