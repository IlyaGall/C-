


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;






//var forInt = new Korobka<int>();

//forInt.Put(1);
//// forInt.Put("2");
//var s = forInt.Pop();
//forInt.PrintMe(true);
//forInt.PrintMe<bool>(true);
//forInt.PrintMe<string>("Privet");
//forInt.PrintMe(DateTime.Now);


var extracCol = new MyExtraCollection<double>();
var doubleCol = new DoubleCollection();
doubleCol.Values = new double[] { 1, 2, 3, 4, 5, 6, 7 };
Console.WriteLine(doubleCol.GeomAvg());
Console.WriteLine("-----------------");


var kv1 = new MyKeyValue<int, string>(1, "privet");
var kv2 = new MyKeyValue<DateTime, double>(DateTime.Now, 1.4);
var kv3 = new MyKeyValue<DateTime, string>(DateTime.Now, "FASF");


MyDefault.DisplayDefault<int>();
MyDefault.DisplayDefault<string>();

MyDefault.DisplayDefault<string>("privet");
MyDefault.DisplayDefault<Complex>();

MyDefault.DisplayDefault<DateTime>();

Console.WriteLine("-----------------");


var d = new Dictionary<int, string>();


var newCOns1 = new NewConstraint<int>();
var newCOns2 = new NewConstraint<bool>();
var sc = new SimpleClass();
var newCOns3 = new NewConstraint<SimpleClass>();
var cc = new ComplexClass(1);


var lada = new MonsterTruck();

var rider = new Rider<Car>();
rider.StartEngine(lada);

//var newCOns4 = new NewConstraint<ComplexClass>();

//var fkv = new FancyKeyValue<int, DateTime>(); 
class Korobka<TKey>
{
    private TKey item;


    public void Put(TKey whatToPut)
    {
        item = whatToPut;
    }

    public void PrintMe<KFancyType>(KFancyType o)
    {
        Console.WriteLine($"My type is '{o.GetType()}' and values is '{o}'");
    }

    public TKey Pop()
    {
        var f = item;
        //item = (T?)null;
        return f;
    }
}

public class MyCollection<T>
{
    public T[] Values { get; set; }
}

public class MyExtraCollection<T>
    : MyCollection<T>
{
    public T[] ExtraValues { get; set; }
}
public class DoubleCollection
    : MyCollection<double>
{
    public double GeomAvg()
    {
        var res = 1.0;
        var numOfValues = Values.Length;
        foreach (var v in Values)
        {
            res *= Math.Pow(v, 1.0 / numOfValues);
        }
        return res;
    }
}

class MyKeyValue<TKey, TValue>
{
    public MyKeyValue(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }
    public TKey Key { get; set; }
    public TValue Value { get; set; }

    public override string ToString()
    => $"Key={Key}, Value={Value}";
}

public static class MyDefault
{


    public static void DisplayDefault<T>(T val = default)
    {


        if (val == null || val.Equals(default(T)))
        {
            Console.WriteLine("I'm empty");
        }
        Console.WriteLine($"The value of type {typeof(T)} is: {(val == null ? "null" : val.ToString())}");
    }

}



/// <summary>
/// Ограничение с конструктором
/// </summary>
/// <typeparam name="T"></typeparam>
public class NewConstraint<T>
    where T : new()
{
    public NewConstraint()
    {
        var v = new T();
        Console.WriteLine($"Hello {v}");
    }

    public void Do<K>() where K : new()
    {
        var v = new K();
        Console.WriteLine($"DO {v}");
    }
}

class SimpleClass
{
    public int Value { get; set; }
}

class ComplexClass
{
    public ComplexClass(int value)
    {
        Value = value;
    }

    public int Value { get; set; }
}


class FancyKeyValue<K, V>
    where K : struct 
    where V : class, new()
{

}


public interface IVehicle
{
    public void Vroom();
}

public abstract class Car : IVehicle
{
    public void Vroom()
    {
        Console.WriteLine();
    }
}

public class MonsterTruck : Car
{

}

public class Rider<Tv>
    where Tv: Car
{
    public void StartEngine(Tv vehicle)
    {
        vehicle.Vroom();
    }
}

