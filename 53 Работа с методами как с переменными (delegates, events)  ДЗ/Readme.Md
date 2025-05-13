# Работа с методами как с переменными (delegates, events)
## Что такое делегат?

Делегат это тип, который определяет сигнатуру используемой функции
Похож на указатель на функцию из C++

## Для чего нужны делегаты?

### Объявление делегата

![img](https://github.com/IlyaGall/C-/blob/main/53%20%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BC%D0%B5%D1%82%D0%BE%D0%B4%D0%B0%D0%BC%D0%B8%20%D0%BA%D0%B0%D0%BA%20%D1%81%20%D0%BF%D0%B5%D1%80%D0%B5%D0%BC%D0%B5%D0%BD%D0%BD%D1%8B%D0%BC%D0%B8%20(delegates%2C%20events)%20%20%D0%94%D0%97/img/1.JPG)

### Делегат не привязан к классу


Как и любой другой тип его можно объявить внутри namespace:
```C#
namespace X
{
    ▪class
    ▪struct
    ▪interface
    ⮚delegate
    ▪enum
}
```

### Создание экземпляра делегата
```c#
public void TimerCallbackHandler(object? state)
{
     Console. WriteLine("x"); 
}
async Task Main(string[] args) 
{
    TimerCallback timerCallback = TimerCallbackHandler;
}
```

### Передача делегата в качестве аргумента

```C#
public sealed class Timer : MarshalByRefObject, IAsyncDisposable, IDisposable
{
     public Timer(TimerCallback callback); 
     public Timer(TimerCallback callback, object? state, int dueTime, int period);
     public Timer(TimerCallback callback, object? state, long dueTime, long period); 
     public Timer(TimerCallback callback, object? state, TimeSpan dueTime, TimeSpan period); 
     public Timer(TimerCallback callback, object? state, uint dueTime, uint period);
}
```


![img](https://github.com/IlyaGall/C-/blob/main/53%20%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BC%D0%B5%D1%82%D0%BE%D0%B4%D0%B0%D0%BC%D0%B8%20%D0%BA%D0%B0%D0%BA%20%D1%81%20%D0%BF%D0%B5%D1%80%D0%B5%D0%BC%D0%B5%D0%BD%D0%BD%D1%8B%D0%BC%D0%B8%20(delegates%2C%20events)%20%20%D0%94%D0%97/img/2.JPG)

### Делегаты и методы

Могут принимать любые методы с подходящей сигнатурой (static)

```C#
public static void TimerCallbackHandler(object? state)
{

}
public static void AnotherCallbackHandler(object? state)
{

}
static async Task Main(string[] args) 
{
    TimerCallback timerCallback1 = TimerCallbackHandler; 
    TimerCallback timerCallback2 = AnotherCallbackHandler;
}
```
Могут принимать любые методы с подходящей сигнатурой (instance)

```C#
public void TimerCallbackHandler(object? state)
{
     Console. WriteLine("x");
}
public void AnotherCallbackHandler(object? state) 
{
    Console. WriteLine("y");
}

async Task Main(string[] args) 
{
    TimerCallback timerCallback1 = TimerCallbackHandler; 
    TimerCallback timerCallback2 = AnotherCallbackHandler;
}
```

### Во что компилируется делегат?

Все делегаты, которые мы объявляем наследуют
System.MulitcastDelegate -> System.Delegate.

![img](https://github.com/IlyaGall/C-/blob/main/53%20%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BC%D0%B5%D1%82%D0%BE%D0%B4%D0%B0%D0%BC%D0%B8%20%D0%BA%D0%B0%D0%BA%20%D1%81%20%D0%BF%D0%B5%D1%80%D0%B5%D0%BC%D0%B5%D0%BD%D0%BD%D1%8B%D0%BC%D0%B8%20(delegates%2C%20events)%20%20%D0%94%D0%97/img/3.JPG)

## Вызов делегата

Вызов делегата как метода и через Invoke – одно и тоже


```C#
static async Task Main(string[] args) 
{
    TimerCallback timerCallback = TimerCallbackHandler; 
    timerCallback(new object()); 
    timerCallback.Invoke(new object());
}
```

### System.Delegate

![img](https://github.com/IlyaGall/C-/blob/main/53%20%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BC%D0%B5%D1%82%D0%BE%D0%B4%D0%B0%D0%BC%D0%B8%20%D0%BA%D0%B0%D0%BA%20%D1%81%20%D0%BF%D0%B5%D1%80%D0%B5%D0%BC%D0%B5%D0%BD%D0%BD%D1%8B%D0%BC%D0%B8%20(delegates%2C%20events)%20%20%D0%94%D0%97/img/4.JPG)

### InvokationList

● Любой делегат, может содержать в себе ссылки на другие делегаты такого же типа
● Все эти ссылки содержаться в InvokationList
● При вызове делегата они вызываются в порядке добавления


### Арифметика делегатов


```C#
async Task Main(string[] args) 
{
    TimerCallback timerCallback1 = TimerCallbackHandler; 
    TimerCallback timerCallback2 = AnotherCallbackHandler; 
    TimerCallback timerCallback3 = timerCallback1 + timerCallback2;
    timerCallback3 = timerCallback3 - timerCallback25;
}
```

Операторы «+» и «–» у делегатов:
● Это сложение и вычитание множеств
● В качестве множеств выступают InvokationList’ы делегатов

Чаще всего используют операторы += и -= с одним делегатом в правой части

```C#
static async Task Main(string[] args)
{
    TimerCallback timerCallback = TimerCallbackHandler; 
    timerCallback += AnotherCallbackHandler;
    timerCallback -= = TimerCallbackHandler;
}
```

### Готовые generic делегаты в .NET

public delegate void Action();
public delegate void Action<in T>(T obj);
public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);
...
public delegate TResult Func<out TResult>();
public delegate TResult Func<in T1, out TResult>(T obj);
...
delegate bool Predicate<in T>(T obj);

● Делегат компилируется в специальный класс-наследник System.MulticastDelegate
● += и -= это добавление/удаление делегата в список вызовов

## Что такое события?

Событие (event) — это специальный член класса/интерфейса/структуры (как, например property) , с помощью которого они предоставляют уведомления.

![img](https://github.com/IlyaGall/C-/blob/main/53%20%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BC%D0%B5%D1%82%D0%BE%D0%B4%D0%B0%D0%BC%D0%B8%20%D0%BA%D0%B0%D0%BA%20%D1%81%20%D0%BF%D0%B5%D1%80%D0%B5%D0%BC%D0%B5%D0%BD%D0%BD%D1%8B%D0%BC%D0%B8%20(delegates%2C%20events)%20%20%D0%94%D0%97/img/5.JPG)

## Объявление события

```C#
public event Action SomeActionHappened; // простая форма

// развёртную форма:
private Action _someActionHappened; 
public event Action SomeActionHappened
{
    add
    {// подписка на событие
         _someActionHappened + = value; 
    }
    remove
    {// отписка от события
         _someActionHappened -= value;
    }
} 

```
## Подписка и отписка на событие

```C#
private static void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
{
     Console. WriteLine("tick");
}
static async Task Main(string[] args) 
{
    System.Timers.Timer timer = new System.Timers.Timer(); 
    // Подписались 
    timer. Elapsed += OnTimerElapsed;// Проваливаемся в секцию add
    // ...
    // Отписались 
     timer. Elapsed - = OnTimerElapsed; // Проваливаемся в секцию remove
}
```
## Вопрос на собеседовании: в чем отличие события от делегата?

● Событие – это член класса/интерфейса/структуры, а делегат это отдельный тип
● Событию нельзя присвоить другой делегат, доступны только операторы
+= и -= (подписка и отписка) через add и remove
● Событие нельзя вызвать вне его владельца (класса или структуры)
● Делегат можно передавать по ссылке в метод, а событие - нет
● Во время выполнения программы никакой разницы между простыми
событиями и ссылками на делегат нет

### Событие в System.Timers.Timer

Событие срабатывания таймера

![img](https://github.com/IlyaGall/C-/blob/main/53%20%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BC%D0%B5%D1%82%D0%BE%D0%B4%D0%B0%D0%BC%D0%B8%20%D0%BA%D0%B0%D0%BA%20%D1%81%20%D0%BF%D0%B5%D1%80%D0%B5%D0%BC%D0%B5%D0%BD%D0%BD%D1%8B%D0%BC%D0%B8%20(delegates%2C%20events)%20%20%D0%94%D0%97/img/6.JPG)

### События в System.IO.FileSystemWatcher

![img](https://github.com/IlyaGall/C-/blob/main/53%20%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BC%D0%B5%D1%82%D0%BE%D0%B4%D0%B0%D0%BC%D0%B8%20%D0%BA%D0%B0%D0%BA%20%D1%81%20%D0%BF%D0%B5%D1%80%D0%B5%D0%BC%D0%B5%D0%BD%D0%BD%D1%8B%D0%BC%D0%B8%20(delegates%2C%20events)%20%20%D0%94%D0%97/img/7.JPG)

### Принятый стандарт делегатов событий в .NET


● Делегат события обычно заканчивается на слово EventHandler (исключение Blazor)
● Делегат события не возвращает никаких значений
● Делегат события обычно имеет 2 аргумента object и наследник

EventArgs:

```c#
public delegate void FileSystemEventHandler(object sender, FileSystemEventArgs e);
```

● Делегат чаще используют в качестве параметра метода или конструктора и когда нужно иметь возвращаемое значение
● Событие используют для того, чтобы дать возможность подписки на уведомления конкретного объекта

### Не забывайте отписываться от событий

● Источник событий хранит ссылку на подписчика
● Каким образом?
● Если источник событий живет дольше, чем подписчик, то отсутствие отписки может привести к утечки памяти!

```C# timer. Elapsed -= OnTimerElapsed;```












