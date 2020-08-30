using System;
using System.Collections.Generic;
using System.Text;

public class Creature
{
    public string name;
    public int maxHp;
    public int hp;
    public int strength;
    public int agility;
    public int stamina;
    public int gold;    
    public int experience;    
    public int level;    
    
    public Creature()
    {

    }

    public void Heal(int heal)
    {
        hp = (hp + heal >= maxHp) ? maxHp : hp + heal;
    }

    public void TakeDamage(int damage)
    {
        hp = (hp - damage <= 0) ? 0 : hp - damage;
        if (hp == 0) Death();
    }

    public virtual void Death()
    {

    }

    public int Damage() { return strength; }
    public int Hit() { return 65 + (level * 5 + agility *2); }
    public int Crit() { return 5 + agility *2; }
    public int Mitigation() { return stamina/3 + 1; }
    public int Defence() { return level * 5 + agility; }
}