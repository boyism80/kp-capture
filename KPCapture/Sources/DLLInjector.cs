using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace KPU.Sources
{
    public enum DLLInjectionResult
    {
        DllNotFound,
        GameProcessNotFound,
        InjectionFailed,
        Success
    }

    [StructLayout(LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
    public struct MODULEENTRY32
    {
        public uint dwSize;
        public uint th32ModuleID;
        public uint th32ProcessID;
        public uint GlblcntUsage;
        public uint ProccntUsage;
        public IntPtr modBaseAddr;
        public uint modBaseSize;
        public IntPtr hModule;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szModule;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szExePath;
    }



    public sealed class DLLInjector
    {
        static readonly IntPtr INTPTR_ZERO = (IntPtr)0;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress,
            IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern int WaitForSingleObject(IntPtr hHandle, int dwMilliseconds);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateToolhelp32Snapshot(uint dwFlags, uint th32ProcessID);

        [DllImport("kernel32.dll")]
        static extern bool Module32First(IntPtr hSnapshot, ref MODULEENTRY32 mentry);

        [DllImport("kernel32.dll")]
        static extern bool Module32Next(IntPtr hSnapshot, ref MODULEENTRY32 lpme);





        static DLLInjector _instance;

        public static DLLInjector GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DLLInjector();
                }
                return _instance;
            }
        }

        DLLInjector() { }

        public DLLInjectionResult Inject(string nameProcess, string dll)
        {
            if (File.Exists(dll) == false)
            {
                return DLLInjectionResult.DllNotFound;
            }

            uint _procId = 0;

            var _procs = Process.GetProcesses();
            for (var i = 0; i < _procs.Length; i++)
            {
                if (_procs[i].ProcessName == nameProcess)
                {
                    _procId = (uint)_procs[i].Id;
                    break;
                }
            }

            if (_procId == 0)
            {
                return DLLInjectionResult.GameProcessNotFound;
            }

            if (!this.Inject(_procId, dll))
            {
                return DLLInjectionResult.InjectionFailed;
            }

            return DLLInjectionResult.Success;
        }

        public bool Inject(uint pid, string dll)
        {
            var handleProc = OpenProcess((0x0400 | 0x0008 | 0x0010 | 0x0020 | 0x0002), 0, pid);
            if (handleProc == INTPTR_ZERO)
                return false;


            var bytes = Encoding.Default.GetBytes(dll);
            var allocsize = bytes.Length + 1;
            var vbuffer = VirtualAllocEx(handleProc, (IntPtr)null, (IntPtr)allocsize, (0x1000 | 0x2000), 0X40);
            if (vbuffer == INTPTR_ZERO)
                return false;



            //var bytes = Encoding.GetEncoding(949).GetBytes(dll);
            if (WriteProcessMemory(handleProc, vbuffer, bytes, (uint)allocsize, 0) == 0)
                return false;



            var loadLibraryRef = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            if (loadLibraryRef == INTPTR_ZERO)
                return false;



            var handleThread = CreateRemoteThread(handleProc, (IntPtr)null, INTPTR_ZERO, loadLibraryRef, vbuffer, 0, (IntPtr)null);
            if (handleThread == INTPTR_ZERO)
                return false;

            WaitForSingleObject((IntPtr)handleThread, -1);
            CloseHandle(handleProc);

            return true;
        }

        private string ConvertUnicodeToAscii(string unicode)
        {
            var buffer = Encoding.Unicode.GetBytes(unicode);
            var nullidx = Array.FindIndex(buffer, 0, (x) => x == 0);

            if (nullidx >= 0)
                return Encoding.ASCII.GetString(buffer, 0, nullidx);
            else
                return Encoding.ASCII.GetString(buffer);
        }

        public bool Eject(uint pid, string dll)
        {
            var hsnapshot = CreateToolhelp32Snapshot(0x0008, pid);
            if (hsnapshot == new IntPtr(-1))
                return false;

            var found = false;
            var mentry = new MODULEENTRY32();
            mentry.dwSize = (uint)Marshal.SizeOf(typeof(MODULEENTRY32));

            for (bool existNext = Module32First(hsnapshot, ref mentry); existNext; existNext = Module32Next(hsnapshot, ref mentry))
            {
                var dllname = Path.GetFileName(dll).ToLower();


                var cvtdll = ConvertUnicodeToAscii(mentry.szModule).ToLower();
                if (dllname.Equals(cvtdll) == false)
                    continue;

                found = true;
                break;
            }

            if (found == false)
                return false;

            var handleProc = OpenProcess((0x0400 | 0x0008 | 0x0010 | 0x0020 | 0x0002), 0, pid);
            if (handleProc == INTPTR_ZERO)
                return false;

            var freeLibraryRef = GetProcAddress(GetModuleHandle("kernel32.dll"), "FreeLibrary");
            if (freeLibraryRef == INTPTR_ZERO)
                return false;

            var handleThread = CreateRemoteThread(handleProc, (IntPtr)null, INTPTR_ZERO, freeLibraryRef, mentry.modBaseAddr, 0, (IntPtr)null);
            if (handleThread == INTPTR_ZERO)
                return false;

            WaitForSingleObject(handleThread, -1);
            return true;
        }
    }
}
