using System;
using System.Windows;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.TreeListView
{
    public class MyDataContext
    {
        ObservableCollection<FolderViewModel> folders;

        public ObservableCollection<FolderViewModel> Folders
        {
            get
            {
                if (folders == null)
                {
                    var stream = Application.GetResourceStream(new Uri("TreeListView;component/Folders.xml",
                                                                       UriKind.RelativeOrAbsolute)).Stream;
                    var reader = XmlReader.Create(stream);
                    var document = XDocument.Load(reader);

                    var data = from f in document.Element("folders").Elements("folder")
                               select new FolderViewModel(f.Attribute("Name").Value,
                                                          bool.Parse(f.Attribute("IsEmpty").Value),
                                                          DateTime.Parse(f.Attribute("CreationTime").Value, System.Globalization.CultureInfo.InvariantCulture),
                                                          f);

                    folders = new ObservableCollection<FolderViewModel>(data);
                }

                return folders;
            }
        }

        ObservableCollection<FolderViewModel> foldersOnDemand;

        public ObservableCollection<FolderViewModel> FoldersOnDemand
        {
            get
            {
                if (foldersOnDemand == null)
                {
                    var stream = Application.GetResourceStream(new Uri("TreeListView;component/Folders.xml",
                                                                       UriKind.RelativeOrAbsolute)).Stream;
                    var reader = XmlReader.Create(stream);
                    var document = XDocument.Load(reader);

                    var data = from f in document.Element("folders").Elements("folder")
                               select new FolderViewModel(f)
                    {
                        Name = f.Attribute("Name").Value,
                        IsEmpty = bool.Parse(f.Attribute("IsEmpty").Value),
                        CreatedOn = DateTime.Parse(f.Attribute("CreationTime").Value, System.Globalization.CultureInfo.InvariantCulture),
                    };

                    foldersOnDemand = new ObservableCollection<FolderViewModel>(data);
                }

                return foldersOnDemand;
            }
        }
    }
}
