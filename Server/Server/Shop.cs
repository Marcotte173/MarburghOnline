using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

public class Shop
{
    public string owner;
    public List<Equipment> forSale = new List<Equipment> { };
    public string ownerRace;
    public string shop;
    public int gold;
    public List<Creature> guards = new List<Creature> { };
    public int page;
    static bool reset;


    public Shop(string owner, string ownerRace, string shop, List<Equipment> forsale)
    {
        this.owner = owner;
        this.ownerRace = ownerRace;
        this.shop = shop;
        this.forSale = forsale;
        gold = 2000;
        guards = new List<Creature> { new Monster("Steve", 4, 4, 4, 300, 10, 2), new Monster("Bill", 4, 4, 4, 300, 10, 2) };
    }

    public void Store()
    {
        Utilities.Clear();
        page = 0;
        Write.Line($"You walk into the {shop} shop. ");
        Write.Line($"{owner} the {ownerRace} comes over to greet you");
        Write.Line("'Greetings! Anything I can help you with?");
        Utilities.JumpY(6);
        if (this == Town.weaponShop) Write.Line($"Your weapon: {Player.p.weapon.name}");
        else Write.Line($"Your armor:  {Player.p.armor.name}");
        Utilities.NewLine(2);
        Write.Line($"Your gold: {Player.p.gold}");
        Utilities.JumpY(25);
        Write.Line("[1] Buy");
        Write.Line("[2] Sell");
        Write.Line("[9] Rob the store!");
        Write.Line("[0] Return to town");
        Utilities.Input();
        if (Utilities.input == "1")
        {
            if(shop == Town.weaponShop.shop)
            {
                if (Player.p.weapon.name == "Fist") Buy();
                else
                {
                    Utilities.Clear();
                    Write.Line("You already have a weapon! Sell your weapon first!");
                    Utilities.Keypress();
                    Store();
                }
            }
            else
            {
                if (Player.p.armor.name == "None") Buy();
                else
                {
                    Utilities.Clear();
                    Write.Line("You already have armor! Sell your armor first!");
                    Utilities.Keypress();
                    Store();
                }
            }            
        }
        else if (Utilities.input == "2") Sell();
        else if (Utilities.input == "9") Write.Line("Not Implemented yet");
        else if (Utilities.input == "0") Town.Go();
        Store();
    }

    public void Buy()
    {        
        Utilities.Clear();
        Write.Line($"Great, what can I get you?");
        Utilities.JumpY(6);
        if (this == Town.weaponShop) Write.Line($"Your weapon: {Player.p.weapon.name}");
        else Write.Line($"Your armor:  {Player.p.armor.name}");
        Utilities.NewLine(2);
        Write.Line($"Your gold: {Player.p.gold}");
        Utilities.JumpY(13);
        if (page == 0)
        {
            for (int i = 1; i < forSale.Count; i++)
            {
                Write.Line(String.Format("{0,-10}{1,-30}{2,-30}", $"[{i}]", forSale[i].name, forSale[i].price));
                if (i == 9) break;
            }
        }
        else
        {
            for (int i = page * 10; i < page * 10 + 10; i++)
            {
                if (i == forSale.Count)
                {
                    reset = true;
                    break;
                }
                Write.Line(String.Format("{0,-10}{1,-30}{2,-30}", $"[{i}]", forSale[i].name, forSale[i].price));
            }
        }
        Utilities.JumpY(25);
        Write.Line("Press any key to continue");
        Utilities.NewLine();
        Write.Line("[B] Buy an item");
        Write.Line("[0] Return to shop");
        Utilities.Input();
        if (Utilities.input == "0")
        {
            page = 0;
        }
        else if (Utilities.input == "b")
        {
            Utilities.Clear();
            Write.Line($"Great! What would you like to buy?");
            Utilities.LongInput();
            int x = 0;
            if (Int32.TryParse(Utilities.input, out x))
            {
                if (Utilities.CanAfford(forSale[x].price))
                {
                    Purchase(forSale[x]);
                }
                else
                {
                    Write.Line("I'm sorry, you don't have the money");
                    Utilities.Keypress();
                    Store();
                }
                    
            }
            else Buy();
        }
        else
        {
            if (reset)
            {
                reset = false;
                page = 0;
                Store();
            }
            else
            {
                page++;
                Buy();
            }            
        }
    }

    private void Purchase(Equipment equipment)
    {
        Utilities.Clear();
        Write.Line("You want to buy " + equipment.name + "? for " + equipment.price + " gold?");
        Utilities.YesNo();
        Utilities.Input();
        if (Utilities.input == "1")
        {
            Utilities.Clear();
            Write.Line("'Fantastic!'");
            Write.Line(owner + " takes your money and gives you the " + equipment.name);
            Player.p.gold -= equipment.price;
            Player.p.Equip(equipment);
            Utilities.Keypress();
        }
        Store();
    }

    public void Sell()
    {
        Utilities.Clear();
        Write.Line($"What would you like to sell?");
        List<Equipment> sell = new List<Equipment> { };
        if (Player.p.weapon.name != "Fist") sell.Add(Player.p.weapon);
        if (Player.p.armor.name != "None") sell.Add(Player.p.armor);
        Utilities.NewLine(2);
        for (int i = 0; i < sell.Count; i++)
        {
            Write.Line($"[{i+1}] {sell[i].name}    {sell[i].price}");
        }
        Utilities.Input();
        int x = 0;
        if (Int32.TryParse(Utilities.input, out x))
        {
            Write.Line("Would you like to sell your " + sell[x - 1] + " for " + sell[x - 1].price / 2 + " gold?");
            Utilities.YesNo();
            Utilities.Input();
            if(Utilities.input == "1")
            {
                Utilities.Clear();
                Write.Line("'Wonderful!'");
                Write.Line(owner + " takes your " + sell[x-1] + " and gives you " + sell[x-1].price/2 + " gold");
                Player.p.gold += sell[x - 1].price / 2;
                Player.p.Unequip(sell[x - 1]);
                Utilities.Keypress();
            }
        }
        else Store();
        Utilities.Keypress();
    }
}