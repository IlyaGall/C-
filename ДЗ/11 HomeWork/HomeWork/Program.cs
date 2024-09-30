namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var otusDictionary = new OtusDictionary();
            otusDictionary.Add(12, "testzzzz");
            otusDictionary.Add(1, "test");
            otusDictionary.Add(1, "test121111111111");
            otusDictionary.Add(2, "test123222211111111111111111111");
            otusDictionary.Add(4, "test121111111111");
            otusDictionary.Add(5, "test121111111111");
            otusDictionary.Add(3, "test121111111111");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");
            otusDictionary.Add(40, "test12xxxxxx");

            var result = otusDictionary.Get(2);
            var result2 = otusDictionary.Get(41);

            //Console.WriteLine("Hello, World!");
            Console.WriteLine($"Индексатор {otusDictionary[1].Value}");


            Console.ReadKey();
        }
    }
}
