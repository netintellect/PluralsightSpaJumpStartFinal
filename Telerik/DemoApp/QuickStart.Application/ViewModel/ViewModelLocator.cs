using System;
using System.Collections.Generic;
using System.Linq;

namespace Telerik.Windows.QuickStart.ViewModel
{
	/// <summary>
	/// Locates the appropriate viewmodel instance for a certain view. Use ViewModelLocator.GetViewModel(INotifyUser) to get the viewmodel.
	/// Use ViewModelLocator.RegisterAssociation() to register a view type with its viewmodel type and caching option for that viewmodel type.
	/// </summary>
	public static class ViewModelLocator
	{
		/// <summary>
		/// Maps view types (keys) to viewmodel types (values)
		/// </summary>
		private static readonly Dictionary<Type, Type> associations = new Dictionary<Type, Type>();

		/// <summary>
		/// Contains created instances of viewmodel types that specified caching via RegisterAssociation().
		/// </summary>
		private static readonly Dictionary<Type, QuickStartViewModelBase> instancesCache = new Dictionary<Type, QuickStartViewModelBase>();

		/// <summary>
		/// Contains caching options for viewmodel types.
		/// </summary>
		private static readonly Dictionary<Type, bool> cacheSettings = new Dictionary<Type, bool>();

		public static void RegisterAssociation(Type view, Type viewModel, bool shouldCacheViewModel = false)
		{
			if (!associations.ContainsKey(view))
			{
				associations.Add(view, viewModel);
			}

			if (!cacheSettings.ContainsKey(viewModel))
			{
				cacheSettings.Add(viewModel, shouldCacheViewModel);
			}
		}

		public static QuickStartViewModelBase GetViewModel(INotifyUser owner)
		{
			if (owner == null || !associations.ContainsKey(owner.GetType()))
			{
				throw new ArgumentException("Owner should not be null and should be registered via RegisterAssociation()", "owner");
			}

			Type viewType = owner.GetType();
			Type viewModelType = associations[viewType];
			QuickStartViewModelBase result = null;
			bool shouldCacheViewModel = cacheSettings[viewModelType];

			if (shouldCacheViewModel)
			{
				if (instancesCache.ContainsKey(viewModelType))
				{
					result = instancesCache[viewModelType];
				}
				else
				{
					result = InstantiateViewModel(viewType, owner);
					instancesCache.Add(viewModelType, result);
				}
			}
			else
			{
				result = InstantiateViewModel(viewType, owner);
			}

			return result;
		}
  
		private static QuickStartViewModelBase InstantiateViewModel(Type viewType, INotifyUser owner)
		{
			return (QuickStartViewModelBase)Activator.CreateInstance(associations[viewType], owner);
		}
	}
}