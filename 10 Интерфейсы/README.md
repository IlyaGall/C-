## Интерфейсы
### Определение

Интерфейс в C# — это контракт, определяющий набор методов, свойств, событий или индексаторов, которые должен реализовать класс или структура.
В отличие от классов, интерфейсы не предоставляют никакой реализации для определяемых ими членов; они только определяют члены, которые должны быть реализованы.

### Соглашения по использованию интерфейса
Соглашения:
- Находится в отдельном файле
- Название начинается на “I”
- Если в названии нужно обозначить признак по действию, добавляется “-able” (IDisposable, IClonable)
### Члены интерфейса
* Метод: void Method1() должен быть реализован любым классом, реализующим IExample.
* Свойство: int Property1 { get; set; } должно быть реализовано, включая как геттер, так и сеттер.
* Событие: event EventHandler Event1 должно быть реализовано для обработки событий.
* Индексатор: string this[int index] { get; set; } должно быть реализовано для индексации.
* Константа: const int ConstantValue = 42 предоставляет постоянное значение, которое нельзя изменить.
* Метод по умолчанию: void DefaultMethod() предоставляет реализацию по умолчанию, которая может быть опционально переопределена реализующим классом

```c#
    public interface IExtample 
    {
        /// <summary>
        /// декларативный метод
        /// </summary>
        void method1();
        /// <summary>
        /// защищенный
        /// </summary>
        int property1 { get; set; }
        /// <summary>
        /// ивент 
        /// </summary>
        event EventHandler event1;

        /// <summary>
        /// индексатор метод
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        string this[int index] { get;set; }

        /// <summary>
        ///константа
        /// </summary>
        const int constantValue = 42;

        /// <summary>
        /// метод по умолчанию
        /// </summary>
        void defaultMethod() 
        {
            Console.WriteLine();
        }
    }
```
### Различия между классом и интерфейсом

