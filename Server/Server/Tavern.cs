using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class Tavern
{
    public static void Go()
    {
        Utilities.Clear();
        Write.Line("You walk into a nice tavern. It seems cozy. In the corner you see Roderick, the bard.");
        Write.Line("Behind the counter, Billiam is cleaning a mug");
        Utilities.JumpY(24);
        Write.Line("[1] Inquire about a room for a night");
        Write.Line("[2] Order a soda");
        Write.Line("[3] Talk to the Billiam");
        Write.Line("[4] Listen to Roderick sing");
        Write.Line("[0] Return to Town");
        Utilities.Input();
        Utilities.Clear();
        if (Utilities.input == "1")
        {
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
                    Data.Save();
                    Utilities.Logout();
                }
                else Go();
            }
            Write.Line("'Come back when you have money!'");
            Utilities.Keypress();
            Go();
        }
        else if (Utilities.input == "2")
        {
            if(Player.p.drinks <= 0) Write.Line("'I think you've had enough sir. Come back tomorrow");
            else
            {
                if (Utilities.CanAfford(70))
                {
                    Write.Line("A soda costs 70 gold. The effects can... vary");
                    Write.Line("Would you like to buy one?");
                    Utilities.YesNo();
                    Utilities.Input();
                    if (Utilities.input == "1")
                    {
                        Utilities.Clear();
                        Write.Line("Down the hatch!");
                        Utilities.Sleep();
                        Write.Line("You down the entire soda in one gulp");
                        Utilities.Sleep();
                        Write.Line("Billiam looks at you. You look at Billiam.");
                        Utilities.Sleep();
                        Write.SameLine("You feel");
                        Utilities.DotDotDot();
                        Utilities.NewLine(3);
                        int roll = Utilities.RandomInt(1, 21);
                        Write.Line((roll == 1) ? "Awful!" : (roll > 1 && roll < 6) ? "Nauseous!" : (roll < 5 && roll < 9) ? "Sick!" : (roll > 12 && roll < 16) ? "Pretty Good!" : (roll > 15 && roll <20) ? "Great!" :(roll ==20)?"Amazing!":"Fine");
                        Utilities.Keypress();
                    }
                    else Go();
                }
                else Write.Line("'I'm sorry, you don't have enough money'");
            }
            Utilities.Keypress();
            Go();
        }
        else if (Utilities.input == "3")
        {

        }
        else if (Utilities.input == "4")
        {
            Write.Line("You grab a seat near Roderick");
            Write.Line("Roderick begins to sing");
            Utilities.Sleep();
            Write.Line("'Hark to the tale of Billiam, and the boy he loved so dear'");
            Utilities.Sleep();
            Write.Line("'They became the best of freinds for years and years and years.'");
            Utilities.Sleep();
            Utilities.NewLine(3);
            Write.Line("You consider how much, if at all, this song has touched your heart");
            Utilities.Sleep();
            Write.SameLine("You feel");
            Utilities.DotDotDot();
            Utilities.NewLine(3);
            int roll = Utilities.RandomInt(1, 21);
            Write.Line((roll == 1) ? "Disgusted!" : (roll > 1 && roll < 6) ? "Put off" : (roll < 15 && roll < 20) ? "Happy" : (roll == 20) ? "Elate!" : "Not much of anything, honestly");
            Utilities.Keypress();
            Utilities.Clear();
            if (roll == 1)
            {
                Write.Line("You tell Roderick how awful his music is, things get heated.");
                Write.Line("By the time the shouting match is over, you have been asked to leave the tavern. You can enter again tomorrow");
                Player.p.tavernBan = true;
                Utilities.Keypress();
                Town.Go();
            }
            else if (roll > 1 && roll < 6)
            {

            }
            else if (roll < 15 && roll < 20)
            {

            }
            else if(roll == 20)
            {

            }
            else
            {

            }

        }
    }
}