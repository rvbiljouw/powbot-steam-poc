using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace steampoctest.PowBot.Api
{
    class Actor
    {
        private readonly Context context;
        private readonly IntPtr pointer;

        public Actor(Context context, IntPtr pointer)
        {
            this.context = context;
            this.pointer = pointer;
        }

        public int GetAnimation()
        {
            return context.GetMemory().ReadInt(IntPtr.Add(pointer, 0x104));
        }

        public int GetSpotAnimation()
        {
            return context.GetMemory().ReadInt(IntPtr.Add(pointer, 0x118));
        }

        public int GetAnimationDelay()
        {
            return context.GetMemory().ReadInt(IntPtr.Add(pointer, 0x110));
        }

        public int GetMovementSpeed()
        {
            return context.GetMemory().ReadInt(IntPtr.Add(pointer, 0x15c));
        }

        public int GetWalkingQueueLength()
        {
            return context.GetMemory().ReadInt(IntPtr.Add(pointer, 0x1c0));
        }

        public int GetX()
        {
            return context.GetMemory().ReadInt(IntPtr.Add(pointer, 0x10));
        }

        public int GetY()
        {
            return context.GetMemory().ReadInt(IntPtr.Add(pointer, 0x14));
        }

    }
}
