# Работа с файлами

## Что такое обработка файлов? 

Определение: Обработка файлов относится к чтению и записи данных в файлы в файловой системе.

Важность:
- Постоянное хранение данных между сеансами.
- Чтение файлов конфигурации или журналов.
- Запись выходных данных для последующей обработки или анализа.
- Генерация других файлов
- Межсистемная интеграция
- Формирование отчетов 


![Image alt](https://github.com/IlyaGall/C-/blob/main/20%20%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D1%84%D0%B0%D0%B9%D0%BB%D0%B0%D0%BC%D0%B8/img/1.JPG)

## Обработка файлов в C#

C# использует пространство имен System.IO для файловых операций.

Обычные файловые операции включают:

* Создание файлов
* Чтение файлов
* Запись в файлы
* Удаление файлов

![Image alt](https://github.com/IlyaGall/C-/blob/main/20%20%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D1%84%D0%B0%D0%B9%D0%BB%D0%B0%D0%BC%D0%B8/img/2.JPG)

## Пространство имен System.IO

* Класс File: Предоставляет статические методы для операций с файлами (создание, чтение, запись).
* Класс Directory: Предоставляет статические методы для операций с каталогами (создание, удаление, перемещение).

Другие классы:

* FileInfo, DirectoryInfo (предоставляют методы экземпляра для расширенных операций).
* StreamReader и StreamWriter для работы с потоками файлов.

## Основные операции с файлами и каталогами в C#


###  получить системные доступы.

```C#
Console.WriteLine($"Текущий каталог: {Environment.CurrentDirectory}");
Console.WriteLine($"Имя машины: {Environment.MachineName}");
Console.WriteLine($"Имя пользователя: {Environment.UserName}");
Console.WriteLine($"Настольный каталог: {Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}");

string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
string filePath = Path.Combine(desktopPath, "example.txt");
Console.WriteLine($"Символ разделителя каталогов: {Path.DirectorySeparatorChar}");
Console.WriteLine($"Путь к файлу: {filePath}");

filePath = @"C:\Users\User\Documents\example.txt";
Console.WriteLine($"Имя файла: {Path.GetFileName(filePath)}");
Console.WriteLine($"Имя каталога: {Path.GetDirectoryName(filePath)}");
onsole.WriteLine($"Расширение файла: {Path.GetExtension(filePath)}");
```

### дисковое пространство пк
```C#
 DriveInfo[] drives = DriveInfo.GetDrives();
 foreach (DriveInfo drive in drives)
 {
     if (drive.DriveType == DriveType.Removable && drive.IsReady)
     {
         Console.WriteLine($"Found Removable Drive: {drive.Name}");
         string sourceFile = @"C:\example.txt";
         string destinationFile = Path.Combine(drive.Name, "example.txt");

         File.Copy(sourceFile, destinationFile);
         Console.WriteLine("File copied to removable drive.");
         break;
     }
 }
```
#### проверка пути к диску и его размерности
```C# 
  //показать всю информацию о дисках
  DriveInfo[] drives = DriveInfo.GetDrives();

  foreach (DriveInfo drive in drives)
  {
      Console.WriteLine($"Drive: {drive.Name}");
      Console.WriteLine($"Type: {drive.DriveType}");

      if (drive.IsReady)
      {
          Console.WriteLine($"Format: {drive.DriveFormat}");
          Console.WriteLine($"Available Space: {drive.AvailableFreeSpace} bytes");
          Console.WriteLine($"Total Size: {drive.TotalSize} bytes");
      }
      Console.WriteLine();
  }

  string driveLetter = "C"; // Укажите диск для проверки
  DriveInfo driveInfo = new DriveInfo(driveLetter);

  if (driveInfo.AvailableFreeSpace > 1000000000) // Проверьте наличие 1 ГБ свободного места
  {
      Console.WriteLine("Достаточно места для записи файла.");
      // Продолжить операцию с файлом
  }
  else
  {
      Console.WriteLine("Недостаточно места для записи файла.");
  }
```

### проверки доступа к файлу

```C#
    static void Main()
    {
        string filePath = "example.txt";

        // Проверить, существует ли файл
        if (File.Exists(filePath))
        {
            Console.WriteLine("Проверка доступа к файлу: " + filePath);

            // Проверить доступ на чтение
            if (HasReadAccess(filePath))
            {
                Console.WriteLine("У вас есть доступ на чтение файла.");
            }
            else
            {
                Console.WriteLine("У вас НЕТ прав на чтение файла.");
            }

            // Проверить доступ на запись
            if (HasWriteAccess(filePath))
            {
                Console.WriteLine("У вас есть права на запись в файл.");
            }
            else
            {
                Console.WriteLine("У вас НЕТ прав на запись в файл.");
            }
        }
        else
        {
            Console.WriteLine("Файл не существует.");
        }
    }

    // Метод проверки наличия у пользователя прав на чтение с использованием ACL
    static bool HasReadAccess(string filePath)
    {
        return HasAccess(filePath, FileSystemRights.ReadData);
    }

    // Метод проверки наличия у пользователя прав на запись с использованием ACL
    static bool HasWriteAccess(string filePath)
    {
        return HasAccess(filePath, FileSystemRights.WriteData);
    }

    // Метод проверки наличия у пользователя определенных прав доступа с использованием ACL
    static bool HasAccess(string filePath, FileSystemRights accessRight)
    {
        try
        {
            FileInfo fileInfo = new FileInfo(filePath);
            FileSecurity fileSecurity = fileInfo.GetAccessControl();
            AuthorizationRuleCollection rules = fileSecurity.GetAccessRules(true, true, typeof(NTAccount));

            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            foreach (FileSystemAccessRule rule in rules)
            {
                if (principal.IsInRole(rule.IdentityReference.Value))
                {
                    if ((rule.FileSystemRights & accessRight) == accessRight)
                    {
                        if (rule.AccessControlType == AccessControlType.Allow)
                        {
                            return true; // Пользователь имеет необходимый доступ
                        }
                    }
                }
            }
            return false;
        }
        catch (UnauthorizedAccessException)
        {
            return false; // Нет доступа из-за ограниченных прав доступа


        }
    }
```


### Создание и запись файлов

```C#
    filePath = @"C:\Users\User\Documents\example.txt";
    File.Create(filePath).Dispose();
    File.WriteAllText(filePath, "какой-то текст");
```

### Проверка существования файла
```C#
filePath = @"C:\Users\User\Documents\example.txt";

if (File.Exists(filePath)) 
{
    Console.WriteLine("File Exitst");
}
```

### Чтение из файлов

```C#
    string contents = File.ReadAllText(filePath);
    Console.WriteLine(contents);
```

### Перемещение и копирование файлов

```C#
  File.Move("файл", "cюда");
  File.Copy("файл", "cюда");
```

```C#
string filePath = "example.txt";
File.Create(filePath).Dispose();
string currentDirectory = Environment.CurrentDirectory;
string sourceFile = Path.Combine(currentDirectory, "example.txt");
string targetDirectory = Path.Combine(currentDirectory, "Backup");
string targetFile = Path.Combine(targetDirectory, "example.txt");

// Создать каталог, если он не существует
if (!Directory.Exists(targetDirectory))
{
    Directory.CreateDirectory(targetDirectory);
}

// Переместить файл
File.Move(sourceFile, targetFile);
Console.WriteLine($"Файл перемещен в: {targetFile}");
```


### удаление файлов

```C#
File.Delete("файл", "cюда");
```


### Вставить позицию в файл

```C#
static void Main()
{
    string filePath = "example.txt";

    // Создать файл-пример для демонстрации
    CreateSampleFile(filePath);

    // Вставляемые байты
    byte[] bytesToInsert = Encoding.UTF8.GetBytes("INSERTED_TEXT");

    // Позиция, куда следует вставить байты (после 10-го байта)
    int insertPosition = 10;

    // Вставляем байты в файл
    InsertBytesInFile(filePath, bytesToInsert, insertPosition);

    // Чтение и отображение измененного содержимого файла
    Console.WriteLine("Измененное содержимое файла:");
    Console.WriteLine(File.ReadAllText(filePath));
}

// Метод для вставки байтов в указанную позицию в файле
static void InsertBytesInFile(string filePath, byte[] bytesToInsert, int position)
{
    // Считывание байтов исходного файла
    byte[] originalBytes = File.ReadAllBytes(filePath);

    // Проверка правильности позиции вставки
    if (position > originalBytes.Length)
    {
    Console.WriteLine("Error: Insertion position is beyond the file length.");
    return;
    }

    // Создание нового массива байтов для хранения результата
    byte[] newBytes = new byte[originalBytes.Length + bytesToInsert.Length];

    // Копирование первой части исходного файла (до точки вставки)
    Array.Copy(originalBytes, 0, newBytes, 0, position);

    // Копируем байты для вставки
    Array.Copy(bytesToInsert, 0, newBytes, position, bytesToInsert.Length);

    // Копируем оставшуюся часть исходного файла (после точки вставки)
    Array.Copy(originalBytes, position, newBytes, position + bytesToInsert.Length, originalBytes.Length - position);

    // Записываем измененные байты обратно в файл
    File.WriteAllBytes(filePath, newBytes);
    }

// Вспомогательный метод для создания файла-образца
static void CreateSampleFile(string filePath)
{
    string sampleContent = "Это содержимое файла-образца для тестирования.";
    File.WriteAllText(filePath, sampleContent);
    Console.WriteLine("Содержимое исходного файла:");
    Console.WriteLine(sampleContent);
    Console.WriteLine();
}
```


### Перезаписать файлы

```c#
    using System;
    using System.IO;

static void Main()
{
        string filePath = "example.txt";

        Console.WriteLine("Демонстрация перезаписи файла с помощью FileMode.Create:");
        OverwriteFileWithFileMode(filePath, "Это содержимое перезапишет файл.");

        Console.WriteLine("\nДемонстрация предотвращения перезаписи файла с помощью FileMode.CreateNew:");
        PreventOverwriteWithFileMode(filePath, "Это содержимое не должно перезаписывать файл.");
}

    // Метод перезаписи существующего файла с помощью FileMode.Create
    static void OverwriteFileWithFileMode(string filePath, string content)
    {
        try
        {
            // Открыть или создать файл, перезаписав его, если он существует
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.Write(content);
                }
            }
            Console.WriteLine($"Файл успешно перезаписан с содержимым: {content}");
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Ошибка записи в файл: {ex.Message}");
        }
    }

    // Метод предотвращения перезаписи существующего файла с помощью FileMode.CreateNew
    static void PreventOverwriteWithFileMode(string filePath, string content)
    {
    try
    {
    // Попытаемся создать файл; если он существует, будет выдано исключение
    using (FileStream fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write))
    {
        using (StreamWriter writer = new StreamWriter(fs))
        {
        writer.Write(content);
        }
    }
      Console.WriteLine($"Файл создан с содержимым: {content}");
    }
    catch (IOException)
    {
      Console.WriteLine("Ошибка: Файл уже существует и не будет перезаписан.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
    }
}

```

## TEXTREADER /TEXTWRITER и его наследники

![Image alt](https://github.com/IlyaGall/C-/blob/main/20%20%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D1%84%D0%B0%D0%B9%D0%BB%D0%B0%D0%BC%D0%B8/img/3.JPG)



### Работа с каталогами

```C#
static void Main(string[] args)
{
    Directory.CreateDirectory("NewFolder");
    if (Directory.Exists("NewFolder"))
    {
        Console.WriteLine("Directory exist!");
    }
    string[] files = Directory.GetFiles("NewFolder");
    foreach (строка file в files)
    {
        Console.WriteLine(file);
    }
}
```

### Работа с файлами

```C#
static void Main(string[] args)
{
    // Создание файла
    string filePath = "example.txt";
    File.Create(filePath).Dispose(); // Dispose для освобождения дескриптора файла

    // Запись в файл
    File.WriteAllText(filePath, "Hello, C#!");

    if (File.Exists("example.txt"))
    {
        Console.WriteLine("Файл существует!");
    }

    string content = File.ReadAllText("example.txt");
    Console.WriteLine(content);

    // File.Move("example.txt", "newDirectory/example.txt");
    File.Copy("example.txt", "example_copy.txt");

    File.Delete("example.txt");
}
```

## Stream

Что такое поток (Stream)?
Поток — это последовательность данных.
Потоки позволяют выполнять чтение и запись в источник данных (например, файл) небольшими порциями.
Два типа потоков:
* Входные потоки (для чтения).
* Выходные потоки (для записи).

![Image alt](https://github.com/IlyaGall/C-/blob/main/20%20%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D1%84%D0%B0%D0%B9%D0%BB%D0%B0%D0%BC%D0%B8/img/4.JPG)

## Класс System.IO.Stream
Базовым классом для всех типов потоков в C# является Stream.

Обычно используемые потоки:
* FileStream: для чтения/записи байтов в/из файлов.
* MemoryStream: для работы с данными в памяти.
* NetworkStream: для сетевого взаимодействия.

![Image alt](https://github.com/IlyaGall/C-/blob/main/20%20%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D1%84%D0%B0%D0%B9%D0%BB%D0%B0%D0%BC%D0%B8/img/5.JPG)

### Запись в файлы с использованием FileStream

```C#
 using (FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate))
 {
     byte[] data = new UTF8Encoding(true).GetBytes("Hello, Stream!");
     fs.Write(data, 0, data.Length);
 }
```
### Чтение из файлов с использованием FileStream
```C#
 using (FileStream fs = new FileStream("data.txt", FileMode.Open))
{
    byte[] data = new byte[fs.Length];
    fs.Read(data, 0, data.Length);
    string text = new UTF8Encoding(true).GetString(data);
    Console.WriteLine(text);
}
```
### Использование StreamWriter для текстовых файлов
```C#
   using (StreamWriter writer = new StreamWriter("example.txt"))
   {
       writer.WriteLine("This is a text file.");
       writer.WriteLine("This is a text file.");
   }
```
### Чтение текстовых файлов с помощью StreamReader
```C#
  using (StreamReader reader = new StreamReader("example.txt"))
 {
     string content = reader.ReadToEnd();
     Console.WriteLine(content);
 }
```


### Работа с потоком

```C#
using System.Text;

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
        writer.WriteLine("Это текстовый файл.");
        writer.WriteLine("Это текстовый файл.");
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
        Console.WriteLine("Файл не найден: " + e.Message);
    }
    catch (Exception e)
    {
        Console.WriteLine("Ошибка: " + e.Message);
    }

    using (FileStream fs = new FileStream("binarydata.dat", FileMode.Create))
    {
        BinaryWriter writer = new BinaryWriter(fs);
        writer.Write(1234); // Запись целого числа
        writer.Write(99.99); // Запись числа double
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
```


## Обработка исключений при файловом вводе-выводе
Зачем обрабатывать исключения в файловых операциях?
* Файлы могут не существовать.
* Проблемы с разрешениями.
* Ошибки диска.

## Ввод-вывод двоичных файлов
Зачем использовать двоичные файлы?
* Для нетекстовых данных, таких как изображения, видео или
сериализованные объекты.

```C#
   using (FileStream fs = new FileStream("binarydata.dat", FileMode.Create))
    {
        BinaryWriter writer = new BinaryWriter(fs);
        writer.Write(1234); // Запись целого числа
        writer.Write(99.99); // Запись числа double
        writer.Close();
    }
```

## Чтение двоичных файлов

```C#
 using (FileStream fs = new FileStream("binarydata.dat", FileMode.Open))
    {
        BinaryReader reader = new BinaryReader(fs);
        int intValue = reader.ReadInt32();
        double doubleValue = reader.ReadDouble();
        Console.WriteLine($"Integer: {intValue}, Double: {doubleValue}");
    }
```

## Итого по потокам
* Потоки обеспечивают гибкий доступ к файлам.
* FileStream позволяет выполнять операции с файлами на уровне байтов.
* StreamReader и StreamWriter упрощают обработку текстовых файлов.
* Обработка исключений обеспечивает стабильные операции с файлами.
* Используйте BinaryWriter/BinaryReader для нетекстовых данных.


# Асинхронная обработка файлов в C#


## Зачем использовать асинхронную обработку файлов?

синхронные файловые операции: программа ожидает завершения каждой файловой операции перед продолжением.
Асинхронные файловые операции: программа может выполнять другие задачи, ожидая завершения файловых операций.

Преимущества:
* Улучшенная отзывчивость: идеально подходит для приложений пользовательского интерфейса.
* Эффективное использование ресурсов: сокращает время простоя при ожидании ввода-вывода.


### Ключевые слова async и await
* async: Помечает метод как асинхронный.
* await: Приостанавливает выполнение метода до тех пор, пока ожидаемая задача не завершится.


```C#
      public async Task ReadFileAcces() 
      {
          string content = await File.ReadAllTextAsync("paht");
          Console.WriteLine(content);
      }
```

### Асинхронные методы в пространстве имен System.IO
Асинхронное чтение:
* File.ReadAllTextAsync()
* File.ReadAllLinesAsync()
* File.ReadAllBytesAsync()
Асинхронная запись:
* File.WriteAllTextAsync()
* File.WriteAllLinesAsync()
* File.WriteAllBytesAsync()


### Асинхронная запись файлов

```C#
public async Task WriteToFileAnsync() 
{
    string content = "1";
    await File.WriteAllTextAsync("path",content);
    Console.WriteLine(content);
}
```
### Асинхронная обработка больших файлов
Для больших файлов использование ReadAllTextAsync или WriteAllTextAsync может попрежнему потреблять значительную часть памяти.
Решение:
асинхронные операции на основе потоков:
FileStream.ReadAsync()
FileStream.WriteAsync()


### Асинхронная запись больших файлов с помощью FileStream.WriteAsync()

![Image alt](https://github.com/IlyaGall/C-/blob/main/20%20%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D1%84%D0%B0%D0%B9%D0%BB%D0%B0%D0%BC%D0%B8/img/6.JPG)

### Асинхронное чтение больших файлов с помощью FileStream.ReadAsync()

![Image alt](https://github.com/IlyaGall/C-/blob/main/20%20%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D1%84%D0%B0%D0%B9%D0%BB%D0%B0%D0%BC%D0%B8/img/7.JPG)

### Обработка ошибок при асинхронных nоперациях с файлами

![Image alt](https://github.com/IlyaGall/C-/blob/main/20%20%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D1%84%D0%B0%D0%B9%D0%BB%D0%B0%D0%BC%D0%B8/img/8.JPG)


### Работа с асинхронным режимом(большой пример)

```C#
using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        string largeFilePath = "largefile.txt";

        // Шаг 1: Асинхронное создание и запись большого файла
        await CreateLargeFileAsync(largeFilePath, 1000000); // 1 миллион строк
        Console.WriteLine("Большой файл создан успешно.");

        // Шаг 2: Асинхронное чтение большого файла
        await ReadLargeFileAsync(largeFilePath);

        // Шаг 3: Удаление файла после чтения
        DeleteFile(largeFilePath);
        Console.WriteLine("Файл успешно удален.");

        Console.WriteLine("Демо завершено.");
    }

    // Метод создания большого файла асинхронно с использованием FileStream
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

    // Метод для асинхронного чтения большого файла с использованием FileStream и асинхронного потокового чтения
    static async Task ReadLargeFileAsync(string filePath)
    {
        Console.WriteLine("Асинхронное чтение большого файла...");

        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None, 4096, true))
        using (StreamReader reader = new StreamReader(fs, Encoding.UTF8))
        {
            string? line;
            int lineNumber = 0;

            while ((line = await reader.ReadLineAsync()) != null)
            {
                lineNumber++;
                if (lineNumber % 100000 == 0) // Вывести каждую 100 000-ю строку
                {
                    Console.WriteLine($"Read line {lineNumber}: {line}");
                }
            }
        }

        Console.WriteLine("File reading performed.");
    }

    // Метод удаления файла
    static void DeleteFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
```


## Сравнение производительности: синхронный и асинхронный режимы

Синхронная обработка файлов:
* Блокирует вызывающий поток.
* Подходит для небольших быстрых операций с файлами.

Асинхронная обработка файлов:
* Не блокирует основной поток.
* Идеально подходит для длительных операций ввода-вывода или при работе с большими файлами.

### Итого
* Асинхронная обработка файлов улучшает отзывчивость приложения.
* async и await имеют решающее значение для написания неблокирующего кода.
* Используйте FileStream.WriteAsync() и FileStream.ReadAsync() для обработки больших файлов.
* Правильно обрабатывайте ошибки в асинхронных операциях.