
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.Chart.Selection
{
    public class Country
    {
        public const string ExtendedPropertyCountryName = "CNTRY_NAME";
        public const string ExtendedPropertyCountryPopulationName = "SUM_POP_AD";

        public string Name;
        public double Population;

        public static Country ExtractFromMapShapeExtendedData(MapShape mapShape)
        {
            string countryName = ExtractNameFromMapShapeExtendedData(mapShape);
            double countryPopulation = (double)mapShape.ExtendedData.GetValue(ExtendedPropertyCountryPopulationName);
            Country country = new Country();
            country.Name = countryName;
            country.Population = countryPopulation;
            return country;
        }

        public static string ExtractNameFromMapShapeExtendedData(MapShape mapShape)
        {
            return mapShape.ExtendedData.GetValue(ExtendedPropertyCountryName) as string;
        }

        public static double ExtractPopulationFromMapShapeExtendedData(MapShape mapShape)
        {
            return (double)mapShape.ExtendedData.GetValue(ExtendedPropertyCountryPopulationName);
        }
    }
}
