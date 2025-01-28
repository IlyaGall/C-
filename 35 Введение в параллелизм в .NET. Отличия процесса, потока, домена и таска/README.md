# Введение в параллелизмв .NET. Отличияпроцесса,потока, домена итаска


## Задача
Нам необходимо сделать маркетинговую рассылку пользователям в разные каналы,
сообщения для рассылки уже сформированы и сохранены в базе данных. У сообщения есть:
● Id сообщения
● Тип:
    ● Email
    ● Sms
    ● Push
● Текст сообщения
● Id пользователя, которому нужно доставить сообщение
● Дата создания сообщения

Сообщения отсортированы по возрастанию даты создания. Нужно сделать приложение, которое будет обрабатывать сообщения из БД и передаватьихдругомукомпоненту на отправку. Необходимо в чат описать общую логику работы алгоритма обработки сообщений из БД, тоестькакбывы решали эту задачу, общими словами (например, мы берем сообщения из БДи делаем...)

## Алгоритм последовательной обработки

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/1.JPG)

Какие могут быть проблемыприпростойпоследовательной обработке сообщений?

**Основная проблема:** медленная обработка, еслисообщений становится много или если они постоянно поступают
**Решение:** надо подумать, как увеличитьколичествообработчиков


### пример кода (Простой планировщик с последовательной обработкой)

```C#
 public class SimpleScheduler
     : IScheduler
 {
     
     public void ProcessQueue()
     {
         var queueHandler = QueueHandlerFactory.GetSimpleQueueHandler();
         
         var stopWatch = new Stopwatch();
         
         Console.WriteLine("Simple scheduler...");
         Console.WriteLine("Handling queue...");
         stopWatch.Start();
         
         queueHandler.Handle();
         
         stopWatch.Stop();
         
         Console.WriteLine($"Handled queue in {stopWatch.Elapsed}...");
     }
 }
 ```
## Параллелизм

Параллелизм — выполнение нескольких действийфизически одновременно в единицу времени.

### Простой параллельный вариант

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/2.JPG)

Как мы можем реализовать параллельныйвариант, чтобыобработчики не мешали друг другу?

Разбиваем очередь сообщений на три потипусообщения,делаем по обработчику на каждыйтип. Каждый забирает сообщения только своеготипаинемешает другим.

### Задача

Нам необходимо сделать маркетинговую рассылку пользователям в разные каналы,
сообщения для рассылки уже сформированы и сохранены в базе данных. У сообщения есть:
● Id сообщения
● Тип:
    * Email
    * Sms
    * Push
● Текст сообщения
● Id пользователя, которому нужно доставить сообщение
● Дата создания сообщения
Сообщения отсортированы по возрастанию даты создания. Нужно сделать приложение, которое будет обрабатывать сообщения из БД параллельнообработчиками на каждый тип и передавать их другому компоненту на отправку.

### Более параллельный вариант

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/3.JPG)


## Программные средства параллелизма

### Основные понятия и их уровни

* **Процесс (Process)** — объект ОС, контейнер для кода, имеет изолированноеадресное пространство в памяти, содержит потоки. 

* **Поток (Thread)** — объект ОС, наименьшая единица выполнениякода, частьпроцесса, потоки делят память и другие ресурсы между собойврамкахпроцесса. 

* **Многозадачность** — свойство ОС, возможность выполнятьнесколькопроцессов почти одновременно

* **Домен приложения (App Domain)** - объект .NET, нужен для изоляцииразногокода в одном процессе, аналогия процесса

### Основные понятия и их уровни

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/4.JPG)

## Процессыидомены

### Процессы (Что такое процесс?)

Процесс — это выполняемая в ОС программаивсе, что ей необходимо для исполнения. 

Процесс не имеет доступа к памятидругогопроцесса - это механизмизоляциипроцессов.

За обеспечение изоляции и за управлениепроцессами отвечает ОС

### Зачем нужна изоляция процессов?

Чтобы один процесс не получил доступ к конфиденциальнойинформации в памяти другого процесса илинеповредилданные.

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/5.JPG)

### Что содержит процесс?

В Windows процесс включает в себя:

1. Закрытое виртуальное адресное пространство памяти, нужнодляизоляции.2. Исполняемая программа, то есть машинный код
2. Исполняемая программа, то есть машинный код
3. Список открытых дескрипторов для I/O Streams (сеть, диски) - нужен, чтобы ОС могла закрыть порты ввода/вывода. 4. Маркер доступа для пользователя или группы - для уровней доступа процесса
4. Маркер доступа для пользователя или группы - для уровней доступа процесса
5. Id процесса
6. Как минимум один главный поток исполнения - в немвыполняетсякод.

### Процесс в .NET

Процессы с .NET кодом - это обычные процессы ОС, но в их памятьсначалазагружается CLR, которая и выполняет IL код.

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/6.JPG)

