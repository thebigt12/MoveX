using MoveX.Database;

namespace MoveX.Features.TodoItems
{
    public class DeleteTodoItemHandler
    {
        private readonly MoveXContext _context;
        public DeleteTodoItemHandler(MoveXContext context) { _context = context; }

        public async Task Execute(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            _context.TodoItems.Remove(item!);
            await _context.SaveChangesAsync();
        }
    }
}
