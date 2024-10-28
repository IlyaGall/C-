using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using ScottPlot.Finance;
using ScottPlot.TickGenerators.TimeUnits;
using static FinalProject.ParserXML;
using System.Drawing.Drawing2D;
using ScottPlot.Colormaps;
using ScottPlot;

namespace FinalProject
{
    /// <summary>
    /// линия поддержки
    /// </summary>
    public class LinePoint
    {
        /// <summary>
        /// координата Y
        /// </summary>
        public double CoordinateY { get; set; }
        /// <summary>
        /// координата x(double)
        /// </summary>
        public double CoordinateX { get; set; }
        /// <summary>
        /// координата x(время)
        /// </summary>
        public DateTime CoordinateXTime { get; set; }

        /// <summary>
        /// id точки поддержки из общего массива точек
        /// </summary>
        public int IdPoint { get; set; }

        /// <summary>
        /// тип линии поддержка: 1 , сопротивления: 0 
        /// </summary>
        public int TypeLine { get; set; }

        public LinePoint(double coordinateY, DateTime coordinateXTime, int idPoint, int typeLine)
        {
            CoordinateY = coordinateY;
            CoordinateXTime = coordinateXTime;
            IdPoint = idPoint;
            TypeLine = typeLine;
        }
        public LinePoint(double coordinateY, double coordinateX, int idPoint, int typeLine)
        {
            CoordinateY = coordinateY;
            CoordinateX = coordinateX;
            IdPoint = idPoint;
            TypeLine = typeLine;

        }

    }
    

    public class MethodLineSupport
    {
        /// <summary>
        /// получить массив линий поддержки
        /// </summary>
        /// <returns>коллекцию линий поддержки</returns>
        public static List<LinePoint> lineSupport(string uri)
        {

            //List<Candle> candles = ParserXML.passingXMLStock(@"http://iss.moex.com/iss/engines/stock/markets/shares/securities/SBER/candles.xml?iss.meta=off&from=2021-02-01&till=2021-02-01&interval=10");
            List<Candle> candles = ParserXML.passingXMLStock(uri);
            List<LinePoint> linePoints = new();
            double arraySum = 0;
            for (var i = 0; i < candles.Count; i++)
            {
                var middle = candles[i].High - candles[i].Low;
                arraySum += middle;
            }
            var s = arraySum / candles.Count;


            List<double> levels = new List<double>();

            for (int i = 2; i < candles.Count - 2; i++)
            {
                if (IsSupport(candles, i))
                {
                    double l = candles[i].Low;
                    if (IsFarFromLevel(levels.ToArray(), l, s))
                    {
                        levels.Add(l);
                        linePoints.Add(new LinePoint(
                            coordinateY: l,
                            coordinateXTime: candles[i].End,
                            idPoint: i - 1,
                            typeLine: 1)
                        );
                    }
                }
                else if (IsResistance(candles, i))
                {
                    double l = candles[i].High;

                    if (IsFarFromLevel(levels.ToArray(), l, s))
                    {
                        levels.Add(l);
                        linePoints.Add(new LinePoint(
                           coordinateY: l,
                           coordinateXTime: candles[i].End,
                           idPoint: i - 1,
                           typeLine: 2)
                       );
                    }
                }
            }
            return linePoints;

        }

