using AddressToCoordinates;
using MapInfo;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Addres2GISTest;

public class YandexCordinatesTest {

  [Fact]
  public async Task MoscowTheRedSquare() {
    string address = "Москва Красная площадь";

    var yandexCoordinates = await CoordinatesCompany.GetCoordinates(
        new YandexInfo("e03bdaff-ee7b-4469-9fa7-00a848da959e", address));

    Assert.Equal("37.621202 55.753544", yandexCoordinates);
  }

  [Fact]
  public async Task NSU() {
    string address = "Новосибирский государственный университет";

    var yandexCoordinates = await CoordinatesCompany.GetCoordinates(
        new YandexInfo("e03bdaff-ee7b-4469-9fa7-00a848da959e", address));

    Assert.Equal("82.665694 54.826022", yandexCoordinates);
  }

  [Fact]
  public async Task BadRequest() {
    string address = "ромдосрмлшогапжщшрощорэщгпашжгпашжангжшпг";

    var yandexCoordinates = await CoordinatesCompany.GetCoordinates(
        new YandexInfo("e03bdaff-ee7b-4469-9fa7-00a848da959e", address));

    Assert.Equal(null, yandexCoordinates);
  }

  [Fact]
  public async Task ZeroRequest() {
    string address = "";

    var yandexCoordinates = await CoordinatesCompany.GetCoordinates(
        new YandexInfo("e03bdaff-ee7b-4469-9fa7-00a848da959e", address));

    Assert.Equal(null, yandexCoordinates);
  }
}