using System.ComponentModel;
namespace Dark_Launcher.Model
{
    internal abstract class NotifiableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetAndNotify<T>(ref T field, T value, string propertyName = null)
        {
            if (ReferenceEquals(field, value))
                return;

            field = value;

            OnPropertyChanged(propertyName);
        }
    }
}
