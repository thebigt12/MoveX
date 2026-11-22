using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Finance
{
    public class AddCategoryHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public AddCategoryHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Category category)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }
    }
}
