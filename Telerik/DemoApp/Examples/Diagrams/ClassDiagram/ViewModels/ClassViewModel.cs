using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
#if WPF
using System.Windows.Controls;
#else
using Telerik.Windows.Controls;
#endif
using Telerik.Windows.Data;
using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;
using Telerik.Windows.Examples.Diagrams.ClassDiagram.ViewModels;

namespace Telerik.Windows.Examples.Diagrams.ClassDiagram
{
	/// <summary>
	/// The class view model.
	/// </summary>
	public class ClassViewModel : NodeViewModelBase
	{
		/// <summary>
		/// The display member path.
		/// </summary>
		private string displayMemberPath;

		/// <summary>
		/// The group descriptor path.
		/// </summary>
		private GroupDescriptorPath groupDescriptorPath;

		/// <summary>
		/// The group sort direction.
		/// </summary>
		private ListSortDirection groupSortDirection;

		/// <summary>
		/// The header.
		/// </summary>
		private string header;

		/// <summary>
		/// The is sorting.
		/// </summary>
		private bool isSorting;
		
		/// <summary>
		/// The sort descriptor path.
		/// </summary>
		private string sortDescriptorPath;

		/// <summary>
		/// The sort direction.
		/// </summary>
		private ListSortDirection? sortDirection;

		/// <summary>
		/// The class type.
		/// </summary>
		private ClassType classType;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ClassViewModel"/> class.
		/// </summary>
		/// <param name="type">
		/// The type.
		/// </param>
		public ClassViewModel(Type type)
		{
			var items = new ObservableCollection<MemberViewModel>();
			this.BaseTypes = new List<Type>();

			this.Header = type.Name;

            if (type.IsClass)
                this.ClassType = ClassType.Class;
            else if (type.IsInterface)
                this.ClassType = ClassType.Interface;
            else if (type.IsEnum)
                this.ClassType = ClassType.Enum;
            else
                this.ClassType = ClassType.Struct;

            ReflectTypeMemebers(type, items);

			this.GroupedItems = new QueryableCollectionView(items);
            
            this.GroupDescriptorPath = GroupDescriptorPath.Kind;

			foreach (var baseInterface in type.GetInterfaces())
			{
				this.BaseTypes.Add(baseInterface);
			}

			if (type.BaseType != null)
			{
				this.BaseTypes.Add(type.BaseType);
			}
		}

		/// <summary>
		/// Gets BaseTypes.
		/// </summary>
		public List<Type> BaseTypes { get; private set; }

		/// <summary>
		/// Gets or sets DisplayMemberPath.
		/// </summary>
		public string DisplayMemberPath
		{
			get
			{
				return this.displayMemberPath;
			}

			set
			{
				this.displayMemberPath = value;
				this.OnPropertyChanged("DisplayMemberPath");
			}
		}

		/// <summary>
		/// Gets or sets GroupDescriptorPath.
		/// </summary>
		public GroupDescriptorPath GroupDescriptorPath
		{
			get
			{
				return this.groupDescriptorPath;
			}

			set
			{
				if (this.groupDescriptorPath != value)
				{
					this.groupDescriptorPath = value;
					this.ChangeGrouping(this.groupDescriptorPath);
				}
			}
		}

		/// <summary>
		/// Gets or sets GroupSortDirection.
		/// </summary>
		public ListSortDirection GroupSortDirection
		{
			get
			{
				return this.groupSortDirection;
			}

			set
			{
				this.groupSortDirection = value;
				this.OnPropertyChanged("GroupSortDirection");
			}
		}

		/// <summary>
		/// Gets GroupedItems.
		/// </summary>
		public QueryableCollectionView GroupedItems { get; private set; }

		/// <summary>
		/// Gets or sets Header.
		/// </summary>
		public string Header
		{
			get
			{
				return this.header;
			}

			set
			{
				this.header = value;
				this.OnPropertyChanged("Header");
			}
		}

