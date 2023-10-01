namespace TarefaPro.MAUI.MVVM.ViewModels.Category
{
    public class PopupCategoriesViewModel : BaseViewModel
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

        public PopupCategoriesViewModel()
        {
        }

        public PopupCategoriesViewModel SetParametersOnPopup(Command firstCommand,
                                                             Command secondCommand)
        {
            return new PopupCategoriesViewModel
            {
                FirstCommand = firstCommand,
                SecondCommand = secondCommand
            };
        }
    }
}
