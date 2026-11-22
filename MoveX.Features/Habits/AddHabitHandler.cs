using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Habits
{
    public class AddHabitHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public AddHabitHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Habit habit)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            await context.Habits.AddAsync(habit);
            await context.SaveChangesAsync();
        }
    }
}
