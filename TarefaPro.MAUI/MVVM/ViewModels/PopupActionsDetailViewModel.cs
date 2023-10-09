using TarefaPro.MAUI.MVVM.Models;

namespace TarefaPro.MAUI.MVVM.ViewModels
{
    [QueryProperty(nameof(SelectedTask), "SelectedTask")]
    public class PopupActionsDetailViewModel : BaseViewModel
    {
        private TaskModel _selectedTask;
        public TaskModel SelectedTask
        {
            get => _selectedTask;
            set => SetProperty(ref _selectedTask, value);
        }

        private Command _firstCommand;
        public Command FirstCommand
        {

            get => _firstCommand;
            set => SetProperty(ref _firstCommand, value);
        }


        private bool _firstExecuted;
        public bool FirstExecuted
        {
            get => _firstExecuted;
            set => SetProperty(ref _firstExecuted, value);
        }


        private Command _secondCommand;
        public Command SecondCommand
        {
            get => _secondCommand;
            set => SetProperty(ref _secondCommand, value);
        }


        private bool _secondExecuted;
        public bool SecondExecuted
        {
            get => _secondExecuted;
            set => SetProperty(ref _secondExecuted, value);
        }

        private Command _thirdCommand;
        public Command ThirdCommand
        {
            get => _thirdCommand;
            set => SetProperty(ref _thirdCommand, value);
        }


        private bool _thirdExecuted;
        public bool ThirdExecuted
        {
            get => _thirdExecuted;
            set => SetProperty(ref _thirdExecuted, value);
        }


        private string _titleFirstButton;
        public string TitleFirstButton
        {
            get => _titleFirstButton;
            set => SetProperty(ref _titleFirstButton, value);
        }


        private string _titleSecondButton;
        public string TitleSecondButton
        {
            get => _titleSecondButton;
            set => SetProperty(ref _titleSecondButton, value);
        }


        private string _titleThirdButton;
        public string TitleThirdButton
        {
            get => _titleThirdButton;
            set => SetProperty(ref _titleThirdButton, value);
        }

        private string _dateEvent;
        public string DateEvent
        {
            get => _dateEvent;
            set => SetProperty(ref _dateEvent, value);
        }


        private string _dateReminder;
        public string DateReminder
        {
            get => _dateReminder;
            set => SetProperty(ref _dateReminder, value);
        }


        private string _hourReminder;
        public string HourReminder
        {
            get => _hourReminder;
            set => SetProperty(ref _hourReminder, value);
        }


        private string _hourAndDateReminderFormated;
        public string HourAndDateReminderFormated
        {

            get => _hourAndDateReminderFormated;
            set => SetProperty(ref _hourAndDateReminderFormated, value);
        }


        public PopupActionsDetailViewModel()
        {            
        }

        public PopupActionsDetailViewModel SetParametersOnPopupActionsDetails(object parameter = null,
                                                                       Command firstCommand = null,
                                                                       string titleFirstButton = "")
        {
            SelectedTask = parameter as TaskModel;

            GetStringDatesFormated();

            return new PopupActionsDetailViewModel
            {
                FirstCommand = firstCommand,
                TitleFirstButton = titleFirstButton,
            };
        }



        private void GetStringDatesFormated()
        {
            DateEvent = SelectedTask.DateEvent.ToShortDateString();
            DateReminder = SelectedTask.DateTask.ToShortDateString();
            HourReminder = SelectedTask.HourTask.ToString("h'h 'm'm'");

            HourAndDateReminderFormated = $"{DateReminder} ás {HourReminder}";
        }
    }
}
