using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.TimeEntries
{
    public class AddTimeEntryHandler
    {
        private readonly MoveXContext _context;
        public AddTimeEntryHandler(MoveXContext context) { _context = context; }

        public async Task Execute(TimeEntry entry)
        {
            await _context.TimeEntries.AddAsync(entry);
            await _context.SaveChangesAsync();
        }
    }
}
