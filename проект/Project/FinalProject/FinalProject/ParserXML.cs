using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Telegram.Bot.Requests.Abstractions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinalProject
{

    /// <summary>
    /// Класс для того, чтобы распарить json
    /// </summary>
    public static class ParserXML
    {

        /// <summary>
        /// Распрасить данные из json (для заполнения бд  DataStock)
        /// </summary>
        /// <param name="json">файл json</param>
        /// <param name="items">коллекция класса List<DataBase.DataStock></param>
        static public List<DataBase.DataStock> parsing(string json, List<DataBase.DataStock> items)
        {

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(json);
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                // обход всех узлов в корневом элементе
                foreach (XmlElement xnode in xRoot)
                {
                    // получаем атрибут name
                    XmlNode? attr = xnode.Attributes.GetNamedItem("row");
                    Console.WriteLine(attr?.Value);

                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childNode in xnode.ChildNodes)
                    {
                        foreach (XmlNode childNode1 in childNode.ChildNodes)
                        {
                            DataBase.DataStock item = new DataBase.DataStock();
                            PropertyInfo[] properties = typeof(DataBase.DataStock).GetProperties(); // получение свойства класса
                            Type t = typeof(DataBase.DataStock); // https://learn.microsoft.com/en-us/dotnet/api/system.reflection.propertyinfo.propertytype?view=net-8.0


                            for (int i = 0; i < childNode1?.Attributes?.Count; i++)
                            {
                                Console.Write($"{childNode1.Attributes[i].InnerText} {childNode1.Attributes[i].LocalName} ");

                                switch (t.GetProperties()[i].PropertyType.Name)
                                {
                                    case "String":
                                        properties[i].SetValue(item, childNode1.Attributes[i].Value);
                                        break;
                                    case "Double":
                                        properties[i].SetValue(item, Convert.ToDouble(childNode1.Attributes[i].Value.Replace(".", ",")));
                                        break;
                                    case "Int16":
                                        properties[i].SetValue(item, Convert.ToInt16(childNode1.Attributes[i].Value));
                                        break;
                                    case "Int32":
                                        properties[i].SetValue(item, Convert.ToInt32(childNode1.Attributes[i].Value));
                                        break;
                                    case "Int64":
                                        properties[i].SetValue(item, Convert.ToInt64(childNode1.Attributes[i].Value));
                                        break;
                                    default:
                                        throw new Exception($"Не известный тип данных {t.GetProperties()[i].PropertyType.Name}");
                                }
                            }
                            Console.WriteLine("", "");
                            items.Add(item);
                        }
                    }
                    Console.WriteLine();
                }
            }
            return items;
        }






        static private Dictionary<DateTime, double> parsingXML(Dictionary<DateTime, double> items, XmlElement xNode, bool visibleTeg = false)
        {
            // обходим все дочерние узлы элемента user
            foreach (XmlNode childNode in xNode.ChildNodes)
            {
                foreach (XmlNode childNode1 in childNode.ChildNodes)
                {
                    if (visibleTeg)
                    {
                        for (int i = 0; i < childNode1?.Attributes?.Count; i++)
                        {
                            Console.Write($"{childNode1.Attributes[i].InnerText} {childNode1.Attributes[i].LocalName} ");
                        }
                    }
                    items.Add(Convert.ToDateTime(childNode1?.Attributes?[1].InnerText), Convert.ToDouble(childNode1?.Attributes?[0].InnerText.ToString().Replace(".", ",")));
                    if (visibleTeg)
                    {
                        Console.WriteLine();
                    }
                }
            }
            return items;
        }






        /// <summary>
        /// распарcить индекс мосбиржи
        /// </summary>
        /// <param name="xml">xml</param>
        /// <param name="request"></param>
        /// <param name="visibleTeg"></param>
        /// <returns></returns>
        static public string parsing(string xml, string request, bool visibleTeg = false)
        {
            Dictionary<DateTime, double> items = new Dictionary<DateTime, double>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xml);
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                // обход всех узлов в корневом элементе
                foreach (XmlElement xNode in xRoot)
                {
                    // получаем атрибут name
                    XmlNode? attr = xNode.Attributes.GetNamedItem("id");

                    Console.WriteLine(attr?.Value);

                    switch (attr?.Value)
                    {
                        case "history":
                            items = parsingXML(
                                items: items,
                                xNode: xNode,
                                visibleTeg: false);
                            break;
                        case "history.cursor":
                            foreach (XmlNode childNode in xNode.ChildNodes)
                            {
                                foreach (XmlNode childNode1 in childNode.ChildNodes)
                                {
                                    //Telegram.SendMessageDebagger($"{childNode1?.Attributes?[0].InnerText} {childNode1?.Attributes?[0].LocalName}\n" +
                                    //     $"{childNode1?.Attributes?[1].InnerText} {childNode1?.Attributes?[1].LocalName}\n" +
                                    //     $"{childNode1?.Attributes?[2].InnerText} {childNode1?.Attributes?[2].LocalName} ");
                                    double index = Convert.ToInt32(childNode1?.Attributes?[0].InnerText);
                                    double total = Convert.ToInt32(childNode1?.Attributes?[1].InnerText);
                                    double pageSize = Convert.ToInt32(childNode1?.Attributes?[2].InnerText);

                                    if (index + pageSize < total)
                                    {
                                        for (double i = 1; i < total / 100; i++)
                                        {
                                            Console.WriteLine($"обработано страниц {i} из {total / 100}");
                                            xDoc.LoadXml(Request.request(request + $"&start={i * 100}"));


                                            xRoot = xDoc.DocumentElement;
                                            foreach (XmlElement xNodeHistory in xRoot)
                                            {
                                                XmlNode? attrHistory = xNodeHistory.Attributes.GetNamedItem("id");

                                                switch (attrHistory?.Value)
                                                {
                                                    case "history":
                                                        items = parsingXML(
                                                            items: items,
                                                            xNode: xNodeHistory,
                                                            visibleTeg: false);
                                                        break;
                                                }

                                            }
                                        }
                                    }


                                }
                            }
                            break;
                        default:
                            throw new Exception("Не известный xml файл");
                    }
                }
            }

            return Analytic.AnalyticMoscowExchange(items);
        }



        ////////////////////########новый парсер###########/////////////////////

        /// <summary>
        /// Парсинг исторического массива данных
        /// </summary>
        /// <returns></returns>
        public static Dictionary<DateTime, double> parsingXmlHistory(string request, bool visibleTeg = false)
        {
            string xml = Request.RequestServer(request);
            Dictionary<DateTime, double> items = new Dictionary<DateTime, double>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xml);
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                // обход всех узлов в корневом элементе
                foreach (XmlElement xNode in xRoot)
                {
                    // получаем атрибут name
                    XmlNode? attr = xNode.Attributes.GetNamedItem("id");
                    switch (attr?.Value)
                    {
                        case "history":
                            items = parsingXML(
                                items: items,
                                xNode: xNode,
                                visibleTeg: false);
                            break;
                        case "history.cursor":
                            foreach (XmlNode childNode in xNode.ChildNodes)
                            {
                                foreach (XmlNode childNode1 in childNode.ChildNodes)
                                {
                                    double index = Convert.ToInt32(childNode1?.Attributes?[0].InnerText);
                                    double total = Convert.ToInt32(childNode1?.Attributes?[1].InnerText);
                                    double pageSize = Convert.ToInt32(childNode1?.Attributes?[2].InnerText);

                                    if (index + pageSize < total)
                                    {
                                        for (double i = 1; i < total / 100; i++)
                                        {
                                            Console.WriteLine($"обработано страниц {i} из {total / 100}");
                                            xDoc.LoadXml(Request.request(request + $"&start={i * 100}"));


                                            xRoot = xDoc.DocumentElement;
                                            foreach (XmlElement xNodeHistory in xRoot)
                                            {
                                                XmlNode? attrHistory = xNodeHistory.Attributes.GetNamedItem("id");

                                                switch (attrHistory?.Value)
                                                {
                                                    case "history":
                                                        items = parsingXML(
                                                            items: items,
                                                            xNode: xNodeHistory,
                                                            visibleTeg: false);
                                                        break;
                                                }

                                            }
                                        }
                                    }


                                }
                            }
                            break;
                        default:
                            throw new Exception("Не известный xml файл");
                    }
                }
            }

            return items;
        }





        public static List<Candle> passingXMLStock(string request)
        {
            List<Candle> candles = new List<Candle>();
            string xml = Request.RequestServer(request);
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xml);
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xNode in xRoot)
                {
                    XmlNode? attr = xNode.Attributes.GetNamedItem("id");
                    foreach (XmlNode childNode in xNode.ChildNodes)
                    {
                        foreach (XmlNode childNode1 in childNode.ChildNodes)
                        {
                            if (childNode1.LocalName == "row")
                            {
                                candles.Add(
                                    new Candle(
                                        childNode1?.Attributes?[0].InnerText,
                                        childNode1?.Attributes?[1].InnerText,
                                        childNode1?.Attributes?[2].InnerText,
                                        childNode1?.Attributes?[3].InnerText,
                                        childNode1?.Attributes?[4].InnerText,
                                        childNode1?.Attributes?[5].InnerText,
                                        childNode1?.Attributes?[6].InnerText,
                                        childNode1?.Attributes?[7].InnerText
                                        )
                                    );
                                
                            }
                        }
                    }
                }
            }
            return candles;
        }


        /// <summary>
        /// свечка
        /// </summary>
        public class Candle
        {
            /// <summary>
            /// открытие (цена) 
            /// </summary>
            public double Open { get; set; }
            /// <summary>
            /// закрытие (цена)
            /// </summary>
            public double Close { get; set; }
            /// <summary>
            /// покупка(высота)
            /// </summary>
            public double High { get; set; }
            /// <summary>
            /// продажа (высота)
            /// </summary>
            public double Low { get; set; }
            /// <summary>
            /// стоимость
            /// </summary>
            public double Value { get; set; }
            /// <summary>
            /// Объём
            /// </summary>
            public double Volume { get; set; }
            /// <summary>
            /// начало время продажи (свечки)
            /// </summary>
            public DateTime Begin { get; set; }
            /// <summary>
            /// конец время продажи (свечки)
            /// </summary>
            public DateTime End { get; set; }


            public Candle(string? open, string? close, string? high, string? low, string? value, string? volume, string? begin, string? end)
            {
                Open = Convert.ToDouble(open?.Replace('.',','));
                Close = Convert.ToDouble(close?.Replace('.', ','));
                High = Convert.ToDouble(high?.Replace('.', ','));
                Low = Convert.ToDouble(low?.Replace('.', ','));
                Value = Convert.ToDouble(value?.Replace('.', ','));
                Volume = Convert.ToDouble(volume?.Replace('.',','));
                Begin = Convert.ToDateTime(begin);
                End = Convert.ToDateTime(end);
            }

        }

    }


}
