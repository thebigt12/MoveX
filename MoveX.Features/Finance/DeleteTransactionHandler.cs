using Microsoft.EntityFrameworkCore;
using MoveX.Database;

namespace MoveX.Features.Finance
{
    public class DeleteTransactionHandler
    {
        private readonly IDbContextFactory<MoveXContext> _contextFactory;

        public DeleteTransactionHandler(IDbContextFactory<MoveXContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(int id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var transaction = await context.Transactions.FindAsync(id);
            context.Transactions.Remove(transaction!);
            await context.SaveChangesAsync();
        }
    }
}
