using Microsoft.EntityFrameworkCore;
using MoveX.Database;
using MoveX.Domain;

namespace MoveX.Features.Finance
{
    public class GetTransactionsHandler
    {
        private readonly MoveXContext _context;
        public GetTransactionsHandler(MoveXContext context) { _context = context; }

        public async Task<List<Transaction>> Execute()
        {
            return await _context.Transactions.ToListAsync();
        }
    }
}
