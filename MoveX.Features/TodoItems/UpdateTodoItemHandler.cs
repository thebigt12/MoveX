using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.TodoItems
{
    public class UpdateTodoItemHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public UpdateTodoItemHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(TodoItem replacement)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var item = await context.TodoItems.FindAsync(replacement.Id);
            item!.SubjectId = replacement.SubjectId;
            item.Description = replacement.Description;
            item.DueDate = replacement.DueDate;
            await context.SaveChangesAsync();
        }
    }
}
