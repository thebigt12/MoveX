using MoveX.Database;

namespace MoveX.Features.Finance
{
    public class DeleteTransactionHandler
    {
        private readonly MoveXContext _context;
        public DeleteTransactionHandler(MoveXContext context) { _context = context; }

        public async Task Execute(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transaction!);
            await _context.SaveChangesAsync();
        }
    }
}
