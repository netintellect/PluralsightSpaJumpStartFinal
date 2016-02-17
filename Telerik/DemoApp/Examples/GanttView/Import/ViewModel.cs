using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Xml.Linq;
using Telerik.Windows.Controls.GanttView;
using Telerik.Windows.Controls.Scheduling;
using Telerik.Windows.Core;

namespace Telerik.Windows.Examples.GanttView.Import
{
	public class ViewModel : PropertyChangedBase
	{

		public ViewModel()
		{
			tasks = new ObservableCollection<GanttTask>();
			FilePath = "MarketSchedule.xml";
		}
		private string filePath;
		public string FilePath
		{
			get
			{
				return this.filePath;
			}
			set
			{
				if (filePath != value)
				{
					filePath = value;
					OnPropertyChanged(() => FilePath);
					this.ImportFromFile();
				}
			}
		}
		private void ImportFromFile()
		{
			var stream = Application.GetResourceStream(new Uri(@"/GanttView;component/Import/"+this.FilePath, UriKind.RelativeOrAbsolute)).Stream;

			XDocument xDocument = XDocument.Load(stream);
			XNamespace xnamespace = xDocument.Root.Name.Namespace;
			this.Tasks = MsProjectImportHelper.GetMsTasks(xDocument, xnamespace);
			this.SetUpVisibleRange(xDocument, xnamespace);
		}


		private void SetUpVisibleRange(XDocument xDocument, XNamespace xnamespace)
		{
			DateTime dateTimeStart = DateTime.Parse(xDocument.Root.Element(xnamespace + "StartDate").Value);
			DateTime dateTimeEnd = DateTime.Parse(xDocument.Root.Element(xnamespace + "FinishDate").Value);
			this.VisibleRange = new Controls.Scheduling.VisibleRange() { Start = dateTimeStart.Date.AddDays(1), End = dateTimeEnd.Date.AddDays(1) };
		}

		private ObservableCollection<GanttTask> tasks;

		public ObservableCollection<GanttTask> Tasks
		{
			get
			{
				return tasks;

			}
			set
			{
				tasks = value;
				OnPropertyChanged(() => Tasks);
			}

		}

		private VisibleRange visibleRange;
		public VisibleRange VisibleRange
		{
			get
			{
				return visibleRange;
			}
			set
			{
				if (visibleRange != value)
				{
					visibleRange = value;
					OnPropertyChanged(() => VisibleRange);
				}
			}
		}

	}
}
