using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_StarwarsAPI.Utils
{
    public static class Utils
    {
        public static (PlanetData?, PlanetData?) FindMinMax(List<PlanetData> AllPlanetsData, string selectedProperty)
        {
            // Use reflection to access the property by name
            var propertyInfo = typeof(PlanetData).GetProperty(selectedProperty);

            if (propertyInfo == null)
            {
                throw new ArgumentException("Invalid property name", nameof(selectedProperty));
            }

            var _ordered_AllPlanetsData = AllPlanetsData
                .Where(item => !string.Equals(propertyInfo.GetValue(item)?.ToString(), "unknown", StringComparison.OrdinalIgnoreCase))
                .Where(item => !string.Equals(propertyInfo.GetValue(item)?.ToString(), "N/A", StringComparison.OrdinalIgnoreCase))
                .OrderBy(item => propertyInfo.GetValue(item));

            PlanetData? minInstance = _ordered_AllPlanetsData.FirstOrDefault();
            PlanetData? maxInstance = _ordered_AllPlanetsData.LastOrDefault();

            return (minInstance, maxInstance);
        }
    }
}
