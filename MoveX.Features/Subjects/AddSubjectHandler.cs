using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Subjects
{
    public class AddSubjectHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public AddSubjectHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Subject subject)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            await context.Subjects.AddAsync(subject);
            await context.SaveChangesAsync();
        }
    }
}
