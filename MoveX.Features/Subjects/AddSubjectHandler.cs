using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Subjects
{
    public class AddSubjectHandler
    {
        private readonly MoveXContext _context;
        public AddSubjectHandler(MoveXContext context) { _context = context; }

        public async Task Execute(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
        }
    }
}
