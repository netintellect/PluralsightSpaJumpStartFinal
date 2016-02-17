using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using Telerik.Windows.Documents.Code.Text;
using Telerik.Windows.QuickStart.Parsers;
using Telerik.Windows.QuickStart.ServiceReference1;

namespace Telerik.Windows.QuickStart
{
	public class CodeViewer : ContentControl
	{
		// Using a DependencyProperty as the backing store for XAMLContentTemplate.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty XAMLContentTemplateProperty =
		DependencyProperty.Register("XAMLContentTemplate", typeof(DataTemplate), typeof(CodeViewer), null);

		// Using a DependencyProperty as the backing store for CodeContentTemplate.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CodeContentTemplateProperty =
		DependencyProperty.Register("CodeContentTemplate", typeof(DataTemplate), typeof(CodeViewer), null);

		public static readonly DependencyProperty SourceProperty =
		DependencyProperty.Register("Source", typeof(Uri), typeof(CodeViewer), new PropertyMetadata(null, new PropertyChangedCallback(CodeViewer.OnSourcePropertyChanged)));

		public DataTemplate XAMLContentTemplate
		{
			get
			{
				return (DataTemplate)GetValue(XAMLContentTemplateProperty);
			}
			set
			{
				SetValue(XAMLContentTemplateProperty, value);
			}
		}

		public DataTemplate CodeContentTemplate
		{
			get
			{
				return (DataTemplate)GetValue(CodeContentTemplateProperty);
			}
			set
			{
				SetValue(CodeContentTemplateProperty, value);
			}
		}

		public Uri Source
		{
			get
			{
				return (Uri)GetValue(SourceProperty);
			}
			set
			{
				SetValue(SourceProperty, value);
			}
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.ChangeSource();
		}

		private static void OnSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
		{
			(sender as CodeViewer).ChangeSource();
		}

		private void ChangeSource()
		{
            if (this.Source != null)
            {
                string codeFileName = this.Source.OriginalString;
                string codeFileText = ResourceToStreamHelper.ExtractSourceCodeFromSource(this.Source);

                if (!string.IsNullOrEmpty(codeFileName))
                {
                    if (codeFileName.EndsWith(".cs"))
                    {
                        this.DisplayCSharpOrVBFile(codeFileText);
                    }
                    else
                    {
                        this.DisplayOtherCodeFile(codeFileText, codeFileName);
                    }
                }
            }
		}

		private void DisplayOtherCodeFile(string codeFileText, string codeFileName)
		{
			string codeFileNameExtension = codeFileName.Substring(codeFileName.LastIndexOf("."));

			// taking first linesCount rows from very long XML files (otherwise they load too long and block the UI)
			if (codeFileNameExtension == ".xml")
			{
				int linesCount = 1500;
				codeFileText = string.Concat(string.Format("Loaded first {0} rows from file.\n", linesCount), codeFileText);
				var lines = codeFileText.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Take(linesCount).ToArray();
				codeFileText = string.Join(Environment.NewLine, lines);
			}

			DependencyObject templateContent = this.XAMLContentTemplate.LoadContent();
			this.PrepareCodeViewerForOtherCode(templateContent, codeFileText);
			this.Content = templateContent;
		}

		private void DisplayCSharpOrVBFile(string codeFileText)
		{
			RadTabControl tabControl = this.CodeContentTemplate.LoadContent() as RadTabControl;

			// make sure tabcontrol is styled with win8 theme, as this bug regresses often
			ApplicationThemeManager.EnsureFrameworkElementResourcesForTheme(tabControl, "Windows8");

			RadCodeEditor codeViewer = this.PrepareCodeViewerForCSharpCode(tabControl, codeFileText);

			// prepare C# tab
			var tabCSharp = tabControl.Items[0] as RadTabItem;
			tabCSharp.Content = codeViewer;

			// prepare VB.NET tab
			RadSelectionChangedEventHandler selectionChangedEventHandler = null;
			RoutedEventHandler unloadedHandler = null;

			unloadedHandler = (sender, args) =>
			{
				(sender as RadTabControl).Unloaded -= unloadedHandler;
				(sender as RadTabControl).SelectionChanged -= selectionChangedEventHandler;
			};

			selectionChangedEventHandler = (sender, args) =>
			{
				if (tabControl.SelectedIndex == 1)
				{
					tabControl.SelectionChanged -= selectionChangedEventHandler;
					using (ConvertServiceSoapClient service = new ConvertServiceSoapClient("ConvertServiceSoap"))
					{
						var requestBody = new ConvertRequestBody("cs2vbnet", codeFileText);
						var request = new ConvertRequest(requestBody);
						EventHandler<ConvertCompletedEventArgs> convertCompleted = null;
						convertCompleted = (s, e) =>
						{
							service.ConvertCompleted -= convertCompleted;
							string convertedCode = e.Result.Body.ConvertedCode.Replace("\t", "    ").Replace("\n", "\r\n");
							var codeEditor = tabControl.ItemTemplate.LoadContent() as RadCodeEditor;
							codeEditor.Document = e.Error == null ? new TextDocument(convertedCode) : new TextDocument(e.Error.Message);
							this.PrepareSyntaxHighlighting(codeEditor, "vb");

							var vbTab = tabControl.Items[1] as RadTabItem;
							vbTab.Content = codeEditor;
						};

						service.ConvertCompleted += convertCompleted;
						service.ConvertAsync(request);
					}
				}
			};

			tabControl.SelectionChanged += selectionChangedEventHandler;
			tabControl.Unloaded += unloadedHandler;

			if (ApplicationOptions.DefaultCodeViewerLanguage == CodeViewerLanguages.VB)
			{
				tabControl.SelectedIndex = 1;
			}

			this.Content = tabControl;
		}

