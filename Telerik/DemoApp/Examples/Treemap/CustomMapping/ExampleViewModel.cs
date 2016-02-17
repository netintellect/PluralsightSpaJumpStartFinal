using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Treemap.CustomMapping
{
    public class ExampleViewModel : ViewModelBase
    {
        private IEnumerable<IDiskItem> data;

        public IEnumerable<IDiskItem> Data
        {
            get
            {
                if (this.data == null)
                {
                    this.data = this.LoadData();
                }
                return this.data;
            }
        }

        private IEnumerable<IDiskItem> LoadData()
        {
            Folder c = new Folder("C", Initialize(
                new Folder("My Documents", Initialize(
                    new Folder("Telerik", Initialize(
                        new File("abc.txt", 160),
                        new File("sha-la-la.mp3", 971),
                        new File("IMG_2371.png", 811),
                        new File("work.txt", 120))),
                    new Folder("Silverlight", Initialize(
                        new File("memorandum.doc", 641),
                        new File("important.doc", 327),
                        new File("IMG_2445.png", 922),
                        new File("notes.txt", 188))),
                    new Folder("Projects", Initialize(
                        new File("surprise.avi", 1641),
                        new File("url.txt", 257),
                        new File("important.doc", 227),
                        new File("my doc.doc", 327),
                        new File("IMG_2677.png", 922),
                        new File("links.txt", 188),
                        new File("alarm.mp3", 688))),
                    new File("weekend.doc", 166),
                    new File("IMG_2664.png", 263),
                    new File("IMG_2665.png", 286),
                    new File("melody.flac", 817),
                    new File("sha-la-la.flac", 729))),
                new Folder("My Music", Initialize(
                    new File("Kalimba.mp3", 422),
                    new File("Push.mp3", 254),
                    new File("Bassnectar.mp3", 469),
                    new File("Sleep Away.mp3", 643),
                    new File("Carried Away.mp3", 968))),
                new File("shopping list.doc", 972),
                new File("my guests.doc", 435),
                new File("party list.doc", 428),
                new File("car offer.doc", 741),
                new File("my doc.doc", 350)));

            Folder d = new Folder("D", Initialize(
                new Folder("Videos", Initialize(
                    new File("graduation.avi", 2566),
                    new File("my nephew.avi", 1719),
                    new File("summer trip.avi", 3125),
                    new File("boat.avi", 1899)))));

            return Initialize(c, d);
        }

        private IEnumerable<IDiskItem> Initialize(params IDiskItem[] items)
        {
            return new List<IDiskItem>(items);
        }
    }
}
