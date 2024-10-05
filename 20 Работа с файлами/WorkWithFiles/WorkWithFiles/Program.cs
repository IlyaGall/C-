namespace WorkWithFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a file
            string filePath = "example.txt";
            File.Create(filePath).Dispose(); // Dispose to release file handle

            // Write to the file
            File.WriteAllText(filePath, "Hello, C#!");

            if (File.Exists("example.txt"))
            {
                Console.WriteLine("File exists!");
            }

            string content = File.ReadAllText("example.txt");
            Console.WriteLine(content);

            //File.Move("example.txt", "newDirectory/example.txt");
            File.Copy("example.txt", "example_copy.txt");

            File.Delete("example.txt");
        }
    }
}
