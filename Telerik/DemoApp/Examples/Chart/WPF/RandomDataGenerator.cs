using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows.Data;

namespace Telerik.Windows.Examples
{
	public static class RandomDataGenerator
	{
		private static Random rand = new Random(DateTime.Now.Millisecond);

		public static double GetRounedDoubleValue()
		{
			return Math.Round(rand.NextDouble() * 100, 1);
		}

		public static DataTable GetDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("DoubleData", typeof(double));
			dataTable.Columns.Add("DoubleData2", typeof(double));
			dataTable.Columns.Add("StringData", typeof(string));

			for (int index = 0; index < rand.Next(5, 10); index++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["DoubleData"] = GetRounedDoubleValue();
				dataRow["DoubleData2"] = GetRounedDoubleValue();
				dataRow["StringData"] = string.Format("Item {0}", index);
				dataTable.Rows.Add(dataRow);
			}

			return dataTable;
		}

		public static List<DataClass> GetObjectData()
		{
			List<DataClass> list = new List<DataClass>();
            for (int index = 0; index < rand.Next(5, 10); index++)
				list.Add(new DataClass(string.Format("Item {0}", index)));

			return list;
		}

		public static ArrayList GetArrayList()
		{
			ArrayList list = new ArrayList();
            for (int index = 0; index < rand.Next(5, 10); index++)
				list.Add(GetRounedDoubleValue());

			return list;
		}

		public static ObservableCollection<DataClass> GetObservableCollection()
		{
            ObservableCollection<DataClass> list = new ObservableCollection<DataClass>();
            for (int index = 0; index < rand.Next(5, 10); index++)
				list.Add(new DataClass(string.Format("Item {0}", index)));

			return list;
		}

		public static object GetObjectDataProvider()
		{
			ObjectDataProvider objectData = new ObjectDataProvider();
			List<DataClass> list = new List<DataClass>();
            for (int index = 0; index < rand.Next(5, 10); index++)
				list.Add(new DataClass(string.Format("Item {0}", index)));

			objectData.ObjectInstance = list;
			objectData.IsAsynchronous = false;

			return objectData.Data;
		}

		public static ICollectionView GetCollectionView()
		{
			return CollectionViewSource.GetDefaultView(GetDataTable());;
		}

		internal static object GetDataFromPropertyPaths()
		{
			List<PropertyPathDataClass> list = new List<PropertyPathDataClass>();
            for (int index = 0; index < rand.Next(5, 10); index++)
				list.Add(new PropertyPathDataClass(new DataClass(string.Format("Item {0}", index))));

			return list;
		}
	}

	public class DataClass
	{
		private string stringValue;
		private double doubleValue;
		private double doubleValue2;
		
		public DataClass()
			: this("Test Label")
		{

		}

		public DataClass(string stringData)
			: this(RandomDataGenerator.GetRounedDoubleValue(),
				   RandomDataGenerator.GetRounedDoubleValue(), 
				   stringData)
		{

		}

		public DataClass(double doubleData, double doubleData2, string stringData)
		{
			this.DoubleData = doubleData;
			this.DoubleData2 = doubleData2;
			this.StringData = stringData;
		}

		public double DoubleData
		{
			get
			{
				return this.doubleValue;
			}
			set
			{
				this.doubleValue = value;
			}
		}

		public double DoubleData2
		{
			get
			{
				return this.doubleValue2;
			}
			set
			{
				this.doubleValue2 = value;
			}
		}

		public string StringData
		{
			get
			{
				return this.stringValue;
			}
			set
			{
				this.stringValue = value;
			}
		}
	}

	public class PropertyPathDataClass
	{
		private DataClass dataInstance;
		
		public PropertyPathDataClass()
		{

		}

		public PropertyPathDataClass(DataClass data)
		{
			this.Data = data;
		}

		public DataClass Data
		{
			get
			{
				return this.dataInstance;
			}
			set
			{
				this.dataInstance = value;
			}
		}
	}
}
