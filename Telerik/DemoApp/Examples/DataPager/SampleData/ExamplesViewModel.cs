using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.DataPager;

namespace Telerik.Windows.Examples
{
	/// <summary>
	/// ExamplesViewModel.
	/// </summary>
	public class ExamplesViewModel
	{
		        private IEnumerable<MyBusinessObject> randomProducts;
		private IEnumerable<MyBusinessObject> largeRandomProducts;

		/// <summary>
		/// Gets the random products.
		/// </summary>
		/// <value>The random products.</value>
		public IEnumerable<MyBusinessObject> RandomProducts
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
		/// Gets the large random products.
		/// </summary>
		/// <value>The large random products.</value>
		public IEnumerable<MyBusinessObject> LargeRandomProducts
		{
			get
			{
				if (this.largeRandomProducts == null)
				{
					this.largeRandomProducts = new MyBusinessObjects().GetData(1000000).ToList();
				}

				return this.largeRandomProducts;
			}
		}

        object[] _pagerDisplayModes;
        public object[] PagerDisplayModes
        {
            get
            {
                if (_pagerDisplayModes == null)
                {
                    _pagerDisplayModes = EnumHelper.GetValues(typeof(PagerDisplayModes));
                }

                return _pagerDisplayModes;
            }
        }

        object[] _autoEllipsisModes;
        public object[] AutoEllipsisModes
        {
            get
            {
                if (_autoEllipsisModes == null)
                {
                    _autoEllipsisModes = EnumHelper.GetValues(typeof(AutoEllipsisModes));
                }

                return _autoEllipsisModes;
            }
        }
        
        EndlessPagedCollectionView _view;
        public EndlessPagedCollectionView View
        {
            get
            {
                if (_view == null)
                { 
                    _view = new EndlessPagedCollectionView();
                }

                return _view;
            }
        }
	}
}
