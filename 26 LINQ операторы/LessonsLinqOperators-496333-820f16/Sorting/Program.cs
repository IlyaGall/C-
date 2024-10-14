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

;

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

;

//ThenByDescending уже лень :)


//Reverse
students.Reverse();
;

//IComparer<Student> comparer = new StudComparer()