using System;
using System.Collections.Generic;
using System.Linq;

namespace GambitApp
{
    public class Character
    {
        public Character(string name, int hp, int damage, Hostility hostility = Hostility.Enemy)
        {
            Name = name;
            Health = hp;
            Damage = damage;
            Hostility = hostility;
        }
        
        public string Name { get; }
        public Hostility Hostility { get; }
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
            var possibleTargets = GameState.Characters
                .Where(pt => pt.Hostility == Hostility)
                .ToArray();
            
            foreach (var gambit in Gambits)
            {
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