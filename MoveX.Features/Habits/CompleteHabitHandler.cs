using Microsoft.EntityFrameworkCore;
using MoveX.Database;

namespace MoveX.Features.Habits
{
    public class CompleteHabitHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public CompleteHabitHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(int id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var habit = await context.Habits.FindAsync(id);

            var today = DateOnly.FromDateTime(DateTime.Today);
            DateOnly? lastCompleted = habit!.LastCompleted is null
                ? null
                : DateOnly.FromDateTime(habit.LastCompleted.Value);

            // Heute schon erledigt: nichts tun
            if (lastCompleted == today)
            {
                return;
            }

            // Gestern erledigt: Streak läuft weiter. Sonst beginnt ein neuer Streak.
            habit.Streak = lastCompleted == today.AddDays(-1) ? habit.Streak + 1 : 1;
            habit.LastCompleted = DateTime.Now;
            await context.SaveChangesAsync();
        }
    }
}