        /// <summary>
        /// линия поддержки
        /// </summary>
        /// <param name="myCandlesArray">массив свечек</param>
        /// <param name="i">позиция элемента в коллекции, который нужно проверить</param>
        /// <returns>true-это линия поддержки, false- это не линия поддержки</returns>
        static bool IsSupport(List<Candle> myCandlesArray, int i)
        {
            var result = myCandlesArray[i].Low < myCandlesArray[i - 1].Low
                         && myCandlesArray[i].Low < myCandlesArray[i + 1].Low
                         && myCandlesArray[i + 1].Low < myCandlesArray[i + 2].Low
                         && myCandlesArray[i - 1].Low < myCandlesArray[i - 2].Low;

            return result;
        }
        /// <summary>
        /// линия сопротивления
        /// </summary>
        /// <param name="myCandlesArray">массив свечек</param>
        /// <param name="i">позиция элемента в коллекции, который нужно проверить</param>
        /// <returns>true-это линия сопротивления, false- это не линия сопротивления</returns>
        static bool IsResistance(List<Candle> myCandlesArray, int i)
        {
            var result = myCandlesArray[i].High > myCandlesArray[i - 1].High
                         && myCandlesArray[i].High > myCandlesArray[i + 1].High
                         && myCandlesArray[i + 1].High > myCandlesArray[i + 2].High
                         && myCandlesArray[i - 1].High > myCandlesArray[i - 2].High;

            return result;
        }

        /// <summary>
        /// убрать шумы по свечке
        /// </summary>
        /// <param name="levels">количество линий поддержки</param>
        /// <param name="l">проверяемая линия поддержки</param>
        /// <param name="s">средняя свеча</param>
        /// <returns>true линию можно добавить, false линию нельзя добавлять</returns>
        static bool IsFarFromLevel(double[] levels, double l, double s)
        {
            foreach (var lev in levels)
            {
                if (Math.Abs(l - lev) <= s)
                {
                    return false;
                }
            }
            return true;
        }


    }


