using System;
using System.Collections.Generic;
using System.Text;

public class Level
{
    public static void Go()
    {
        Utilities.Clear();
        Player.p.level++;
        Write.Line("You gained a level!");
        Write.Line("You are now level " + Player.p.level);
        if (Player.p.level % 5 == 0)
        {
            Write.Line("You gain 2 points to improve your character");
            Player.p.points += 2;
        }
        else
        {
            Write.Line("You gain 1 points to improve your character");
            Player.p.points ++;
        }
        Utilities.Keypress();
        Console.Clear();
        Stats();
    }
    public static void Stats()
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
}