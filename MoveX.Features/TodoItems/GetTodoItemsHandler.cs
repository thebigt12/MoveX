using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.TodoItems
{
    public class GetTodoItemsHandler
    {
        private readonly MoveXContext _context;
        public GetTodoItemsHandler(MoveXContext context) { _context = context; }

        public async Task<List<TodoItem>> Execute()
        {
            return await _context.TodoItems.ToListAsync();
        }
    }
}
