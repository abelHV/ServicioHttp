using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servei.CLASSES
{
    public class ClPowerShellRunner
    {
        public string Executar(string rutaScript)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = @"C:\Windows\Sysnative\WindowsPowerShell\v1.0\powershell.exe";
            psi.Arguments = $"-NoProfile -ExecutionPolicy Bypass -File \"{rutaScript}\"";
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            using (Process proc = Process.Start(psi))
            {
                return proc.StandardOutput.ReadToEnd();
            }
        }
    }
}
