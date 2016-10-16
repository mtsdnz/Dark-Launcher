using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace LauncherUpdater.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected ViewModelBase()
        {
            if (!Loaded.Contains(this))
                Loaded.Add(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private static readonly List<ViewModelBase> Loaded = new List<ViewModelBase>();
        public static T InstanceOf<T>() where T : ViewModelBase
        {
            return Loaded.OfType<T>().FirstOrDefault() ?? Activator.CreateInstance<T>();
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
