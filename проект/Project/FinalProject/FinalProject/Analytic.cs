using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public static class Analytic
    {
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
            return returnStringAnalytic;
        }

        /// <summary>
        /// аналитика по индексу мосбиржи
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string AnalyticMoscowExchange(List<double> items)
        {
            double statistic = 0;
            double newValueStatistic = 0;
            double oldValueStatistic = 0;
            double startValue = 0;
            double endValue = 0;
            int countItems = items.Count;

            #region за весь период расчёта 
            for (int i = 0; i < countItems; i++)
            {
                if (oldValueStatistic == 0)
                {
                    startValue = items[i];
                    oldValueStatistic = items[i];
                }
                else
                {
                    newValueStatistic = items[i];
                    statistic += newValueStatistic - oldValueStatistic;
                    oldValueStatistic = items[i];
                }

                if (i == countItems - 1)
                {
                    endValue = items[i];
                }
            }
            #endregion
            string returnStringAnalytic = Analytic.generationText("Индекс мосбиржи", "30", statistic, startValue, endValue);

            statistic = 0;
            newValueStatistic = 0;
            oldValueStatistic = 0;
            startValue = 0;
            endValue = 0;
            countItems = items.Count;

            #region за 10 дней
            for (int i = countItems - 11; i < countItems; i++)
            {
                if (oldValueStatistic == 0)
                {
                    startValue = items[i];
                    oldValueStatistic = items[i];
                }
                else
                {
                    newValueStatistic = items[i];
                    statistic += newValueStatistic - oldValueStatistic;
                    oldValueStatistic = items[i];
                }

                if (i == countItems - 1)
                {
                    endValue = items[i];
                }
            }
            #endregion
            returnStringAnalytic += Analytic.generationText("Индекс мосбиржи", "10", statistic, startValue, endValue);

            statistic = 0;
            newValueStatistic = 0;
            oldValueStatistic = 0;
            startValue = 0;
            endValue = 0;
            countItems = items.Count;

            #region за последний день
            for (int i = countItems - 2; i < countItems; i++)
            {
                if (oldValueStatistic == 0)
                {
                    startValue = items[i];
                    oldValueStatistic = items[i];
                }
                else
                {
                    newValueStatistic = items[i];
                    statistic += newValueStatistic - oldValueStatistic;
                    oldValueStatistic = items[i];
                }

                if (i == countItems - 1)
                {
                    endValue = items[i];
                }
            }
            #endregion
            returnStringAnalytic += Analytic.generationText("Индекс мосбиржи", "2", statistic, startValue, endValue);



            return returnStringAnalytic;
        }
    }
}
