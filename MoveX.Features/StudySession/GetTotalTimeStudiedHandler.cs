using Microsoft.EntityFrameworkCore;
using MoveX.Database;

namespace MoveX.Features.StudySessions
{
    public class GetTotalTimeStudiedHandler
    {
        private readonly MoveXContext _context;
        public GetTotalTimeStudiedHandler(MoveXContext context) { _context = context; }

        public async Task<TimeSpan> Execute()
        {
            var list = await _context.StudySessions.ToListAsync();
            return list.Aggregate(TimeSpan.Zero, (total, s) => total + s.Duration);
        }
    }
}
