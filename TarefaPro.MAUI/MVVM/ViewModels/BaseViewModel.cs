using System.ComponentModel;
using System.Runtime.CompilerServices;
using TarefaPro.MAUI.Controls;

namespace TarefaPro.MAUI.MVVM.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Common Porperts 

        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }


        private bool _isGreenSelected;
        public bool IsGreenSelected
        {
            get => _isGreenSelected;
            set
            {
                SetProperty(ref _isGreenSelected, value);

                if (value)
                {
                    IsBlueSelected = false;
                    IsSalmonSelected = false;
                    IsYellowSelected = false;
                    IsOrangeSelected = false;
                }
            }
        }


        private bool _isBlueSelected;
        public bool IsBlueSelected
        {
            get => _isBlueSelected;
            set
            {
                SetProperty(ref _isBlueSelected, value);

                if (value)
                {
                    IsGreenSelected = false;
                    IsSalmonSelected = false;
                    IsYellowSelected = false;
                    IsOrangeSelected = false;
                }
            }
        }


        private bool _isSalmonSelected;
        public bool IsSalmonSelected
        {
            get => _isSalmonSelected;
            set
            {
                SetProperty(ref _isSalmonSelected, value);

                if (value)
                {
                    IsGreenSelected = false;
                    IsBlueSelected = false;
                    IsYellowSelected = false;
                    IsOrangeSelected = false;
                }
            }
        }


        private bool _isYellowSelected;
        public bool IsYellowSelected
        {
            get => _isYellowSelected;
            set
            {
                SetProperty(ref _isYellowSelected, value);

                if (value)
                {
                    IsGreenSelected = false;
                    IsBlueSelected = false;
                    IsSalmonSelected = false;
                    IsOrangeSelected = false;
                }
            }
        }


        private bool _isOrangeSelected;
        public bool IsOrangeSelected
        {
            get => _isOrangeSelected;
            set
            {
                SetProperty(ref _isOrangeSelected, value);

                if (value)
                {
                    IsGreenSelected = false;
                    IsBlueSelected = false;
                    IsSalmonSelected = false;
                    IsYellowSelected = false;
                }
            }
        }


        private ImageSource _greenCheckImageSource;
        public ImageSource GreenCheckImageSource
        {
            get => _greenCheckImageSource;
            set => SetProperty(ref _greenCheckImageSource, value);


        }


        private ImageSource _blueCheckImageSource;
        public ImageSource BlueCheckImageSource
        {
            get => _blueCheckImageSource;
            set => SetProperty(ref _blueCheckImageSource, value);

        }


        private ImageSource _salmonCheckImageSource;
        public ImageSource SalmonCheckImageSource
        {
            get => _salmonCheckImageSource;
            set => SetProperty(ref _salmonCheckImageSource, value);

        }


        private ImageSource _yellowCheckImageSource;
        public ImageSource YellowCheckImageSource
        {
            get => _yellowCheckImageSource;
            set => SetProperty(ref _yellowCheckImageSource, value);

        }


        private ImageSource _orangeCheckImageSource;
        public ImageSource OrangeCheckImageSource
        {
            get => _orangeCheckImageSource;
            set => SetProperty(ref _orangeCheckImageSource, value);

        }


        private Color _backgroundColorButtonNew;
        public Color BackgroundColorButtonNew
        {
            get => _backgroundColorButtonNew;
            set => SetProperty(ref _backgroundColorButtonNew, value);

        }


        private string _colorFrame;
        public string ColorFrame
        {
            get => _colorFrame;
            set => SetProperty(ref _colorFrame, value);
        }


        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }


        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }


        private string _iconSelected;
        public string IconSelected
        {
            get => _iconSelected;
            set => SetProperty(ref _iconSelected, value);
        }

        #endregion

        public void GetDefaultLayoutSettings()
        {
            GreenCheckImageSource = ImageSource.FromFile("green_not_check");
            BlueCheckImageSource = ImageSource.FromFile("blue_not_check");
            SalmonCheckImageSource = ImageSource.FromFile("salmon_not_check");
            YellowCheckImageSource = ImageSource.FromFile("yellow_not_check");
            OrangeCheckImageSource = ImageSource.FromFile("orange_not_check");
            BackgroundColorButtonNew = Color.FromArgb("#919191");

            IsGreenSelected = false;
            IsBlueSelected = false;
            IsSalmonSelected = false;
            IsYellowSelected = false;
            IsOrangeSelected = false;

            IconSelected = StringConstants.IconDefaultName;
            ColorFrame = StringConstants.ColorDefaultHex;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            var change = PropertyChanged;
            
            if (change == null) return;

            change.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected bool SetProperty<T>(ref T backingStore, 
                                        T value,
                                        [CallerMemberName] string name = "",
                                        Action onChange = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChange?.Invoke();
            OnPropertyChanged(name);
            return true;
        }
        #endregion
    }
}
