using System;
using System.Collections.Generic;
using System.Linq;

namespace GambitApp
{
    public class Character
    {
        public Character(string name, int hp, int damage, Faction faction = Faction.Enemy)
        {
            Name = name;
            Health = hp;
            Damage = damage;
            Faction = faction;
        }
        
        public string Name { get; }
        public Faction Faction { get; }
        public int Health { get; private set; }
        public int Damage { get; }
        
        public List<Gambit> Gambits { get; } = new();

        public void Heal(int amount)
        {
            Health += amount;
        }

        public void Attack(Character target)
        {
            target.TakeDamage(Damage);
        }

        private void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void TriggerGambits()
        {
            foreach (var gambit in Gambits)
            {
                var possibleTargets = GameState.Characters
                    .Where(pt => pt.Faction == Faction)
                    .Where(pt => pt.Faction == gambit.Faction)
                    .ToArray();
                
                foreach (var potentialTarget in possibleTargets)
                {
                    if (gambit.IsConditionMet(this, potentialTarget))
                    {
                        gambit.Trigger(this, potentialTarget);   
                    }
                    break;
                }
            }
        }

        public void UseItem(Item item, Character target)
        {
            item.Use(target);
            Console.WriteLine($"Used [{item.Name}] on {target.Name}");
        }
    }
}