using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FinalProgIIRemmer.CancelProcess
{
    class CancelProcess
    {
        public void ProcessCancel()
        {
            Process[] allProcesses = Process.GetProcesses();
            foreach (Process p in allProcesses)
            {
                if (p.ProcessName == "FinalProgIIRemmer")
                {
                    Console.Clear();
                    Console.WriteLine("Cerrando aplicacion... \nGracias por elegirnos.");
                    p.Kill();
                }
            }
        }
    }
}
