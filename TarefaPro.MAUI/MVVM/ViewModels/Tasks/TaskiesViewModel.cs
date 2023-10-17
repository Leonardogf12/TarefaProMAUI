using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using TarefaPro.MAUI.MVVM.Models;
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
        public Command DeleteTaskCommand { get; private set; }


        public TaskiesViewModel(INavigationService navigationService)
        {
            _taskRepository = new TaskRepository();
            _navigationService = navigationService;

            SelectedTaskCommand = new Command<TaskModel>(OnSelectedTaskCommand);
            EditTaskCommand = new Command(OnEditTaskCommand);
            DeleteTaskCommand = new Command(OnDeleteTaskCommand);
        }

        private async void OnDeleteTaskCommand()
        {
            try
            {
                Popup.Close();

                var question = await App.Current.MainPage.DisplayAlert("Excluir", "Deseja realmente excluir esta tarefa?", "Sim", "Não");

                if (question)
                {
                    IsBusy = true;

                    await Task.Delay(500);

                    var result = await _taskRepository.DeleteAsync(SelectedTask);

                    if (result > 0)                                        
                        await App.Current.MainPage.DisplayAlert("Sucesso", "Tarefa excluída com sucesso.", "Ok");
                    
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", $"Ocorreu um erro inesperado enquanto tentava excluir a tarefa {SelectedTask.Name}", "Ok");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await LoadTaskies();
                IsBusy = false;
            }

        }

        private async Task LoadTaskies()
        {
            IsBusy = true;

            TaskiesCollection.Clear();

            var taskies = await _taskRepository.GetAllAsync();

            var list = taskies.Where(x => x.CategoryId == CategorySelected.Id);

            foreach (var x in list) TaskiesCollection.Add(x);

            TotalTaskies = TaskiesCollection.Count;

            await Task.Delay(300);

            IsBusy = false;
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

            PopupActionsDetailViewModel PopupTask = new();

            Popup = new PopupActionsDetailPage(PopupTask.SetParametersOnPopupActionsDetails(firstCommand: EditTaskCommand,
                                                                                            secondCommand: DeleteTaskCommand,
                                                                                            titleFirstButton: "Editar",
                                                                                            titleSecondButton: "Excluir",
                                                                                            SelectedTask.DateEvent.ToShortDateString(),
                                                                                            GetRemiderFormated()));

            await App.Current.MainPage.ShowPopupAsync(Popup);
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
            await _taskRepository.DeleteAllAsync();
            OnAppearing();         
        }

        private string GetRemiderFormated()
        {
            if (!SelectedTask.IsReminder)
                return $"Não Definido";
            else
                return $"{SelectedTask.DateTask.ToShortDateString()} ás {SelectedTask.HourTask.ToString("h'h 'm'm'")}";
        }

    }
}
