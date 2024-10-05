namespace OverwriteFiles
{
    using System;
    using System.IO;

    class Program
    {
        static void Main()
        {
            string filePath = "example.txt";

            Console.WriteLine("Demonstrating file overwrite using FileMode.Create:");
            OverwriteFileWithFileMode(filePath, "This content will overwrite the file.");

            Console.WriteLine("\nDemonstrating prevention of file overwrite using FileMode.CreateNew:");
            PreventOverwriteWithFileMode(filePath, "This content should not overwrite the file.");
        }

        // Method to overwrite an existing file using FileMode.Create
        static void OverwriteFileWithFileMode(string filePath, string content)
        {
            try
            {
                // Open or create the file, overwriting it if it exists
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.Write(content);
                    }
                }
                Console.WriteLine($"File overwritten successfully with content: {content}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        // Method to prevent overwriting an existing file using FileMode.CreateNew
        static void PreventOverwriteWithFileMode(string filePath, string content)
        {
            try
            {
                // Try to create the file; if it exists, an exception is thrown
                using (FileStream fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.Write(content);
                    }
                }
                Console.WriteLine($"File created with content: {content}");
            }
            catch (IOException)
            {
                Console.WriteLine("Error: File already exists and will not be overwritten.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }

}
