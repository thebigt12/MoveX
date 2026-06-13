using MoveX.Database;

namespace MoveX.Features.TimeEntries
{
    public class DeleteTimeEntryHandler
    {
        private readonly MoveXContext _context;
        public DeleteTimeEntryHandler(MoveXContext context) { _context = context; }

        public async Task Execute(int id)
        {
            var entry = await _context.TimeEntries.FindAsync(id);
            _context.TimeEntries.Remove(entry!);
            await _context.SaveChangesAsync();
        }
    }
}
