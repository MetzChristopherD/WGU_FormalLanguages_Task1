// See https://aka.ms/new-console-template for more information
using WeatherApp;

List<DailyTemperature> WeeklyTemperatures =
[
    new DailyTemperature() { DayOfTheWeek = DayOfWeek.Sunday, High = 78, Low = 75 },
    new DailyTemperature() { DayOfTheWeek = DayOfWeek.Monday, High = 76, Low = 70 },
    new DailyTemperature() { DayOfTheWeek = DayOfWeek.Tuesday, High = 80, Low = 75 },
    new DailyTemperature() { DayOfTheWeek = DayOfWeek.Wednesday, High = 82, Low = 76 },
    new DailyTemperature() { DayOfTheWeek = DayOfWeek.Thursday, High = 85, Low = 75 },
    new DailyTemperature() { DayOfTheWeek = DayOfWeek.Friday, High = 79, Low = 70 },
    new DailyTemperature() { DayOfTheWeek = DayOfWeek.Saturday, High = 75, Low = 69 },
];

Weather weather = new Weather(WeeklyTemperatures, 9, 'P');

Console.WriteLine(weather.GetWeatherDescription());
Console.WriteLine(weather.GetFormattedDailyForecast(DayOfWeek.Sunday));
Console.WriteLine(weather.GetFormattedWeeklyForecast());

