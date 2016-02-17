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

namespace Examples.OutlookBar.CS
{
	public class MailMessages : ObservableCollection<Message>
	{
		public MailMessages()
		{
			Message mailMessage1 = new Message();
			mailMessage1.From = "Nancy Davolio";
			mailMessage1.Title = "Summer product updates";
			mailMessage1.Sent = "Mon 31-Aug-09";
			mailMessage1.MessageContent = new BitmapImage(new Uri(@"../Images/OutlookBar/letter1.png", UriKind.RelativeOrAbsolute)); ;
			Add(mailMessage1);

			Message mailMessage2 = new Message();
			mailMessage2.From = "Janet Leverling";
			mailMessage2.Title = "Silverlight Contest";
			mailMessage2.Sent = "Wed 19-Aug-09";
			mailMessage2.MessageContent = new BitmapImage(new Uri(@"../Images/OutlookBar/letter2.png", UriKind.RelativeOrAbsolute)); ;
			Add(mailMessage2);

			Message mailMessage3 = new Message();
			mailMessage3.From = "Robert King";
			mailMessage3.Title = "OpenAccess class tickets";
			mailMessage3.Sent = "Sat 08-Aug-09";
			mailMessage3.MessageContent = new BitmapImage(new Uri(@"../Images/OutlookBar/letter3.png", UriKind.RelativeOrAbsolute)); ;
			Add(mailMessage3);
		}
	}

}
