namespace CopyToDrive
{
    class Program
    {
        static void Main()
        {
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
        }
    }

}
