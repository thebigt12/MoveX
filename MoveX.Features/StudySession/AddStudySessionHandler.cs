using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.StudySessions
{
    public class AddStudySessionHandler
    {
        private readonly MoveXContext _context;
        public AddStudySessionHandler(MoveXContext context) { _context = context; }

        public async Task Execute(StudySession session)
        {
            await _context.StudySessions.AddAsync(session);
            await _context.SaveChangesAsync();
        }
    }
}
