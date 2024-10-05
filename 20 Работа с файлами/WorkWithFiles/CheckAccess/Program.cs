using System.Security.AccessControl;
using System.Security.Principal;

namespace CheckAccess
{
    class Program
    {
        static void Main()
        {
            string filePath = "example.txt";

            // Check if file exists
            if (File.Exists(filePath))
            {
                Console.WriteLine("Checking access for file: " + filePath);

                // Check read access
                if (HasReadAccess(filePath))
                {
                    Console.WriteLine("You have read access to the file.");
                }
                else
                {
                    Console.WriteLine("You do NOT have read access to the file.");
                }

                // Check write access
                if (HasWriteAccess(filePath))
                {
                    Console.WriteLine("You have write access to the file.");
                }
                else
                {
                    Console.WriteLine("You do NOT have write access to the file.");
                }
            }
            else
            {
                Console.WriteLine("The file does not exist.");
            }
        }

        // Method to check if the user has read access using ACLs
        static bool HasReadAccess(string filePath)
        {
            return HasAccess(filePath, FileSystemRights.ReadData);
        }

        // Method to check if the user has write access using ACLs
        static bool HasWriteAccess(string filePath)
        {
            return HasAccess(filePath, FileSystemRights.WriteData);
        }

        // Method to check if the user has specific access rights using ACLs
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
                                return true; // User has the required access
                            }
                        }
                    }
                }
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                return false; // No access due to restricted permissions


            }
        }
    }
}
