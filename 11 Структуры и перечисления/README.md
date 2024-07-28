# Структуры и перечислени

## Что такое
Структура - знаùимýй тип, которýй инкапсулирует даннýе и функøионалþностþ.
РазмеûаĀтсā в стеке
Примитивнýе типý (int, float, bool...) - структурý
Чтобý обüāвитþ структуру исполþзуетсā клĀùевое слово struct
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
øелþ: повýситþ производителþностþ приложениā работает длā неболþúих структур

## особенность

● нелþзā определитþ конструктор по умолùаниĀ (до C#10)
● не поддерживает наследованиā
● => abstract, virtual или protected - не указýваĀтсā у ùленов структур
● нелþзā определитþ деструктор
● передаетсā по знаùениĀ: при присвоении, передаùе параметра в метод или возвраûаемое знаùение метода знаùение копируетсā
● Equals(): сравнение по знаùениāм


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
Переùисление - øелоùисленнýй тип, определеннýй набором именованнýх констант
Удобен длā хранениā возможнýх знаùений области (дни недели, месāøý, поддерживаемýе типý устройств и пр.) , состоāниā суûности (соединениā с БД, код http ответа и пр.)
Чтобý обüāвитþ переùисление исполþзуетсā клĀùевое слово enum

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
● Облегùает сопровождение
● ДелаĀт код āснее
● Ускорение написаниā кода

# Булева алгебра

## Или / or
в булевой алгебре:
ДизüĀнкøиā / логиùеское сложение
обознаùение ∨, |

ложно тогда, когда тогда и толþко тогда, когда ложнý оба вýсказýваниā (аргумента)

записþ в с# (и поùти везде): int c = a | b

![Image alt](https://github.com/IlyaGall/C-/blob/main/10%20%D0%98%D0%BD%D1%82%D0%B5%D1%80%D1%84%D0%B5%D0%B9%D1%81%D1%8B/img/3.PNG)

пример побитового сложениā:



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