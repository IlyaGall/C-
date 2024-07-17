## Что такое ООП
- парадигма программирования, основанная на концепции “объектов”, которые могут содержать данные и код для их обработки.

Основные концепции:
* Классы
* Экземпляры
* Методы
* Свойства

## Абстракция
Абстракция означает скрытие сложных деталей реализации и показ только существенных функций объекта.

Abstract class – класс, который обычно содержит реализацию некоторых методов/свойств, а реализацию других методов оставляет за своими «наследниками».

Экземпляры такого класса создавать нельзя.

Interface — контракт (обязательство), который обязуется выполнить класс.
Интерфейс может включать в себя, т.е. наследовать другие интерфейсы.

```C#
abstract class StringHolder
{
    private readonly string _content;
    abstract public string Read();
    abstract public void Add(string content);
    public int Length => _content.Length;
    protected bool CanAdd => Length < 1000;
}
class FileStringHolder : StringHolder
{
    public override string Read()
    {
        // ...
    }
    public override void Add(string content)
    {
        if (!CanAdd)
        {
        throw new Exception("Too much content");
        }
       // ...
    }
    public string Delete()
    {
       // ...
    }
}
```

### Используемые модификаторы

* abstract – абстрактный класс
* virtual – член класса разрешает, чтобы его переопределяли наследники
* override – член класса переопределяет базовое определение
* new – член класса скрывает базовое определение

### abstract, virtual

Если не сделать виртуальным класс, то его нельзя будет переопредлить при наследовании абстрактного класса, а еще virtual означает, что метод не обязательно переопределять, так как виртуальный метод что-то реализует. А абстрактный класс нужно всегда переопределять!


```C#
// Абстрактный класс
public abstract class LivingThing
{
    // Абстрактный
    // Производный класс должен реализовать его
    public abstract void Move();
    // Тут уже какая-то реализация есть
    public virtual void Eat(Thing t)
    {
    Console.WriteLine("I ate");
    }
}

public class Human : LivingThing
{
    // ОБЯЗАТЕЛЬНО
    // переопределяем метод
    public override void Move()
    {
    Console.WriteLine("One leg");
    Console.WriteLine("Two leg");
    }
}
```
2 пример 

```C#
// Абстрактный класс
public abstract class LivingThing {
    // Абстрактный
    // Производный класс должен реализовать его
    public abstract void Move();
    // Тут уже какая-то реализация есть
    public virtual void Eat(Thing t)
    {
     Console.WriteLine("I ate");
    } 
 }

 public class Animal : LivingThing {
 // ОБЯЗАТЕЛЬНО
 // переопределяем метод
        public override void Move()
        {
            Console.WriteLine("One leg");
            Console.WriteLine("Two leg");
            Console.WriteLine("Three leg");
            Console.WriteLine("Four leg");
        }
        // НЕОБЯЗАТЕЛЬНО
        // переопределяем метод
        public override void Eat(Thing t)
        {
            Console.WriteLine("I bite");
            base.Eat(t);
        } 
 }
```

## Наследование

```C#
// Базовый класс
public class Vehicle
{
    public long Speed { get; set; }
}

// Car наследует свойства Vehicle
public class Car : Vehicle
{
     public string Name { get; set; }
}

static void Main(string[] args)
{
    var v = new Vehicle();
    v.Speed = 10;
    var car = new Car();
    // у car есть свойство Speed
    // от Vehicle
    car.Speed = 100;
    // И собственное Name
    car.Name = "Nissan";
}

```
### Глубина наследования

Количество уровней наследования не ограничено, но не рекомендуется делать иерархию
чрезмерно глубокой
```c#
lass Stuff { }
class Equipment : Stuff { }
class Computer : Equipment { }
class Laptop : Computer { }
class Macbook : Laptop { }
```
Неявно в корне любой иерархии класс Object
```c#
class Staff : Object { }
```
### Нет множественного наследования класса от классов
```c#
public class Robot
{
}
// Можно
public class Transformer : Car
{
}
// Нельзя
public class Transformer : Car, Robot
{
}
```

## Модификаторы
Модификаторы доступа помогают защититься от ошибок разработчиков (т.н. защитное программирование)

* private — доступ только для членов этого же класса
* protected — доступ только для членов этого же класса + для наследников этого класса (как прямых, так и опосредованных)
* internal — доступ только для членов этого проекта
* public — доступ для всех

Некоторые другие модификаторы:

* const – значение должно быть рассчитано на этапе компиляции
* readonly – значение может быть записано только один раз (при инициализации класса)
* static – не требует создания экземпляра класса для обращения к этому члену


### Модификаторы доступа: private

```C#
class Parent
{
    private int a;
    public void PrintParent()
    {
     Console.WriteLine(a);
    }
}
class Child : Parent
{
    public void PrintChild()
    {
        Console.WriteLine("Нельзя " + a);
    }
}
class Alien
{
    public void PrintAlien()
    {
        Parent parent = new Parent();
        Console.WriteLine("Нельзя " + parent.a);
    }
}

```
### Модификаторы доступа: protected

Видны методы только у отнаследованных классов

```C#
class Parent
{
    protected int a;
    public void PrintParent()
    {
    Console.WriteLine(a);
    }
}
class Child : Parent
{
    public void PrintChild()
    {
    Console.WriteLine("Можно " + a);
    }
}

class Alien
{
    public void PrintAlien()
    {
    Parent parent = new Parent();
    Console.WriteLine("Нельзя " + parent.a);
    }
}
```
### Модификаторы доступа: public
```C#
class Parent
{
    public int a;
    public void PrintParent()
    {
        Console.WriteLine(a);
    }
}
class Child : Parent
{
    public void PrintChild()
    {
         Console.WriteLine("Можно " + a);
    }
}
class Alien
{
    public void PrintAlien()
    {
        Parent parent = new Parent();
        Console.WriteLine("Можно " + parent.a);
    }  
}
```

## Инкапсуляция
Инкапсуляция — это процесс отделения друг от друга элементов объекта, определяющих его устройство и поведение;

инкапсуляция служит для того, чтобы изолировать контрактные обязательства абстракции от их реализации
Г. Буч

```C#
class Server
 {
    private ServerState state = ServerState.Stopped;
    public void Run() { DoRun(); }
    public void Stop() { DoStop(); }
    private void DoRun()
    {
        state = ServerState.Starting;
        // выполнить логику по запуску сервера
        // ...
        state = ServerState.Started;
    }
        private void DoStop()
    {
    state = ServerState.Stopping;
    // выполнить логику по остановке сервера
    // ...
    state = ServerState.Stopped;
    }
 }
 enum ServerState
 {
    Starting,
    Started,
    Stopping,
    Stopped
 }
```

### sealed
```C#
public class FaunaThing : LivingThing
{
    public override void Move()
    {
    }
    // sealed не позволяет переопределять дальше
    public override sealed void Eat(Thing t)
    {
         Console.WriteLine("absorb air");
    }
}
public class Tree : FaunaThing
{
    // Ошибка компиляции
    public override void Eat(Thing t)
    {
    }
}
```
## Полиморфизм

Полиморфизм (Polymorphe греч.) Дословно - множественность форм. Способность
объекта или оператора ссылаться на объекты разных классов на стадии выполнения. И.
Грэхем
- это способность объектов принимать множество форм, что позволяет одному
интерфейсу представлять различные подлежащие типы данных.
Выделяют два основных типа полиморфизма:
- Времени компиляции (перегрузка методов)
- Времени выполнения (переопределение методов)