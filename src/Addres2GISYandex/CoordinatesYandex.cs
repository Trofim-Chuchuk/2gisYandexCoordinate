using Newtonsoft.Json.Linq;

namespace AddressToCoordinates;

public class CoordinatesYandex {
  private static readonly string yandexApiKey =
      "e03bdaff-ee7b-4469-9fa7-00a848da959e";

  /// <summary>
  /// Получение кординат из api яндекса.
  /// </summary>
  /// <param name="address">Желаемое место.</param>
  /// <returns><Координаты введенного места/returns>
  public static async Task<string> GetCoordinatesYandex(string address) {
    try {
      using (HttpClient client = new HttpClient()) {
        string requestUri =
            $"https://geocode-maps.yandex.ru/1.x/?apikey={yandexApiKey}&geocode={Uri.EscapeDataString(address)}&format=json";

        HttpResponseMessage response = await client.GetAsync(requestUri);

        if (response.IsSuccessStatusCode) {

          string json = await response.Content.ReadAsStringAsync();
          JObject result = JObject.Parse(json);

          var pos = result["response"]["GeoObjectCollection"]["featureMember"]
                          [0]["GeoObject"]["Point"]["pos"];
          return pos.ToString();
        } else {
          Console.WriteLine(
              $"Ошибка при запросе к API Яндекса: {response.StatusCode}");
        }
      }
    } catch (Exception ex) {
      Console.WriteLine($"Ошибка: {ex.Message}");
      Console.WriteLine($"Метод: {ex.TargetSite}");
    }
    return "Не получилось";
  }
}