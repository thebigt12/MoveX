using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.StudySessions
{
    public class AddStudySessionHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public AddStudySessionHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(StudySession session)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            await context.StudySessions.AddAsync(session);
            await context.SaveChangesAsync();
        }
    }
}
