using System.Xml.Linq;
using System.Linq;
using LinqExamples;
using LinqUndeclarativeExamples;


//Инициализация коллекции 
List<Employer> source = new List<Employer>()
{
    new Employer{ Id = 1, Name = "Alice", Department = new Department{ Id = 1, DepartmentName = "Бухгалтерия" } }
    , new Employer{ Id = 2, Name = "John", Department = new Department{ Id = 1, DepartmentName = "Бухгалтерия" } }
    , new Employer{ Id = 3, Name = "Bob" , Department = new Department{ Id = 2, DepartmentName = "ИТ"} }
    , new Employer{ Id = 4, Name = "James", Department = new Department{ Id = 2, DepartmentName = "ИТ"}  }
};


//1. Самый простой запрос без условий. Возвращает коллекцию как есть
IEnumerable<Employer> asIs = source.Select(item => item);

//Func с передачей в select
//Идентичен запросу выше.

Func<Employer, Employer> funcOfEmployers = (item) => item;
asIs = source.Select(funcOfEmployers);


//2. Пример с демонстрацией фильтров
IEnumerable<Employer> onlyIT = source.Where(item => item.Department.DepartmentName.Equals("ИТ"));

//2.' Пример с фильтрацией подходящей по определенному условию(отсуствует в декларативном синтаксисе)
List<IPerson> peoples = new List<IPerson>()
{
    new Child {  }
    , new Child {  }
    , new Parent { }
};

var onlyChilds = peoples.OfType<Child>().ToList();


//3. Пример сортировки order by
IEnumerable<Employer> orderBy = source.OrderBy(item => item.Name); 
/*desc*/
orderBy = source.OrderByDescending(item => item.Name);

//4. Пример group by
IEnumerable<IGrouping<int, Employer>> employee = source.GroupBy(item => item.Department.Id);

//5. Использования let нет в метод-синтаксисе

//6. Использования into нет в метод-синтаксисе

//7. Пример использования join 
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


//8. Группировка с соединением
var personnel = groups.GroupJoin(students, // второй набор
             eachGroup => eachGroup.GroupId, // свойство-селектор объекта из первого набора
             student => student.GroupId, // свойство-селектор объекта из второго набора
             (jgroup, jstudents) => new   // результат
             {
                 GroupName = jgroup.Name,
                 Students = jstudents
             });


//9. Пример использования агрегатной функции (Count() - метод fluent api)
int groupNamesCount = students.Count();



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