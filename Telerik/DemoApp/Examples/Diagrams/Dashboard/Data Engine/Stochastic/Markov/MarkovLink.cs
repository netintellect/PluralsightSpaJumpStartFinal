using System;
using System.Collections.Generic;
using System.Linq;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	/// <summary>
	/// An element of a Markov chain.
	/// </summary>
	/// <typeparam name="T">The data type of the link.</typeparam>
	[System.Diagnostics.DebuggerDisplay("Data: {Data}, Count: {Occurances}.")]
	internal class MarkovLink<T>
	{
		private static readonly Random rand = new Random();
		private readonly T data;
		private readonly Dictionary<T, MarkovLink<T>> links;
		private int count;

		/// <summary>
		/// Initializes a new instance of the <see cref="MarkovLink{T}" /> class.
		/// </summary>
		/// <param name="data">The data.</param>
		internal MarkovLink(T data)
		{
			this.data = data;
			this.count = 0;
			this.links = new Dictionary<T, MarkovLink<T>>();
		}

		public T Data
		{
			get
			{
				return this.data;
			}
		}

		public int Occurances
		{
			get
			{
				return this.count;
			}
		}

		/// <summary>
		/// Total number of incidences after this link.
		/// </summary>
		public int ChildOccurances
		{
			get
			{
				// sum all followers occurances
				var result = this.links.Sum(link => link.Value.Occurances);

				return result;
			}
		}

		/// <summary>
		/// Processes the input in chunks.
		/// </summary>
		/// <param name="input">The sample set.</param>
		/// <param name="length">The size of the sequence window.</param>
		public void Process(IEnumerable<T> input, int length)
		{
			var window = new Queue<T>(length);

			// process the input, a window at a time (overlapping)
			foreach (var part in input)
			{
				if (window.Count == length) window.Dequeue();
				window.Enqueue(part);
				this.ProcessWindow(window);
			}
		}

		/// <summary>
		/// Selects a random follower weighted towards followers that followed us more often in the sample set.
		/// </summary>
		public MarkovLink<T> SelectRandomLink()
		{
			MarkovLink<T> markovLink = null;

			var universe = this.ChildOccurances;

			// select a random probability
			var rnd = rand.Next(1, universe + 1);

			// match the probability by treating the followers as bands of probability
			var total = 0;
			foreach (var child in this.links.Values)
			{
				total += child.Occurances;
				if (total < rnd) continue;
				markovLink = child;
				break;
			}
			return markovLink;
		}

		/// <summary>
		/// Process an item following us keep track of how many times we are followed by each item.
		/// </summary>
		/// <param name="part">The element to process.</param>
		internal MarkovLink<T> Process(T part)
		{
			var link = this.Find(part);

			// not been followed by this item before
			if (link == null)
			{
				link = new MarkovLink<T>(part);
				this.links.Add(part, link);
			}

			link.Seen();

			return link;
		}

		/// <summary>
		/// A generated set of followers based on the likelihood of sequence steps seen in the sample data.
		/// </summary>
		/// <param name="start">A seed value to start the sequence with.</param>
		/// <param name="length">How big should the window be to use for sequence steps.</param>
		/// <param name="max">Maximum size of the set produced.</param>
		internal IEnumerable<MarkovLink<T>> Generate(T start, int length, int max)
		{
			var window = new Queue<T>(length);

			window.Enqueue(start);

			for (var link = this.Find(window); link != null && max != 0; link = this.Find(window), max--)
			{
				var next = link.SelectRandomLink();

				yield return link;

				if (window.Count == length - 1)
					window.Dequeue();
				if (next != null)
					window.Enqueue(next.Data);
			}
		}

		/// <summary>
		/// Process the window to construct the chain.
		/// </summary>
		/// <param name="window">The window of elements.</param>
		private void ProcessWindow(IEnumerable<T> window)
		{
			var link = this;
			window.Aggregate(link, (current, part) => current.Process(part));
		}

		private void Seen()
		{
			this.count++;
		}

		/// <summary>
		/// Finds a follower of this link.
		/// </summary>
		/// <param name="follower">The follower.</param>
		/// <returns></returns>
		private MarkovLink<T> Find(T follower)
		{
			MarkovLink<T> markovLink = null;

			if (this.links.ContainsKey(follower))
				markovLink = this.links[follower];

			return markovLink;
		}

		/// <summary>
		/// Find a window of followers that  are after this link, returns where the last link if found, or null if this window never occurred after this link.
		/// </summary>
		/// <param name="window">The sequence to look for.</param>
		private MarkovLink<T> Find(IEnumerable<T> window)
		{
			var link = this;

			foreach (var part in window)
			{
				link = link.Find(part);
				if (link == null)
					break;
			}

			return link;
		}
	}
}