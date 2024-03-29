﻿using System;

namespace Lesson6_Weather
{
    class WeatherList
    {
        Weather[][] list;
        
        public WeatherList()
        {
            list = new Weather[12][];
        }

        public void setRandomData()
        {
            int year = DateTime.Now.Year;
            Random rnd = new Random();

            for (int i = 0; i < 12; i++)
            {
                int dayInMonth = DateTime.DaysInMonth(year, i + 1);
                list[i] = new Weather[dayInMonth];

                for (int j = 0; j < dayInMonth; j++)
                {
                    list[i][j] = getRandomWeather(rnd, year, i, j);
                }
            }
        }

        private T getRandomDic<T>(Random rnd)
        {
            string[] values = Enum.GetNames(typeof(T));
            int ind = rnd.Next(0, values.Length - 1);
            return (T)Enum.Parse(typeof(T), values[ind]);
        }

        private Weather getRandomWeather(Random rnd, int year, int month, int day)
        {
            DateTime dt = new DateTime(year, month + 1, day + 1);
            sbyte tMin = (sbyte)rnd.Next(-30, 30);
            sbyte tMax = (sbyte)rnd.Next(0, 50);

            if (tMax < tMin)
            {
                sbyte temp = tMax;
                tMax = tMin;
                tMin = temp;
            }

            byte humidity = (byte)rnd.Next(0, 100);
            byte windForce = (byte)rnd.Next(0, 25);

            WeaterDictionary.CloudyList cloudy = getRandomDic<WeaterDictionary.CloudyList>(rnd);
            WeaterDictionary.PrecipitationList precipitation = getRandomDic<WeaterDictionary.PrecipitationList>(rnd);
            WeaterDictionary.WindDirectionList windDirection = getRandomDic<WeaterDictionary.WindDirectionList>(rnd);
            WeaterDictionary.MoonPhaseList moonPhase = getRandomDic<WeaterDictionary.MoonPhaseList>(rnd);

            return new Weather(dt, tMin, tMax, cloudy,
                precipitation, humidity, windForce, windDirection, moonPhase);

        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < list.Length; i++)
                for (int j = 0; j < list[i].Length; j++)
                    result += list[i][j] + "\n\n";

            return result;
        }

        private int getAvgTempOfDay(Weather w) {
            return (w.TempMin + w.TempMax) / 2;
        }

        // среднегодовую температуру
        public int AvgYearTemp()
        {
            int days = 0;
            int sumYear = 0;

            for (int i = 0; i < list.Length; i++)
                for (int j = 0; j < list[i].Length; j++)
                {
                    sumYear += getAvgTempOfDay(list[i][j]);
                    days++;
                }
            return sumYear / days;
        }

        //среднее количество солнечных дней в месяц
        public int AvgClearMonth()
        {
            int[] clearSkyInMonth = new int[12];

            for (int i = 0; i < list.Length; i++)
            {
                clearSkyInMonth[i] = 0;
                for (int j = 0; j < list[i].Length; j++)
                {
                    if (list[i][j].Precipitation == WeaterDictionary.PrecipitationList.Undefined
                        && (list[i][j].Cloudy == WeaterDictionary.CloudyList.Clear 
                            || list[i][j].Cloudy == WeaterDictionary.CloudyList.PartlyCloudy))
                        clearSkyInMonth[i]++;
                }
            }

            int sum = 0;
            foreach (int item in clearSkyInMonth)
                sum += item;

            return (sum / 12);
        }

        private bool IsPrecipitation (Weather w)
        {
            return (w.Precipitation == WeaterDictionary.PrecipitationList.Rain
                || w.Precipitation == WeaterDictionary.PrecipitationList.Snow
                || w.Precipitation == WeaterDictionary.PrecipitationList.Sleet
                || w.Precipitation == WeaterDictionary.PrecipitationList.Hail
                || w.Precipitation == WeaterDictionary.PrecipitationList.SnowGrout);
        }

        private bool IsSlowWindForce (Weather w)
        {
            return (w.WindForce < 5);
        }

        //общее количество дней в году с осадками
        public int SumPrecipitationYear()
        {
            int sum = 0;
            for (int i = 0; i < list.Length; i++)
                for (int j = 0; j < list[i].Length; j++)
                    if (IsPrecipitation(list[i][j])) 
                        sum++;
            return sum;
        }

        //общее количество дней в году со слабым ветром (менее 5 м/с)
        public int SumLowWindForceYear()
        {
            int sum = 0;
            for (int i = 0; i < list.Length; i++)
                for (int j = 0; j < list[i].Length; j++)
                    if (IsSlowWindForce(list[i][j]))
                        sum++;
            return sum;
        }

        //общее количество дней с температурой выше среднегодовой температуры
        public int SumGreaterThenAvg()
        {
            int avgYearTemp = AvgYearTemp();
            int sum = 0;

            for (int i = 0; i < list.Length; i++)
                for (int j = 0; j < list[i].Length; j++)
                    if (getAvgTempOfDay(list[i][j]) > avgYearTemp)
                        sum++;
            return sum;
        }

        //общее количество дней с температурой ниже  среднегодовой температуры
        public int SumLessThenAvg()
        {
            int avgYearTemp = AvgYearTemp();
            int sum = 0;

            for (int i = 0; i < list.Length; i++)
                for (int j = 0; j < list[i].Length; j++)
                    if (getAvgTempOfDay(list[i][j]) < avgYearTemp)
                        sum++;
            return sum;
        }

        //месяц с самым большим количеством осадков
        public int PrecipitationMonthNum()
        {
            int[] precipitationInMonth = new int[12];

            for (int i = 0; i < list.Length; i++)
            {
                precipitationInMonth[i] = 0;
                for (int j = 0; j < list[i].Length; j++)
                {
                    if (IsPrecipitation(list[i][j]))
                        precipitationInMonth[i]++;
                }
            }

            int max = 0;
            int maxMonth = 0;
            for (int i = 0; i < precipitationInMonth.Length; i++)
            {
                if (max < precipitationInMonth[i])
                {
                    max = precipitationInMonth[i];
                    maxMonth = i;
                }
            }

            return maxMonth+1;
        }

        //самый безветренный месяц (в котором кол-во дней со слабым ветром минимально)
        public int LowWindForceMonthNum()
        {
            int[] lowWindForceInMonth = new int[12];

            for (int i = 0; i < list.Length; i++)
            {
                lowWindForceInMonth[i] = 0;
                for (int j = 0; j < list[i].Length; j++)
                    if (IsSlowWindForce(list[i][j]))
                        lowWindForceInMonth[i]++;
            }

            int min = 0;
            int minMonth = 1;
            for (int i = 0; i < lowWindForceInMonth.Length; i++)
            {
                if (min > lowWindForceInMonth[i])
                {
                    min = lowWindForceInMonth[i];
                    minMonth = i;
                }
            }

            return minMonth+1;
        }
    }
}
