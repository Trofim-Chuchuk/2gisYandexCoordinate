using MapInfo;
using Newtonsoft.Json.Linq;

namespace Addres2GISYandex;

public class CoordinatesCompany {

  private static readonly HttpClient client = new HttpClient();

  public static async Task<string> GetCoordinates(IGisInfo address) {
    try {
      HttpResponseMessage response =
          await client.GetAsync(address.GetRequestUri());

      if (!response.IsSuccessStatusCode) {
        Console.WriteLine(
            $"Ошибка при запросе к API: {response.StatusCode}");
        return null;
      }
      string json = await response.Content.ReadAsStringAsync();
      JObject result = JObject.Parse(json);
      return address.GetCoordinatesByJson(result);

    } catch (Exception ex) {
      Console.WriteLine($"Ошибка: {ex.Message}");
      Console.WriteLine($"Метод: {ex.TargetSite}");
      return null;
    }
  }
}
