using System;

namespace Lesson6_Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Weather weather1 = new Weather(DateTime.Parse("13.06.2019"), 22, 31, WeaterDictionary.CloudyList.Clear, 
                WeaterDictionary.PrecipitationList.Undefined, 60, 5, WeaterDictionary.WindDirectionList.Southeast, WeaterDictionary.MoonPhaseList.FullMoon);

            Console.WriteLine(weather1);
            Console.WriteLine();
            */

            WeatherList weatherList = new WeatherList();
            weatherList.setRandomData();

            Console.WriteLine(weatherList);

            Console.WriteLine("Среднегодовая температура: " + weatherList.AvgYearTemp());
            Console.WriteLine("Среднее количество солнечных дней в месяц: " + weatherList.AvgClearMonth());
            Console.WriteLine("Общее количество дней в году с осадками: " + weatherList.SumPrecipitationYear());
            Console.WriteLine("Общее количество дней в году со слабым ветром (менее 5 м/с): " + weatherList.SumLowWindForceYear());
            Console.WriteLine("Общее количество дней с температурой выше среднегодовой температуры: " + weatherList.SumGreaterThenAvg());
            Console.WriteLine("Общее количество дней с температурой ниже среднегодовой температуры: " + weatherList.SumLessThenAvg());
            Console.WriteLine("Месяц с самым большим количеством осадков: " + weatherList.PrecipitationMonthNum());
            Console.WriteLine("Самый безветренный месяц (в котором кол-во дней со слабым ветром минимально): " + weatherList.LowWindForceMonthNum());
        }
    }
}
