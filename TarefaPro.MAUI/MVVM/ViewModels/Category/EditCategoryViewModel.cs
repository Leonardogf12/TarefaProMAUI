using TarefaPro.MAUI.Controls;
using TarefaPro.MAUI.MVVM.Models;
using TarefaPro.MAUI.Repositories.Category;

namespace TarefaPro.MAUI.MVVM.ViewModels.Category
{
    [QueryProperty(nameof(SelectedCategory), "SelectedCategory")]
    public class EditCategoryViewModel : BaseViewModel
    {
        private readonly CategoryRepository _categoryRepository;


        private CategoryModel _selectedCategory;
        public CategoryModel SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                SetProperty(ref _selectedCategory, value);

                if (SelectedCategory != null)
                    SetLayoutPropertyOfCategorySelected();
            }
        }

        public EditCategoryViewModel()
        {
            _categoryRepository = new CategoryRepository();
            
            GetDefaultLayoutSettings();            
        }

        public async Task EditCategoryCommand()
        {
            IsBusy = true;

            try
            {
                var newCategory = (CategoryModel)SelectedCategory;
                newCategory.Color = ColorFrame;
                newCategory.IconName = IconSelected;

                var result = await _categoryRepository.UpdateAsync(newCategory);

                if (result > 0)
                    await App.Current.MainPage.DisplayAlert("Categoria", "Categoria editada com sucesso.", "OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await App.Current.MainPage.DisplayAlert("Categoria", "Ocorreu um erro durante a edição da categoria.", "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }

        private void SetLayoutPropertyOfCategorySelected()
        {
            BackgroundColorButtonNew = Color.FromArgb(SelectedCategory.Color);
           
            if (SelectedCategory.IconName.Equals(StringConstants.IconGreenName))
            {
                GreenCheckImageSource = ImageSource.FromFile(StringConstants.IconGreenName);
                IsGreenSelected = true;
                return;   
            }
    
            if (SelectedCategory.IconName.Equals(StringConstants.IconOrangeName))
            {
                GreenCheckImageSource = ImageSource.FromFile(StringConstants.IconOrangeName);
                IsOrangeSelected = true;
                return;
            }

            if (SelectedCategory.IconName.Equals(StringConstants.IconBlueName))
            {
                BlueCheckImageSource = ImageSource.FromFile(StringConstants.IconBlueName);
                IsBlueSelected = true;
                return;
            }

            if (SelectedCategory.IconName.Equals(StringConstants.IconYellowName))
            {
                YellowCheckImageSource = ImageSource.FromFile(StringConstants.IconYellowName);
                IsYellowSelected = true;
                return;
            }

            if (SelectedCategory.IconName.Equals(StringConstants.IconSalmonName))
            {
                SalmonCheckImageSource = ImageSource.FromFile(StringConstants.IconSalmonName);
                IsSalmonSelected = true;
                return;
            }
        }
       
    }
}
