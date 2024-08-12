# Алгоритмы и их сравнения

## Определение “алгоритм”
* Последовательность действий, для решения некоторой задачи Пример: вычисление площади (треугольника, квадрата)
* Для чего нам может понадобиться сравнивать алгоритмы между собой?
Наводящий пример: обмен значений переменных

## Сравнение алгоритмов

```C#
int a= 5;
int b = 7;
int temp;

temp = b
b = a;
a = temp;
```

```C#
int a= 5;
int b = 7;

a = a + b;
b = a - b;
a = a - b;
```

Второй быстрее, так как работает ссылками и не создаёт новую переменную

**По каким критериям мы можем сравнить алгоритмы?**
* Память
* Время выполнения (скорость)

**Сравнение алгоритмов - способы:**
* Аналитический
* Экспериментальный

## Big O
Сложность алгоритма - это количественная характеристика, которая говорит о том, сколько времени\памяти потребуется для выполнения алгоритма.
Big O показывает, как сложность алгоритма растёт с увеличением входных данных. Она всегда показывает худший вариант развития событий - верхнюю границу.
Зачем изучать Big O:
* Чтобы уметь видеть и исправлять неоптимальный код.
* Спрашивают на собеседованиях.
* Потеря производительности от непонимания Big O.

Попробуем разобраться…


## Сложность О(1) - константная 
Допустим, у нас есть массив:
```C# 
var array = new int[] {1, 2, 3, 4, 5};
```
Какова сложность доступа к элементу?
```c#
array[0]
array[1]
array[2]
```

Для доступа к элементу массива время, затраченное на его получение - константа.
Сложность О(1) означает, что время, затрачиваемое на выполнение не зависит от входных данных.

Массив в памяти располагается лийно друг за другом, поэтому время у него линейно

## Сложность O(n) - линейная
```C#
var array = new int[] {7, 18, 158, 16, 23};
public void FindElement(int[] array, int element)
{
    for(int i = 0; i < array.Length; i++)
    {
        if(array[i] == element)
        // do something
    }
}

```
Сколько элементов надо перебрать, чтобы найти нужный?


Сложность алгоритма увеличивается линейно с увеличением входных данных.
FindElement на массиве из 10 элементов отработает за Х микросекунд.
А на массиве из 100..10 000 элементов уже за Х*10 … Х*100 микросекунд

## Сложность O(n^2) - квадратичная

```C#
var array = new int[] {7, 18, 158, 16, 23};
public void FindElement(int[] array, int element)
{
    for(int i = 0; i < array.Length; i++)
    {
        for(int j = 0; j < array.Length; j++)
        {
        if(array[i] == array[j] && i != j)
        // do something
        }
    }
}
```

Удвоение размера входных данных увеличивает время выполнения в 4 раза.
Например, при увеличении данных в 10 раз, количество операций (и время выполнения) увеличится примерно в 100 раз.
Если алгоритм имеет квадратичную сложность, то это повод пересмотреть необходимость использования данного алгоритма. Но иногда этого не избежать.

## Сложность O(log n) - логарифмическая
```C#
var array = new int[] {7, 16, 18, 23, 158};
public void FindElement(int[] array, int element)
{
    int median = array.Length / 2;
    int startIndex = 0;
    if (array[median] > element)
    {
        startIndex = median;
    }
    for(int i = 0; i < array.Length; i++)
    {
        if(array[i] == element)
        // do something
    }
}
```

Сложность алгоритма растёт логарифмически с увеличением входных данных.
Другими словами это такой алгоритм, где на каждой итерации берётся половина элементов. 

O(n) * O(log n)
Удвоение размера входных данных увеличит время выполнения чуть более, чем вдвое.
**Можно ли улучшить пример с поиском повторяющихся значений с O(n^2) до O(n * log n) ?**

