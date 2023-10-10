using SQLite;
using TarefaPro.MAUI.MVVM.Models;

namespace TarefaPro.MAUI.Repositories.Tasks
{
    public class TaskRepository : GenericRepository<TaskModel>
    {
        private readonly SQLiteAsyncConnection _db;

        public TaskRepository()
        {
            _db = new SQLiteAsyncConnection(App.dbPath);
        }

        public async Task<TaskModel> GetTaskWithNameExistentAsync(string name)
        {
            return await _db.Table<TaskModel>().FirstOrDefaultAsync(x => x.Name.ToUpper().Equals(name.ToUpper()));
        }
    }
}
