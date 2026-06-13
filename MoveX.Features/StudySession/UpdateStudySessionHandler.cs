using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.StudySessions
{
    public class UpdateStudySessionHandler
    {
        private readonly MoveXContext _context;
        public UpdateStudySessionHandler(MoveXContext context) { _context = context; }

        public async Task Execute(StudySession replacement)
        {
            var session = await _context.StudySessions.FindAsync(replacement.Id);
            session!.SubjectId = replacement.SubjectId;
            session.Notes = replacement.Notes;
            await _context.SaveChangesAsync();
        }
    }
}
