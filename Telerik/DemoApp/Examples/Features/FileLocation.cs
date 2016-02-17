using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Microsoft.Win32;

namespace Telerik.Windows.Diagrams.Features
{
	/// <summary>
	/// Enumerates the storage targets.
	/// </summary>
	public enum FileLocation
	{
		/// <summary>
		/// The local user disk.
		/// </summary>
		Disk,

		/// <summary>
		/// The application's isolated storage.
		/// </summary>
		IsolatedStorage
	}
}
