using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Finance
{
    public class GetTransactionsHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public GetTransactionsHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Transaction>> Execute()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Transactions
                .AsNoTracking()
                .Include(t => t.Category)
                .OrderByDescending(t => t.TimeOfPurchase)
                .ToListAsync();
        }
    }
}
