using System;
using System.Collections.Generic;
using System.Text;

public class Equipment
{
    public string name;
    public int damage;
    public int hit;
    public int crit;
    public int defence;
    public int mitigation;
    public int price;
    public bool weapon;

    public static List<Equipment> weaponList = new List<Equipment>
    {
        new Equipment("Fist", 0,0,0,0),
        new Equipment("Knife", 2,0,0,100),
        new Equipment("Sharp Knife", 4,0,0,400),
        new Equipment("Butcher's Knife", 5,0,0,700),
        new Equipment("Stiletto", 7,0,0,1000),
        new Equipment("Combat Knife", 9,0,0,1500),
        new Equipment("Short Sword", 12,0,0,2000),
        new Equipment("Long Sword", 14,0,0,2500),
        new Equipment("Arming Sword", 16,0,0,3000),
        new Equipment("Falchion", 18,0,0,4000),
        new Equipment("Great Sword", 22,0,0,5000),
        new Equipment("Axe of Death", 25,0,0,7000),
    };

    public static List<Equipment> armorList = new List<Equipment>
    {
        new Equipment("None", 0,0,0),
        new Equipment("Cloth", 2,0,100),
        new Equipment("Robe", 4,0,400),
        new Equipment("Soft Leather", 5,0,700),
        new Equipment("Boiled Leather", 7,0,1000),
        new Equipment("Waxed Leather", 9,0,1500),
        new Equipment("Lamelar", 12,0,2000),
        new Equipment("Chainmail", 14,0,2500),
        new Equipment("Chain and Plate", 16,0,3000),
        new Equipment("Platemail", 18,0,4000),
        new Equipment("Articulated Plate", 22,0,5000),
        new Equipment("Destiny", 25,0,7000),
    };

    public Equipment()
    {
        
    }

    public Equipment(string name, int damage, int hit, int crit, int price)
    {
        this.name = name;
        weapon = true;
        this.damage = damage;
        this.hit = hit;
        this.crit = crit;
        this.price = price;
    }

    public Equipment(string name, int defence, int mitigation, int price)
    {
        this.name = name;
        this.defence = defence;
        this.mitigation = mitigation;
        this.price = price;
        weapon = false;
    }

    public Equipment Copy()
    {
        return (Equipment)MemberwiseClone();
    }
}