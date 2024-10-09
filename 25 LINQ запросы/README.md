# Стек и очередь

![Image alt](https://github.com/IlyaGall/C-/blob/main/22%20%D0%9E%D1%81%D0%BD%D0%BE%D0%B2%D0%BD%D1%8B%D0%B5%20%D0%BA%D0%BE%D0%BB%D0%BB%D0%B5%D0%BA%D1%86%D0%B8%D0%B8%20%D0%BE%D1%87%D0%B5%D1%80%D0%B5%D0%B4%D1%8C%2C%20%D1%81%D1%82%D0%B5%D0%BA%2C%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%D1%80%D1%8C%2C%20%D1%85%D0%B5%D1%88%D1%81%D0%B5%D1%82%20%20%D0%94%D0%97/img/1.JPG)




## дополнительный код

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