using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.StudySessions
{
    public class GetStudySessionsHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public GetStudySessionsHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<StudySession>> Execute()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.StudySessions
                .AsNoTracking()
                .Include(s => s.Subject)
                .OrderByDescending(s => s.StartedAt)
                .ToListAsync();
        }
    }
}
