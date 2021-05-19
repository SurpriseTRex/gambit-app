using System;
using System.Collections.Generic;
using System.Linq;
using GambitApp.Enums;

namespace GambitApp
{
    public class Gambit
    {
        public TargetType TargetType { get; set; }
        public Func<Character, bool> Condition { get; set; }
        public IAction Action { get; set; }

        public void Run(Character owner)
        {
            var eligibleTargets = GetEligibleTargets(owner);

            foreach (var potentialTarget in eligibleTargets)
            {
                if (ConditionIsMet(potentialTarget))
                {
                    owner.Act(owner, potentialTarget, Action);
                    return;
                }   
            }
        }
        
        private bool ConditionIsMet(Character c) => Condition.Invoke(c);

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