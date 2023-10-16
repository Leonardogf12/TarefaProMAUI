using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TarefaPro.MAUI.MVVM.Models
{
    public class BaseModelPropertChanged : INotifyPropertyChanged
    {        
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
