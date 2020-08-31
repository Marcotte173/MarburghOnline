using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

public class Utilities
{
    internal static void Keypress()
    {
        Console.SetCursorPosition(0, 28);
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    internal static void DotDotDot()
    {
        Console.Write(".");
        Thread.Sleep(600);
        Console.Write(".");
        Thread.Sleep(600);
        Console.Write(".");
        Thread.Sleep(800);
    }
}