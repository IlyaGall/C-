## Определение
Объектно-ориентированное программирование (ООП) – методология программирования, основанная на представлении программы в виде совокупности взаимодействующих объектов, каждый из которых является экземпляром определенного класса, а классы образуют иерархию наследования (Гради Буч “Объектно-ориентированный анализ и проектирование” Класс в объектно-ориентированном программировании – модель для создания объектов  определённого типа, описывающая их структуру (набор полей и их начальное состояние) и определяющая алгоритмы (функции или методы) для работы с этими объектами.
● Программа – набор объектов
● Объекты – экземпляры класса
● Класс – комплексный тип данных, состоящий из полей и методов для работы с ними

## Синтаксис

```c#
[тип доступа (public, internal, private)] class НазваниеКласса
{
//код
}
public class Car {}
```

## Создаем объекты класса

```c#
public class Car {}
//       ||
//       \/
// Можно создавать объект класса Car - nissan
var nissan = new Car();
// lexus – ссылка на объект nissan
var lexus = nissan;
```

## Конструктор по умолчанию

```c#
public class Car {}
||
\/
public class Car
{
    public Car()
    {
        /*
        Конструктор по умолчанию
        создается, если нет других
        конструкторов и заполняет поля
        класса дефолтными значениями
        */
    }
}

```

## Поля
Приватные поля доступны только из класса, в котором находятся!

```c#
public class Car
{
    // Трансмиссия
    private int transmission;
    // Марка машины
    public string Name;
}

var nissan = new Car();
/*не имее доступ к полю, так как он приватный в классе
    nissan.transmission = 0
*/
 nissan.Name = null
```

## Конструктор(кастомный)
! Если есть конструктор с параметрами, то конструктор по умолчанию не создается!
```c#
public class НазваниеКласса
{
    [тип доступа] НазваниеКласса([Аргументы])
    {
    //какой-то код
    }
}
public class Car
{
    public Car(string name)
    {
        Name = name;
    }
}
//||
//\/
var nissan = new Car("Nissan");

```

##  Создаем объекты класса

Если есть конструктор с параметрами, то конструктор по умолчанию не создается!

Приватные поля доступны только из класса, в котором находятся!

```C#
public class Car 
{ 
    private int transmission;
    public string Name;
    public Car(string name) 
    { 
      Name = name; 
    } 
}
//||
//\/
var nissan = new Car("Nissan");

nissan.Name = "Lexus";
//nissan.transmission = 5; //ошибка

```

## Методы (void)
```C#
Тип ответа void - метод ничего не возвращает
public class MyClass 
{ 
    [тип доступа] тип_данных_ответа НазваниеМетода([параметры]) 
    { 
        // код 
    } 
}

public class Car 
{ 
    private int transmission;
    public void ChangeTransmission(int count) 
    { 
     transmission += count; 
    } 
}
```

## Методы (return)

return возвращает из метода значение
```C#
public class Car 
{ 
    private int transmission;
    public int ChangeTransmission(int count) 
    { 
        transmission += count; 
        return transmission;
    } 
}
…
var nissan = new Car("Nissan");
Console.WriteLine($"Transmission = {nissan.ChangeTransmission(1)}”);
```

## Ключевое слово this
```c#
public class Car 
{ 
    private int transmission;
    public int ChangeTransmission(int count) 
    { 
        this.transmission += count; 
        return transmission;
    } 
}
```
Часто можно увидеть в конструкторах(в данном случае нужен для указания конкретной переменной)
```C#
public class Car 
{ 
    private string name;
    public Car(string name) 
    { 
        this.name = name; 
    } 
}

```

ссылки на сайт макросовфт 

[1](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/top-level-statements)
[2](https://learn.microsoft.com/en-us/dotnet/core/tutorials/top-level-templates)


## Пишем свой класс. Свойства get set


Всегда лучше public свойство, чем public поле. Свойство – особое поле, позволяющее настраивать присвоение и получение данных для него 
• По принципу работы – похожи на методы 
• По синтаксису – на поля 
• Для получения данных – ключевое слово get
• Для присваивания – ключевое слово set

### Пишем свой класс. Свойства
```c#
[тип доступа] тип_свойства НазваниеСвойства
{ 
    get 
    { 
    // Какой-то код 
        return что-то; 
    } 
    set 
    { 
        // Какой-то код 
      что-то = value; // value – значение извне 
    } 
}
```
Пример
```c#
private double _velocity = 0; 
public double Velocity 
{ 
    get { return _velocity; } 
    set 
    { 
        if (value < 0) 
        throw new InvalidOperationException("Скорость должна быть > 0"); 
        _velocity = value; 
    } 
}
nissan.Velocity = 40; //срабатывает set 
Console.WriteLine(nissan.Velocity); //срабатывает get
```
### Автосвойства
```C#
private double _velocity; 
public double Velocity 
{ 
    get { return _velocity; }  //
                               // => public double Velocity { get; set; }    
    set { _velocity = value; } //
}
 
```

# partial, static, удобства работы
## partial
1. Класс очень большой, часть методов/свойств/полей можно семантически объединить вместе
2. С одним классом работают несколько программистов
3. Часть кода генерируется автоматически – обычно создается в отдельном файле

```C#
// в одном файле Car.cs
public partical class car
{
    public Car(string name)
    {
        Name = name;
    }
    //код
}
```

```C#
// в другом файле CarAction.cs
public partial class Car
{
    public void StartEngine()
    {

    }
    public void Driva()
    {

    }

}
```

## static Когда используется
1. Есть методы/функции, которые могут работать без объекта, содержащих их
2. Есть набор констант, доступных в разных частях приложения
3. Есть объект, который будет всегда в единственном экземпляре
4. Надо «расширить» класс новыми методами

Статический класс – класс, из которого нельзя создавать объекты
```C#
static class MathStatic
{
    public static int Pow(int a, int p)
    {
        return 0;
    }
}
```
```C#
// все ошибка
var m = new MathStatic();
Console.WriteLine(m.Pow(2,4));
// но можно так
console.WriteLine(MathStatic.Pow(2,4))
```
Статические классы могут содержать только статические члены класса


## static. Статический конструктор (особенности)
Статические конструкторы не должны иметь модификатор доступа и не принимают параметров, их нельзя вызвать вручную
```C#
static class MathStatic 
{ 
    //автоматически вызывается при первом обращении к классу 
    static MathStatic() 
    { 
    Console.WriteLine("Я статический конструктор"); 
    } 
}
```
Статический конструктор может быть и у нестатического класса

```c#
class MathStatic 
{ 
    public int MyValue = 5;
    public static double Pi = 3.141592;
    public static string MyProp { get; set; }
    public static int Pow(int a, int p)
    { 
        MyValue = 90; //так нельзя
        Pi = 90; //так можно
    } 
}
Статические методы могут обращаться только к статическим членам класса 
```

```c#
class MathStatic 
{ 
    public int MyValue = 5;
    public static double Pi = 3.141592;
    public static string MyProp { get; set; }
    public static int Pow(int a, int p)
    { 
    //код
    } 
}
К статическим членам классам обращение идет по имени класса, а не по имени экземпляра как обычно
Console.WriteLine(MathStatic.Pi);
MathStatic.Pow(2,3); 
```
## static. Методы расширения

```C#
public static class CarExtensions
{
    public static void Drive(this Car car, int speed)
    {
        car.Velocity = speed;
        Console.WriteLine("vrum");
    }
}
var nissan = new Car("Nissan");
nissan.Drive(10);

// или так
CarExtensions.Drive(nissan,10);
```

## Удобства работы. Классы внутри классов
```C#
public class Car
{
    // класс внутри, но доступен снаружи
    public class Engine{}
    class Tier {}
}
// так можно 
var v8  = new car.Engine();
//так -нельзя
var michelin = new car.Tiger();
```

![Image alt](https://github.com/IlyaGall/C-/blob/main/08%20%D0%9A%D0%BB%D0%B0%D1%81%D1%81%D1%8B%20%D0%BA%D0%B0%D0%BA%20%D0%BE%D1%81%D0%BD%D0%BE%D0%B2%D0%B0/img/1.PNG)

## добства работы. Разные модификаторы доступа
Устанавливать значение свойству можно только внутри класса
```C#
private double _velocity = 0; 
public double Velocity
{ 
    public get { return _velocity; } 
    private set 
    { 
        if (value < 0) 
        throw new InvalidOperationException("Скорость должна быть > 0"); 
        _velocity = value; 
    } 
}
```

## Удобства работы. Только get или set

```C#
private double _velocity = 0;
public double Velocity
{
    set
    {
        _velocity = value;
    }
}
```

```C#
private double _velocity = 0;
public double Velocity
{
    get
    {
        return _velocity;
    }
}
```

## упрощение get/set
```C#
private double _velocity = 0;
public double Velocity
{
    set
    {
        _velocity = value;
    }
    get
    {
        return _velocity;
    }
}

```
будет так:
```C#
public double Velocity
{
    get => _velocity;
    set => _velociwty = value;
}
```

