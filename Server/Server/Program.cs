using System;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;
using System.Net;
using System.Security.Cryptography;

namespace ServerSocketApp
{
    public class Program
    {
        public static TcpListener listener = new TcpListener(IPAddress.Parse("192.168.0.14"), port);
        static string ip = "192.168.0.14";
        static int port = 1302;
        static string world;
        static void Main(string[] args)
        {
            Start();
        }
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("Marburgh Multiplayer 0.1 - Server");
            Console.WriteLine("IP adress - " + ip);
            if (File.Exists("World.txt"))
            {
                string rawInfo = File.ReadAllText("World.txt");
                string[] info = rawInfo.Split(",");
                Console.SetCursorPosition(100, 27);
                Console.WriteLine("World: " + world);
            }
            Console.SetCursorPosition(100, 27);
            Console.WriteLine("[!] Create World");
            Console.SetCursorPosition(100, 28);
            Console.WriteLine("[*] Reset World");
            Console.SetCursorPosition(0, 21);            
            Console.WriteLine("[1] Start game - 1302");
            Console.WriteLine("[2] Start game - 1303");
            Console.WriteLine("[3] Start game - 1304");
            Console.WriteLine("[4] Start game - 1305");
            Console.WriteLine("[5] Start game - 1306");
            Console.WriteLine("[6] Change IP");
            Console.WriteLine("[9] Run Maintenance");
            Console.WriteLine("[0] Quit Program");
            string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if (choice == "1")
            {
                port = 1302;
                listener = new TcpListener(IPAddress.Parse(ip), port);
                LaunchGame();
            }
            else if (choice == "2")
            {
                port = 1303;
                listener = new TcpListener(IPAddress.Parse(ip), port);
                LaunchGame();
            }
            else if (choice == "3")
            {
                port = 1304;
                listener = new TcpListener(IPAddress.Parse(ip), port);
                LaunchGame();
            }
            else if (choice == "4")
            {
                port = 1305;
                listener = new TcpListener(IPAddress.Parse(ip), port);
                LaunchGame();
            }
            else if (choice == "5")
            {
                port = 1306;
                listener = new TcpListener(IPAddress.Parse(ip), port);
                LaunchGame();
            }
            else if (choice == "6")
            {
                Console.Clear();
                Console.WriteLine("Please enter the new IP");
                string newIP = Console.ReadLine();
                ip = newIP;
                Start();
            }
            else if (choice == "9") Maintenance();
            else if (choice == "*") CatastropheReset();
            else if (choice == "0") Environment.Exit(0);
            else Start();
        }



        private static void CatastropheReset()
        {
            Console.Clear();
            Console.WriteLine("Are you sure?\nThis will erase ALL data");
            Console.CursorTop = 26;
            Console.WriteLine("[1] Yes");
            Console.WriteLine("[2] No");
            string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if (choice == "1")
            {
                string rawInfo = File.ReadAllText("Players.txt");
                string[] info = rawInfo.Split(",");
                foreach (string s in info) File.Delete(s + ".txt");
                Console.Clear();                
                Console.WriteLine("All data has been erased");
                Console.CursorTop = 28;
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                File.WriteAllText("Master.txt", "");
            }
            Start();
        }

        private static void Maintenance()
        {
            
        }

        public static void LaunchGame()
        {
            Console.Clear();
            Console.WriteLine("Ready for connections");
            Console.WriteLine("IP - " + ip);
            Console.WriteLine("Port - " + port);
            FindClient();
        }

        public static void FindClient()
        {            
            listener.Start();
            Utilities.client = listener.AcceptTcpClient();
            Utilities.stream = Utilities.client.GetStream();
            Utilities.sw = new StreamWriter(Utilities.client.GetStream());
            Menu();
        }

        public static void Menu()
        {
            Utilities.Clear();
            Console.WriteLine("\nConnection Found");
            Write.Line(Color.GOLD, Color.MONSTER, "", "Welcome to my first foray into ","","multiplayer","");
            Utilities.JumpY(26);            
            Write.Line("[1] New Game");
            Write.Line("[2] Load Game");
            Write.Line("[0] Quit");
            Utilities.Input();
            if (Utilities.input == "1") NewGame();
            else if (Utilities.input == "2") Data.Load();
            else if (Utilities.input == "0") Utilities.Logout();
            else Menu();
        }

        static void NewGame()
        {
            Player.p = new Player("");
            Name();
            Stats();
            Town.Go();
        }

        private static void Stats()
        {
            StatDisplay();
            Utilities.NewLine();
            Write.Line($"You have {Player.p.points} points to use to improve your character");
            Utilities.Input();
            if (Utilities.input == "1")
            {
                Player.p.AddStrength();
                Player.p.points--;
            }
            if (Utilities.input == "2")
            {
                Player.p.AddAgility();
                Player.p.points--;
            }
            if (Utilities.input == "3")
            {
                Player.p.AddStamina();
                Player.p.points--;
            }
            if (Player.p.points > 0)
            {
                Stats();
            }
            else
            {
                StatDisplay();
                Utilities.Keypress();
            }
        }

        private static void StatDisplay()
        {
            Utilities.Clear();
            Write.Line(Color.NAME, Player.p.name);
            Utilities.NewLine();
            Write.Line("[1] Strength: " + Player.p.strength);
            Write.Line("[2] Agility:  " + Player.p.agility);
            Write.Line("[3] Stamina:  " + Player.p.stamina);
            Utilities.NewLine(3);
            Write.Line("Strength increases your damage and helps you accomplish physical tasks");
            Write.Line("Agility affects your ability to hit, crit, and avoid damage");
            Write.Line("Stamina increase your hitpoints and helps you accomplish exhausting tasks");
        }

        private static void Name()
        {
            Utilities.Clear();
            Write.Line(Color.NAME, "What is your ", "name", "?\n");
            Utilities.NewLine();
            Utilities.InputColor(Color.NAME);
            Utilities.LongInput();
            Utilities.InputColor(Color.RESET);
            string rawInfo = File.ReadAllText("Master.txt");
            string[] info = rawInfo.Split(",");
            bool notThere = true;
            foreach (string s in info)
            {
                if (s == Utilities.input)
                {
                    notThere = false;
                    break;
                }
            }
            if (notThere)
            {
                Player.p.name = Utilities.input;
                Utilities.NewLine();
                Write.Line(Color.NAME, Utilities.input + "?");
                Utilities.YesNo();
                Utilities.Input();
                if (Utilities.input != "1") Menu();
            }
            else
            {
                Utilities.NewLine();
                Write.Line("Someone already goes by that name");
                Utilities.Keypress();
                Menu();
            }
            Password();
        }

        private static void Password()
        {
            Utilities.Clear();
            Write.Line("Please select a password");
            Utilities.LongInput();
            Player.p.password = Utilities.input;
            Utilities.NewLine(2);
            if (Player.p.password.Length < 4)
            {
                Utilities.NewLine();
                Write.Line("Sorry, your password is too short. Please make it at least 5 characters");
                Utilities.Keypress();
                Password();
            }
            else if (Player.p.password.Length >9)
            {
                Utilities.NewLine();
                Write.Line("Sorry, your password is too Long. Please make it less than 10 characters");
                Utilities.Keypress();
                Password();
            }
            Write.Line(Color.ABILITY, Player.p.password + "?");
            Utilities.YesNo();
            Utilities.Input();
            if (Utilities.input != "1") Password();
        }
    }
}