using System;
using System.Collections.Generic;
using System.Linq;
using GambitApp.Enums;

namespace GambitApp
{
    internal static class Program
    {
        private static void Main()
        {
            var player = new Character("Jimmy", 100, 10, Faction.Player);
            var friendlyNPC = new Character("Friendly NPC", 30, 100, Faction.Player);
            
            var enemyNPC = new Character("Enemy NPC", 30, 100, Faction.Enemy);

            GameState.Entities.Add(player);
            GameState.Entities.Add(friendlyNPC);
            GameState.Entities.Add(enemyNPC);

            var potion = new Item
            {
                Name = "Potion I",
                Effect = (user, target) => target.Health += 33 
            };
            
            var ether = new Item
            {
                Name = "Ether",
                Effect = (user, target) => target.Mana += 12 
            };
            
            // todo: might want to wrap this in my own class, with a nicer method than Invoke.
            // Could be better than the various kinds of condition classes, as long as
            // I can pass in each part of the gambit condition separately and build a function at runtime.
            
            // if [friendly target] [mana] [less than (%)] [10] then [use ether] on [friendly target]
            // Func<Character, int> test = c => c.Health;
            // int threshold = 20;
            // Dictionary<ThresholdDirection, Func<int, int, bool>> funcs = new()
            // {
            //     {ThresholdDirection.Over, (a, b) => a > b},
            //     {ThresholdDirection.Under, (a, b) => a < b},
            // };
            // var usedFunc = funcs[ThresholdDirection.Under];

            var itemMeta = new GambitCondition(
                c => c.Health,
                (a, b) => a < b,
                30);

            // here ends testing of building this at runtime from parts.
            
            var itemGambit = new ItemGambit
            {
                TargetType = TargetType.Enemy,
                Condition = target => itemMeta.Compose(target),
                Item = potion
            };
            
            player.Gambits.Add(itemGambit);

            for (int i = 10; i > 0; i--)
            {
                player.RunGambits();

                friendlyNPC.Health -= 30;

                Console.WriteLine($"Player: {player.Health}");
                Console.WriteLine($"NPC: {friendlyNPC.Health}");
                Console.Write(Environment.NewLine);
            }
        }
    }
}