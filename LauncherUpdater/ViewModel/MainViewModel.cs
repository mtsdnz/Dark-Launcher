using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace LauncherUpdater.ViewModel
{
    public sealed class MainViewModel
    {
        public Dispatcher UIDispatcher;

        public MainViewModel()
        {
            Debug.Print("initialized!");
        }
    }
}
