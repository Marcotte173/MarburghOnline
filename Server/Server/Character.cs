using System;
using System.Collections.Generic;
using System.Text;

public class Character
{
    public static void Display()
    {
        Utilities.Clear();
        Write.Line("Name: " + Player.p.name);
        Write.Line("");
        Write.Line("XP: " + Player.p.experience);
        Write.Line("Level: " + Player.p.level);
        Write.Line("");
        Write.Line("Gold: " + Player.p.gold);
        Write.Line("Gold in Bank: " + Player.p.goldInBank);
        Write.Line("");
        Write.Line("Strength: " + Player.p.strength);
        Write.Line("Agility: " + Player.p.agility);
        Write.Line("Stamina: " + Player.p.stamina);
        Write.Line("");
        Write.Line("Damage: " + Player.p.Damage());
        Write.Line("Hit: " + Player.p.Hit());
        Write.Line("Crit: " + Player.p.Crit());
        Write.Line("");
        Write.Line("Defence: " + Player.p.Defence());
        Write.Line("Mitigation: " + Player.p.Mitigation());
        Write.Line("");
        Write.Line("Weapon: " + Player.p.weapon.name);
        Write.Line("Armor: " + Player.p.armor.name);
        Write.Line("");
        Write.Line("Fights today: " + Player.p.fights);
        Write.Line("Town Activities today: " + Player.p.townActions);
        Write.Line("");
        Write.Line("Songs: " + Player.p.songs);
        Write.Line("Drinks: " + Player.p.drinks);
        Utilities.Keypress();
    }
}