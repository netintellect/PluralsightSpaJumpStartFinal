namespace Telerik.Windows.Examples.ContextMenu.Theming
{
	public class DataViewModel
	{
		private DataItemCollection items;

		public DataViewModel()
		{
			this.items = new DataItemCollection(null);

			this.BeginLoadingItems();
		}

		public DataItemCollection Items
		{
			get
			{
				return this.items;
			}
		}

		private void BeginLoadingItems()
		{
			// You can load the items from a web service
			this.ItemsLoaded();
		}

		private void ItemsLoaded()
		{
			DataItem root = new DataItem();
			root.Text = "Personal Folders";
			root.ImageUrl = "../../Images/ContextMenu/Outlook/1PersonalFolders.png";
			root.IsExpanded = true;

			DataItem deletedItems = new DataItem();
			root.Items.Add(deletedItems);
			deletedItems.Text = "Deleted Items(6)";
			deletedItems.ImageUrl = "../../Images/ContextMenu/Outlook/2DeletedItems.png";

			DataItem inbox = new DataItem();
			root.Items.Add(inbox);
			inbox.Text = "Inbox(14)";
			inbox.ImageUrl = "../../Images/ContextMenu/Outlook/4Inbox.png";

			DataItem folders = new DataItem();
			inbox.Items.Add(folders);
			folders.Text = "Folders";
			folders.ImageUrl = "../../Images/ContextMenu/Outlook/folder.png";

			DataItem junkEmails = new DataItem();
			root.Items.Add(junkEmails);
			junkEmails.Text = "Junk E-mails";
			junkEmails.ImageUrl = "../../Images/ContextMenu/Outlook/junk.png";

			DataItem outbox = new DataItem();
			root.Items.Add(outbox);
			outbox.Text = "Outbox";
			outbox.ImageUrl = "../../Images/ContextMenu/Outlook/outbox.png";

			DataItem sentItems = new DataItem();
			root.Items.Add(sentItems);
			sentItems.Text = "Sent Items";
			sentItems.ImageUrl = "../../Images/ContextMenu/Outlook/sent.png";

			DataItem search = new DataItem();
			root.Items.Add(search);
			search.Text = "Search Folder";
			search.ImageUrl = "../../Images/ContextMenu/Outlook/searchFolder.png";

			DataItem followup = new DataItem();
			search.Items.Add(followup);
			followup.Text = "From Follow up";
			followup.ImageUrl = "../../Images/ContextMenu/Outlook/folder.png";

			DataItem largeMail = new DataItem();
			search.Items.Add(largeMail);
			largeMail.Text = "Large Mail";
			largeMail.ImageUrl = "../../Images/ContextMenu/Outlook/search.png";

			DataItem unreadMail = new DataItem();
			search.Items.Add(unreadMail);
			unreadMail.Text = "Unread Mail";
			unreadMail.ImageUrl = "../../Images/ContextMenu/Outlook/search.png";

			this.Items.Add(root);
		}
	}
}