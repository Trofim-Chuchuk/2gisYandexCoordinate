using AddressToCoordinates;

Console.WriteLine("Введите адрес:");
string address = Console.ReadLine();

// Получаем координаты с помощью Яндекс.Карт
var yandexCoordinates = await CoordinatesYandex.GetCoordinatesYandex(address);
Console.WriteLine($"Координаты от Яндекс: {yandexCoordinates}");


// var gisCoordinates = await Coordinates2GIS.GetCoordinatesFrom2GIS(address);
// Console.WriteLine($"Координаты от 2ГИС: {gisCoordinates ?? "Не найдено"}");