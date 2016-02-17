using System.Collections.Generic;
using System.Linq;

namespace Telerik.Windows.Examples.DataFilter
{
	/// <summary>
	/// ExamplesViewModel.
	/// </summary>
	public class ExamplesViewModel
	{
		private IList<MyBusinessObject> randomProducts;
		private IList<Club> clubs;

		/// <summary>
		/// Gets the random products.
		/// </summary>
		/// <value>The random products.</value>
		public IList<MyBusinessObject> RandomProducts
		{
			get
			{
				if (this.randomProducts == null)
				{
					this.randomProducts = new MyBusinessObjects().GetData(100).ToList();
				}

				return this.randomProducts;
			}
		}
		
		/// <summary>
		/// Gets the random products.
		/// </summary>
		/// <value>The random products.</value>
		public IList<MyBusinessObject> LargeRandomProducts
		{
			get
			{
				if (this.randomProducts == null)
				{
					this.randomProducts = new MyBusinessObjects().GetData(1000).ToList();
				}

				return this.randomProducts;
			}
		}
		
		/// <summary>
		/// Gets the random products.
		/// </summary>
		/// <value>The random products.</value>
		public IList<Club> Clubs
		{
			get
			{
				if (this.clubs == null)
				{
					this.clubs = Club.GetClubs();
				}

				return this.clubs;
			}
		}
	}
}
