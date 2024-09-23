##Что такое делегат?

Делегат это тип, который определяет сигнатуру используемой функции. Похож на указатель на функцию из C++.




* Объект, ссылающийся на метод(ы)*
* Ссылка позволяет вызвать метод, абстрагируясь от конкретики
* Делегат может быть объявлен вне класса
* По-сути, делегат это подсказка о том, какая сигнатура (типы и
количество параметров, тип возвращаемого значения) ожидается



Объявление:
```delegate int Operation (int i, int j);```
Использование:
```void MyFunc(int a, int b, Operation op);```

## Events

Шаблон проектирования или паттерн (англ. design pattern):

повторяемая архитектурная конструкция, представляющая собой решение проблемы проектирования в рамках некоторого часто возникающего контекста.

Поведенческие, структурные, порождающие.


### пример events

```c#
using System.Runtime.CompilerServices;
var caclulator = new Calculator();
var list = new List<int>() { 1,2,3};
var res1 =  list.Where(x => x > 2).ToList();
//caclulator.Operation(2,2, (a,b) =>  a + b );
//caclulator.Operation(2, 2, CustomOperation);

CalculatorDelegate handler = caclulator.GetHandler('+');
CalculatorDelegate handler2 = caclulator.GetHandler('-');
CalculatorDelegate handler3 = caclulator.GetHandler('*');

var res = caclulator.Operation(2, 2, handler);
Console.WriteLine(res);
var res2 = caclulator.Operation(3, 2, handler2);
Console.WriteLine(res2);
var res3 = caclulator.Operation(3, 2, handler3);
Console.WriteLine(res3);


int CustomOperation (int a, int b)
{
    return a + b;
}

public delegate int CalculatorDelegate(int i, int j);

public class Calculator : ICalculator
{
    public int Operation(int a, int b, CalculatorDelegate hadler)
    {
        int result = hadler(a, b);
        Console.WriteLine($"Operation result hendler ({a},{b}) = {result}");
        return result;
    }

    public CalculatorDelegate GetHandler(char operation)
    {
        switch (operation)
        {
            case '+':
                return (int a, int b) => { return a + b; };
                break;
            case '-':
                return (int a, int b) => { return a - b; };
                break;

            default:
                return (int a, int b) => 
                {
                    Console.WriteLine("Operation not found!");
                    return 0; 
                };
                break;

            //default:
            //    return GetDefaultHandler; 
            //    break;
        }
    }

    private int GetDefaultHandler(int a, int b)
    {
        return (a + b);
    }

}

interface ICalculator
{
    int Operation(int a, int b, CalculatorDelegate hadler);
}
```

### второй пример

```C#
namespace ConsoleApp2
{
    internal class Program
    {
        public delegate void SimpleDelegate(string message);

        static void Main(string[] args)
        {
            SimpleDelegate del = DisplayMessage;

            del += DisplayUpperMessage;

            del -= DisplayMessage;


            foreach (Delegate d in del.GetInvocationList())
            {
                Console.WriteLine(d.Method.Name);
            }


            del("Hello ");

            del.Invoke("world!");


            void DisplayMessage(string message) 
            { 
                Console.WriteLine (message);            
            }

            void DisplayUpperMessage(string message)
            {
                Console.WriteLine(message.ToUpper());
            }
        }
    }
}
```


### третий пример

```C#
﻿namespace ConsoleApp3
{
    class Program
    {
        private static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            Subscriber subscriber1 = new Subscriber("First Subscriber");
            Subscriber subscriber2 = new Subscriber("Second Subscriber");

            publisher.MyEvent += subscriber1.OnDataReceived;
            publisher.MyEvent += subscriber2.OnDataReceived;
            publisher.RaiseEvent("Event from Publisher!");
        }
    }

    public class Publisher
    {
        public delegate void MyEventHandler(string data);     
        public event MyEventHandler MyEvent;
        public void RaiseEvent(string data)
        {
            Console.WriteLine("Raise Event");
            MyEvent?.Invoke(data);
        }
    }

    public class Subscriber
    {
        private string _name;
        public Subscriber(string name)
        {
            _name = name;
        }

        public void OnDataReceived(string data)
        {
            Console.WriteLine($"Subscriber '{_name}' received data: {data}");
        }
    }
}
```


