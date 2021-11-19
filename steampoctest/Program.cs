using steampoctest.PowBot;
using steampoctest.PowBot.Api;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace steampoctest
{
    class Program
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(
            uint processAccess,
            bool bInheritHandle,
            uint processId
        );

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(
            string lpClassName,
            string lpWindowName
        );

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(
            IntPtr hWnd, 
            out uint processId
        );


        static void Main(string[] args)
        {
            IntPtr hwnd = FindWindow(null, "Old School RuneScape");
            GetWindowThreadProcessId(hwnd, out uint pid);
            if (pid <= 0)
            {
                Console.WriteLine("Failed to find the OSRS process");
                return;
            }

            IntPtr processHandle = OpenProcess(0x001F0FFF, true, pid);
            Context context = new Context(processHandle, new IntPtr(0x7FF603570000));

            Actor player = context.GetLocalPlayer();
            Console.WriteLine("Animation: {0} | SpotAnimation: {1} | AnimationDelay: {2} | MovementSpeed: {3} | WalkingQueueLength: {4} | X: {5} | Y: {6}", 
                player.GetAnimation(),
                player.GetSpotAnimation(),
                player.GetAnimationDelay(),
                player.GetMovementSpeed(),
                player.GetWalkingQueueLength(),
                player.GetX(),
                player.GetY());
            // TODO: Replace with discovered module pointer

            Console.ReadKey();
        }
    }
}
