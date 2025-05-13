# Атрибуты
## Что такое атрибут?


- класс-наследник System.Attribute, добавляющий дополнительную информацию или функциональность к элементу перед которым находится.
По соглашению, название атрибута заканчивается на Attribute (“ObsoleteAttribute”).


```C#
[Obsolete("This method is obsolete. Use M2 instead.")] public void M1(int x)
{
    Console.WriteLine($"x = {x}");
}
```
## Использование атрибутов

* Аннотация метаданных. Атрибуты позволяют добавлять метаданные к элементам программы, таким как классы, методы, свойства, параметры и т. д. Эти метаданные могут передавать дополнительную информацию об этих элементах, помогая в документации кода, анализе и поведении во время выполнения.

* Организация и ясность кода. Атрибуты помогают организовать и уточнить код, прикрепляя описательные метки или поведение к конкретным элементам. Например, такие атрибуты, как [Serializable] или [Obsolete], передают важную информацию о сериализации классов или устаревших методах соответственно, что делает код более понятным для разработчиков.

* Использование платформы. Многие платформы и библиотеки .NET широко используют атрибуты для управления поведением или предоставления параметров конфигурации. Понимание того, как использовать и интерпретировать эти атрибуты, имеет решающее значение при работе с такими платформами, как ASP.NET, Entity Framework или ASP.NET Core.

* Настройка и расширяемость. Атрибуты позволяют разработчикам расширять функциональность среды выполнения .NET, создавая собственные атрибуты, адаптированные к их конкретным требованиям. Пользовательские атрибуты можно использовать для реализации сквозных задач, таких как ведение журнала, кэширование, проверка, авторизация и многое другое.

* Reflection и метапрограммирование. Reflection позволяет разработчикам проверять код и манипулировать им во время выполнения, а атрибуты играют центральную роль в Reflection. Понимание того, как эффективно использовать атрибуты, позволяет разработчикам использовать Reflection для таких задач, как динамический вызов методов, запросы метаданных и обработка на основе атрибутов.

* Аспектно-ориентированное программирование (АОП). Атрибуты являются ключевым компонентом АОП, парадигмы программирования, которая позволяет разработчикам  модулизировать сквозные задачи. Применяя атрибуты к элементам программы, разработчики могут добавлять в приложение дополнительное поведение или функциональность, не изменяя его основную логику. 

* Тестирование и отладка. Атрибуты могут помочь в тестировании и отладке, предоставляя метаданные, которые влияют на выполнение теста или поведение отладки.

```C#
[Serializable][Flags] public void Method() { }

[FlagsAttribute, SerializableAttribute] public void Method() { }

[Serializable, Flags] public void Method() { }

[FlagsAttribute()][Serializable()] public void Method() { }
```

```C#
[RemarkAttribute("This class uses an attribute.")] 
[RemarkAttribute("This class uses an attribute #2.")]
 class UseAttribute { }
```

## Применение атрибутов

```C#
[AttributeUsage(AttributeTargets.All, AllowMultiple = true)] 
public class RemarkAttribute : Attribute
{
    string _remark;

    public RemarkAttribute(string comment)
    {
        _remark = comment;
    }
    public string Remark
    {
        get { return _remark; }
    }
}
```

2 пример

```C#
///
<summary>
/// Ремонт и строительство
/// </summary>
[Cities(Cities.Moscow, Cities.Piter)]
[Order(1), Description("TaskCategories_Clerical", true, "Tasks")]
[TaskPrice(1100, 1350, 2500, 1200, 1500, 500)]
[TaskPrice(900, 1200, 2500, 1000, 1500, 500, "Piter")]
Clerical = 32768,
```

3 пример

```C#

/// <summary>
/// Получение слиске Mастерое
/// </summary>
[HttpPost]
[Route("masters")]
[ProducesResponseType(typeof(MastersModel), (int)HttpStatusCode.OK)]
[ProducesResponseType((int)HttpStatusCode.NotFound)]
public async Task<ActionResult> GetMasters([FromBody] MastersRequest request)
```

