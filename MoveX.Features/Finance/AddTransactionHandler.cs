using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Finance
{
    public class AddTransactionHandler
    {
        private readonly MoveXContext _context;
        public AddTransactionHandler(MoveXContext context) { _context = context; }

        public async Task Execute(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
