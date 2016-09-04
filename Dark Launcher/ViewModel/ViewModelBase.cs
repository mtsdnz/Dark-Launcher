using Dark_Launcher.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dark_Launcher.ViewModel
{
    public abstract class ViewModelBase : NotifiableBase
    {

        private static List<ViewModelBase> loadedViewModels;

        static ViewModelBase()
        {
            loadedViewModels = new List<ViewModelBase>();
        }

        public ViewModelBase()
        {
            lock (loadedViewModels)
            {
                loadedViewModels.RemoveAll(vm => vm.GetType() == GetType());
                loadedViewModels.Add(this);
            }
        }

        public static T InstanceOf<T>()
            where T : ViewModelBase
        {
            return (T)loadedViewModels.FirstOrDefault(vm => vm.GetType() == typeof(T)) ?? Activator.CreateInstance<T>();
        }

    }
}
