using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class World
{
    public static List<string> roderick = new List<string> { };
    public static string name = "Marcotte";
    public static int day = 1;
    public static int fights = 15;
    public static int townActions = 3;
    public static int songs = 2;
    public static int drinks = 3;
    public static int startingGold = 200;
    public static int bankGold = 1000;
    public static double bankInterest = 0.05;


    public static void Create()
    {
        File.WriteAllText("Players.txt", "");
        if (File.Exists("World.txt"))
        {
            Console.Clear();
            Console.WriteLine("There is already a world!");
            Console.CursorTop = 28;
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            ServerSocketApp.Program.Start();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("World Attrributes");
            Console.CursorTop = 19;
            Console.WriteLine("[1] World Name: " + name);
            Console.WriteLine("[2] Fights: " + fights);
            Console.WriteLine("[3] Town Actions: " + townActions);
            Console.WriteLine("[4] Drinks: " + drinks);
            Console.WriteLine("[5] Songs: " + songs);
            Console.WriteLine("[6] Starting Gold: " + startingGold);
            Console.WriteLine("[7] Bank Gold: " + bankGold);
            Console.WriteLine("[8] Bank Interest: " + bankInterest);
            Console.WriteLine("[9] Create World");
            Console.WriteLine("[S] Add to the song");
            Console.WriteLine("[0] Return to main menu");
            string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if (choice == "1")
            {
                Console.Clear();
                Console.WriteLine("Please enter a name for the world");
                string newName = Console.ReadLine();
                name = newName;                
            }
            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("How many fights per day should a player get?");
                int number;
                do
                {

                } while (!int.TryParse(Console.ReadLine(), out number));
                fights = number;
            }
            else if (choice == "3")
            {
                Console.Clear();
                Console.WriteLine("How many town actions a day should a player get?");
                int number;
                do
                {

                } while (!int.TryParse(Console.ReadLine(), out number));
                townActions = number;
            }
            else if (choice == "4")
            {
                Console.Clear();
                Console.WriteLine("How many drinks should a player be able to buy?");
                int number;
                do
                {

                } while (!int.TryParse(Console.ReadLine(), out number));
                drinks = number;
            }
            else if (choice == "5")
            {
                Console.Clear();
                Console.WriteLine("How many songs should a player be able to hear per day?");
                int number;
                do
                {

                } while (!int.TryParse(Console.ReadLine(), out number));
                songs = number;
            }
            else if (choice == "6")
            {
                Console.Clear();
                Console.WriteLine("How much gold should the player start with?");
                int number;
                do
                {

                } while (!int.TryParse(Console.ReadLine(), out number));
                startingGold = number;
            }
            else if (choice == "7")
            {
                Console.Clear();
                Console.WriteLine("How much gold should the bank start with?");
                int number;
                do
                {

                } while (!int.TryParse(Console.ReadLine(), out number));
                bankGold = number;
            }
            else if (choice == "8")
            {
                Console.Clear();
                Console.WriteLine("What should the starting interest rate be?");
                int number;
                do
                {

                } while (!int.TryParse(Console.ReadLine(), out number));
                bankInterest = number;
            }
            else if (choice == "s")
            {
                Console.Clear();
                Console.WriteLine("What should the next line be?");
                string song = Console.ReadLine();
                roderick.Add(song);
            }
            else if (choice == "9")
            {
                Console.Clear();
                Console.WriteLine("World Created!");
                Console.CursorTop = 28;
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                Save();
                ServerSocketApp.Program.Start();
            }
            else if (Utilities.input == "0") ServerSocketApp.Program.Start();
            Create();
        }        
    }

    public static void Change()
    {
        Console.Clear();
        Console.WriteLine("World Attrributes");
        Console.CursorTop = 19;
        Console.WriteLine("[1] World Name: " + name);
        Console.WriteLine("[2] Fights: " + fights);
        Console.WriteLine("[3] Town Actions: " + townActions);
        Console.WriteLine("[4] Drinks: " + drinks);
        Console.WriteLine("[5] Songs: " + songs);
        Console.WriteLine("[6] Starting Gold: " + startingGold);
        Console.WriteLine("[7] Bank Gold: " + bankGold);
        Console.WriteLine("[8] Bank Interest: " + bankInterest);
        Console.WriteLine("[9] Save Changes" );
        Console.WriteLine("[S] Add to the song");
        Console.WriteLine("[0] Return to main menu");
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "1")
        {
            Console.Clear();
            Console.WriteLine("Please enter a name for the world");
            string newName = Console.ReadLine();
            name = newName;
        }
        else if (choice == "2")
        {
            Console.Clear();
            Console.WriteLine("How many fights per day should a player get?");
            int number;
            do
            {

            } while (!int.TryParse(Console.ReadLine(), out number));
            fights = number;
        }
        else if (choice == "3")
        {
            Console.Clear();
            Console.WriteLine("How many town actions a day should a player get?");
            int number;
            do
            {

            } while (!int.TryParse(Console.ReadLine(), out number));
            townActions = number;
        }
        else if (choice == "4")
        {
            Console.Clear();
            Console.WriteLine("How many drinks should a player be able to buy?");
            int number;
            do
            {

            } while (!int.TryParse(Console.ReadLine(), out number));
            drinks = number;
        }
        else if (choice == "5")
        {
            Console.Clear();
            Console.WriteLine("How many songs should a player be able to hear per day?");
            int number;
            do
            {

            } while (!int.TryParse(Console.ReadLine(), out number));
            songs = number;
        }
        else if (choice == "6")
        {
            Console.Clear();
            Console.WriteLine("How much gold should the player start with?");
            int number;
            do
            {

            } while (!int.TryParse(Console.ReadLine(), out number));
            startingGold = number;
        }
        else if (choice == "7")
        {
            Console.Clear();
            Console.WriteLine("How much gold should the bank start with?");
            int number;
            do
            {

            } while (!int.TryParse(Console.ReadLine(), out number));
            bankGold = number;
        }
        else if (choice == "8")
        {
            Console.Clear();
            Console.WriteLine("What should the starting interest rate be?");
            int number;
            do
            {

            } while (!int.TryParse(Console.ReadLine(), out number));
            bankInterest = number;
        }
        else if (choice == "s")
        {
            Console.Clear();
            Console.WriteLine("What should the next line be?");
            string song = Console.ReadLine();
            roderick.Add(song);
        }
        else if (choice == "9")
        {
            Console.Clear();
            Console.WriteLine("World Saved!");
            Console.CursorTop = 28;
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            Save();
            ServerSocketApp.Program.Start();
        }
        else if (choice == "0") ServerSocketApp.Program.Start();
        Change();
    }

    public static void Save()
    {        
        File.WriteAllText("World.txt", day + ",");
        File.AppendAllText("World.txt", name + ",");
        File.AppendAllText("World.txt", fights + ",");
        File.AppendAllText("World.txt", townActions + ",");
        File.AppendAllText("World.txt", songs + ",");
        File.AppendAllText("World.txt", drinks + ",");
        File.AppendAllText("World.txt", startingGold + ",");
        File.AppendAllText("World.txt", bankGold + ",");
        File.AppendAllText("World.txt", bankInterest + ",");
        if (roderick.Count !=0) foreach(string s in roderick) File.AppendAllText("World.txt", s + ",");
    }
    public static void Load()
    {
        if (File.Exists("World.txt"))
        {
            string rawInfo = File.ReadAllText("World.txt");
            string[] info = rawInfo.Split(",");
            World.day = Int32.Parse(info[0]);
            World.name = info[1];
            World.fights = Int32.Parse(info[2]);
            World.townActions = Int32.Parse(info[3]);
            World.songs = Int32.Parse(info[4]);
            World.drinks = Int32.Parse(info[5]);
            World.startingGold = Int32.Parse(info[6]);
            World.bankGold = Int32.Parse(info[7]);
            World.bankInterest = Double.Parse(info[8]);
            for (int i = 9; i < info.Length; i++) World.roderick.Add(info[i]);
        }
    }
}