using System;
using System.Collections.Generic;
using System.Text;

public class Tavern
{
    public static void Go()
    {
        Write.Line("You walk into a nice tavern. It seems cozy. In the corner you see Roderick, the bard.");
        Write.Line("Behind the counter, Billiam is cleaning a mug");
        Utilities.JumpY(24);
        Write.Line("[1] Inquire about a room for a night");
        Write.Line("[2] Order a soda");
        Write.Line("[3] Talk to the Billiam");
        Write.Line("[4] Listen to Roderick sing");
        Write.Line("[0] Return to Town");
        Utilities.Input();
        if(Utilities.input == "1")
        {
            Utilities.Clear();
            if (Utilities.CanAfford(100))
            {                
                Write.Line("Billiam looks you over");
                Write.Line("A room, eh? No problem, I have one available");
                Write.Line("That will be 100 gold");
                Write.Line("Would you like to rent this room?");
                Utilities.Input();
                if (Utilities.input == "1")
                {
                    Player.p.location = Location.Tavern;
                    Player.p.gold -= 100;

                    Utilities.Logout();
                }
                else Go();
            }
            Write.Line("'Come back when you have money!'");
            Utilities.Keypress();
            Go();
        }
    }
}