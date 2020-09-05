using System;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Dynamic;
using System.Data;
using System.Threading;

namespace ClientSocketApp
{
    class Program
    {
        static TcpClient client;
        static NetworkStream stream;        
        static StreamReader sr;
        static string ip = "192.168.0.14";
        static int port = 1302;

        static void Main(string[] args)
        {
            Color.SetupConsole();
            Connect();                       
        }

        private static void Connect()
        {
            Console.Clear();
            Console.Clear();
            Console.WriteLine("Marburgh Multiplayer 0.1 - Client");
            Console.WriteLine("IP adress - " + ip);
            Console.SetCursorPosition(100, 28);
            Console.SetCursorPosition(0, 22);
            Console.WriteLine("[1] Start game - 1302");
            Console.WriteLine("[2] Start game - 1303");
            Console.WriteLine("[3] Start game - 1304");
            Console.WriteLine("[4] Start game - 1305");
            Console.WriteLine("[5] Start game - 1306");
            Console.WriteLine("[6] Change IP");
            Console.WriteLine("[0] Quit Program");
            string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if (choice == "1") port = 1302;
            if (choice == "2") port = 1303;
            if (choice == "3") port = 1304;
            if (choice == "4") port = 1305;
            if (choice == "5") port = 1306;
            if (choice == "6") 
            {
                Console.Clear();
                Console.WriteLine("Please enter the new IP");
                string newIP = Console.ReadLine();
                ip = newIP;
                Connect();
            }
            client = new TcpClient(ip, port);
            stream = client.GetStream();
            sr = new StreamReader(stream);
            Listen();
        }

        private static void Listen()
        {
        connection:
            try
            {
                string response = sr.ReadLine();
                if (response == "clr") Console.Clear();
                else if (response == "cName") Console.Write(Color.NAME);
                else if (response == "cReset") Console.Write(Color.RESET);
                else if (response == "cGold") Console.Write(Color.GOLD);
                else if (response == "cXP") Console.Write(Color.XP);
                else if (response == "cItem") Console.Write(Color.ITEM);
                else if (response == "cHealth") Console.Write(Color.HEALTH);
                else if (response == "cEnergy") Console.Write(Color.ENERGY);
                else if (response == "cMonster") Console.Write(Color.MONSTER);
                else if (response == "cBold") Console.Write(Color.BOLD);
                else if (response == "cBlood") Console.Write(Color.BLOOD);
                else if (response == "cBurning") Console.Write(Color.BURNING);
                else if (response == "cShield") Console.Write(Color.SHIELD);
                else if (response == "cClass") Console.Write(Color.CLASS);
                else if (response == "cStun") Console.Write(Color.STUNNED);
                else if (response == "cBoss") Console.Write(Color.BOSS);
                else if (response == "cAbility") Console.Write(Color.ABILITY);
                else if (response == "cMitigation") Console.Write(Color.MITIGATION);
                else if (response == "uSleep") Thread.Sleep(600);
                else if (response == "...") Utilities.DotDotDot();
                else if (response == "xy0") Console.SetCursorPosition(0, 0);
                else if (response == "y0") Console.CursorTop = 0;
                else if (response == "y1") Console.CursorTop = 1;
                else if (response == "y2") Console.CursorTop = 2;
                else if (response == "y3") Console.CursorTop = 3;
                else if (response == "y4") Console.CursorTop = 4;
                else if (response == "y5") Console.CursorTop = 5;
                else if (response == "y6") Console.CursorTop = 6;
                else if (response == "y7") Console.CursorTop = 7;
                else if (response == "y8") Console.CursorTop = 8;
                else if (response == "y9") Console.CursorTop = 9;
                else if (response == "y10") Console.CursorTop = 10;
                else if (response == "y11") Console.CursorTop = 11;
                else if (response == "y12") Console.CursorTop = 12;
                else if (response == "y13") Console.CursorTop = 13;
                else if (response == "y14") Console.CursorTop = 14;
                else if (response == "y15") Console.CursorTop = 15;
                else if (response == "y16") Console.CursorTop = 16;
                else if (response == "y17") Console.CursorTop = 17;
                else if (response == "y18") Console.CursorTop = 18;
                else if (response == "y19") Console.CursorTop = 19;
                else if (response == "y20") Console.CursorTop = 20;
                else if (response == "y21") Console.CursorTop = 21;
                else if (response == "y22") Console.CursorTop = 22;
                else if (response == "y23") Console.CursorTop = 23;
                else if (response == "y24") Console.CursorTop = 24;
                else if (response == "y25") Console.CursorTop = 25;
                else if (response == "y26") Console.CursorTop = 26;
                else if (response == "y27") Console.CursorTop = 27;
                else if (response == "x20") Console.CursorLeft = 20;
                else if (response == "x25") Console.CursorLeft = 25;
                else if (response == "x30") Console.CursorLeft = 30;
                else if (response == "x35") Console.CursorLeft = 35;
                else if (response == "x40") Console.CursorLeft = 40;
                else if (response == "x45") Console.CursorLeft = 45;
                else if (response == "x50") Console.CursorLeft = 50;
                else if (response == "x55") Console.CursorLeft = 55;
                else if (response == "x60") Console.CursorLeft = 60;
                else if (response == "x65") Console.CursorLeft = 65;
                else if (response == "x70") Console.CursorLeft = 70;
                else if (response == "x75") Console.CursorLeft = 75;
                else if (response == "x80") Console.CursorLeft = 80;
                else if (response == "x85") Console.CursorLeft = 85;
                else if (response == "x90") Console.CursorLeft = 90;
                else if (response == "x95") Console.CursorLeft = 95;
                else if (response == "x100") Console.CursorLeft = 100;
                else if (response == "x105") Console.CursorLeft = 105;
                else if (response == "nl") Console.Write("\n");
                else if (response == "k") Utilities.Keypress();
                else if (response == "yn")
                {
                    Console.SetCursorPosition(0, 27);
                    Console.WriteLine("[1]" + Color.HEALTH + " Yes" + Color.RESET);
                    Console.WriteLine("[2]" + Color.MONSTER + " No" + Color.RESET);
                }
                else if (response == "q")
                {
                    stream.Close();
                    client.Close();
                    Environment.Exit(0);
                }
                else if (response == "i") Input();
                else if (response == "li") LongInput();
                else Console.Write(response);
                goto connection;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to connect...");
                Console.WriteLine("");
                Connect();
            }
        }

        private static void LongInput()
        {
            string messageToSend = Console.ReadLine();
            if (messageToSend == "") LongInput();
            int byteCount = Encoding.ASCII.GetByteCount(messageToSend + 1);
            byte[] sendData = Encoding.ASCII.GetBytes(messageToSend);
            stream.Write(sendData, 0, sendData.Length);
        }

        private static void Input()
        {
            string messageToSend = Console.ReadKey(true).KeyChar.ToString().ToLower();
            int byteCount = Encoding.ASCII.GetByteCount(messageToSend + 1);
            byte[] sendData = Encoding.ASCII.GetBytes(messageToSend);
            stream.Write(sendData, 0, sendData.Length);
        }
    }
}
