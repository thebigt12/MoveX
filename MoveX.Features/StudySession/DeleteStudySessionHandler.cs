using MoveX.Database;

namespace MoveX.Features.StudySessions
{
    public class DeleteStudySessionHandler
    {
        private readonly MoveXContext _context;
        public DeleteStudySessionHandler(MoveXContext context) { _context = context; }

        public async Task Execute(int id)
        {
            var session = await _context.StudySessions.FindAsync(id);
            _context.StudySessions.Remove(session!);
            await _context.SaveChangesAsync();
        }
    }
}
