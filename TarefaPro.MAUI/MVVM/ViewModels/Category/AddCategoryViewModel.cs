using TarefaPro.MAUI.Controls;
using TarefaPro.MAUI.MVVM.Models;
using TarefaPro.MAUI.Repositories.Category;

namespace TarefaPro.MAUI.MVVM.ViewModels.Category
{
    public class AddCategoryViewModel : BaseViewModel
    {
        private readonly CategoryRepository _categoryRepository;        

        public AddCategoryViewModel()
        {
            _categoryRepository = new CategoryRepository();

            GetDefaultLayoutSettings();
        }
       
        public async Task AddCategory()
        {
            IsBusy = true;
            
            try
            {
                var category = new CategoryModel();

                category.Name = Name;
                category.Description = Description;
                category.Color = ColorFrame ?? StringConstants.ColorDefaultHex;
                category.IconName = IconSelected ?? StringConstants.IconDefaultName;

                var exist = await CheckIfExistCategory(category.Name);
                if (exist)
                {
                    await App.Current.MainPage.DisplayAlert("Ops", "Já existe uma categoria com este nome. Favor verificar.", "OK");
                    return;
                }

                var result = await _categoryRepository.SaveAsync(category);

                if (result > 0)
                    await App.Current.MainPage.DisplayAlert("Categoria", "Categoria salva com sucesso.", "OK");              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await App.Current.MainPage.DisplayAlert("Categoria", "Ocorreu um erro durante o registro da categoria.", "OK");                
            }
            finally
            {
                IsBusy = false;
            }                              
        }

        private async Task<bool> CheckIfExistCategory(string name)
        {
            var result = await _categoryRepository.GetCategoryWithNameExistentAsync(name);
            
            if(result == null) return false;

            return true;            
        }

    }
}