![Image alt](https://github.com/IlyaGall/C-/blob/main/10%20%D0%98%D0%BD%D1%82%D0%B5%D1%80%D1%84%D0%B5%D0%B9%D1%81%D1%8B/img/1.PNG)

![Image alt](https://github.com/IlyaGall/C-/blob/main/10%20%D0%98%D0%BD%D1%82%D0%B5%D1%80%D1%84%D0%B5%D0%B9%D1%81%D1%8B/img/2.PNG)


Сценарии использования
* Определение общего поведения: Интерфейсы могут определять набор методов, которые должны реализовывать несколько классов. Это обеспечивает согласованность между различными типами.
Пример: интерфейс IComparable позволяет сравнивать объекты разных классов.
* Разделение кода: Интерфейсы помогают отделить реализацию класса от кода, который использует этот класс. Это делает код более модульным и простым в обслуживании.
Пример: интерфейс ILogger может быть реализован различными классами ведения журнала, такими как FileLogger и DatabaseLogger.
* Полиморфизм: Интерфейсы обеспечивают полиморфное поведение, позволяя одному методу работать с объектами разных классов, реализующих один и тот же интерфейс.
Пример: метод, обрабатывающий список объектов IAnimal, может работать с любым классом, реализующим интерфейс IAnimal.

* Модульное тестирование и имитация: Интерфейсы обычно используются в модульном тестировании для создания имитационных реализаций зависимостей.
Пример: интерфейс IEmailService может быть имитацией для проверки функциональности класса, который отправляет электронные письма без фактической отправки электронных писем.
* Расширение функциональности: Интерфейсы можно использовать для расширения функциональности класса без изменения его исходного кода.
Пример: интерфейс IDisposable можно реализовать для предоставления логики очистки неуправляемых ресурсов.

```c#
    public interface IPaymentProcessor

    {
        void ProcessPayment(decimal amount);
    }
    public class PayPalProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount:C}.");
        }
    }
    public class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount:C}.");
        }
    }
```

## Композиция интерфейсов

Определение композиция
- Композиция интерфейса предполагает объединение нескольких интерфейсов для создания более сложных и универсальных типов. Это позволяет классу реализовать несколько интерфейсов, тем самым наследуя контракт нескольких источников и способствуя лучшей организации и гибкости кода.
```c#
    public interface IPrintable
    {
        void Print();
    }
    public interface IScannable
    {
        void Scan();
    }
    
```
### Преимущества
* Разделение и гибкость: Композиция интерфейсов помогает разделить функциональность в системе. Разбивая сложные функции на bболее мелкие, специализированные интерфейсы, вы можете создать более гибкий и поддерживаемый код.
* Повторное использование: Когда функциональность определяется в небольших, одноцелевых интерфейсах, ее можно повторно использовать в нескольких классах. Это предотвращает дублирование кода и способствует согласованности.
* Полиморфизм: Композиция интерфейсов позволяет рассматривать класс как несколько типов. Этот полиморфизм особенно полезен при проектировании систем, которым необходимо работать с различными объектами через общий интерфейс.
* Поддерживаемость: Меньшие интерфейсы легче понимать и поддерживать. Изменения одного интерфейса не влияют на другие, что снижает риск ошибок и упрощает расширение системы.

```c#
    public interface IPrintable

    {
        void Print();
    }
    public interface IScannable
    {
        void Scan();
    }

    public class multiFunctionbevice : IPrintable, IScannable
    {

        public void Print()

        {
            Console.WriteLine("Printing document...");
        }
        public void Scan()
        {

            Console.WriteLine("Scanning document.");
        }
    }
```

### Назначение интерфейсов
Разделение кода относится к практике сокращения зависимостей между различными частями приложения. Это делает систему более модульной и простой в обслуживании.
Как помогают интерфейсы: Интерфейсы определяют контракт без указания реализации.
Программируя интерфейс, вы можете изменить базовую реализацию, не затрагивая код, который зависит от интерфейса.

### Проблема жескости связанности

```C#
    public class UserService
    {
        private UserRepository _userRepository;
        public UserService()
        {
            _UserRepository = new UserRepository();
        }
    }
```

### Проблема разработки "Сразу всего фунцкционала"
Повторное использование означает возможность использования компонентов в разных контекстах без внесения изменений. Гибкость позволяет расширять или заменять компоненты без существенных изменений.
Как помогают интерфейсы: Интерфейсы позволяют использовать различные реализации взаимозаменяемо. Это способствует повторному использованию, позволяя реализовывать один и тот же интерфейс несколькими способами, и
гибкости, позволяя легко заменять компоненты.

Пример:
Рассмотрим систему обработки платежей. Определив интерфейс IPaymentProcessor, вы можете создавать различные платежные процессоры, такие как CreditCardProcessor и PayPalProcessor.


### Содействие тестированию и мокингу 27

Определение:
Тестирование и имитация подразумевают создание упрощенных версий компонентов для проверки их взаимодействия и поведения в изоляции.
Как помогают интерфейсы:
Интерфейсы упрощают создание имитационных реализаций для целей тестирования. Это позволяет вам тестировать компоненты в изоляции, предоставляя контролируемое поведение с помощью имитаций.

```c#
public interface IEmailservice
{
    void SendEmail(string recipient, string subject, string body);

public class Notificationservice

    {

        private readonly IEmailservice _emailservice;

        public Notificationservice(IEmailservice enailservice)

        {

            _emailservice = enailservice;
        }
            public void Notify(string recipient, string message)

            {

            _emailservice.SendEmail(recipient, "Wot ification", message);
            }
        }
    }
```


```C#
  public class Mockemailservice : IEmailservice
  {
      public List<string> SentEmails = new List<string>();
      public void SendEmail(string recipient, string subject, string body)
      {
          SentEmails.Add($"{recipient}: {subject} - {body}");
      }
  }
```

### Реализация методов интерфейса в классах

Определение:
Когда класс реализует интерфейс, он должен предоставлять конкретные реализации для всех членов, определенных в этом интерфейсе. Это означает, что класс должен содержать фактический код, который выполняет операции, указанные методами, свойствами, событиями или индексаторами интерфейса.

Шаги по реализации методов интерфейса:
* Определите интерфейс: создайте интерфейс с методами, свойствами, событиями или индексаторами, которые вы хотите реализовать.
* Реализуйте интерфейс в классе: класс должен предоставлять конкретные реализации для всех членов, объявленных в интерфейсе.

```C#
 // Define the interface
 public interface IVehicle
 {
     void Start();
     void Stop();
 }

 // Implement the interface in a class
 public class Car : IVehicle
 {
     public void Start()
     {
         Console.WriteLine("car started.");
     }
     public void Stop()
     {
         Console.WriteLine("Car stopped.");
     }
 }
 ```

 использование

 ```C#
    public static void Main()
    {
        IVehicle myCar = new Car();
        myCar.Start(); // Output: Car started.
        myCar.Stop();  // Output: Car stopped.
    }
 ```
 ## Наследование интерфейсов

 Наследование
* Наследование интерфейсов в C# позволяет одному интерфейсу наследовать от другого интерфейса. Это означает, что производный интерфейс будет включать в себя все элементы базового интерфейса, а также любые дополнительные элементы, которые он определяет.

Назначение:
* Расширение функциональности: позволяет расширить существующий интерфейс, добавляя больше членов без изменения исходного интерфейса.
* Повторное использование: способствует повторному использованию, позволяя интерфейсам надстраиваться над другими интерфейсами.


```C#
    // Define the base interface
    public interface IAnimal
    {
        void Eat();
    }


    // Define the derived interface that inherits from the base interface
    public interface IDog : IAnimal

    {
        void Bark();
    }
```
### Реализация унаследованных интерфейсов в классах

```C#
  // Define the base interface
  public interface IAnimal
  {
      void Eat();
  }


  // Define the derived interface that inherits from the base interface
  public interface IDog : IAnimal

  {
      void Bark();
  }
  //Taplemant the derived interfoce ino class
  public class Gersanshepherd : IDog
  {
      public void Eat()
      {
          Console.WriteLine("Ihe dog is eating.");
      }
      public void Bark()
      {
          Console.WriteLine("Ihe dog is barking.");
      }
  }
```
### Множественное наследование интерфейсов
```C#
    // Define the base interfaces
    public interface IAnimal

    {
        void Eat();
    }
    public interface IPet
    {
        void Play();
    }

    // Define the derived interface that inherits from multiple interfaces
    public interface ICat : IAnimal, IPet
    {
        void Meou();
    }

        public class PersinalCat : ICat
    {
        public void Eat()
        {
             Console.WriteLine("Ihe cat is barking.");
        }

        public void Meou()
        {
            Console.WriteLine("Meou");
        }

        public void Play()
        {
            Console.WriteLine("Ihe cat is Play.");
        }
    }
```

## Реализация интерфейса с идентичными методами
Явная реализация интерфейса

Явная реализация интерфейса — это метод, используемый в C# для разрешения конфликтов, возникающих, когда класс реализует несколько интерфейсов, содержащих методы с одинаковой сигнатурой. Используя явную реализацию интерфейса, вы можете предоставить отдельные реализации для каждого метода интерфейса, избегая конфликтов имен и гарантируя, что контракт каждого интерфейса выполняется правильно.

```C#
    interface IFirstinterface
    {
        void Method();
    }

    interface ISecondinterface
    {
        void Method();
    }

    public class ImplenentationClass : IFirstinterface, ISecondinterface
    {
        void IFirstinterface.Method() 
        {
            Console.WriteLine("IFirstinterface Method implenentation.");
        }

        void ISecondinterface.Method()
        {

            Console.WriteLine("Isecondinterface Method implenentation.");
        }
    }
```

Ключевые моменты:
* Явная реализация интерфейса гарантирует, что имена методов не будут конфликтовать.
* Методы можно вызывать только через экземпляры интерфейса, а не напрямую через экземпляр класса.

```C#
    public class Program
    {
        public static void Main()
        {
            ImplenentationClass obj = new ImplenentationClass();
            IFirstinterface first =obj;
            first.Method(); // Output: IFinstinterface Method implenentation.
            ISecondinterface second =obj;
            second.Method(); // Output: ISecondInterface Method inplenentation.
        }
    }
```
### Разрешение конфликтов имен методов
При реализации нескольких интерфейсов, имеющих методы с одинаковыми сигнатурами, могут возникнуть конфликты.

Явная реализация интерфейса — основной способ разрешения этих конфликтов в C#.

```C#
    interface IDrawable
    {

        void Draw();
    }
    interface IRenderable
    {
        void Draw();
    }

    public class Shape : IDrawable, IRenderable

    {
        void IDrawable.Draw()
        {
            Console.WriteLine("Orawing is IDrawable.");
        }
        void IRenderable.Draw()
        {
            Console.WriteLine("Drawing is IRenderable.");
        }

    }

     public class Program
    {
        public static void Main()
        {
            Shape shape = new Shape();
            IDrawable drawable = shape;
            drawable.Draw(); // Output: Drawing as IDrawable.
            IRenderable renderable = shape;
            renderable.Draw(); // Output: Drawing as IRenderable.
        }
    }
```

# Константы и Дефолтная реализация

Константы
В C# вы можете определять константы в интерфейсах. Эти константы неявно статичны и не могут быть изменены. Константы в интерфейсах можно использовать для предоставления фиксированных значений, общих для разных реализаций.

Ключевые моменты:
* Статическая природа: константы в интерфейсах статичны и используются во всех реализациях.
* Только для чтения: значения констант не могут быть изменены после компиляции.
* Нет доступа к экземпляру: доступ к константам невозможен через экземпляр класса, реализующего интерфейс; доступ к ним должен быть возможен через сам интерфейс.

```C#
public interface TLogger
{
    const string DefaultLogtevel = "INFO";
    void Log(string message);
    void LogErron(string message)
    {
        Log($"ERROR: {message}");
    }
    public class ConsoleLogger : TLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
```

## Реализация по умолчанию

Начиная с C# 8.0, интерфейсы могут предоставлять реализации методов по умолчанию. Это позволяет интерфейсам включать тела методов, позволяя определять поведение по умолчанию, которое реализующие классы могут использовать как есть или переопределить.

Ключевые моменты:
* Необязательное переопределение: реализующие классы могут использовать реализацию по умолчанию или предоставить свою собственную.
* Поведение по умолчанию: предоставляет способ определить общее поведение в интерфейсах, которое может использоваться в нескольких реализациях.

### Ограничения:
* Нет полей экземпляра: интерфейсы не могут содержать поля экземпляра или нестатические члены, кроме методов, свойств, событий и индексаторов.
* Нет конструкторов: интерфейсы не могут иметь конструкторов. Поэтому методы по умолчанию не могут полагаться на поля экземпляра для инициализации.
* Перегрузка методов: методы по умолчанию не могут быть перегружены так же, как методы в классах. 
Каждый метод в интерфейсе должен иметь уникальную сигнатуру.
* Статические члены: интерфейсы не могут содержать статические методы, а методы по умолчанию не являются по-настоящему статическими, а предоставляют тело метода, которое совместно используют все реализующие классы.

### Таблица различий абстактного класса и интерфейса

![Image alt](https://github.com/IlyaGall/C-/blob/main/10%20%D0%98%D0%BD%D1%82%D0%B5%D1%80%D1%84%D0%B5%D0%B9%D1%81%D1%8B/img/3.PNG)

### практика

```C#
namespace интерфейс
{
    /*
    Создать класс Person с методом Walk(), который выводит на экран надпись “Человек прошел 500 метров”;
    Создать массив из 5 людей и в цикле вызвать метод Walk();
    Создать класс Horse с методом Walk(), который выводит на экран надпись “Лошадь прошла 5000 метров”;
    Создать интерфейс IWalkable с методом Walk();
    Добавить реализацию этого интерфейса в обоих классах.
    Поменять тип объектов на интерфейс в массиве и в цикле;
    Добавить в массив 5 экземпляров Horse;
    *Создать интерфейс IMoveable с методом void Move(); и реализовать его в обоих классах.
     */
    interface IMoveable
    {
        void Move();
    }

    interface IWalkable 
    {
        void Walk();
    }
    class Person: IWalkable, IMoveable
    {
        public void Move()
        {
            Console.WriteLine("Человек прошел 500 метров");
        }

        public void Walk() 
        {
            Console.WriteLine("Человек прошел 500 метров");
        }
    }
    class Horse : IWalkable, IMoveable
    {
        public void Move()
        {
            Console.WriteLine("Лошадь прошла 5000 метров");
        }
        public void Walk()
        {
            Console.WriteLine("Лошадь прошла 5000 метров");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
          
            var list = new IWalkable[] { new  Person(), new Person(), new Person(), new Person(), new Person(), new Horse()};
           
          
            foreach (IWalkable p in list) 
            {
                 p.Walk();
            }
            foreach (Person p in list)
            {// ошибка так как к одному типу привели, а лошадка не человек
                p.Walk();
            }


        }
    }
}

```