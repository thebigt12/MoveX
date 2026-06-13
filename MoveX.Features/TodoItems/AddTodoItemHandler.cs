using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.TodoItems
{
    public class AddTodoItemHandler
    {
        private readonly MoveXContext _context;
        public AddTodoItemHandler(MoveXContext context) { _context = context; }

        public async Task Execute(TodoItem item)
        {
            await _context.TodoItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }
    }
}
