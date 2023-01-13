using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using AssignmentTrackerApp.Models;

namespace AssignmentTrackerApp.Data
{
    public class AssignmentDbContext
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<AssignmentDbContext> Instance = new AsyncLazy<AssignmentDbContext>(async () =>
        {
            var instance = new AssignmentDbContext();
            CreateTableResult result = await Database.CreateTableAsync<Assignment>();
            return instance;
        });

        public AssignmentDbContext()
        {
            Database = new SQLiteAsyncConnection(AssignmentDbConnection.DatabasePath, AssignmentDbConnection.Flags);
        }

        public Task<List<Assignment>> GetAssignmentsAsync()
        {
            return Database.Table<Assignment>().ToListAsync();
        }

        public Task<List<Assignment>> GetAssignmentsNotDoneAsync()
        {
            return Database.QueryAsync<Assignment>("SELECT * FROM [Assignment] WHERE [Completed] = 0");
        }

        public Task<Assignment> GetAssignmentAsync(int id)
        {
            return Database.Table<Assignment>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveAssignmentAsync(Assignment assignment)
        {
            if (assignment.Id != 0)
            {
                return Database.UpdateAsync(assignment);
            }
            else
            {
                return Database.InsertAsync(assignment);
            }
        }

        public Task<int> DeleteAssignmentAsync(Assignment assignment)
        {
            return Database.DeleteAsync(assignment);
        }
    }
}
