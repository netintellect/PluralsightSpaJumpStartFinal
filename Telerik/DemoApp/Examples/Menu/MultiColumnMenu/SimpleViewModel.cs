using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace Examples.Menu.MultiColumnMenu
{
    public class SimpleViewModel : ViewModelBase
    {
        private ObservableCollection<MenuItem> products;
        private ObservableCollection<MenuItem> accessories;

        public SimpleViewModel()
        {
            this.products = new ObservableCollection<MenuItem>()
            {
                new MenuItem() { Text="iPhone", ImageUrl="/Menu;component/Images/Menu/Multicolumn/iphone.png" },
                new MenuItem() { Text="Android", ImageUrl="/Menu;component/Images/Menu/Multicolumn/android.png" },
                new MenuItem() { Text="Windows", ImageUrl="/Menu;component/Images/Menu/Multicolumn/windows.png" },
                new MenuItem() { Text="Blackberry", ImageUrl="/Menu;component/Images/Menu/Multicolumn/blackberry.png" },
                new MenuItem() { Text="Camcoder", ImageUrl="/Menu;component/Images/Menu/Multicolumn/phone.png" },
                new MenuItem() { Text="Camcoder-pro", ImageUrl="/Menu;component/Images/Menu/Multicolumn/Calculator.png" },
                new MenuItem() { Text="Webcam", ImageUrl="/Menu;component/Images/Menu/Multicolumn/webcam.png" },
                new MenuItem() { Text="Camcoder", ImageUrl="/Menu;component/Images/Menu/Multicolumn/camcoder.png" },
                new MenuItem() { Text="Camcoder-pro", ImageUrl="/Menu;component/Images/Menu/Multicolumn/camcoder_pro.png" },
                new MenuItem() { Text="Slr_camera", ImageUrl="/Menu;component/Images/Menu/Multicolumn/slr_camera.png" },
                new MenuItem() { Text="Slr_camera", ImageUrl="/Menu;component/Images/Menu/Multicolumn/slr_camera2.png" },
                new MenuItem() { Text="Compact_camera", ImageUrl="/Menu;component/Images/Menu/Multicolumn/compact_camera.png" },
                new MenuItem() { Text="Video_projector", ImageUrl="/Menu;component/Images/Menu/Multicolumn/video_projector.png" },
                new MenuItem() { Text="Monitor", ImageUrl="/Menu;component/Images/Menu/Multicolumn/monitor.png" },
                new MenuItem() { Text="Keyboard", ImageUrl="/Menu;component/Images/Menu/Multicolumn/keyboard.png" },
                new MenuItem() { Text="Mouse", ImageUrl="/Menu;component/Images/Menu/Multicolumn/mouse.png" },
                new MenuItem() { Text="Scanner", ImageUrl="/Menu;component/Images/Menu/Multicolumn/scanner.png" },
                new MenuItem() { Text="Hard disk", ImageUrl="/Menu;component/Images/Menu/Multicolumn/hdd.png" },
            };

            this.accessories = this.products;
        }

        /// <summary>
        /// Gets or sets Accessories and notifies for changes
        /// </summary>
        public ObservableCollection<MenuItem> Accessories
        {
            get
            {
                return this.accessories;
            }

            set
            {
                if (this.accessories != value)
                {
                    this.accessories = value;
                    this.OnPropertyChanged(() => this.Accessories);
                }
            }
        }

        /// <summary>
        /// Gets or sets Items and notifies for changes
        /// </summary>
        public ObservableCollection<MenuItem> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                if (this.products != value)
                {
                    this.products = value;
                    this.OnPropertyChanged(() => this.Products);
                }
            }
        }
    }
}
