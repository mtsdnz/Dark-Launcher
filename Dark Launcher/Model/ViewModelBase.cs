using System;
using System.Collections.Generic;
using System.Linq;

namespace Dark_Launcher.Model
{
    internal abstract class ViewModelBase : NotifiableBase
    {
        private static readonly List<ViewModelBase> LoadedViewModels;

        static ViewModelBase()
        {
            LoadedViewModels = new List<ViewModelBase>();
        }

        protected ViewModelBase()
        {
            lock (LoadedViewModels)
            {
                LoadedViewModels.RemoveAll(vm => vm.GetType() == GetType());
                LoadedViewModels.Add(this);
            }
        }

        public static T InstanceOf<T>() where T : ViewModelBase
        {
            lock (LoadedViewModels)
            {
                return (T)LoadedViewModels.FirstOrDefault(vm => vm.GetType() == typeof(T)) ?? Activator.CreateInstance<T>();
            }
        }
    }
}
