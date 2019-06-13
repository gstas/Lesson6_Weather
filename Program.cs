using System;

namespace Lesson6_Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            Weather weather1 = new Weather(DateTime.Parse("13.06.2019"), 22, 31, WeaterDictionary.CloudyList.Clear, 
                WeaterDictionary.PrecipitationList.Undefined, 60, 5, WeaterDictionary.WindDirectionList.Southeast, WeaterDictionary.MoonPhaseList.FullMoon);

            Console.WriteLine(weather1);          

        }
    }
}
