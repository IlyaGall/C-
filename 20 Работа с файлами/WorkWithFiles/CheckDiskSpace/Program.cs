namespace CheckDiskSpace
{
    class Program
    {
        static void Main()
        {
            //show all drivers info
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

            string driveLetter = "C"; // Specify the drive to check
            DriveInfo driveInfo = new DriveInfo(driveLetter);

            if (driveInfo.AvailableFreeSpace > 1000000000) // Check for 1GB free space
            {
                Console.WriteLine("Sufficient space available to write the file.");
                // Proceed with file operation
            }
            else
            {
                Console.WriteLine("Not enough space available to write the file.");
            }
        }
    }

}
