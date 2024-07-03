## Что такое
Коллекции – объекты, позволяющие хранить другие связные объекты в качестве
набора данных
Сегодня будем разбирать
Массивы (Array)
Списки (List<T> - обобщенный список с элементами типа T)

## Массив

Массив – коллекция с постоянным доступом к элементам и фиксированного размера
Синтаксис
string[] ar = new string[10];
Инициализировали массив ar на 10 строк
int[] ints = new int[5];
Инициализировали массив ints на 5 целых чисел

### Особенности
* Доступ к элементам за постоянное время по индексу-числу
* Нумерация – с 0 (нуля)
* Размер массива – не меняется
* Как следствие – нельзя удалить/добавить элемент
* При создании массива – заполняется значениями по умолчанию (int[] – массив из
0, bool[] – массив из false, string[] – массив из NULL)


### Что умеет
* Доступ к элементу – при помощи [индекс], индекс начинается с 0
```c#
int[] arr = new int[10];
Console.WriteLine(arr[0]); // Доступ к 1-ому элементу
Console.WriteLine(arr[4]); // Доступ к 5-ому элементу
Console.WriteLine(arr[10]); // Ошибка - доступ к 11 элементу, хотя элементов 10
```
* Количество элементов
```c#
int[] arr = new int[10];
Console.WriteLine(arr.Length) // 10
```

### пример работы с массивом
```c#
            // ## МАССИВЫ

            var arrayOfNumber = new int[7];
            Console.WriteLine(arrayOfNumber.Length);
            Console.WriteLine(PrintArray(arrayOfNumber));

            arrayOfNumber[0] = 17;

            arrayOfNumber[5] = 8522;
            Console.WriteLine(PrintArray(arrayOfNumber));
            arrayOfNumber[6] = 10000;
            Console.WriteLine(PrintArray(arrayOfNumber));

            Console.WriteLine(arrayOfNumber[4] + 19);

            var arrayOfNumber1 = new int[] { 1242, 444, 22142, 512, 512, 512, 51, 25 };

            Console.WriteLine("============");
            Console.WriteLine($"Size = {arrayOfNumber1.Length} {PrintArray(arrayOfNumber1)}");


            int[] arrayOfNumber2 = [12444442, 2, 224142, 512, 512, 512, 51, 25, 044, -1];

            Console.WriteLine("============");
            Console.WriteLine($"Size = {arrayOfNumber2.Length} {PrintArray(arrayOfNumber2)}");



            string aaaa = "asfafasfasf";
            Console.WriteLine("============");
            Console.WriteLine(PrintArray(Quadratic(1, 1, 1)));// x^2+x+1

            Console.WriteLine(PrintArray(Quadratic(1, -2, 1))); // x^2-2x+1


            Console.WriteLine(PrintArray(Quadratic(1, -4, 3))); // x^2 - 4x + 3


            string[] arrayOfstrings = new[] { "asfaf", "qqqq" };
            arrayOfstrings = new[] { "", "", "", "", "", "", "", "", "", };
            // a* x^2 + b * x + c = 0


```

### дискрименант
```c#
  static double[] Quadratic(double a, double b, double c)
  {
      double[] res;
      var d = b * b - 4 * a * c;
      if (d < 0)
      {

          res = new double[0];
      }
      else
      {
          var a1 = (-b - Math.Sqrt(d)) / (2 * a);

          var a2 = (-b + Math.Sqrt(d)) / (2 * a);

          res = a1 == a2 ? [a1] : [a1, a2];

      }
      return res;
  }
```

### превращения массива в строку

```c#
  /// <summary>
  /// превращение массива в строку
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="array"></param>
  /// <returns></returns>
  static string PrintArray<T>(T[] array)
  {
      return $"[{string.Join(", ", array)}]";
  }
```

### массиво массивов
```c#
            #region массив массивов

            int[][] arraOfArra = new int[3][];

            arraOfArra[0] = [1, 23, 4, 5];
            arraOfArra[1] = [1];
            arraOfArra[2] = [
                44444,
                    4,
                    4,
                    4,
                    4,
                    4,
                    4,
                    4,
                    2,
                    44,
                    12414,
                     4,
                    1254, // ошибки не будет из-за
                 ];

            foreach (var i in arraOfArra)
            {
                foreach (var j in i)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
            #endregion
```


## Списки

