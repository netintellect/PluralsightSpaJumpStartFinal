using System;

namespace Telerik.Windows.Examples.Treemap.FirstLook
{
    public class MovieInfo
    {
#if WPF
        const string path = "/Treemap;component/Images/Pivotmap/FirstLook/{0}";
#else
        const string path = "../Images/Pivotmap/FirstLook/{0}";
#endif

        private int rank;
        private string name;
        private DateTime releaseDate;
        private string distributor;
        private string genre;
        private long ticketsSold;
        private long grossSales;
        private string imageName;

        public int Rank
        {
            get
            {
                return this.rank;
            }
            set
            {
                this.rank = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public DateTime ReleaseDate
        {
            get
            {
                return this.releaseDate;
            }
            set
            {
                this.releaseDate = value;
            }
        }
        public string Distributor
        {
            get
            {
                return this.distributor;
            }
            set
            {
                this.distributor = value;
            }
        }
        public string Genre
        {
            get
            {
                return this.genre;
            }
            set
            {
                this.genre = value;
            }
        }
        public long TicketsSold
        {
            get
            {
                return this.ticketsSold;
            }
            set
            {
                this.ticketsSold = value;
            }
        }
        public long GrossSales
        {
            get
            {
                return this.grossSales;
            }
            set
            {
                this.grossSales = value;
            }
        }
        public string ImageName
        {
            get
            {
                return this.imageName;
            }
            set
            {
                this.imageName = value;
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
