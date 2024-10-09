// using System.Collections.ObjectModel;
// using System.Collections.Specialized;

// internal class Program
// {


//   private static void Main(string[] args)
//   {
//     var observableCollection = new ObservableCollection<int>();
//     observableCollection.CollectionChanged += ProcessCollectionChangedEvent;

//     for (int i = 0; i < 5; i++)
//       observableCollection.Add(i);

//     Log(observableCollection);

//     observableCollection.Remove(3);
//     Log(observableCollection);

//     observableCollection[2] = 100;
//     Log(observableCollection);

//     observableCollection.Clear();
//   }

//   private static void ProcessCollectionChangedEvent(object? sender, NotifyCollectionChangedEventArgs e)
//   {
//     switch (e.Action)
//     {
//       case NotifyCollectionChangedAction.Add:
//         Console.WriteLine($"Добавлен элемент {e.NewItems[0]}");
//         break;
//       case NotifyCollectionChangedAction.Remove:
//         Console.WriteLine($"Удален элемент {e.OldItems[0]}");
//         break;
//       case NotifyCollectionChangedAction.Reset:
//         Console.WriteLine($"cleared");
//         break;
//       case NotifyCollectionChangedAction.Replace:
//         Console.WriteLine($"Заменен элемент {e.OldItems[0]} на элемент {e.NewItems[0]}");
//         break;
//     }
//   }

//   static void Log<T>(IEnumerable<T> values)
//   {
//     Console.WriteLine($"[ {String.Join(", ", values)} ]");
//   }


//   static List<T> Limit<T>(List<T> s, int limit = 1)
//   {
//     var res = new List<T>(limit);

//     for (int i = 0; i < limit && i < s.Count; i++)
//       res.Add(s[i]);

//     return res;
//   }
// }