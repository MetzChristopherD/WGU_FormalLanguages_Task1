namespace WeatherApp
{
    public class DailyTemperature
    {
        public DayOfWeek DayOfTheWeek { get; set; }
        public int High { get; set; }
        public int Low { get; set; }
    }

    public class Weather
    {
        private List<DailyTemperature> WeeklyTemperatures = new();
        private readonly List<int> FahrenheitHighs = new List<int>(7);
        private List<int> FahrenheitLows = new List<int>(7);
        private int WindSpeedInMPH = 0;
        private static int DaysInTheWeek = 7;
        private char WeatherCode = ' ';
        private string Description = string.Empty;

        public Weather(List<DailyTemperature> weeklyTemperatures, int windSpeedInMPH, char weatherCode)
        {
            WeeklyTemperatures = weeklyTemperatures;
            FahrenheitHighs = WeeklyTemperatures.Select(x => x.High).ToList();
            FahrenheitLows = WeeklyTemperatures.Select(x => x.Low).ToList();
            WindSpeedInMPH = windSpeedInMPH;
            WeatherCode = weatherCode;
        }

        public float CalculateAverageFahrenheitHighTemp()
        {
            int highSum = FahrenheitHighs.Sum();
            float averageHigh = highSum / DaysInTheWeek;
            return averageHigh;
        }

        public float CalculateAverageFahrenheitLowTemp()
        {
            int lowSum = FahrenheitLows.Sum();
            float averageLow = lowSum / DaysInTheWeek;
            return averageLow;
        }

        public int FindWeeklyFahrenheitHighTemp()
        {
            return FahrenheitHighs.Max();
        }

        public int FindWeeklyFahrenheitLowTemp()
        {
            return FahrenheitLows.Min();
        }

        public string GetWeatherDescription()
        {
            switch (WeatherCode)
            {
                case 'S':
                    Description = "SUNNY";
                    break;
                case 'P':
                    Description = "PARTLY CLOUDY";
                    break;
                case 'C':
                    Description = "CLOUDY";
                    break;
                case 'N':
                    Description = "CLEAR";
                    break;
            }
            return Description;
        }

        public string GetFormattedDailyForecast(DayOfWeek dayOfWeek)
        {
            DailyTemperature dailyTemperature = WeeklyTemperatures.First(x => x.DayOfTheWeek == dayOfWeek);
            string message = $"{dailyTemperature.DayOfTheWeek.ToString().ToUpper()} FORECAST" + Environment.NewLine;
            message += $"High: {dailyTemperature.High} (F) Low: {dailyTemperature.Low}";
            return message;
        }

        public string GetFormattedWeeklyForecast()
        {
            string message = "THE WEEKLY FORECAST" + Environment.NewLine;
            message += $"Average Hi: {CalculateAverageFahrenheitHighTemp()}" + Environment.NewLine;
            message += $"Average Low: {CalculateAverageFahrenheitLowTemp()}" + Environment.NewLine;
            message += Environment.NewLine;
            message += $"Highest Weekly Temperature: {FindWeeklyFahrenheitHighTemp()} (F)" + Environment.NewLine;
            message += $"Lowest Weekly Temperature: {FindWeeklyFahrenheitLowTemp()} (F)" + Environment.NewLine;
            message += Environment.NewLine;

            foreach (DailyTemperature dailyTemperature in WeeklyTemperatures)
            {
                message += dailyTemperature.DayOfTheWeek + Environment.NewLine;
                message += $"High: {dailyTemperature.High} (F) Low: {dailyTemperature.Low} (F)" + Environment.NewLine;
                message += Environment.NewLine;
            }

            return message;
        }
    }
}
