using System.Xml.Linq;
using System.Linq;
using LinqExamples;


//Инициализация коллекции 
List<Employer> source = new List<Employer>()
{
    new Employer{ Id = 1, Name = "Alice", Department = new Department{ Id = 1, DepartmentName = "Бухгалтерия" } }
    , new Employer{ Id = 2, Name = "John", Department = new Department{ Id = 1, DepartmentName = "Бухгалтерия" } }
    , new Employer{ Id = 3, Name = "Bob" , Department = new Department{ Id = 2, DepartmentName = "ИТ"} }
    , new Employer{ Id = 4, Name = "James", Department = new Department{ Id = 2, DepartmentName = "ИТ"}  }
};


//1. Самый простой запрос без условий. Возвращает коллекцию как есть
IEnumerable<Employer> 
    asIs = 
            from item in source
            select item;

//2. Пример с демонстрацией фильтров
IEnumerable<Employer>
    onlyIT =
            from item in source
            where item.Department.DepartmentName.Equals("ИТ")
            select item;

//3. Пример сортировки order by
IEnumerable<Employer> 
    orderBy =
            from item in source
            //where item.Department.DepartmentName.Equals("ИТ")
            orderby item.Name /*ascending*/ /*descending*/
            select item;

//4. Пример group by
IEnumerable<IGrouping<int,Employer>>
    employee 
    = 
        from item in source
        //where item.Department.DepartmentName.Equals("ИТ")
        group item by item.Department.Id;

//5. Пример использования let
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

//6. Пример использования into вместе с group
//IEnumerable<string>
var
emplWithHashCode
    = from item in source
      group item by item.Department.Id into dprtId
      //select dprtId; /*Тип dprtId - IGrouping<int,Employer> */
      //select new dprtId;
      select new { Id=dprtId.Key, Employee = string.Join(",", dprtId.Select(item => item.Name)) };

//6.' Пример использования into вместе с select
int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
IEnumerable<int> 
    _squares = from number in numbers
            select number*number into squares
            select squares;
;

//7. Пример использования join 
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

//8. Пример вложенного запроса 
IEnumerable<string> groupNames =
    from item in 

    /*Вложенный запрос из п.7*/

    from student in students
    join eachgroup in groups on student.GroupId equals eachgroup.GroupId
    select new { StudentName = student.Name, GroupName = eachgroup.Name }

    /*-----------------------*/
    
    select item.GroupName;

//9. Пример использования агрегатной функции (Count() - метод fluent api)
int groupNamesCount =
    (from item in

        /*Вложенный запрос из п.7*/

        from student in students
        join eachgroup in groups on student.GroupId equals eachgroup.GroupId
        select new { StudentName = student.Name, GroupName = eachgroup.Name }

        /*-----------------------*/

    select item.GroupName).Count();