### К чему применяются атрибуты?

```C#
using System;
[assembly: SomeAttr] // Применяется к сборке
[module: SomeAttr] // Применяется к модулю

[type: SomeAttr] // Применяется к типу
internal sealed class SomeType<[typevar: SomeAttr] T> { // Применяется
// к переменной обобщенного типа

[field: SomeAttr] // Применяется к полю 
public Int32 SomeField = 0;

[return: SomeAttr] // Применяется к возвращаемому значению
[method: SomeAttr] // Применяется к методу
public Int32 SomeMethod(
[param: SomeAttr] // Применяется к параметру Int32 SomeParam
Int32 SomeParam) { return SomeParam; }


[property: SomeAttr] // Применяется к свойству
public String SomeProp {
[method: SomeAttr] // Применяется к механизму доступа get
get { return null; } }


[event: SomeAttr] // Применяется к событиям
[field: SomeAttr] // Применяется к полям, созданным компилятором
[method: SomeAttr] // Применяется к созданным
// компилятором методам add и remove
public event EventHandler SomeEvent;
}
```

### Вопросы для проверки

* Что такое атрибут в C#?

Атрибут в C# — это декларативный тег, который предоставляет метаданные об элементах программы, таких как классы, методы, свойства, параметры и т. д. Он позволяет разработчикам добавлять к этим элементам дополнительную информацию или поведение без изменения их основных функций.

* Как атрибуты используются при разработке на C#?

Атрибуты используются для передачи метаданных об элементах программы, которые могут использоваться компиляторами, средами выполнения, платформами и инструментами. Они облегчают выполнение различных таких как генерация кода, сериализация, проверка, документирование и многое другое.

* Можете ли вы привести примеры сценариев, в которых обычно используются атрибуты?

Общие сценарии использования атрибутов включают пометку методов как устаревших ([Obsolete]), указание поведения сериализации ([Serializable]), определение шаблонов маршрутов в ASP.NET MVC ([Route]), настройку внедрения зависимостей ([Inject]) и указание требования авторизации ([Authorize]).



## .NET Core


* [Serializable]: помечает класс как сериализуемый, позволяя сериализовать и  десериализовать экземпляры класса.
* [DataContract] , [DataMember]: используются для определения контрактов данных в  службах WCF (Windows Communication Foundation) для сериализации и десериализации данных
* [JsonProperty] (Newtonsoft.Json or System.Text.Json.Serialization): позволяет указывать имена свойств JSON во время сериализации и десериализации объектов.
* [Required] ( [ValidationAttribute] )(System.ComponentModel.DataAnnotations): указывает, что свойство должно иметь значение во время проверки модели.
* [Obsolete]: помечает элемент (например, свойство, метод) как устаревший или устаревший, указывая, что его больше не следует использовать.
* [Conditional]: позволяет условно компилировать методы на основе указанных символов предварительной обработки. Это позволяет разработчикам включать или исключать определенные методы из скомпилированного вывода в зависимости от определенных символов, что может быть полезно для управления кодом, специфичным для отладки, или реализации переключения функций.
* [Flags]: указывает, что перечисление представляет собой набор битовых полей или флагов. Это позволяет разработчикам определять перечислимые типы, в которых каждое значение перечисления представляет одну битовую позицию, что позволяет объединять несколько значений перечисления в одно значение с помощью побитовых операций.

## AspNetCore.Mvc

