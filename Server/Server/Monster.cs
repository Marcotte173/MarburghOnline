using System;
using System.Collections.Generic;
using System.Text;

public class Monster:Creature
{
    public static Random rand;
    public Monster(string name, int strength, int agility, int stamina, int gold, int experience, int level)
    :base ()
    {
        this.name = name;
        this.strength = strength;
        this.agility = agility;
        this.stamina = stamina;
        hp = maxHp = level * 5 + stamina * 5;
        this.gold = gold * level+ Utilities.RandomInt(15 + level, 20 * level);
        this.experience = experience * level + Utilities.RandomInt(3 + level, 4 * level);
        this.level = level;
    }
}