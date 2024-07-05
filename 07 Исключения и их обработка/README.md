## Что такое
Исключение (exception) – событие, означающее, что в программе что-то 
пошло не так (возникла ошибка)
Выбросить (пробросить) исключение – вызвать событие исключения
• Поделили на ноль
• Аргумент функции некорректный
• Доступ к полю неинициализированного объекта
• Выход за границы массива

### Когда могут появляться
• Во время выполнения .NET Runtime (доступ к 
пустому объекту)
• Выбрасываются сторонними библиотеками
• Вызываются пользователем принудительно

### Как выглядят
```C#
var a = 0;
var b = 4;
Console.WriteLine(b / a);
```

## Немного про классы
Тип для описания какого-то сложного объекта, с разными функциями, полями и 
пр.
```c#
// Это класс под названием 
// Транспортное средство
class Vehicle
{
 // у него есть свойство Название
 public string Name;
}
```

### System.Exception
System.Exception – базовый класс исключений
Все исключения наследуются на определенном уровне от 
System.Exception
Принято все классы исключений называть с суффиксом Exception
• InvalidOperationException
• OutOfRangeException
• ArgumentNullException


### Собственные исключения
```c#
/// <summary>
/// Мое собственное исключение
/// </summary>
class MyCystomException : Exception
{
}
```


### Свойства
• Message – сообщение в исключении
• StackTrace – текстовая информация с порядком вызова места 
исключения
• InnerException – исключение, вызвавшее данное (если есть)
• Data – словарь ключ-значение с доп. данными (например, 
параметрами функции)
• TargetSite – информация о методе, где произошла ошибка



### Операторы

### Общее, синтаксис
```c#
try
{
 if (b == 0)
 throw new DivideByZeroException("Делим на ноль");
 return a / b;
}
catch (Exception e)
{
 Console.WriteLine("Произошла ошибка");
 return 0.0;
}
finally
{
 Console.WriteLine("Я блок finally ");
}
```

### throw
```c#
try
{
 if (b == 0)
 throw new DivideByZeroException("Делим на ноль");
 return a / b;
}
catch (Exception e)
{
 Console.WriteLine("Произошла ошибка");
 return 0.0;
}
finally
{
 Console.WriteLine("Я блок finally ");
}
```

throw – оператор вызова исключения
Синтаксис
throw объект_класс_exception_или_производного


Можно так
```c#
throw new Exception("Я сообщение об ошибке");
```
А можно так
```c#
var ex = new Exception("Я сообщение об ошибке");
ex.Data.Add("a", "2");
throw ex;
```


### try catch

```c#
try
{ 
 // Здесь может быть какой-то код
}
catch (Exception exc)
{
 // А здесь происходит обработка исключения exc
 // вызванного в каком-то коде
}
```


```c#
try
{
 if (b == 0)
 throw new DivideByZeroException("Делим на ноль");
 return a / b;
}
catch (Exception e)
{
 Console.WriteLine("Произошла ошибка");
 return 0.0;
}
finally
{
 Console.WriteLine("Я блок finally ");
}
```
try catch – операторы перехвата исключений
try {} – объявляет область кода, где потенциально 
может вызываться исключение
catch{} – «ловит» исключение из блока try, где 
можно его обработать

```c#
try
{ 
 // Здесь может быть какой-то код
}
catch (FooException exc)
{
 // Если какой-то код выкинул FooException
}
catch (BarException exc)
{
 // Если какой-то код выкинул BarException

```

### try catch без выбрасывания throw

```c#
try
{ 
 // Здесь может быть какой-то код
}
catch (Exception exc)
{
 ОбработкаИсключения(exc);
 // пробрасываем то же исключение
 throw;
}
```

### finally(срабатывает даже если есть return)

finally – оператор выполнения кода после всех обработок
• Блок внутри выполняется всегда, есть исключение или нет
• в блоке нельзя возвращать что-то (return)



