using System;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;
using System.Reflection.Metadata.Ecma335;

public enum Location { Town,Tavern,House}
public class Utilities
{
    public static StreamWriter sw;
    public static TcpClient client;
    public static NetworkStream stream;
    public static string input;
    public static bool received;
    public static Random rand = new Random();
    public static void Input()
    {
        sw.WriteLine("i");
        sw.Flush();
        Listen();
    }

    internal static void JumpY(int v)
    {
        sw.WriteLine("y"+v.ToString());
        sw.Flush();
    }

    public static void LongInput()
    {
        sw.WriteLine("li");
        sw.Flush();
        Listen();
    }

    public  static void Listen()
    {
        while (received == false)
        {
            try
            {
                byte[] buffer = new byte[1024];
                Utilities.stream.Read(buffer, 0, buffer.Length);
                int recv = 0;
                foreach (byte b in buffer)
                {
                    if (b != 0)
                    {
                        recv++;
                    }
                }
                input = Encoding.UTF8.GetString(buffer, 0, recv);
                received = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong.");
                Utilities.sw.WriteLine(e.ToString());
                ServerSocketApp.Program.Start();
            }
        }
        received = false;
    }

    internal static void Keypress()
    {
        sw.WriteLine("k");
        sw.Flush();
    }

    internal static void Clear()
    {
        sw.WriteLine("clr");
        sw.Flush();
    }

    public static void NewLine()
    {
        sw.WriteLine("nl");
        sw.Flush();
    }
    public static void NewLine(int number)
    {
        for (int i = 0; i < number; i++)
        {
            sw.WriteLine("nl");
            sw.Flush();
        }        
    }

    internal static void Logout()
    {
        sw.WriteLine("q");
        sw.Flush();
        ServerSocketApp.Program.FindClient();
    }

    public static void InputColor(string color)
    {
        sw.WriteLine(color);
        sw.Flush();
    }

    internal static int RandomInt(int min, int max)
    {
        return rand.Next(min, max);
    }

    internal static void YesNo()
    {
        sw.WriteLine("yn");
        sw.Flush();
    }

    internal static bool CanAfford(int price) => Player.p.gold >= price;
}