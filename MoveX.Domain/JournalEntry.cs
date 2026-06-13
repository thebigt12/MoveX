namespace MoveX.Domain
{
    public class JournalEntry
    {
        public int Id { get; set; }
        public DateTime TimeOfEntry { get; set; } = DateTime.Now;
        public string Text { get; set; } = "";
        public string Mood { get; set; } = "";
    }
}
