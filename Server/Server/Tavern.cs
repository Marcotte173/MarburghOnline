using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
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
                    Utilities.Clear();
                    Write.Line("You go up to your room and collapse in your bed.");
                    Write.Line("You drift off...");
                    Utilities.Keypress();
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
            if (Player.p.drinks <= 0) Write.Line("'I think you've had enough sir. Come back tomorrow");
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
                        Player.p.drinks--;
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
                        if (roll > 1 && roll < 6 && Player.p.fights < 4) roll = 1;
                        Write.Line((roll == 1) ? "Awful!" : (roll > 1 && roll < 6) ? "Nauseous!" : (roll < 5 && roll < 9) ? "Sick!" : (roll > 12 && roll < 16) ? "Pretty Good!" : (roll > 15 && roll < 20) ? "Great!" : (roll == 20) ? "Amazing!" : "Fine");
                        Utilities.Keypress();
                        Utilities.Clear();
                        if (roll == 1)
                        {
                            Write.Line("You've never tasted something so awful. Perhaps it was left out in the sun... forever.");
                            Write.Line("You are too sick to contune today. Maybe try again tomorrow");
                            Player.p.active = false;
                            Utilities.Keypress();
                            Utilities.Logout();
                        }
                        if (roll > 1 && roll < 6)
                        {
                            Write.Line("That did not sit well....");
                            Write.Line("You feel terrible. You need to rest a bit before leaving");
                            Write.Line("LOSE 3 FIGHTS");
                            Player.p.fights -= 3;

                        }
                        if (roll > 5 && roll < 9)
                        {
                            Write.Line("That's no good, spit it out!");
                            Write.Line("Billiam, dripping, looks at you. He is not amused.");
                            Write.Line("I hope you know you're gonna pay for that");
                            if (Utilities.CanAfford(50))
                            {
                                Write.Line("You sheepishly give Billiam 50 gold to cover cleaning");
                                Player.p.gold -= 50;
                            }
                            else if (Player.p.fights >= 3)
                            {
                                Write.Line("You don't have the money, but you can work the debt off");
                                Write.Line("LOSE 3 FIGHTS");
                                Player.p.fights -= 3;
                            }
                            else
                            {
                                Write.Line("You don't have the money, but you can work the debt off");
                                Write.Line("You end up working the rest of the day");
                                Write.Line("You can adventure tomorrow");
                                Utilities.Keypress();
                                Utilities.Logout();
                            }

                        }
                        if (roll > 8 && roll < 13)
                        {
                            Write.Line("That was pretty alright");
                            Write.Line("In fact, you're pretty sure you have room for another");
                            Player.p.drinks++;
                        }
                        if (roll > 12 && roll < 16)
                        {
                            Write.Line("This is great");
                            Write.Line("You're so hopped up on sugar, you decide to sing for everyone here!");
                            Write.Line("People throw money at you, and you make 90 gold!");
                            Player.p.gold += 90;
                        }
                        if (roll > 15 && roll < 20)
                        {
                            Write.Line("You feel full of energy!");
                            Write.Line("GAIN 3 FIGHTS");
                            Player.p.fights += 3;
                        }
                        if (roll == 20)
                        {
                            Write.Line("That was life changing soda!");
                            Write.Line("In fact you can feel a change coming over now...");
                            Utilities.Sleep();
                            int x = Utilities.RandomInt(0, 3);
                            Write.Line((x == 0) ? "You gain 1 Strength" : (x == 1) ? "You gain 1 agility" : "You gain 1 Stamina");
                            if (x == 0) Player.p.AddStrength();
                            else if (x == 1) Player.p.AddAgility();
                            else Player.p.AddStamina();
                            Player.p.drinks = 0;
                        }
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
                Write.Line("By the time the shouting match is over, you have been asked to leave the tavern. You can enter again tomorrow.");
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
            else if (roll == 20)
            {
                Write.Line("You wipe the tears away from your eyes.");
                Write.Line("You let Roderick know that that is the most beautiful song you've ever heard.");
                Player.p.tavernBan = true;
                Utilities.Keypress();
                Town.Go();
            }
            else
            {

            }
        }
        else if (Utilities.input == "0") Town.Go();
        else Go();
    }
}