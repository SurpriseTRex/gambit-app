using System;
using System.Collections.Generic;

namespace GambitApp
{
    internal static class Program
    {
        private static void Main()
        {
            var john = new Character("John", 100, 14, Faction.Player);
            var enemy = new Character("Enemy", 60, 14, Faction.Enemy);
            
            GameState.Characters.Add(john);
            GameState.Characters.Add(enemy);

            var potion = new Item("Potion I", target => target.Heal(120));

            var potionGambit = new Gambit(
                Faction.Player,
                (actor, target) => actor.Health < 14,
                (actor, target) => actor.UseItem(potion, target));

            enemy.Gambits.Add(potionGambit);

            while (enemy.Health > 0 && john.Health > 0)
            {
                john.TriggerGambits();
                enemy.TriggerGambits();
                
                john.Attack(enemy);
                Console.WriteLine($"Enemy HP: {enemy.Health}");
            }
        }
    }

    public static class GameState
    {
        public static List<Character> Characters { get; } = new();
    }
}