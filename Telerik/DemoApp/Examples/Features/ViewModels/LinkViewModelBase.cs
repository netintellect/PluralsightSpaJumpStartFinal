using System;
using System.Linq;
using Telerik.Windows.Diagrams.Core;

namespace Telerik.Windows.Diagrams.Features.ViewModels
{
    /// <summary>
    /// A generic base class for the link or connection in a diagram source.
    /// </summary>
    /// <typeparam name="T"> A type inheriting from <see cref="NodeViewModelBase"/>.
    /// </typeparam>
    /// <example>
    /// If you want to map the Content of the link to the Content of the connection you
    /// need to add a Style like so 
    /// <code lang="C#">
    /// &lt;Style  TargetType="telerik:RadDiagramConnection"&gt;
    ///   &lt;Setter Property="ContentTemplate"  &gt;
    ///     &lt;Setter.Value&gt;
    ///       &lt;DataTemplate&gt;
    ///         &lt;TextBlock Text="{Binding Content}"/&gt;
    ///       &lt;/DataTemplate&gt;
    ///     &lt;/Setter.Value&gt;
    ///   &lt;/Setter&gt;
    /// &lt;/Style&gt;
    /// </code>.
    /// </example>
	public class LinkViewModelBase<T> : ItemViewModelBase, ILink<T> where T : NodeViewModelBase
	{
        private CapType sourceCapType;
        private CapType targetCapType;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkViewModelBase&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
		public LinkViewModelBase(T source, T target)
		{
			this.Source = source;
			this.Target = target;
		}
		
        /// <summary>
        /// Gets or sets the source of the connection.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public T Source { get; set; }

        /// <summary>
        /// Gets or sets the target of this connection.
        /// </summary>
        /// <value>
        /// The target.
        /// </value>
        public T Target { get; set; }

        public CapType SourceCapType
        {
            get
            {
                return this.sourceCapType;
            }
            set
            {
                if (this.sourceCapType != value)
                {
                    this.sourceCapType = value;
                    this.OnPropertyChanged("SourceCapType");
                }
            }
        }

        public CapType TargetCapType
        {
            get
            {
                return this.targetCapType;
            }
            set
            {
                if (this.targetCapType != value)
                {
                    this.targetCapType = value;
                    this.OnPropertyChanged("TargetCapType");
                }
            }
        }

		object ILink.Source
		{
			get
			{
				return this.Source;
			}
			set
			{
				this.Source = value as T;
			}
		}

		object ILink.Target
		{
			get
			{
				return this.Target;
			}
			set
			{
				this.Target = value as T;
			}
		}
	}
}
