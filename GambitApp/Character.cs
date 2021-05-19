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
        
        public string Name { get; }
        public int Health { get; private set; }
        public int Mana { get; private set; }
        public Faction Faction { get; }
        public List<Gambit> Gambits { get; } = new();

        public Dictionary<string, int> Inventory { get; } = new();

        public void Heal(int amount) => Health += amount;
        public void Harm(int amount) => Health -= amount;
        public void SetHealth(int newValue) => Health = newValue;
        
        public void RestoreMana(int abilityManaCost) => Mana += abilityManaCost;
        public void SpendMana(int abilityManaCost) => Mana -= abilityManaCost;
        public void SetMana(int newValue) => Mana = newValue;

        public void RunGambits()
        {
            foreach (var gambit in Gambits)
            {
                gambit.Run(this);
            }
        }

        public void Act(Character owner, Character target, IAction item)
        {
            switch (item)
            {
                case Item i: 
                    UseItem(owner, target, i);
                    break;
                case Ability a: 
                    UseAbility(owner, target, a);
                    break;
            }
        }

        public int GetItemQuantityHeld(Item item)
        {
            Inventory.TryGetValue(item.Name, out var qtyHeld);
            return qtyHeld;
        }

        public void AddItem(Item item)
        {
            Inventory.Increment(item.Name);
        }
        
        private void UseItem(Character owner, Character target, Item item)
        {
            var hasItem = GetItemQuantityHeld(item) > 0;
            if (!hasItem) return;

            Inventory.Decrement(item.Name);
            item.Use(owner, target);
        }

        private void UseAbility(Character owner, Character target, Ability ability)
        {
            var hasEnoughMana = ability.ManaCost <= Mana;
            if (!hasEnoughMana) return;

            SpendMana(ability.ManaCost);
            ability.Use(owner, target);
        }
    }
}