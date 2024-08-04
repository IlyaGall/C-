namespace ConsoleApp1
{
    internal class Program
    {
        
        
        delegate void Calculate(int x, int y);

        static void Main(string[] args)
        {
            double x = 5;
            double y = 7;
            double result = Sum(x, y);
            Console.WriteLine("Простой метод: " + result);
            Console.WriteLine("---");
            Console.WriteLine();

            Calculate(5, 7, Sum);
            Calculate(5, 7, Diff);
            Console.WriteLine("---");
            Console.WriteLine();

            result = Calculate(5, 7, delegate (double x, double y)
            {
                return x + y;
            });
            Console.WriteLine("Анонимный метод: " + result);
            Console.WriteLine("---");
            Console.WriteLine();

            result = Calculate(5, 7, (arg1, arg2) =>
            {
                Console.WriteLine("Мы внутри лямбда-выражения");
                return arg1 + arg2;
            });
            Console.WriteLine("Лямбда-выражение: " + result);
            Console.WriteLine("---");
            Console.WriteLine();

            result = Calculate(5, 7, (arg1, arg2) => arg1 + arg2);
            Console.WriteLine("Однострочное лямбда-выражение: " + result);
            Console.WriteLine("---");
            Console.WriteLine();

            Console.WriteLine("Деконструирование в цикле");
            var inputs = new[] { "ИСТИНА", "FALSE" };
            foreach (var (r, l) in inputs.Select(input => TryParseBoolNamed(input)))
            {
                Console.WriteLine("res: " + r);
                Console.WriteLine("lang: " + l);
            }
            Console.WriteLine("---");
            Console.WriteLine();

            BiFunc lambda1 = (arg1, arg2) => arg1 + arg2;
            Console.WriteLine("Вызов лямбды, сохраненной в переменную-делегат: " + lambda1(5, 7));
            Console.WriteLine("---");
            Console.WriteLine();

            Func<double, double, double> lambda2 = (arg1, arg2) => arg1 + arg2;
            Console.WriteLine("Вызов лямбды, сохраненной в переменную-Func: " + lambda2(5, 7));
            Console.WriteLine("---");
            Console.WriteLine();

            Action<double, double> lambda3 = (arg1, arg2) => Console.WriteLine(arg1 + arg2);
            Console.Write("Вызов лямбды, сохраненной в переменную-Action: ");
            lambda3(5, 7);
            Console.WriteLine("---");
            Console.WriteLine();

            var z = 500;
            Func<double, double, double> lambda4 = (arg1, arg2) => arg1 + arg2 + z;
            Console.WriteLine("Лямбда с замыканием: " + lambda4(5, 7));
            Console.WriteLine("---");
            Console.WriteLine();

            var leakedClass = new LeakedClass();
            var func = leakedClass.GetFunc();
            Console.WriteLine("Лямбда, приведшая к утечке: " + func(5, 7));
            Console.WriteLine("---");
            Console.WriteLine();

            Console.ReadKey();
        }

        static List<int> Filter(List<int> integers, MyFilterDelegate criteria)
        {
            var result = new List<int>();
            foreach (var i in integers)
            {
                if (criteria(i))
                {
                    result.Add(i);
                }
            }
            return result;
        }

        delegate bool MyFilterDelegate(int i);

        static double Sum(double arg1, double arg2)
        {
            var result = arg1 + arg2;
            return result;
        }

        static double Diff(double arg1, double arg2)
        {
            var result = arg1 - arg2;
            return result;
        }

        delegate double BiFunc(double arg1, double arg2);

        static public (bool res, string lang) TryParseBoolNamed(string str)
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
        }

        class LeakedClass
        {
            private readonly int _i = 500;

            public BiFunc GetFunc()
            {
                BiFunc myDelegate = (a, b) => a + b + _i;
                return myDelegate;
            }
        }
        
    }
}