```C#
try
{
 if (b == 0)
 throw new DivideByZeroException("Делим на ноль");
 return a / b;
}
catch (Exception e)
{
 Console.WriteLine("Произошла ошибка");
 return 0.0;
}
finally
{
 Console.WriteLine("Я блок finally ");
}

```
![Image alt](https://github.com/IlyaGall/C-/blob/main/06%20%D0%9C%D0%B0%D1%81%D1%81%D0%B8%D0%B2%20%D0%B8%20%D0%BB%D0%B8%D1%81%D1%82/img/1.PNG)

```C#
double Divide(int a, int b)
{
 try
 {
 Console.WriteLine("Я блок try");
 return a / b;
 }
 catch (Exception)
 {
 Console.WriteLine("Произошла
ошибка");
 return 0;
 }
 finally
 {
 Console.WriteLine("Я блок finally");
 }
}
```

### Порядок перехвата исключений
```c#
// Исключение-болезнь
class IllnessException : Exception { }
// Микробная болезнь
class MicrobeException : IllnessException { }
// Вирусная болезнь
class VirusException : IllnessException { }
```
Порядок перехвата исключений
```c#
static void DemoCure()
{
 try
 {
 Live();
 }
 catch (VirusException) 
 {
 // тут ловим только VirusException
 }
 catch (IllnessException) 
 {
 // тут ловим IllnessException и производные, 
 // в т.ч. MicrobeException 
 // НО НЕ VirusException
 }
 catch (Exception)
 {
 // тут ловим все остальные исключения
 }
}
```


### Перехват на разных уровнях функций
```C#
class RedException : Exception
{
    public RedException() : base("КОД КРАСНЫЙ")
    {
    }
    public RedException(string message) : base(message)
    {
    }
}
class PurpleException : RedException
{
    public PurpleException() : base("КОД ФИОЛЕТОВЫЙ")
    {
    }
}
```
### использование switch throw
```c#
void Throw(WhatToThrow a)
{
    switch (a)
    {
        case WhatToThrow.Red:
            throw new RedException();
        case WhatToThrow.Purple:
            throw new PurpleException();
        default:
             throw new InvalidOperationException($"Непонятная ошибка");
    }
}
```
```c#
static void Level2(WhatToThrow a)
{
    try
    {
          Throw(a);
    }
    catch (PurpleException e)
    {
         Console.Write($"LEVEL2: ФИОЛЕТОВОЕ '{e.Message}'");
    }
    catch (RedException e)
    {
         Console.Write($"LEVEL2: КРАСНОЕ '{e.Message}'");
        throw;
    }
}
     static void Level1(WhatToThrow a)
    {
    try
    {
        Level2(a);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Level1: Я жду любую ошибку
        '{e.Message}'");
    }
}
```
### Упрощаем catch

```c#
try
{
 // Тут какой-то код
}
catch (ArgumentNullException exception)
{
 // если в блоке с объектом
 // exception не работаем,
 // но важно перехватить именно 
//ArgumentNullException
 // exception можно убрать
}
```
упрощение еслм не нужно exception
```C#
try
{
 // Тут какой-то код
}
catch (ArgumentNullException)
{
 // на важен сам факт возникновения
 // ArgumentNullException
}
```


```c#
try
{
 // Тут какой-то код
}
catch (Exception)
{
 // Если в блоке ловим
 // любые исключения
 // и нам не нужно их содержание
// Exception убираем
}
try
{
 // Тут какой-то код
}
сatch
{
 // обрабатываем любые исключения
}
```

### Условные исключения  catch (IndexOutOfRangeException) when (index < 0)
```c#
int GetItem(int[] arr, int index)
{
 try
 {
 return arr[index];
 }
 catch (IndexOutOfRangeException) when (index < 0) // IndexOutOfRangeException для index 
< 0
 {
 Console.WriteLine("Индекс меньше ноля");
 }
 catch (IndexOutOfRangeException) // IndexOutOfRangeException в остальных случаях
 {
 Console.WriteLine("Индекс аут оф рэндж"); 
 }
 сatch // остальные ошибки
 {
 Console.WriteLine("Другая ошибка");
 }
 return 0;
}
```



