using Microsoft.EntityFrameworkCore;
using MoveX.Database;

namespace MoveX.Features.Finance
{
    public class GetBalanceHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public GetBalanceHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<decimal> Execute()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var transactions = await context.Transactions.AsNoTracking().ToListAsync();
            decimal income = transactions.Where(t => !t.IsExpense).Sum(t => t.Amount);
            decimal expenses = transactions.Where(t => t.IsExpense).Sum(t => t.Amount);
            return income - expenses;
        }
    }
}
