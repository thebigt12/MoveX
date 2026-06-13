using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.StudySessions
{
    public class GetStudySessionsHandler
    {
        private readonly MoveXContext _context;
        public GetStudySessionsHandler(MoveXContext context) { _context = context; }

        public async Task<List<StudySession>> Execute()
        {
            return await _context.StudySessions.ToListAsync();
        }
    }
}