* [Route] : определяет шаблон маршрута для действия контроллера MVC или обработчика Razor Pages.
* [HttpGet], [HttpPost], [HttpPut], [HttpDelete]: HTTP-глаголы маршрутизации на основе атрибутов, используемые для указания метода HTTP для методов действия контроллера.
* [ApiController] : помечает контроллер как контроллер API, обеспечивая такие функции, как автоматическая проверка модели и автоматические ответы HTTP 400.
* [FromQuery], [FromRoute], [FromBody], [FromHeader]: используется для привязки модели в ASP.NET Core MVC для привязки данных из разных источников (строка запроса, данные маршрута, тело запроса, заголовки) для параметров метода действия.
* [Produces] [Consumes] : используются для указания типов мультимедиа, которые действие контроллера может создавать или потреблять.
* [BindProperty]: используется в Razor Pages для указания того, что свойство должно быть привязано к данным входящего запроса.
* [Authorize] (Microsoft.AspNetCore.Authorization): указывает, что для доступа к контроллеру или методу действия требуется проверка подлинности.

### Сколько у этого класса атрибутов?

```class A {}```

* AutoLayout - автоматическое размещение содержимого класса в памяти. Другие варианты - ExplicitLayout и SequentialLayout.

* AnsiClass - означает, что при маршаллинге класса строки в нём необходимо интерпретировать как ANSI. Другие варианты - UnicodeClass, AutoClass и CustomFormatClass.
* Class - обозначение, что этот объект является классом.
* NestedPrivate - вложенный и приватный.
* BeforeFieldInit - означает, что объект класса может быть создан заранее, т.е. до того, как к нему обратились.

### Сколько у этого метода атрибутов?

```C#
public void M1(int x)
{
    Console.WriteLine($"x = {x}");
}
```
* PrivateScope - указывает, что невозможно создать ссылку на этот член
* Public - метод находится в публичном доступе.
* HideBySig - указывает, что метод скрывается на основе оценки имени и сигнатуры; в обратном случае метод скрывается только по имени.


### Размещение в памяти

```C#
public struct NotAlignedStruct
{
    public byte m_byte1;
    public int m_int;
    public byte m_byte2;
    public short m_short;
}
```

