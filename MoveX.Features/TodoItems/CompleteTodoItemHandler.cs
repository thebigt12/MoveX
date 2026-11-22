using Microsoft.EntityFrameworkCore;
using MoveX.Database;

namespace MoveX.Features.TodoItems
{
    public class CompleteTodoItemHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public CompleteTodoItemHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(int id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var item = await context.TodoItems.FindAsync(id);
            item!.IsCompleted = true;
            await context.SaveChangesAsync();
        }
    }
}
