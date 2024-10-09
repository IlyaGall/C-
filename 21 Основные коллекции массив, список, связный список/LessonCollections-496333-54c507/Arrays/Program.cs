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