Задача
Нам необходимо сделать маркетинговую рассылку пользователям в разные каналы,
сообщения для рассылки уже сформированы и сохранены в базе данных. У сообщения есть:
● Id сообщения
● Тип:
    * Email
    * Sms
    * Push
● Текст сообщения
● Id пользователя, которому нужно доставить сообщение
● Дата создания сообщения
Сообщения отсортированы по возрастанию даты создания. 

Нужно сделать приложение, которое будет обрабатывать сообщения из БД параллельнообработчиками на каждый тип и передавать их другому компоненту на отправку.


```c#
  public class ProcessesScheduler
      : IScheduler
  {
      private const string HandlerProcessFileName = "Otus.Teaching.Concurrency.Queue.Handler.Process.exe";
      private const string HandlerProcessDirectory = @"C:\GitProjects\otus.teaching.concurrency.queue\Otus.Teaching.Concurrency.Queue.Handler.Process\publish";
      readonly List<Process> _queueHandlerProcesses = new List<Process>();

      public void ProcessQueue()
      {
          var stopWatch = new Stopwatch();
          
          Console.WriteLine("Process scheduler...");
          Console.WriteLine("Handling queue...");
          stopWatch.Start();

          _queueHandlerProcesses.Add(StartHandlerProcess(MessageQueueItemType.Email));
          _queueHandlerProcesses.Add(StartHandlerProcess(MessageQueueItemType.Sms));
          _queueHandlerProcesses.Add(StartHandlerProcess(MessageQueueItemType.Push));
          
          _queueHandlerProcesses.ForEach(x => x.WaitForExit());
          
          stopWatch.Stop();
          
          Console.WriteLine($"Handled queue in {stopWatch.Elapsed}...");
      }

      private Process StartHandlerProcess(MessageQueueItemType type)
      {
          var startInfo = new ProcessStartInfo()
          {
              ArgumentList = {type.ToString()},
              FileName = GetPathToHandlerProcess(),
          };
          
          var process = Process.Start(startInfo);

          return process;
      }

      private string GetPathToHandlerProcess()
      {
          return Path.Combine(HandlerProcessDirectory, HandlerProcessFileName);
      }
  }
```

Какие есть проблемы в решении задачи напроцессах?

Плюсы:
1. Независимость обработчиков;
2. Можно независимо увеличивать число обработчиковдлятипавнутри одного процесса (через потоки);
Минусы:
1. Сложность управления процессами;
2. Порождение процессов является трудоемкой операцией, таккакэто функция ядра ОС;
3. Если умрет процесс-планировщик, то процессы-обработчикимогут остаться работать дальше или их никто не запуститснова;

### Пример для создания процесса

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/7.JPG)

## Домены приложений

### Что такое домен приложения?

1. Единица изоляции программногокодав.NETFramework
2. Аналогия процесса ОС
3. Контейнер для загрузки сборок .NET в память процесса. 
4. Процесс может в своей памяти содержать несколько доменов/приложений

### Домены приложений в процессе .NET Framework

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/8.JPG)

[ссылка](https://www.codeproject.com/Articles/808838/NET-Application-Boot-Strapping)

### Домены приложений в процессе .NET Core

1. AppDomain оставлен для обратной совместимостиинебудет поддерживаться;
2. Не обеспечивает изоляцию. Загрузка/выгрузкасбороксделана через класс AssemblyLoadContext;
3. По умолчанию при старте создается одинAppDomain,новые создавать нельзя;
4. Изоляция за счет создания отдельных процессов, анедоменов;

[ссылка](https://learn.microsoft.com/ru-ru/dotnet/core/porting/net-framework-tech-unavailable)

### Использование доменов в .NET Framework

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/9.JPG)

[link](https://www.codeproject.com/Articles/121096/Web-Server-and-ASP-NET-Application-Life-Cycle-in-D)

### Потоки

Поток - это механизм операционной системы, который позволяет выполнять на одном процессоре почти одновременно несколько задач,за счет того, что каждой задаче выдается небольшой промежуток времени, также он имеет доступ ко всем ресурсам процесса.

Для многоядерных систем можно говорить о полностьюпараллельномисполнении.

Процессор не знает про потоки, он просто выполняет какой-томашинный код, это инструмент ОС.

### Поток в .NET

Потоки в .NET - это обычные потоки ОС, объект Thread хранит общую информацию осозданномв ОС потоке выполнения

Иногда .NET потоки называют управляемыми (Managed), но на самом деле Thread это объект для лучшего контроля за приложением для CLR. CLR хранит ссылки на все потоки приложения.

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/10.JPG)

### Приоритеты потоков

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/11.JPG)

### Кванты времени для потоков

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/12.JPG)

