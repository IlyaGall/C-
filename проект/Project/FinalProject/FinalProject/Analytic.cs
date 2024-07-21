using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace FinalProject
{
    public static class Analytic
    {

       static private void texst() 
        {
            
        }


        /// <summary>
        /// код отвечающий за генерацию ответов, чтобы разгрузить основной класс
        /// </summary>
        /// <returns>сгенерированный текст ответа</returns>
        private static string generationText(string switcher, string info, params double[] statistic)
        {



            string returnStringAnalytic = "";
            switch (switcher)
            {
                case "Индекс мосбиржи":

                    double percent = statistic[2] * 100 / statistic[1] - 100;
                    if (statistic[0] == 0)
                    {
                        returnStringAnalytic = $"Позиция по индексу мосбиржи за {info} дней НЕЙТРАЛЬНАЯ коэ-т {statistic[0]}\n %: {percent}\n";
                    }
                    if (statistic[0] > 0)
                    {
                        returnStringAnalytic = $"Настроение игроков по индексу мосбиржи за {info} дней ПОКУПКА коэ-т {statistic[0]}\n %: ▲{percent}\n";
                    }
                    if (statistic[0] < 0)
                    {
                        returnStringAnalytic = $"Настроение игроков по индексу мосбиржи за {info} дней ПРОДАЖА коэ-т {statistic[0]}\n %: ▼{percent}\n";
                    }
                    break;
            }

          //  GraphicCreator.GraphicCreatorDateTime(path:);

            return returnStringAnalytic;
        }



        /// <summary>
        /// вспомогательная ф-я для расчёта раз
        /// </summary>
        /// <param name="items"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        private static double[] calculationsIndex(Dictionary<DateTime,double> items, int days) 
        {
            Dictionary<DateTime,double> itemsGraphics = new Dictionary<DateTime,double>();
            double statistic = 0;
            double newValueStatistic = 0;
            double oldValueStatistic = 0;
            double startValue = 0;
            double endValue = 0;
            int countItems = items.Count;

        
            for (int i = countItems - days; i < countItems; i++)
            {
                if (oldValueStatistic == 0)
                {
                    startValue = items.ElementAt(i).Value;
                    oldValueStatistic = items.ElementAt(i).Value;
                    itemsGraphics.Add(items.ElementAt(i).Key, items.ElementAt(i).Value);
                }
                else
                {
                    newValueStatistic = items.ElementAt(i).Value;
                    itemsGraphics.Add(items.ElementAt(i).Key, items.ElementAt(i).Value);
                    statistic += newValueStatistic - oldValueStatistic;
                    oldValueStatistic = items.ElementAt(i).Value;
                }

                if (i == countItems - 1)
                {
                    endValue = items.ElementAt(i).Value;
                }
            }
            GraphicCreator.GraphicCreatorDateTime(
                directory: Settings.GlobalParameters.PATH_SAVE,
                nameFile: $"{(countItems - days).ToString()}.png",
                itemsGraphics.Keys.ToArray(),
                itemsGraphics.Values.ToArray());

            double[] returnArr = new double[3];
            returnArr[0] = statistic;
            returnArr[1] = startValue;
            returnArr[2] = endValue;
            return returnArr;

        }

        /// <summary>
        /// аналитика по индексу мосбиржи
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string AnalyticMoscowExchange(Dictionary<DateTime,double> items)
        {
            int countItems = items.Count;
            string returnStringAnalytic = Analytic.generationText("Индекс мосбиржи", $"{countItems.ToString()}", calculationsIndex(items, countItems));
          
            returnStringAnalytic += Analytic.generationText("Индекс мосбиржи", "10", calculationsIndex(items, 11));
            returnStringAnalytic += Analytic.generationText("Индекс мосбиржи", "2", calculationsIndex(items, 2));
            return returnStringAnalytic;
        }
    }
}
