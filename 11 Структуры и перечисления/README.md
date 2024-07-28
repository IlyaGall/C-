# Структуры и перечислени

## Что такое
Структура - значимый тип, который инкапсулирует данные и функциональность.
Размещаются в стеке
Примитивные типы (int, float, bool...) - структуры
Чтобы объявить структуру используется ключевое слово struct
```C#
struct UserInfo
{
    public string Name;
    public byte Age;
    public void WriteUserInfo()
    {
        Console.WriteLine("Имя: {0}, возраст:{1}",Name,Age);
    }
}
```

## Зачем
цель: повысить производительность приложения работает для небольших структур

## особенность

* нельзя определить конструктор по умолчанию (до C#10)
* не поддерживает наследования
* => abstract, virtual или protected - не указываются у членов структур
* нельзя определить деструктор
* передается по значению: при присвоении, передаче параметра в метод или возвращаемое значение метода значение копируется
* Equals(): сравнение по значениям


```c#
struct WithString
{
    public const string SuperCOnstString = "";
    public string SuperString { get; set; }
}

struct Beta
{
    public int A;

    public void DoSomething()
    {
        Console.WriteLine("Do something");
    }
}

var ws = new WithString();
var ws2 = new WithString();
ws2.SuperString = "124";
ws2.SuperString = "1424224";
```

```c#
public class Alpha
{
    public int A;
}

public interface IDuck
{
    public void Quack();
}

struct Dot2D : IDuck
{

    public int X { get; set; }

    public int Y { get; set; }

    public void Quack()
    {
        throw new NotImplementedException();
    }
}

struct Dot3D
{
    public Dot3D(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public int X { get; set; }

    public int Y { get; set; }

    public int Z { get; set; }

    public Alpha Point { get; set; }
}


var listOfAlpha = new List<Alpha> { new Alpha { A = 10 } };

listOfAlpha[0].A = 1000;



var listOfBeta = new List<Beta> { new Beta { A = 10 } };

listOfBeta[0] = new Beta { A = 111 };
```

# Перечисления
## Что такое
Перечисление - целочисленный тип, определенный набором именованных констант
Удобен для хранения возможных значений области (дни недели, месяцы, поддерживаемые типы устройств и пр.) , состояния сущности (соединения с БД, код http ответа и пр.)
Чтобы объявить перечисление используется ключевое слово enum

```c#
enum Season
{
 Spring, // имеет
 Summer,
 Autumn,
 Winter
}
```

## Чем хороши
* Облегчает сопровождение
* Делают код яснее
* Ускорение написания кода

# Булева алгебра

## Или / or
в булевой алгебре:
Дизъюнкция / логическое сложение
обозначение ∨, |

ложно тогда, когда тогда и только тогда, когда ложны оба высказывания (аргумента)

запись в с# (и почти везде): int c = a | b

![Image alt](https://github.com/IlyaGall/C-/blob/main/11%20%D0%A1%D1%82%D1%80%D1%83%D0%BA%D1%82%D1%83%D1%80%D1%8B%20%D0%B8%20%D0%BF%D0%B5%D1%80%D0%B5%D1%87%D0%B8%D1%81%D0%BB%D0%B5%D0%BD%D0%B8%D1%8F/img/1.PNG)

## И / and
в булевой алгебре:
Конъюнкция / логическое умножение обозначение ∧, &

истинно тогда, когда тогда и только тогда, когда истинны оба высказывания
запись в с# (и почти везде):
int c = a & b

![Image alt](https://github.com/IlyaGall/C-/blob/main/11%20%D0%A1%D1%82%D1%80%D1%83%D0%BA%D1%82%D1%83%D1%80%D1%8B%20%D0%B8%20%D0%BF%D0%B5%D1%80%D0%B5%D1%87%D0%B8%D1%81%D0%BB%D0%B5%D0%BD%D0%B8%D1%8F/img/2.PNG)


## Не
в булевой алгебре:
Инверсия, отрицание обозначение ¬ результатом является суждение, «противоположное» исходному
запись в с# (и почти везде):
bool c = !a

![Image alt](https://github.com/IlyaGall/C-/blob/main/11%20%D0%A1%D1%82%D1%80%D1%83%D0%BA%D1%82%D1%83%D1%80%D1%8B%20%D0%B8%20%D0%BF%D0%B5%D1%80%D0%B5%D1%87%D0%B8%D1%81%D0%BB%D0%B5%D0%BD%D0%B8%D1%8F/img/3.PNG)


## XOR
в булевой алгебре:
Исключающее ИЛИ, сложение по модулю 2 обозначение XOR, ⊕

истинно тогда и только тогда, когда один из аргументов истинен, а другой — ложен 

запись в с# (и почти везде):
int c = a
^ b
пример побитового XOR:

![Image alt](https://github.com/IlyaGall/C-/blob/main/11%20%D0%A1%D1%82%D1%80%D1%83%D0%BA%D1%82%D1%83%D1%80%D1%8B%20%D0%B8%20%D0%BF%D0%B5%D1%80%D0%B5%D1%87%D0%B8%D1%81%D0%BB%D0%B5%D0%BD%D0%B8%D1%8F/img/4.PNG)

## Еще материалы по  Булевой алгебре

![Image alt](https://github.com/IlyaGall/C-/blob/main/11%20%D0%A1%D1%82%D1%80%D1%83%D0%BA%D1%82%D1%83%D1%80%D1%8B%20%D0%B8%20%D0%BF%D0%B5%D1%80%D0%B5%D1%87%D0%B8%D1%81%D0%BB%D0%B5%D0%BD%D0%B8%D1%8F/img/5.PNG)

можно смотреть в википедии
* [Дизъюнкция](https://ru.wikipedia.org/wiki/%D0%94%D0%B8%D0%B7%D1%8A%D1%8E%D0%BD%D0%BA%D1%86%D0%B8%D1%8F)
* [Импликация](https://ru.wikipedia.org/wiki/%D0%98%D0%BC%D0%BF%D0%BB%D0%B8%D0%BA%D0%B0%D1%86%D0%B8%D1%8F)
* [Конъюнкция](https://ru.wikipedia.org/wiki/%D0%9A%D0%BE%D0%BD%D1%8A%D1%8E%D0%BD%D0%BA%D1%86%D0%B8%D1%8F)
* [Отрицание (унарная)](https://ru.wikipedia.org/wiki/%D0%9E%D1%82%D1%80%D0%B8%D1%86%D0%B0%D0%BD%D0%B8%D0%B5)
* [Исключающее «или»](https://ru.wikipedia.org/wiki/%D0%98%D1%81%D0%BA%D0%BB%D1%8E%D1%87%D0%B0%D1%8E%D1%89%D0%B5%D0%B5_%C2%AB%D0%B8%D0%BB%D0%B8%C2%BB)
* [Стрелка Пирса](https://ru.wikipedia.org/wiki/%D0%A1%D1%82%D1%80%D0%B5%D0%BB%D0%BA%D0%B0_%D0%9F%D0%B8%D1%80%D1%81%D0%B0)
* [Условная дизъюнкция(тернарная)](https://ru.wikipedia.org/wiki/%D0%A3%D1%81%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0%D1%8F_%D0%B4%D0%B8%D0%B7%D1%8A%D1%8E%D0%BD%D0%BA%D1%86%D0%B8%D1%8F)
* [Штрих Шеффера](https://ru.wikipedia.org/wiki/%D0%A8%D1%82%D1%80%D0%B8%D1%85_%D0%A8%D0%B5%D1%84%D1%84%D0%B5%D1%80%D0%B0)
* [Эквиваленция](https://ru.wikipedia.org/wiki/%D0%AD%D0%BA%D0%B2%D0%B8%D0%B2%D0%B0%D0%BB%D0%B5%D0%BD%D1%86%D0%B8%D1%8F)


## Битовые флаги  [Flags]
Если необходимо, чтобы значение перечисления представлял комбинацию вариантов:
- определить каждое значение как степень двойки
- использовать побитовые логические операторы И / ИЛИ
На практике можно применять и к перечислениям 



```c#
public enum DocumentType
{
    Passport = 5,
    ForeignPassport = 10,
    DriveLicence = 1003,
    PassportMoryka,
}

public enum RoleFeature
{
    DownloadFile = 1, //  0001     1-0001
    SaveSettings = 2, //  0010      2- 0010
    CreateMessage = 4, // 0100     3-0011
    RemoveFile = 8,//     1000
}


[Flags]
public enum RoleFeature1
{
    DownloadFile, //  0001     1-0001
    SaveSettings, //  0010      2- 0010
    CreateMessage, // 0100     3-0011
    RemoveFile,//     1000
}

public bool HasFlag(RoleFeature val, RoleFeature flag)
{
    return val & flag == flag;
}
```