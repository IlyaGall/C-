namespace WorkWithDirectories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("NewFolder");
            if (Directory.Exists("NewFolder"))
            {
                Console.WriteLine("Directory exists!");
            }
            string[] files = Directory.GetFiles("NewFolder");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }

        }
    }
}
