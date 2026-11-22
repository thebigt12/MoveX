using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Subjects
{
    public class GetSubjectsHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public GetSubjectsHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Subject>> Execute()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Subjects
                .AsNoTracking()
                .OrderBy(s => s.Name)
                .ToListAsync();
        }
    }
}
