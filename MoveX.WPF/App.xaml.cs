using Microsoft.Extensions.DependencyInjection;
using MoveX.Database;
using MoveX.Features.Finance;
using MoveX.Features.Goals;
using MoveX.Features.Habits;
using MoveX.Features.Journal;
using MoveX.Features.StudySessions;
using MoveX.Features.Subjects;
using MoveX.Features.TimeEntries;
using MoveX.Features.TodoItems;
using System.Windows;

namespace MoveX.WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            services.AddDbContextFactory<MoveXContext>();

            // Habits
            services.AddTransient<AddHabitHandler>();
            services.AddTransient<DeleteHabitHandler>();
            services.AddTransient<CompleteHabitHandler>();
            services.AddTransient<GetHabitsHandler>();
            services.AddTransient<UpdateHabitHandler>();

            // Finance
            services.AddTransient<AddTransactionHandler>();
            services.AddTransient<DeleteTransactionHandler>();
            services.AddTransient<GetTransactionsHandler>();
            services.AddTransient<GetBalanceHandler>();
            services.AddTransient<AddCategoryHandler>();
            services.AddTransient<GetCategoriesHandler>();

            // Study Sessions
            services.AddTransient<AddStudySessionHandler>();
            services.AddTransient<DeleteStudySessionHandler>();
            services.AddTransient<GetStudySessionsHandler>();
            services.AddTransient<UpdateStudySessionHandler>();
            services.AddTransient<GetTotalTimeStudiedHandler>();

            // Goals
            services.AddTransient<AddGoalHandler>();
            services.AddTransient<DeleteGoalHandler>();
            services.AddTransient<GetGoalsHandler>();
            services.AddTransient<UpdateGoalHandler>();
            services.AddTransient<CompleteGoalHandler>();

            // Journal
            services.AddTransient<AddJournalEntryHandler>();
            services.AddTransient<DeleteJournalEntryHandler>();
            services.AddTransient<GetJournalEntriesHandler>();

            // Time Entries
            services.AddTransient<AddTimeEntryHandler>();
            services.AddTransient<DeleteTimeEntryHandler>();
            services.AddTransient<GetTimeEntriesHandler>();

            // Todo Items
            services.AddTransient<AddTodoItemHandler>();
            services.AddTransient<DeleteTodoItemHandler>();
            services.AddTransient<GetTodoItemsHandler>();
            services.AddTransient<UpdateTodoItemHandler>();
            services.AddTransient<CompleteTodoItemHandler>();

            // Subjects
            services.AddTransient<AddSubjectHandler>();
            services.AddTransient<GetSubjectsHandler>();

            services.AddSingleton<MainWindow>();

            var serviceProvider = services.BuildServiceProvider();
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
