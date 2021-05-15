using System;
using System.Collections.Generic;

namespace GambitApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var john = new Character("John", 100, 14, Hostility.Friendly);
            var enemy = new Character("Enemy", 60, 14, Hostility.Enemy);
            
            GameState.Characters.Add(john);
            GameState.Characters.Add(enemy);

            var potion = new Item("Potion I", target => target.Heal(120));

            var potionGambit = new Gambit
            {
                Condition = (actor, target) => actor.Health < 14,
                Action = (actor, target) => actor.UseItem(potion, target)
            };

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