# ИсклĀùениā и нĀансý работý с ними
## ИсклĀùениā (Exception)

### Определениā, обûаā информаøиā

ИсклĀùение (exception) – собýтие, ознаùаĀûее, ùто в программе ùто-то поúло не так (возникла оúибка) 

Вýброситþ (проброситþ) исклĀùение – вýзватþ собýтие исклĀùениā Некоторýе ситуаøии возникновениā исклĀùений:

● Поделили на нолþ
● Аргумент функøии некорректнýй
● Доступ к полĀ неиниøиализированного обüекта
● Вýход за граниøý массива

Где могут поāвитþсā:
● Во времā вýполнениā .NET Runtime (доступ к пустому обüекту)
● ВýбрасýваĀтсā сторонними библиотеками
● ВýзýваĀтсā полþзователем принудителþно

### Как вýглāдāт?

```C#
var a = 0;
var b = 4; 
Console.WriteLine(b/a);
```

[img](https://github.com/IlyaGall/C-/blob/main/52%20%D0%98%D1%81%D0%BA%D0%BB%D1%8E%D1%87%D0%B5%D0%BD%D0%B8%D1%8F%20%D0%B8%20%D0%BD%D1%8E%D0%B0%D0%BD%D1%81%D1%8B%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D1%8B%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/img/1.JPG)

### ИсклĀùениā и управление состоāнием

Конструируā тип (Классý) мý заранее представлāем ситуаøии в которýх он будет исполþзоватþсā. В каùестве имен суûествителþнýе. Затем определāĀтсā свойства собýтиā, методý и тп . Форма определениā ÿтих ùленов становитсā интерфейсом типа. Именно ùленý определāĀт допустимýе действиā с типом и его ÿкземплāрами. Если ùлен сборки не может реúитþ возложеннуĀ на него задаùу программа вýбрасýвает исклĀùение.

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


### Механизм обработки исклĀùений


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

### CLS-совместимýе и CLS-несовместимýе исклĀùениā

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

## Как работатþ с исклĀùением
### System.Exception

System.Exception – базовýй класс исклĀùений Все исклĀùениā наследуĀтсā на определенном уровне от
System.Exception
Принāто все классý
исклĀùений назýватþ с
суффиксом Exception
• InvalidOperationException
• OutOfRangeException
• ArgumentNullException

[img](https://github.com/IlyaGall/C-/blob/main/52%20%D0%98%D1%81%D0%BA%D0%BB%D1%8E%D1%87%D0%B5%D0%BD%D0%B8%D1%8F%20%D0%B8%20%D0%BD%D1%8E%D0%B0%D0%BD%D1%81%D1%8B%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D1%8B%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/img/3.JPG)

### Иерархиā исклĀùений

[img](https://github.com/IlyaGall/C-/blob/main/52%20%D0%98%D1%81%D0%BA%D0%BB%D1%8E%D1%87%D0%B5%D0%BD%D0%B8%D1%8F%20%D0%B8%20%D0%BD%D1%8E%D0%B0%D0%BD%D1%81%D1%8B%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D1%8B%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/img/4.JPG)
    
### Генераøиā собственнýх исклĀùений

```C#
///<summary>
///Мое собственное исключение
///</summary>
class MyCystomException:Exception
{

}
```

### Вариантý перехвата
● try catch
● try catch finally
● AppDomain.CurrentDomain.UnhandledException
● Application.ThreadException (WinForms, WPF)

### Stacktrace
● Содержит цепочку вызовов методов до места, где произошло исключение (с точностью номера строки)
● Можно получить и Environment.StackTrace
● Можно использовать System.Diagnostic.StackTrace

## Операторý

### Обûее, синтаксис

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

### throw– оператор вýзова исклĀùениā

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

### throw , вариантý исполþзованиā

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

* try catch – операторý перехвата исклĀùений
* try {} – обüāвлāет областþ кода, где потенøиалþно может вýбрасýватþсā исклĀùение
* catch{} – «ловит» исклĀùение из блока try и обрабатýвает даннуĀ ситуаøиĀ

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

### try catch ловим разнýе типý исклĀùений

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

### try catch кидаем далþúе

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

● finally – оператор вýполнениā кода после всех обработок
● может исполþзоватþсā конструкøиā try{}finally{} без catch{}
● Блок внутри вýполнāетсā всегда, естþ исклĀùение или нет
● в блоке нелþзā возвраûатþ ùто-то (return)
● исполþзуетсā в разлиùнýх инструкøиāх представлāĀûих синтаксиùеский сахар lock, using,foreach, при определении деструктора

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
    
## Порāдок перехвата исклĀùений

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

### Порāдок перехвата исклĀùений (условнýе)


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

● Исключения – для получения источника проблемы
● Создание исключения – дорого, надо пользоваться аккуратно
● Как следствие – если ошибка предсказуема (бизнес данные некорректны) – оформить ошибку без выброса исключения
● Пример: парсинг строки в тип – использовать TryParse, вместо Parse

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

● Важно неповрежденное состоāние приложениā, а не продуктивностþ вместо надежности
● Не нужно перехватýватþ все исклĀùениā
● Не должно бýтþ пустýх блоков Catch
● Не должно бýтþ блоков Catch длā обработки всех исклĀùений без throw
● Логируйте исклĀùениā

Список материалов длā изуùениā
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
