using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.TodoItems
{
    public class GetTodoItemsHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public GetTodoItemsHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<TodoItem>> Execute()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.TodoItems
                .AsNoTracking()
                .Include(t => t.Subject)
                .OrderBy(t => t.IsCompleted)
                .ThenBy(t => t.DueDate == null)
                .ThenBy(t => t.DueDate)
                .ToListAsync();
        }
    }
}
