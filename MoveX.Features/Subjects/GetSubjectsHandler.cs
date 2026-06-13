using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Subjects
{
    public class GetSubjectsHandler
    {
        private readonly MoveXContext _context;
        public GetSubjectsHandler(MoveXContext context) { _context = context; }

        public async Task<List<Subject>> Execute()
        {
            return await _context.Subjects.ToListAsync();
        }
    }
}
