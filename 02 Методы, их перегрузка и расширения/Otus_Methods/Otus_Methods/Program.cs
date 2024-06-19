using System;

namespace Otus_Methods
{
    public class Program
    {
        public static void Main()
        {
            // Console.WriteLine
            // Статический метод
            Console.WriteLine("Hello Otus");

            // Static Sum
            var first = 5;
            var second = 5;
            var staticSum = StaticSum(first, second);
            var staticSum2 = StaticSum2(7, 8);
            Console.WriteLine("staticSum: " + staticSum);
            Console.WriteLine("staticSum2: " + staticSum2);
            

            // Non static Sum
            var program = new Program();
            var nonStaticSum = program.NonStaticSum(2, 3);
            Console.WriteLine("nonStaticSum: " + nonStaticSum);
            
            Console.WriteLine("GetRetirenmentAge: " + Person.GetRetirenmentAge());


            var person = new Person("Tom");
            var person2 = new Person("Jack");
            var person3 = new Person("Rob");
            Console.WriteLine("person2 name: "+ person2.GetName());
            Console.WriteLine("person name: "+ person.GetName());

            // Custom void WriteLine
            WriteLineCustom("WriteLineCustom");

            // WriteLine without args
            WriteLineWithoutArgsVoid();
            var x = WriteLineWithoutArgs();
            Console.WriteLine("x "+ x);

            // Static method in custom class
            Person.WriteLineWithoutArgs();
            WriteLineWithoutArgs();

            // Console.WriteLine перегрузка 
            Console.WriteLine("Simple WriteLine");
            Console.WriteLine("Writeline {0} {1} {2}", "text", 234, true);

            // Перегрузка Sum
            var firstSum = StaticSum(2, 3);
            var secondSum = StaticSum(2, 3, 5);
            var thirdSum = StaticSum("12", "5");
            StaticSum("test", 1);
            StaticSum(1, "test");
            Console.WriteLine("firstSum " + firstSum);
            Console.WriteLine("secondSum " + secondSum);
            Console.WriteLine("thirdSum " + thirdSum);


            // Factorial
            var fact = Fact(5);
            Console.WriteLine("Fact = " + fact);

            // Sum with params
            var paramsSum = StaticSum(1,2,3,4,5,6,7,8,9,10);

            var paramsSum2 = StaticSum(new int[] { 1,2,3,4,5,6,7,8,9,10});
            Console.WriteLine("paramsSum = " + paramsSum);
            Console.WriteLine("paramsSum2 = " + paramsSum2);

            // FormatNums
            Console.WriteLine(FormatNums(5, 7));
            Console.WriteLine(FormatNums(5,7, "{0} ---- ??? --- {1}"));
            Console.WriteLine(FormatNums(5, format: "{0} ---- ??? --- {1}"));

            // Ref
            var a = 6;
            var b = 9;
            Swap(ref a, ref b);
            Console.WriteLine($"a = {a}, b = {b}");

            // out
            var d = new Dictionary<int, string>() { {1, "first"}, {2, "second"}};

            if (d.TryGetValue(2, out var res))
            {
                Console.WriteLine(res);
            }


            if (TryParse("true", out var res2))
            {
                Console.WriteLine("Success " + res2);
            }

        }

        static bool TryParse(string s, out bool res)
        {
            if (s == "false" || s == "true")
            {
                //res = s == "true";
                
                if (s == "true")
                    res = true;
                else
                    res = false;
                
                return true;
            }

            res = false;

            return false;
        }

        public static void Swap(ref int a, ref int b)
        {
            var c = a;
            a = b;
            b = c;
        }

        public static string FormatNums(int a, int b = 5, string format = "[{0} {1}]")
        {
            return string.Format(format, a, b);
        }

        public static long Fact(long n)
        {
            if (n == 1)
               return 1;
               
            Console.WriteLine("n = " + n);

            var fact = Fact(n - 1) * n;
            
            return fact;
        }
        
        public static int WriteLineWithoutArgs()
        {
            Console.WriteLine("??? WriteLineWithoutArgs ???");
            return 1;
        }

        public static void WriteLineWithoutArgsVoid()
        {
            Console.WriteLine("---- Hello WriteLineWithoutArgsVoid ----");
        }

        public static void WriteLineCustom(string s)
        {
            Console.WriteLine("---- " + s + " ----");
        }
        
        public static int StaticSum(int n1, params int[] nums)
        {
            foreach (var num in nums)
            {
                Console.WriteLine(num);
            }
            
            return nums.Sum();
        }
        
        public static int StaticSum(params int[] nums)
        {
            foreach (var num in nums)
            {
                Console.WriteLine(num);
            }
            
            return nums.Sum();
        }

        public static int StaticSum(int a, int b)
        {
            //var sum = a + b;

            return a + b;
        }
        
        public static double StaticSum3(int a, int b)
        {
            return a + b + 0.2;
        }
        
        public static int StaticSum(int a, int b, int c)
        {
            return a + b + c;
        }
        
        public static string StaticSum(string s1, string s2)
        {
            return s1 + s2;
        }
        
        public static void StaticSum(string s1, int s2)
        {
            Console.WriteLine(s1 + s2);
        }
        
        public static void StaticSum(int s2, string s1)
        {
            Console.WriteLine(s1 + s2);
        }
        
        public static int StaticSum2(int a, int b) => a + b;
        
        public int NonStaticSum(int a, int b) => a + b;
    }

    public class Person
    {
        private const string Const = "Const";
        private readonly string _name;

        public Person(string name)
        {
            _name = name;
        }
        
        public static int GetRetirenmentAge()
        {
            return 65;
        }

        public string GetName()
        {
            return _name;
        }
        
        public static int WriteLineWithoutArgs()
        {
            Console.WriteLine("??? WriteLineWithoutArgs ???");
            return 1;
        }
    }
}

