using System.IO;
using System.IO.Compression;
using System.Text;

namespace Decorator.Problem
{
    public static class FileDecorator
    {
        private const string StringToWrite = "Мой дядя самых честных правил,\nКогда не в шутку занемог,\nОн уважать себя заставил\nИ лучше выдумать не мог.\nЕго пример другим наука;\nНо, боже мой, какая скука\nС больным сидеть и день и ночь,\nНе отходя ни шагу прочь!\nКакое низкое коварство\nПолуживого забавлять,\nЕму подушки поправлять,\nПечально подносить лекарство,\nВздыхать и думать про себя:\nКогда же черт возьмет тебя!";
        private const string Folder = "C://Sandbox/OTUS/StructuralPatterns";

        public static void Write()
        {
            using (FileStream fileStream = new FileStream($"{Folder}/unarchived.txt", FileMode.Create))
            {
                byte[] bytes = Encoding.Default.GetBytes(StringToWrite);
                fileStream.Write(bytes);
            }
        }
        
        public static void WriteArchived()
        {
            using (FileStream fileStream = new FileStream($"{Folder}/archived.gz", FileMode.Create))
            using (GZipStream gZipStream = new GZipStream(fileStream, CompressionLevel.Optimal))
            {
                byte[] bytes = Encoding.Default.GetBytes(StringToWrite);
                gZipStream.Write(bytes);
            }
        }
    }
}