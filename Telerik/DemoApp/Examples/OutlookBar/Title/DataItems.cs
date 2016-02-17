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
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Telerik.Windows.Examples.OutlookBar.Title
{
	public class DataItems : ObservableCollection<DataItem>
	{
		public DataItems()
		{
			DataItem mail = new DataItem();
			mail.Header = "Mail";
			mail.HeaderIcon = new BitmapImage(new Uri("/OutlookBar/Images/mailBig.png", UriKind.RelativeOrAbsolute));
			mail.Title = "Mail";
			mail.TitleIcon = new BitmapImage(new Uri("/OutlookBar/Images/mailBig.png", UriKind.RelativeOrAbsolute));
			mail.MinimizedIcon = new BitmapImage(new Uri("/OutlookBar/Images/mailSmall.png", UriKind.RelativeOrAbsolute));
			mail.Content = "Mail";
			this.Add(mail);

			DataItem folders = new DataItem();
			folders.Header = "Folders";
			folders.HeaderIcon = new BitmapImage(new Uri("/OutlookBar/Images/foldersBig.png", UriKind.RelativeOrAbsolute));
			folders.Title = "Folders";
			folders.TitleIcon = new BitmapImage(new Uri("/OutlookBar/Images/foldersBig.png", UriKind.RelativeOrAbsolute));
			folders.MinimizedIcon = new BitmapImage(new Uri("/OutlookBar/Images/foldersSmall.png", UriKind.RelativeOrAbsolute));
			folders.Content = "Folders";
			this.Add(folders);

			DataItem notes = new DataItem();
			notes.Header = "Notes";
			notes.HeaderIcon = new BitmapImage(new Uri("/OutlookBar/Images/notesBig.png", UriKind.RelativeOrAbsolute));
			notes.Title = "Notes";
			notes.TitleIcon = new BitmapImage(new Uri("/OutlookBar/Images/notesBig.png", UriKind.RelativeOrAbsolute));
			notes.MinimizedIcon = new BitmapImage(new Uri("/OutlookBar/Images/notesSmall.png", UriKind.RelativeOrAbsolute));
			notes.Content = "Content";
			this.Add(notes);
		}
	}
}
