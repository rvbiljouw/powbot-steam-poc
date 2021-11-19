using steampoctest.PowBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace steampoctest.PowBot
{
    class Context
    {
      
        private readonly IntPtr process;
        private readonly IntPtr baseAddress;
        private readonly Memory memory;

        public Context(IntPtr process, IntPtr baseAddress)
        {
            this.process = process;
            this.baseAddress = baseAddress;
            this.memory = new Memory(this);
        }

        public IntPtr GetProcess()
        {
            return process;
        }

        public IntPtr GetBaseAddress()
        {
            return baseAddress;
        }

        public Memory GetMemory()
        {
            return memory;
        }

        public Actor GetLocalPlayer()
        {
            IntPtr localPlayerPtr = IntPtr.Add(baseAddress, 0x1BD7FA8);
            IntPtr instancePtr = GetMemory().ReadPtr(localPlayerPtr);
            return new Actor(this, instancePtr);
        }


    }
}
