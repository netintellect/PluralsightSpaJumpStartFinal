using System;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace RibbonView.Silverlight.Common
{
	public class RecentDocuments : ObservableCollection<DataItem>
	{
		public RecentDocuments()
		{
			Add(new DataItem("RadRibbonBarSpecification", @"\\telerik.com\Resources", "", @"/RibbonView;component/Images/RibbonView/FirstLook/Backstage/Document.png", ""));
			Add(new DataItem("RadRibbonBackstageSpecification", @"\\telerik.com\Resources", "", @"/RibbonView;component/Images/RibbonView/FirstLook/Backstage/Document.png", ""));
			Add(new DataItem("RadRibbonBackstageItemSpecification", @"\\telerik.com\Resources", "", @"/RibbonView;component/Images/RibbonView/FirstLook/Backstage/Document.png", ""));
			Add(new DataItem("DevReach 2010", @"c:\My Documents", "", @"/RibbonView;component/Images/RibbonView/FirstLook/Backstage/Document.png", ""));
			Add(new DataItem("PDC 2010", @"c:\My Documents", "", @"/RibbonView;component/Images/RibbonView/FirstLook/Backstage/Document.png", ""));
			Add(new DataItem("MIX 2010", @"c:\My Documents", "", @"/RibbonView;component/Images/RibbonView/FirstLook/Backstage/Document.png", ""));
			Add(new DataItem("MS Days 2010", @"c:\My Documents", "", @"/RibbonView;component/Images/RibbonView/FirstLook/Backstage/Document.png", ""));
		}
	}

	public class RecentPlaces : ObservableCollection<DataItem>
	{
		public RecentPlaces()
		{
			Add(new DataItem("My Documents", @"c:\Users\vtsvetkov\Documents", "", @"/RibbonView;component/Images/RibbonView/FirstLook/Backstage/Document.png", ""));
			Add(new DataItem("Downloads", @"c:\Users\vtsvetkov\Documents", "", @"/RibbonView;component/Images/RibbonView/FirstLook/Backstage/Document.png", ""));
			Add(new DataItem("Resources", @"\\telerik.com\Resources", "", @"/RibbonView;component/Images/RibbonView/FirstLook/Backstage/Document.png", ""));
		}
	}

	public class AvailableTemplates : ObservableCollection<DataItem>
	{
		public AvailableTemplates()
		{
			Add(new DataItem("Blank     document", "", "", @"/RibbonView;component/Images/RibbonView/FirstLook/Backstage/DocTemplateNew.png", ""));
			Add(new DataItem("Blog post", "", "", @"/RibbonView;component/Images/RibbonView/Backstage/FirstLook/Backstage/DocTemplateBlogPost.png", ""));
			Add(new DataItem("Recent    templates", "", "", @"/RibbonView;component/Images/RibbonView/FirstLook/Backstage/DocTemplateRecent.png", ""));
			Add(new DataItem("Sample    templates", "", "", @"/RibbonView;component/Images/RibbonView/FirstLook/Backstage/DocTemplateSamples.png", ""));
			Add(new DataItem("My templates", "", "", @"/RibbonView;component/Images/RibbonView/Backstage/FirstLook/DocTemplateMy.png", ""));
			Add(new DataItem("New from    existing", "", "", @"/RibbonView;component/Images/RibbonView/FirstLook/Backstage/DocTemplateNewBasedOn.png", ""));
		}
	}

	public class HelpItems : ObservableCollection<DataItem>
	{
		public HelpItems()
		{
			Add(new DataItem("RadRibbonView Help", "", "Go to our help page.", @"/RibbonView;component/Images/RibbonView/FirstLook/Backstage/Help64.png", ""));
			Add(new DataItem("Getting started", "", "See what's new and find resources to help you the basics quickly.", @"/RibbonView;component/Images/RibbonView/FirstLook/Backstage/Getting_Started.png", ""));
			Add(new DataItem("Contact Us", "", "Let us know if you need help or how we can make RadRibbonBar better.", @"/RibbonView;component/Images/RibbonView/FirstLook/Backstage/ContactUs2.png", ""));
		}
	}

	public class DataItem
	{
		public string Header
		{ get; set; }

		public string Description
		{ get; set; }

		public string Folder
		{ get; set; }

		public string ImageSource
		{ get; set; }

		public string NavigateUri
		{ get; set; }

		public DataItem(string header, string folder, string description, string imageSource, string navigateUri)
		{
			this.Header = header;
			this.Description = description;
			this.Folder = folder;
			this.ImageSource = imageSource;
			this.NavigateUri = navigateUri;
		}
	}
}
