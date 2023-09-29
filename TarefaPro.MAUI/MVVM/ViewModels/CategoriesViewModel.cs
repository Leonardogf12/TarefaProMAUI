using System.Collections.ObjectModel;
using TarefaPro.MAUI.MVVM.Models;
using TarefaPro.MAUI.Repositories.Category;

namespace TarefaPro.MAUI.MVVM.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {

        private readonly CategoryRepository _categoryRepository;

        private ObservableCollection<CategoryModel> _categoriesCollection = new();
        public ObservableCollection<CategoryModel> CategoriesCollection
        {
            get => _categoriesCollection;
            set => SetProperty(ref _categoriesCollection, value);
        }


        private bool _hasCategories = false;
        public bool HasCategories
        {
            get => _hasCategories;
            set
            {
                SetProperty(ref _hasCategories, value);
                HasNotCategories = !value;
            }

        }


        private bool _hasNotCategories = false;
        public bool HasNotCategories
        {
            get => _hasNotCategories;
            set => SetProperty(ref _hasNotCategories, value);

        }


        private int _totalCategories;
        public int TotalCategories
        {
            get => _totalCategories;
            set=>SetProperty(ref _totalCategories, value);
        }


        public CategoriesViewModel()
        {
            _categoryRepository = new CategoryRepository();           
        }

        public async Task LoadCategories()
        {
            CategoriesCollection.Clear();

            var categories = await _categoryRepository.GetAllAsync();

            foreach (var x in categories) CategoriesCollection.Add(x);

            TotalCategories = CategoriesCollection.Count;
        }
        
        public void CheckIfHasCategories()
        {
            HasCategories = CategoriesCollection.Count > 0 ? true : false;
        }

        public async void OnAppearing()
        {
            await LoadCategories();
           CheckIfHasCategories();
        }

        public async void RemoveAllCategories()
        {
            _ = await _categoryRepository.DeleteAllAsync();

            await LoadCategories();
        }
    }
}
