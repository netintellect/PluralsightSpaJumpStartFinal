using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Telerik.Windows.Examples.TimeBar.FirstLook
{
    public class ServerInfo
    {
        public ServerInfo(DateTime date, int uniqueVisitors, int newVisitors, int sessions, int pageViews)
        {
            this.Date = date;
            this.UniqueVisitors = uniqueVisitors;
            this.NewVisitors = newVisitors;
            this.Sessions = sessions;
            this.PageViews = pageViews;
        }

        public DateTime Date { get; private set; }
        public int UniqueVisitors { get; private set; }
        public int NewVisitors { get; private set; }
        public int Sessions { get; private set; }
        public int PageViews { get; private set; }
    }
}
