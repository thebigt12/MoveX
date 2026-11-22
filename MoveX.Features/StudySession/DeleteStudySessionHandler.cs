using Microsoft.EntityFrameworkCore;
using MoveX.Database;

namespace MoveX.Features.StudySessions
{
    public class DeleteStudySessionHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public DeleteStudySessionHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(int id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var session = await context.StudySessions.FindAsync(id);
            context.StudySessions.Remove(session!);
            await context.SaveChangesAsync();
        }
    }
}