### 4 пример

```C#
       static void Start2()
        {
            Console.WriteLine("Скачивание файла началось2");
            // Log.Info("Скачивание файла началось");
            // Image.GenerateNewImage();
        }

        static void Start3()
        {
            Console.WriteLine("Скачивание файла началось3");
            // Log.Info("Скачивание файла началось");
            // Image.GenerateNewImage();
        }   
         static void task1_3()
        {
            ImageDownLoader image = new ImageDownLoader();
            image.NotifyStart += Start;
            image.NotifyStart += Start2;
            image.NotifyStart += Start3;
            image.NotifyEnd += image.ImageFinished;

            image.NotifyStart -= Start;
        }

        
```

```C#
  internal class ImageDownLoader
    {
        #region 1 - 3 задание
        /*
         Добавьте события: в классе ImageDownloader в начале скачивания картинки и в конце скачивания картинки выкидывайте события (event) 
         ImageStarted и ImageCompleted соответственно.
         В основном коде программы подпишитесь на эти события, а в обработчиках их срабатываний выводите соответствующие уведомления в консоль: 
         "Скачивание файла началось" и "Скачивание файла закончилось".
         */
        public event Action? NotifyStart;
        public event Action? NotifyEnd;

        /// <summary>
        /// загрузка картинки
        /// </summary>
        /// <param name="remoteUri">URL адрес, где расположена картинка</param>
        /// <param name="savePath">Место сохраннее картинки на ПК</param>
        public void Download(string remoteUri, string savePath, string nameFile)
        {
            string fileNameLoad = savePath + "\\" + nameFile;

            using (var myWebClient = new WebClient())
            {
                // Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileNameLoad, remoteUri);
                NotifyStart?.Invoke();
                myWebClient.DownloadFile(remoteUri, fileNameLoad);
                NotifyEnd?.Invoke();
                //Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileNameLoad, remoteUri);
            }

        }

        public void ImageStarted()
        {
            Console.WriteLine("Скачивание файла началось");
        }

        public void ImageFinished()
        {
            Console.WriteLine("Скачивание файла закончилось");

        }
        #endregion

        #region 4 задание
        /*
         Сделайте метод ImageDownloader.Download асинхронным. Если Вы скачивали картинку с использованием WebClient.DownloadFile,
         то используйте теперь WebClient.DownloadFileTaskAsync - он возвращает Task.
        В конце работы программы выводите теперь текст "Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания" 
        и ожидайте нажатия любой клавиши. Если нажата клавиша "A" - выходите из программы. В противном случае выводите состояние загрузки картинки 
        (True - загружена, False - нет). Проверить состояние можно через вызов Task.IsCompleted.
         */
        public async Task Download(string remoteUri, string savePath)
        {
            Thread.Sleep(3000);
            // не нашёл картинку большого размера будет имитация большой картинки
            using (var myWebClient = new WebClient())
            {
                await myWebClient.DownloadFileTaskAsync(remoteUri, savePath);
            }
            //  return Task;
        }
        #endregion



    }
```

### Паттерн “Наблюдатель”

Термины:
• Observer (subscriber) -наблюдатель
• Observable (publisher) -наблюдаемый
Плюсы:
• Помогает избежать лишних запросов (от наблюдателя)
• Помогает избежать лишних рассылок (от наблюдаемого)
Можно реализовать как с использованием Event, так и без него.


## Событие (event)

