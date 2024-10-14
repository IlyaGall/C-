# Стек и очередь

1. [Фильтрация](https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/standard-query-operators/filtering-data)
2. [Проекция](https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/standard-query-operators/projection-operations)
3. [Наборы данных](https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/standard-query-operators/set-operations)
4. [Сортировка](https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/standard-query-operators/sorting-data)
5. [Квантификаторы](https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/standard-query-operators/quantifier-operations)
6. [Секционирование](https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/standard-query-operators/partitioning-data)
7. [Конвертация данных](https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/standard-query-operators/converting-data-types)
8. [Операции соединения](https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/standard-query-operators/join-operations)
9. [Группировка данных](https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/standard-query-operators/grouping-data)

## Фильтрация

Фильтрация – это операция, результатом которой будет набор значений, подходящий под определенное условие.

![img](https://github.com/IlyaGall/C-/blob/main/26%20LINQ%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%82%D0%BE%D1%80%D1%8B/img/1.JPG)

Фильтрация данных в linq представлена следующими методами:
[OfType](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.oftype?view=net-8.0) – фильтрует данные по типу;
[Where](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.where?view=net-8.0) – фильтрует значения по условию (в декларативном синтаксисе - where)

```C#
string[] words = ["the", "quick", "brown", "fox", "jumps"];

IEnumerable<string> query = from word in words
                            where word.Length == 3
                            select word;

/*IEnumerable<string> query =
    words.Where(word => word.Length == 3);*/

foreach (string str in query)
{
    Console.WriteLine(str);
}

//Пример с OfType в проекте LinqUndeclarativeExamples - 2.'
```

## Проекция
Проекция – это операция преобразования объекта в новую форму, которая часто состоит только из этих свойств, которые впоследствии используются.

![img](https://github.com/IlyaGall/C-/blob/main/26%20LINQ%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%82%D0%BE%D1%80%D1%8B/img/2.JPG)


Проекция данных в linq представлена следующими методами:
* [Select](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.select?view=net-8.0) – проецирует значения, которые основаны на функции преобразования (в декларативном синтаксисе также select)

* [SelectMany](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.selectmany?view=net-8.0) – проецирует последовательности значений, основанных на функции преобразования, а затем выравнивает их в одну последовательность.(в декларативном синтаксисе множественный from). 

Простыми словами: забирает последовательность из элемента коллекции и кладет его в результирующую последовательность.

* [Zip](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.zip?view=net-8.0) – создает последовательность кортежей из 2-3 указанных последовательностей.


```C#
using System.Linq;

List<string> words = ["an", "apple", "a", "day"];

var query = from word in words
            select word.Substring(0, 1);

query = words.Select(word => word.Substring(0, 1));

foreach (string s in query)
{
    Console.WriteLine(s);
}

//SelectMany
List<string> phrases = ["an apple a day", "the quick brown fox"];

query = from phrase in phrases
            from word in phrase.Split(' ')
            select word;

query = phrases.SelectMany(phrases => phrases.Split(' '));

foreach (string s in query)
{
    Console.WriteLine(s);
}

//Zip
// An int array with 7 elements.
IEnumerable<int> numbers = [1, 2, 3, 4, 5, 6, 7];
// A char array with 6 elements.
IEnumerable<char> letters = ['A', 'B', 'C', 'D', 'E', 'F'];

var zip
 = numbers.Zip(letters
 );

IEnumerable<ZipType> zip2 = numbers.Zip(letters
 , (number, letter) => new ZipType { Num = number, Letter = letter }    
 );


class ZipType
{
    public int Num { get; set; }
    public char Letter { get; set; }
}
```

## Операции над множествами

Под операции над множествами в данном случае понимаются операции запросов, которые создают результирующий набор присутствия или отсутствия эквивалентных элементов в одной или отдельной коллекциях.
[Distinct](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.distinct?view=net-8.0) или [DistinctBy](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.distinctby?view=net-8.0) – возвращает уникальные элементы последовательности. Можно также сказать, что удаляет дубликаты.

![img](https://github.com/IlyaGall/C-/blob/main/26%20LINQ%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%82%D0%BE%D1%80%D1%8B/img/3.JPG)

[Except](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.except?view=net-8.0) или [ExceptBy](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.exceptby?view=net-8.0) – возвращает набор значений, которые присутствуют в одной коллекции и отсутствуют в другой.

![img](https://github.com/IlyaGall/C-/blob/main/26%20LINQ%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%82%D0%BE%D1%80%D1%8B/img/4.JPG)

[Intersect](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.intersect?view=net-8.0) или [IntersectBy](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.exceptby?view=net-8.0) – возвращает набор значений, которые встречаются в обоих коллекциях.

![img](https://github.com/IlyaGall/C-/blob/main/26%20LINQ%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%82%D0%BE%D1%80%D1%8B/img/5.JPG)


[Union](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.union?view=net-8.0) или [UnionBy](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.unionby?view=net-8.0) – возвращает набор уникальных значений, присутствующий в обоих коллекциях.

![img](https://github.com/IlyaGall/C-/blob/main/26%20LINQ%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%82%D0%BE%D1%80%D1%8B/img/6.JPG)


```C#
//Distinct
string[] words = ["the", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog"];
List<string> query = words.Distinct().ToList();


//Except
string[] words1 = ["the", "quick", "brown", "fox"];
string[] words2 = ["jumped", "over", "the", "lazy", "dog"];

List<string> query2 = words1.Except(words2).ToList();

query2.ForEach(item => Console.WriteLine(item));


//Intersect
string[] words3 = ["the", "quick", "brown", "fox"];
string[] words4 = ["jumped", "over", "the", "lazy", "dog"];

List<string> query3 = words3.Intersect(words4).ToList();
Console.WriteLine("--------------------");

query3.ForEach(item => Console.WriteLine(item));

//Union
string[] words5 = ["the", "quick", "brown", "fox"];
string[] words6 = ["jumped", "over", "the", "lazy", "dog"];

List<string> query4 = words5.Union(words6).ToList();
Console.WriteLine("--------------------");
query4.ForEach(item => Console.WriteLine(item));
```

## Сортировка данных

Операция сортировки упорядочивает элементы последовательности на основе одного или нескольких атрибутов.

![img](https://github.com/IlyaGall/C-/blob/main/26%20LINQ%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%82%D0%BE%D1%80%D1%8B/img/7.JPG)

* [OrderBy](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.orderby?view=net-8.0) – сортировка значений в возрастающем порядке. В декларативном синтаксисе – оператор orderby или orderby ascending.
* [OrderByDescending](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.orderbydescending?view=net-8.0) – сортировка значений в убывающем порядке. В декларативном синтаксисе – оператор orderby descending.
* [ThenBy](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.thenby?view=net-8.0) – дополнительная сортировка по возрастанию. В декларативном дополнительные – операторы orderby или orderby ascending.
* [ThenByDescending](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.thenbydescending?view=net-8.0) – дополнительная сортировка по убыванию. В декларативном синтаксисе дополнительные orderby descending.
* [Reverse](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.reverse?view=net-8.0) - изменение порядка элементов в коллекции на обратный. В декларативном синтаксисе аналогов нет.

```C#
List<Student> students = new List<Student>
{
    new Student{ StudentId = 5, GroupId = 2, Name = "Tom"},
    new Student{ StudentId = 1, GroupId = 1, Name = "Alice"},
    new Student{ StudentId = 2, GroupId = 2, Name = "Bob"},
    new Student{ StudentId = 3, GroupId = 1, Name = "John"},
    new Student{ StudentId = 4, GroupId = 2, Name = "Jerry"},
};

//Order by
List<Student> orderResult;

//Undeclare
orderResult = students.OrderBy(
    item => item.StudentId
    ).ToList();

students.Order(new StudComparer());

//Declare 
orderResult = (from student in students
              orderby student.StudentId //ascending
              select student).ToList();
//OrderByDescending
//Undeclare
orderResult = (List<Student>)students.OrderByDescending(item => item.StudentId).ToList();

//Declare 
orderResult = (from student in students
               orderby student.StudentId descending
               select student).ToList();
//ThenBy
//Undeclare
orderResult = (List<Student>)students
    .OrderBy(item => item.GroupId)
    .ThenBy(item => item.Name)
    .ToList();
//ThenBy
//declare
orderResult = (from item in 
                   
                   /*Вложенный запрос с сортировкой по группе */
              (from student in students
              orderby student.GroupId descending
              select student)
                   /*Конец вложенного запроса*/

              /*Сортировка по имени*/
              orderby item.Name
              select item)
                .ToList();
//ThenByDescending уже лень :)
//Reverse
students.Reverse();
//IComparer<Student> comparer = new StudComparer()
```

```C#
internal class StudComparer : IComparer<Student>
{
    int IComparer<Student>.Compare(Student? x, Student? y)
    {
        return x.Name.CompareTo(y.Name);
    }
}
```

```C#
internal class Student : IComparable<Student>
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int GroupId { get; set; }

    int IComparable<Student>.CompareTo(Student? other)
    {
        return this.StudentId.CompareTo(other.StudentId);
    }
}
```

## Квантификаторы

### Операции квантификатора

Квантификатор – это операция, которая возвращают значение bool, которое указывает, удовлетворяют ли условию некоторые или все элементы в последовательности.
* [All](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.all?view=net-8.0) - определяет, все ли элементы последовательности удовлетворяют условию.
* [Any](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.any?view=net-8.0) - определяет, удовлетворяют ли условию какие-либо элементы последовательности.
* [Contains](https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.contains?view=net-8.0) - определяет, содержит ли последовательность указанный элемент.

![img](https://github.com/IlyaGall/C-/blob/main/26%20LINQ%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%82%D0%BE%D1%80%D1%8B/img/8.JPG)

```C#
using System.Linq;

string[] words = ["the", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog"];

bool allElementMoreThan = words.All(item => 
                                            item.Length > 0
                                            //item.Length > 3
                                            );
//Any
bool anyElementMoreThan = words.Any(item =>                 /*Аргумент не обязателен, если мы хотим узнать есть ли элементы в коллекции*/
                                            item.Length > 0
                                            //item.Length > 3
                                            );
//Contains
bool wordExsist = words.Contains("quick");  /*Есть перегрузка с компаратором*/
```

## Секционирование данных
Секционирование – это операция разделения входной последовательности на два раздела без изменения порядка элементов, а затем возвращения одного из разделов.

![img](https://github.com/IlyaGall/C-/blob/main/26%20LINQ%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%82%D0%BE%D1%80%D1%8B/img/9.JPG)

[Skip](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.skip?view=net-8.0) - пропускает элементы до указанной позиции в последовательности.
[SkipWhile](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.skipwhile?view=net-8.0) - пропускает элементы на основе функции предиката, пока элемент не удовлетворяет условию.
[Take](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.take?view=net-8.0) - возвращает элементы на указанную позицию в последовательности.
[TakeWhile](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.takewhile?view=net-8.0) - принимает элементы на основе функции предиката, пока элемент не удовлетворяет условию.
[Chunk](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.chunk?view=net-8.0) - разделяет элементы последовательности на фрагменты указанного максимальногоразмера.


```C#
string[] words = ["the", "quick", "brown", "fox", "jumps", "do"];
//Skip
List<string> skip = words.Skip(1).ToList();
//SkipWhile
List<string> skipWhile = words.SkipWhile(
    item => !item.StartsWith("q")
    ).ToList();
//Take
List<string> take = words.Take(3).ToList();
//TakeWhile
List<string> takeWhile = words.TakeWhile(
    item => item.Length > 2
    ).ToList();
//Chunk
List<string[]> chunks = words.Chunk(2).ToList();
```
## Преобразование типов данных
Операция преобразования меняет тип входных объектов.
Таблица методов преобразования находится [здесь](https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/standard-query-operators/converting-data-types).
https://learn.microsoft.com/en-us/dotnet/csharp/linq/standard-query-operators/converting-datatypes#methods


## Операции соединения(Join)
Соединение двух источников данных — это связь объектов в одном источнике данных с объектами, которые имеют общий атрибут в другом источнике данных.
* [Join](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.join?view=net-8.0) – соединяет две последовательности на основании функций селектора ключа и извлекает пары значений. В декларативном синтаксисе дополнительные join … in … on … equals.
* [GroupJoin](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.groupjoin?view=net-8.0) – соединяет две последовательности на основании функций селектора ключа и группирует полученные при сопоставлении данные для каждого элемента. В декларативном
синтаксисе дополнительные join … in … on … equals … into … .
Пример декларативного синтаксиса:
```C#
from x in set1
join y in set2 on y.Prop2 equals x.Prop1
```
где, свойства y.Prop2 и x.Prop1 являются одной и той же сущностью, скажем идентификатором группы студента.

![img](https://github.com/IlyaGall/C-/blob/main/26%20LINQ%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%82%D0%BE%D1%80%D1%8B/img/10.JPG)

```C#
using LinqExamples;

//Join
List<Student> students = new List<Student>
{
    new Student { StudentId = 1, Name = "Ivanov", GroupId = 1 },
    new Student { StudentId = 2, Name = "Petrov", GroupId = 2 },
    new Student { StudentId = 3, Name = "Sidorov", GroupId = 1 },
};

List<StudentGroup> groups = new List<StudentGroup>
{
    new StudentGroup { GroupId = 1, Name = "Отличники", StudentId = 1 },
    new StudentGroup { GroupId = 2, Name = "Двоечники", StudentId = 2 }
};

//Вывод нового типа, который содержиь пары: имя студент и имя группы студента
//Метод-синтаксис
var studentsInGroups = students.Join(groups,
                                    student => student.GroupId,
                                    eachGroup => eachGroup.GroupId,
                                    (student, eachGroup) => new { Name = student.Name, GroupName = eachGroup.Name }).ToList();
//Декларативный
var studentsInGroups2 = (from student in students
                   join eachGroup in groups on student.GroupId equals eachGroup.GroupId
                   select new { StudentName = student.Name, GroupName = eachGroup.Name }).ToList();

//Соединение по комплексному ключу
//Метод-синтаксис
var studentsInGroups3 = students.Join(groups,
                                    student => new { student.StudentId, student.GroupId },
                                    eachGroup => new {eachGroup.StudentId, eachGroup.GroupId }, //Бред, но для демонстрации подойдет
                                    (student, eachGroup) => new { Name = student.Name, GroupName = eachGroup.Name }).ToList();
//Декларативный
var studentsInGroups4 = (from student in students
                         join eachGroup in groups
                         on
                         new { student.StudentId, student.GroupId }
                         equals new { eachGroup.StudentId, eachGroup.GroupId }
                         select new { StudentName = student.Name, GroupName = eachGroup.Name }).ToList();

//grouped join
//Метод синтаксис
var personnel = groups.GroupJoin(students, // второй набор
             eachGroup => eachGroup.GroupId, // свойство-селектор объекта из первого набора
             student => student.GroupId, // свойство-селектор объекта из второго набора
             (jgroup, jstudents) => new   // результат
             {
                 GroupName = jgroup.Name,   //Наименование группы
                 Students = jstudents       //Коллекция студентов данной группы
             });

//Декларативный
var studInGroups = from eachGroup in groups
                join student in students on eachGroup.GroupId equals student.GroupId into groupJoin
                select new { GroupName = eachGroup.Name, StudentsInGroup = groupJoin };
```

```C#
internal class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int GroupId { get; set; }
}
```

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples
{
    internal class StudentGroup
    {
        public int GroupId { get; set; }
        public string Name { get; set; }

        public int StudentId {  get; set; }
    }
}

```

## Группирование данных
Группировка – это операция объединения данных в группы таким образом, чтобы у элементов в каждой группе был общий атрибут. На следующем рисунке показаны результаты операции группирования последовательности символов. Ключ для каждой группы — это символ.


![img](https://github.com/IlyaGall/C-/blob/main/26%20LINQ%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%82%D0%BE%D1%80%D1%8B/img/11.JPG)

![img](https://github.com/IlyaGall/C-/blob/main/26%20LINQ%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%82%D0%BE%D1%80%D1%8B/img/12.JPG)


* [GroupBy](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.groupby?view=net-8.0) – группирует элементы с общим атрибутом. Объект представляет каждую IGrouping<TKey,TElement> группу. В декларативном синтаксисе group … by или group … by …
into
[ToLookup](https://learn.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.tolookup?view=net-8.0) – вставляет элементы в Lookup<TKey,TElement> (словарь "один ко многим") в
зависимости от функции выбора ключа.


```C#
//Group
using Grouping;

List<int> numbers = [35, 44, 200, 84, 3987, 4, 199, 329, 446, 208];



IEnumerable<IGrouping<int, int>> query = (from number in numbers
                                         group number by number % 2);

IEnumerable<IGrouping<int, int>> query2 = numbers
    .GroupBy(number => number % 2).ToList();

foreach (IGrouping<int, int> item in query)
{
    Console.WriteLine(item.Key);
    Console.WriteLine("--------------");
    foreach (int a in item/*IEnumerable<int>*/)
    {
        Console.WriteLine(a);
    }
}

//ToLookup
List<Package> packages = new List<Package> { new Package { Company = "Coho Vineyard", Weight = 25.2, TrackingNumber = 89453312L },
                                                 new Package { Company = "Lucerne Publishing", Weight = 18.7, TrackingNumber = 89112755L },
                                                 new Package { Company = "Wingtip Toys", Weight = 6.0, TrackingNumber = 299456122L },
                                                 new Package { Company = "Contoso Pharmaceuticals", Weight = 9.3, TrackingNumber = 670053128L },
                                                 new Package { Company = "Wide World Importers", Weight = 33.8, TrackingNumber = 4665518773L } }; ;

Lookup<char, string> lookup = (Lookup<char, string>)packages.ToLookup(p => p.Company[0],
                                                    p => p.Company + " " + p.TrackingNumber);
;

```

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grouping
{
    class Package
    {
        public string Company;
        public double Weight;
        public long TrackingNumber;
    }
}

```




##  Одиночный вызов



```C#

string[] people = { "Tom", "Bob", "Tim", "Sam" };

//First
string first = people.First();

//First Exception
//first = people.First(item => item.Equals("Kate")); 

//FirstOrDefault
first = people.FirstOrDefault(item=> item.Equals("Kate"));



//signle
string signle = people.Single(item => item.Equals("Tom"));

//signle Exception
//signle = people.Single(item => item.Length == 3); 

//signle
signle = people.SingleOrDefault(item => item.Equals("Kate"));


//Last
string last = people.Last();

//Last Exception
last = people.Last(item => item.Equals("Kate"));

//LastOrDefault
last = people.LastOrDefault(item => item.Equals("Kate"));

```

