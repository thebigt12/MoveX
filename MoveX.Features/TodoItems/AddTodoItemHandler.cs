using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.TodoItems
{
    public class AddTodoItemHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public AddTodoItemHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(TodoItem item)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            await context.TodoItems.AddAsync(item);
            await context.SaveChangesAsync();
        }
    }
}
