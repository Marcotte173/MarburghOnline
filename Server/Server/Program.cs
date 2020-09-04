using System;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace ServerSocketApp
{
    public class Program
    {
        public static TcpListener listener = new TcpListener(IPAddress.Parse("192.168.0.14"), port);
        static string ip = "192.168.0.14";
        static int port = 1302;
        static void Main(string[] args)
        {
            World.Load();
            Start();
        }
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("Marburgh Multiplayer 0.3 - Server");
            Console.WriteLine("IP adress - " + ip);
            Console.SetCursorPosition(80, 0);
            if (File.Exists("World.txt"))
            {
                Console.WriteLine("World: " + World.name);
                Console.SetCursorPosition(80, 1);
                Console.WriteLine("Day: " + World.day);
                Console.SetCursorPosition(80, 2);
                Console.WriteLine("fights: " + World.fights);
                Console.SetCursorPosition(80, 3);
                Console.WriteLine("Town Actions: " + World.townActions);
                Console.SetCursorPosition(80, 4);
                Console.WriteLine("Songs: " + World.songs);
                Console.SetCursorPosition(80, 5);
                Console.WriteLine("Drinks: " + World.drinks);
                Console.SetCursorPosition(80, 5);
                Console.WriteLine("Starting Gold: " + World.startingGold);
                Console.SetCursorPosition(80, 6);
                Console.WriteLine("Bank Gold: " + World.bankGold);
                Console.SetCursorPosition(80, 7);
                Console.WriteLine("Interest rate: " + World.bankInterest);
            }
            else Console.WriteLine("World: None");
            Console.SetCursorPosition(80, 27);
            Console.WriteLine("[!] Create World");
            Console.SetCursorPosition(80, 28);
            Console.WriteLine("[*] Reset World");
            Console.SetCursorPosition(0, 21);
            if (File.Exists("World.txt"))
            {
                Console.WriteLine("[1] Start game - 1302");
                Console.WriteLine("[2] Start game - 1303");
                Console.WriteLine("[3] Start game - 1304");
                Console.WriteLine("[4] Start game - 1305");
                Console.WriteLine("[5] Start game - 1306");
            }
            else
            {
                Console.WriteLine("[X] No World Exists");
                Console.WriteLine("[X] No World Exists");
                Console.WriteLine("[X] No World Exists");
                Console.WriteLine("[X] No World Exists");
                Console.WriteLine("[X] No World Exists");
            }
            Console.WriteLine("[6] Change IP");
            if (File.Exists("World.txt")) Console.WriteLine("[7] Change World");
            else Console.WriteLine("[X] No World Exists");
            if (File.Exists("World.txt")) Console.WriteLine("[9] Run Maintenance");
            else Console.WriteLine("[X] No World Exists");
            Console.WriteLine("[0] Quit Program");
            string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if (choice == "1" && File.Exists("World.txt"))
            {
                port = 1302;
                listener = new TcpListener(IPAddress.Parse(ip), port);
                LaunchGame();
            }
            else if (choice == "2" && File.Exists("World.txt"))
            {
                port = 1303;
                listener = new TcpListener(IPAddress.Parse(ip), port);
                LaunchGame();
            }
            else if (choice == "3" && File.Exists("World.txt"))
            {
                port = 1304;
                listener = new TcpListener(IPAddress.Parse(ip), port);
                LaunchGame();
            }
            else if (choice == "4" && File.Exists("World.txt"))
            {
                port = 1305;
                listener = new TcpListener(IPAddress.Parse(ip), port);
                LaunchGame();
            }
            else if (choice == "5" && File.Exists("World.txt"))
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
            else if (choice == "7" && File.Exists("World.txt")) World.Change();
            else if (choice == "9" && File.Exists("World.txt")) Maintenance();
            else if (choice == "!") World.Create();
            else if (choice == "*") RestWorld();
            else if (choice == "0") Environment.Exit(0);
            else Start();
        }



        private static void RestWorld()
        {
            Console.Clear();
            Console.WriteLine("Are you sure?\nThis will erase ALL data");
            Console.CursorTop = 26;
            Console.WriteLine("[1] Yes");
            Console.WriteLine("[2] No");
            string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if (choice == "1")
            {
                File.Delete("Players.txt");
                File.Delete("World.txt");
                Console.Clear();                
                Console.WriteLine("All data has been erased");
                Console.CursorTop = 28;
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
            }
            Start();
        }

        private static void Maintenance()
        {
            Console.Clear();
            Console.WriteLine("Would you like to progress the world by one day?");
            Console.CursorTop = 27;
            Console.WriteLine("[1] Yes");
            Console.WriteLine("[2] No");
            string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if(choice == "1")
            {                
                WorldMaintenance();
                PlayerMaintenance();                
            }            
            Start();
        }

        private static void PlayerMaintenance()
        {
            string rawInfo = File.ReadAllText("Players.txt");
            string[] info = rawInfo.Split(",");
            foreach (string s in info)
            {
                if (s != "")
                {
                    string rawInfo1 = File.ReadAllText(s + ".txt");
                    string[] info1 = rawInfo1.Split(",");
                    Player.p.name = info1[0];
                    Player.p.level = Int32.Parse(info1[1]);
                    Player.p.experience = Int32.Parse(info1[2]);
                    Player.p.strength = Int32.Parse(info1[3]);
                    Player.p.agility = Int32.Parse(info1[4]);
                    Player.p.stamina = Int32.Parse(info1[5]);
                    Player.p.hp = Int32.Parse(info1[6]);
                    Player.p.maxHp = Int32.Parse(info1[7]);
                    Player.p.fights = Int32.Parse(info1[8]);
                    Player.p.points = Int32.Parse(info1[9]);
                    foreach (Equipment e in Equipment.weaponList) if (e.name == info1[10]) Player.p.weapon = e.Copy();
                    foreach (Equipment e in Equipment.armorList) if (e.name == info1[11]) Player.p.armor = e.Copy();
                    Player.p.gold = Int32.Parse(info1[12]);
                    Player.p.goldInBank = Int32.Parse(info1[13]);
                    Player.p.house = (info1[14] == "true") ? true : false;
                    Player.p.location = (info1[15] == "Tavern") ? Location.Tavern : (info1[15] == "House") ? Location.House : Location.Town;
                    Player.p.password = info1[16];
                    Player.p.drinks = Int32.Parse(info1[17]);
                    Player.p.songs = Int32.Parse(info1[18]);
                    Player.p.tavernBan = (info1[19] == "true") ? true : false;
                    Player.p.townActions = Int32.Parse(info1[20]);
                    File.WriteAllText
                   (
                    s + ".txt",
                    Player.p.name + "," +
                    Player.p.level + "," +
                    Player.p.experience + "," +
                    Player.p.strength + "," +
                    Player.p.agility + "," +
                    Player.p.stamina + "," +
                    Player.p.hp + "," +
                    Player.p.maxHp + "," +
                    World.fights + "," +
                    Player.p.points + "," +
                    Player.p.weapon.name + "," +
                    Player.p.armor.name + "," +
                    Player.p.gold + "," +
                    Player.p.goldInBank + "," +
                    Player.p.house + "," +
                    Player.p.location + "," +
                    Player.p.password + "," +
                    World.drinks + "," +
                    World.songs + "," +
                    "False" + "," +
                    World.townActions
                    );
                }
            }
        }

        private static void WorldMaintenance()
        {
            World.day++;
            World.bankGold += 2000;
            World.bankInterest += 0.0001 * Utilities.RandomInt(-10, 11);
            World.Save();
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
            Level.Stats();
            Town.Go();
        }       

        private static void Name()
        {
            Utilities.Clear();
            Write.Line(Color.NAME, "What is your ", "name", "?\n");
            Utilities.NewLine();
            Utilities.InputColor(Color.NAME);
            Utilities.LongInput();
            Utilities.InputColor(Color.RESET);
            string rawInfo = File.ReadAllText("Players.txt");
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