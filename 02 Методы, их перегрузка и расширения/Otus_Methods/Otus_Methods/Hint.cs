namespace Otus_Methods;

public class Hint
{
    public static void HintMethod()
    {
        // Console.WriteLine
        Console.WriteLine("Hello OTUS");

        // Static Sum
        var sum = Sum(2, 7);
        Console.WriteLine(sum);

        // Non static Sum
        var program = new Program();
        //var sum2 = program.Sum2(2, 10);
        //Console.WriteLine(sum2);

        // Custom void WriteLine
        WriteLine("String");

        // WriteLine without args
        WriteLineHello();

        // Static method in custom class
        //Test.TestMethod();

        // Console.WriteLine перегрузка 
        Console.WriteLine("Test");
        Console.WriteLine("Test {0}, {1} {2} {3}", 12345, false, true, 555);

        // Перегрузка Sum
        Console.WriteLine(Sum(5, 6));
        Console.WriteLine(Sum(5, 6, 7));
        Console.WriteLine(Sum("string"));

        // Factorial
        var f = Fact(5);
        Console.WriteLine(f);

        // Sum with params
        var sum3 = Sum(1, 2, 3, 4, 5, 6, 7, 8, 8, 9, 0);
        Console.WriteLine(sum3);

        // FormatNums
        var str1 = FormatNums(5, 6);
        Console.WriteLine(str1);
        var str2 = FormatNums(10, 11, "{0}  {1}");
        Console.WriteLine(str2);

        var str3 = FormatNums(8, 9, format2: "Hello Otus", format3: "Test -- Test");
        Console.WriteLine(str3);
        
        // Ref
        int a = 5;
        int b = 6;
        Swap(ref a, ref b);
        Console.WriteLine("a = " + a + " --- " + "b = " + b);

        // out
        bool res;

        if (TryParse("false", out res))
        {
            Console.WriteLine("Res = " + res);
        }

        if (TryParse("guygyugyu", out res))
        {
            Console.WriteLine("Res2 = " + res);
        }
    }

    public static bool TryParse(string s, out bool res)
    {
        if (s == "true" || s == "false")
        {
            res = s == "true";

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

    public static string FormatNums(int a, int b, string format = "[ {0} -- {1}]", string format2 = "", string format3 = "Test")
    {
        return String.Format(format, a,b);
    }

    public static int Fact(int n)
    {
        if (n == 1)
            return 1;

        return Fact(n - 1) * n;
    }


    public static int Sum(int first, int second)
    {
        return first + second;
    }

    public static int Sum(int first, int second, int third)
    {
        return Sum(first, second) + third;
    }

    public static string Sum(string s)
    {
        return s;
    }

    public static int Sum(params int[] nums)
    {
        return nums.Sum();
    }

    public int Sum2(int first, int second)
    {
        return first + second;
    }

    public static void WriteLine(string s)
    {
        Console.WriteLine(s);
    }

    public static void WriteLineHello()
    {
        Console.WriteLine("Hello");
    }
}
