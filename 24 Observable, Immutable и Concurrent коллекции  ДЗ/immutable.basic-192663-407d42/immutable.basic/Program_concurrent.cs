// using System.Collections.Concurrent;
// using System.Collections.ObjectModel;
// using System.Collections.Specialized;

// internal class Program
// {

//   static object _s = new object();
//   static ConcurrentDictionary<string, long> _dic = new();

//   private static void Main(string[] args)
//   {
//     ConcurrentBag<int> bag = new();


//     Parallel.For(1, 10, DoWork);
//     Log(_dic);
//   }

//   static void DoWork(int threadValue)
//   {
//     for (int i = 0; i < 10; i++)
//     {
//       var playerName = GetPlayerName(threadValue);
//       _dic.AddOrUpdate(playerName, (key) => threadValue, (key, oldValue) => oldValue * key.Length);

//       // if (!_dic.ContainsKey(playerName))
//       //   _dic.Add(playerName, threadValue);
//       // else
//       //   _dic[playerName] = _dic[playerName] * 10;
//     }
//   }


//   static string GetPlayerName(int playerNumber)
//   {
//     return $" Player #{playerNumber}";
//   }

//   static void Log<T, S>(IEnumerable<KeyValuePair<T, S>> values)
//   {
//     Console.WriteLine($"[ {String.Join(", ", values.Select(x => x.Value))} ]");
//   }

//   // static void Log<T>(IEnumerable<T> values)
//   // {
//   //   Console.WriteLine($"[ {String.Join(", ", values)} ]");
//   // }

// }