using Microsoft.EntityFrameworkCore;
using MoveX.Database;

namespace MoveX.Features.Finance
{
    public class GetBalanceHandler
    {
        private readonly MoveXContext _context;
        public GetBalanceHandler(MoveXContext context) { _context = context; }

        public async Task<decimal> Execute()
        {
            var transactions = await _context.Transactions.ToListAsync();
            decimal income = transactions.Where(t => !t.IsExpense).Sum(t => t.Amount);
            decimal expenses = transactions.Where(t => t.IsExpense).Sum(t => t.Amount);
            return income - expenses;
        }
    }
}
