using SQLite;
using TarefaPro.MAUI.MVVM.Models;

namespace TarefaPro.MAUI.Repositories.Category
{
    public class CategoryRepository : GenericRepository<CategoryModel>
    {
        private readonly SQLiteAsyncConnection _db;

        public CategoryRepository()
        {
            _db = new SQLiteAsyncConnection(App.dbPath);
        }

        public async Task<CategoryModel> GetCategoryWithNameExistentAsync(string name)
        {
            return await _db.Table<CategoryModel>().FirstOrDefaultAsync(x => x.Name.ToUpper().Equals(name.ToUpper()));
        }
    }
}
