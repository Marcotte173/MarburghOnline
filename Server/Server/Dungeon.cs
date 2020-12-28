using System;
using System.Collections.Generic;
using System.Text;

public class Dungeon
{
    public static int dungeonLevel; 
    public static void Go()
    {
        Utilities.Clear();
        Write.Line("You are in dungeon level " + dungeonLevel);
        Write.Line("[1] Look for a fight");
        Write.Line("[2] ");
    }
}