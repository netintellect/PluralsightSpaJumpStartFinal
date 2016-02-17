using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Telerik.Windows.Documents.Model;

namespace Telerik.Windows.Examples.DesktopAlert.FirstLook
{
    public static class EmailService
    {
        private static readonly List<string> content = new List<string>
        {
            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.",
            "At Telerik Corporation, we realize that customer feedback is becoming more and more critical to doing business efficiently. That's why I'm writing to inform you that we are creating a new community web site for the following control packages: Silverlight controls WPF controls WinForms There will be several support officers who will gather feedback about the products during the 6 month trial of the site. Your assigned support officer is Matti Karttunen. Feel free to send him mail with any questions or suggestions. Your feedback will really give our business a clear idea of how to best serve our customers and become more reliable. Our support officer Matti Karttunen will send a mail to talk over the matter further and see if you accept our test site account and will participate in this clients program. Thank you for your attention. ",
            "RadRichTextBox is a control that offers Microsoft Word-like authoring and editing in your applications using a familiar interface for end users. The experience is enhanced by the support of multilevel bullet and numbered lists, tables, inline and floating images. More advanced options include external and in-document hyperlinks, bookmarks and comments.  The control can preview and edit text in various languages thanks to the Input Method Editor and the Right-to-Left support, which makes it an appropriate choice in a wide range of applications. Even more sweetness is added by the integrated spell-checker and image editor allowing immediate detection and correction of spelling mistakes and in-place tweaking of images. ",
            "RadRichTextBox provides two convenient ways to insert additional information about content in the document without inserting it in the main body directly. These are the footnotes and endnotes, which provide a natural way for introducing supplementary information without interrupting the flow of thought.",
            "In English, however, the meaning is rather different. It means a word that has been created by combining the morphemes of two other words, just how 'entrance' and 'coat' have been combined to form the 'porte-manteau' term. Some of the examples include chocoholic (from 'chocolate' and 'holic', as in 'alcoholic'), smog (from 'smoke'and 'fog') and wurly (from 'wavy' and 'curly', used to describe hair)4. The popularity of each new developed term gains determines if the word will be used only by a closed circle of people, or will become part of the speech, and subsequently – of the language.",
            "RadRichTextBox has a concept of styles which allows you to use a set of predefined styling rules for document elements. One of the types of styles which you can use in the control is Table styles. They can be applied and manipulated using the table styles gallery which is part of the predefined RadRichTextBoxRibbonUI. Once a style is applied to a particular table every change in its properties will result in a change in the instance in the current document as well. All properties related to the formatting can be viewed and modified through the Modify style dialog. You can also change the Table Style Options from the Design ribbon tab.",
            "RadDesktopAlert is a control that allows you to display notifications on the desktop when a specific event in the application has occurred (new e-mail message, meeting request or task request is received). The alert can be shown for a specified amount of time and will automatically close after that time has elapsed."
        };

        private static readonly List<string> emailSubjects = new List<string>
        {
            "Let's have a party for new years eve",
            "New application brainstorming",
            "New application brainstorming",
            "Happy Birthday",
            "Plan your summer holiday now!",
            "Don't miss this month's discounts",
            "Action required",
            "Action required",
            "Will be late today",
            "Need recommendation"
        };

        private static readonly List<string> emailSubjectPrefixes = new List<string>
        {
            string.Empty,
            "FW: ",
            "RE: ",
            string.Empty,
        };

        private static readonly List<string> firstNames = new List<string>
        {
            "Ricky",
            "Alan",
            "Seth",
            "John",
            "Daniel",
            "Jimmie",
            "Tom",
            "Cruz",
            "Vince",
            "Colin"
        };

        private static readonly List<string> lastNames = new List<string>
        {
            "Barley",
            "Fields",
            "Hillsman",
            "Hosking",
            "Gabel",
            "Zander",
            "Cavins",
            "Benz",
            "Trudell",
            "Brim"
        };

        private static readonly List<string> domains = new List<string>
        {
            "telerikdomain.com",
            "telerikdomain.net",
            "telerikdomain.eu",
            "telerikdomain.de",
            "telerikdomain.es",
            "telerikdomain.bg",
            "telerikdomain.ru",
            "telerikdomain.uk",
            "telerikdomain.fr",
            "telerikdomain.it"
        };

        public static ObservableCollection<Email> GetEmails(int size)
        {
            var now = DateTime.Now;
            var result = new ObservableCollection<Email>();
            int dateIncrement = 0;
            var rand = new Random();

            for (int i = 1; i <= size; i++)
            {
                var subject = EmailService.GetRandomEmailSubject(rand.Next());
                var status = i % 3 == 0 ? EmailStatus.Unread : EmailStatus.Read;
                var from = EmailService.GetRandomEmailAddress(rand.Next());
                var to = EmailService.GetRandomEmailAddress(rand.Next());
                if (i % 10 == 0)
                {
                    dateIncrement++;
                }

                var receivedDate = now.AddDays(-dateIncrement);
                result.Add(new Email(from, to, subject, receivedDate)
                {
                    Content = CreateDocument(rand.Next()),
                    Status = status
                });
            }

            return result;
        }

        private static RadDocument CreateDocument(int seed)
        {
            var document = new RadDocument();
            var section = new Section();
            var paragraph1 = new Paragraph();
            section.Blocks.Add(paragraph1);
            var paragraph2 = new Paragraph();
            paragraph2.TextAlignment = Telerik.Windows.Documents.Layout.RadTextAlignment.Center;
            var span1 = new Span("Thank you for choosing Telerik");
            paragraph2.Inlines.Add(span1);
            var span2 = new Span();
            span2.Text = " RadDesktopAlert!";
            span2.FontWeight = FontWeights.Bold;
            paragraph2.Inlines.Add(span2);
            section.Blocks.Add(paragraph2);
            var rand = new Random(seed);
            var paragraph3 = new Paragraph();
            var span3 = new Span(content[rand.Next(content.Count)]);
            paragraph3.Inlines.Add(span3);
            section.Blocks.Add(paragraph3);
            section.Blocks.Add(new Paragraph());
            document.Sections.Add(section);

            return document;
        }

        private static string GetRandomEmailSubject(int seed)
        {
            var rand = new Random(seed);

            return emailSubjectPrefixes[rand.Next(emailSubjectPrefixes.Count)] + emailSubjects[rand.Next(emailSubjects.Count)];
        }

        private static string GetRandomEmailAddress(int seed)
        {
            var rand = new Random(seed);
            var firstName = EmailService.firstNames[rand.Next(firstNames.Count)];
            var lastName = EmailService.lastNames[rand.Next(lastNames.Count)];
            var domain = EmailService.domains[rand.Next(domains.Count)];

            return string.Format("{0}{1}@{2}", firstName, lastName, domain);
        }
    }
}
