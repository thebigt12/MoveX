using Microsoft.EntityFrameworkCore;
using MoveX.Domain;

namespace MoveX.Database
{
    public class MoveXContext : DbContext
    {
        public DbSet<Habit> Habits { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<StudySession> StudySessions { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MoveX", "movex.db");
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            optionsBuilder.UseSqlite($"Data Source={path}");
        }
    }
}
