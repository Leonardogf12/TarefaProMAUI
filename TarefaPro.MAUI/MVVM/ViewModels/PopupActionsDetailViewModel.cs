namespace TarefaPro.MAUI.MVVM.ViewModels
{
    public class PopupActionsDetailViewModel : BaseViewModel
    {       
        private Command _firstCommand;
        public Command FirstCommand
        {

            get => _firstCommand;
            set => SetProperty(ref _firstCommand, value);
        }


        private Command _secondCommand;
        public Command SecondCommand
        {
            get => _secondCommand;
            set => SetProperty(ref _secondCommand, value);
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


        private string _dateEvent;
        public string DateEvent
        {
            get => _dateEvent;
            set => SetProperty(ref _dateEvent, value);
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

        public PopupActionsDetailViewModel SetParametersOnPopupActionsDetails(Command firstCommand = null,
                                                                              Command secondCommand = null,
                                                                              string titleFirstButton = "",
                                                                              string titleSecondButton = "",
                                                                              string dateEvent = "",
                                                                              string remider = "")
        {            
            return new PopupActionsDetailViewModel
            {
                FirstCommand = firstCommand,
                SecondCommand = secondCommand,
                TitleFirstButton = titleFirstButton,
                TitleSecondButton = titleSecondButton,
                DateEvent = dateEvent,
                HourAndDateReminderFormated = remider
            };
        }       
    }
}
