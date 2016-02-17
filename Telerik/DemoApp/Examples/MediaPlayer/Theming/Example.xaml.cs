using System;
using Microsoft.Expression.Encoder.AdaptiveStreaming;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.MediaPlayer.Theming
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();
		}

		private void RadMediaItem_StreamAttached(object sender, EventArgs e)
		{
			RadMediaItem item = sender as RadMediaItem;
			if (item != null)
			{
				AdaptiveStreamingSource adaptiveSource = new AdaptiveStreamingSource();
				adaptiveSource.MediaElement = this.player.MediaElement;
				adaptiveSource.ManifestUrl = item.Source;
				adaptiveSource.PlayBitrateChange += adaptiveSource_PlayBitrateChange;

				adaptiveSource.StartPlayback();
			}
		}

		void adaptiveSource_PlayBitrateChange(object sender, BitrateChangedEventArgs e)
		{
			this.player.Header = e.Bitrate;
		}
	}
}
