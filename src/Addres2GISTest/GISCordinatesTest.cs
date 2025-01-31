using AddressToCoordinates;
using MapInfo;

namespace Addres2GISTest;

public class GISCordinatesTest {
    
  [Fact]
  public async Task MoscowTheRedSquare() {
    string address = "Москва Красная площадь";

    var gisCoordinates = await CoordinatesCompany.GetCoordinates(
    new TwoGisInfo("b6235b06-5ec9-4e0e-94a8-6b9a681db3e3", address));

    Assert.Equal("37,62177, 55,753239", gisCoordinates);
  }

  [Fact]
  public async Task NSU() {
    string address = "Новосибирский государственный университет";

    var gisCoordinates = await CoordinatesCompany.GetCoordinates(
    new TwoGisInfo("b6235b06-5ec9-4e0e-94a8-6b9a681db3e3", address));

    Assert.Equal("82,905772, 54,986434", gisCoordinates);
  }
  [Fact]
  public async Task BadRequest() {
    string address = "ромдосрмлшогапжщшрощорэщгпашжгпашжангжшпг";

    var gisCoordinates = await CoordinatesCompany.GetCoordinates(
    new TwoGisInfo("b6235b06-5ec9-4e0e-94a8-6b9a681db3e3", address));

    Assert.Equal(null, gisCoordinates);
  }

  [Fact]
  public async Task ZeroRequest() {
    string address = "";

    var yandexCoordinates =
        await CoordinatesCompany.GetCoordinates(
    new TwoGisInfo("b6235b06-5ec9-4e0e-94a8-6b9a681db3e3", address));

    Assert.Equal(null, yandexCoordinates);
  }

  [Fact]
  public async Task NullRequest() {
    string address = null;

    var yandexCoordinates =
        await CoordinatesCompany.GetCoordinates(
    new TwoGisInfo("b6235b06-5ec9-4e0e-94a8-6b9a681db3e3", address));
    
    Assert.Equal(null, yandexCoordinates);
  }
}