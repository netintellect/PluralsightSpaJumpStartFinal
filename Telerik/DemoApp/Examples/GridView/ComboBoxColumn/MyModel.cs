using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Controls;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Windows.Data;
using System.Windows;
using Telerik.Windows.Data;
using System.ComponentModel;

namespace Telerik.Windows.Examples.GridView.ComboBoxColumn
{
    public class MyModel : ViewModelBase
    {
        private readonly string[] countryNames;

        public MyModel()
        {
            countryNames = new string[11];
            countryNames[0] = "USA";
            countryNames[1] = "Canada";
            countryNames[2] = "Mexico";
            countryNames[3] = "Italy";
            countryNames[4] = "Germany";
            countryNames[5] = "France";
            countryNames[6] = "Belgium";
            countryNames[7] = "Russia";
            countryNames[8] = "Spain";
            countryNames[9] = "Portugal";
            countryNames[10] = "Greece";
        }

        IEnumerable _data;
        public IEnumerable Data
        {
            get
            {
                if (_data == null)
                {
                    _data = GetData();
                }

                return _data;
            }
        }

        ObservableCollection<GridViewColumn> _columns;
        public ObservableCollection<GridViewColumn> Columns
        {
            get
            {
                if (_columns == null)
                {
                    _columns = new ObservableCollection<GridViewColumn>();
                }
                return _columns;
            }
        }

        EnumMemberViewModel _type;
        public EnumMemberViewModel Type
        {
            get
            {
                return _type;
            }
            set
            {
                if (_type != value)
                {
                    _type = value;

                    _data = null;

                    OnPropertyChanged("Type");
                    OnPropertyChanged("Data");
                }
            }
        }

        string _descriptionHeader;
        public string DescriptionHeader
        {
            get
            {
                return _descriptionHeader;
            }
            set
            {
                if (_descriptionHeader != value)
                {
                    _descriptionHeader = value;

                    OnPropertyChanged("DescriptionHeader");
                }
            }
        }

