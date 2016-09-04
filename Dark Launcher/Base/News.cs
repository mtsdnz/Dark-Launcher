using Dark_Launcher.Constants;
using System;

namespace Dark_Launcher.Base
{
    public struct News
    {
        public string Date { get; set; }

        private Uri url;
        public string Url
        {
            get { return url.ToString(); }
            set { url = new Uri(value); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                value = (value.Length > LauncherConstants.NewsMaxTitleLength) ? value.Substring(0, LauncherConstants.NewsMaxTitleLength) + "..." : value;
                title = "- " + value;
            }
        }
    }
}
