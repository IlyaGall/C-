using System.Text;
using System.Collections.Generic;
using static System.Console;
using System.ComponentModel;


// ## МАССИВЫ

//var arrayOfNumber = new int[7];
//WriteLine(arrayOfNumber.Length);
//WriteLine(PrintArray(arrayOfNumber));

//arrayOfNumber[0] = 17;

//arrayOfNumber[5] = 8522;
//WriteLine(PrintArray(arrayOfNumber));
//arrayOfNumber[6] = 10000;
//WriteLine(PrintArray(arrayOfNumber));

//WriteLine(arrayOfNumber[4] + 19);

//var arrayOfNumber1 = new int[] { 1242, 444, 22142, 512, 512, 512, 51, 25 };

//WriteLine("============");
//WriteLine($"Size = {arrayOfNumber1.Length} {PrintArray(arrayOfNumber1)}");


//int[] arrayOfNumber2 = [12444442, 2, 224142, 512, 512, 512, 51, 25, 044, -1];

//WriteLine("============");
//WriteLine($"Size = {arrayOfNumber2.Length} {PrintArray(arrayOfNumber2)}");



//string aaaa = "asfafasfasf";
//WriteLine("============");
//WriteLine(PrintArray(Quadratic(1, 1, 1)));// x^2+x+1

//WriteLine(PrintArray(Quadratic(1, -2, 1))); // x^2-2x+1


//WriteLine(PrintArray(Quadratic(1, -4, 3))); // x^2 - 4x + 3


//string[] arrayOfstrings = new[] { "asfaf", "qqqq" };
//arrayOfstrings = new[] { "", "", "", "", "", "", "", "", "", };
// a*x^2+b*x+c =0 



//var listOfInts1 = new List<int>();

//var listOfInts2 = new List<int>(100) { 0, 9, 1, 3, 33, 45, 4, 5, 6, 66, 1234214, 6 };

//var listOnInts3 = new List<int>(100);

//WriteLine(PrintList(listOfInts2));


//WriteLine(listOfInts2.Count);
//listOfInts2.Add(-4);

//WriteLine(PrintList(listOfInts2));
//listOfInts2.AddRange([-42, -4444, -1]);
//WriteLine(PrintList(listOfInts2));
//listOfInts2.Insert(2, 777);
//WriteLine(PrintList(listOfInts2));
//WriteLine(listOfInts2[4]);
//listOfInts2[4] = -101010;
//WriteLine(PrintList(listOfInts2));

//listOfInts2.Remove(6);
//WriteLine(PrintList(listOfInts2));
//listOfInts2.RemoveAt(1);
//WriteLine(PrintList(listOfInts2));
//listOfInts2.RemoveAll(IsOdd);
//WriteLine(PrintList(listOfInts2));
//listOfInts2.InsertRange(1, [44, 444, 4444]);
//WriteLine(PrintList(listOfInts2));


//WriteLine(PrintList(listOfInts2));
////var listOfInts4 = new List<int>(listOfInts2);

////var listOfInts4 = listOfInts2;
////WriteLine(PrintList(listOfInts4));
////listOfInts4.RemoveAt(1);
////WriteLine();
////WriteLine(PrintList(listOfInts2));
////WriteLine(PrintList(listOfInts4));
//listOfInts2.InsertRange(1, [33, 33, 3333]);
//WriteLine();
//WriteLine(PrintList(listOfInts2));
//listOfInts2.RemoveRange(2, 3);
//WriteLine(PrintList(listOfInts2));



//WriteLine(PrintList(listOfInts2));


//var oddNumbers = new List<int>(listOfInts2.Count / 2);

//for (var i = 0; i < listOfInts2.Count; i++)
//{
//    if (i % 2 != 0)
//    {
//        listOfInts2.RemoveAt(i);
//    }
//}


//WriteLine(PrintList(listOfInts2));

//var linked2 = new LinkedList<int>();

//linked2.AddLast(9999);

//var b = linked2.AddLast(888);

//var linked = new LinkedList<int>();
//linked.AddLast(100);
//linked.AddLast(101);

//var a = linked.AddLast(1001);
//linked.AddFirst(-1001);
//WriteLine(PrintLinkedList(linked));


//linked.AddBefore(a, b);

//WriteLine(PrintLinkedList(linked));



var listOfList = new List<List<List<List<int>>>>();


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
1254,
];


int[,] matrix = new int[2, 10];
matrix[1, 8] = 4;


WriteLine(matrix.GetLength(1));


int[,,,] aaaa = new int[10, 20, 30, 40];



foreach(var i in arraOfArra)
{
    foreach(var j in i)
    {
        Write(j + " ");
    }
    WriteLine();
}


bool IsOdd(int x)
{
    return x % 2 == 0;
}

bool IsOpredelennie(int x)
{
    return x == 0 || x == 9 || x == 33 || x == 45;
}

double[] Quadratic(double a, double b, double c)
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






static string PrintList<T>(List<T> list)
{
    return $"{{{string.Join(", ", list)}}}";
   
}

static string PrintArray<T>(T[] array)
{

    return $"[{string.Join(", ", array)}]";
 

}













