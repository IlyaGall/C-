using Lists;

//1 Списки
//1.1 Инициализация списка(пустой)
//List<string> people = new List<string>();
//1.2 Инициализация списка начальными значениями

List<string> people = new List<string>() { "Tom", "Bob", "Sam", "James", "Tom", "Alex" };

//1.2' Вывод списка
Console.WriteLine("Вывод списка people");
people.ForEach(item => Console.Write(item + "\t"));

//1.3 Инициализация списка c заданием начальной емкости 
List<int> numbers = new List<int>(1000);                  //Задается свойство Capacity = 16

for(int i = 0; i < numbers.Count; i++)
    numbers.Add(i);                                     //Показать исходный код метода Add

//Вывод списка
Console.WriteLine("\n\nВывод списка numbers");
numbers.ForEach(item => Console.Write(item + "\t"));


//2.1 Добавление элемента в список
people.Add("Alice");
Console.WriteLine("\n\nДобавление элемента (Alice) в список");
people.ForEach(item => Console.Write(item + "\t"));

//3.1 Вставка элемента в список
people.Insert(2, "John");
Console.WriteLine("\n\nВставка элемента (John) в список");
people.ForEach(item => Console.Write(item + "\t"));

//4.1 Удаление элемента в списке 
//4.1.1 По индексу
people.RemoveAt(2);
Console.WriteLine("\n\nУдаление элемента в списке по индексу(2)");
people.ForEach(item => Console.Write(item + "\t"));

//4.1.2 По значению
people.Remove("Alice");
Console.WriteLine("\n\nУдаление элемента в списке по значению (Alice)");
people.ForEach(item => Console.Write(item + "\t"));

//4.1.3 По условию
people.RemoveAll(item => item.Length == 3 );
Console.WriteLine("\n\nУдаление элемента в списке по условию длина имени = 3");
people.ForEach(item => Console.Write(item + "\t"));

//5.1 Сортировка в списке
//5.1.1 по умолчанию
people.Sort();
Console.WriteLine("\n\nСортировка в списке");
people.ForEach(item => Console.Write(item + "\t"));

//5.1.2 сортировка списка с помощью компаратора
List<Person> persons = new List<Person> 
{ new Person { Id = 2, Name = "Eddie", Age = 5 },
    new Person { Id = 1, Name = "Alice", Age = 27 },
    new Person { Id = 0, Name = "Bob", Age = 30 },
    
};

//5.1.2.1 Сортировка списка с помощью компаратора по умолчанию(IComparable)
Console.WriteLine("\n\nСортировка списка с помощью компаратора по умолчанию");
persons.Sort();
persons.ForEach(item => Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Age));

//5.1.2.2 Сортировка списка с помощью компаратора по имени
Console.WriteLine("\n\nСортировка списка с помощью компаратора(по имени)");
persons.Sort(new PersonNameComparer());
persons.ForEach(item => Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Age));

//5.1.2.3 Сортировка списка с помощью компаратора по возрасту
Console.WriteLine("\n\nСортировка списка с помощью компаратора(по возрасту)");
persons.Sort(new PersonAgeComparer());
persons.ForEach(item => Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Age));

//5.1.2.4 Сортировка Comparison
persons.Sort((item, item2) => item.Id.CompareTo(item2.Id));

//6.1 Удаление дубликатов в списке
//6.1.1 Удаление дубликатов в списке (по умолчанию)
Console.WriteLine("\n\nУдаление дубликатов в списке по умолчанию");
people.Add("John");
people = people.Distinct().ToList();
people.ForEach(item => Console.Write(item + "\t"));

//6.1.2 Удаление дубликатов в списке для пользовательских типов  по умолчанию (IEquatable - по Id)
Console.WriteLine("\n\nУдаление дубликатов в списке по внутреннему компаратору");
persons.Add(new Person { Id = 1, Name = "John", Age = 0 });
persons = persons.Distinct().ToList();                      //disinct - различающиеся
persons.ForEach(item => Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Age));

//6.1.3 Удаление дубликатов в списке для пользовательских типов по компаратору
Console.WriteLine("\n\nУдаление дубликатов в списке по умолчанию по компаратору");
persons.Add(new Person { Id = 5, Name = "Alice", Age = 0 });
persons = persons.Distinct(new PersonNameEqComparer()).ToList();
persons.ForEach(item => Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Age));

//7.1 Поиск элемента в списке
Console.WriteLine("\n\nПоиск элемента в списке");
Console.WriteLine("James = " + people.IndexOf("James"));
Console.WriteLine("Alice = " + people.IndexOf("Alice"));


//8 Пересечение коллекций
List<string> firstList = new List<string> { "A", "B", "C" };
List<string> secondList = new List<string> { "B", "C", "D" };

var thirdList = firstList.Intersect(secondList);

;
/*live*/
//Задачи:
//1. Проинициализируйте List размером 16 и заполните его данными.
//2. Просортируйте члены List<string> в порядке, обратному алфавитному (можно через реализацию: IComparer, Comparison, etc.)
//3. Найдите пересечение множеств, указанных выше.


//List<string> list_ = new List<string> { 1, "1", "Ж", "A", "0" };

List<string> list_ = new List<string> {"Masha1234", "123Sasha"  } ;
list_.Sort();
;