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