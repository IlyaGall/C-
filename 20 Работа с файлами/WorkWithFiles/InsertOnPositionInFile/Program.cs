using System.Text;

namespace InsertOnPositionInFile
{
    class Program
    {
        static void Main()
        {
            string filePath = "example.txt";

            // Create a sample file for demonstration
            CreateSampleFile(filePath);

            // Bytes to be inserted
            byte[] bytesToInsert = Encoding.UTF8.GetBytes("INSERTED_TEXT");

            // Position where the bytes should be inserted (after the 10th byte)
            int insertPosition = 10;

            // Insert the bytes into the file
            InsertBytesInFile(filePath, bytesToInsert, insertPosition);

            // Read and display the modified file content
            Console.WriteLine("Modified File Content:");
            Console.WriteLine(File.ReadAllText(filePath));
        }

        // Method to insert bytes at a specified position in the file
        static void InsertBytesInFile(string filePath, byte[] bytesToInsert, int position)
        {
            // Read the original file bytes
            byte[] originalBytes = File.ReadAllBytes(filePath);

            // Ensure the insertion position is valid
            if (position > originalBytes.Length)
            {
                Console.WriteLine("Error: Insertion position is beyond the file length.");
                return;
            }

            // Create a new byte array to hold the result
            byte[] newBytes = new byte[originalBytes.Length + bytesToInsert.Length];

            // Copy the first part of the original file (before the insertion point)
            Array.Copy(originalBytes, 0, newBytes, 0, position);

            // Copy the bytes to be inserted
            Array.Copy(bytesToInsert, 0, newBytes, position, bytesToInsert.Length);

            // Copy the remaining part of the original file (after the insertion point)
            Array.Copy(originalBytes, position, newBytes, position + bytesToInsert.Length, originalBytes.Length - position);

            // Write the modified bytes back to the file
            File.WriteAllBytes(filePath, newBytes);
        }

        // Helper method to create a sample file
        static void CreateSampleFile(string filePath)
        {
            string sampleContent = "This is a sample file content for testing.";
            File.WriteAllText(filePath, sampleContent);
            Console.WriteLine("Original File Content:");
            Console.WriteLine(sampleContent);
            Console.WriteLine();
        }
    }

}