Увеличение числа потоков ведет к уменьшению квантов ивитоге к тому, что они будут ждать ядра, то есть увеличение числа потоков не значит увеличение производительности

```c#
 public class ThreadsScheduler
     : IScheduler
 {
     private readonly List<Thread> _queueHandlerThreads = new List<Thread>();

     public void ProcessQueue()
     {
         var stopWatch = new Stopwatch();
         
         Console.WriteLine($"Thread scheduler in thread: {Thread.CurrentThread.ManagedThreadId}...");
         Console.WriteLine("Handling queue...");
         stopWatch.Start();
         
         _queueHandlerThreads.Add(StartHandlerThread(MessageQueueItemType.Email));
         _queueHandlerThreads.Add(StartHandlerThread(MessageQueueItemType.Sms));
         _queueHandlerThreads.Add(StartHandlerThread(MessageQueueItemType.Push));
         
         stopWatch.Stop();
         
         Console.WriteLine($"Handled queue in {stopWatch.Elapsed}...");
     }

     private Thread StartHandlerThread(MessageQueueItemType type)
     {
         var handler = QueueHandlerFactory.GetTypeQueueHandler(type);

         var thread = new Thread(handler.Handle);

         thread.Start();

         return thread;
     }
 }
```

Нам необходимо сделать маркетинговую рассылку пользователям в разные каналы,
сообщения для рассылки уже сформированы и сохранены в базе данных. У сообщения есть:

● Id сообщения
● Тип:
    * Email
    * Sms
    * Push
● Текст сообщения
● Id пользователя, которому нужно доставить сообщение
● Дата создания сообщения
Сообщения отсортированы по возрастанию даты создания. Нужно сделать приложение, которое будет обрабатывать сообщения из БД параллельнообработчиками на каждый тип и передавать их другому компоненту на отправку.

## Какие есть плюсы и минусы в решении задачинапотоках?

Плюсы:
1. Удобство управления потоками;
2. Можно сделать динамическое увеличение числа потоков, еслибырешили проблему конкуренции;
3. Более оптимальный вариант;
Минусы:
1. В случае с процессами у нас полная изоляция по памяти;
2. Если умирает процесс, то обработка не закончится, номыможемее просто перезапустить.

### Основной поток и фоновые потоки

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/13.JPG)


### Как упростить создание потоков?

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/14.JPG)


### Пул потоков

1. Реализован классом ThreadPool;
2. Хранит набор изначально созданных для процесса потоков;
3. Все потоки фоновые;
4. Подходит для небольших вычислительных задач и участвуетвдругомважном механизме;
5. После обработки задачи поток возвращается в пул;
6. Может создавать новые потоки, если нужно;

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/15.JPG)

```c#
  class ThreadPoolScheduler
      : IScheduler
  {
      private readonly Dictionary<MessageQueueItemType,ThreadPoolSchedulerItem> _threadPoolSchedulerItems = 
          new Dictionary<MessageQueueItemType, ThreadPoolSchedulerItem> 
      {
          {MessageQueueItemType.Email, new ThreadPoolSchedulerItem(MessageQueueItemType.Email)},
          {MessageQueueItemType.Sms, new ThreadPoolSchedulerItem(MessageQueueItemType.Sms)},
          {MessageQueueItemType.Push, new ThreadPoolSchedulerItem(MessageQueueItemType.Push)},
      };
      
      public void ProcessQueue()
      {
          var stopWatch = new Stopwatch();

          Console.WriteLine($"Thread pool scheduler in thread: {Thread.CurrentThread.ManagedThreadId}...");
          Console.WriteLine("Handling queue...");
          stopWatch.Start();

          ThreadPool.QueueUserWorkItem(HandleInThreadPool, _threadPoolSchedulerItems[MessageQueueItemType.Email]);
          ThreadPool.QueueUserWorkItem(HandleInThreadPool, _threadPoolSchedulerItems[MessageQueueItemType.Sms]);
          ThreadPool.QueueUserWorkItem(HandleInThreadPool, _threadPoolSchedulerItems[MessageQueueItemType.Push]);

          WaitHandle[] waitHandles = _threadPoolSchedulerItems.Values.Select(x => x.WaitHandle).ToArray();
          
          WaitHandle.WaitAll(waitHandles);
          
          stopWatch.Stop();

          Console.WriteLine($"Handled queue in {stopWatch.Elapsed}...");
      }
      
      private void HandleInThreadPool(object item)
      {
          var schedulerItem = (ThreadPoolSchedulerItem) item;
          var handler = QueueHandlerFactory.GetTypeQueueHandler(schedulerItem.Type);
          
          handler.Handle();

          var autoResetEvent = (AutoResetEvent) schedulerItem.WaitHandle;
          
          autoResetEvent.Set();
      }
  }
```

Как вы считаете потоки в наших приложениях больше работают или больше ждут?

