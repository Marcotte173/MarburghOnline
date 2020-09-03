using System;
using System.Collections.Generic;
using System.Text;

public class Player:Creature
{
    public int goldInBank;
    public int fights;
    public int points;
    public bool house;
    public int drinks;
    public bool active;
    public int songs;
    public bool tavernBan;
    public string password;
    public Location location;
    public Equipment weapon;
    public Equipment armor;
    public static Player p = new Player(null);
    public Player(string name)
    : base()
    {
        songs = 2;
        this.name = name;
        gold = World.startingGold;
        goldInBank = 0;
        fights = World.fights;
        hp = maxHp = 20;
        strength = 3;
        agility = 3;
        stamina = 3;
        experience = 0;
        level = 1;
        points = 2;
        drinks = World.drinks;
        songs = World.songs;
        weapon = Equipment.weaponList[0].Copy();
        armor = Equipment.armorList[0].Copy();
    }

    public void AddStrength() => strength++;
    public void AddAgility() => agility++;
    public void AddStamina()
    {
        stamina++;
        hp = maxHp = level * 5 + stamina * 5;
    }

    public void Equip(Equipment e)
    {
        if (e.weapon) weapon = e.Copy();
        else armor = e.Copy();
    }

    internal void Unequip(Equipment e)
    {
        if (e.weapon) weapon = Equipment.weaponList[0].Copy();
        else armor = Equipment.armorList[0].Copy();
    }
}