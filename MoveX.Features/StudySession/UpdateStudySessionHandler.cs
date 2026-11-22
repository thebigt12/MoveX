using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.StudySessions
{
    public class UpdateStudySessionHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public UpdateStudySessionHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(StudySession replacement)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var session = await context.StudySessions.FindAsync(replacement.Id);
            session!.SubjectId = replacement.SubjectId;
            session.Notes = replacement.Notes;
            await context.SaveChangesAsync();
        }
    }
}
