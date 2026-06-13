using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Journal
{
    public class GetJournalEntriesHandler
    {
        private readonly MoveXContext _context;
        public GetJournalEntriesHandler(MoveXContext context) { _context = context; }

        public async Task<List<JournalEntry>> Execute()
        {
            return await _context.JournalEntries.ToListAsync();
        }
    }
}
