# Исключения и нюансы работы с ними
## Исключения (Exception)

### Определения, общая информация

Исключение (exception) – событие, означающее, что в программе что-то пошло не так (возникла ошибка) 

Выбросить (пробросить) исключение – вызвать событие исключения Некоторые ситуации возникновения исключений:

* Поделили на ноль
* Аргумент функции некорректный
* Доступ к полю неинициализированного объекта
* Выход за границы массива

Где могут появиться:
* Во время выполнения .NET Runtime (доступ к пустому объекту)
* Выбрасываются сторонними библиотеками
* Вызываются пользователем принудительно

### Как выглядят?

```C#
var a = 0;
var b = 4; 
Console.WriteLine(b/a);
```

[img](https://github.com/IlyaGall/C-/blob/main/52%20%D0%98%D1%81%D0%BA%D0%BB%D1%8E%D1%87%D0%B5%D0%BD%D0%B8%D1%8F%20%D0%B8%20%D0%BD%D1%8E%D0%B0%D0%BD%D1%81%D1%8B%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D1%8B%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/img/1.JPG)

### Исключения и управление состоянием

Конструируя тип (Классы) мы заранее представляем ситуации в которых он будет использоваться. В качестве имен существительные. Затем определяются свойства события, методы и тп . Форма определения этих членов становится интерфейсом типа. Именно члены определяют допустимые действия с типом и его экземплярами. Если член сборки не может решить возложенную на него задачу программа выбрасывает исключение.

```C#
internal seald class Account{
    public static
    void Transfer(Account from, Account to, Decimal amount)
    {
        form-=amount;
        to+-amount;
    }
}
```


### Механизм обработки исключений


```C#
private void SomeMethod()
{
    try
    {
        //Код, требующиий корректноно восстановления
        //или очистки ресурсов
    }
    catch(InvalidOperationException)
    {
        // Код восстановления работоспособности
        //после InvalidOperationException
    }
    catch(IOException)
    {
        // Код восстановления работоспособности
        //после IOException
    }
    catch{
        // Код восстановления работоспособности после всех остальных исключений
        // После прехвата исключений их обчно генерируют повторно
        //Рассмотрим эту тему позже
        throw;
    }
    finally
    {
        //Здесь находится код, выполняющий очистку ресурсов
        //после операций начатых в блоке try. Этот код
        //выполняется ВСЕГДА вне зависимости от наличия исключения
        //Код, следующий за блоком finally, выполняется, если в блоке
    }

    //не генерировалось исключение или если исключение было перехвачено
    //блоком catch, а новое не генерировалось
}
```

### CLS-совместимые и CLS-несовместимые исключения

[img](https://github.com/IlyaGall/C-/blob/main/52%20%D0%98%D1%81%D0%BA%D0%BB%D1%8E%D1%87%D0%B5%D0%BD%D0%B8%D1%8F%20%D0%B8%20%D0%BD%D1%8E%D0%B0%D0%BD%D1%81%D1%8B%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D1%8B%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/img/2.JPG)


```C#
private void SomeMethod()
{
    try
    {
        // Код, требующиий корректноно восстановления
        // или очистки ресурсов
    }
    catch(Exception e)
    {
        //    До C# 2.0 этот блок перехватывал только CLS-совместимые исключения
        // В С# это блок научился перехватывать также
        // CLS- несовместимые исключения
    }
    catch
    {
        // Во всех версия C# данный блок перехватывает
        // и совместимые, и не совместимые с CLS исключения
        throw; // повторная генерация прехваченного исключения
    }
}
```

## Как работать с исключением
### System.Exception

System.Exception – базовый класс исключений Все исключения наследуются на определенном уровне от
System.Exception
Принято все классы
исключений называть с
суффиксом Exception
* InvalidOperationException
* OutOfRangeException
* ArgumentNullException

[img](https://github.com/IlyaGall/C-/blob/main/52%20%D0%98%D1%81%D0%BA%D0%BB%D1%8E%D1%87%D0%B5%D0%BD%D0%B8%D1%8F%20%D0%B8%20%D0%BD%D1%8E%D0%B0%D0%BD%D1%81%D1%8B%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D1%8B%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/img/3.JPG)

### Иерархия исключений

[img](https://github.com/IlyaGall/C-/blob/main/52%20%D0%98%D1%81%D0%BA%D0%BB%D1%8E%D1%87%D0%B5%D0%BD%D0%B8%D1%8F%20%D0%B8%20%D0%BD%D1%8E%D0%B0%D0%BD%D1%81%D1%8B%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D1%8B%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/img/4.JPG)
    
### Генерация собственных исключений

```C#
///<summary>
///Мое собственное исключение
///</summary>
class MyCystomException:Exception
{

}
```

### Варианты перехвата
* try catch
* try catch finally
* AppDomain.CurrentDomain.UnhandledException
* Application.ThreadException (WinForms, WPF)

### Stacktrace
* Содержит цепочку вызовов методов до места, где произошло исключение (с точностью номера строки)
* Можно получить и Environment.StackTrace
* Можно использовать System.Diagnostic.StackTrace

## Операторы

### Общее, синтаксис

```C#
try
{
    if (b == 0)
    {
        throw new DivideByZeroException("Делим на ноль");
    }
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

### throw– оператор вызова исключения

```C#
try
{
    if (b == 0)
    {
        throw new DivideByZeroException("Делим на ноль");
    }
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

Синтаксис
```
throw объект_класс_exception_или_производного
```

### throw , варианты использования

Можно так:

```throw new Exception("Я сообщение об ошибке");```

А можно так:
```C#
var ex = new Exception("Я cообщение о6 ошибке"); 
ex.Data.Add("a", "2");
throw ex;
```

### try\catch

```C#
try
{
    if (b == 0)
    {
        throw new DivideByZeroException("Делим на ноль");
    }
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

### try catch

* try catch – операторы перехвата исключений
* try {} – объявляет область кода, где потенциально может выбрасываться исключение
* catch{} – «ловит» исключение из блока try и обрабатывает данную ситуацию

Синтаксис:

```C#
try
{
    // Здесь может быть какой-то код
}
catch (Exception exc)
{
    // А здесь происходит обработка исключения ехс
    // вызванного в каком-то коде
}
```

### try catch ловим разные типы исключений

```C#
try
{
    // Здесь может быть какой-то код
}
catch (FooException exc)
{ 
    // Если какой-то код выкинул FooException 
} catch (BarException exc) 
{
    // Если какой-то код выкинул BarException
}
```

### try catch кидаем дальше

```C#
try
{
// Здесь может быть какой-то код 
}
catch (Exception exc)
 {
    ОбработкаИсключения (ехс); // пробрасываем то же исключение
     throw;
 }
```
## finally

* finally – оператор выполнения кода после всех обработок
* может использоваться конструкция try{}finally{} без catch{}
* Блок внутри выполняется всегда, есть исключение или нет
* в блоке нельзя возвращать что-то (return)
* используется в различных инструкциях представляющих синтаксический сахар lock, using,foreach, при определении деструктора

```C#
double Divide(int a, int b) 
{
    try
    {
        Console. WriteLine("Я блок try"); 
        return a / b;
    }
    catch (Exception)
    {
         Console. WriteLine("Произошла ошибка");
         return 0;
    } 
    finally 
    {
        Console. WriteLine("Я блок finally");
    }
}
```

[img](https://github.com/IlyaGall/C-/blob/main/52%20%D0%98%D1%81%D0%BA%D0%BB%D1%8E%D1%87%D0%B5%D0%BD%D0%B8%D1%8F%20%D0%B8%20%D0%BD%D1%8E%D0%B0%D0%BD%D1%81%D1%8B%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D1%8B%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/img/5.JPG)
    
## Порядок перехвата исключений

```C#
// Исключение-болезнь
class IllnessException : Exception { } 
// Микробная болезнь 
class MicrobeException : IllnessException { } 
// Вирусная болезнь 
class VirusException : IllnessException { }
```


```C#
static void DemoCure()
try
{
    live();

} 
catch (VirusException) 
{
    // тут ловим только VirusException
} catch (IllnessException) 
{
    // тут ловим IllnessException и производные, 
    // в т.ч. MicrobeException 
    // НO HE VirusException 
}catch(Exception)
{
    // тут ловим все остальные исключения
}
```


```C#
try
{
    try 
    {
        int.Parse(Console.ReadLine()); 
    }  
    catch (FormatException e)
    {
         Console. WriteLine($"Внутри: {e.Message}"); 
    }
}
catch (Exception e) 
{
    Console. WriteLine($"Снаружи: {e.Message}");
} 
```

### Порядок перехвата исключений (условные)


```C#
int GetItem(int[] arr, int index)
{

    try
    {
        return arr[index];
    }
     catch (Index0utOfRangeException) when (index < 0) {
        // IndexOutOfRangeException для index < 0
        Console. WriteLine("Индекс меньше ноля"); 
     }catch (Index0ut0fRangeException)
     {
         // Index0utOfRangeException в остальных случаях 
         Console. WriteLine("Индекс аут оф рэндж");
     }
      catch
       {
        // остальные ошибки 
        Console. WriteLine("Другая ошибка");
       }
}

```

## Best practices

* Исключения – для получения источника проблемы
* Создание исключения – дорого, надо пользоваться аккуратно
* Как следствие – если ошибка предсказуема (бизнес данные некорректны) – оформить ошибку без выброса исключения
* Пример: парсинг строки в тип – использовать TryParse, вместо Parse

```C#
try
{
    var s = int.Parse("s"); 
    Console. WriteLine(s);
} 
catch (Format Exception)
{
    Console. WriteLine("Некорректный формат");
} 
```

```C#
if (int.TryParse("s", out var s)) 
{
    Console. WriteLine(s);
}
 else 
{
     Console. WriteLine("Некорректный формат");
}
```

* Важно неповрежденное состояние приложения, а не продуктивность вместо надежности
* Не нужно перехватывать все исключения
* Не должно быть пустых блоков Catch
* Не должно быть блоков Catch для обработки всех исключений без throw
* Логируйте исключения

Список материалов для изучения
1. https://learn.microsoft.com/ru-ru/dotnet/standard/exceptions/
2. https://referencesource.microsoft.com/#mscorlib/system/exception.cs,f092fb2b893a0162
3. https://otus.ru/journal/vidy-oshibok-programmnogo-obespecheniya-bagi/
4. https://learn.microsoft.com/ru-ru/dotnet/csharp/fundamentals/exceptions/
5. https://learn.microsoft.com/en-us/dotnet/api/system.appdomain.firstchanceexception?view=net-8.0
6. https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.runtimewrappedexception?view=net-8.0
7. https://learn.microsoft.com/ru-ru/dotnet/standard/exceptions/best-practices-for-exceptions
8. https://learn.microsoft.com/ru-ru/dotnet/api/system.exception?view=net-8.0
9. https://learn.microsoft.com/en-us/dotnet/standard/exceptions/exception-class-and-properties
10. https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.contracts?view=net-8.0
11. https://pediaa.com/what-is-the-difference-between-error-and-exception-in-c/
12. https://learn.microsoft.com/ru-ru/archive/msdn-magazine/2009/february/clr-inside-out-handling-corrupted-state-exceptions
13. https://learn.microsoft.com/en-us/archive/msdn-magazine/2009/february/clr-inside-out-handling-corrupted-state-exceptions
14. https://learn.microsoft.com/en-us/aspnet/web-forms/overview/older-versions-getting-started/deploying-web-site-projects/processing-unhandled-exceptions-cs
15. https://learn.microsoft.com/en-us/dotnet/framework/configure-apps/file-schema/runtime/legacycorruptedstateexceptionspolicy-element
16. https://learn.microsoft.com/ru-ru/dotnet/fundamentals/code-analysis/quality-rules/ca2153
17. https://learn.microsoft.com/en-us/windows/win32/seccrypto/common-hresult-values
18. https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/finalizers
19. https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/statements/using
20. https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/statements/lock
21. https://gitlab.com/otus-demo/exceptions
22. https://learn.microsoft.com/ru-ru/dotnet/framework/interop/how-to-map-hresults-and-exceptions