[img](https://github.com/IlyaGall/C-/blob/main/51%20%D0%90%D1%82%D1%80%D0%B8%D0%B1%D1%83%D1%82%D1%8B/img/1.JPG)

```C#
[StructLayout(LayoutKind.Auto)]
public struct NotAlignedStructWithAutoLayout
{
    public byte m_byte1;
    public int m_int;
    public byte m_byte2;
    public short m_short;
}
```

[img](https://github.com/IlyaGall/C-/blob/main/51%20%D0%90%D1%82%D1%80%D0%B8%D0%B1%D1%83%D1%82%D1%8B/img/2.JPG)

### Атрибут [Flags]

```C#
[Flags]
internal enum Weekdays
{
    None = 0x0000, // Зачем None?
    Monday = 0x0001,
    Tuesday = 0x0002,
    Wednesday = 0x0004,
    Thursday = 0x0008,
    Friday = 0x0010, // Почему 10, ведь должны быть степени двойки?
    Saturday = 0x0020,
    Sunday = 0x0030,
    Workdays = Monday |Tuesday | Wednesday| Thursday | Friday,
    Holidays = Saturday |  Sunday,
    All = Workdays |  Holidays
}
```

### Где используются атрибуты?

* Тестирование (xUnit, nUnit)
* Валидация
* Сериализация
* ASP.NET Controllers
* etc.

### Вопросы для проверки


* Объясните назначение атрибута [Obsolete]. Как и почему вы будете использовать его в своем коде?

Атрибут [Obsolete] помечает программный элемент (обычно метод или свойство) как устаревший, указывая, что он устарел или больше не должен использоваться. При его применении компилятор генерирует предупреждение или ошибку, чтобы предупредить разработчиков об устаревшем элементе, побуждая их соответствующим образом обновить свой код.

* Что делает атрибут [Serializable] и когда его можно использовать?

Атрибут [Serializable] помечает класс как сериализуемый, позволяя конвертировать экземпляры класса в поток байтов для хранения или передачи. Этот атрибут обычно используется в распределенных системах, операциях файлового ввода-вывода и сценариях сохранения объектов.

* Обсудите значение атрибута [Conditional] в C#.

Атрибут [Conditional] позволяет условно компилировать методы на основе указанных символов предварительной обработки. Это позволяет разработчикам включать или исключать определенные методы из скомпилированного вывода в зависимости от определенных символов, что может быть полезно для управления кодом, специфичным для отладки, или реализации переключения функций.

### Типы которые можно использовать

В C# атрибуты могут иметь свойства, также называемые параметрами. Однако существуют ограничения на типы, которые можно использовать для этих свойств.

Возможные типы, которые можно использовать в качестве свойств атрибутов:

* Примитивные типы: bool, byte, char, short, int, long, float, double
* string:string
* Enum (Перечисления):Любой тип перечисления
* Тип: System.Type
* Массивы объектов:

Одномерные массивы любого из вышеперечисленных типов, включая массивы этих типов
(int[], string[], bool[], Type[] и т. д.)

#### Почему только такие

Атрибуты предназначены для хранения метаданных о коде, и эти метаданные должны быть доступны во время компиляции, чтобы их можно было внедрить в сборку и впоследствии использовать инструментами и платформами, которые читают эти метаданные во время выполнения.

Типы, разрешенные в качестве параметров атрибута (примитивные типы, строки, перечисления, Type и статические массивы), — это все типы, которые могут быть представлены как константы во время компиляции.

В C# экземпляр класса атрибута создается средой выполнения .NET, когда это необходимо, обычно когда отражение используется для проверки атрибутов, примененных к элементам кода (таким как классы, методы, свойства и т. д.). (Такие методы, как GetCustomAttributes, IsDefined и GetCustomAttribute, запускают создание экземпляров классов атрибутов.)

#### Пример Кастомного Атрибута

```C#
[RemarkAttribute("This class uses an attribute.")] 
class UseAttribute { }
```

```C#
[AttributeUsage(AttributeTargets. All)]
public class RemarkAttribute : Attribute
{
    string remark;

    public RemarkAttribute(string comment)
    {
        remark = comment;
    }
    public string Remark
    {
         get { return _remark; }
    }
}

```
#### Области применения

```C#
[assembly: SomeAttr] // Applied to assembly
[module: SomeAttr] // Applied to module

[type: SomeAttr] // Applied to type
class SomeType<[typevar: SomeAttr] T> // Applied to generic type variable
{
    [field: SomeAttr] // Applied to field
    public int SomeField = 0;

    [return: SomeAttr] // Applied to return value
    [method: SomeAttr] // Applied to method
    public int SomeMethod([param: SomeAttr] int SomeParam)    //    Applied to parameter
    { 
        return SomeParam;
    }

    [property: SomeAttr]     // Applied to property
    public String SomeProp
    {
        [method: SomeAttr]
        get { return null; } // Applied to get accessor method
    }
    [event: SomeAttr] // Applied to event
    [field: SomeAttr] // Applied to compiler-generated field
    [method: SomeAttr] // Applied to compiler-generated add & remove methods
    public event EventHandler SomeEvent;
}
```

```c#
[Flags, Serializable]
public enum AttributeTargets
{
    Assembly = 0x0001,
    Module = 0x0002,
    Class = 0x0004,
    Struct = 0x0008,
    Enum = 0x0010,
    Constructor = 0x0020,
    Method = 0x0040,
    Property = 0x0080,
    Field = 0x0100,
    Event = 0x0200,
    Interface = 0x0400,
    Parameter = 0x0800,
    Delegate = 0x1000,
    ReturnValue = 0x2000,
    GenericParameter = 0x4000,
    All = Assembly | Module | Class | Struct | Enum | Constructor
    | Method | Property | Field | Event | Interface | Parameter | Delegate | ReturnValue | GenericParameter
}
```
### Способы получения атрибутов
* IsDefined*
* GetCustomAttribute
* GetCustomAttributes
* GetCustomAttributesData

[img](https://github.com/IlyaGall/C-/blob/main/51%20%D0%90%D1%82%D1%80%D0%B8%D0%B1%D1%83%D1%82%D1%8B/img/3.JPG)

### Где используются кастомные атрибуты?
* Кастомная валидация
* Аспектно-ориентированное программирование
* Собственные мапперы
* Любые места, где нужно работать с классами, а не их экземплярами.

### Вопросы для проверки

* Что такое пользовательские атрибуты и зачем их создавать?

Пользовательские атрибуты — это определяемые пользователем теги метаданных, созданные на основе базового класса System.Attribute. Разработчики создают пользовательские атрибуты, чтобы аннотировать свой код метаданными, специфичными для предметной области.
 
* Можете ли вы объяснить шаги, необходимые для создания настраиваемого атрибута?

Чтобы создать настраиваемый атрибут, вы определяете новый класс, который наследуется от System.Attribute, и украшаете его атрибутом [AttributeUsage], чтобы указать его целевые элементы. При желании вы можете определить свойства, поля или методы в классе атрибутов для хранения дополнительной информации. 

* Приведите пример сценария, в котором вы будете использовать настраиваемый атрибут в проекте C#.

Распространенным сценарием использования настраиваемого атрибута является реализация правил декларативной авторизации в веб-приложении. Вы можете создать собственный атрибут [AuthorizeRole], который принимает параметр роли и применяет его к действиям или методам контроллера, упрощая логику управления доступом и повышая читаемость кода.

### Полезные ссылки

* https://learn.microsoft.com/en-us/dotnet/csharp/advancedtopics/reflection-and-attributes/
* http://csharpindepth.com/Articles/General/Beforefieldinit.aspx - Статья, где Джон Скит рассуждает про поведение BeforeFieldInit.
* https://github.com/SergeyTeplyakov/ObjectLayoutInspector - утилита для просмотра расположения объектов в памяти.
* http://sergeyteplyakov.blogspot.com/ - блог Сергея Теплякова, где ещё много всего интересного.
* https://referencesource.microsoft.com/#mscorlib/system/reflection/methodattributes.cs,22 - Исходный код с PrivateScope.
* https://www.youtube.com/watch?v=zAhOxraBsi0 - Обсуждение изменений ватрибутах в Microsoft


### практика

/*
 3 примера получения данных из атрибута
string remark;
remark = (typeof(UseAttribute).GetCustomAttribute(typeof(RemarkAttribute)) as RemarkAttribute).Remark;
remark = (typeof(UseAttribute).GetCustomAttributes(typeof(RemarkAttribute)).Single() as RemarkAttribute).Remark;
remark = typeof(UseAttribute).GetCustomAttributesData().Single(x => x.AttributeType == typeof(RemarkAttribute)).ConstructorArguments.First().Value.ToString();
 */


```C#
[CustomAttribyte("Mike", "2020-10-02", 11576)]
public class Class1
{

}
```

```C#
namespace CustomAttribyte
{

    /// [LastChange("Mike", "2020-10-02", 11576)]

    [AttributeUsage(AttributeTargets.Class)] //только для классов
    public class CustomAttribyte : Attribute
    {
        public string Name { get; }

        public string DateTime { get;}

        public int Number { get; }
       
        public CustomAttribyte(string name, string dateTime, int number)
        {
            Name = name;
            DateTime = dateTime;
            Number = number;
        }
    }
}
```


```C#

using System.Reflection;

namespace CustomAttribyte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            var collectionAt = typeof(Class1).GetCustomAttributes(typeof(CustomAttribyte)).First() as CustomAttribyte;
            if (collectionAt != null)
            {
                Console.WriteLine($"{collectionAt.Name} {collectionAt.DateTime} {collectionAt.Number} ");
            }
        }
    }
}
    ```