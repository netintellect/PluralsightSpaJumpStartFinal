﻿using System;
using System.Windows;

namespace Telerik.Windows.Examples.Map
{
    public static class URIHelper
    {
        public static Uri CurrentApplicationURL 
        {
            get
            {
                return System.Windows.Browser.HtmlPage.Document.DocumentUri;
            }
        }
    }
}