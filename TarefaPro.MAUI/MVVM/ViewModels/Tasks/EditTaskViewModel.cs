using TarefaPro.MAUI.MVVM.Models;
using TarefaPro.MAUI.Repositories.Tasks;

namespace TarefaPro.MAUI.MVVM.ViewModels.Tasks
{
    [QueryProperty(nameof(SelectedTask), "SelectedTask")]
    public class EditTaskViewModel : BaseViewModel
    {
        private readonly TaskRepository _taskRepository;

        private TaskModel _selectedTask;
        public TaskModel SelectedTask
        {
            get => _selectedTask;
            set
            {
                SetProperty(ref _selectedTask, value);

                IsReminderTask = SelectedTask.IsReminder;
            }
        }

        private bool _isRemiderTask;
        public bool IsReminderTask
        {
            get => _isRemiderTask;
            set => SetProperty(ref _isRemiderTask, value);
        }


        private bool _isEnabledReminder = false;
        public bool IsEnabledReminder
        {
            get => _isEnabledReminder;
            set
            {
                SetProperty(ref _isEnabledReminder, value);

                if (value)
                {
                    BackgroundIsEnabled = (Style)App.Current.Resources["borderFormRemindeEnabled"];
                }
                else
                {
                    BackgroundIsEnabled = (Style)App.Current.Resources["borderFormRemindeDisabled"];
                }

            }
        }

        private Style _backgroundIsEnabled = (Style)App.Current.Resources["borderFormRemindeDisabled"];
        public Style BackgroundIsEnabled
        {
            get => _backgroundIsEnabled;
            set => SetProperty(ref _backgroundIsEnabled, value);
        }


        public EditTaskViewModel()
        {
            _taskRepository = new TaskRepository();
        }

        public async Task OnEditTaskCommand()
        {
            IsBusy = true;

            try
            {
                var taskEdited = (TaskModel)SelectedTask;

                SelectedTask.IsReminder = IsReminderTask;

                var result = await _taskRepository.UpdateAsync(taskEdited);

                if (result > 0)
                {
                    await App.Current.MainPage.DisplayAlert("Sucesso", "Tarefa editada com sucesso.", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await App.Current.MainPage.DisplayAlert("Tarefa", $"Ocorreu um erro durante a edição da Tarefa {SelectedTask.Name}.", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
