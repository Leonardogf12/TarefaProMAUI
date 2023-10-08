using TarefaPro.MAUI.MVVM.Models;

namespace TarefaPro.MAUI.MVVM.ViewModels.Tasks
{
    [QueryProperty(nameof(SelectedTask), "SelectedTask")]
    public class EditTaskViewModel : BaseViewModel
    {
        private TaskModel _selectedTask;
        public TaskModel SelectedTask
        {
            get => _selectedTask;
            set=>SetProperty(ref _selectedTask, value); 
        }

        public EditTaskViewModel()
        {            
        }
    }
}
