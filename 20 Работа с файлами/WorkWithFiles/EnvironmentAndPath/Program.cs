namespace EnvironmentAndPath
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine($"Current Directory: {Environment.CurrentDirectory}");
            Console.WriteLine($"Machine Name: {Environment.MachineName}");
            Console.WriteLine($"User Name: {Environment.UserName}");
            Console.WriteLine($"Desktop Directory: {Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}");

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "example.txt");
            Console.WriteLine($"DirectorySeparatorChar: {Path.DirectorySeparatorChar}");
            Console.WriteLine($"File Path: {filePath}");

            filePath = @"C:\Users\User\Documents\example.txt";
            Console.WriteLine($"File Name: {Path.GetFileName(filePath)}");
            Console.WriteLine($"Directory Name: {Path.GetDirectoryName(filePath)}");
            Console.WriteLine($"File Extension: {Path.GetExtension(filePath)}");
            
  
        }
    }

}
