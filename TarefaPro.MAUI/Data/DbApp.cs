using SQLite;
using TarefaPro.MAUI.MVVM.Models;

namespace TarefaPro.MAUI.Data
{
    public class DbApp
    {
        private readonly SQLiteAsyncConnection _dbApp;

        public DbApp(string path)
        {
            _dbApp = new SQLiteAsyncConnection(path);
            _dbApp.CreateTableAsync<CategoryModel>();
            _dbApp.CreateTableAsync<TaskModel>();
        }
    }
}
