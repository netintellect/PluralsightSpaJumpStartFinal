using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls.ColorEditor;

namespace Telerik.Windows.Examples.PropertyGrid.EditorAttribute
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
            this.DataContext = new Employee()
                                    {
                                        Name = "Mark Smith",
                                        Position = "Supplies Manager",
                                        ContactInformation = new ContactInformation { Email = "smith@greentech.com", PhoneNumber = "0071112222" },
                                        CurrentColor = Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF8EC441"),                                  
                                        Location="Boston, MA 02108",
                                    };

        }
    }
}