		private RadCodeEditor PrepareCodeViewerForOtherCode(DependencyObject templateContent, string codeFileText)
		{
			var codeViewer = templateContent as RadCodeEditor ?? templateContent.FindChildByType<RadCodeEditor>();
			if (codeViewer == null)
			{
				throw new InvalidOperationException("CodeViewer doesn't have correct template to load.");
			}

			// Loading from XamlTemplate
			this.PrepareSyntaxHighlighting(codeViewer, "xaml");
			this.SetCodeViewerLineNumbersBackgroundToTransparent(codeViewer);

			codeViewer.Document = new TextDocument(codeFileText);
			return codeViewer;
		}

		private RadCodeEditor PrepareCodeViewerForCSharpCode(RadTabControl templateContent, string codeFileText)
		{
			RadCodeEditor codeViewer;
			var tabControl = templateContent ?? templateContent.FindChildByType<RadTabControl>();
			if (tabControl == null)
			{
				throw new InvalidOperationException("CodeViewer doesn't have correct template to load.");
			}
			else
			{
				codeViewer = tabControl.ItemTemplate.LoadContent() as RadCodeEditor;
				this.PrepareSyntaxHighlighting(codeViewer, "cs");
				this.SetCodeViewerLineNumbersBackgroundToTransparent(codeViewer);
			}

			codeViewer.Document = new TextDocument(codeFileText);
			return codeViewer;
		}

		private void PrepareSyntaxHighlighting(RadCodeEditor codeViewer, string language)
		{
			switch (language)
			{
				case "cs":
					codeViewer.TaggersRegistry.RegisterTagger(new CSharpTagger(codeViewer));
					break;
				case "vb":
					codeViewer.TaggersRegistry.RegisterTagger(new VisualBasicTagger(codeViewer));
					break;
				case "xaml":
				default:
					codeViewer.TaggersRegistry.RegisterTagger(new XamlTagger(codeViewer));

					codeViewer.TextFormatDefinitions.AddLast(XamlSyntaxHighlightingHelper.XamlAttribute, XamlSyntaxHighlightingHelper.XamlAttributeFormatDefinition);
					codeViewer.TextFormatDefinitions.AddLast(XamlSyntaxHighlightingHelper.XamlElement, XamlSyntaxHighlightingHelper.XamlElementFormatDefinition);
					codeViewer.TextFormatDefinitions.AddLast(XamlSyntaxHighlightingHelper.XamlComment, XamlSyntaxHighlightingHelper.XamlCommentFormatDefinition);
					codeViewer.TextFormatDefinitions.AddLast(XamlSyntaxHighlightingHelper.XamlContent, XamlSyntaxHighlightingHelper.XamlContentFormatDefinition);
					codeViewer.TextFormatDefinitions.AddLast(XamlSyntaxHighlightingHelper.XamlString, XamlSyntaxHighlightingHelper.XamlStringFormatDefinition);
					codeViewer.TextFormatDefinitions.AddLast(XamlSyntaxHighlightingHelper.XamlTag, XamlSyntaxHighlightingHelper.XamlTagFormatDefinition);
					break;
			}
		}


		private void SetCodeViewerLineNumbersBackgroundToTransparent(RadCodeEditor codeViewer)
		{
			codeViewer.Margins.ScrollableLeft.Clear();
			codeViewer.Margins.ScrollableLeft.Add(new Telerik.Windows.Controls.CodeEditor.UI.Margins.LineNumberMargin(codeViewer)
			{
				Background = System.Windows.Media.Brushes.Transparent
			});
		}
	}
}
