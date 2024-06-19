namespace Variables;

public static class Examples
{
    
    public static void DotnetTypesAndAliases()
    {
        System.Int32 i = 10;
        int j = 10;
        var z = 10;
    }
    
    public static void Variable()
    {
        int i = 10;
        var j = 10;
    }
    
    public static void NumericTypes()
    {
        var intgerNumber = 100000000000000000;
        var doubleNumber = 100.0;
    }
    
    public static void BooleanTypes()
    {
        bool booleanVar = true;
        var booleanVar2 = false;
    }
    
    public static void CharTypes()
    {
        char charVar = '1';
    }
    
    public static void StringTypes()
    {
        var stringVar = "someValue";
        Console.WriteLine(stringVar[3]);
        
        stringVar = stringVar + "1";
        Console.WriteLine(stringVar);
    }
    
    public static void Var()
    {
        int value1 = 2;
        var value2 = 2;
    }
    
    public static void Object()
    {
        //ToString
        var i = 10;
        Console.WriteLine(i.ToString());
        var j = "someString";
        Console.WriteLine(j.ToString());
        var obj = new object();
        Console.WriteLine(obj.ToString());
        
        //Equals
        Console.WriteLine(i.Equals(10));
        Console.WriteLine(j.Equals("someString"));
        Console.WriteLine(obj.Equals(new object()));
        
        //GetHashCode
        var value1 = "2";
        var value2 = "3";
        Console.WriteLine(value1.GetHashCode());
        Console.WriteLine(value2.GetHashCode());
    }
    
    public static void GetTypes()
    {
        //var length = 10;
        
        //Console.WriteLine(length.GetType());
        
        //Console.WriteLine(typeof(int));
    }
    
    public static void Dynamic()
    {
        dynamic e = 1;
        //Console.WriteLine(typeof(dynamic));
        try
        {
            e.GetType();
            Console.WriteLine(e[0]);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }
    
    public static void BoxingUnboxing()
    {
        int i = 1;
        object obj = i;
        Console.WriteLine(obj.GetType());
        int newI = (int)obj;
        Console.WriteLine(newI.GetType());
    }
    
    public static void Cast()
    {
        //implicit
        int i = 10;
        long j = i;
        object obj = j;

        //explicit
        byte b = (byte)i;
        
        //char index
        int indexA = 'a';
        Console.WriteLine(indexA);
        
        int indexD = 'z';
        Console.WriteLine(indexD);
        
       
    }
    
    public static void DefaultValues()
    {
        int i;
        object j;
        string s;

        int? nullableI;
    }
    
    public static void IsAs()
    {
        string s = "abc";
        var obj = (object)s;
        
        Console.WriteLine("abc" is object);
        Console.WriteLine(1 is string);
    }
    
    public static void ArithmeticOperators()
    {
        int i = 1;
        Console.WriteLine(i++);
        Console.WriteLine(i++);
        Console.WriteLine(i);

        // (1+2)^2
        var result = 1 + 2*2 + 4;
        Console.WriteLine(result);
        
        var result2 = 5 / 2;
        var result3 = 5 / 2.0;
        var result4 = 5 % 2;
        Console.WriteLine(result2);
        Console.WriteLine(result3);
        Console.WriteLine(result4);
    }
    
    public static void CompareOperators()
    {
        Console.WriteLine($"2 < 1  {2 < 1}");
        Console.WriteLine($"2 > 1  {2 > 1}");
        Console.WriteLine($"2 >= 1  {2 >= 1}");
        Console.WriteLine($"1 >= 1  {1 <= 1}");
    }
    
    public static void BooleanOperators()
    {
        Console.WriteLine($"true && true  {true && true}");
        Console.WriteLine($"false && true  {false && true}");
        Console.WriteLine($"true && false  {true && false}");
        Console.WriteLine($"false && false  {false && false}");
        
        Console.WriteLine($"true || true  {true || true}");
        Console.WriteLine($"false || true  {false || true}");
        Console.WriteLine($"true || false  {true || false}");
        Console.WriteLine($"false || false  {false || false}");
 
        Console.WriteLine($"!false {!false}");
        Console.WriteLine($"!true {!true}");
    }
    
    public static void EqualityOperators()
    {
        Console.WriteLine($"1.0 == 1.0  {1.0 == 1.0}");
        Console.WriteLine($"1.0 != 1.0  {1.0 != 1.0}");

        string x = "1";
        //int t = || x;
    }
    
    public static void AssignmentOperators()
    {
        var x = 1;
        x = 2;
        x = 1;
        x = 100000;
        Console.WriteLine($"x = {x}");
    }
}