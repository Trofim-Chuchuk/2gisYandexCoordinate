using AddressToCoordinates;

namespace Addres2GISTest;

public class GISCordinatesTest{
    [Fact]
    public async Task MoscowTheRedSquare(){
        string address = "Москва Красная площадь";
        
        var gisCoordinates = await Coordinates2GIS.GetCoordinatesFrom2GIS(address);
        
        Assert.Equal("37,62177, 55,753239", gisCoordinates);
    }
    
    [Fact]
    public async Task NSU(){
        string address = "Новосибирский государственный университет";
        
        var gisCoordinates = await Coordinates2GIS.GetCoordinatesFrom2GIS(address);
        
        Assert.Equal("82,905772, 54,986434", gisCoordinates);
    }
}