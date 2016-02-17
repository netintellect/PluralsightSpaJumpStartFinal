using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace Telerik.Windows.Examples.SpellChecker.SampleData
{
    public class ExamplesDataContext
    {
        private ObservableCollection<Employee> employees;

        public ObservableCollection<Employee> Employees
        {
            get 
            {
                if (this.employees == null)
                {
                    this.employees = new ObservableCollection<Employee>(new List<Employee>()
                    {
                        new Employee()
                        {
                            FirstName = "Andrew",
                            LastName = "Fuller", 
                            JobTitle = "Director - Finance",
                            EmployeeDescription = "Andrew was boorn in 1959 and is a graduat of Manchester University and the Manchester Business School in the UK.  He joined British American Tobacco in 1990 as Regional Finance Controller with responsibilties for Europe, East Africa and South Asia and in 1994 moved to Switzerland where he worked in a variety of marketing roles.", 
                            JobDescription = "<t:RadDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:t=\"clr-namespace:Telerik.Windows.Documents.Model;assembly=Telerik.Windows.Documents\" version=\"1.0\" DefaultPageLayoutSettings=\"800,1140\" LayoutMode=\"Flow\" PageViewMargin=\"10,10\">\r\n  <t:Section>\r\n    <t:Paragraph>\r\n      <t:Span Text=\"Undi\" />\r\n      <t:Span HighlightColor=\"#FFFFFF00\" Text=\"er policy dirrecti\" />\r\n      <t:Span Text=\"on, \" />\r\n      <t:Span ForeColor=\"#FFFF0000\" Text=\"plans, organizess\" />\r\n      <t:Span Text=\" and directs the activities of the Financce \" />\r\n      <t:Span FontSize=\"18.6666666666667\" Text=\"Department; man\" />\r\n      <t:Span Text=\"ages an\" />\r\n      <t:Span Strikethrough=\"True\" Text=\"d directs the prov\" />\r\n      <t:Span Text=\"iscion of i\" />\r\n      <t:Span FontWeight=\"Bold\" Text=\"nvestment \" />\r\n      <t:Span Text=\"a\" />\r\n      <t:Span FontStyle=\"Italic\" Text=\"nd treasury servicecs\" />\r\n      <t:Span Text=\", fin\" />\r\n      <t:Span Text=\"ancial analysis and budgecti\" />\r\n      <t:Span Text=\"ng,\" />\r\n      <t:Span FontWeight=\"Bold\" Text=\" accounting, billi\" />\r\n      <t:Span Text=\"ng, de\" />\r\n      <t:Span FontSize=\"13.3333333333333\" Text=\"veloper services, rate set\" />\r\n      <t:Span Text=\"ting, ri\" />\r\n      <t:Span FontSize=\"13.33\" Text=\"sk management and mete\" />\r\n      <t:Span Text=\"r servcices for the Dis\" />\r\n      <t:Span Strikethrough=\"True\" Text=\"trict and its custom\" />\r\n      <t:Span Text=\"ers; ser\" />\r\n      <t:Span ForeColor=\"#FFFF0000\" Text=\"ves as treasurer and m\" />\r\n      <t:Span Text=\"anages acc\" />\r\n      <t:Span HighlightColor=\"#FFFFFF00\" Text=\"ounting, financial, pa\" />\r\n      <t:Span Text=\"yroull a\" />\r\n      <t:Span FontStyle=\"Italic\" Text=\"nd other services for th\" />\r\n      <t:Span Text=\"e SNWA; provides expert \" />\r\n      <t:Span FontWeight=\"Bold\" Text=\"professional assistansce an\" />\r\n      <t:Span Text=\"d gui\" />\r\n      <t:Span Text=\"dance to manageeme\" />\r\n      <t:Span Text=\"nt on debt fina\" />\r\n      <t:Span ForeColor=\"#FFFF0000\" Text=\"ncing, fiscal, acco\" />\r\n      <t:Span Text=\"unting and related \" />\r\n      <t:Span FontStyle=\"Italic\" Text=\"matters; and performss relat\" />\r\n      <t:Span Text=\"ed duties as assigned.\" />\r\n    </t:Paragraph>\r\n    <t:Paragraph />\r\n  </t:Section>\r\n</t:RadDocument>",
                        }, 
                        new Employee()
                        {
                            FirstName = "Nancy",
                            LastName = "Davolio", 
                            JobTitle = "Director - Human Resources",
                            EmployeeDescription = "Nancy took on this role having joined Digicel in May 2008 to focus on Human Resources in the Eastern Caribbean markeets. Prior to that, Nancy haf spent eight months in the Caribbean working for a start-up airline.", 
                            JobDescription = "<t:RadDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:t=\"clr-namespace:Telerik.Windows.Documents.Model;assembly=Telerik.Windows.Documents\" version=\"1.0\" DefaultPageLayoutSettings=\"800,1140\" LayoutMode=\"Flow\" PageViewMargin=\"10,10\">\r\n  <t:Section>\r\n    <t:Paragraph>\r\n      <t:Span Text=\"Un\" />\r\n      <t:Span HighlightColor=\"#FF537DB1\" Text=\"der policiy direction\" />\r\n      <t:Span Text=\", planss, or\" />\r\n      <t:Span ForeColor=\"#FFA589C7\" Text=\"ganizes, directss and impl\" />\r\n      <t:Span Text=\"ementss comp\" />\r\n      <t:Span FontSize=\"18.6666666666667\" Text=\"rehednsive District\" />\r\n      <t:Span Text=\"-wid\" />\r\n      <t:Span FontWeight=\"Bold\" Text=\"e human resourcdes mana\" />\r\n      <t:Span Text=\"gemednt p\" />\r\n      <t:Span FontStyle=\"Italic\" Text=\"rograms, including recruidtment, s\" />\r\n      <t:Span Text=\"electi\" />\r\n      <t:Span Text=\"on, employment, class\" />\r\n      <t:Span Text=\"ification, comp\" />\r\n      <t:Span FontSize=\"13.3333333333333\" Text=\"ensation, employee relatio\" />\r\n      <t:Span Text=\"ns, m\" />\r\n      <t:Span Text=\"anagedment and employee devel\" />\r\n      <t:Span Text=\"opmdent, perf\" />\r\n      <t:Span FontWeight=\"Bold\" Text=\"ormance appraisal, bene\" />\r\n      <t:Span Text=\"fits, sa\" />\r\n      <t:Span FontStyle=\"Italic\" Text=\"fety and occudpational health, a\" />\r\n      <t:Span Text=\"nd ot\" />\r\n      <t:Span Text=\"her services; provides ex\" />\r\n      <t:Span Text=\"pert p\" />\r\n      <t:Span ForeColor=\"#FFA589C7\" Text=\"rofedssional assisdtance and guidanc\" />\r\n      <t:Span Text=\"e to Dis\" />\r\n      <t:Span HighlightColor=\"#FF537DB1\" Text=\"trict management on human r\" />\r\n      <t:Span Text=\"esource\" />\r\n      <t:Span Strikethrough=\"True\" Text=\" and emplodyee reldations mat\" />\r\n      <t:Span Text=\"ters; and \" />\r\n      <t:Span FontStyle=\"Italic\" Text=\"perfdorms reldated duties as assi\" />\r\n      <t:Span Text=\"gned.\" />\r\n    </t:Paragraph>\r\n    <t:Paragraph />\r\n  </t:Section>\r\n</t:RadDocument>",
                        },
                        new Employee()
                        {
                            FirstName = "Robert",
                            LastName = "King", 
                            JobTitle = "Engineering Design Manager",
                            EmployeeDescription = "Robert manags the Highway Engineering grup for the Northern Region. His team consists of 17 technical staff and his business unit consists of three groups: Highway Design, Survey, and Traffic Engineering. His region extends just south of Prince George, nortg to the BC/Yukon border, west to the Queen Charlottes, and eastt to the BC/Alberta border.", 
                            JobDescription = "<t:RadDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:t=\"clr-namespace:Telerik.Windows.Documents.Model;assembly=Telerik.Windows.Documents\" version=\"1.0\" DefaultPageLayoutSettings=\"800,1140\" LayoutMode=\"Flow\" PageViewMargin=\"10,10\">\r\n  <t:Section>\r\n    <t:Paragraph>\r\n      <t:Span Text=\"Pl\" />\r\n      <t:Span HighlightColor=\"#FF6E8E2C\" Text=\"ans, organizess, controls, inte\" />\r\n      <t:Span Text=\"grates\" />\r\n      <t:Span ForeColor=\"#FFCA6919\" Text=\" and evaluatess the work of\" />\r\n      <t:Span Text=\" D\" />\r\n      <t:Span FontWeight=\"Bold\" Text=\"esign Division in t\" />\r\n      <t:Span Text=\"he Eng\" />\r\n      <t:Span FontStyle=\"Italic\" Text=\"ineering Department; with\" />\r\n      <t:Span Text=\" subordi\" />\r\n      <t:Span Text=\"nate supervidsors and \" />\r\n      <t:Span Strikethrough=\"True\" Text=\"staff, develops, impleme\" />\r\n      <t:Span Text=\"nts a\" />\r\n      <t:Span FontSize=\"18.6666666666667\" Text=\"nd monitors long-term plan\" />\r\n      <t:Span Text=\"s, go\" />\r\n      <t:Span FontSize=\"13.3333333333333\" Text=\"als and objecdtives focus\" />\r\n      <t:Span Text=\"ed o\" />\r\n      <t:Span FontStyle=\"Italic\" Text=\"n achieving the dedpartment’s mission a\" />\r\n      <t:Span Text=\"nd a\" />\r\n      <t:Span Text=\"ssigned priorities; partici\" />\r\n      <t:Span Text=\"patdes\" />\r\n      <t:Span HighlightColor=\"#FF6E8E2C\" Text=\" in the dedvelopment of \" />\r\n      <t:Span Text=\"and m\" />\r\n      <t:Span ForeColor=\"#FFCA6919\" Text=\"onitors performance against\" />\r\n      <t:Span Text=\" the an\" />\r\n      <t:Span FontStyle=\"Italic\" Text=\"nual dividsion/unit buddget; m\" />\r\n      <t:Span Text=\"ana\" />\r\n      <t:Span Text=\"ges and directs the development, i\" />\r\n      <t:Span Text=\"mple\" />\r\n      <t:Span FontSize=\"18.6666666666667\" Text=\"mentdation and evadluation of plan\" />\r\n      <t:Span Text=\"s, po\" />\r\n      <t:Span Strikethrough=\"True\" Text=\"licies, systems and pro\" />\r\n      <t:Span Text=\"cedures \" />\r\n      <t:Span ForeColor=\"#FFCA6919\" Text=\"to achieve annual goals, o\" />\r\n      <t:Span Text=\"bjectives\" />\r\n      <t:Span FontStyle=\"Italic\" FontWeight=\"Bold\" Text=\" and work standards\" />\r\n      <t:Span Text=\".\" />\r\n    </t:Paragraph>\r\n    <t:Paragraph />\r\n    <t:Paragraph />\r\n  </t:Section>\r\n</t:RadDocument>",
                        },
                        new Employee()
                        {
                            FirstName = "Margaret",
                            LastName = "Peacock", 
                            JobTitle = "Finance & Investments Officer",
                            EmployeeDescription = "Margaret Peacock is the Chief Executive Officer of Boston Financial. She has 15 years of experience in the low-income housing tax credit industry as a senior executive and tax attorney. Prior to joining Boston Financial, Margaret Peacock was a Senior Vice President at Alliant Asset Management Company, LLC. From 2001 to 2008, Margaret Peacock was responsible for supervising that firm's acquisition department.",
                            JobDescription = "<t:RadDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:t=\"clr-namespace:Telerik.Windows.Documents.Model;assembly=Telerik.Windows.Documents\" version=\"1.0\" DefaultPageLayoutSettings=\"800,1140\" LayoutMode=\"Flow\" PageViewMargin=\"10,10\">\r\n  <t:Section>\r\n    <t:Paragraph>\r\n      <t:Span Text=\"Un\" />\r\n      <t:Span HighlightColor=\"#FF1E7F99\" Text=\"der generall directi\" />\r\n      <t:Span Text=\"on, indepe\" />\r\n      <t:Span ForeColor=\"#FF92D050\" Text=\"ndently performss difficulta a\" />\r\n      <t:Span Text=\"nd responsiblee duti\" />\r\n      <t:Span FontWeight=\"Bold\" Text=\"es in the invesdtment \" />\r\n      <t:Span Text=\"and m\" />\r\n      <t:Span Text=\"anagement of District casdh and \" />\r\n      <t:Span Text=\"revenudes to \" />\r\n      <t:Span FontStyle=\"Italic\" Text=\"meet supderior yield\" />\r\n      <t:Span Text=\" and liq\" />\r\n      <t:Span Strikethrough=\"True\" Text=\"uidity requirements; c\" />\r\n      <t:Span Text=\"onduct\" />\r\n      <t:Span Strikethrough=\"True\" Text=\"s specialized financial anal\" />\r\n      <t:Span Text=\"yseds, au\" />\r\n      <t:Span Text=\"dits and evaludations of \" />\r\n      <t:Span Text=\"indter\" />\r\n      <t:Span ForeColor=\"#FF92D050\" Text=\"nal controls and \" />\r\n      <t:Span Text=\"proce\" />\r\n      <t:Span HighlightColor=\"#FF1E7F99\" Text=\"dures; and perfodrms relate\" />\r\n      <t:Span Text=\"d ddu\" />\r\n      <t:Span FontStyle=\"Italic\" FontWeight=\"Bold\" Text=\"ties as assigned.\" />\r\n    </t:Paragraph>\r\n    <t:Paragraph />\r\n  </t:Section>\r\n</t:RadDocument>",
                        }
                    });
                }

                return employees; 
            }
        }

    }
}
