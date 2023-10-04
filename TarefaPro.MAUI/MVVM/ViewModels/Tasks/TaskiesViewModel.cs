using System.Collections.ObjectModel;
using TarefaPro.MAUI.MVVM.Models;
using TarefaPro.MAUI.MVVM.Views.Tasks;
using TarefaPro.MAUI.Repositories.Tasks;
using TarefaPro.MAUI.Services;

namespace TarefaPro.MAUI.MVVM.ViewModels.Tasks
{
    [QueryProperty(nameof(CategorySelected), "CategorySelected")]
    public class TaskiesViewModel : BaseViewModel
    {
        private readonly TaskRepository _taskRepository;

        private readonly INavigationService _navigationService;


        private CategoryModel _categorySelected;
        public CategoryModel CategorySelected
        {
            get => _categorySelected;
            set => SetProperty(ref _categorySelected, value);
        }


        private bool _hasTaskies = false;
        public bool HasTaskies
        {
            get => _hasTaskies;
            set
            {
                SetProperty(ref _hasTaskies, value);
                HasNotTaskies = !value;
            }
        }


        private bool _hasNotTaskies;
        public bool HasNotTaskies
        {
            get => _hasNotTaskies;
            set => SetProperty(ref _hasNotTaskies, value);
        }


        private ObservableCollection<TaskModel> _taskiesCollection = new();
        public ObservableCollection<TaskModel> TaskiesCollection
        {
            get => _taskiesCollection;
            set => SetProperty(ref _taskiesCollection, value);
        }

        private int _totalTaskies;
        public int TotalTaskies
        {
            get => _totalTaskies;
            set => SetProperty(ref _totalTaskies, value);
        }


        public TaskiesViewModel(INavigationService navigationService)
        {
            _taskRepository = new TaskRepository();
            _navigationService = navigationService;
        }


        public async void OnAppearing()
        {
            await LoadTaskies();
            CheckIfHasTaskies();
        }

        private void CheckIfHasTaskies() => HasTaskies = TaskiesCollection.Count > 0 ? true : false;


        private async Task LoadTaskies()
        {
            TaskiesCollection.Clear();

            var taskies = await _taskRepository.GetAllAsync();

            var list = taskies.Where(x => x.CategoryId == CategorySelected.Id);

            foreach (var x in list) TaskiesCollection.Add(x);

            TotalTaskies = TaskiesCollection.Count;
        }

        public async void GotoAddTaskPage()
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>
            {
                { "CategorySelectedToTask", CategorySelected }
            };

            await _navigationService.NavigationToPageAsync<AddTaskPage>(parameters: Parameters);
        }
    }
}
