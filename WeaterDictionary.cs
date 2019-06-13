using System;
using System.Collections.Generic;

namespace Lesson6_Weather
{
    class WeaterDictionary
    {
        private static string GetDictionary(int index, string[] dict)
        {
            try
            {
                return dict[index];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        // Не определено (если информация не занесена), Ясно, Малооблачно, Облачно, Грозовые тучи
        public enum CloudyList
        {
            Undefined,
            Clear,          // Ясно
            PartlyCloudy,   // Малооблачно
            Cloudy,         // Облачно
            Thunderclouds,   // Грозовые тучи
        }

        public static string GetCloudy(CloudyList cloudyList)
        {
            string[] dict = new string[] { "Не определено", "Ясно", "Малооблачно", "Облачно", "Грозовые тучи" };
            return GetDictionary((int)cloudyList, dict) ?? cloudyList.ToString();
        }

        // Осадки: Не определено(если информация не занесена), Дождь, Снег, Дождь со снегом, Град, Снежная крупа, Роса, Иней, Изморозь, Гололед, Ледяные иглы
        public enum PrecipitationList
        {
            Undefined,
            Rain,           // Дождь
            Snow,           // Снег
            Sleet,          // Дождь со снегом
            Hail,           // Град
            SnowGrout,      // Снежная крупа
            Dew,            // Роса
            Hoarfrost,      // Иней
            Rime,           // Изморозь
            Ice,            // Гололед
            IceNeedles,      // Ледяные иглы
        }

        public static string GetPrecipitation(PrecipitationList precipitationList)
        {
            string[] dict = new string[] { "Не определено", "Дождь", "Снег", "Дождь со снегом", "Град", "Снежная крупа", "Роса", "Иней", "Изморозь", "Гололед", "Ледяные иглы" };
            return GetDictionary((int)precipitationList, dict) ?? precipitationList.ToString();
        }

        // Направление ветра: Не определено(если информация не занесена), Север, Северо-восток, Восток, Юго-восток, Юг, Юго-запад, Запад, Северо-запад.
        public enum WindDirectionList
        {
            Undefined,
            North,
            Northeast,
            East,
            Southeast,
            South,
            Southwest,
            West,
            Northwest,
        }

        public static string GetWindDirection(WindDirectionList windDirectionList)
        {
            string[] dict = new string[] { "Не определено", "С", "СВ", "В", "ЮВ", "Ю", "ЮЗ", "З", "СЗ" };
            return GetDictionary((int)windDirectionList, dict) ?? windDirectionList.ToString();
        }

        // Фаза луны: Не определено(если информация не занесена), Новолуние, Растущая, Полнолуние, Убывающая.
        public enum MoonPhaseList
        {
            Undefined,
            NewMoon,   // Новолуние
            Growing,   // Растущая
            FullMoon,  // Полнолуние
            Falling,    // Убывающая
        }

        public static string GetMoonPhase(MoonPhaseList moonPhaseList)
        {
            string[] dict = new string[] { "Не определено", "Новолуние", "Растущая", "Полнолуние", "Убывающая" };
            return GetDictionary((int)moonPhaseList, dict) ?? moonPhaseList.ToString();
        }

    }
}
