using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using TarefaPro.MAUI.MVVM.Models;
using TarefaPro.MAUI.MVVM.Views.Category;
using TarefaPro.MAUI.MVVM.Views.Components.Category;
using TarefaPro.MAUI.MVVM.Views.Tasks;
using TarefaPro.MAUI.Repositories.Category;
using TarefaPro.MAUI.Repositories.Tasks;
using TarefaPro.MAUI.Services;

namespace TarefaPro.MAUI.MVVM.ViewModels.Category
{
    public class CategoriesViewModel : BaseViewModel
    {
        private readonly CategoryRepository _categoryRepository;

        private readonly TaskRepository _taskRepository;


        private readonly INavigationService _navigationService;

        PopupCategoriesViewModel PopupCategory = new();

        Popup Popup = new();

        #region Properts

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


        private CategoryModel _selectedCategory;
        private CategoryModel SelectedCategory
        {
            get => _selectedCategory;
            set=>SetProperty( ref _selectedCategory, value);
        }


        private bool _hasSelectedCategory = false;
        public bool HasSelectedCategory
        {
            get => _hasSelectedCategory;
            set=> SetProperty(ref _hasSelectedCategory, value);
        }


        private int _totalTaskiesOfCategory;
        public int TotalTaskiesOfCategory
        {
            get => _totalTaskiesOfCategory;
            set => SetProperty(ref _totalTaskiesOfCategory, value);   
        }

        #endregion

        #region Commands

        public Command EditCategoryCommand { get; set; }

        public Command TaskOfCategoryCommand { get; set; }

        public Command SelectedCategoryCommand { get; set; }

        #endregion


        public CategoriesViewModel(INavigationService navigationService)
       
        {
           _navigationService = navigationService;

            _categoryRepository = new CategoryRepository();

            _taskRepository = new TaskRepository();

            SelectedCategoryCommand = new Command<CategoryModel>(OnSelectedCategoryCommand);
            EditCategoryCommand = new Command(OnEditCategoryCommand);
            TaskOfCategoryCommand = new Command(OnTaskOfCategoryCommand);
        }


        private async void OnSelectedCategoryCommand(CategoryModel model)
        {
            SelectedCategory = model;

            Popup = new PopupCategoriesPage(PopupCategory.SetParametersOnPopup(EditCategoryCommand, TaskOfCategoryCommand));

            await App.Current.MainPage.ShowPopupAsync(Popup);

            HasSelectedCategory = false;
        }

        public async Task LoadCategories()
        {
            CategoriesCollection.Clear();

            var categories = await _categoryRepository.GetAllAsync();

            foreach (var x in categories) CategoriesCollection.Add(x);

            TotalCategories = CategoriesCollection.Count;          
        }
        
        public void CheckIfHasCategories()=> HasCategories = CategoriesCollection.Count > 0 ? true : false;
        
        public async void OnAppearing()
        {
            await LoadCategories();
            CheckIfHasCategories();
            await GetCountTaskiesOfCategory();
        }

        private async Task GetCountTaskiesOfCategory()
        {
            var taskies = await _taskRepository.GetAllAsync();
            var categories = CategoriesCollection.ToList();

            var test = new List<TaskModel>();

            test = taskies..Select(x=>x.CategoryId).Where(x=>x.)

            TotalTaskiesOfCategory = 
        }

        public async void RemoveAllCategories()
        {
            _ = await _categoryRepository.DeleteAllAsync();

            OnAppearing();
        }

        public void OpenPopupActions() => PopupCategory.SetParametersOnPopup(EditCategoryCommand, TaskOfCategoryCommand);       

        private async void OnTaskOfCategoryCommand()
        {          
            Popup.Close();
            
            Dictionary<string, object> Parameters = new Dictionary<string, object>
            {
                { "CategorySelected", SelectedCategory }
            };

            await _navigationService.NavigationToPageAsync<TaskiesPage>(parameters: Parameters);
        }

        private async  void OnEditCategoryCommand()
        {            
            Popup.Close();

            Dictionary<string, object> Parameters = new Dictionary<string, object>
            {
                { "SelectedCategory", SelectedCategory }
            };

            await _navigationService.NavigationToPageAsync<EditCategoryPage>(Parameters);           
        }      
    }
}
