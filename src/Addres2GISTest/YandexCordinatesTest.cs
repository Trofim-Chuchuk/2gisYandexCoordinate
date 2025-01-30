using AddressToCoordinates;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Addres2GISTest;

public class YandexCordinatesTest {
    
    [Fact]
    public async Task MoscowTheRedSquare(){
        string address = "Москва Красная площадь";
        
        var yandexCoordinates = await CoordinatesYandex.GetCoordinatesYandex(address);
        
        Assert.Equal("37.621202 55.753544", yandexCoordinates);
    }
    
    [Fact]
    public async Task NSU(){
        string address = "Новосибирского государственного университета ";
        
        var yandexCoordinates = await CoordinatesYandex.GetCoordinatesYandex(address);
        
        Assert.Equal("72.512558 37.102891", yandexCoordinates);
    }
    
}