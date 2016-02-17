using System;
using System.Windows;
using System.Linq;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls.TreeView;
using Telerik.Windows.DragDrop;

namespace Telerik.Windows.Examples.TreeView.DragDrop
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			this.MergeResourceDictionaries();
			InitializeComponent();

			this.DataContext = new SampleViewModel();
			DragDropManager.AddDragOverHandler(this.xTree1, new Windows.DragDrop.DragEventHandler(OnDragOver), true);
			DragDropManager.AddDragOverHandler(this.xTree2, new Windows.DragDrop.DragEventHandler(OnDragOver), true);
		}

		private static void OnDragOver(object sender, Telerik.Windows.DragDrop.DragEventArgs e)
		{
			var options = DragDropPayloadManager.GetDataFromObject(e.Data, TreeViewDragDropOptions.Key) as TreeViewDragDropOptions;
			if (options != null)
			{
				var isDraggingGroups = options.DraggedItems.OfType<Group>().Count() > 0;
				if (isDraggingGroups)
				{
					//// Disable drop of groups.
					options.DropAction = DropAction.None;
					options.UpdateDragVisual();
				}
				else
				{
					var dropGroup = GetDropGroup(options);
					if (dropGroup == null)
					{
						//// Disable drop in leaf items.
						options.DropAction = DropAction.None;
						options.UpdateDragVisual();
					}
					else
					{
						//// Override drop in Groups to be always Drop Inside.
						options.DropPosition = Controls.DropPosition.Inside;
						options.UpdateDragVisual();
					}
				}
			}
		}

		private static Group GetDropGroup(TreeViewDragDropOptions options)
		{
			Group result = null;
			if (options != null && options.DropTargetItem != null)
			{
				result = options.DropTargetItem.Item as Group;
			}
			return result;
		}

		private void MergeResourceDictionaries()
		{
			try
			{
				ResourceDictionary dict = new ResourceDictionary();
#if WPF
				dict.Source = new Uri("TreeView;component/DragDrop/TreeViewTemplates_WPF.xaml", UriKind.RelativeOrAbsolute);
#else
				Application.LoadComponent(dict, new Uri("TreeView;component/DragDrop/TreeViewTemplates_SL.xaml", UriKind.RelativeOrAbsolute));
#endif
				this.Resources.MergedDictionaries.Add(dict);
			}
			catch
			{
			}
		}
	}

	public class Person
	{
		public string Name { get; set; }

		public Person(string name)
		{
			this.Name = name;
		}
	}

	public class Group
	{
		public string Name { get; set; }
		public ObservableCollection<Person> Participants { get; private set; }

		public Group()
		{
			this.Participants = new ObservableCollection<Person>();
		}
	}

	public class SampleViewModel
	{
		public ObservableCollection<Group> GroupStaff { get; private set; }
		public ObservableCollection<Group> GroupTeams { get; private set; }

		public SampleViewModel()
		{
			this.GroupStaff = new ObservableCollection<Group>();
			this.GroupTeams = new ObservableCollection<Group>();

			Group gr = new Group();
			gr.Name = "QAS";
			this.LoadPeopleInGroup(gr, "Nancy Davolio", "Andrew Fuller", "Janet Levering", "Margaret Peacock", "Steven Buchanan");
			GroupStaff.Add(gr);

			gr = new Group();
			gr.Name = "Designers";
			this.LoadPeopleInGroup(gr, "Maria Anders", "Ana Trujillo", "Antonio Moreno", "Thomas Hardy", "Christina Berglund");
			GroupStaff.Add(gr);

			gr = new Group();
			gr.Name = "Sales";
			this.LoadPeopleInGroup(gr, "Hanna Moos", "Laurence Lebihan", "Elizabeth Lincoln", "Victoria Ashworth", "Patricio Simpson");
			GroupStaff.Add(gr);

			gr = new Group();
			gr.Name = "Developers";
			this.LoadPeopleInGroup(gr, "Francisco Chang", "Yang Wang", "Pedro Afonso", "Elizabeth Brown", "Sven Ottlieb");
			GroupStaff.Add(gr);

			gr = new Group();
			gr.Name = "Managers";
			this.LoadPeopleInGroup(gr, "Janine Labrune", "Ann Devon", "Roland Mendel", "Aria Cruz", "Diego Roel");
			GroupStaff.Add(gr);

			gr = new Group();
			gr.Name = "XamlTeam";
			GroupTeams.Add(gr);

			gr = new Group();
			gr.Name = "WebTeam";
			GroupTeams.Add(gr);

			gr = new Group();
			gr.Name = "AspNetTeam";
			GroupTeams.Add(gr);
		}

		private void LoadPeopleInGroup(Group group, string firstPerson, string secondPerson,
			string thirdPerson, string fourthPerson, string fifthPerson)
		{
			group.Participants.Add(new Person(firstPerson));
			group.Participants.Add(new Person(secondPerson));
			group.Participants.Add(new Person(thirdPerson));
			group.Participants.Add(new Person(fourthPerson));
			group.Participants.Add(new Person(fifthPerson));
		}
	}
}
