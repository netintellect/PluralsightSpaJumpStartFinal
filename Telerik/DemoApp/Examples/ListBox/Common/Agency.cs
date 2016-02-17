namespace Telerik.Windows.Examples.ListBox
{
	public class Agency
	{
		private string name;
		private string phone;
		private string zip;

		public Agency()
		{
		}

		public Agency(string name, string phone, string zip)
		{
			Name = name;
			Phone = phone;
			Zip = zip;
		}

		public string Name 
		{ 
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		public string Phone 
		{
			get
			{
				return this.phone;
			}
			set
			{
				this.phone = value;
			}
		}

		public string Zip
		{
			get
			{
				return this.zip;
			}
			set
			{
				this.zip = value;
			}
		}

		public override string ToString()
		{
			return string.Format("[Agency : {0}]", this.Name);
		}
	}
}