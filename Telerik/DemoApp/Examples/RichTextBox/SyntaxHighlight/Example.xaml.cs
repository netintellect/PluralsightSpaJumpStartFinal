﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Telerik.Windows.Documents.Layout;
using Telerik.Windows.Documents.Model;
using Telerik.Windows.Examples.RichTextBox.Parsers;

namespace Telerik.Windows.Examples.RichTextBox.SyntaxHighlight
{
    public partial class Example : UserControl
    {
        #region Constants

        private static readonly string XamlResource = "SampleData/SampleXAML.txt";
        private static readonly string CsResource = "SampleData/SampleCS.txt";

        #endregion

        #region Fields

        private RadDocument XamlDocument;
        private RadDocument CsDocument;

        #endregion

        #region Constructors

        public Example()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        void SyntaxHighlighTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadSampleXamlDocument();
        }

        private void LoadXaml_Click(object sender, RoutedEventArgs e)
        {
            this.LoadSampleXamlDocument();
        }

        private void LoadCS_Click(object sender, RoutedEventArgs e)
        {
            this.LoadSampleCsDocument();
        }

        private void ToggleFormattingSymbols_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = (ToggleButton)sender;
            this.Editor.ShowFormattingSymbols = toggleButton.IsChecked ?? false;
        }

        private void LoadSampleXamlDocument()
        {
            if (this.XamlDocument == null)
            {
                Stream xamlStream = Application.GetResourceStream(
                    GetResourceUri(SyntaxHighlight.Example.XamlResource)).Stream;

                using (StreamReader reader = new StreamReader(xamlStream))
                {
                    this.XamlDocument = CreateFormattedDocument(reader.ReadToEnd(), ".xaml");
                }
            }

            this.Editor.Document = this.XamlDocument;
        }

        private void LoadSampleCsDocument()
        {
            if (this.CsDocument == null)
            {
                Stream csStream = Application.GetResourceStream(
                    GetResourceUri(SyntaxHighlight.Example.CsResource)).Stream;

                using (StreamReader reader = new StreamReader(csStream))
                {
                    this.CsDocument = CreateFormattedDocument(reader.ReadToEnd(), ".cs");
                }
            }

            this.Editor.Document = this.CsDocument;
        }

        private RadDocument CreateFormattedDocument(string text, string fileFormat)
        {
            RadDocument document = new RadDocument();
            document.LayoutMode = DocumentLayoutMode.Flow;
            document.SectionDefaultPageMargin = new Padding(25);

            Section section = new Section();
            document.Sections.Add(section);

            Tokenizer tokenizer = new Tokenizer();
            List<Token> tokens = tokenizer.TokenizeCode(text, fileFormat);

            Paragraph currentParagraph = new Paragraph();
            currentParagraph.SpacingAfter = 0;
            section.Blocks.Add(currentParagraph);
            foreach (Token token in tokens)
            {
                string[] lines = Regex.Split(token.Value, DocumentEnvironment.NewLine);

                bool createParagraph = false;
                foreach (string line in lines)
                {
                    if (createParagraph)
                    {   
                        currentParagraph = new Paragraph();
                        currentParagraph.SpacingAfter = 0;
                        section.Blocks.Add(currentParagraph);
                    }
                    createParagraph = true;

                    if (!string.IsNullOrEmpty(line))
                    {
                        Span span = token.GetSpanStyle();
                        span.Text = line;
                        currentParagraph.Inlines.Add(span);
                    }
                }
            }
            
            return document;
        }

        private static Uri GetResourceUri(string resource)
        {
            AssemblyName assemblyName = new AssemblyName(typeof(SyntaxHighlight.Example).Assembly.FullName);
            string resourcePath = "/" + assemblyName.Name + ";component/" + resource;

            Uri resourceUri = new Uri(resourcePath, UriKind.Relative);

            return resourceUri;
        }

        #endregion
    }
}