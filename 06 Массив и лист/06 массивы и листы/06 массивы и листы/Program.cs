namespace _06_массивы_и_листы
{
    internal class Program
    {




        static void Main(string[] args)
        {

# region МАССИВЫ
            // ## 

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
            #endregion

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


            Console.WriteLine(PrintList(listOfInts2));
            Console.WriteLine(listOfInts2[4]);
          
            Console.WriteLine(PrintList(listOfInts2));

  
            Console.WriteLine(PrintList(listOfInts2));
           
            Console.WriteLine(PrintList(listOfInts2));
            
            Console.WriteLine(PrintList(listOfInts2));
           
            Console.WriteLine(PrintList(listOfInts2));


            Console.WriteLine(PrintList(listOfInts2));
            //var listOfInts4 = new List<int>(listOfInts2);

            //var listOfInts4 = listOfInts2;
            // Console.WriteLine(PrintList(listOfInts4));
            //listOfInts4.RemoveAt(1);
            // Console.WriteLine();
            // Console.WriteLine(PrintList(listOfInts2));
            // Console.WriteLine(PrintList(listOfInts4));
            listOfInts2.InsertRange(1, [33, 33, 3333]);
            Console.WriteLine();
            Console.WriteLine(PrintList(listOfInts2));
           
            Console.WriteLine(PrintList(listOfInts2));



            Console.WriteLine(PrintList(listOfInts2));


            
           


            Console.WriteLine(PrintList(listOfInts2));

     





            var listOfList = new List<List<List<List<int>>>>();


         


            int[,] matrix = new int[2, 10];
            matrix[1, 8] = 4;

            Console.WriteLine(matrix.GetLength(1));


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
                    1254,
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
        }
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
        static bool IsOdd(int x)
        {
            return x % 2 == 0;
        }

        static bool IsOpredelennie(int x)
        {
            return x == 0 || x == 9 || x == 33 || x == 45;
        }

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

        static string PrintList<T>(List<T> list)
        {
            return $"{{{string.Join(", ", list)}}}";

        }
    }
}
