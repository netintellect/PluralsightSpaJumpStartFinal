using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;
using System.Windows;
using System;

namespace Telerik.Windows.Examples.Barcode.QRCodeVCard
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

            QRCode1.Version = 9;
            QRCode1.Text = @"BEGIN:VCARD
VERSION:2.1
N:Steven Buchannan
TEL;WORK;VOICE:+44.71.555.48.48
ADR;WORK:;;14 Garrett Hill, SW 1 8JR, London, UK
EMAIL;PREF;INTERNET:buchannan@company.com
END:VCARD";
        }
    }
}
