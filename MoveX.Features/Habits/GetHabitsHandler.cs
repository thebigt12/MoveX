using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Habits
{
    public class GetHabitsHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public GetHabitsHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Habit>> Execute()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Habits
                .AsNoTracking()
                .OrderBy(h => h.Id)
                .ToListAsync();
        }
    }
}
