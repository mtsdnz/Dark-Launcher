using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Interfaces
{
    interface ICryptography
    {
        string Encrypt(string text, string key);
        string Decrypt(string text, string key);
    }
}
