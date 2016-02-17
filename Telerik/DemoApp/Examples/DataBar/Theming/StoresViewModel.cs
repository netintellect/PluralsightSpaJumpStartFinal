using System.Collections.Generic;
using System.Linq;
using System;

namespace Telerik.Windows.Examples.DataBar.Theming
{
    public class StoresViewModel
    {
        public StoresViewModel() 
        {
            this.StoreInfos = new List<StoreInfo>() 
            {
                new StoreInfo("Mr. Dorrell", "North Area", 957, 865, 1072, 1077),
                new StoreInfo("Hi five", "North Area", 900, 665, 872, 1050),           
                new StoreInfo("ShopAtOnes", "South-West Area", 800, 780, 805, 790),   
                new StoreInfo("LollyHolly", "South-East Area", 746, 650, 640, 590),                   
                new StoreInfo("The Favourites", "South-East Area", 446, 650, 740, 710),
                new StoreInfo("Marrie and Jack", "South-East Area", 600, 650, 530, 510),       
                new StoreInfo("Mrs. Smith", "South-West Area", 570, 590, 510, 520),   
                new StoreInfo("Quality food", "South-East Area", 546, 550, 530, 540),  
                new StoreInfo("Ellinor", "East Area", 555, 480, 540, 540),         
                new StoreInfo("Your store", "South-West Area", 570, 590, 410, 420),   
                new StoreInfo("Perfecto", "East Area", 488.4, 422.4, 475.2, 475),  
                new StoreInfo("Family Store", "North Area", 516, 321, 456, 526),   
                new StoreInfo("Dominos", "East Area", 500, 480, 400, 440),           
                new StoreInfo("NearBy", "East Area", 444, 384, 432, 432),         
                new StoreInfo("Greenings", "North Area", 405, 390, 420, 420), 
                new StoreInfo("The Hit", "South-West Area", 370, 390, 410, 420),          
                new StoreInfo("Variety", "South-West Area", 370, 390, 410, 420),      
                new StoreInfo("Fresh & Green", "East Area", 350, 370, 380, 390),
                new StoreInfo("Ted's", "North Area", 300, 300, 300, 300),                     
                new StoreInfo("GoShopping!", "South-West Area", 270, 320, 305, 280),   
            };
        }

        public IEnumerable<StoreInfo> StoreInfos { get; private set; }

        public double MaxRevenue 
        { 
            get 
            { 
                double maxRevenue = this.StoreInfos.Max(info => info.TotalRevenue);
                return maxRevenue;
            } 
        }

        public double MaxAxisValue
        {
            get
            {
                double maxAxisValue = Math.Ceiling(this.MaxRevenue / 100) * 100;
                return maxAxisValue;
            }
        }
    }
}