Списки (List<T>) – коллекции значений произвольной длины Содержатся в пространстве System.Collections.Generic
List<T> - обобщенный тип (Generic, дженерик), для каждого типа используется свой класс (вместо T)

![Image alt](https://github.com/IlyaGall/C-/blob/main/06%20%D0%9C%D0%B0%D1%81%D1%81%D0%B8%D0%B2%20%D0%B8%20%D0%BB%D0%B8%D1%81%D1%82/img/1.PNG)


* var intl1 = new List<int>() – список чисел типа int
* var intl2 = new List<int>(100) – список чисел типа
int заранее указанного размера 100 элементов
* var intl3 = new List<int>(new[] { 1, 2, 3, 4, 5 })
– список элементов с заранее указанными элементами:
числами 1, 2, 3, 4, 5


* Добавление элемента – легко
```c#
var l = new List<int>(new[] { 1, 2, 3, 4, 5 });
l.Add(1000); // Добавить в конец
l.Insert(2, 100); // Добавить на 2ую позицию
// Будет 1, 2, 100, 3, 4, 5, 1000
```
* Удаление элемента – легко
```c#
var l = new List<int>(new[] { 1, 2, 3, 4, 5, 3 });
l.Remove(3); // Удаляет первую попавшуюся тройку
l.RemoveAt(3); // Удаляет элемент на позиции 3 (после пред. Операции – 5)
// Будет 1, 2, 4, 3
```
* Доступ к элементу списка – также как и в массиве, при помощи []


### ArrayList (лучше не использовать!)
Список из разнотипных элементов
```c# 
var f = new ArrayList();
f.Add("Пример");
f.Add(12);
f.Add(true);
```
В новых проектах – лучше использовать
List<object>

### LinkedList
Двунаправленный список
У каждого элемента ссылка на следующий (как у List) элемента и предыдущий
```c#
var ll = new LinkedList<int>();
ll.AddLast(1); // [1]
ll.AddLast(2); // [1, 2]
ll.AddLast(3); // [1, 2, 3]
ll.AddFirst(8); // [8, 1, 2, 3]
var last = ll.AddLast(4); // [8, 1, 2, 3, 4] last = 4
ll.AddBefore(last, 5); // [8, 1, 2, 3, 5, 4]
```

### пример листа
```c#
      #region list
      var listOfInts1 = new List<int>(); // инцилизация
      var listOfInts2 = new List<int>(100) { 0, 9, 1, 3, 33, 45, 4, 5, 6, 66, 1234214, 6 };// инцилизация
      var listOnInts3 = new List<int>(100); // инцилизаци ( с размерностью для оптимизации)
      // если этого не делать, то умолчанию List<int>(4), если вылезает за 4, то 8, потом 16, 32 и т.д.




      Console.WriteLine(PrintList(listOfInts2));

      listOfInts2.Add(-4); //добавление элемента 1
      listOfInts2.AddRange([-42, -4444, -1]); // добавление массива
      listOfInts2.InsertRange(1, [44, 444, 4444]); // добавление массива по индексу
      listOfInts2.Insert(2, 777); // добавление элемента в указанное место (index, item)
      listOfInts2[4] = -101010; // перезапись элемента
      listOfInts2.Remove(6); //удаление элемента(ищет "6" item)
      listOfInts2.RemoveAt(1); // удаление по индексу
      listOfInts2.RemoveAll(IsOdd);// удаление с помощью ф-и
      listOfInts2.RemoveRange(2, 3);// удаление с помощью ф-и(начальная позиция и кол-во  item)

      var oddNumbers = new List<int>(listOfInts2.Count / 2); // создание новой копии листа
      for (var i = 0; i < listOfInts2.Count; i++)
      {
          if (i % 2 != 0)
          {
              listOfInts2.RemoveAt(i);
          }
      }
      #endregion
```

###    LinkedList
```c#
         #region LinkedList
            var linked2 = new LinkedList<int>(); 
            linked2.AddLast(9999);// добовление элемента
            var b = linked2.AddLast(888); // отличие в том, что мы можем прикрепить ссылку на объект и к этому объекту присвоить значение
            var linked = new LinkedList<int>();
            linked.AddLast(100);
            linked.AddLast(101);
            var a = linked.AddLast(1001);
            linked.AddFirst(-1001);
            linked.AddBefore(a, b);
            #endregion
```