using Dark_Launcher.Constants;
using System;

namespace Dark_Launcher.Base
{
    public sealed class News
    {
        public string Date { get; set; }

        private Uri _url;
        public string Url
        {
            get { return _url.ToString(); }
            set { _url = new Uri(value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                value = value.Length > LauncherConstants.NewsMaxTitleLength ? value.Substring(0, LauncherConstants.NewsMaxTitleLength) + "..." : value;
                _title = "- " + value;
            }
        }
    }
}
