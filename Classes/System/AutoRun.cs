using System.Windows.Forms;
using Microsoft.Win32;
using System.Reflection;

namespace DeskTime.Classes.System
{
    internal static class AutoRun
    {
        private static string name = Assembly.GetEntryAssembly().GetName().Name.ToString();
        public static bool SetAutorunValue(bool autorun)
        {
            string ExePath = Application.ExecutablePath;
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if (autorun)
                    reg.SetValue(name, ExePath);
                else
                    reg.DeleteValue(name);

                reg.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
