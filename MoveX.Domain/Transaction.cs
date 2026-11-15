namespace MoveX.Domain
{
    public class Transaction
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public string Description { get; set; } = "";
        public decimal Amount { get; set; }
        public DateTime TimeOfPurchase { get; set; } = DateTime.Now;
        public bool IsExpense { get; set; }
    }
}
