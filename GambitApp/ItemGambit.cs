using System;
using System.Collections.Generic;
using System.Linq;
using GambitApp.Enums;

namespace GambitApp
{
    public class ItemGambit
    {
        public TargetType TargetType { get; set; }
        public Func<Character, bool> Condition { get; set; }
        public Item Item { get; set; }


        public void Run(Character owner)
        {
            var eligibleTargets = GetEligibleTargets(owner);

            foreach (var eligibleTarget in eligibleTargets)
            {
                if (Condition.Invoke(eligibleTarget))
                {
                    Item.Use(owner, eligibleTarget);
                    return;
                }   
            }
        }

        private IEnumerable<Character> GetEligibleTargets(Character owner)
        {
            var eligibleTargets = TargetType switch
            {
                TargetType.Self => new[] {owner},
                TargetType.Ally => GameState.Entities.Where(e => e.Faction == owner.Faction),
                TargetType.Enemy => GameState.Entities.Where(e => e.Faction != owner.Faction),
                _ => throw new ArgumentOutOfRangeException(nameof(TargetType), "Not a valid target type. This should never happen.")
            };
            return eligibleTargets;
        }
    }












}