# Взаимодействие потоков

➔ Monitor
➔ CountdownEvent
➔ Barrier
➔ AutoResetEvent
➔ ManualResetEvent
➔ ManualResetEventSlim

## Monitor


## Процессы, потоки, синхронизация

Процессы, потоки , разделяемые ресурсы

![img](https://github.com/IlyaGall/C-/blob/main/39%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D0%B5%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%BE%D0%B2/IMG/1.JPG)

```c#
var _now = DateTime.Now;

object _lock = new object();
Thread t1 = new Thread(T1);
t1.Start();

Thread.Sleep(50);
Thread t2 = new Thread(T2);
t2.Start();

Thread.Sleep(50);
Thread t3 = new Thread(T3);
t3.Start();


Thread.Sleep(50);
Thread t4 = new Thread(T4);
t4.Start();


void T1()
{
    Log("T1");
    lock (_lock)
    {
        Log("T1 entered");
        Thread.Sleep(1000);
        Log("T1 wait");
        Monitor.Wait(_lock);
        Log("T1 after wait");
    }
    Log("T1 left");
}

void T3()
{
    Log("T3");
    lock (_lock)
    {
        Log("T3 entered");
        Thread.Sleep(1000);
        Log("T3 wait");
        Monitor.Wait(_lock);
        Log("T3 after wait");
    }
    Log("T3 left");
}

void T4()
{
    Log("T4");
    lock (_lock)
    {
        Log("T4 entered");
        Thread.Sleep(1000);
        Log("T4 pulse");
        Monitor.PulseAll(_lock);
        Log("T4 after pulse");
    }
    Log("T4 left");
}


void T2()
{
    Log("T2");
    lock (_lock)
    {
        Log("T2 entered");
        Thread.Sleep(1000);
        Log("T2 pulse");
        Monitor.PulseAll(_lock);
        Log("T2 after pulse");
    }
    Log("T2 left");
}


void Log(string msg)
{
    Console.WriteLine($"{(DateTime.Now - _now).TotalMilliseconds}\t[{Environment.CurrentManagedThreadId}] | {msg}");
}
```

### CountdownEvent

![img](https://github.com/IlyaGall/C-/blob/main/39%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D0%B5%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%BE%D0%B2/IMG/2.JPG)

```c#
var _now = DateTime.Now;

CountdownEvent countObject = new CountdownEvent(1);
var elementsCount = 10;
int[] input = Enumerable.Range(0, elementsCount).ToArray();
int[] result = new int[elementsCount];

for (int i = 0; i < elementsCount; ++i)
{
    countObject.AddCount();
    int j = i;
    Task.Factory.StartNew(() =>
    {
        Thread.Sleep(20 * j); // Имитируем вычисления
        result[j] = j * 59 - 16 + 42;

        countObject.Signal();

        Log($"[{j}]: {String.Join(" ", result)}");
    });
}

countObject.Signal();
Log("wait");
countObject.Wait();
Log($"{String.Join(" ", result)}");

void Log(string msg)
{
    Console.WriteLine($"{(DateTime.Now - _now).TotalMilliseconds}\t[{Environment.CurrentManagedThreadId}] | {msg}");
}
```

### Barrier

![img](https://github.com/IlyaGall/C-/blob/main/39%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D0%B5%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%BE%D0%B2/IMG/3.JPG)

![img](https://github.com/IlyaGall/C-/blob/main/39%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D0%B5%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%BE%D0%B2/IMG/4.JPG)

```c#
var _now = DateTime.Now;

Barrier bar;
int numberOfWorkers = 10;

bar = new Barrier(numberOfWorkers, AnnounceEndOfPhase);
Parallel.For(0, numberOfWorkers, DoWork);

void DoWork(int id)
{
    Thread.Sleep(new Random().Next(50, 100));
    Log($"[Фаза {bar.CurrentPhaseNumber}] Часть данных №{id} успешно скачана");
    bar.SignalAndWait();
    Thread.Sleep(new Random().Next(50, 100));
    Log($"[Фаза {bar.CurrentPhaseNumber}] Обучение на данных №{id} завершено");
    bar.SignalAndWait();
    Thread.Sleep(new Random().Next(50, 100));
    Log($"[Фаза {bar.CurrentPhaseNumber}] Серия тестов №{id} прошла успешно");
    bar.SignalAndWait();
}

void AnnounceEndOfPhase(Barrier barrier)
{
    switch (barrier.CurrentPhaseNumber)
    {
        case 0:
            Log("Скачивание всех частей завершено. Можно отключать интернет.");
            Log("");
            break;
        case 1:
            Log("Обучение нейронной сети завершено. Подготавливаем тестирующие выборки.");
            Log("");
            break;
        case 2:
            Log("Тестирование завершено успешно. Искусственный интеллект готов к мировому господству! =)");
            Log("");
            break;
    }
}


void Log(string msg)
{
    Console.WriteLine($"{(DateTime.Now - _now).TotalMilliseconds}\t[{Environment.CurrentManagedThreadId}] | {msg}");
}
```

### AutoResetEvent

— примитив синхронизации, автоматически блокирующий движение следующих потоков после пропуска одного, находившегося в состоянии ожидания

![img](https://github.com/IlyaGall/C-/blob/main/39%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D0%B5%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%BE%D0%B2/IMG/5.JPG)

```C#
var _now = DateTime.Now;

AutoResetEvent autoResetEvent = new AutoResetEvent(true);

Parallel.For(0, 10, DoWork);

// Программа для запоминания 10 слов
void DoWork(int id)
{
    Log($"Поток {id} генерируем звучание слова");
    Thread.Sleep(new Random().Next(500, 1000)); // Генерируем звучание
    autoResetEvent.WaitOne();
    Log($"[{id}] Воспроизводим звук");
    Thread.Sleep(new Random().Next(200, 500)); // Воспроизводим звук
    autoResetEvent.Set();
    Log("set");
}

void Log(string msg)
{
    Console.WriteLine($"{(DateTime.Now - _now).TotalMilliseconds}\t[{Environment.CurrentManagedThreadId}] | {msg}");
}
```

### ManualResetEvent

— примитив синхронизации, разрешающий движение всех ожидающих потоков после его “открытия”.  Движение запрещается только после закрытия вручную.

![img](https://github.com/IlyaGall/C-/blob/main/39%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D0%B5%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%BE%D0%B2/IMG/6.JPG)

```C#
var _now = DateTime.Now;

ManualResetEvent manualResetEvent = new ManualResetEvent(true);

var _ = Task.Run(async () =>
{
    await Task.Delay(600);
    //manualResetEvent.Set();
});

Parallel.For(0, 10, DoWork);

// Программа для запоминания 10 слов
void DoWork(int id)
{
    Log($"Поток {id} генерируем звучание слова");
    Thread.Sleep(new Random().Next(500, 1000)); // Генерируем звучание
    manualResetEvent.WaitOne();
    Log($"[{id}] Воспроизводим звук");
    Thread.Sleep(new Random().Next(200, 500)); // Воспроизводим звук
    manualResetEvent.Set();
    Log("set");
    manualResetEvent.Reset();
}

void Log(string msg)
{
    Console.WriteLine($"{(DateTime.Now - _now).TotalMilliseconds}\t[{Environment.CurrentManagedThreadId}] | {msg}");
}
```

### ManualResetEventSlim

## Дополнительные инструменты

➔ Interlocked
➔ Volatile

### Interlocked example

![img](https://github.com/IlyaGall/C-/blob/main/39%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D0%B5%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%BE%D0%B2/IMG/7.JPG)

### Volatile example

![img](https://github.com/IlyaGall/C-/blob/main/39%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D0%B5%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%BE%D0%B2/IMG/8.JPG)

programm

```c#
var _now = DateTime.Now;

ManualResetEvent manualResetEvent = new ManualResetEvent(true);

var _ = Task.Run(async () =>
{
    await Task.Delay(600);
    //manualResetEvent.Set();
});

Parallel.For(0, 10, DoWork);

// Программа для запоминания 10 слов
void DoWork(int id)
{
    Log($"Поток {id} генерируем звучание слова");
    Thread.Sleep(new Random().Next(500, 1000)); // Генерируем звучание
    manualResetEvent.WaitOne();
    Log($"[{id}] Воспроизводим звук");
    Thread.Sleep(new Random().Next(200, 500)); // Воспроизводим звук
    manualResetEvent.Set();
    Log("set");
    manualResetEvent.Reset();
}

void Log(string msg)
{
    Console.WriteLine($"{(DateTime.Now - _now).TotalMilliseconds}\t[{Environment.CurrentManagedThreadId}] | {msg}");
}
```