### Потоки в CPU-операциях и в I/Oоперациях

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/16.JPG)

## Синхронность и асинхронность

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/17.JPG)


### Как объединили асинхронностьимногопоточность в C#?

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/18.JPG)

## Task

Task - универсальная абстракция для выполнения кода в любомколичестве потоков, в синхронном или асинхронномрежиме

Особенности
1. По умолчанию Task выполняется в потоке из пула, гораздо легче, чем работать с ним напрямую;
2. Представляет собой объект-задачу, которая имеет статусы выполнения и позволяет сделать абстракцию над потоками, задачами управлять удобнееи проще, чем потоками;
3. В сочетании с async/await дает удобный доступ к асинхроннымоперациям,которые не блокируют вызывающий поток;

### Как выглядит использование Task?

![img](https://github.com/IlyaGall/C-/blob/main/35%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%BF%D0%B0%D1%80%D0%B0%D0%BB%D0%BB%D0%B5%D0%BB%D0%B8%D0%B7%D0%BC%20%D0%B2%20.NET.%20%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BF%D1%80%D0%BE%D1%86%D0%B5%D1%81%D1%81%D0%B0%2C%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0%2C%20%D0%B4%D0%BE%D0%BC%D0%B5%D0%BD%D0%B0%20%D0%B8%20%D1%82%D0%B0%D1%81%D0%BA%D0%B0/IMG/19.JPG)

Нам необходимо сделать маркетинговую рассылку пользователям в разные каналы,
сообщения для рассылки уже сформированы и сохранены в базе данных. У сообщения есть:
● Id сообщения
● Тип:
    * Email
    * Sms
    * Push
● Текст сообщения
● Id пользователя, которому нужно доставить сообщение
● Дата создания сообщения
Сообщения отсортированы по возрастанию даты создания. Нужно сделать приложение, которое будет обрабатывать сообщения из БД параллельнообработчиками на каждый тип и передавать их другому компоненту на отправку.


```c#
 public class TasksScheduler
     : IScheduler
 {
     private readonly List<TaskSchedulerItem> _queueHandlerTasks = new List<TaskSchedulerItem>();
     private readonly int _retryCount = 3;

     public void ProcessQueue()
     {
         var stopWatch = new Stopwatch();
         
         Console.WriteLine("Task scheduler...");
         Console.WriteLine("Handling queue...");
         stopWatch.Start();

         StartAsTasks();

         stopWatch.Stop();
         
         Console.WriteLine($"Handled queue in {stopWatch.Elapsed}...");
     }

     private void StartAsTasks()
     {
         var emailTask = new TaskSchedulerItem(MessageQueueItemType.Email);
         var smsTask = new TaskSchedulerItem(MessageQueueItemType.Sms);
         var pushTask = new TaskSchedulerItem(MessageQueueItemType.Push);
         
         _queueHandlerTasks.Add(emailTask);
         _queueHandlerTasks.Add(smsTask);
         _queueHandlerTasks.Add(pushTask);
         
         _queueHandlerTasks.ForEach(StartHandlerTask);
         
         WaitAllTasksWithRetry();
     }

     private void WaitAllTasksWithRetry()
     {
         try
         {
             var tasksForWait = GetTasksForWait();
             Task.WaitAll(tasksForWait);
         }
         catch (Exception)
         {
             RetryFaultTasks();
             WaitAllTasksWithRetry();
         }
     }

     private Task[] GetTasksForWait()
     {
         return _queueHandlerTasks
             .Where(x => x.RetryCount <= _retryCount)
             .Select(x => x.Task)
             .ToArray();
     }

     private void RetryFaultTasks()
     {
         _queueHandlerTasks
             .Where(t => t.Task.IsFaulted)
             .ToList()
             .ForEach(RetryHandle);
     }

     private void StartHandlerTask(TaskSchedulerItem item)
     {
         var handler = QueueHandlerFactory.GetTypeQueueHandler(item.Type);
         item.Task = Task.Run(() => handler.Handle());
         item.RetryCount += 1;
     }

     private void RetryHandle(TaskSchedulerItem item)
     {
         Console.WriteLine($"Пытаемся заново запустить обработчик {item.Type}, так как произошла ошибка: {item.Task?.Exception}");
         if (item.RetryCount <= _retryCount)
         {
             StartHandlerTask(item);
         }
     }
 }
```

Плюсы:
1. Удобство управления тасками еще выше, чемпотоками;
2. Если использовать асинхронность, то не будет лишнихблокировок;
3. Не создаем потоки в ОС;
Минусы:
1. В случае с процессами у нас полная изоляция по памяти;
2. Если умирает процесс, то обработка не закончится, номыможемее просто перезапустить. 3. Если не используем асинхронность, то поток пула можетбытьзаблокирован очень долго, это не критично в этой задаче, нонужно учитывать, если много потоков.