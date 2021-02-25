using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CriticalProcessBSOD
{
    class Program
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);

        static void Main(string[] args) // src https://codingvision.net/c-make-a-critical-process-bsod-if-killed
        {
            Console.WriteLine("When you close this program, your computer invoke BSOD");
           try
            {
                int isCritical = 1;  // we want this to be a Critical Process
                int BreakOnTermination = 0x1D;  // value for BreakOnTermination (flag)

                Process.EnterDebugMode();  //acquire Debug Privileges

                // setting the BreakOnTermination = 1 for the current process
                NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
            } catch { }
        }
    }
}
