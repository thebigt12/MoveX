using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Finance
{
    public class AddCategoryHandler
    {
        private readonly MoveXContext _context;
        public AddCategoryHandler(MoveXContext context) { _context = context; }

        public async Task Execute(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
    }
}
