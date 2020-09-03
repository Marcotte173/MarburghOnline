using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class World
{
    public static List<string> roderick = new List<string> { };
    public static string name;
    public static int day = 1;
    public static int fights = 15;
    public static int townActions = 3;
    public static int songs = 2;
    public static int drinks = 3;
    public static int startingGold = 200; 
    public static int bankGold = 1000;


    public static void Create()
    {
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
            Console.WriteLine("[8] Add to the song");
            Console.WriteLine("[9] Create World");
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

    public static void Save()
    {
        File.AppendAllText("Players.txt", "");
        File.AppendAllText("World.txt", day + ",");
        File.AppendAllText("World.txt", name + ",");
        File.AppendAllText("World.txt", fights + ",");
        File.AppendAllText("World.txt", townActions + ",");
        File.AppendAllText("World.txt", songs + ",");
        File.AppendAllText("World.txt", drinks + ",");
        File.AppendAllText("World.txt", startingGold + ",");
        File.AppendAllText("World.txt", bankGold + ",");
        if (roderick.Count !=0) foreach(string s in roderick) File.AppendAllText("World.txt", s + ",");
    }
}