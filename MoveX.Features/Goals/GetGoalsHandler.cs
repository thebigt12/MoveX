using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Goals
{
    public class GetGoalsHandler
    {
        private readonly MoveXContext _context;
        public GetGoalsHandler(MoveXContext context) { _context = context; }

        public async Task<List<Goal>> Execute()
        {
            return await _context.Goals.ToListAsync();
        }
    }
}
