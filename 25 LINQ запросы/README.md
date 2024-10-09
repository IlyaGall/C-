# Стек и очередь

## Что такое linq?

Linq(Language Integrated Query) – это синтаксис в .net-языках, спроектированный для работы с источниками данных, таких как коллекции, базы данных, XML-документы и пр.
Linq-запрос – это способ выполнения операций с данными, который интегрирован в язык.

Из чего состоит linq-запрос
Все linq–запросы подразумевают в
себе 3 следующие действия:
1. Выбор источника данных
2. Описание тела запроса
3. Выполнение запроса


![Image alt](https://github.com/IlyaGall/C-/blob/main/25%20LINQ%20%D0%B7%D0%B0%D0%BF%D1%80%D0%BE%D1%81%D1%8B/img/1.JPG)

## Отложенное и немедленное выполнение
Отложенное выполнение (Deferred Execution) в LINQ — это механизм, при котором запрос не выполняется в момент его создания, а откладывается до тех пор, пока к данным не будет фактического обращения.
Существуют методы, которые вызывают немедленное выполнение (Immediate Execution) запроса и загрузку данных в память. В основном это агрегатные функции и методы возвращения коллекции.

[Классификационная таблица](https://learn.microsoft.com/en-us/dotnet/csharp/linq/get-started/introduction-to-linq-queries)


## Провайдеры данных linq-запросов


Все запросы можно отправлять в любой источник данных, реализующий интерфейс IEnumerable<T>, такие как:
1. LINQ to Objects: применяется для работы с массивами и коллекциями
2. LINQ to Entities: используется при обращении к базам данных через технологию Entity Framework
3. LINQ to XML: применяется при работе с файлами XML
4. LINQ to DataSet: применяется при работе с объектом DataSet
5. Parallel LINQ (PLINQ): используется для выполнения параллельных запросов

## Интерфейс IQueryable<T> (для работы с бд)

Queryable<T> — это интерфейс, который используется в LINQ для создания запросов к удаленным источникам данных.

Используйте IQueryable, когда работаете с удаленными источниками данных, например, с базами данных или веб-сервисами.

Используйте IEnumerable, когда данные уже находятся в памяти, например, в списке, массиве или другой коллекции. 

![Image alt](https://github.com/IlyaGall/C-/blob/main/25%20LINQ%20%D0%B7%D0%B0%D0%BF%D1%80%D0%BE%D1%81%D1%8B/img/2.JPG)

## Варианты написания запросов
Существует 2 формы написания linq-запросов:
1. Декларативный синтаксис/синтаксис запросов/SQL-подобный синтаксис
2. Fluent API/Метод-синтаксис/Недекларативный синтаксис


## Декларативный синтаксис

![Image alt](https://github.com/IlyaGall/C-/blob/main/25%20LINQ%20%D0%B7%D0%B0%D0%BF%D1%80%D0%BE%D1%81%D1%8B/img/3.JPG)


При использовании декларативного синтаксиса всегда используются 3
предложения:
1. [from](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/from-clause) – указывается псевдоним элемента источника данных;
2. [in](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/in) - указывается источник данных;
3. [select/group](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/select-clause) – возвращаемые элементы данных.


## Fluent-синтаксис
При использовании метод-синтаксиса используются методы расширения интерфейса IEnumerable<T>.
Просмотреть исходный код методов можно по [ссылке](https://github.com/microsoft/referencesource/blob/master/System.Core/System/Linq/Enumerable.cs). 

![Image alt](https://github.com/IlyaGall/C-/blob/main/25%20LINQ%20%D0%B7%D0%B0%D0%BF%D1%80%D0%BE%D1%81%D1%8B/img/4.JPG)

## Особенности декларативного синтаксиса
Декларативный подход не поддерживает:
* Агрегатные функции: Sum(), Count(), Max(), Min(), Average();
* Методы пагинации: Skip(), SkipWhile(), Take(), TakeWhile();
* Методы для работы с порядком элементов: ThenBy(),ThenByDescending();
* Методы для работы с множествами: Distinct(), Union(),Intersect(), Except();
* Методы группового соединения: GroupJoin();
* Экзистенциальные запросы: Any(), All(), Contains().

## Особенности Fluent API
Метод-синтаксис не поддерживает:
- Запросы с ключевым словом let;
- Запросы с ключевым словом into.

## Декларативный синтаксис

Ключевые слова
При использовании декларативного синтаксиса используются следующие ключевые слова:
* from – где указывается элемент последовательности(обязателен); Используется с in;
* in - источник данных(обязателен);
* where – задает фильтрацию элементов последовательности(опционально);
* select – возвращает проекцию данных(обязательно, либо group);
* group – возвращает объекты типа IGrouping<TKey,TElement>; используетсяс by; (обязательно, либо select);
* by – указывает параметр, по которому необходимо сгруппировать членыпоследовательности;


## Ключевые слова
При использовании декларативного синтаксиса используются следующие ключевые слова:
● [let](https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/query-keywords) – определяет переменную и присваивает ей значение, рассчитанное на основе значений данных;
● [into](https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/into) – служит для создания временного идентификатора для хранения результата из group;
● [join](https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/join-clause) – объединяет различные последовательности, имеющих отношения в объектной модели; Используется с on;
● [on](https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/on) – задает ключи, по которым необходимо сопоставить коллекции в join;
● [equals](https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/equals) – сравнивает значения в выражениях запроса; используется с join on;
● [orderby](https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/orderby-clause) – сортирует последовательность значений, используя компаратор по умолчанию;
● [ascending/descending](https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/ascending)–  сортирует последовательность значений, используя компаратор по умолчанию.

## Правила описания запроса
1. Выражение должно начинаться с ключевого слова from и должно заканчиваться select или group.
2. Между первым и последним предложением могут находится where, orderby, join, let. Может быть дополнительный from, может быть into, join, group.
3. Выражение может возвращать 2 типа: var или IEnumerable<T>.
4. Запросы могут иметь вложенность.

## Пример запроса
Пример запроса выглядит следующим образом:
```C#
var query = from item in source where item.Department.DepartmentName.Equals("ИТ")
orderby item.Name /*ascending*/ /*descending*/
select item;
```

## Метод синтаксис
Все методы расширения предоставляются интерфейсом IEnumerable<T>.
Список находится в исходном коде класса Enumerable.cs, расширяющим интерфейс.
Все методы fluent API на основе LINQ:
1. Принимают обобщенный делегат (анонимные функции) в качестве параметра.
2. Возвращают другую последовательность или одно значение.
3. Могут принимать еще одну коллекцию как параметр(Join).

## Методы расширения IEnumerable<T>
Функционал метод-синтаксиса идентичен функционалу декларативного
синтаксиса с той разницей, что:
1. Нет ключевых слов: from, in, let, into.
2. Ключевые слова операторов запросов созвучны по написанию, но работают посредством обобщенных делегатов: Action, Predicate, Func.
Пример:

```C#
var query = source.Where(item => item.Id > 1).Select(item=> item);
```
## Пример синтаксиса

![Image alt](https://github.com/IlyaGall/C-/blob/main/25%20LINQ%20%D0%B7%D0%B0%D0%BF%D1%80%D0%BE%D1%81%D1%8B/img/5.JPG)

## Решение задач
1. Напишите запрос к коллекции int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, который вернет все числа кратные 3.
```C#
int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var num = from item in numbers
                where item%3 == 0
                select item;
foreach (var item in num)
{
    Console.WriteLine(item);
}


```
2. Напишите запрос к коллекции из п.1, который вернет объект(любого типа), содержащий число из коллекции, например Student, в котором StudentId = n(n – число из коллекции п.1);
```C#
var num2 = from item in numbers
                where item % 3 == 0
                select new Student { StudentId = item } ;
      foreach (var item in num2)
      {
          Console.WriteLine("StudentId " + item.StudentId);
      }
```
3. Напишите запрос к коллекции
List<Student> students = new List<Student>
{
new Student { StudentId = 1, Name = "Ivanov", GroupId = 1 },
new Student { StudentId = 2, Name = "Petrov", GroupId = 2 },
new Student { StudentId = 3, Name = "Sidorov", GroupId = 1 },
};
, который сгруппирует студентов по GroupId.

```C#
   List<Student> students = new List<Student>
      {
          new Student { StudentId = 1, Name = "Ivanov", GroupId = 1 },
          new Student { StudentId = 2, Name = "Petrov", GroupId = 2 },
          new Student { StudentId = 3, Name = "Sidorov", GroupId = 1 },
      };
      // запрос, который сгруппирует студентов по GroupId.

      var num4 = from item in students
                 group item by item.GroupId;
      Console.WriteLine();
      foreach (var item in num4) 
      {
          Console.WriteLine("StudentId key " + item.Key);
          foreach (var student in item)
          {
              Console.WriteLine("Student Name " + student.Name);

          }
      }
```


4. Напишите запрос, выводящий количество студентов из п.3
```C#
int count = students.Count();
Console.WriteLine("students " + students.Count());
```
5. Напишите запрос, сортирующий элементы коллекции из п.3 по убыванию идентификатора
студента.
```C#
var num5 = students.OrderByDescending(item => item.StudentId);
      foreach (var item in num5) 
      {
          Console.WriteLine($"{item.StudentId} - {item.Name}");
      }
```
весь код

```C#
  internal class Student
  {
      public int StudentId { get; set; }
      public string Name { get; set; }
      public int GroupId { get; set; }
  }

  static void Main(string[] args)
  {

      int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

      var num = from item in numbers
                where item%3 == 0
                select item;

      foreach (var item in num)
      {
          Console.WriteLine(item);
      }

      /*
       Напишите запрос к коллекции из п.1, который вернет объект(любого типа), 
       содержащий число из коллекции, например Student, в котором StudentId = n(n – число из коллекции п.1);
       */
      var num2 = from item in numbers
                where item % 3 == 0
                select  new Student { StudentId = item } ;
      foreach (var item in num2)
      {
          Console.WriteLine("StudentId " + item.StudentId);
      }

      var num3 = from item in numbers
                 where item % 3 == 0
                 select new { StudentId = item };

      foreach (var item in num3)
      {
          Console.WriteLine("StudentId anonim " + item.StudentId);
      }

      /*
       Напишите запрос к коллекции
       */

      List<Student> students = new List<Student>
      {
          new Student { StudentId = 1, Name = "Ivanov", GroupId = 1 },
          new Student { StudentId = 2, Name = "Petrov", GroupId = 2 },
          new Student { StudentId = 3, Name = "Sidorov", GroupId = 1 },
      };
      // запрос, который сгруппирует студентов по GroupId.

      var num4 = from item in students
                 group item by item.GroupId;
      Console.WriteLine();
      foreach (var item in num4) 
      {
          Console.WriteLine("StudentId key " + item.Key);
          foreach (var student in item)
          {
              Console.WriteLine("Student Name " + student.Name);

          }
      }


      /////////////////////////44
      Console.WriteLine();

      int count = students.Count();
      Console.WriteLine("students " + students.Count());


      /// Напишите запрос, сортирующий элементы коллекции из п.3 по убыванию идентификатора студента.
      var num5 = students.OrderByDescending(item => item.StudentId);
      foreach (var item in num5) 
      {
          Console.WriteLine($"{item.StudentId} - {item.Name}");
      }
  }
```

## примеры запросов

```C#
 internal class StudentGroup
 {
     public int GroupId { get; set; }
     public string Name { get; set; }
 }

 internal class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int GroupId { get; set; }
}

internal class Department
{
    public int Id { get; set; }
    public string DepartmentName { get; set; }
}

 internal class Employer
 {
     public int Id { get; set; }
     public string Name { get; set; }
     public Department Department { get; set; }
 }

 //Инициализация коллекции 
List<Employer> source = new List<Employer>()
{
    new Employer{ Id = 1, Name = "Alice", Department = new Department{ Id = 1, DepartmentName = "Бухгалтерия" } }
    , new Employer{ Id = 2, Name = "John", Department = new Department{ Id = 1, DepartmentName = "Бухгалтерия" } }
    , new Employer{ Id = 3, Name = "Bob" , Department = new Department{ Id = 2, DepartmentName = "ИТ"} }
    , new Employer{ Id = 4, Name = "James", Department = new Department{ Id = 2, DepartmentName = "ИТ"}  }
};
```
### 1 Возвращает коллекцию как есть

```C#
IEnumerable<Employer> 
    asIs = 
            from item in source
            select item;
```
### 2 демонстрацией фильтров
```C#
IEnumerable<Employer>
    onlyIT =
            from item in source
            where item.Department.DepartmentName.Equals("ИТ")
            select item;
```
### 3 сортировки order by

```C#
IEnumerable<Employer> 
    orderBy =
            from item in source
            //where item.Department.DepartmentName.Equals("ИТ")
            orderby item.Name /*ascending*/ /*descending*/
            select item;
```
### 4 group by
```C#
IEnumerable<IGrouping<int,Employer>>
    employee 
    = 
        from item in source
        //where item.Department.DepartmentName.Equals("ИТ")
        group item by item.Department.Id;
```

### 5 использования let
```C#
//IEnumerable<string> 
    var
    emplInDeprtms
    =
        from item in source
        let description = ($"{item.Name} работает в отделе: {item.Department.DepartmentName}")
        select description;
        /*В linq-запросах допускается возвращать анонимный тип*/
/*select new { id = item.Id, Name = item.Name, Department = item.Department,
            Description = description};*/

//var a = new { id = 1, name = "sdfsd" };

foreach (var item in emplInDeprtms)
{
    Console.WriteLine(item);
}
```

### 6 использования into вместе с group +Пример использования into вместе с select
```C#
//IEnumerable<string>
var
emplWithHashCode
    = from item in source
      group item by item.Department.Id into dprtId
      //select dprtId; /*Тип dprtId - IGrouping<int,Employer> */
      //select new dprtId;
      select new { Id=dprtId.Key, Employee = string.Join(",", dprtId.Select(item => item.Name)) };
```

```C#
///Пример использования into вместе с select
int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
IEnumerable<int> 
    _squares = from number in numbers
            select number*number into squares
            select squares;
```
### 7. Пример использования join 
```C#
List<Student> students = new List<Student> 
{ 
    new Student { StudentId = 1, Name = "Ivanov", GroupId = 1 },
    new Student { StudentId = 2, Name = "Petrov", GroupId = 2 },
    new Student { StudentId = 1, Name = "Sidorov", GroupId = 1 },
};

List<StudentGroup> groups = new List<StudentGroup>
{
    new StudentGroup { GroupId = 1, Name = "Отличники" },
    new StudentGroup { GroupId = 2, Name = "Двоечники" }
};


//Вывод нового типа, который содержиь пары: имя студент и имя группы студента
var studentsInGroups = 
    from student in students
    join eachgroup in groups on student.GroupId equals eachgroup.GroupId
    select new { StudentName = student.Name, GroupName = eachgroup.Name };
;
```

### 8. Вложенного запроса 
```C#
IEnumerable<string> groupNames =
    from item in 

    /*Вложенный запрос из п.7*/

    from student in students
    join eachgroup in groups on student.GroupId equals eachgroup.GroupId
    select new { StudentName = student.Name, GroupName = eachgroup.Name }

    /*-----------------------*/
    
    select item.GroupName;
```
### 9. Пример использования агрегатной функции (Count() - метод fluent api)
```C#
int groupNamesCount =
    (from item in
        /*Вложенный запрос из п.7*/
        from student in students
        join eachgroup in groups on student.GroupId equals eachgroup.GroupId
        select new { StudentName = student.Name, GroupName = eachgroup.Name }
        /*-----------------------*/
    select item.GroupName).Count();
```




## let примеры

### 1.Возвращает коллекцию как есть
```C#
IEnumerable<Employer> asIs = source.Select(item => item);

//Func с передачей в select
//Идентичен запросу выше.

Func<Employer, Employer> funcOfEmployers = (item) => item;
asIs = source.Select(funcOfEmployers);
```

### 2. Пример с демонстрацией фильтров
```C#
IEnumerable<Employer> onlyIT = source.Where(item => item.Department.DepartmentName.Equals("ИТ"));

//2.' Пример с фильтрацией подходящей по определенному условию(отсуствует в декларативном синтаксисе)
List<IPerson> peoples = new List<IPerson>()
{
    new Child {  }
    , new Child {  }
    , new Parent { }
};

var onlyChilds = peoples.OfType<Child>().ToList();
```

### 3 Пример сортировки order by
```C#
IEnumerable<Employer> orderBy = source.OrderBy(item => item.Name); 
/*desc*/
orderBy = source.OrderByDescending(item => item.Name);
```

### 4. Пример group by
```C#
IEnumerable<IGrouping<int, Employer>> employee = source.GroupBy(item => item.Department.Id);
```
//5. Использования let нет в метод-синтаксисе

//6. Использования into нет в метод-синтаксисе

### 7. Пример использования join 
```C#
List<Student> students = new List<Student> 
{ 
    new Student { StudentId = 1, Name = "Ivanov", GroupId = 1 },
    new Student { StudentId = 2, Name = "Petrov", GroupId = 2 },
    new Student { StudentId = 3, Name = "Sidorov", GroupId = 1 },
};

List<StudentGroup> groups = new List<StudentGroup>
{
    new StudentGroup { GroupId = 1, Name = "Отличники" },
    new StudentGroup { GroupId = 2, Name = "Двоечники" }
};

//Вывод нового типа, который содержиь пары: имя студент и имя группы студента
var studentsInGroups = students.Join(groups,
                                    student => student.GroupId,
                                    eachGroup => eachGroup.GroupId,
                                    (student, eachGroup) => new { Name = student.Name, GroupName = eachGroup.Name });

```
### 8. Группировка с соединением

```C#
var personnel = groups.GroupJoin(students, // второй набор
             eachGroup => eachGroup.GroupId, // свойство-селектор объекта из первого набора
             student => student.GroupId, // свойство-селектор объекта из второго набора
             (jgroup, jstudents) => new   // результат
             {
                 GroupName = jgroup.Name,
                 Students = jstudents
             });
```
### 9. Пример использования агрегатной функции (Count() - метод fluent api)
```C# int groupNamesCount = students.Count();



//Анонимные типы (показать, если нужно будет)
/*decimal[] numbers = new decimal[] { 1.0M, 1.35M };
var apple = new { Item = "apples", Price = 1.35M };
var onSale = apple with { Price = 0.79M };

var apples = from number in numbers
             select apple with { Price = number };*/

Action<Employer> action = (x) => Console.WriteLine(x.Id);

action = null;

source.ForEach(
    action
    );

source.ForEach(
    item => Console.WriteLine(item.Name) /*Action*/
    );
;
```
## xml

```C#
using System.Xml.Linq;

XElement contacts = 
new XElement("Contacts",
    new XElement("Contact",
        new XElement("Name", "Patrick Hines"),
        new XElement("Phone", "206-555-0144",
            new XAttribute("Type", "Home")),
        new XElement("phone", "425-555-0145",
            new XAttribute("Type", "Work")),
        new XElement("Address",
            new XElement("Street1", "123 Main St"),
            new XElement("City", "Mercer Island"),
            new XElement("State", "WA"),
            new XElement("Postal", "68042")
        )
    )
);

IEnumerable<string> names = from item in contacts.Element("Contact").Elements()
              select item.ToString();

names = names.ToList();
;

```
### Parallel
```C#
 ParallelLoopResult result = Parallel.ForEach<int>(
       new List<int>() { 1, 3, 5, 8 },
       Square
);

;
// вычисляем квадрат числа
void Square(int n)
{
    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
    Console.WriteLine($"Квадрат числа {n} равен {n * n}");
    Thread.Sleep(2000);
}
```

## разбор запроса

```C#
//Набор данных
int[] numbers = { 1, 2, 3, 4, 5 };

// Запрос создается, но не выполняется
var query = from n in numbers
            where n > Get1()
            select n;
;

// Запрос выполнится только здесь, когда мы начнем итерировать результаты
foreach (var number in query)
{
    Console.WriteLine(number);
}

//int a = 
    numbers.Where(item => item > Get1()).Count();

;

int Get1()
{
    return 2;
}
```



## перебрать коллекцию c фильтром

```C#
List<string> strings = new List<string> { "A", "B", "C", null, "D", "A", "A" };

var stringSet = from s in strings
                where s != null
                select s;
;
```

## запрос к бд
```C#
 public DbSet<User> Users => Set<User>();
 public ApplicationContext() : base()
 {
     /*Database.EnsureDeleted();
     Database.EnsureCreated();
     this.SaveChanges();*/
 }

 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 {
     optionsBuilder.UseSqlServer("data source=localhost;initial catalog=Users;user=sa;password=********;App=EntityFramework;TrustServerCertificate=True");
 } 
```

```C#
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

using (ApplicationContext db = new ApplicationContext())
{
    // Добавить пользователей, если их нет в Db
    /*User tom = new User { Name = "Tom", Age = 33 };
    User alice = new User { Name = "Alice", Age = 26 };
    db.Add(tom);
    db.Add<User>(alice);
    db.SaveChanges();*/



    IQueryable<User> query = db.Users;
    query = query.Where(item => item.Age > 27);
    query = query.Where(item => item.Age < 34);
    List<User> users = query.ToList();
    ;
}

```

```C#
public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}
```