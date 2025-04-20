using Microsoft.Win32;
using System;
using System.Security.Principal;

public class Program
{
    public static void Main()
    {
        Console.Title = "BetterDesktopQuality";

        WindowsIdentity identity = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new WindowsPrincipal(identity);

        if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
        {
            Console.WriteLine("[+] The program is not run with Administrator privileges!");
            goto exit;
        }

        try
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);
            registryKey.SetValue("JPEGImportQuality", 100);
            Console.WriteLine("[+] Operation has been completed succesfully!");
        }
        catch
        {
            Console.WriteLine("[+] An error occurred.");
        }

        exit: Console.WriteLine("[+] Press ENTER to exit from the program.");
        Console.ReadLine();
    }
}