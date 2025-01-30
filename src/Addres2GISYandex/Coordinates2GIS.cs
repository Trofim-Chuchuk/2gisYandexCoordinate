using Newtonsoft.Json.Linq;

namespace AddressToCoordinates;

public class Coordinates2GIS {
    private static readonly string gisApiKey = "Net";

    public static async Task<string> GetCoordinatesFrom2GIS(string address){

        using (HttpClient client = new HttpClient()) {
            string requestUri =
                $"https://catalog.api.2gis.com/3.0/items/geocode?q={Uri.EscapeDataString(address)}&fields=items.point&key={gisApiKey}";

            return null;
        }

        return null;
    }
}