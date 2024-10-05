using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        string largeFilePath = "largefile.txt";

        // Step 1: Create and Write a Large File Asynchronously
        await CreateLargeFileAsync(largeFilePath, 1000000); // 1 million lines
        Console.WriteLine("Large file created successfully.");

        // Step 2: Read the Large File Asynchronously
        await ReadLargeFileAsync(largeFilePath);

        // Step 3: Delete the File After Reading
        DeleteFile(largeFilePath);
        Console.WriteLine("File deleted successfully.");

        Console.WriteLine("Demo complete.");
    }

    // Method to create a large file asynchronously using a FileStream
    static async Task CreateLargeFileAsync(string filePath, int numberOfLines)
    {
        byte[] buffer;
        string line;

        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
        {
            for (int i = 0; i < numberOfLines; i++)
            {
                line = $"This is line number {i + 1}\n";
                buffer = Encoding.UTF8.GetBytes(line);
                await fs.WriteAsync(buffer, 0, buffer.Length);
            }
        }
    }

    // Method to read a large file asynchronously using a FileStream and async stream reading
    static async Task ReadLargeFileAsync(string filePath)
    {
        Console.WriteLine("Reading large file asynchronously...");

        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None, 4096, true))
        using (StreamReader reader = new StreamReader(fs, Encoding.UTF8))
        {
            string? line;
            int lineNumber = 0;

            while ((line = await reader.ReadLineAsync()) != null)
            {
                lineNumber++;
                if (lineNumber % 100000 == 0) // Print every 100,000th line
                {
                    Console.WriteLine($"Read line {lineNumber}: {line}");
                }
            }
        }

        Console.WriteLine("File reading completed.");
    }

    // Method to delete a file
    static void DeleteFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
