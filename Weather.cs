using System;
using Lesson6_Weather_Dictionary;

namespace Lesson6_Weather
{
    class Weather
    {
        /*
            дата
            температура минимальная
            температура максимальная
            облачность
            осадки
            влажность
            сила ветра
            направление ветра
            фаза луны

            Облачность, осадки, направление ветра, фаза луны должны быть представлены как битовое перечисление:
         */

        public DateTime Date { get; set; }
        public sbyte TempMin { get; set; }
        public sbyte TempMax { get; set; }
        public WeaterDictionary.CloudyList Cloudy { get; set; }
        public WeaterDictionary.PrecipitationList Precipitation { get; set; }
        public byte Humidity { get; set; }
        public byte WindForce { get; set; }
        public WeaterDictionary.WindDirectionList WindDirection { get; set; }
        public WeaterDictionary.MoonPhaseList MoonPhase { get; set; }

        public Weather(
            DateTime date,
            sbyte tempMin,
            sbyte tempMax,
            WeaterDictionary.CloudyList cloudy,
            WeaterDictionary.PrecipitationList precipitation,
            byte humidity,
            byte windForce,
            WeaterDictionary.WindDirectionList windDirection,
            WeaterDictionary.MoonPhaseList moonPhase)
        {
            Date = date;
            TempMin = tempMin;
            TempMax = tempMax;
            Cloudy = cloudy;
            Precipitation = precipitation;
            Humidity = humidity;
            WindForce = windForce;
            WindDirection = windDirection;
            MoonPhase = moonPhase;
        }
        
        public override string ToString()
        {
            string result = $"{Date.ToShortDateString()}; Tmin = {TempMin}, Tmax = {TempMax}\n" +
                $"Облачность: {WeaterDictionary.GetCloudy(Cloudy)}, Осадки: {WeaterDictionary.GetPrecipitation(Precipitation)}, Влажность: {Humidity}%\n" +
                $"Ветер: {WindForce} м/с ({WeaterDictionary.GetWindDirection(WindDirection)})\n" +
                $"Фаза Луны: {WeaterDictionary.GetMoonPhase(MoonPhase)}";

            return result;
        }
    }
}
