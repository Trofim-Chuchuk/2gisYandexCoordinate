using Newtonsoft.Json.Linq;

namespace AddressToCoordinates;

public class Coordinates2GIS {
  private static readonly string gisApiKey =
      "b6235b06-5ec9-4e0e-94a8-6b9a681db3e3";

  public static async Task<string> GetCoordinatesFrom2GIS(string address) {
    try {
      using (HttpClient client = new HttpClient()) {

        string requestUri =
            $"https://catalog.api.2gis.com/3.0/items/geocode?q={Uri.EscapeDataString(address)}&fields=items.point&key={gisApiKey}";

        HttpResponseMessage response = await client.GetAsync(requestUri);

        if (response.IsSuccessStatusCode) {
          string json = await response.Content.ReadAsStringAsync();
          JObject result = JObject.Parse(json);

          // Парсим JSON и извлекаем координаты
          var point = result["result"]["items"][0]["point"];

          return $"{point["lon"]}, {point["lat"]}";
        }
      }
    } catch (Exception ex) {
       Console.WriteLine($"Ошибка: {ex.Message}");
      Console.WriteLine($"Метод: {ex.TargetSite}");
    }

    return "Не найдено";
  }
}