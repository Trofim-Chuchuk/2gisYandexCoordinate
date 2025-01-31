using System.Reflection.Metadata;
using Newtonsoft.Json.Linq;

namespace MapInfo;

public class YandexInfo : IGisInfo {

  private string apiEndpoint;

  public YandexInfo(string apiKey, string address) {
    var addressNotNull = address == null ? " " : address;
    apiEndpoint =
        $"https://geocode-maps.yandex.ru/1.x/?apikey={apiKey}&geocode={Uri.EscapeDataString(addressNotNull)}&format=json";
  }
  public string GetRequestUri() { return apiEndpoint; }
  public string GetCoordinatesByJson(JObject json) {
    var сoordinats = json["response"]["GeoObjectCollection"]["featureMember"][0]
                         ["GeoObject"]["Point"]["pos"];
    return сoordinats.ToString();
  }
}