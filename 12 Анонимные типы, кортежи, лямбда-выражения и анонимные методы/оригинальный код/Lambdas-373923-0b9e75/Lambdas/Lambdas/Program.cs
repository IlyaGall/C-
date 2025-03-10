﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Lambdas
{
    public static class MyLinq
    {
        public static List<int> Filter(this List<int> collection, Func<int, bool> criteria)
        {
            var result = new List<int>();

            foreach (var i in collection)
            {
                if (criteria(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }

    











    internal class Program
    {
        private delegate bool CriteriaDelegate(int i);

        private static bool CriteriaEven(int i)
        {
            return i % 2 == 0;
        }

        public static bool CriteriaPositive(int i)
        {
            return i > 0;
        }
        
        private static bool CriteriaOdd(int i)
        {
            return i % 2 != 0;
        }

        private static void Main(string[] args)
        {
            var collection1 = new List<int>
            {
                1, -2, 15, 16, 200, 0, 14
            };
            
            var collection2 = new List<int>
            {
                1, -2, 15, 16, 200, 0, 14
            };

            var x = collection1
                .Select(x => new
                {
                    Value = x,
                    Key = x * x
                })
                .Join(collection2
                        .Select(x => new
                        {
                            Key = x * x
                        }),
                i => i.Value,
                i => i.Key,
                (i1, i2) => i1.Value + i2.Key);

            //var collection2 = FilterPositive(collection1);
            var collection3 = FilterEven(collection1);
            
            var collection2_2 = Filter(collection1, CriteriaPositive);
            var collection3_2 = Filter(collection1, CriteriaEven);
            //var collection4 = Filter(collection1, CriteriaOdd);

            var counter = 0;
            var collection4 = Filter(collection2, i =>
            {
                var isEven = i % 2 == 0;
                if (isEven)
                {
                    counter++;
                }
                if (counter > 2)
                {
                    return false;
                }
                return isEven;
            });

            var collection2_3 = collection1
                //.Where(i => i > 0)
                //.OrderBy(i => i)
                .Select(i => new
                {
                    Value = i
                })
                .GroupBy(i => i.Value % 2 == 0)
                .ToList();

            Func<int, int, int> func = (int item1, int item2) => item1 + item2;
            //Action<int>;


            var filtered = collection1.Filter(i => i > 0);

            /*Console.WriteLine("Положительные: " + JsonSerializer.Serialize(collection2));
            Console.WriteLine("Положительные: " + JsonSerializer.Serialize(collection2_2));
            Console.WriteLine("Четные:" + JsonSerializer.Serialize(collection3));
            Console.WriteLine("Четные:" + JsonSerializer.Serialize(collection3_2));*/
            
            Console.WriteLine("Тест:" + JsonSerializer.Serialize(x));
        }
        
       public static List<int> Filter(List<int> collection, Func<int, bool> criteriaDelegate)
        {
            var result = new List<int>();

            foreach (var i in collection)
            {
                if (criteriaDelegate(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }

        static List<int> FilterPositive(List<int> collection)
        {
            var result = new List<int>();

            foreach (var i in collection)
            {
                if (CriteriaPositive(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }
        
        static List<int> FilterEven(List<int> collection)
        {
            var result = new List<int>();

            foreach (var i in collection)
            {
                if (CriteriaEven(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }
        
        //static void Main(string[] args)
        //{
        //    double x = 5;
        //    double y = 7;
        //    double result = Sum(x, y);
        //    Console.WriteLine("Простой метод: " + result);
        //    Console.WriteLine("---");
        //    Console.WriteLine();

        //    //Calculate(5, 7, Sum);
        //    //Calculate(5, 7, Diff);
        //    //Console.WriteLine("---");
        //    //Console.WriteLine();

        //    //result = Calculate(5, 7, delegate (double x, double y)
        //    //{
        //    //    return x + y;
        //    //});
        //    //Console.WriteLine("Анонимный метод: " + result);
        //    //Console.WriteLine("---");
        //    //Console.WriteLine();

        //    //result = Calculate(5, 7, (arg1, arg2) =>
        //    //{
        //    //    Console.WriteLine("Мы внутри лямбда-выражения");
        //    //    return arg1 + arg2;
        //    //});
        //    //Console.WriteLine("Лямбда-выражение: " + result);
        //    //Console.WriteLine("---");
        //    //Console.WriteLine();

        //    //result = Calculate(5, 7, (arg1, arg2) => arg1 + arg2);
        //    //Console.WriteLine("Однострочное лямбда-выражение: " + result);
        //    //Console.WriteLine("---");
        //    //Console.WriteLine();

        //    //Console.WriteLine("Деконструирование в цикле");
        //    //var inputs = new[] { "ИСТИНА", "FALSE" };
        //    //foreach (var (r, l) in inputs.Select(input => TryParseBoolNamed(input)))
        //    //{
        //    //    Console.WriteLine("res: " + r);
        //    //    Console.WriteLine("lang: " + l);
        //    //}
        //    //Console.WriteLine("---");
        //    //Console.WriteLine();

        //    //BiFunc lambda1 = (arg1, arg2) => arg1 + arg2;
        //    //Console.WriteLine("Вызов лямбды, сохраненной в переменную-делегат: " + lambda1(5, 7));
        //    //Console.WriteLine("---");
        //    //Console.WriteLine();

        //    //Func<double, double, double> lambda2 = (arg1, arg2) => arg1 + arg2;
        //    //Console.WriteLine("Вызов лямбды, сохраненной в переменную-Func: " + lambda2(5, 7));
        //    //Console.WriteLine("---");
        //    //Console.WriteLine();

        //    //Action<double, double> lambda3 = (arg1, arg2) => Console.WriteLine(arg1 + arg2);
        //    //Console.Write("Вызов лямбды, сохраненной в переменную-Action: ");
        //    //lambda3(5, 7);
        //    //Console.WriteLine("---");
        //    //Console.WriteLine();

        //    //var z = 500;
        //    //Func<double, double, double> lambda4 = (arg1, arg2) => arg1 + arg2 + z;
        //    //Console.WriteLine("Лямбда с замыканием: " + lambda4(5, 7));
        //    //Console.WriteLine("---");
        //    //Console.WriteLine();

        //    //var leakedClass = new LeakedClass();
        //    //var func = leakedClass.GetFunc();
        //    //Console.WriteLine("Лямбда, приведшая к утечке: " + func(5, 7));
        //    //Console.WriteLine("---");
        //    //Console.WriteLine();

        //    Console.ReadKey();
        //}

        //static List<int> Filter(List<int> integers, MyFilterDelegate criteria)
        //{
        //    var result = new List<int>();
        //    foreach(var i in integers)
        //    {
        //        if (criteria(i))
        //        {
        //            result.Add(i);
        //        }
        //    }
        //    return result;
        //}

        //delegate bool MyFilterDelegate(int i);

        //static double Sum(double arg1, double arg2)
        //{
        //    var result = arg1 + arg2;
        //    return result;
        //}

        //static double Diff(double arg1, double arg2)
        //{
        //    var result = arg1 - arg2;
        //    return result;
        //}

        //delegate double BiFunc(double arg1, double arg2);

        //static public (bool res, string lang) TryParseBoolNamed(string str)
        //{
        //    str = str.ToLower();
        //    if (str == "ложь")
        //    {
        //        return (res: false, lang: "ru");
        //    }
        //    if (str == "истина")
        //    {
        //        return (res: true, lang: "ru");
        //    }
        //    if (str == "false")
        //    {
        //        return (res: false, lang: "en");
        //    }
        //    if (str == "true")
        //    {
        //        return (res: true, lang: "en");
        //    }

        //    return (false, "?");
        //}

        //class LeakedClass
        //{
        //    private readonly int _i = 500;

        //    public BiFunc GetFunc()
        //    {
        //        BiFunc myDelegate = (a, b) => a + b + _i;
        //        return myDelegate;
        //    }
        //}
    }
}