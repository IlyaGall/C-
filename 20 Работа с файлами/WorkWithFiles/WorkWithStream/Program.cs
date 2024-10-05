using System.Text;

namespace WorkWithStream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate))
            {
                byte[] data = new UTF8Encoding(true).GetBytes("Hello, Stream!");
                fs.Write(data, 0, data.Length);
            }

            using (FileStream fs = new FileStream("data.txt", FileMode.Open))
            {
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                string text = new UTF8Encoding(true).GetString(data);
                Console.WriteLine(text);
            }

            using (StreamWriter writer = new StreamWriter("example.txt"))
            {
                writer.WriteLine("This is a text file.");
                writer.WriteLine("This is a text file.");
            }

            using (StreamReader reader = new StreamReader("example.txt"))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            }


            try
            {
                using (StreamReader reader = new StreamReader("nonexistent.txt"))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            using (FileStream fs = new FileStream("binarydata.dat", FileMode.Create))
            {
                BinaryWriter writer = new BinaryWriter(fs);
                writer.Write(1234);  // Writing an integer
                writer.Write(99.99); // Writing a double
                writer.Close();
            }

            using (FileStream fs = new FileStream("binarydata.dat", FileMode.Open))
            {
                BinaryReader reader = new BinaryReader(fs);
                int intValue = reader.ReadInt32();
                double doubleValue = reader.ReadDouble();
                Console.WriteLine($"Integer: {intValue}, Double: {doubleValue}");
            }


        }
    }
}
