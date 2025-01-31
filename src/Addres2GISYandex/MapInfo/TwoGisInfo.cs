using System.Reflection.Metadata;
using Newtonsoft.Json.Linq;

namespace MapInfo;

public class TwoGisInfo : IGisInfo {

  private string apiEndpoint;

  public TwoGisInfo(string apiKey, string address) {
    var addressNotNull = address == null ? " " : address;
    apiEndpoint =
        $"https://catalog.api.2gis.com/3.0/items/geocode?q={Uri.EscapeDataString(addressNotNull)}&fields=items.point&key={apiKey}";
  }

  public string GetRequestUri() { return apiEndpoint; }

  public string GetCoordinatesByJson(JObject json) {
    var point = json["result"]["items"][0]["point"];

    return $"{point["lon"]}, {point["lat"]}";
  }
}