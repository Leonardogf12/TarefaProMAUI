using System.Collections.ObjectModel;
using TarefaPro.MAUI.MVVM.Models;
using TarefaPro.MAUI.Repositories.Tasks;

namespace TarefaPro.MAUI.MVVM.ViewModels.Tasks
{
    [QueryProperty(nameof(CategorySelected), "CategorySelected")]
    public class TaskiesViewModel : BaseViewModel
    {
        private readonly TaskRepository _taskRepository;

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


        public TaskiesViewModel()
        {
            _taskRepository = new TaskRepository();
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

            foreach (var x in taskies) TaskiesCollection.Add(x);

            TotalTaskies = TaskiesCollection.Count;
        }
    }
}
