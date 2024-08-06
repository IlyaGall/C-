using System;
using System.Collections.Generic;

namespace Tuples
{
    internal class Program
    {
        public static bool TryParse(string str)
        {
            str = str.ToLower();
            if (str == "ложь")
            {
                return false;
            }
            if (str == "истина")
            {
                return true;
            }
            if (str == "false")
            {
                return false;
            }
            if (str == "true")
            {
                return true;
            }

            return false;
        }

        public static (bool, string) TryParseBool(string str)
        {
            str = str.ToLower();
            if (str == "ложь")
            {
                return (false, "ru");
            }
            if (str == "истина")
            {
                return (true, "ru");
            }
            if (str == "false")
            {
                return (false, "en");
            }
            if (str == "true")
            {
                return (true, "en");
            }

            return (false, "?");
        }

        public static Tuple<bool, string> TryParseBoolExplicit(string str)
        {
            str = str.ToLower();
            if (str == "ложь")
            {
                return Tuple.Create(false, "ru");
            }
            if (str == "истина")
            {
                return Tuple.Create(true, "ru");
            }
            if (str == "false")
            {
                return Tuple.Create(false, "en");
            }
            if (str == "true")
            {
                return Tuple.Create(true, "en");
            }

            return Tuple.Create(false, "?");
        }

        public static (bool res, string lang) TryParseBoolNamed(string str)
        {
            str = str.ToLower();
            if (str == "ложь")
            {
                return (res: false, lang: "ru");
            }
            if (str == "истина")
            {
                return (res: true, lang: "ru");
            }
            if (str == "false")
            {
                return (res: false, lang: "en");
            }
            if (str == "true")
            {
                return (res: true, lang: "en");
            }

            return (false, "?");
            //return (false, null, "Не удалось");
            //return null;
        }

        private static void Main(string[] args)
        {
            var resNamed = TryParseBoolNamed("истина");
            Console.WriteLine("Именной");
            Console.WriteLine("res: " + resNamed.res);
            Console.WriteLine("lang: " + resNamed.lang);
            Console.WriteLine("tuple: " + resNamed);
            Console.WriteLine("---");
            Console.WriteLine();

            //var res = TryParseBool("false");
            //Log(res);
            

            var (result, language) = TryParseBoolNamed("истина");
            Console.WriteLine("Деконструктуирование");
            Console.WriteLine("res: " + result);
            Console.WriteLine("lang: " + language);
            Console.WriteLine("---");
            Console.WriteLine();

            Console.WriteLine("Сохранение в списке");
            var inputs = new[] { "ИСТИНА", "FALSE" };

            var outputs = new List<Tuple<bool, string>>();
            foreach (var input in inputs)
            {
                Tuple<bool, string> output = TryParseBoolExplicit(input);
                outputs.Add(output);
                Console.WriteLine(output);
            }
            Console.WriteLine("---");
            Console.WriteLine();

            Console.WriteLine("Деконструирование в цикле");
            foreach (var (r, l) in outputs)
            {
                Console.WriteLine("res: " + r);
                Console.WriteLine("lang: " + l);
            }
            Console.WriteLine("---");
            Console.WriteLine();

            Console.ReadKey();
        }

        public static void Log((bool, string) res)
        {
            Console.WriteLine("Без имен");
            Console.WriteLine("Item1: " + res.Item1);
            Console.WriteLine("Item2: " + res.Item2);
            Console.WriteLine("tuple: " + res);
            Console.WriteLine("---");
            Console.WriteLine();
        }
    }
}