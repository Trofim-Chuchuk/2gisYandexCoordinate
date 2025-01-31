using Addres2GISYandex;
using MapInfo;

Console.WriteLine("Введите адрес:");
string? address = Console.ReadLine();

var yandexCoordinates = await CoordinatesCompany.GetCoordinates(
    new YandexInfo("e03bdaff-ee7b-4469-9fa7-00a848da959e", address));
Console.WriteLine($"Координаты от Яндекс: {yandexCoordinates??"не найдено"}");

var gisCoordinates = await CoordinatesCompany.GetCoordinates(
    new TwoGisInfo("b6235b06-5ec9-4e0e-94a8-6b9a681db3e3", address));
Console.WriteLine($"Координаты от 2ГИС: {gisCoordinates??"не найдено"}");
