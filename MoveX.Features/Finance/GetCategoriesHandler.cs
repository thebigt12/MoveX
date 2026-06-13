using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Finance
{
    public class GetCategoriesHandler
    {
        private readonly MoveXContext _context;
        public GetCategoriesHandler(MoveXContext context) { _context = context; }

        public async Task<List<Category>> Execute()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
