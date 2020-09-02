using System;
using System.Collections.Generic;
using System.Text;

public class Town
{
    public static Shop weaponShop = new Shop("Sam", "Orc", "Weapon", Equipment.weaponList);
    public static Shop armorShop = new Shop("Absilf", "Elf", "Armor", Equipment.armorList);
    public static void Go()
    {
        Utilities.Clear();
        Write.Line("You are in the city-state of Marburgh.");
        Write.Line("It is under construction, so there is not a ton to do yet");
        Utilities.JumpY(18);
        Write.Line("[1] Enter the dungeon");
        Write.Line("[2] Weapon Shop");
        Write.Line("[3] Armor Shop");
        if(Player.p.tavernBan) Write.Line(Color.MITIGATION, "[X] ", "You've been banned. Come back tomorrow", "");
        else Write.Line("[4] Tavern");
        Write.Line("[5] Bank");
        Write.Line(Color.MITIGATION, "[X] ","You don't have a house","");
        Write.Line("[7] Level Master");
        Write.Line(Color.MITIGATION, "[X] ","Not Implemented","");
        Write.Line("[9] Character");
        Write.Line("[0] Quit");
        Utilities.Input();
        if (Utilities.input == "1") Write.Line("Not Implemented yet");
        else if (Utilities.input == "2") weaponShop.Store();
        else if (Utilities.input == "3") armorShop.Store();
        else if (Utilities.input == "4" && Player.p.tavernBan == false) Tavern.Go();
        else if (Utilities.input == "5") Write.Line("Not Implemented yet");
        else if (Utilities.input == "6") Write.Line("Not Implemented yet");
        else if (Utilities.input == "6") Write.Line("Not Implemented yet");
        else if (Utilities.input == "9") Write.Line("Not Implemented yet");
        else if (Utilities.input == "0")
        {
            Utilities.Clear();
            Write.Line("Are you sure you want to log out here? You will not be safe");
            Utilities.YesNo();
            Utilities.Input();
            if(Utilities.input == "1")
            {
                Player.p.location = Location.Town;
                Data.Save();
                Utilities.Logout();
            }
        }
        Go();
    }    
}