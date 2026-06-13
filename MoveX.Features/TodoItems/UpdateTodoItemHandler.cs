using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.TodoItems
{
    public class UpdateTodoItemHandler
    {
        private readonly MoveXContext _context;
        public UpdateTodoItemHandler(MoveXContext context) { _context = context; }

        public async Task Execute(TodoItem replacement)
        {
            var item = await _context.TodoItems.FindAsync(replacement.Id);
            item!.SubjectId = replacement.SubjectId;
            item.Description = replacement.Description;
            item.DueDate = replacement.DueDate;
            await _context.SaveChangesAsync();
        }
    }
}