    public static class Analytic
    {
        /// <summary>
        /// расчёт скользящей средней
        /// </summary>
        /// <param name="kvs">массив значений(цена акции за день)</param>
        /// <param name="period">период</param>
        /// <returns></returns>
        private static double[] EMA(double[] kvs, int period)
        {
            //https://programmersought.com/article/360411371762/

            double[] res = new double[kvs.Length];
            double up = kvs[0];
            res[0] = up; // первый день
            double w1 = (period - 1D) / (period + 1);
            double w2 = 2D / (period + 1);
            for (int i = 1; i < kvs.Length; i++)
            {
                up = (up * w1) + (kvs[i] * w2);
                res[i] = up;
            }
            return res;
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

                    double percent = statistic[1] * 100 / statistic[0] - 100;
                    if (percent == 0)
                    {
                        returnStringAnalytic = $"Позиция по индексу мосбиржи за {info} дней НЕЙТРАЛЬНАЯ коэ-т {statistic[0]}\n %: {percent}\n";
                    }
                    if (percent > 0)
                    {
                        returnStringAnalytic = $"Настроение игроков по индексу мосбиржи за {info} дней ПОКУПКА коэ-т {statistic[0]}\n %: ▲{percent}\n";
                    }
                    if (percent < 0)
                    {
                        returnStringAnalytic = $"Настроение игроков по индексу мосбиржи за {info} дней ПРОДАЖА коэ-т {statistic[0]}\n %: ▼{percent}\n";
                    }
                    break;

                case "Свечи":
                    percent = statistic[1] * 100 / statistic[0] - 100;
                    if (percent == 0)
                    {
                        returnStringAnalytic = $"Позиция по за {info} дней НЕЙТРАЛЬНАЯ коэ-т {statistic[0]}\n %: {percent}\n";
                    }
                    if (percent > 0)
                    {
                        returnStringAnalytic = $"Позиция по акции за {info} дней ПОКУПКА коэ-т {statistic[0]}\n %: ▲{percent}\n";
                    }
                    if (percent < 0)
                    {
                        returnStringAnalytic = $"Позиция по акции за {info} дней ПРОДАЖА коэ-т {statistic[0]}\n %: ▼{percent}\n";
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
        private static double[] calculationsIndex(Dictionary<DateTime, double> items, int days)
        {
            Dictionary<DateTime, double> itemsGraphics = new Dictionary<DateTime, double>();
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
                //directory: Settings.GlobalParameters.PathSave,
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
        public static string AnalyticMoscowExchange(Dictionary<DateTime, double> items)
        {
            int countItems = items.Count;
            string returnStringAnalytic = Analytic.generationText(
                "Индекс мосбиржи",
                $"{countItems.ToString()}",
                calculationsIndex(items, countItems));
            returnStringAnalytic += Analytic.generationText("Индекс мосбиржи", "10", calculationsIndex(items, 11));
            returnStringAnalytic += Analytic.generationText("Индекс мосбиржи", "2", calculationsIndex(items, 2));
            return returnStringAnalytic;
        }


        /// <summary>
        /// аналитика по одному активу
        /// </summary>
        /// <param name="url">url адрес запроса</param>
        /// <param name="nameStock">название актива</param>
        /// <param name="typeActive">тип актива(по умолчанию stocks)</param>
        /// <param name="text">описание периода</param>
        /// <param name="history">Нужно ли подтягивать историю, если она более 100 дней</param>
        /// <returns></returns>
        public static (string, List<string>, List<string>) AnalyticMoscowExchangeActive(string url, string nameStock = "sber", string typeActive = "stocks", string text = "")
        {
            /*
             логика следующая
             1 это какое-то описание, так как графиков может быть несколько
             2 это путь к файлам
             3 это описание файлов
             */

            List<string> items = new List<string>();
            Dictionary<DateTime, double> collectionInformationForCreateImages = new Dictionary<DateTime, double>();

            switch (typeActive)
            {
                case "stocks":
                    var s = ParserXML.passingXMLStock(url);
                 
                    items = new List<string>()
                    {
                        GraphicCreator.GraphicCreateStock(
                           candles:s,
                           nameFile:nameStock+".png"
                        )
                    };
                    collectionInformationForCreateImages = ParserXML.parsingXmlHistory(RequestCommand.QueryStockYear(nameStock));
                    double[] array1 = collectionInformationForCreateImages.Values.ToArray();
                   
                    
                    items.Add(
                         GraphicCreator.GraphicCreatorDateTime(
                         nameFile: $"Индекс за 364 дня.png",
                         collectionInformationForCreateImages.Keys.ToArray(),
                         array1)
                    );

                    items.Add(
                        GraphicCreator.GraphicCreatorDateTimeEMA(
                        nameFile: $"Индекс за 364 дня cкользящий.png",
                        collectionInformationForCreateImages.Keys.ToArray(),
                        array1,
                        EMA: Analytic.EMA(
                            collectionInformationForCreateImages.Values.ToArray(),
                            collectionInformationForCreateImages.Keys.ToArray().Length)
                        )
                   );

          

                    items.Add(
                         GraphicCreator.GraphicCreatorLineSupport(
                              candles: s,
                              linePoints: MethodLineSupport.lineSupport(url),
                              nameFile: nameStock + ".png"
                            
                             )
                        );

                    string answer = nameStock + ": " + generationText("Свечи", "1", s[0].Open, s[s.Count - 1].Close);
                    string answer2 = nameStock + ": " + generationText("Свечи", "364", s[0].Open, s[s.Count - 1].Close);



                    return ("", items, new List<string>() { answer, answer2 });






                case "MoscowExchangeHistory": // за 30 дней
                    collectionInformationForCreateImages = ParserXML.parsingXmlHistory(url);
                    double[] array = collectionInformationForCreateImages.Values.ToArray();
                    items = new List<string>()
                    {
                         GraphicCreator.GraphicCreatorDateTime(
                         nameFile: $"Индекс за 30 дней.png",
                         collectionInformationForCreateImages.Keys.ToArray(),
                         array)
                    };
                    answer = generationText("Индекс мосбиржи", text, array[0], array[array.Length - 1]);

                    return ("", items, new List<string>() { answer });

                case "MoscowExchangeHistoryYear":

                    break;

            }
            return ("", items, null);
        }


    }
}

