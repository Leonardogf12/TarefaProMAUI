namespace TarefaPro.MAUI.MVVM.ViewModels
{
    public class PopupActionsViewModel : BaseViewModel
    {
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
            set=>SetProperty(ref _firstExecuted, value);
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
            set=>SetProperty(ref _titleFirstButton, value);
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


        public PopupActionsViewModel()
        {
        }

        public PopupActionsViewModel SetParametersOnPopup(Command firstCommand = null,
                                                          Command secondCommand = null,
                                                          Command thirdCommand = null,
                                                          string titleFirstButton = "",
                                                          string titleSecondButton = "",
                                                          string titleThirdButton = "")
        {
            return new PopupActionsViewModel
            {
                FirstCommand = firstCommand,
                SecondCommand = secondCommand,
                ThirdCommand = thirdCommand,
                TitleFirstButton = titleFirstButton,
                TitleSecondButton = titleSecondButton,
                TitleThirdButton = titleThirdButton    
            };
        }

        public void SetSelectedCommand(object parameter)
        {
            if(FirstExecuted)
            FirstCommand.Execute(parameter);

            if (SecondExecuted)
                SecondCommand.Execute(parameter);

            if (ThirdExecuted)
                ThirdCommand.Execute(parameter);
        }
    }
}
