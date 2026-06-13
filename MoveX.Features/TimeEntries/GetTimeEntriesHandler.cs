using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.TimeEntries
{
    public class GetTimeEntriesHandler
    {
        private readonly MoveXContext _context;
        public GetTimeEntriesHandler(MoveXContext context) { _context = context; }

        public async Task<List<TimeEntry>> Execute()
        {
            return await _context.TimeEntries.ToListAsync();
        }
    }
}
