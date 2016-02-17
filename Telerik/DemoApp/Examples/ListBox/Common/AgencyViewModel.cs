using System.Collections.ObjectModel;
using System;

namespace Telerik.Windows.Examples.ListBox
{
	public class AgencyViewModel
	{
		private ObservableCollection<Agency> agencies;

		public ObservableCollection<Agency> Agencies
		{
			get
			{
				if (agencies == null)
				{
					agencies = new ObservableCollection<Agency>();
					agencies.Add(new Agency("Exotic Liquids", "(171) 555-2222", "EC1 4SD"));
					agencies.Add(new Agency("New Orleans Cajun Delights", "(100) 555-4822", "70117"));
					agencies.Add(new Agency("Grandma Kelly's Homestead", "(313) 555-5735", "48104"));
					agencies.Add(new Agency("Tokyo Traders", "(03) 3555-5011", "100"));
					agencies.Add(new Agency("Cooperativa de Quesos 'Las Cabras'", "(98) 598 76 54", "33007"));
					agencies.Add(new Agency("Mayumi's", "(06) 431-7877", "545"));
					agencies.Add(new Agency("Pavlova, Ltd.", "(03) 444-2343", "3058"));
					agencies.Add(new Agency("Specialty Biscuits, Ltd.", "(161) 555-4448", "M14 GSD"));
					agencies.Add(new Agency("PB Knäckebröd AB", "031-987 65 43", "S-345 67"));
					agencies.Add(new Agency("Refrescos Americanas LTDA", "(11) 555 4640", "5442"));
				}
				return agencies;
			}
		}

		
	}
}