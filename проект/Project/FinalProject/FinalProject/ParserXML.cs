using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        foreach (XmlNode childNode1 in childnode.ChildNodes)
                        {
                            DataBase.DataStock item = new DataBase.DataStock();
                            PropertyInfo[] properties = typeof(DataBase.DataStock).GetProperties(); // получение свойства класса
                            Type t = typeof(DataBase.DataStock); // https://learn.microsoft.com/en-us/dotnet/api/system.reflection.propertyinfo.propertytype?view=net-8.0


                            for (int i = 0; i < childNode1.Attributes.Count; i++)
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

        static public string parsing(string xml, bool visibleTeg = false)
        {
            List<double> items = new List<double>();
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
                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childNode in xNode.ChildNodes)
                    {
                        foreach (XmlNode childNode1 in childNode.ChildNodes)
                        {
                            if (visibleTeg)
                            {
                                for (int i = 0; i < childNode1.Attributes.Count; i++)
                                {
                                    Console.Write($"{childNode1.Attributes[i].InnerText} {childNode1.Attributes[i].LocalName} ");
                                }
                            }
                            items.Add(Convert.ToDouble(childNode1.Attributes[0].InnerText.ToString().Replace(".", ",")));
                            if (visibleTeg)
                            {
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            return Analytic.AnalyticMoscowExchange(items);
        }
    }


}
