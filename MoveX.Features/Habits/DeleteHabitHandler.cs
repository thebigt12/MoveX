using Microsoft.EntityFrameworkCore;
using MoveX.Database;

namespace MoveX.Features.Habits
{
    public class DeleteHabitHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public DeleteHabitHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(int id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var habit = await context.Habits.FindAsync(id);
            context.Habits.Remove(habit!);
            await context.SaveChangesAsync();
        }
    }
}