Событие:
• Ситуация, требующая реакции
• Реакция может состоять из одного и более действий
Событие (в C#) -именованный делегат, запускающий в момент возникновения события все подписавшиеся на него методы.

```public event <НазваниеДелегата> <Имя>;```

Событие не может существовать вне класса (оно в этом случае бесполезно).




## Параллелизм
### Процессы и потоки

Операционная система -это менеджер ресурсов
Одна из основных задач ОС -распределение ресурсов между приложениями:
• Оперативная память
• Процессорное время
• I\O (сеть, HDD, шины, например PCI, USB)


## Процессы и потоки
В операционной системе работают процессы

Процесс -загруженная в оперативную память программа, исполняемая в данный момент

Поток -наименьшая единица исполнения, которая может быть назначена на ядро ЦП


## Процессы и потоки

Каждый процесс может иметь >= 1 потока
Минимально каждый процесс запускает хотя бы один поток исполнения (главный поток или Main thread)

ОС распределяет ресурсы между потоками (многопоточное выполнение).

Чтобы все процессы в системе могли работать “параллельно” ОС должна давать им доступ к ядрам ЦП.

Потоков в ОС как правило больше чем ядер ЦП, следовательно, каждому потоку нужно давать время на выполнение работы.

![Image alt](https://github.com/IlyaGall/C-/blob/main/19%20%D0%94%D0%B5%D0%BB%D0%B5%D0%B3%D0%B0%D1%82%D1%8B%2C%20Event-%D1%8B%2C%20%D0%B4%D0%BE%D0%B1%D0%B0%D0%B2%D0%BB%D1%8F%D0%B5%D0%BC%20%D0%B0%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D0%BE%D0%B5%20%D0%B2%D1%8B%D0%BF%D0%BE%D0%BB%D0%BD%D0%B5%D0%BD%D0%B8%D0%B5%20%20%D0%94%D0%97/img/1.JPG)

Переключение контекста (context switch) - смена исполнителя.

Дорогая операция, частая смена контекста = “тормоза”

![Image alt](https://github.com/IlyaGall/C-/blob/main/19%20%D0%94%D0%B5%D0%BB%D0%B5%D0%B3%D0%B0%D1%82%D1%8B%2C%20Event-%D1%8B%2C%20%D0%B4%D0%BE%D0%B1%D0%B0%D0%B2%D0%BB%D1%8F%D0%B5%D0%BC%20%D0%B0%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D0%BE%D0%B5%20%D0%B2%D1%8B%D0%BF%D0%BE%D0%BB%D0%BD%D0%B5%D0%BD%D0%B8%D0%B5%20%20%D0%94%D0%97/img/2.JPG)


## Блокировка потока

Некоторые операции блокируют поток:
• I\O
• Работа с сетью
• Thread.Sleep
Пока поток заблокирован - он не выполняет никакой работы, ожидая завершения длительной операции.

Некоторые действия привязаны к одному потоку, например работать с UI (в WinForms) может только один поток.
Если в этом же потоке запустить “тяжелую” операцию -это приведет к блокировке окна и элементов управления.

Создание потока -небыстрая операция 

Чаще всего используется пул потоков (ThreadPool) -некоторое количество заранее созданных потоков, которые динамически назначаются на выполнение “тяжелых” задач.


• Кол-во потоков <= кол-во ядер ЦП
• Если ЦП на 1 ядро -то уменьшения времени работы за счет разделения добиться сложнее(время на переключение контекста)
• На 2+ ядра -можно увеличить производительность работы программы

## Асинхронность

Идея асинхронности заключается в том, что:
• При выполнении блокирующей операции не обязательно блокировать поток
• Можно выполнять ее в фоновом режиме
• В какой-то момент получить результат ее (операции) выполнения

## Асинхронность (Task)

Концепция похожа на потоки, но реализуется на уровне CLR.

Task -задача, которая имеет возможность отмены, возврата результата.

Task != Thread

Но, Task для запуска использует ThreadPool

![Image alt](https://github.com/IlyaGall/C-/blob/main/19%20%D0%94%D0%B5%D0%BB%D0%B5%D0%B3%D0%B0%D1%82%D1%8B%2C%20Event-%D1%8B%2C%20%D0%B4%D0%BE%D0%B1%D0%B0%D0%B2%D0%BB%D1%8F%D0%B5%D0%BC%20%D0%B0%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D0%BE%D0%B5%20%D0%B2%D1%8B%D0%BF%D0%BE%D0%BB%D0%BD%D0%B5%D0%BD%D0%B8%D0%B5%20%20%D0%94%D0%97/img/3.JPG)