		/// <summary>
		/// Gets or sets SortDescriptorPath.
		/// </summary>
		public string SortDescriptorPath
		{
			get
			{
				return this.sortDescriptorPath;
			}

			set
			{
				this.sortDescriptorPath = value;
				this.OnPropertyChanged("SortDescriptorPath");
			}
		}

		/// <summary>
		/// Gets or sets SortDirection.
		/// </summary>
		public ListSortDirection? SortDirection
		{
			get
			{
				return this.sortDirection;
			}

			set
			{
				if (this.sortDirection != value)
				{
					this.sortDirection = value;
					this.ChangeSorting(this.sortDirection);
				}
			}
		}

		/// <summary>
		/// Gets or sets ClassType.
		/// </summary>
		public ClassType ClassType
		{
			get
			{
				return this.classType;
			}

			set
			{
				this.classType = value;
				this.OnPropertyChanged("ClassType");
			}
		}
   
		/// <summary>
		/// The reflect type memebers.
		/// </summary>
		/// <param name="type">
		/// The type.
		/// </param>
		/// <param name="items">
		/// The items.
		/// </param>
		private static void ReflectTypeMemebers(Type type, ICollection<MemberViewModel> items)
		{
            if (type.IsEnum)
            {
	            foreach (var property in type.GetFields(BindingFlags.Public | BindingFlags.Static)) items.Add(new MemberViewModel { Name = property.Name });
	            return;
            }

			foreach (var property in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(property => char.IsUpper(property.Name[0])))
			{
				items.Add(new MemberViewModel { Name = property.Name, Access = AccessType.Public, Kind = KindType.Methods });
			}

			foreach (var property in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static).Where(property => char.IsUpper(property.Name[0])))
			{
                items.Add(new MemberViewModel { Name = property.Name, Access = AccessType.Public, Kind = KindType.Methods });
			}

			foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(property => char.IsUpper(property.Name[0])))
			{
                items.Add(new MemberViewModel { Name = property.Name, Access = AccessType.Public, Kind = KindType.Properties });
			}

            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static).Where(property => char.IsUpper(property.Name[0])))
            {
                items.Add(new MemberViewModel { Name = property.Name, Access = AccessType.Public, Kind = KindType.Properties });
            }

            foreach (var property in type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static).Where(property => char.IsUpper(property.Name[0])))
            {
                items.Add(new MemberViewModel { Name = property.Name, Access = AccessType.Public, Kind = KindType.Fields });
            }

			foreach (var property in type.GetEvents(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(property => char.IsUpper(property.Name[0])))
			{
                items.Add(new MemberViewModel { Name = property.Name, Access = AccessType.Public, Kind = KindType.Events });
			}

			foreach (var property in type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(property => char.IsUpper(property.Name[0])))
			{
				if (property.IsAssembly)
				{
                    items.Add(new MemberViewModel { Name = property.Name, Access = AccessType.Internal, Kind = KindType.Methods });
				}
				else if (property.IsFamily)
				{
					items.Add(new MemberViewModel { Name = property.Name, Access = AccessType.Protected, Kind = KindType.Methods });
				}
				else if (property.IsPrivate)
				{
					items.Add(new MemberViewModel { Name = property.Name, Access = AccessType.Private, Kind = KindType.Methods });
				}
			}

			foreach (var property in type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static).Where(property => char.IsUpper(property.Name[0])))
			{
				if (property.IsAssembly)
				{
					items.Add(new MemberViewModel { Name = property.Name, Access = AccessType.Internal, Kind = KindType.Methods });
				}
				else if (property.IsFamily)
				{
					items.Add(new MemberViewModel { Name = property.Name, Access = AccessType.Protected, Kind = KindType.Methods });
				}
				else if (property.IsPrivate)
				{
					items.Add(new MemberViewModel { Name = property.Name, Access = AccessType.Private, Kind = KindType.Methods });
				}
			}

			foreach (var property in type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(property => char.IsUpper(property.Name[0])))
			{
				items.Add(new MemberViewModel { Name = property.Name, Access = AccessType.Private, Kind = KindType.Properties });
			}

			foreach (var property in type.GetEvents(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(property => char.IsUpper(property.Name[0])))
			{
				items.Add(new MemberViewModel { Name = property.Name, Access = AccessType.Private, Kind = KindType.Events });
			}
		}

		/// <summary>
		/// The change grouping.
		/// </summary>
		/// <param name="groupDescriptorMemberPath">
		/// The group descriptor member path.
		/// </param>
		private void ChangeGrouping(GroupDescriptorPath groupDescriptorMemberPath)
		{
			if (!this.isSorting) this.SortDirection = null;
			this.isSorting = false;

			this.GroupedItems.GroupDescriptors.Clear();
            string memberString = groupDescriptorMemberPath.ToString();
			this.GroupedItems.GroupDescriptors.Add(new GroupDescriptor { Member = memberString });

            if (groupDescriptorMemberPath == GroupDescriptorPath.Access)
            {
                SortDescriptor desc = new SortDescriptor() { Member = "Access" };
                this.GroupedItems.SortDescriptors.Add(desc);
            }
		}

		/// <summary>
		/// The change sorting.
		/// </summary>
		/// <param name="direction">
		/// The direction.
		/// </param>
		private void ChangeSorting(ListSortDirection? direction)
		{
			if (direction != null)
			{
				this.isSorting = true;
				this.GroupDescriptorPath = GroupDescriptorPath.Member;
				this.GroupedItems.SortDescriptors.Add(new SortDescriptor { Member = "Name", SortDirection = ListSortDirection.Ascending });
			}
			else
			{
				this.GroupedItems.SortDescriptors.Clear();
			}
		}
	}

	/// <summary>
	/// The group descriptor path.
	/// </summary>
	public enum GroupDescriptorPath
	{
		/// <summary>
		/// The access.
		/// </summary>
		Access,

		/// <summary>
		/// The kind.
		/// </summary>
		Kind,

		/// <summary>
		/// The member.
		/// </summary>
		Member
	}

	public enum ClassType
	{
		Class,
		Interface,
		Enum,
        Struct
	}

	public class ClassTemplateSelector : DataTemplateSelector
	{
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			var classViewModel = item as ClassViewModel;
			if (classViewModel == null) return null;
			switch (classViewModel.ClassType)
			{
				case ClassType.Class:
					return this.ClassTemplate;
				case ClassType.Interface:
					return this.InterfaceTemplate;
				case ClassType.Enum:
					return this.EnumTemplate;
                case ClassType.Struct:
                    return this.StructTemplate;
			}
			return null;
		}

		public DataTemplate ClassTemplate { get; set; }

		public DataTemplate InterfaceTemplate { get; set; }

        public DataTemplate EnumTemplate { get; set; }

        public DataTemplate StructTemplate { get; set; }
	}

    public class TreeViewItemTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var memberViewModel = item as MemberViewModel;
            if (memberViewModel == null) return null;
            switch (memberViewModel.Kind)
            {
                case KindType.Properties:
                    return this.PropertyTemplate;
                case KindType.Methods:
                    return this.MethodTemplate;
                case KindType.Events:
                    return this.EventTemplate;
                case KindType.Fields:
                    return this.FieldTemplate;
            }
            return null;
        }

        public DataTemplate PropertyTemplate { get; set; }

        public DataTemplate MethodTemplate { get; set; }

        public DataTemplate EventTemplate { get; set; }

        public DataTemplate FieldTemplate { get; set; }
    }

    public class NamespaceItemTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var classViewModel = item as ClassViewModel;
            if (classViewModel == null) return null;
            switch (classViewModel.ClassType)
            {
                case ClassType.Class:
                    return PublicClassTemplate;
                case ClassType.Interface:
                    return this.PublicInterfaceTemplate;
                case ClassType.Enum:
                    return this.PublicEnumTemplate;
                case ClassType.Struct:
                    return this.PublicStructTemplate;
            }
            return null;
        }

        public DataTemplate PublicClassTemplate { get; set; }

        public DataTemplate PublicInterfaceTemplate { get; set; }

        public DataTemplate PublicEnumTemplate { get; set; }

        public DataTemplate PublicStructTemplate { get; set; }
    }
}