![Image alt](https://github.com/IlyaGall/C-/blob/main/13%20%D0%90%D0%BD%D0%B0%D0%BB%D0%B8%D0%B7%20%D1%81%D0%BB%D0%BE%D0%B6%D0%BD%D0%BE%D1%81%D1%82%D0%B8%20%D0%B0%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC%D0%BE%D0%B2%20%D0%B8%20%D1%81%D0%BE%D1%80%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%BA%D0%B0/img/1.PNG)


## Сортировки

Алгоритмы сортировок

* Пузырьком 
* Быстрая
* Вставками 
* Перемешиванием
* Слиянием 
* Расческой
* и.д.

![Image alt](https://github.com/IlyaGall/C-/blob/main/13%20%D0%90%D0%BD%D0%B0%D0%BB%D0%B8%D0%B7%20%D1%81%D0%BB%D0%BE%D0%B6%D0%BD%D0%BE%D1%81%D1%82%D0%B8%20%D0%B0%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC%D0%BE%D0%B2%20%D0%B8%20%D1%81%D0%BE%D1%80%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%BA%D0%B0/img/2.PNG)

Сортировка позырьком:

![Image alt](https://github.com/IlyaGall/C-/blob/main/13%20%D0%90%D0%BD%D0%B0%D0%BB%D0%B8%D0%B7%20%D1%81%D0%BB%D0%BE%D0%B6%D0%BD%D0%BE%D1%81%D1%82%D0%B8%20%D0%B0%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC%D0%BE%D0%B2%20%D0%B8%20%D1%81%D0%BE%D1%80%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%BA%D0%B0/img/3.PNG)

Сортировка вставками:

![Image alt](https://github.com/IlyaGall/C-/blob/main/13%20%D0%90%D0%BD%D0%B0%D0%BB%D0%B8%D0%B7%20%D1%81%D0%BB%D0%BE%D0%B6%D0%BD%D0%BE%D1%81%D1%82%D0%B8%20%D0%B0%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC%D0%BE%D0%B2%20%D0%B8%20%D1%81%D0%BE%D1%80%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%BA%D0%B0/img/4.PNG)

Сортировка быстрая:

![Image alt](https://github.com/IlyaGall/C-/blob/main/13%20%D0%90%D0%BD%D0%B0%D0%BB%D0%B8%D0%B7%20%D1%81%D0%BB%D0%BE%D0%B6%D0%BD%D0%BE%D1%81%D1%82%D0%B8%20%D0%B0%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC%D0%BE%D0%B2%20%D0%B8%20%D1%81%D0%BE%D1%80%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%BA%D0%B0/img/5.PNG)

Сложность сортировок:

![Image alt](https://github.com/IlyaGall/C-/blob/main/13%20%D0%90%D0%BD%D0%B0%D0%BB%D0%B8%D0%B7%20%D1%81%D0%BB%D0%BE%D0%B6%D0%BD%D0%BE%D1%81%D1%82%D0%B8%20%D0%B0%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC%D0%BE%D0%B2%20%D0%B8%20%D1%81%D0%BE%D1%80%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%BA%D0%B0/img/6.PNG)

## полезные ссылки (хабр)

* [Big O](https://habr.com/ru/articles/444594/)
* [Знай сложности алгоритмов](https://habr.com/ru/articles/188010/)
* [Быстрая сортировка](https://dyzzet.ru/a/quicksort/)



## пример кода по алгоритмам(работа в цикле с массивом)
```C#
﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace AlgoComplexity
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new Stopwatch();

            int size = 50000;
            
            int[] array = new int[size];

            var rnd = new Random(40);
            
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(0, 5000);
                if (array[i] % 2 == 0)
                {
                    array[i] += 1;
                }
            }
            
            st.Start();
            for (int i = 0; i < size; i++)
            {
                array[i] += 1;
                
            }
            st.Stop();
            Console.WriteLine($"Not sort = {st.ElapsedTicks}");
            
            st.Reset();
            
            Array.Sort(array);
            
            st.Start();
            for (int i = 0; i < size; i++)
            {
                array[i] += 1;
                
            }
            st.Stop();
            Console.WriteLine($"After sort = {st.ElapsedTicks}");
        }

        public static bool LongCalc()
        {
            Thread.Sleep(2000);
            return false;
        }
        
        
        static void arrayIncrement()
        {
            var st = new Stopwatch();

            int size = 5000;

            int[,] array = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = i + j;
                }
            }
            
            st.Start();
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] += 1;
                }
            }
            
            st.Stop();
            
            Console.WriteLine($"array[i, j] += 1; took {st.ElapsedMilliseconds}ms; {st.ElapsedTicks} ticks");
            
            st.Reset();
            
            st.Start();
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[j, i] += 1;
                }
            }
            
            st.Stop();
            
            Console.WriteLine($"array[j,i] += 1; took {st.ElapsedMilliseconds}ms; {st.ElapsedTicks} ticks");
        }

        static float CalcFolderSize(string path)
        {
            float result = 0;
            
            List<string> directories = Directory.EnumerateDirectories(path).ToList();

            int i = 0;
            while (i < directories.Count)
            {
                try
                {
                    directories.AddRange(Directory.EnumerateDirectories(directories[i]).ToList());
                    ++i;
                }
                catch (UnauthorizedAccessException ex)
                {
                    
                }
                
            }
            
            foreach (var dir in directories)
            {
                foreach (var file in Directory.EnumerateFiles(dir))
                {
                    try
                    {
                        var info = new FileInfo(file);
                        result += info.Length;
                    }
                    catch (UnauthorizedAccessException ex)
                    {}
                }
            }
            
            return result;
        }
    }
}
```

## пример кода сортировки

```C#
using System;
using System.Diagnostics;

namespace AlgoComplexity
{
    public class Sorts
    {
        public static void Bubble(int length = 10)
        {
            //int length = 10;
            int[] array = new int[length];
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(0,100);
            }
            
            Console.WriteLine($"Bubble Source: {String.Join(',', array)}");

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (array[i] > array[j])
                    {
                        var tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                }
            }
            
            Console.WriteLine($"Bubble Sorted: {String.Join(',', array)}");
            
        }
        
        public static void Insertion(int length = 10)
        {
            //int length = 10;
            int[] array = new int[length];
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(0,10);
            }
            
            // Console.WriteLine($"Insertion Source: {String.Join(',', array)}");

            for (int i = 1; i < length; i++)
            {
                var key = array[i];
                var flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (key < array[j])
                    {
                        array[j + 1] = array[j];
                        j--;
                        array[j + 1] = key;
                    }
                    else flag = 1;
                }
            }
            
            // Console.WriteLine($"Insertion Sorted: {String.Join(',', array)}");
            
        }

        public static void Quick(int length = 10)
        {
            // int length = 5;
            int[] array = new int[length];
            var random = new Random(42);
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(0,10);
            }
            
            //Console.WriteLine($"Quick Source: {String.Join(',', array)}");

            Sorts.QuickSortRecursive(array, 0, array.Length - 1);
            
            //Console.WriteLine($"Quick Sorted: {String.Join(',', array)}");
        }
        
        public static int[] QuickSortRecursive(int[] array, int leftIndex, int rightIndex)
        {
            // Console.WriteLine($"Source array: {String.Join(',', array)} LeftIndex:{leftIndex} RightIndex:{rightIndex}");
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }
        
                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            // Console.WriteLine($"Source array after pivot ordering: {String.Join(',', array)}");
            // Console.WriteLine(Environment.NewLine);
            if (leftIndex < j)
                Sorts.QuickSortRecursive(array, leftIndex, j);
            if (i < rightIndex)
                Sorts.QuickSortRecursive(array, i, rightIndex);
            return array;
        }
    }
}
```