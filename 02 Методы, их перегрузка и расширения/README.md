# Переменные и операторы

## декларация и инициализация
```c#
int i;
i = 1;
int i = 1;
```

## статическая типизация
```c#
int i = 1;
i[0];
```
            
## неявная типизация
```c#
Examples.Var();
```
            
## методы определения типа
```c#
Examples.GetTypes();
```
            
## Числовые типы
```c#
Examples.DotnetTypesAndAliases();
Examples.NumericTypes();
```

## Булевские типы
```c#
Examples.BooleanTypes();
```      

## Символьный тип
```c#
Examples.CharTypes();
```

## Строковый тип
```c#
Examples.StringTypes();
```

## тип Object
```c#
Examples.Object();
```
            
## тип Dynamic
```c#
Examples.Dynamic();
```

## приведение типов
```c#
Examples.Cast();
```
            
## упаковка распаковка
```c#
Examples.BoxingUnboxing();
```

## Defaut
```c#
Examples.DefaultValues();
```

## is as
```C#
Examples.IsAs();
```

## арифметические операторы
```c#
Examples.ArithmeticOperators();
```

## операторы сравнения
```c#
Examples.CompareOperators();
```

## логические операторы
```c#
Examples.BooleanOperators();
```

## операторы равенства
```c#
Examples.EqualityOperators();
```

## операторы присвоения
```c#
Examples.AssignmentOperators();
```


# namespace Variables 

```c#
namespace Variables;

public static class Examples
{
    /// <summary>
    /// Числовые типы
    /// </summary>
    public static void DotnetTypesAndAliases()
    {
        System.Int32 i = 10;
        int j = 10;
        var z = 10;
    }

    /// <summary>
    /// Числовые типы
    /// </summary>
    public static void NumericTypes()
    {
        var intgerNumber = 100000000000000000;
        var doubleNumber = 100.0;
    }


    /// <summary>
    /// неявная типизация
    /// </summary>
    public static void Variable()
    {
        int i = 10;
        var j = 10;
    }

    /// <summary>
    /// Булевские типы
    /// </summary>
    public static void BooleanTypes()
    {
        bool booleanVar = true;
        var booleanVar2 = false;
    }

    /// <summary>
    /// Символьный тип
    /// </summary>
    public static void CharTypes()
    {
        char charVar = '1';
    }

    /// <summary>
    /// Строковый тип
    /// </summary>
    public static void StringTypes()
    {
        var stringVar = "someValue";
        Console.WriteLine(stringVar[3]);
        
        stringVar = stringVar + "1";
        Console.WriteLine(stringVar);
    }
    /// <summary>
    /// неявная типизация
    /// </summary>
    public static void Var()
    {
        int value1 = 2;
        var value2 = 2;
    }

    /// <summary>
    /// тип Object
    /// </summary>
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

    /// <summary>
    /// методы определения типа
    /// </summary>
    public static void GetTypes()
    {
        var length = 10;
        Console.WriteLine(length.GetType()); // определение типа
        Console.WriteLine(typeof(int)); // понять что за тип
    }

    /// <summary>
    /// тип Dynamic
    /// </summary>
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

    /// <summary>
    /// упаковка распаковка
    /// </summary>
    public static void BoxingUnboxing()
    {
        int i = 1;
        object obj = i;
        Console.WriteLine(obj.GetType());
        int newI = (int)obj;
        Console.WriteLine(newI.GetType());
    }

    /// <summary>
    /// приведение типов
    /// </summary>
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
    /// <summary>
    /// Defaut
    /// </summary>
    public static void DefaultValues()
    {
        int i;
        object j;
        string s;

        int? nullableI;
    }
    /// <summary>
    /// is as
    /// </summary>
    public static void IsAs()
    {
        string s = "abc";
        var obj = (object)s;
        
        Console.WriteLine("abc" is object);
        Console.WriteLine(1 is string);
    }
    /// <summary>
    /// арифметические операторы
    /// </summary>
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

    /// <summary>
    /// операторы сравнения
    /// </summary>
    public static void CompareOperators()
    {
        Console.WriteLine($"2 < 1  {2 < 1}");
        Console.WriteLine($"2 > 1  {2 > 1}");
        Console.WriteLine($"2 >= 1  {2 >= 1}");
        Console.WriteLine($"1 >= 1  {1 <= 1}");
    }
    /// <summary>
    /// логические операторы
    /// </summary>
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
    /// <summary>
    /// операторы равенства
    /// </summary>
    public static void EqualityOperators()
    {
        Console.WriteLine($"1.0 == 1.0  {1.0 == 1.0}");
        Console.WriteLine($"1.0 != 1.0  {1.0 != 1.0}");

        string x = "1";
        //int t = || x;
    }
    /// <summary>
    /// операторы присвоения
    /// </summary>
    public static void AssignmentOperators()
    {
        var x = 1;
        x = 2;
        x = 1;
        x = 100000;
        Console.WriteLine($"x = {x}");
    }
}
```