using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using TarefaPro.MAUI.MVVM.Models;
using TarefaPro.MAUI.MVVM.ViewModels.Category;
using TarefaPro.MAUI.MVVM.Views.Components;
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

        PopupActionsViewModel PopupTask = new();

        Popup Popup = new();

        #region Properts

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


        private TaskModel _selectedTask;
        private TaskModel SelectedTask
        {
            get => _selectedTask;
            set => SetProperty(ref _selectedTask, value);
        }

        #endregion


        public Command SelectedTaskCommand { get; set; }
        public Command EditTaskCommand { get; private set; }

        public TaskiesViewModel(INavigationService navigationService)
        {
            _taskRepository = new TaskRepository();
            _navigationService = navigationService;

            SelectedTaskCommand = new Command<TaskModel>(OnSelectedTaskCommand);
            EditTaskCommand = new Command(OnEditTaskCommand);
        }      

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

        public async void OnSelectedTaskCommand(TaskModel model)
        {
            SelectedTask = model;

            Popup = new PopupActionsPage(PopupTask.SetParametersOnPopup(EditTaskCommand, null));

            await App.Current.MainPage.ShowPopupAsync(Popup);

            //HasSelectedCategory = false;
        }


        private async void OnEditTaskCommand()
        {
            Popup.Close();

            Dictionary<string, object> Parameters = new Dictionary<string, object>
            {
                { "SelectedTask", SelectedTask }
            };

            await _navigationService.NavigationToPageAsync<EditTaskPage>(Parameters);
        }

        private void CheckIfHasTaskies() => HasTaskies = TaskiesCollection.Count > 0 ? true : false;

        public async void OnAppearing()
        {
            await LoadTaskies();
            CheckIfHasTaskies();
        }

        public async Task RemoveAllTasks()
        {
            IsBusy = true;
            await _taskRepository.DeleteAllAsync();
            OnAppearing();
            IsBusy = false;

        }
    }
}
