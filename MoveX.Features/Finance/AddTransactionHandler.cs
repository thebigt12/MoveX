using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Finance
{
    public class AddTransactionHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public AddTransactionHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Transaction transaction)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            await context.Transactions.AddAsync(transaction);
            await context.SaveChangesAsync();
        }
    }
}
