using System;
using System.Collections.Generic;
using System.Text;

public class Utilities
{
    internal static void Keypress()
    {
        Console.SetCursorPosition(0, 28);
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
}