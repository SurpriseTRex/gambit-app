using System.Collections.Generic;

namespace GambitApp
{
    public class Character
    {
        public Character(string name, int hp, int damage)
        {
            Name = name;
            Health = hp;
            Damage = damage;
        }
        
        public string Name { get; set; }
        public int Health { get; private set; }
        public int Damage { get; private set; }
        
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
                foreach (var character in GameState.Characters)
                {
                    
                }
            }
        }
    }
}