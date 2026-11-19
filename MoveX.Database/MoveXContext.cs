using Microsoft.EntityFrameworkCore;
using MoveX.Domain;

namespace MoveX.Database
{
    public class MoveXContext : DbContext
    {
        public static readonly string DatabasePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MoveX", "movex.db");

        public MoveXContext()
        {
        }

        public MoveXContext(DbContextOptions<MoveXContext> options) : base(options)
        {
        }

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
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(DatabasePath)!);
            optionsBuilder.UseSqlite($"Data Source={DatabasePath}");
        }
    }
}
