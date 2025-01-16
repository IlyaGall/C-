# Типы коллекций
* Массив
* Список
* Связный список

## Что такое массив
Массив — это структура данных фиксированной длины для хранения упорядоченного набора элементов. 
Элементы при этом должны относиться к одному типу данных.
Элементы массива физически хранятся в К каждому из них можно обратиться по mЭлементы массива идут друг за другом в памяти.



![Image alt](https://github.com/IlyaGall/C-/blob/main/21%20%D0%9E%D1%81%D0%BD%D0%BE%D0%B2%D0%BD%D1%8B%D0%B5%20%D0%BA%D0%BE%D0%BB%D0%BB%D0%B5%D0%BA%D1%86%D0%B8%D0%B8%20%D0%BC%D0%B0%D1%81%D1%81%D0%B8%D0%B2%2C%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA%2C%20%D1%81%D0%B2%D1%8F%D0%B7%D0%BD%D1%8B%D0%B9%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA/img/1.JPG)


### Массив как объект .NET
Особенности массивов в рамках .net:
1. Любой массив - это ссылочный тип данных.
2. Любой массив унаследован от Array.
3. Все массивы реализуют IList. Для получения доступа к элементу по индексу.
4. Все массивы реализуют IEnumerable коллекции.

### Виды массивов

![Image alt](https://github.com/IlyaGall/C-/blob/main/21%20%D0%9E%D1%81%D0%BD%D0%BE%D0%B2%D0%BD%D1%8B%D0%B5%20%D0%BA%D0%BE%D0%BB%D0%BB%D0%B5%D0%BA%D1%86%D0%B8%D0%B8%20%D0%BC%D0%B0%D1%81%D1%81%D0%B8%D0%B2%2C%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA%2C%20%D1%81%D0%B2%D1%8F%D0%B7%D0%BD%D1%8B%D0%B9%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA/img/2.JPG)

### Класс Array
Описание класса Array:
https://learn.microsoft.com/en-us/dotnet/api/system.array?view=net-8.0

<T> variable = Array.Method(exemplarOfArray, delegate());

Работа со статическими методами класса Array:
1. Возвращаемый тип: может быть коллекция, квантификатор и пр.
2. Экземпляр переменной.
3. Ключевое слово Array.
4. Статический метод: ForEach(), Sort() etc.
5. Экземпляр массива, над которым будет выполняться операция из п.4.
6. Делегат-обработчик массива.

### Вычислительная сложность в массивах
Вычислительная сложность массива:
1. Индексация – О(1). (см. рисунок ниже) Пояснение: address = array[0] + n*sizeof
2. Поиск – О(n). Требуется перебрать все элементы.
3. Вставка – не применимо.
4. Удаление – не применимо.

![Image alt](https://github.com/IlyaGall/C-/blob/main/21%20%D0%9E%D1%81%D0%BD%D0%BE%D0%B2%D0%BD%D1%8B%D0%B5%20%D0%BA%D0%BE%D0%BB%D0%BB%D0%B5%D0%BA%D1%86%D0%B8%D0%B8%20%D0%BC%D0%B0%D1%81%D1%81%D0%B8%D0%B2%2C%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA%2C%20%D1%81%D0%B2%D1%8F%D0%B7%D0%BD%D1%8B%D0%B9%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA/img/3.JPG)


## Список

Объект класса List<T> представляет строго
типизированный список объектов, к которым можно
получить доступ по индексу.
1. List хранит данные как обычный массив.
2. List более удобен в использовании, потому что:
i. Нет необходимости заранее задавать размер.
ii. Имеет место заранее описанный методов для работы с коллекцией.
iii. Добавление элемента в список происходит интуитивно понятным способом. 


![Image alt](https://github.com/IlyaGall/C-/blob/main/21%20%D0%9E%D1%81%D0%BD%D0%BE%D0%B2%D0%BD%D1%8B%D0%B5%20%D0%BA%D0%BE%D0%BB%D0%BB%D0%B5%D0%BA%D1%86%D0%B8%D0%B8%20%D0%BC%D0%B0%D1%81%D1%81%D0%B8%D0%B2%2C%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA%2C%20%D1%81%D0%B2%D1%8F%D0%B7%D0%BD%D1%8B%D0%B9%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA/img/4.JPG)

## Добавление элемента
Для добавления нового элемента необходимо сначала выделить новую область памяти в приложения, соответствующей объему массива, а потом скопировать элемент. 

![Image alt](https://github.com/IlyaGall/C-/blob/main/21%20%D0%9E%D1%81%D0%BD%D0%BE%D0%B2%D0%BD%D1%8B%D0%B5%20%D0%BA%D0%BE%D0%BB%D0%BB%D0%B5%D0%BA%D1%86%D0%B8%D0%B8%20%D0%BC%D0%B0%D1%81%D1%81%D0%B8%D0%B2%2C%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA%2C%20%D1%81%D0%B2%D1%8F%D0%B7%D0%BD%D1%8B%D0%B9%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA/img/5.JPG)


### Класс List
Описание класса List:

https://learn.microsoft.com/ru-ru/dotnet/api/system.collections.generic.list-1?view=net-8.0

Методы класса List:
* Добавление элемента в список
* Поиск элемента в списке
* Вставка элемента в список
* Удаление элемента списка
* Сортировка элементов

### Вычислительная сложность в списке
Вычислительная сложность массива:
1. Индексация – О(1).
2. Поиск – О(n).
3. Вставка – О(n).
4. Удаление Удаление – О(n).


## Связный список

### Что такое связный список
Связный список — базовая динамическая структура данных в информатике, состоящая из узлов, содержащих («связки») на следующий и/или предыдущий узел списка.

![Image alt](https://github.com/IlyaGall/C-/blob/main/21%20%D0%9E%D1%81%D0%BD%D0%BE%D0%B2%D0%BD%D1%8B%D0%B5%20%D0%BA%D0%BE%D0%BB%D0%BB%D0%B5%D0%BA%D1%86%D0%B8%D0%B8%20%D0%BC%D0%B0%D1%81%D1%81%D0%B8%D0%B2%2C%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA%2C%20%D1%81%D0%B2%D1%8F%D0%B7%D0%BD%D1%8B%D0%B9%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA/img/6.JPG)

В двусвязном списке сcылки в каждом узле указывают на предыдущий и на последующий узел в списке.

![Image alt](https://github.com/IlyaGall/C-/blob/main/21%20%D0%9E%D1%81%D0%BD%D0%BE%D0%B2%D0%BD%D1%8B%D0%B5%20%D0%BA%D0%BE%D0%BB%D0%BB%D0%B5%D0%BA%D1%86%D0%B8%D0%B8%20%D0%BC%D0%B0%D1%81%D1%81%D0%B8%D0%B2%2C%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA%2C%20%D1%81%D0%B2%D1%8F%D0%B7%D0%BD%D1%8B%D0%B9%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA/img/7.JPG)


### Представление данных в памяти приложения

Приведенная в примере с List последовательность будет выглядеть примерно следующим образом.

Это дает преимущество у LinekedList по сравнению с массивами – LinekedList может заполнить практически всю память доступную приложению.

![Image alt](https://github.com/IlyaGall/C-/blob/main/21%20%D0%9E%D1%81%D0%BD%D0%BE%D0%B2%D0%BD%D1%8B%D0%B5%20%D0%BA%D0%BE%D0%BB%D0%BB%D0%B5%D0%BA%D1%86%D0%B8%D0%B8%20%D0%BC%D0%B0%D1%81%D1%81%D0%B8%D0%B2%2C%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA%2C%20%D1%81%D0%B2%D1%8F%D0%B7%D0%BD%D1%8B%D0%B9%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA/img/8.JPG)


### Область применения LinkedList
1. Реализация стеков и очередей.
2. Менеджеры памяти и аллокаторы.
3. Реализация системы отмены действий (undo/redo).
Недостатки:
1. Медленный доступ на чтение.
2. Достаточно простое добавление.
3. Расход памяти на указатели.

![Image alt](https://github.com/IlyaGall/C-/blob/main/21%20%D0%9E%D1%81%D0%BD%D0%BE%D0%B2%D0%BD%D1%8B%D0%B5%20%D0%BA%D0%BE%D0%BB%D0%BB%D0%B5%D0%BA%D1%86%D0%B8%D0%B8%20%D0%BC%D0%B0%D1%81%D1%81%D0%B8%D0%B2%2C%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA%2C%20%D1%81%D0%B2%D1%8F%D0%B7%D0%BD%D1%8B%D0%B9%20%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA/img/9.JPG)


### Класс LinkedList
Описание класса LinkedList:

https://learn.microsoft.com/ru-ru/dotnet/api/system.collections.generic.linkedlist-1?view=net-8.0

Методы класса LinkedList:
* Добавление элемента в связный список
* Вставка элемента в связный список
* Удаление элемента связного списка
* Получение следующего/предыдущего элемента

### Вычислительная сложность в связных списках
Вычислительная сложность массива:
1. Индексация – не применимо.
2. Поиск – О(n).
3. Вставка – О(1).
4. Удаление – О(1).

## код работы с Массив
```C#
using System.Collections;

//1 Одномерный массив

//1.1 Инициализация массива(значения по умолчанию)
//int[] array = new int[3];

//1.2 Инициализация массива конкретными значениями
int[] array = new int[] { 1, 2 };
IList list = array;
IEnumerable numerable = array;

//1.3 Неявная инициализация массивов
int[] a = new /*тип не указан*/ [] { 1, 10, 100, 1000 };                      // int[]
var b = new /*тип не указан*/[] { "hello", null, "world" };                   // string[]

//1.4 Инициализация посредством статического метода CreateInstance класса Array
Array arr = Array.CreateInstance(typeof(int), 5);
arr.SetValue(1, 0);
arr.SetValue(2, 1);
int[] arrToInt = (int[])arr;
;

Console.WriteLine("Вывод одномерного массива");

for (int i = 0; i < array.Length; i++)
    Console.Write(array[i] + "\t");

//1.3 Ранг массива
int arrayRank = array.Rank;

//2 Двумерный массив
//2.1 Инициализация массива(значения по умолчанию)
//int[,] multiDimensionalArray = new int[3,4];
//multiDimensionalArray[0, 0] = 1;
//multiDimensionalArray[2, 2] = 10;

//2.2 Инициализация массива конкретными значениями
int[,] multiDimensionalArray = new int[2,3] { { 1, 2, 3 }, { 4, 5, 6 } };

int height = multiDimensionalArray.GetLength(0);
int weight = multiDimensionalArray.GetLength(1);

Console.WriteLine("\nВывод двумерного массива");
for (int i = 0; i < height; i++)
{
    for (int j = 0; j < weight; j++)
        Console.Write(multiDimensionalArray[i, j] + "\t");
    Console.WriteLine();
}

//3 Зубчатый массив
// 3.1 Инициализация массива
int[][] jaggedArray = new int[3][];
jaggedArray[0] = new int[] { 1, 3, 5, 7, 9 };
jaggedArray[1] = new int[] { 0, 2, 4, 6 };
jaggedArray[2] = new int[] { 11, 22 };


Console.WriteLine("\nВывод jagged-массива");
for (int i = 0; i < jaggedArray.Length; i++)
{
    Console.Write("{0}-й элемент: ", i);

    for (int j = 0; j < jaggedArray[i].Length; j++)
        Console.Write("{0}{1}", jaggedArray[i][j], j == (jaggedArray[i].Length - 1) ? "" : " ");
    
    Console.WriteLine();
}

//4 Класс Array
string[] people = { "Tom", "Sam", "Bob", "Kate", "Tom", "Alice" };

//4.1 Поиск элементов в массиве
Console.WriteLine("\nПоиск элементов в массиве");
Console.WriteLine (Array.IndexOf(people, "Bobx"/*Tommy*/));

//4.2 Сортировка в массиве
Console.WriteLine("\nСортировка в массиве");
Array.Sort(people);
//Console.WriteLine(Array.IndexOf(people, "Tom"));

//4.3 Операция foreach и вывод массива
Console.WriteLine("\nОперация foreach и вывод массива");

Array.ForEach(people, item => Console.Write(item + "\t"));

//4.4 Поиск всех эементов по условию
Console.WriteLine("\n\nПоиск всех эементов по условию");
string[] notToms = Array.FindAll(people, item => !item.Equals("Tom"));

Array.ForEach(notToms, item => Console.Write(item + "\t"));

//5 Сравнение массивов
Console.WriteLine("\n\nСравнение 2х массивов");
int[] array1 = new int[] {1};
int[] array2 = new int[] {1, 2};

bool arraysAreEqual = array1.SequenceEqual(array2);

Console.WriteLine("Массивы совпадают:" + arraysAreEqual);


int[,,] abc = new int [3,2,3];
;
/*live*/
//Задачи:
//Количество положительных элеметов массива(без ноля)
/*int[] numbers = { -4, -3, -2, -1, 0, 1, 2, 3, 4 };*/

```

## код работы list

```C#
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
```


### код работы с Список (компараторы)

```C#
   internal class Person : IComparable<Person>, IEquatable<Person>
   {
       public int Id { get; set; }
       public string Name { get; set; }
       public int Age { get; set; }

       public int CompareTo(Person other)
       {
           return this.Name.CompareTo(other.Name);
       }

       public bool Equals(Person other)
       {
           return this.Id == other.Id;
       }

       public override int GetHashCode()
       {
           return HashCode.Combine(Name, Age, Id);
           //return 0;
       }
   }
```

### компоратор Age
```C#
  internal class PersonAgeComparer : IComparer<Person>
  {
      int IComparer<Person>.Compare(Person x, Person y)
      {
          return x.Age - y.Age;
      }
  }
```

### компоратор name
```C#
 internal class PersonNameComparer : IComparer<Person>
 {
     int IComparer<Person>.Compare(Person x, Person y)
     {
         return x.Name.CompareTo(y.Name);
     }
 }
```

### компоратор name
```C#
internal class PersonNameEqComparer : IEqualityComparer<Person>
 {
     bool IEqualityComparer<Person>.Equals(Person x, Person y)
     {
         return x.Name.Equals(y.Name);
     }

     int IEqualityComparer<Person>.GetHashCode(Person obj)
     {
         return 0;
     }
 }
```

### кастомный компоратор
```C#
List<Person> persons = new List<Person>
{ 
    new Person { Id = 2, Name = "Eddie", Age = 5 },
    new Person { Id = 1, Name = "Alice", Age = 27 },
    new Person { Id = 0, Name = "Bob", Age = 30 },

};
persons.Sort();
//persons.Sort(new CompaerId());

;
class Person : IComparable<Person> 
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }

    int IComparable<Person>.CompareTo(Person? other)
    {
        // return this.Id - other.Id ;// если бьльше 0, то последовательность не меняется, если меньше, то меняется местами
        return this.Name.CompareTo(other.Name); // сравниваем string
    }
}
class CompaerId : IComparer<Person>
{
    int IComparer<Person>.Compare(Person? x, Person? y)
    {
        return y.Id - x.Id;
    }
    
}
```

## код работы с Связный список

```C#
//Связный список
using LinkedList;

//1 Инициализация
//1.1 Пустой св.список
LinkedList<string> empty = new LinkedList<string>();

//1.2 Инициализация св.списка
LinkedList<string> people = new LinkedList<string>(new List<string>{ "Tom", "Sam", "Bob" });

//2 Вывод списка
//2.1 Прямой
Console.WriteLine("Вывод значений свзяного списка(прямой порядок):");
for(LinkedListNode<string> currentNode = people.First; currentNode != null; currentNode = currentNode.Next)
    Console.Write(currentNode.Value + "\t");

//2.2 Обратный
Console.WriteLine("\n\nВывод значений свзяного списка(обратный порядок):");
for (LinkedListNode<string> currentNode = people.Last; currentNode != null; currentNode = currentNode.Previous)
    Console.Write(currentNode.Value + "\t");

//2.3 Вывод элементов с помощью while (просто для разнообразия)
Console.WriteLine("\n\nВывод значений свзяного списка(while):");
LinkedListNode<string> currentNodeW = people.First;
while (currentNodeW != null)
{
    Console.Write(currentNodeW.Value + "\t");
    currentNodeW = currentNodeW.Next;
}


//3 вставка элемента
//3.1 После выбранной ноды
for (LinkedListNode<string> currentNode = people.First; currentNode != null; currentNode = currentNode.Next)
    if (currentNode.Value.Equals("Sam"))
        people.AddAfter(currentNode, "John");

Console.WriteLine("\n\nВставка элемента после выбранной ноды:");
LinkedListViewer.Show(people);

//3.2 До выбранной ноды
for (LinkedListNode<string> currentNode = people.First; currentNode != null; currentNode = currentNode.Next)
    if (currentNode.Value.Equals("Sam"))
        people.AddBefore(currentNode, "James");

Console.WriteLine("\n\nВставка элемента после выбранной ноды:");
LinkedListViewer.Show(people);

//4 Удаление элемента
//4.1 Первого
people.RemoveFirst();
Console.WriteLine("\n\nУдаление первого элемента:");
LinkedListViewer.Show(people);

//4.2 Последнего
people.RemoveLast();
Console.WriteLine("\n\nУдаление последнего элемента:");
LinkedListViewer.Show(people);

//5 Добавление элемента
//5.1 В начало списка
people.AddFirst(new LinkedListNode<string>("Alice"));
Console.WriteLine("\n\nДобавлеение первого элемента:");
LinkedListViewer.Show(people);

//5.1 В начало списка
people.AddLast(new LinkedListNode<string>("Jenifer"));
Console.WriteLine("\n\nДобавлеение последнего элемента:");
LinkedListViewer.Show(people);

//6 Попытка закольцовывания связного список
//LinkedListNode<string> first = people.First;
//people.AddLast(first);
//LinkedListViewer.Show(people);
```

```C#
 internal class LinkedListViewer
 {
     public static void Show(LinkedList<string> linkedListFirstNode)
     {
         for (LinkedListNode<string> currentNode = linkedListFirstNode.First; currentNode != null; currentNode = currentNode.Next)
             Console.Write(currentNode.Value + "\t");
     }
 }
```