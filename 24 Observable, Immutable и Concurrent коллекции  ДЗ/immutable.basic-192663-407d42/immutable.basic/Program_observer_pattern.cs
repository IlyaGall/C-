﻿// internal class Program
// {
//   public interface IObserver
//   {
//     void Update(string eventDetails);
//   }

//   public interface ISubject
//   {
//     void RegisterObserver(IObserver observer);
//     void RemoveObserver(IObserver observer);
//     void NotifyObservers(string eventMessage);
//   }

//   public class Visitor : IObserver
//   {
//     private readonly string _visitorName;

//     public Visitor(string visitorName)
//     {
//       _visitorName = visitorName;
//     }

//     public void Update(string eventDetails)
//     {
//       Console.WriteLine($"{_visitorName} получил сообщение: {eventDetails}");
//     }
//   }

//   public class Zoo : ISubject
//   {
//     private readonly List<IObserver> _visitors;

//     public Zoo()
//     {
//       _visitors = new List<IObserver>();
//     }

//     public void RegisterObserver(IObserver visitor)
//     {
//       _visitors.Add(visitor);
//     }

//     public void RemoveObserver(IObserver visitor)
//     {
//       _visitors.Remove(visitor);
//     }

//     public void NotifyObservers(string eventMessage)
//     {
//       foreach (var visitor in _visitors)
//       {
//         visitor.Update(eventMessage);
//       }
//     }
//   }

//   private static void Main(string[] args)
//   {
//     var a = new Visitor("alice");
//     var b = new Visitor("bob");
//     var c = new Visitor("charlie");

//     var z = new Zoo();
//     z.RegisterObserver(a);
//     z.RegisterObserver(b);

//     z.NotifyObservers("сегодня Новый год!!");

//     z.RegisterObserver(c);

//     z.NotifyObservers("go for a walk!");
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