using System.Collections.Generic;

namespace Dark_Launcher.Base
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public Dictionary<int, string> Strings = new Dictionary<int, string>();
    }
}
