namespace Telerik.Windows.Examples.Treemap.Selection
{
    public class OilProducingInfo
    {

#if WPF
        const string path = "/Treemap;component/Images/TreeMap/Selection/{0}";
#else
        const string path = "../Images/TreeMap/Selection/{0}";
#endif

        private string _country;
        private double _oil;
        private string _text;
        private string _imageName;
        public string Country
        {
            get
            {
                return this._country;
            }
            set
            {
                this._country = value;
            }
        }
        public double Oil
        {
            get
            {
                return this._oil;
            }
            set
            {
                this._oil = value;
            }
        }
        public string Text
        {
            get
            {
                return this._text;
            }
            set
            {
                this._text = value;
            }
        }
        public string ImageName
        {
            get
            {
                return this._imageName;
            }
            set
            {
                this._imageName = value;
            }
        }
        public string ImagePath
        {
            get
            {
                return string.Format(path, this.ImageName);
            }
        }
    }
}
