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
using Telerik.Windows.Controls;
using System.Text;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.PanelBar.FirstLook
{
	public class MainPageViewModel : ViewModelBase
	{
		private ObservableCollection<Employee> employees;
		private ObservableCollection<WeekDay> weekDays;
		private ObservableCollection<PublicationPeriod> publicationPeriods;
		private Employee selectedEmployee;
		private string additionalInfo;
		private string additionalInfoType;

		public DelegateCommand DayCheckedCommand { get; set; }
		public DelegateCommand PublicationCheckedCommand { get; set; }
		public object SelectedCategory { get; set; }

		public ObservableCollection<Employee> Employees
		{
			get
			{
				return this.employees;
			}
		}

		public Employee SelectedEmployee
		{
			get
			{
				return this.selectedEmployee;
			}
			set
			{
				this.selectedEmployee = value;
				this.OnEmployeeChanged();
				this.OnPropertyChanged("SelectedEmployee");
			}
		}

		public ObservableCollection<WeekDay> WeekDays
		{
			get
			{
				return this.weekDays;
			}
		}

		public ObservableCollection<PublicationPeriod> PublicationPeriods
		{
			get
			{
				return this.publicationPeriods;
			}
		}

		public string AdditionalInfo
		{
			get
			{
				return this.additionalInfo;
			}
			set
			{
				this.additionalInfo = value;
				OnPropertyChanged("AdditionalInfo");
			}
		}

		public string AdditionalInfoType
		{
			get
			{
				return this.additionalInfoType;
			}
			set
			{
				this.additionalInfoType = value;
				OnPropertyChanged("AdditionalInfoType");
			}
		}

		public MainPageViewModel()
		{
			this.employees = new ObservableCollection<Employee>();
			this.weekDays = new ObservableCollection<WeekDay>();
			this.publicationPeriods = new ObservableCollection<PublicationPeriod>();
			this.DayCheckedCommand = new DelegateCommand(this.OnDayCheckedChanged);
			this.PublicationCheckedCommand = new DelegateCommand(this.OnPublicationCheckedChanged);
			this.LoadData();
		}

		public void CategoryChanged()
		{
			RadPanelBarItem selectedItem = this.SelectedCategory as RadPanelBarItem;
			if (selectedItem != null)
			{
				switch (selectedItem.Header.ToString())
				{
					case "Travel - Top Destinations":
						this.AdditionalInfo = this.SelectedEmployee.Goals;
						this.AdditionalInfoType = "Goals:";
						break;
					case "Programs":
						break;
					case "Selected Publications":
						break;
					case "Contact Information":
						break;
				}
			}
		}

		private void OnEmployeeChanged()
		{
			this.AdditionalInfoType = "Goals:";
			this.AdditionalInfo = this.SelectedEmployee.Goals;
			foreach (WeekDay day in this.WeekDays)
			{
				day.IsChecked = false;
			}

			foreach (PublicationPeriod publication in this.PublicationPeriods)
			{
				publication.IsChecked = false;
			}
		}

		private void OnDayCheckedChanged(object parameter)
		{
			StringBuilder sb = new StringBuilder();
			List<string> days = new List<string>();
			foreach (WeekDay day in this.WeekDays)
			{
				if (day.IsChecked)
				{
					sb.Append(this.SelectedEmployee.GetLecturesByDay(day.Header));
					days.Add(day.Header);
				}
			}

			this.AdditionalInfoType = "Lectures:";
			if (sb.ToString() == string.Empty)
			{
				for (int i = 0; i < days.Count; i++)
				{
					if (i < days.Count - 1)
						sb.Append(days[i] + ", ");
					else
						sb.Append(days[i] + " - No lectures");
				}
			}
			this.AdditionalInfo = sb.ToString();
		}

		private void OnPublicationCheckedChanged(object parameter)
		{
			StringBuilder sb = new StringBuilder();
			List<string> years = new List<string>();
			foreach (PublicationPeriod publication in this.PublicationPeriods)
			{
				if (publication.IsChecked)
				{
					sb.Append(this.SelectedEmployee.GetPublicationsByYear(publication.Year));
					years.Add(publication.Year.ToString());
				}
			}

			this.AdditionalInfoType = "Publications:";
			if (sb.ToString() == string.Empty)
			{
				for (int i = 0; i < years.Count; i++)
				{
					if (i < years.Count - 1)
						sb.Append(years[i] + ", ");
					else
						sb.Append(years[i] + " - No lectures");
				}
			}
			this.AdditionalInfo = sb.ToString();
		}

		private void LoadData()
		{
			this.LoadEmployees();
			this.LoadDays();
			this.LoadPublicationPeriods();
		}

		private void LoadPublicationPeriods()
		{
			this.PublicationPeriods.Add(new PublicationPeriod() { Header = "Publications 2008", Year = 2008 });
			this.PublicationPeriods.Add(new PublicationPeriod() { Header = "Publications 2009", Year = 2009 });
			this.PublicationPeriods.Add(new PublicationPeriod() { Header = "Publications 2010", Year = 2010 });
			this.PublicationPeriods.Add(new PublicationPeriod() { Header = "Publications 2011", Year = 2011 });
		}

		private void LoadDays()
		{
			this.WeekDays.Add(new WeekDay() { Header = "Monday" });
			this.WeekDays.Add(new WeekDay() { Header = "Tuesday" });
			this.WeekDays.Add(new WeekDay() { Header = "Wednesday" });
			this.WeekDays.Add(new WeekDay() { Header = "Thursday" });
			this.WeekDays.Add(new WeekDay() { Header = "Friday" });
		}

		private void LoadEmployees()
		{
			Employee robert = new Employee()
			{
				Name = "Robert King",
				Department = "Department Software Technologies",
				Position = "Professor of Mathematics",
				PositionAdditionalInfo = "Since 2008 – Professor, Software Technology Department, Faculty of Mathematics and Informatics",
				Office = "Hall 205 , East Building 1",
				SmallImagePath = "../Images/PanelBar/Image2.png",
				LargeImagePath = "../Images/PanelBar/Image1.png",
				Goals = "To provide the students with comprehensive knowledge in different aspects of software" +
					"engineering: analysis and specification of requirements, specification of programs, program development, " +
					"software quality management, software projects management, documentation, examination and management of software " +
					"configurations, as well as some practical directions of the software development including those that occur in huge and complicated systems."

			};

			robert.Lectures.Add(new Lecture() { StarTime = "9:15", EndTime = "11:15", Location = "Hall 140 West Building 3", DayOfTheWeek = "Monday" });
			robert.Lectures.Add(new Lecture() { StarTime = "14:15", EndTime = "17:15", Location = "Hall 140 West Building 3", DayOfTheWeek = "Monday" });
			robert.Lectures.Add(new Lecture() { StarTime = "10:15", EndTime = "13:15", Location = "Hall 140 West Building 3", DayOfTheWeek = "Wednesday" });
			robert.Lectures.Add(new Lecture() { StarTime = "18:15", EndTime = "20:15", Location = "Hall 140 West Building 3", DayOfTheWeek = "Friday" });

			robert.Publications.Add(new Publication() { PublicationInfo = "- Teaching Strategies in Probability and Statistics , March ", Year = 2008 });
			robert.Publications.Add(new Publication() { PublicationInfo = "- Revolution or Evolution in Mathematics Education, September", Year = 2009 });
			robert.Publications.Add(new Publication() { PublicationInfo = "- Geometry of architectural freeform structures, April", Year = 2010 });

			Employee steven = new Employee()
			{
				Name = "Steven Bell",
				Department = "Department Information Technologies",
				Position = "Associate Professor",
				PositionAdditionalInfo = "Since 1998 – Professor, Department of Information Technologies",
				Office = "Hall 180 , East Building 2",
				SmallImagePath = "../Images/PanelBar/Image4.png",
				LargeImagePath = "../Images/PanelBar/Image3.png",
				Goals = "To provide the students with comprehensive knowledge in different aspects of software" +
					"engineering: analysis and specification of requirements, specification of programs, program development, " +
					"software quality management, software projects management, documentation, examination and management of software " +
					"configurations, as well as some practical directions of the software development including those that occur in huge and complicated systems."
			};

			steven.Lectures.Add(new Lecture() { StarTime = "7:00", EndTime = "10:00", Location = "Hall 120 West Building 1", DayOfTheWeek = "Monday" });
			steven.Lectures.Add(new Lecture() { StarTime = "12:00", EndTime = "17:00", Location = "Hall 120 West Building 1", DayOfTheWeek = "Monday" });
			steven.Lectures.Add(new Lecture() { StarTime = "16:00", EndTime = "18:00", Location = "Hall 120 West Building 1", DayOfTheWeek = "Wednesday" });
			steven.Lectures.Add(new Lecture() { StarTime = "10:00", EndTime = "12:00", Location = "Hall 120 West Building 1", DayOfTheWeek = "Friday" });

			steven.Publications.Add(new Publication() { PublicationInfo = "- Automated elicitation of inclusion dependencies from the source code for database transactions, February ", Year = 2009 });
			steven.Publications.Add(new Publication() { PublicationInfo = "- Integrated design patterns for database applications, April", Year = 2011 });
			steven.Publications.Add(new Publication() { PublicationInfo = "- A method for the recovery of inclusion dependencies from data-intensive business programs, September", Year = 2011 });

			Employee janet = new Employee()
			{
				Name = "Janet Leverling",
				Department = "Department Information Technologies",
				Position = "Associate Professor",
				PositionAdditionalInfo = "Since 2004 – Professor, Department of Information Technologies",
				Office = "Hall 180 , East Building 2",
				SmallImagePath = "../Images/PanelBar/Image7.png",
				LargeImagePath = "../Images/PanelBar/Image6.png",
				Goals = "To provide the students with comprehensive knowledge in different aspects of software" +
					"engineering: analysis and specification of requirements, specification of programs, program development, " +
					"software quality management, software projects management, documentation, examination and management of software " +
					"configurations, as well as some practical directions of the software development including those that occur in huge and complicated systems."
			};

			janet.Lectures.Add(new Lecture() { StarTime = "7:00", EndTime = "10:00", Location = "Hall 154 East Building 1", DayOfTheWeek = "Monday" });
			janet.Lectures.Add(new Lecture() { StarTime = "12:00", EndTime = "17:00", Location = "Hall 154 East Building 1", DayOfTheWeek = "Monday" });
			janet.Lectures.Add(new Lecture() { StarTime = "16:00", EndTime = "18:00", Location = "Hall 154 East Building 1", DayOfTheWeek = "Wednesday" });
			janet.Lectures.Add(new Lecture() { StarTime = "10:00", EndTime = "12:00", Location = "Hall 154 East Building 1", DayOfTheWeek = "Friday" });

			janet.Publications.Add(new Publication() { PublicationInfo = "- Design and Development of Web-based Instruction: Methodology and Tools, March", Year = 2009 });
			janet.Publications.Add(new Publication() { PublicationInfo = "- Teacher Development in Informatics and Information and Communication Technologies, January", Year = 2011 });

			this.employees.Add(robert);
			this.employees.Add(steven);
			this.employees.Add(janet);

			this.SelectedEmployee = robert;
		}
	}
}
