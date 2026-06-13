using MoveX.Database;

namespace MoveX.Features.TodoItems
{
    public class CompleteTodoItemHandler
    {
        private readonly MoveXContext _context;
        public CompleteTodoItemHandler(MoveXContext context) { _context = context; }

        public async Task Execute(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            item!.IsCompleted = true;
            await _context.SaveChangesAsync();
        }
    }
}
