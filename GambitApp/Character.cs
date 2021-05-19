using System.Collections.Generic;
using GambitApp.Enums;

namespace GambitApp
{
    public class Character
    {
        public Character(string name, int hp, int mp, Faction faction)
        {
            Name = name;
            Health = hp;
            Mana = mp;
            Faction = faction;
        }
        
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public Faction Faction { get; set; }
        public List<ItemGambit> Gambits { get; set; } = new();

        public void RunGambits()
        {
            foreach (var gambit in Gambits)
            {
                gambit.Run(this);
            }
        }
    }
}