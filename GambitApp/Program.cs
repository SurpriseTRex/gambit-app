using System;
using System.Collections.Generic;

namespace GambitApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var john = new Character("John", 100, 14);
            var enemy = new Character("Enemy", 60, 14);

            var healGambit = new Gambit
            {
                Condition = (actor, target) => target.Health < 10,
                Action = (actor, target) => actor.Heal(333)
            };

            enemy.Gambits.Add(healGambit);

            while (enemy.Health > 0 && john.Health > 0)
            {
                enemy.TriggerGambits();
                
                john.Attack(enemy);
                Console.WriteLine($"Enemy HP: {enemy.Health}");
            }
        }
    }

    public static class GameState
    {
        public static List<Character> Characters { get; set; } = new();
    }
}