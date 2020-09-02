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
<<<<<<< HEAD
    public bool active;
=======
    public int songs;
    public bool tavernBan;
>>>>>>> 7e36894111e33199fe30ad7db59eed8a7dd1d360
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
        gold = 1000;
        goldInBank = 0;
        fights = 15;
        hp = maxHp = 20;
        strength = 3;
        agility = 3;
        stamina = 3;
        experience = 0;
        level = 1;
        points = 2;
        drinks = 3;
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