        string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description != value)
                {
                    _description = value;

                    OnPropertyChanged("Description");
                }
            }
        }

        DataTemplate _comboTemplate;
        public DataTemplate ComboTemplate
        {
            get
            {
                return _comboTemplate;
            }
            set
            {
                if (_comboTemplate != value)
                {
                    _comboTemplate = value;

                    OnPropertyChanged("ComboTemplate");
                }
            }
        }

        private IEnumerable GetData()
        {
            if (Type == null)
                return null;

            switch ((BindingType)Type.Value)
            {
                case BindingType.SimpleBindingToString:
                    {
                        Description = "This is a demonstration of GridViewComboBoxColumn binding to strings";
                        DescriptionHeader = "Simple Binding to Strings";
                        Columns.Clear();

                        List<Product> products = new List<Product>();
                        for (int i = 0; i < 10; i++)
                        {
                            Product product = new Product();
                            product.ID = i;
                            product.ProductName = String.Format("Product{0}", i);
                            products.Add(product);
                        }

                        GridViewComboBoxColumn column = new GridViewComboBoxColumn();
                        column.DataMemberBinding = new Binding("ProductName");
                        column.ItemsSource = from p in products
                                             select p.ProductName;
						column.Width = new GridViewLength(1, GridViewLengthUnitType.Star);
                        Columns.Add(column);

                        return products;
                    }
                case BindingType.SimpleBindingToObject:
                    {
                        Description = "This is a demonstration of GridViewComboBoxColumn simple binding to objects";
                        DescriptionHeader = "Simple Binding to Objects";
                        Columns.Clear();

                        List<Employee> employees = new List<Employee>();
                        for (int i = 0; i < 10; i++)
                        {
                            Employee employee = new Employee();
                            employee.Name = String.Format("Name{0}", i);
                            employees.Add(employee);
                        }

                        List<Position> positions = new List<Position>();
                        for (int i = 0; i < 10; i++)
                        {
                            Position position = new Position();
                            position.Description = String.Format("Description{0}", i);
                            position.Employee = employees[i];
                            positions.Add(position);
                        }

                        GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn();
                        comboColumn.DataMemberBinding = new Binding("Employee");
                        comboColumn.DisplayMemberPath = "Name";
                        comboColumn.ItemsSource = employees;
						comboColumn.Width = new GridViewLength(1, GridViewLengthUnitType.Star);
                        Columns.Add(comboColumn);

                        GridViewDataColumn column = new GridViewDataColumn();
                        column.DataMemberBinding = new Binding("Description");
						column.Width = new GridViewLength(1, GridViewLengthUnitType.Star);
                        Columns.Add(column);

                        return positions;
                    }
                case BindingType.SimpleBindingToEnum:
                    {
                        Description = "This is a demonstration of GridViewComboBoxColumn binding to enum";
                        DescriptionHeader = "Binding to Enum";
                        Columns.Clear();

                        List<Person> persons = new List<Person>();

                        Person person = new Person();
                        person.ID = 1;
                        person.Gender = Gender.Male;

                        persons.Add(person);

                        person = new Person();
                        person.ID = 2;
                        person.Gender = Gender.Female;
                        persons.Add(person);

                        List<Gender> AvailableGenders = new List<Gender>();
                        AvailableGenders.Add(Gender.Male);
                        AvailableGenders.Add(Gender.Female);

                        GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn();
                        comboColumn.DataMemberBinding = new Binding("Gender");
                        comboColumn.ItemsSource = AvailableGenders;
						comboColumn.Width = new GridViewLength(1, GridViewLengthUnitType.Star);
                        Columns.Add(comboColumn);

                        return persons;
                    }
                case BindingType.ClassicBindingToObject:
                    {
                        Description = "This is a demonstration of GridViewComboBoxColumn classic binding to objects";
                        DescriptionHeader = "Classic Binding to Objects";
                        Columns.Clear();

                        List<Location> locations = new List<Location>();
                        for (int i = 0; i < 10; i++)
                        {
                            Location location = new Location();
                            location.ID = i;
                            location.CountryID = i;
                            locations.Add(location);
                        }

                        List<Country> countries = new List<Country>();
                        for (int i = 0; i < 10; i++)
                        {
                            Country country = new Country();
                            country.ID = i;
                            country.Name = countryNames[i];
                            countries.Add(country);
                        }

                        GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn();
                        comboColumn.DataMemberBinding = new Binding("CountryID");
                        comboColumn.SelectedValueMemberPath = "ID";
                        comboColumn.DisplayMemberPath = "Name";
                        comboColumn.ItemsSource = countries;
						comboColumn.Width = new GridViewLength(1, GridViewLengthUnitType.Star);
                        Columns.Add(comboColumn);

                        return locations;
                    }
                case BindingType.MultiColumnComboBox:
                    {
                        Description = "This is a demonstration of how the ItemTemplate property of the column may be used to provide multicolumn layout for the lookup items";
                        DescriptionHeader = "MultiColumn ComboBox";
                        Columns.Clear();

                        List<Location> locations = new List<Location>();
                        for (int i = 0; i < 10; i++)
                        {
                            Location location = new Location();
                            location.ID = i;
                            location.CountryID = i;
                            locations.Add(location);
                        }

                        List<Country> countries = new List<Country>();
                        for (int i = 0; i < 10; i++)
                        {
                            Country country = new Country();
                            country.ID = i;
                            country.Name = countryNames[i];
                            countries.Add(country);
                        }

                        GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn();
                        comboColumn.Header = "Country ID & Name";
                        comboColumn.DataMemberBinding = new Binding("CountryID");
                        comboColumn.SelectedValueMemberPath = "ID";
                        comboColumn.DisplayMemberPath = "Name";
                        comboColumn.ItemsSource = countries;
                        comboColumn.ItemTemplate = ComboTemplate;
						comboColumn.Width = new GridViewLength(1, GridViewLengthUnitType.Star);
                        Columns.Add(comboColumn);

                        return locations;
                    }
            }

            return null;
        }

        IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> _bindingTypes;
        public IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> BindingTypes
        {
            get
            {
                if (_bindingTypes == null)
                {
                    _bindingTypes = Telerik.Windows.Data.EnumDataSource.FromType<BindingType>();

                    Type = _bindingTypes.FirstOrDefault();
                }

                return _bindingTypes;
            }
        }
    }

    public enum BindingType
    {
        [Description("Simple binding to string")]
        SimpleBindingToString,

        [Description("Simple binding to object")]
        SimpleBindingToObject,

        [Description("Simple binding to enum")]
        SimpleBindingToEnum,

        [Description("Classic binding to object")]
        ClassicBindingToObject,

        [Description("Multi column ComboBox")]
        MultiColumnComboBox
    }
}
