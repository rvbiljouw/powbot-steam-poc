using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace steampoctest.PowBot
{
    class Memory
    {
        private readonly Context context;

        public Memory(Context context)
        {
            this.context = context;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(
           IntPtr hProcess,
           IntPtr lpBaseAddress,
           [Out] byte[] lpBuffer,
           int dwSize,
           out IntPtr lpNumberOfBytesRead
       );

    
        public int ReadInt(IntPtr address)
        {
            IntPtr cursor = IntPtr.Zero;
            byte[] buffer = new byte[4];
            ReadProcessMemory(context.GetProcess(), address, buffer, 4, out cursor);
            return BitConverter.ToInt32(buffer, 0);
        }

        public IntPtr ReadPtr(IntPtr address)
        {
            IntPtr cursor = IntPtr.Zero;
            byte[] buffer = new byte[8];
            ReadProcessMemory(context.GetProcess(), address, buffer, 8, out cursor);
            return new IntPtr(BitConverter.ToInt64(buffer, 0));
        }
    }
}
