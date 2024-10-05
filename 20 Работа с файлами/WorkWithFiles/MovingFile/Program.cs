namespace MovingFile
{
    class Program
    {
        static void Main()
        {
            string filePath = "example.txt";
            File.Create(filePath).Dispose();
            string currentDirectory = Environment.CurrentDirectory;
            string sourceFile = Path.Combine(currentDirectory, "example.txt");
            string targetDirectory = Path.Combine(currentDirectory, "Backup");
            string targetFile = Path.Combine(targetDirectory, "example.txt");

            // Create directory if it doesn't exist
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            // Move the file
            File.Move(sourceFile, targetFile);
            Console.WriteLine($"File moved to: {targetFile}");
        }
    }

}
