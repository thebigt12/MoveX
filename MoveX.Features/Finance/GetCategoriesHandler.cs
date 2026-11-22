using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Finance
{
    public class GetCategoriesHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public GetCategoriesHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Category>> Execute()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Categories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToListAsync();
        }
    }
}
