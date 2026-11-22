using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Habits
{
    public class UpdateHabitHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public UpdateHabitHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Habit replacement)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var habit = await context.Habits.FindAsync(replacement.Id);
            habit!.Subject = replacement.Subject;
            habit.IsBad = replacement.IsBad;
            await context.SaveChangesAsync();
        }
    }
}
