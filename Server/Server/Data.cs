using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Data
{
    public static void Save()
    {
        File.WriteAllText
               (
                Player.p.name           + ".txt",
                Player.p.name           + "," +
                Player.p.level          + "," +
                Player.p.experience        + "," +
                Player.p.strength       + "," +
                Player.p.agility       + "," +
                Player.p.stamina          + "," +
                Player.p.hp              + "," +
                Player.p.maxHp          + "," +
                Player.p.fights           + "," +
                Player.p.points      + "," +
                Player.p.weapon.name        + "," +
                Player.p.armor.name      + "," +
                Player.p.gold          + "," +
                Player.p.goldInBank       + "," +
                Player.p.house       + "," +
                Player.p.location + "," +
                Player.p.password + "," +
                Player.p.drinks + "," +
                Player.p.songs + "," +
                Player.p.tavernBan + "," +
                Player.p.daySaved
                );
        if (File.Exists("Players.txt"))
        {
            string rawInfo = File.ReadAllText("Players.txt");
            string[] info = rawInfo.Split(",");
            bool notThere = true;
            foreach(string s in info)
            {
                if (s == Player.p.name)
                {
                    notThere = false;
                    break;
                }
            }
            if(notThere) File.AppendAllText("Players.txt", Player.p.name + ",");
        }
        else File.AppendAllText("Players.txt", Player.p.name + ",");
    }

    public static void Load()
    {
        Utilities.Clear();
        Write.Line("What is your character's name?");
        Utilities.NewLine(2);
        Utilities.LongInput();
        if (File.Exists(Utilities.input + ".txt"))
        {
            string rawInfo = File.ReadAllText(Utilities.input+".txt");
            string[] info = rawInfo.Split(",");
            Player.p.name = info[0];
            Player.p.level = Int32.Parse(info[1]);
            Player.p.experience = Int32.Parse(info[2]);
            Player.p.strength = Int32.Parse(info[3]);
            Player.p.agility = Int32.Parse(info[4]);
            Player.p.stamina = Int32.Parse(info[5]);
            Player.p.hp = Int32.Parse(info[6]);
            Player.p.maxHp = Int32.Parse(info[7]);
            Player.p.fights = Int32.Parse(info[8]);
            Player.p.points = Int32.Parse(info[9]);
            foreach (Equipment e in Equipment.weaponList) if (e.name == info[10]) Player.p.weapon = e.Copy();
            foreach (Equipment e in Equipment.armorList) if (e.name == info[11]) Player.p.armor = e.Copy();
            Player.p.gold = Int32.Parse(info[12]);
            Player.p.goldInBank = Int32.Parse(info[13]);
            Player.p.house = (info[14] == "true") ? true : false;
            Player.p.location = (info[15] == "Tavern")?Location.Tavern: (info[15] == "House")?Location.House:Location.Town;
            Player.p.password = info[16];
            Player.p.drinks = Int32.Parse(info[17]);
            Player.p.songs = Int32.Parse(info[18]);
            Player.p.tavernBan = (info[19] =="true") ? true : false; 
            Player.p.daySaved = Int32.Parse(info[20]);
            Write.Line("Please enter your password");
            Utilities.LongInput();
            if (Utilities.input == Player.p.password)
            {
                if (Player.p.location == Location.Town) Town.Go();
            }
            else
            {
                Write.Line("That is not the correct password");
                Utilities.Keypress();
                ServerSocketApp.Program.Menu();
            }
        }
        else
        {
            Write.Line("That file does not exist");
            Utilities.Keypress();
            ServerSocketApp.Program.Menu();
        }
    }
}