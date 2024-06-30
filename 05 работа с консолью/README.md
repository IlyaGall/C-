## System.Console
* Console (пространство System) – класс для работы с консолью (командной строкой)
Будем использовать:
* Для вывода – Console.Write(), Console.WriteLine()
* Для ввода – Console.ReadLine(), Console.Read(), Console.ReadKey()

## Вывод данных (Write и WriteLine)

**Console.Write(аргументы)** – выводит в консоль текст.
* Console.Write("Привет");
* Console.Write(2);
* Console.Write(true);
* Console.Write(new {A=2});
**Console.WriteLine(аргументы)** – Console.Write, но с переводом на новую
строку


Значения можно менять согласно формату, значение – двоеточие – формат
```c#
Console.WriteLine($“Пример {значение:формат}");
```


```c#
Console.WriteLine($“Дата {DateTime.Now:MMdd-yyyy HH:mm}"); //08-19-2021 20:00
Console.WriteLine($HEX {243:X}"); // HEX F3
Console.WriteLine($"4 знака{12.34567890:n4}");//4 знака 12,3456
Console.WriteLine($"День недели{DateTime.Now:dddd}");//День недели среда
```

### пример кода
```c#
   public class SimpleClass
   {
       private int _a;
       public SimpleClass(int a)
       {
           _a = a;
       }


       ///// <summary>
       ///// Когда объекта класс SimpleClass выводим в Console.WriteLine
       ///// Вызывается этот метод
       ///// </summary>
       ///// <returns></returns>
       public override string ToString()
       {
           return $"{{ ! \"a\"!: {_a} }}";
       }
   }
        /// <summary>
        /// Простой вывод данных
        /// </summary>
        private static void Simple()
        {
            Console.WriteLine("Выводим обычный текст с переводом строки");
            Console.WriteLine(1);
            Console.WriteLine(true);
            Console.WriteLine(DateTime.Now);
            Console.Write("Привет,");
            Console.Write(" Otus!");
            // Когда дойдем до сюда - надо нажать любую клавишу
            Console.ReadKey();
            Console.WriteLine();
            var obj = new SimpleClass(4);

            var ru = "1. Я пишу текст '{0}' и число {1} и даже объект {2}";
            var en = "1. Я пишу текст english '{0}' и число {1} и даже объект {2}";
            Console.WriteLine("1. Я пишу текст '{0}'  и число {1} и даже объект {2}",
                                "Привет", 2, obj.ToString());
            var sss = "Привет";
            Console.WriteLine($"\t2. Я пишу текст {sss} и число {2}\nи даже объект {obj} div={Div(100, 25)}");
        }

/// <summary>
/// Форматируемый вывод
/// </summary>
private static void Formatted()
{
    //CultureInfo.CurrentCulture = new CultureInfo("en-US");
    var s = $"Вот дата обычная {DateTime.Now:dd.MM}";
    var c = DateTime.Now;
    Console.WriteLine($"Вот дата обычная {DateTime.Now}");
    Console.WriteLine($"Вот дата форматируемая {DateTime.Now:MM,dd'/'yyyy HH:mm}");
    var rubn = $"Выводим с валютой согласно языку операционной системы {100:C}";
    Console.WriteLine($"Выводим 4 знака после запятой {222212.345677890:n4}");
    Console.WriteLine($"Выводим с валютой согласно языку операционной системы {100:C}");
    Console.WriteLine($"Шестнадцатиричной системой {243:X}");
    Console.WriteLine($"День недели {DateTime.Now:dddd}");
    Console.ReadKey();
}

```

## Ввод данных(Read, ReadKey, ReadLine)

* int Console.Read() – возвращает числовой код введенного символа в Unicode
* ConsoleKeyInfo Console.ReadKey() – возвращает информацию о нажатии клавиши (название клавиши, символ под ней, информацию о ctrl, shift и пр.)
* string Console.ReadLine() – возвращает введенную строку (после нажатия Enter)


### Работа с вводом
Парсинг

Парсинг – преобразование строки к определенному типу
* Пользователь вводит данные строкой
* Но строки не всегда подходят
* Например, пользователь вводит числа – мы проводим арифметические операции (сложение/вычитание)
* И тут приходит на помощь парсинг

### Парсинг – варианты использования(parse,TryParse)
```c# 
Тип.Parse(inputString);
```
Если строку inputString можно преобразовать к типу Тип – функция вернет значение, если нет – ошибка программы

```C#
bool Тип.TryParse(inputString, out var i);
```
Если строку inputString можно преобразовать к типу Тип – функция вернет true, а значение запишется в i , если нет – вернет false


### Парсинг(по типам int, double, dateTime, **учёт региональных настроект**)
```c#
int.Parse("12345"); // Преобразовать строку "12345" в тип int (12345)
bool.Parse("true"); // Преобразовать строку "true" в тип bool (true)
DateTime.Parse("11.12.2021") // Преобразовывает строку "11.12.2021" в дату Дата (11 декабря 2021 года)
double.Parse("987,65")  // Преобразовывает строку "987,65" в число с плавающей точкой но только для языков, где так принято писать дробные числа (например Россия), для английской операционной системы - ошибка Число 987.65
double.Parse("987,65", new CultureInfo("ru-RU")) // Преобразовывает строку "987,65" в число с плавающей точкой именно в российском формате (ru-RU) Число 987.65

```

```c#
 public static void ShowReadLine()
 {
     string inputString;
     do
     {
         Console.Write("Введите целое число: ");
         inputString = Console.ReadLine();
         if (inputString != "")
         {

         }
         //var i = int.Parse(inputString);
         //Console.WriteLine($"Вы ввели строку, если прибавим к ней 100 то получим {i + 100}"); ;

         //var i = int.Parse(inputString);
         //Console.WriteLine($"Вы ввели строку, если прибавим к ней 1 то получим {i + 1}"); ;
         //var parsed = int.TryParse(inputString, out var i);

         //int i;
         var parsed = int.TryParse(inputString, out var i);

         if (parsed)
         {
             Console.WriteLine($"Вы ввели строку, если прибавим к ней 1 то получим {i + 1}"); ;
         }
         else
         {
             Console.WriteLine($"Вы ввели строку в некорректном формате '{inputString}'"); ;
         }
     } while (inputString != "");
 }
```

## функции консоли

* Console.Clear() – очищает консоль
* Console.SetCursorPosition(left, top) – устанавливает позицию курсора (слева и сверху консоли)
* Console.BackgroundColor, Console.ForegroundColor – цвет фона (BackgroundColor), и шрифта (ForegroundColor). Доступные значения из ConsoleColor


```c#
Console.Write("Я обычный текст");
// Делаем фон красным
Console.BackgroundColor = ConsoleColor.Red;
// А текст зеленым
Console.ForegroundColor = ConsoleColor.Green;
Console.Write("Ш");
Console.ResetColor();
Console.Write("Я продолжение обычный текст");
Console.WriteLine("Я обычный текст");
// Делаем фон красным
Console.BackgroundColor = ConsoleColor.Red;
// А текст зеленым
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("А я зеленый на красном");
Console.ResetColor();
Console.WriteLine("Я снова в обычном режиме");
```
### крутилка в консоли
```c#
    /// <summary>
    /// Крутилка в консоли (демонстрация CursorPosition)
    /// </summary>
    private static void Krutilca()
    {
        var a = new char[] { '\\', '|', '/', '-' };

        Console.Write("\\ Начинаем крутится");
        var i = 0;

        do
        {
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            Console.Write(a[(i++) % 4]);
            Thread.Sleep(300);
            // Прокручиваем 12 раз
        } while (i < 48);
    }
```
