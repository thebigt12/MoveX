using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Habits
{
    public class GetHabitsHandler
    {
        private readonly MoveXContext _context;
        public GetHabitsHandler(MoveXContext context) { _context = context; }

        public async Task<List<Habit>> Execute()
        {
            return await _context.Habits.ToListAsync();
        }
    }
}
