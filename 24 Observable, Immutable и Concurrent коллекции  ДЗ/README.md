# Observable, Immutable и Concurrent коллекции

Что такое
➔ List + Observable паттерн
➔ Позволяет организовать подписку на события
изменения коллекция

## Что такое ObservableCollection
➔ List + Observable паттерн
➔ Позволяет организовать подписку на события изменения коллекция
➔ Содержит NotifyCollectionChangedEventHandler? CollectionChanged для реагирования на изменение коллекций

[ПРИМЕР ДЗ](https://github.com/IlyaGall/c_Sharp__Developer_Basic/tree/main/12%20HomeWork/HomeWork13)
```c#
internal class Program
{
    public interface IObserver
    {
        void Update(string eventDetails);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(string eventMessage);
    }

    public class Visitor : IObserver
    {
        private readonly string _visitorName;

        public Visitor(string visitorName)
        {
            _visitorName = visitorName;
        }

        public void Update(string eventDetails)
        {
            Console.WriteLine($"{_visitorName} получил сообщение: {eventDetails}");
        }
    }

    public class Zoo : ISubject
    {
        private readonly List<IObserver> _visitors;

        public Zoo()
        {
            _visitors = new List<IObserver>();
        }

        public void RegisterObserver(IObserver visitor)
        {
            _visitors.Add(visitor);
        }

        public void RemoveObserver(IObserver visitor)
        {
            _visitors.Remove(visitor);
        }

        public void NotifyObservers(string eventMessage)
        {
            foreach (var visitor in _visitors)
            {
                visitor.Update(eventMessage);
            }
        }
    }

    private static void Main(string[] args)
    {
        var a = new Visitor("alice");
        var b = new Visitor("bob");
        var c = new Visitor("charlie");

        var z = new Zoo();
        z.RegisterObserver(a);
        z.RegisterObserver(b);
        z.NotifyObservers("сегодня Новый год!!");
        z.RegisterObserver(c);
        z.NotifyObservers("go for a walk!");
    }

    static void Log<T>(IEnumerable<T> values)
    {
        Console.WriteLine($"[ {String.Join(", ", values)} ]");
    }

    static List<T> Limit<T>(List<T> s, int limit = 1)
    {
        var res = new List<T>(limit);

        for (int i = 0; i < limit && i < s.Count; i++)
            res.Add(s[i]);

        return res;
    }
}
```



## Concurrent collections

Проблема:
➔ Простая коллекция – какой поток создал коллекцию, тот ею и управляет
➔ Можно ускорить работу с коллекцией – несколько потоков
➔ Нужно организовать синхронизацию доступа к коллекции
➔ Простая коллекция – не подходит, непредсказуемое поведение

Решение
Concurrent collections

### Варианты
➔ ConcurrentDictionary
➔ ConcurrentBag
➔ ConcurrentStack
➔ ConcurrentQueue
➔ BlockingCollection

### Свойства
➔ В общем случае – медленнее не-concurrent
➔ API для защиты от «гонки потоков» (race condition)
➔ Можно безопасно перебирать элементы через foreach

[Пример дз](https://github.com/IlyaGall/c_Sharp__Developer_Basic/tree/main/12%20HomeWork/HomeWork13_2)

## Immutable collections
Синопсис
➔ «Классические» коллекции (например, List) могут меняться в одном потоке
➔ В общем случае – удобно и безопасно
➔ Но иногда коллекция несет и семантический смысл (например, состояние базы данных)
➔ Тогда использование изменяемых коллекций может повредить читаемости кода
➔ Для этого существуют Immutable (неизменяемый) интерфейс

### Варианты
➔ ImmutableStack
➔ ImmutableList
➔ ImmutableArray
➔ ImmutableDictionary