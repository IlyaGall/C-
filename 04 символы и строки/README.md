## кодировка

Определение

Кодировка – таблицы сопоставления символа и последовательности 
байт
Примеры
* ASCII
* Unicode
* CP1251
* КОИ-8


### ASCII

7-битная кодировка (т.е. доступно 7 бит для кодирования 
символов)
* Максимум – 128 символов
* Символы
* Английский алфавит
* Цифры
* Знаки препинания
* Управляющие символы

![Image alt](https://github.com/IlyaGall/C-/blob/main/04%20%D1%81%D0%B8%D0%BC%D0%B2%D0%BE%D0%BB%D1%8B%20%D0%B8%20%D1%81%D1%82%D1%80%D0%BE%D0%BA%D0%B8/img/3.PNG)


### UNICODE


Кодировка, содержащая поити все символы мирового алфавита
* Пространство – 4 байта (около 4 млрд. возможных символов)
* Содержит в себе ASCII
* Есть блоки под национальные алфавиты
* Есть зарезервированные места под новые символа
* Есть даже ÿмодзи

Примеры диапазонов

* U+0000…U+007F – Латиница
* U+0400…U+04FF – Кириллица
* U+0600…U+06FF – Арабское письмо
* U+16A0…U+16FF – Руны
* U+1F600…U+1F64F – Эмотиконы

```C#

```

### UTF-8, UTF-16, UTF-32

* UTF-8 – кодирует символы Юникода в размере от 1 до 4 байт. 
Основная кодировка в веб-приложениях
* UTF-16 – кодирует каждый символ в виде одного или двух 16-
битных слов. Используется в CLR Для кодирования
* UTF-32 – кодирует каждый символ в виде 32-битного иисла 
(прямой номер символа в юникоде)

### UTF-8

![Image alt](https://github.com/IlyaGall/C-/blob/main/04%20%D1%81%D0%B8%D0%BC%D0%B2%D0%BE%D0%BB%D1%8B%20%D0%B8%20%D1%81%D1%82%D1%80%D0%BE%D0%BA%D0%B8/img/6.PNG)


```c#
#region UTF-8

// Кодируем запятую

var c = ",";
var emAr = Encoding.GetEncoding("UTF-8").GetBytes(c);
Console.WriteLine($"1. , = {FormatBytes(emAr)}");

// 00101100


// Кодируем букву Б
c = "Б";
emAr = Encoding.GetEncoding("UTF-8").GetBytes(c);
Console.WriteLine($"2. Б = {FormatBytes(emAr)}");
// 110   10000 10   010001
// 10000010001

//// 110  10000 10  010001
//// 10000010001


// Кодируем эмоджи

c = "🤖";
emAr = Encoding.GetEncoding("UTF-8").GetBytes(c);
Console.WriteLine($"3. 🤖 = {FormatBytes(emAr)}");

// 11110  000 10  011111 10  100100 10  010110
// 000011111100100010110


#endregion
```

### UTF-16

Символы Unicode до FFFF16 включительно (исключая диапазон для суррогатов) записываются 
как есть 16-битным словом.
Символы же в диапазоне 1000016..10FFFF16 (больше 16 бит) кодируются по следующей схеме:
* Из кода символа вычитается 1000016. В результате получится значение от нуля до FFFFF16, 
которое помещается в разрядную сетку 20 бит.
* Старшие 10 бит (число в диапазоне 000016..03FF16) суммируются с D80016, и результат идёт в 
ведущее (первое) слово, которое входит в диапазон D80016..DBFF16.
* Младшие 10 бит (тоже число в диапазоне 000016..03FF16) суммируются с DC0016, и 
результат идёт в последующее (второе) слово, которое входит в диапазон DC0016..DFFF16


🤖= yyyyyyyyyyxxxxxxxxxx /🤖 - 0x10000

W1 = 110110yyyyyyyyyy / 0xD800 + yyyyyyyyyy

W2 = 110111xxxxxxxxxx/ 0xDC00 + xxxxxxxxxx

### Base64

Стандарт кодирования двоичных данных при помощи 64 символа 
алфавита Используются
* 0-9 (10 символов)
* A-Z, a-z (52 символа)
* 2 символа в зависимости от реализации
Рассмотрим реализацию MIME (используется в ÿлектронной почте)
* Используем дополнительно ‘+’ и ‘/’ и добиваем для кратности 3 символом 
‘=‘

![Image alt](https://github.com/IlyaGall/C-/blob/main/04%20%D1%81%D0%B8%D0%BC%D0%B2%D0%BE%D0%BB%D1%8B%20%D0%B8%20%D1%81%D1%82%D1%80%D0%BE%D0%BA%D0%B8/img/7.PNG)


```C#
#region UTF-16

c = "Б";
var emAr1 = Encoding.GetEncoding("UTF-16").GetBytes(c);
Console.WriteLine($"4. Б = {FormatBytes(emAr1)}");
// 00010001 00000100
// 00000100 00010001

//// 11110000 10011111 10100100 10010110
//// 000011111100100010110


c = "🤖";
emAr1 = Encoding.GetEncoding("UTF-16").GetBytes(c);
Console.WriteLine($"5. 🤖 = {FormatBytes(emAr1)}");

//  00111110 11011000    00010110 11011101
// 110110 0000111110     110111 0100010110
// 00001111100100010110
// 63766 + 65536
// 129302

// 00111110 11011000         00010110 11011101
// 1101100000111110          1101110100010110
// 110110    0000111110          110111     0100010110
// 00001111100100010110

// 63766 + (0x10000)65536

#endregion
```


```c#

#region base-64

var p = "Привет";

var pUtf16 = Encoding.GetEncoding("UTF-16").GetBytes(p);

//// Encoding.GetEncoding("UTF-8")
var pUtf8 = Encoding.UTF8.GetBytes(p);


Console.WriteLine($"UFT8 - {FormatBytes(pUtf8)}");
Console.WriteLine($"UFT16 - {FormatBytes(pUtf16)}");


var pb64Utf16 = Convert.ToBase64String(pUtf16);
var pb64Utf8 = Convert.ToBase64String(pUtf8);

Console.WriteLine("UTF16base64: "+pb64Utf16);

Console.WriteLine("UTF8base64: "+pb64Utf8);

var backUtf16 = Convert.FromBase64String(pb64Utf16);
var backUtf8 = Convert.FromBase64String(pb64Utf8);
Console.WriteLine("backUtf16 " + FormatBytes(backUtf16));
Console.WriteLine("backUtf8 " + FormatBytes(backUtf8));

var backstring = Encoding.GetEncoding("UTF-16").GetString(backUtf16);

#endregion

#region char

var ch1 = '2';
Console.WriteLine(char.IsWhiteSpace('r'));
Console.WriteLine(char.ToUpper('r'));
Console.WriteLine(char.IsPunctuation('.'));
//// var emojiC = '🤖'; // Будет ошибка

#endregion
```














### C# кодирование

```c#
var privet = "Привет";
var bytes = Encoding.UTF8.GetBytes(privet); 
var b64 = Convert.ToBase64String(bytes);
var checkBytes = Convert.FromBase64String(b64);
var s = Encoding.UTF8.GetString(checkBytes);
Console.WriteLine(s);
```

```c#
///для удобного представления данных
static string FormatBytes(byte[] b)
{
    return string.Join(' ', b.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
}
```



## char

char – тип символа
* 2 байта
* UTF-16
Можно указывать значения
* Явно
char c = 'j’;
* Escape-последовательность \x с шестнадцатиричном представлении
char c = '\x6A’; // После \x от 1 до 4 символов
* Escape-последовательность \u с шестнадцатиричном 
представлении Unicode
char c = '\u006A';





## string
String – последовательность UTF-16 символов
var s = "Привет"; 
var em = "🤖";




###  @-вербатим

@”Строка” – выводит строку «буквально»

```c#
var s1 = "c:\\Windows\\System32";
var s2 = @"c:\Windows\System32";
var s3 = @"Текст с ""двойной кавычкой""";
```

### $-интерполяция



```c#
var who = "otus";
var s1 = 
"Привет {who}";
var s2 = $"Привет {who}";
Console.WriteLine(s1); // Привет {who}
Console.WriteLine(s2); // Привет otus
```


### $ интерполяция - формат

{<Выражение>[,<Выравнивание>][:<Формат>]}
* <Выражение> - Выражение (функция, переменная)
* <Выравнивание> - (необяз.) Количество символов для выравнивание (положительное – по правому краю, отрицательное – по левому)
* <Формат> - (необяз.) формат выражения



пример: 
Позволяет писать строки с выражениями
```c#
Console.WriteLine($"Сегодня |{DateTime.Now,20:dd'/'MM'/'yyyy}|"); // сегодня 24/11/2021|
```





```c#
#region string

Console.WriteLine("C:\\Windows \" ");

Console.WriteLine(@"C:\\Windows""");
Console.WriteLine("""
    {  
    }
    """);

var pr = 12414.61264;

Console.WriteLine(pr + " Otus");
var s = "fancy";
Console.WriteLine($"Todays is a lesson, and i {s} say {pr} otus");
Console.WriteLine(string.Format("1. Todays is a lesson, and i say {0} otus {1} {0} {2}", pr, 2142, true));
Console.WriteLine($"Today is a {DateTime.Now:dd'/'MM'/'yyyy}, and i say |{pr,20:C}| |{s,-10}| otus");

#endregion
```
### StringBuilder (не достатки string)


Можно так
var privet = "Привет";
privet += " Otus";

И так

var privet = string.Concat("Привет", " Otus“);

Но есть недостатки
* Если строки конкатенируются в цикле – создается много строк
* Как следствие – тратится лишняя память и время на создание строк


Решение - StringBuilder

```c#
StringBuilder – класс для конкатенации строк
var me = "Эдгар";
// Объявляем класс - StringBuilder 
var sb = new StringBuilder();
// Соединяем строк 
sb.Append("Привет");
sb.Append("Otus");
sb.AppendFormat(", Меня зовут {0}", me);
// Получаем итоговую строку 
var res = sb.ToString(); 
Console.WriteLine(res);
```

еще один пример работы со строками

```c#
#region StringBuilder

var name = "Lusparon";
var sb = new StringBuilder("Start ");
sb.Append("Privet");
sb.Append(" Otus, ");
sb.AppendFormat("My name is {0}", name);
sb.AppendFormat($"My interpolation name is {name}");
sb.AppendLine("With newline");
sb.Append("KAVYCHKI");
sb.AppendJoin(",", "raz", "dva", "tri", "chetyre");
sb.Append("\r\n");
sb.Append("Finish");
sb.Replace()

//var finalString = sb.ToString();
Console.WriteLine(sb);

//ShowStringBuilder();

#endregion
```










### тест производительности string и stringBulder

```c#
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

static void ShowStringBuilder()
{
    var stopwatch = new Stopwatch();
    var times = 200000;
    var s = "";
    Console.WriteLine("Concat with += ");
    stopwatch.Start();
    for (var i = 0; i < times; i++)
    {
        s = s + 's';
    }
    stopwatch.Stop();

    Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}");




    Console.WriteLine("Concat with stringBuilder ");

    stopwatch.Reset();
    stopwatch.Start();
    var sb = new StringBuilder();

    for (var i = 0; i < times; i++)
    {
        sb.Append('s');
    }
    var s11 = sb.ToString();
    stopwatch.Stop();


    Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}");




    Console.WriteLine("Concat with Concat ");


    s = string.Empty;
    stopwatch.Reset();
    stopwatch.Start();
    for (var i = 0; i < times; i++)
    {
        s = String.Concat(s, 's');
    }

    stopwatch.Stop();



    Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}");

}


```



## Иммутабельность

Созданная строка – не меняется, совсем
```c#
var plus = "Плюс";
var minus = plus.Replace("Плюс", "Минус"); // Создалась новая строка!
Console.WriteLine($"{plus}, {minus}"); // Плюс, Минус
plus[1] = 'У'; // Даже не скомпилируется (в языке Си – можно)
```


## Длина строки (промбела длинных char "🤖",которые занимают 2 char)
String.Length – количество char в строке, не символов
```c#
var privet = "Привет"; 
Console.WriteLine(privet.Length); // 6

var em = "🤖";
Console.WriteLine(em.Length); // 2 – поскольку в один char
// не помещается, нужно 2
// Нам поможет класс StringInfo 
var si = new StringInfo(em);
Console.WriteLine(si.LengthInTextElements); // 1
```

## Сравнение строк

String – *класс*, но оператор == сравнивает *по значению*
```c#
var s1 = 
"Привет"; var s2 
= 
"Привет";
var areEqual = s1 == s2;
// В Java – false
// В C# – true
```


## ReferenceEquals

ReferenceEquals – сравнение, что две ссылки ссылаются на один обüект, а не конкретные значения
```c#
var vet = "вет";
var s1 = $"При
{vet}"; var s2 = $"При{vet}";
Console.WriteLine(s1 == s2);// true
Console.WriteLine(ReferenceEquals(s1, s2));
```


## Интернирование

```c#
var s1 = "Привет";
var s2 = "При" + "вет"; 
Console.WriteLine(s1 == s2); // true
Console.WriteLine(ReferenceEquals(s1, s2)); // ?
```

```C#
var s1 = "Привет";
var s2 = "При" + "вет"; 
Console.WriteLine(s1 == s2);// true
Console.WriteLine(ReferenceEquals(s1, s2)); // True

```



* В CLR (среда выполнения C#) – оптимизирована работа со строками
* Существует таблица – пул интернирования
* Пул интернирования – список всех используемых строк в программе
* Если строка задана явным образом – автоматически помещается в 
пул интернирования
* Соответственно – если у двух переменных явно указаны значения 
строк, то они ссылаются на одну переменную
* Если строка создается динамически (ввод пользователем, 
генерация функцией) – они не интернируются → занимают доп. 
память
* Но строки можно интернировать – при помощи string.Intern – и 
получить ссылку на строку из пула
* Если строка уже в пуле – string.Intern возвращает 
интернированную строку
```c#
var vet = "вет";
var s3 = $"При{vet}"; // s3 и s4 – ссылаются на разные строки
var s4 = $"При{vet}"; // выделена память для обеих
Console.WriteLine(s3 == s4); // true 
Console.WriteLine(ReferenceEquals(s3, s4)); // false
s3 = string.Intern(s3); // Помещаем s3«Привет» - в пул интернирования
Console.WriteLine(ReferenceEquals(s3, s4)); // false, поскольку s4 – не в пуле
s4 = string.Intern(s4); // «Привет» уже в пуле – получаем существующую ссылку
Console.WriteLine(ReferenceEquals(s3, s4)); // теперь s3 и s4 ссылаются на одну
// переменную из пула
```


```c#



var plus = "plus";

Console.WriteLine("Privet"[2]);

var pp = "Privet";

Console.WriteLine("Privet".Length);

Console.WriteLine("🤖".Length);

var si = new StringInfo(c);
Console.WriteLine(si.LengthInTextElements);


for (var i = 0; i < sb.Length; i++)
{
    Console.WriteLine($"'{sb[i]}'");
}


var privetStable = "Privet";


var poka = privetStable.Replace("rivet", "poka");

Console.Write($"{privetStable} {poka}");
```

<a name="твоё_название1"></a> 
<a name="твоё_название2"></a> 
<a name="твоё_название3"></a> 