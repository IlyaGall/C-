using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

internal class Program
{

  private static void Main(string[] args)
  {
    //ImmutableList<int> ints =
    var t = ImmutableList<int>.Empty.AddRange(new[] { 1, 2, 3 });

    Log(t);
    /*
        var t1 = t.Add(100);

        Log(t1);

        Log(t.Add(200));
        */

    Log(new List<int>() { 5, 7, 8 });
  }

  static void Log<T>(IList<T> values, T value = default(T))
  {
    values.Add(value);
    Console.WriteLine($"[ {String.Join(", ", values)} ]");
  }

}