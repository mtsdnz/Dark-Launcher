using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace LauncherUpdater.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase()
        {
            if (!loaded.Contains(this))
                loaded.Add(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private static List<ViewModelBase> loaded = new List<ViewModelBase>();
        public static T InstanceOf<T>() where T : ViewModelBase
        {
            return loaded.OfType<T>().FirstOrDefault() ?? Activator.CreateInstance<T>();
        }

        protected void OnPropertyChanged(string propertyName = null)
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
