using System;
using System.Net.Sockets;
using System.Text;
using System.IO;

public class Write
{    
    public static void Line(string word)
    {
        Utilities.sw.WriteLine(word);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine(Color.RESET);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine("nl");
        Utilities.sw.Flush();
    }
    public static void Line(string color, string word)
    {
        Utilities.sw.WriteLine(color);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine(word);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine(Color.RESET);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine("nl");
        Utilities.sw.Flush();
    }
    public static void Line(string color, string word1, string word2, string word3)
    {
        Utilities.sw.WriteLine(word1);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine(color);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine(word2);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine(Color.RESET);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine(word3);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine("nl");
        Utilities.sw.Flush();
    }
    public static void Line(string color1, string color2, string word1,  string word2,  string word3, string word4, string word5)
    {
        Utilities.sw.WriteLine(word1);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine(color1);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine(word2);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine("cReset");
        Utilities.sw.Flush();
        Utilities.sw.WriteLine(word3);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine(color2);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine(word4);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine("cReset");
        Utilities.sw.Flush();
        Utilities.sw.WriteLine(word5);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine("nl");
        Utilities.sw.Flush();
    }
    public static void SameLine(string word)
    {
        Utilities.sw.WriteLine(word);
        Utilities.sw.Flush();
        Utilities.sw.WriteLine(Color.RESET);
        Utilities.sw.Flush();
    }
}